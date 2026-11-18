using System.Security.Cryptography;
using FluentAssertions;
using SemiSync;

namespace SemiSyncTests;

/// <summary>
/// Core guards of the sync tool: a tampered manifest can neither point it at other directories
/// nor inject unverified files, and any failure before the commit leaves the previous skill and
/// the hand-written usage skill intact. Crash leftovers are recovered automatically; a failed
/// metadata write is repaired by rerunning the sync.
/// </summary>
public class SyncRunnerTests : IDisposable
{
    private readonly string _root = Path.Combine(Path.GetTempPath(), "semi-sync-tests", Guid.NewGuid().ToString("N"));
    private readonly string _output;
    private readonly string _repo;
    private readonly StringWriter _errors = new();
    private readonly StringWriter _outputWriter = new();

    public SyncRunnerTests()
    {
        _output = Path.Combine(_root, "generator-out");
        _repo = Path.Combine(_root, "repo");
        // A complete, valid generator output.
        WriteOutput(skillName: "semi-avalonia", skillRoot: "skills/semi-avalonia", contractPath: "ai/semi-avalonia.contract.json", filePath: "SKILL.md");
        // A repository skeleton: a previously synced skill (with stale content), the hand-written
        // usage skill next to it, and the provenance directory.
        Directory.CreateDirectory(Path.Combine(_repo, "plugins", "semi-avalonia", "skills", "semi-avalonia"));
        File.WriteAllText(Path.Combine(_repo, "plugins", "semi-avalonia", "skills", "semi-avalonia", "SKILL.md"), "old generated content");
        Directory.CreateDirectory(Path.Combine(_repo, "plugins", "semi-avalonia", "skills", "semi-avalonia-usage"));
        File.WriteAllText(Path.Combine(_repo, "plugins", "semi-avalonia", "skills", "semi-avalonia-usage", "SKILL.md"), "hand-written usage");
    }

    private void WriteOutput(string skillName, string skillRoot, string contractPath, string? filePath, string? skillContent = null)
    {
        var skillDir = Path.Combine(_output, "skills", "semi-avalonia");
        if (filePath is not null)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(skillDir, filePath))!);
            File.WriteAllText(Path.Combine(skillDir, filePath), skillContent ?? "generated skill v2");
        }
        Directory.CreateDirectory(Path.Combine(_output, "ai"));
        File.WriteAllText(Path.Combine(_output, "ai", "semi-avalonia.contract.json"), "{\"schemaVersion\":1,\"package\":{\"name\":\"Semi.Avalonia\",\"version\":\"12.1.0.1\"}}");
        var contractHash = Hash(Path.Combine(_output, "ai", "semi-avalonia.contract.json"));
        var skillHash = filePath is null ? "" : Hash(Path.Combine(skillDir, filePath));
        var filesJson = filePath is null ? "" : $"{{ \"path\": \"{filePath}\", \"sha256\": \"{skillHash}\" }}";
        var provenance = "{\n" +
            "  \"schemaVersion\": 1,\n" +
            "  \"package\": { \"name\": \"Semi.Avalonia\", \"version\": \"12.1.0.1\" },\n" +
            "  \"sourceRevision\": \"0123456789abcdef0123456789abcdef01234567\",\n" +
            $"  \"contract\": {{ \"path\": \"{contractPath}\", \"sha256\": \"{contractHash}\" }},\n" +
            "  \"skill\": {\n" +
            $"    \"name\": \"{skillName}\",\n" +
            $"    \"root\": \"{skillRoot}\",\n" +
            $"    \"files\": [ {filesJson} ]\n" +
            "  }\n" +
            "}";
        File.WriteAllText(Path.Combine(_output, "ai", "provenance.json"), provenance);
    }

    private int Run() => SyncRunner.Run([_output, "--repo", _repo], _errors, _outputWriter);

    private string TargetSkill => File.ReadAllText(Path.Combine(_repo, "plugins", "semi-avalonia", "skills", "semi-avalonia", "SKILL.md"));
    private string UsageSkill => File.ReadAllText(Path.Combine(_repo, "plugins", "semi-avalonia", "skills", "semi-avalonia-usage", "SKILL.md"));
    private string ProvenanceDir => Path.Combine(_repo, "plugins", "semi-avalonia", "provenance");

    [Fact]
    public void HappyPath_ReplacesSkill_KeepsUsage_CopiesContract()
    {
        Run().Should().Be(0);
        TargetSkill.Should().Be("generated skill v2");
        UsageSkill.Should().Be("hand-written usage");
        File.Exists(Path.Combine(ProvenanceDir, "semi-avalonia.contract.json")).Should().BeTrue();
        File.Exists(Path.Combine(ProvenanceDir, "semi-avalonia.json")).Should().BeTrue();
    }

    [Fact]
    public void RunningTwice_IsIdempotent()
    {
        Run().Should().Be(0);
        var first = TargetSkill;
        Run().Should().Be(0);
        TargetSkill.Should().Be(first);
    }

    [Fact]
    public void ForeignSkillName_IsRefused_AndTargetIntact()
    {
        WriteOutput(skillName: "semi-avalonia-usage", skillRoot: "skills/semi-avalonia", contractPath: "ai/semi-avalonia.contract.json", filePath: "SKILL.md");

        Run().Should().Be(1);
        _errors.ToString().Should().Contain("only syncs 'semi-avalonia'");
        TargetSkill.Should().Be("old generated content");
        UsageSkill.Should().Be("hand-written usage");
    }

    [Fact]
    public void ForeignSkillRoot_IsRefused_AndTargetIntact()
    {
        // A tampered manifest must not be able to point the sync at the hand-written skill.
        WriteOutput(skillName: "semi-avalonia", skillRoot: "skills/semi-avalonia-usage", contractPath: "ai/semi-avalonia.contract.json", filePath: "SKILL.md");

        Run().Should().Be(1);
        _errors.ToString().Should().Contain("not the expected 'skills/semi-avalonia'");
        TargetSkill.Should().Be("old generated content");
        UsageSkill.Should().Be("hand-written usage");
    }

    [Fact]
    public void EscapingFilePath_IsRefused_AndTargetIntact()
    {
        WriteOutput(skillName: "semi-avalonia", skillRoot: "skills/semi-avalonia", contractPath: "ai/semi-avalonia.contract.json", filePath: "../../repo/plugins/semi-avalonia/skills/semi-avalonia-usage/SKILL.md");

        Run().Should().Be(1);
        _errors.ToString().Should().Contain("escapes");
        TargetSkill.Should().Be("old generated content");
        UsageSkill.Should().Be("hand-written usage");
    }

    [Fact]
    public void AbsoluteContractPath_IsRefused()
    {
        WriteOutput(skillName: "semi-avalonia", skillRoot: "skills/semi-avalonia", contractPath: "/etc/passwd", filePath: "SKILL.md");

        Run().Should().Be(1);
        _errors.ToString().Should().Contain("not the expected 'ai/semi-avalonia.contract.json'");
        TargetSkill.Should().Be("old generated content");
    }

    [Fact]
    public void ContractHashMismatch_IsRefused_AndTargetIntact()
    {
        File.WriteAllText(Path.Combine(_output, "ai", "semi-avalonia.contract.json"), "{\"schemaVersion\":1,\"tampered\":true}");

        Run().Should().Be(1);
        _errors.ToString().Should().Contain("sha256 mismatch");
        TargetSkill.Should().Be("old generated content");
    }

    [Fact]
    public void SkillFileMissingFromOutput_IsRefused_AndTargetIntact()
    {
        File.Delete(Path.Combine(_output, "skills", "semi-avalonia", "SKILL.md"));

        Run().Should().Be(1);
        _errors.ToString().Should().Contain("missing from the output");
        TargetSkill.Should().Be("old generated content");
    }

    [Fact]
    public void UnreadableSourceFile_FailsCopy_AndKeepsTarget()
    {
        if (!OperatingSystem.IsMacOS() && !OperatingSystem.IsLinux())
        {
            return; // the permission trick below is unix-only
        }
        var file = Path.Combine(_output, "skills", "semi-avalonia", "SKILL.md");
        File.SetUnixFileMode(file, 0);
        try
        {
            Run().Should().Be(1);
            _errors.ToString().Should().Contain("rerun the sync");
            TargetSkill.Should().Be("old generated content");
            UsageSkill.Should().Be("hand-written usage");
        }
        finally
        {
            File.SetUnixFileMode(file, UnixFileMode.UserRead | UnixFileMode.UserWrite);
        }
    }

    [Fact]
    public void LeftoverBackupWithoutTarget_IsRestored_AndAFailingSyncKeepsIt()
    {
        // A previous run crashed mid-swap: the backup holds the only complete skill. The next run
        // must restore it first, and when that run then fails, the restored skill must survive.
        var skillsDir = Path.Combine(_repo, "plugins", "semi-avalonia", "skills");
        Directory.Delete(Path.Combine(skillsDir, "semi-avalonia"), recursive: true);
        Directory.CreateDirectory(Path.Combine(skillsDir, ".semi-avalonia.backup"));
        File.WriteAllText(Path.Combine(skillsDir, ".semi-avalonia.backup", "SKILL.md"), "crashed run's skill");
        // Fail AFTER the recovery: the provenance target slot is a directory, so the commit fails.
        Directory.CreateDirectory(Path.Combine(ProvenanceDir, "semi-avalonia.json"));

        Run().Should().Be(1);
        // The recovery restored the crashed run's skill, then this run committed its own VERIFIED
        // skill; only the metadata write failed, which rerunning repairs.
        _errors.ToString().Should().Contain("the new skill is in place").And.Contain("rerun the sync to repair");
        TargetSkill.Should().Be("generated skill v2", "the verified new skill stays committed");
        UsageSkill.Should().Be("hand-written usage");
    }

    [Fact]
    public void LeftoverBackupWithTarget_IsCleanedUpAutomatically()
    {
        // A leftover backup beside a complete target is stale by construction (the target only
        // ever gets replaced by a verified staging); it is removed instead of blocking the run.
        var skillsDir = Path.Combine(_repo, "plugins", "semi-avalonia", "skills");
        Directory.CreateDirectory(Path.Combine(skillsDir, ".semi-avalonia.backup"));
        File.WriteAllText(Path.Combine(skillsDir, ".semi-avalonia.backup", "SKILL.md"), "stale skill");

        Run().Should().Be(0);
        _outputWriter.ToString().Should().Contain("Removed the stale skill backup");
        TargetSkill.Should().Be("generated skill v2");
        Directory.Exists(Path.Combine(skillsDir, ".semi-avalonia.backup")).Should().BeFalse();
    }

    [Fact]
    public void LeftoverOldMetadataWithoutCopy_IsRestored()
    {
        Directory.CreateDirectory(ProvenanceDir);
        File.WriteAllText(Path.Combine(ProvenanceDir, "semi-avalonia.json.old"), "only surviving copy");

        Run().Should().Be(0);
        _outputWriter.ToString().Should().Contain("leftover metadata backup");
        File.ReadAllText(Path.Combine(ProvenanceDir, "semi-avalonia.json")).Should().Contain("schemaVersion", "restored, then replaced by this run's sync");
        File.Exists(Path.Combine(ProvenanceDir, "semi-avalonia.json.old")).Should().BeFalse();
    }

    [Fact]
    public void LeftoverOldMetadataBesideCopy_IsResolvedAutomatically()
    {
        Directory.CreateDirectory(ProvenanceDir);
        File.WriteAllText(Path.Combine(ProvenanceDir, "semi-avalonia.json"), "current copy");
        File.WriteAllText(Path.Combine(ProvenanceDir, "semi-avalonia.json.old"), "stale backup");

        Run().Should().Be(0);
        _outputWriter.ToString().Should().Contain("leftover metadata backup");
        File.Exists(Path.Combine(ProvenanceDir, "semi-avalonia.json.old")).Should().BeFalse();
        TargetSkill.Should().Be("generated skill v2");
    }

    [Fact]
    public void MetadataSlotOccupied_NewSkillInPlace_FailsWithRerunHint()
    {
        // Metadata write failure: the (verified) new skill stays committed and the error says the
        // honest state and the repair — rerunning the sync.
        Directory.CreateDirectory(Path.Combine(ProvenanceDir, "semi-avalonia.json"));

        Run().Should().Be(1);
        _errors.ToString().Should().Contain("the new skill is in place").And.Contain("rerun the sync to repair");
        TargetSkill.Should().Be("generated skill v2", "the verified skill stays committed");
        UsageSkill.Should().Be("hand-written usage");
    }

    [Fact]
    public void BackupCleanupFailure_WarnsButSucceeds()
    {
        if (!OperatingSystem.IsMacOS() && !OperatingSystem.IsLinux())
        {
            return; // the permission trick below is unix-only
        }
        // The OLD skill contains a read-only subdirectory, so deleting the backup after a
        // successful commit fails: success plus a warning naming the leftover is the right answer.
        var oldSub = Path.Combine(_repo, "plugins", "semi-avalonia", "skills", "semi-avalonia", "locked");
        Directory.CreateDirectory(oldSub);
        File.WriteAllText(Path.Combine(oldSub, "SKILL.md"), "locked away");
        File.SetUnixFileMode(oldSub, UnixFileMode.UserRead | UnixFileMode.UserExecute);

        try
        {
            Run().Should().Be(0, "the commit itself succeeded; only the cleanup failed");
            _outputWriter.ToString().Should().Contain("warning").And.Contain(".semi-avalonia.backup");
            _errors.ToString().Should().NotContain("error");
            TargetSkill.Should().Be("generated skill v2", "the new content is committed");
            Directory.Exists(Path.Combine(_repo, "plugins", "semi-avalonia", "skills", ".semi-avalonia.backup")).Should().BeTrue();
        }
        finally
        {
            var locked = Path.Combine(_repo, "plugins", "semi-avalonia", "skills", ".semi-avalonia.backup", "locked");
            if (Directory.Exists(locked)) File.SetUnixFileMode(locked, UnixFileMode.UserRead | UnixFileMode.UserWrite | UnixFileMode.UserExecute);
        }
    }

    private static string Hash(string path) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path))).ToLowerInvariant();

    public void Dispose()
    {
        if (OperatingSystem.IsMacOS() || OperatingSystem.IsLinux())
        {
            foreach (var file in Directory.GetFiles(_root, "*", SearchOption.AllDirectories))
            {
                try { File.SetUnixFileMode(file, UnixFileMode.UserRead | UnixFileMode.UserWrite | UnixFileMode.UserExecute); } catch { /* best effort */ }
            }
        }
        try { Directory.Delete(_root, recursive: true); } catch { /* best effort */ }
    }
}
