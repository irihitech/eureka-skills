using System.Text;
using FluentAssertions;
using SemiUsageLint;

namespace SemiUsageLintTests;

/// <summary>
/// Regression tests for the lint's two layers, against a minimal contract fixture: classes
/// Primary/Success/Danger (plain) and SolidButton (compound), pseudo-class topright, one
/// override key, one token.
/// </summary>
public class UsageLintTests : IDisposable
{
    private readonly string _repo = Path.Combine(Path.GetTempPath(), "semi-usage-lint-tests", Guid.NewGuid().ToString("N"));

    private const string Contract = """
        {
          "schemaVersion": 1,
          "controls": [
            {
              "name": "Widget",
              "classes": ["Primary", "Success", "Danger", "SolidButton"],
              "variants": [],
              "pseudoClasses": ["topright", "checked"],
              "overrideKeys": ["WidgetDefaultBackground"]
            }
          ],
          "tokens": [{ "key": "SemiColorPrimary", "type": "Brush" }]
        }
        """;

    private string MakeRepo(params (string Name, string Text)[] documents)
    {
        var plugin = Path.Combine(_repo, "plugins", "semi-avalonia");
        Directory.CreateDirectory(Path.Combine(plugin, "skills", "semi-avalonia", "reference"));
        Directory.CreateDirectory(Path.Combine(plugin, "provenance"));
        File.WriteAllText(Path.Combine(plugin, "provenance", "semi-avalonia.contract.json"), Contract);
        foreach (var (name, text) in documents)
        {
            var path = Path.Combine(plugin, "skills", "semi-avalonia-usage", name);
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.WriteAllText(path, text);
        }
        return _repo;
    }

    private (int Exit, string Errors) Run(string repo)
    {
        var errors = new StringBuilder();
        using var writer = new StringWriter(errors);
        var exit = Program.Run([repo], writer, TextWriter.Null);
        return (exit, errors.ToString());
    }

    private (int Exit, string Errors) Lint(params (string Name, string Text)[] documents)
    {
        var repo = MakeRepo(documents);
        var (exit, errors) = Run(repo);
        return (exit, errors);
    }

    [Fact]
    public void InlineHexColorInAxamlAttribute_Fails()
    {
        var (exit, errors) = Lint(("reference/border.md", "# Border\n\n```xml\n<Border Background=\"#fff\" />\n```\n"));

        exit.Should().Be(1);
        errors.Should().Contain("reference/border.md:4").And.Contain("hard-coded visual color");
    }

    [Fact]
    public void FullHexAndArgbColorsInCode_Fail()
    {
        var (exit, errors) = Lint(("reference/a.md", "```xml\n<Border Background=\"#FF800000\" BorderBrush=\"#006AEA\" />\n```\n"),
                                  ("reference/b.md", "```csharp\nvar b = Brush.Parse(\"#80000000\");\nvar c = Color.Parse(\"#ABCDEF\");\n```\n"));

        exit.Should().Be(1);
        errors.Should().Contain("#FF800000").And.Contain("#006AEA").And.Contain("Brush.Parse").And.Contain("Color.Parse");
    }

    [Fact]
    public void IssueNumbersAndAnchorsInProse_Pass()
    {
        var (exit, errors) = Lint(("reference/prose.md", "Fixed in #123 (see #4567). Jump to the [feed section](#feedCard) or [#fff](#abc).\n\nNo colors here.\n"));

        exit.Should().Be(0, because: $"issue references and anchors are not colors; errors: {errors}");
    }

    [Fact]
    public void SameNameSemiClass_WithoutEnumContext_Fails()
    {
        // Success is both a Semi class and a NotificationSeverity value; outside an enum context
        // it must still fail — in prose backticks and as a lone table cell.
        var (exit, errors) = Lint(("reference/table.md", "| Class | Look |\n| --- | --- |\n| `Success` | confirm |\n"),
                                  ("reference/prose.md", "Apply the `Success` class for confirmations.\n"));

        exit.Should().Be(1);
        errors.Should().Contain("table cell").And.Contain("spelled out");
    }

    [Fact]
    public void EnumContextRow_Passes()
    {
        var (exit, errors) = Lint(("reference/severity.md", "| `Severity` | `NotificationSeverity` | `Info`, `Success`, `Warning`, `Error`. |\n"),
                                  ("reference/theme.md", "| `RequestedThemeVariant` | `ThemeVariant` | `Light`, `Dark`, `Default`. |\n"));

        exit.Should().Be(0, because: $"enum documentation is platform API; errors: {errors}");
    }

    [Fact]
    public void EnumContextDoesNotShieldSemiClasses_OnTheSameLine()
    {
        // An enum word on the line exempts only that enum word — a Semi class next to it fails,
        // both in a table row and in prose.
        var (exit, errors) = Lint(("reference/table.md", "| Property | Example |\n| --- | --- |\n| Severity | `Primary` class example |\n"),
                                  ("reference/prose.md", "NotificationSeverity is an Avalonia enum; use `Primary` for a Semi appearance.\n"));

        exit.Should().Be(1);
        errors.Should().Contain("style class 'Primary'");
    }

    [Fact]
    public void EnumWordBesideSemiClass_InTableRow_FailsForTheClassOnly()
    {
        var (exit, errors) = Lint(("reference/mixed.md", "| `Severity` | `Success`, `Warning`, plus `Primary` |\n"));

        exit.Should().Be(1);
        errors.Should().Contain("style class 'Primary'").And.NotContain("'Success'");
    }

    [Fact]
    public void ThemeAssignmentInCSharp_Fails()
    {
        var (exit, errors) = Lint(("reference/code.md", "```csharp\nvar b = new Button { Theme = myTheme };\n```\n"));

        exit.Should().Be(1);
        errors.Should().Contain("theming attribute");
    }

    [Fact]
    public void StaticResourceGeometryPasses_OtherNamesFail()
    {
        var (exit, errors) = Lint(("reference/ok.md", "```xml\n<PathIcon Data=\"{StaticResource MenuIconGeometry}\" />\n```\n"),
                                  ("reference/bad.md", "```xml\n<PathIcon Data=\"{StaticResource SemiIconClose}\" />\n```\n"));

        exit.Should().Be(1);
        errors.Should().Contain("SemiIconClose").And.NotContain("MenuIconGeometry");
    }

    [Fact]
    public void CompoundFactAndPseudoClassAnywhere_Fail()
    {
        var (exit, errors) = Lint(("reference/prose.md", "Use SolidButton with the SemiColorPrimary brush.\n"),
                                  ("reference/wnm.md", "Position it with `:topright`.\n"));

        exit.Should().Be(1);
        errors.Should().Contain("SolidButton").And.Contain("SemiColorPrimary").And.Contain("topright");
    }

    [Fact]
    public void CleanUsageDocument_Passes()
    {
        var (exit, errors) = Lint(("reference/button.md", """
            # Button

Use for immediate actions; bind `Command` in your ViewModel.

```xml
<Button Content="Save" Command="{Binding SaveCommand}" />
```
"""),
            ("reference/theme.md", "| `TextAlignment` | `TextAlignment` | `Left`, `Center`, `Right`. |\n"));

        exit.Should().Be(0, because: errors);
    }

    public void Dispose()
    {
        try { Directory.Delete(_repo, recursive: true); } catch { /* best effort */ }
    }
}
