using System.Text.Json;
using System.Text.RegularExpressions;

namespace SemiUsageLint;

// Guards the hand-written usage skill against becoming a second copy of Semi theme facts:
//
//   dotnet run --project tools/semi-usage-lint -- [repo-root]
//
// Layer 1 bans theming syntax outright inside code blocks (Classes=, Theme=, {DynamicResource},
// non-generic {StaticResource}, hard-coded colors), so stale names from older Semi releases
// cannot slip through. Layer 2 reads the synced contract (provenance/semi-avalonia.contract.json,
// copied by tools/semi-sync) and fails when any of its class, variant, pseudo-class, override-key
// or token names is spelled out in prose or tables. Avalonia platform vocabulary (built-in
// pseudo-classes, enum values on lines naming their enum type) is exempt. No Semi name is
// hard-coded here; narrow exceptions live in allowlist.json with a mandatory reason.

public static partial class Program
{
    // Avalonia's built-in pseudo-classes — platform behavior, legal to mention as :name.
    private static readonly HashSet<string> AvaloniaPseudoClasses = new(StringComparer.Ordinal)
    {
        "active", "checked", "closed", "disabled", "empty", "error", "flyout-open", "focus",
        "focus-within", "indeterminate", "invalid", "open", "pointerover", "pressed", "selected",
        "unchecked", "valid", "visited",
    };

    // Avalonia enum values that collide with Semi class names (Success, Warning, Light, …). They
    // stay in the rule set; only a line naming the enum's type or property exempts them.
    private static readonly HashSet<string> AvaloniaEnumValues = new(StringComparer.Ordinal)
    {
        "Bold", "Bottom", "Center", "Dark", "Error", "Info", "Informational", "Left", "Light",
        "Normal", "Right", "Stretch", "Strikethrough", "Success", "Top", "Underline", "Warning",
    };

    // Enum type names and the properties that take those values.
    private static readonly HashSet<string> EnumContextWords = new(StringComparer.Ordinal)
    {
        "ButtonSpinnerLocation", "ExpandDirection", "FontWeight", "HorizontalAlignment",
        "Location", "NotificationSeverity", "Placement", "PlacementMode",
        "RequestedThemeVariant", "Severity", "SpinnerLocation", "TextAlignment",
        "TextDecoration", "TextDecorations", "ThemeVariant", "VerticalAlignment",
    };

    [GeneratedRegex(@"[""']\#(?:[0-9a-fA-F]{8}|[0-9a-fA-F]{6}|[0-9a-fA-F]{3})(?![0-9A-Za-z])|Brushes\.[A-Z][A-Za-z0-9]+|Brush\.Parse\s*\(|Color\.Parse\s*\(|rgba?\(\s*\d")]
    private static partial Regex ColorPatternRegex();

    [GeneratedRegex(@"\b(?:FlyoutPresenterClasses|Classes)\s*=|\bTheme\s*=")]
    private static partial Regex ThemingAttributeRegex();

    [GeneratedRegex(@"\{DynamicResource\b|\{StaticResource\s+([A-Za-z0-9_.]+)\s*\}")]
    private static partial Regex ResourceReferenceRegex();

    private static bool GenericResourceName(string name) =>
        name.EndsWith("IconGeometry", StringComparison.Ordinal)
        || name.EndsWith("Geometry", StringComparison.Ordinal)
        || name.EndsWith("Converter", StringComparison.Ordinal);

    public static int Main(string[] args) => Run(args);

    public static int Run(string[] args, TextWriter? errorWriter = null, TextWriter? outputWriter = null)
    {
        var errors = errorWriter ?? Console.Error;
        var output = outputWriter ?? Console.Out;
        var repo = args.Length > 0 ? Path.GetFullPath(args[0]) : Directory.GetCurrentDirectory();
        var plugin = Path.Combine(repo, "plugins", "semi-avalonia");
        var generated = Path.Combine(plugin, "skills", "semi-avalonia");
        var usage = Path.Combine(plugin, "skills", "semi-avalonia-usage");
        var contractPath = Path.Combine(plugin, "provenance", "semi-avalonia.contract.json");
        if (!Directory.Exists(generated) || !Directory.Exists(usage))
        {
            errors.WriteLine($"error: '{plugin}' does not contain both skills — pass the eureka-skills root.");
            return 2;
        }
        if (!File.Exists(contractPath))
        {
            errors.WriteLine("error: plugins/semi-avalonia/provenance/semi-avalonia.contract.json is missing — run tools/semi-sync first.");
            return 2;
        }

        // Layer 2 rules: every concrete fact name from the synced contract.
        using var contract = JsonDocument.Parse(File.ReadAllText(contractPath));
        var controlNames = contract.RootElement.GetProperty("controls").EnumerateArray()
            .Select(c => c.GetProperty("name").GetString()!).ToHashSet(StringComparer.Ordinal);
        var classes = new HashSet<string>(StringComparer.Ordinal);
        var variants = new HashSet<string>(StringComparer.Ordinal);
        var pseudoClasses = new HashSet<string>(StringComparer.Ordinal);
        var overrideKeys = new HashSet<string>(StringComparer.Ordinal);
        foreach (var control in contract.RootElement.GetProperty("controls").EnumerateArray())
        {
            foreach (var name in control.GetProperty("classes").EnumerateArray().Select(x => x.GetString()!)) classes.Add(name);
            foreach (var name in control.GetProperty("variants").EnumerateArray().Select(x => x.GetString()!)) variants.Add(name);
            foreach (var name in control.GetProperty("pseudoClasses").EnumerateArray().Select(x => x.GetString()!)) pseudoClasses.Add(name);
            foreach (var name in control.GetProperty("overrideKeys").EnumerateArray().Select(x => x.GetString()!)) overrideKeys.Add(name);
        }
        var tokens = contract.RootElement.GetProperty("tokens").EnumerateArray()
            .Select(t => t.GetProperty("key").GetString()!).ToHashSet(StringComparer.Ordinal);

        // A name that is also an Avalonia control name (including by case alone: ToolTip the
        // variant vs the Tooltip control) is dropped — usage documents talk about controls.
        bool IsControlName(string name) => controlNames.Any(c => string.Equals(c, name, StringComparison.OrdinalIgnoreCase));
        classes.RemoveWhere(IsControlName);
        variants.RemoveWhere(IsControlName);

        var compound = new HashSet<string>(StringComparer.Ordinal);
        var plain = new HashSet<string>(StringComparer.Ordinal);
        foreach (var name in classes.Concat(variants).Concat(overrideKeys).Concat(tokens))
        {
            if (PlainWordRegex().IsMatch(name)) plain.Add(name);
            else compound.Add(name);
        }
        pseudoClasses.RemoveWhere(p => AvaloniaPseudoClasses.Contains(p));
        output.WriteLine($"Rules from the synced contract: {classes.Count} classes, {variants.Count} variants, "
                          + $"{pseudoClasses.Count} Semi pseudo-classes, {overrideKeys.Count} override keys, {tokens.Count} tokens "
                          + $"({compound.Count} checked everywhere, {plain.Count} plain words in tables/backticks).");

        var (allows, allowlistErrors) = LoadAllows(Path.Combine(repo, "tools", "semi-usage-lint", "allowlist.json"));
        var violations = new List<string>(allowlistErrors);
        var files = Directory.GetFiles(usage, "*.md", SearchOption.AllDirectories).OrderBy(x => x, StringComparer.Ordinal).ToArray();
        foreach (var file in files)
        {
            var relative = Path.GetRelativePath(usage, file).Replace('\\', '/');
            var inCode = false;
            var lines = File.ReadAllLines(file);
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line.TrimStart().StartsWith("```", StringComparison.Ordinal))
                {
                    inCode = !inCode;
                    continue;
                }

                if (inCode)
                {
                    // Layer 1: theming syntax is out of bounds in examples, full stop.
                    if (ThemingAttributeRegex().IsMatch(line))
                        violations.Add($"{relative}:{i + 1}: theming attribute (Classes=/Theme=) in a code block — drop it; for Semi looks load the generated semi-avalonia skill");
                    if (line.Contains("{DynamicResource", StringComparison.Ordinal))
                        violations.Add($"{relative}:{i + 1}: {{DynamicResource}} in a code block — drop the visual property or point at the generated semi-avalonia skill");
                    foreach (Match reference in ResourceReferenceRegex().Matches(line))
                    {
                        if (!reference.Groups[1].Success) continue;
                        if (!GenericResourceName(reference.Groups[1].Value))
                            violations.Add($"{relative}:{i + 1}: {{StaticResource}} '{reference.Groups[1].Value}' is not an obviously generic resource — replace it or allowlist it with a reason");
                    }
                }

                foreach (Match color in ColorPatternRegex().Matches(line).Cast<Match>().DistinctBy(m => m.Value))
                    violations.Add($"{relative}:{i + 1}: hard-coded visual color '{color.Value.Trim('\"', '\'')}' — drop the visual property or point at the generated semi-avalonia skill");

                // Layer 2: concrete contract facts must not be spelled out.
                foreach (var term in compound.Where(t => Word(t).IsMatch(line)))
                    if (!allows.Contains((relative, term)))
                        violations.Add($"{relative}:{i + 1}: Semi fact '{term}' (from the synced contract) must not appear here");
                // Pseudo-classes only count as :name or `name` — bare prose words like "left" or "top" stay legal.
                foreach (var term in pseudoClasses.Where(t => Regex.IsMatch(line, $"(?:^|(?<!\\w):|`){Regex.Escape(t)}\\b")))
                    if (!allows.Contains((relative, term)))
                        violations.Add($"{relative}:{i + 1}: Semi pseudo-class '{term}' — remove it or point at the generated semi-avalonia skill");
                // Plain-word class names collide with English and enum values, so bare prose proves
                // nothing — but a backticked mention or a lone table cell is a spelled-out fact.
                // The enum exemption covers only the enum words themselves, never a Semi class
                // sitting next to them on the same line.
                var enumContext = !inCode && EnumContextWords.Any(line.Contains);
                bool Exempt(string term) => enumContext && AvaloniaEnumValues.Contains(term);
                if (!inCode)
                    foreach (var term in plain.Where(t => !Exempt(t) && line.Contains($"`{t}`", StringComparison.Ordinal)))
                        if (!allows.Contains((relative, term)))
                            violations.Add($"{relative}:{i + 1}: style class '{term}' spelled out — remove it or point at the generated semi-avalonia skill");
                var table = !inCode && line.TrimStart().StartsWith('|') && !Regex.IsMatch(line.TrimStart(), @"^\|[\s\-:|]+\|?$");
                if (table)
                {
                    foreach (var cell in line.Trim().Trim('|').Split('|'))
                    {
                        var value = cell.Trim().Trim('`');
                        if (plain.Contains(value) && !Exempt(value) && !allows.Contains((relative, value)))
                            violations.Add($"{relative}:{i + 1}: style class '{value}' in a table cell — remove it or point at the generated semi-avalonia skill");
                    }
                }
            }
        }

        foreach (var violation in violations) errors.WriteLine(violation);
        output.WriteLine(violations.Count == 0
            ? $"OK: {files.Length} usage documents carry no Semi theme facts, theming syntax or hard-coded colors."
            : $"{violations.Count} violation(s) in plugins/semi-avalonia/skills/semi-avalonia-usage.");
        return violations.Count == 0 ? 0 : 1;
    }

    [GeneratedRegex(@"^[A-Z][a-z]+$")]
    private static partial Regex PlainWordRegex();

    private static Regex Word(string term) => new($"\\b{Regex.Escape(term)}\\b");

    private static (HashSet<(string File, string Term)> Allows, List<string> Errors) LoadAllows(string path)
    {
        var allows = new HashSet<(string, string)>(new AllowComparer());
        var errors = new List<string>();
        if (!File.Exists(path)) return (allows, errors);
        using var document = JsonDocument.Parse(File.ReadAllText(path));
        foreach (var entry in document.RootElement.GetProperty("allows").EnumerateArray())
        {
            allows.Add((entry.GetProperty("file").GetString()!, entry.GetProperty("term").GetString()!));
            if (!entry.TryGetProperty("reason", out var reason) || string.IsNullOrWhiteSpace(reason.GetString()))
                errors.Add($"allowlist.json: entry for '{entry.GetProperty("term").GetString()}' in '{entry.GetProperty("file").GetString()}' has no reason — every allowlist entry needs one.");
        }
        return (allows, errors);
    }

    private sealed class AllowComparer : IEqualityComparer<(string File, string Term)>
    {
        public bool Equals((string File, string Term) x, (string File, string Term) y) => x.File == y.File && x.Term == y.Term;
        public int GetHashCode((string File, string Term) obj) => HashCode.Combine(obj.File, obj.Term);
    }
}
