using System.Security.Cryptography;
using System.Text.Json;

namespace SemiSync;

/// <summary>
/// Syncs the Semi.Avalonia generator's output (skills + AI contract) into this repository's
/// semi-avalonia plugin: verify the provenance hashes, stage the new skill, swap it in.
///
/// Nothing from the manifest is trusted as a path — the skill name, skill root and contract path
/// must equal the generator's fixed layout, and listed files must stay inside that layout.
/// The tool is deliberately not a filesystem transaction: the generated skill is deterministic
/// and git-tracked, rerunning the sync is idempotent, and failures say what state they left.
/// </summary>
public static class SyncRunner
{
    private const string SkillName = "semi-avalonia";
    private const string SkillRoot = "skills/semi-avalonia";
    private const string ContractPath = "ai/semi-avalonia.contract.json";
    private const string ProvenancePath = "ai/provenance.json";

    public static int Run(string[] args, TextWriter? errorWriter = null, TextWriter? outputWriter = null)
    {
        var errors = errorWriter ?? Console.Error;
        var output = outputWriter ?? Console.Out;
        try
        {
            return RunCore(args, errors, output);
        }
        catch (Exception ex)
        {
            errors.WriteLine($"error: sync failed ({ex.Message}) — inspect the skill directory and rerun the sync.");
            return 1;
        }
    }

    private static int RunCore(string[] args, TextWriter errors, TextWriter output)
    {
        int Fail(string message)
        {
            errors.WriteLine($"error: {message}");
            return 1;
        }

        var outputDir = "";
        var repo = Environment.CurrentDirectory;
        for (var i = 0; i < args.Length; i++)
        {
            if (args[i] == "--repo" && i + 1 < args.Length) repo = Path.GetFullPath(args[++i]);
            else if (outputDir.Length == 0) outputDir = args[i];
            else return Fail($"unexpected argument '{args[i]}'.");
        }
        if (outputDir.Length == 0)
        {
            errors.WriteLine("usage: semi-sync <semi-generator-output-dir> [--repo <eureka-skills-root>]");
            return 2;
        }
        outputDir = Path.GetFullPath(outputDir);

        var pluginDir = Path.Combine(repo, "plugins", "semi-avalonia");
        if (!Directory.Exists(pluginDir))
        {
            return Fail($"'{pluginDir}' does not exist — pass the eureka-skills checkout with --repo.");
        }

        // 1. Load the provenance record; only the fixed generator layout is accepted.
        var provenancePath = Path.Combine(outputDir, "ai", "provenance.json");
        if (!File.Exists(provenancePath))
        {
            return Fail($"'{provenancePath}' is missing — point me at a Semi.Avalonia.Llms output directory.");
        }
        using var provenance = JsonDocument.Parse(File.ReadAllText(provenancePath), new JsonDocumentOptions { AllowTrailingCommas = true });
        var root = provenance.RootElement;
        if ((root.TryGetProperty("schemaVersion", out var schema) && schema.TryGetInt32(out var schemaVersion) ? schemaVersion : -1) != 1)
        {
            return Fail($"provenance schemaVersion is not 1 — regenerate the Semi output with a matching tool.");
        }
        var skill = root.GetProperty("skill");
        if (skill.GetProperty("name").GetString() != SkillName)
        {
            return Fail($"provenance describes skill '{skill.GetProperty("name").GetString()}', but this tool only syncs '{SkillName}'.");
        }
        if (skill.GetProperty("root").GetString() != SkillRoot)
        {
            return Fail($"provenance skill root '{skill.GetProperty("root").GetString()}' is not the expected '{SkillRoot}' layout.");
        }
        var contract = root.GetProperty("contract");
        if (contract.GetProperty("path").GetString() != ContractPath)
        {
            return Fail($"provenance contract path '{contract.GetProperty("path").GetString()}' is not the expected '{ContractPath}' layout.");
        }
        var package = root.GetProperty("package");
        var revision = root.TryGetProperty("sourceRevision", out var rev) ? rev.GetString() : null;
        output.WriteLine($"Semi {package.GetProperty("name").GetString()} {package.GetProperty("version").GetString()}, skill '{SkillName}', source revision {(string.IsNullOrEmpty(revision) ? "(none)" : revision[..Math.Min(12, revision.Length)])}.");

        // 2. Verify the contract and every skill file against the provenance hashes; no extra files.
        var sourceSkillDir = Path.Combine(outputDir, SkillRoot.Replace('/', Path.DirectorySeparatorChar));
        if (!Directory.Exists(sourceSkillDir))
        {
            return Fail($"'{sourceSkillDir}' is missing — the generator output has no skill to sync.");
        }
        var contractFile = Path.Combine(outputDir, ContractPath.Replace('/', Path.DirectorySeparatorChar));
        if (!File.Exists(contractFile))
        {
            return Fail($"'{contractFile}' is missing — the contract must ship with the provenance record.");
        }
        string Hash(string path) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path))).ToLowerInvariant();
        if (Hash(contractFile) != contract.GetProperty("sha256").GetString()!)
        {
            return Fail("contract: sha256 mismatch — regenerate the Semi output and retry.");
        }

        var expected = skill.GetProperty("files").EnumerateArray()
            .ToDictionary(f => f.GetProperty("path").GetString()!, f => f.GetProperty("sha256").GetString()!, StringComparer.Ordinal);
        foreach (var path in expected.Keys)
        {
            if (!InsideSkillRoot(path))
            {
                return Fail($"provenance lists '{path}', which escapes the '{SkillRoot}' directory — refusing.");
            }
        }
        foreach (var file in Directory.GetFiles(sourceSkillDir, "*", SearchOption.AllDirectories))
        {
            var relative = Path.GetRelativePath(sourceSkillDir, file).Replace('\\', '/');
            if (!expected.TryGetValue(relative, out var hash))
            {
                return Fail($"'{SkillRoot}/{relative}' exists in the output but not in provenance.json.");
            }
            if (Hash(file) != hash)
            {
                return Fail($"'{SkillRoot}/{relative}': sha256 mismatch — regenerate the Semi output and retry.");
            }
            expected.Remove(relative);
        }
        if (expected.Count > 0)
        {
            return Fail($"provenance.json lists '{SkillRoot}/{expected.Keys.Order().First()}' but the file is missing from the output.");
        }

        // 3. Stage the new skill next to the target and re-verify it.
        var targetSkillDir = Path.Combine(pluginDir, "skills", SkillName);
        var stagingDir = Path.Combine(pluginDir, "skills", $".{SkillName}.staging");
        var sourceFiles = Directory.GetFiles(sourceSkillDir, "*", SearchOption.AllDirectories).OrderBy(x => x, StringComparer.Ordinal).ToArray();
        try
        {
            if (Directory.Exists(stagingDir)) Directory.Delete(stagingDir, recursive: true);
            foreach (var file in sourceFiles)
            {
                var destination = Path.Combine(stagingDir, Path.GetRelativePath(sourceSkillDir, file));
                Directory.CreateDirectory(Path.GetDirectoryName(destination)!);
                File.Copy(file, destination, overwrite: true);
            }
            var staged = Directory.GetFiles(stagingDir, "*", SearchOption.AllDirectories)
                .ToDictionary(f => Path.GetRelativePath(stagingDir, f).Replace('\\', '/'), f => f, StringComparer.Ordinal);
            if (staged.Count != sourceFiles.Length)
            {
                return Fail("staging is incomplete — the previous generated skill is kept.");
            }
            foreach (var file in staged)
            {
                if (Hash(file.Value) != Hash(Path.Combine(sourceSkillDir, file.Key.Replace('/', Path.DirectorySeparatorChar))))
                {
                    return Fail($"staged '{file.Key}' differs from the source — the previous generated skill is kept.");
                }
            }
        }
        catch (Exception ex)
        {
            if (Directory.Exists(stagingDir)) Directory.Delete(stagingDir, recursive: true);
            return Fail($"copying the generated skill failed ({ex.Message}) — the previous generated skill is kept.");
        }

        // 4. Recover leftovers from a crashed previous run: a surviving target only ever came from
        //    a verified staging, so anything beside it is stale and can be cleaned or restored.
        var backupDir = Path.Combine(pluginDir, "skills", $".{SkillName}.backup");
        if (Directory.Exists(backupDir))
        {
            if (Directory.Exists(targetSkillDir))
            {
                Directory.Delete(backupDir, recursive: true);
                output.WriteLine($"Removed the stale skill backup left by a previous run ('{backupDir}').");
            }
            else
            {
                Directory.Move(backupDir, targetSkillDir);
                output.WriteLine($"Recovered the generated skill left in '{backupDir}' by a crashed previous run.");
            }
        }
        var provenanceCopyDir = Path.Combine(pluginDir, "provenance");
        if (Directory.Exists(provenanceCopyDir))
        {
            foreach (var oldPath in Directory.GetFiles(provenanceCopyDir, "*.old"))
            {
                var live = oldPath[..^".old".Length];
                if (File.Exists(live)) File.Delete(oldPath);
                else File.Move(oldPath, live);
                output.WriteLine($"Resolved the leftover metadata backup '{oldPath}'.");
            }
        }

        // 5. Swap the verified staging in, keeping the old directory aside until the swap is done.
        var hadOldSkill = false;
        try
        {
            if (Directory.Exists(targetSkillDir))
            {
                Directory.Move(targetSkillDir, backupDir);
                hadOldSkill = true;
            }
            Directory.Move(stagingDir, targetSkillDir);
        }
        catch (Exception ex)
        {
            if (Directory.Exists(stagingDir)) Directory.Delete(stagingDir, recursive: true);
            if (Directory.Exists(targetSkillDir)) Directory.Delete(targetSkillDir, recursive: true);
            if (hadOldSkill && Directory.Exists(backupDir)) Directory.Move(backupDir, targetSkillDir);
            return Fail($"committing the new skill failed ({ex.Message}) — the previous generated skill is kept; rerun the sync to retry.");
        }

        // 6. Write the metadata; a failure here is repaired by rerunning the sync (idempotent).
        try
        {
            Directory.CreateDirectory(provenanceCopyDir);
            File.Copy(provenancePath, Path.Combine(provenanceCopyDir, $"{SkillName}.json"), overwrite: true);
            File.Copy(contractFile, Path.Combine(provenanceCopyDir, $"{SkillName}.contract.json"), overwrite: true);
        }
        catch (Exception ex)
        {
            return Fail($"the new skill is in place, but writing the provenance metadata failed ({ex.Message}) — rerun the sync to repair it.");
        }
        if (Directory.Exists(backupDir))
        {
            try
            {
                Directory.Delete(backupDir, recursive: true);
            }
            catch (Exception cleanup)
            {
                output.WriteLine($"warning: the new skill is in place, but its backup could not be removed ({cleanup.Message}) — " +
                                 $"delete '{backupDir}' manually; the next run removes it automatically.");
            }
        }

        output.WriteLine($"Synced {sourceFiles.Length} skill files to plugins/semi-avalonia/skills/{SkillName} " +
                         $"and copied the provenance record and contract to plugins/semi-avalonia/provenance/ ({SkillName}.json, {SkillName}.contract.json).");
        output.WriteLine($"skills/{SkillName}/ is generated — do not edit it by hand; rerun the Semi generator instead.");
        return 0;
    }

    /// <summary>Relative, free of "..", and inside the skill root after normalization (which also
    /// rejects absolute paths and Windows drive forms).</summary>
    private static bool InsideSkillRoot(string path)
    {
        if (path.Length == 0 || Path.IsPathRooted(path) || path.Contains("..", StringComparison.Ordinal))
        {
            return false;
        }
        var baseDir = Path.GetFullPath(Path.Combine(Path.GetTempPath(), "skill-root"));
        var normalized = Path.GetFullPath(Path.Combine(baseDir, path));
        return normalized.StartsWith(baseDir + Path.DirectorySeparatorChar, StringComparison.Ordinal);
    }
}
