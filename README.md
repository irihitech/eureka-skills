# IRIHI Tech Agent Skills

This repository is a marketplace of skill plugins for AI coding agents focused on Avalonia and other IRIHI Tech products.

The structure follows the same plugin-first model used by `dotnet/skills`, so the repository can be consumed by multiple agent ecosystems.

## Included Plugins

| Plugin | Description |
| --- | --- |
| [semi-avalonia](plugins/semi-avalonia/) | Semi.Avalonia theme facts (generated from the Semi sources: classes, ControlTheme variants, resource keys, tokens) plus a usage-oriented skill (control selection, scenarios, MVVM, accessibility). |
| [ursa-avalonia](plugins/ursa-avalonia/) | Ursa.Avalonia custom control references (~70 controls) with usage patterns and theme resources. |
| [irihi-lingua](plugins/irihi-lingua/) | Irihi.Lingua Avalonia i18n setup guide — from NuGet installation, resource files, LanguageManager to runtime culture switching. |
| [avalonia-headless-test](plugins/avalonia-headless-test/) | Avalonia headless test setup for control libraries — xUnit + Avalonia.Headless, optional Skia rendering, Fluent or Semi default theme. |

## Agent/Tooling Support

- **Claude Code** via `.claude-plugin/marketplace.json` and each plugin's `.claude-plugin/plugin.json`
- **GitHub Copilot CLI** via `.github/plugin/marketplace.json`
- **Cursor** via `.cursor-plugin/marketplace.json`
- **Codex / Open-standard plugin clients** via `.agents/plugins/marketplace.json` and each plugin's `.codex-plugin/plugin.json`
- **CodeWhale-style marketplaces** via `.codewhale-plugin/marketplace.json`

## Repository Layout

```text
.
├── .agents/plugins/marketplace.json
├── .github/plugin/marketplace.json
├── .claude-plugin/marketplace.json
├── .codewhale-plugin/marketplace.json
├── .cursor-plugin/marketplace.json
└── plugins/
    ├── semi-avalonia/
    │   ├── plugin.json
    │   ├── .claude-plugin/plugin.json
    │   ├── .codex-plugin/plugin.json
    │   ├── provenance/semi-avalonia.json   # hashes of the generated skill (from Semi's generator)
    │   └── skills/
    │       ├── semi-avalonia/               # GENERATED from the Semi.Avalonia sources — do not edit
    │       │   ├── SKILL.md
    │       │   ├── checklist.md
    │       │   └── reference/ (tokens, customization, classes)
    │       └── semi-avalonia-usage/         # handwritten usage guidance
    │           ├── SKILL.md
    │           └── reference/ (65 control files)
    └── irihi-lingua/
        ├── plugin.json
        ├── .claude-plugin/plugin.json
        ├── .codex-plugin/plugin.json
        └── skills/
            └── i18n/SKILL.md
    └── ursa-avalonia/
        ├── plugin.json
        ├── .claude-plugin/plugin.json
        ├── .codex-plugin/plugin.json
        └── skills/
            └── controls/SKILL.md
                └── reference/ (70+ control files)
    └── avalonia-headless-test/
        ├── plugin.json
        ├── .claude-plugin/plugin.json
        ├── .codex-plugin/plugin.json
        └── skills/
            └── headless-test-setup/SKILL.md
```

## Generated Semi skill

`plugins/semi-avalonia/skills/semi-avalonia/` is **generated output**, not hand-written content: it is produced by Semi.Avalonia's own `tools/Semi.Avalonia.Llms` from the theme sources, so its style classes, ControlTheme variants and resource keys always match the Semi release it was generated from. It is synced into this repository by `tools/semi-sync`, which verifies every SHA-256 in the generator's `ai/provenance.json` before replacing the directory:

```bash
# in the Semi.Avalonia checkout:
dotnet run --project tools/Semi.Avalonia.Llms -- . <output-dir>

# in this repository:
dotnet run --project tools/semi-sync -- <output-dir>
```

The plugin works fully offline once installed — the authoritative Semi skill ships inside the plugin; `plugins/semi-avalonia/provenance/semi-avalonia.json` records which Semi version and source revision it was generated from. Never edit `skills/semi-avalonia/` by hand; rerun the generator and the sync tool instead. `skills/semi-avalonia-usage/` is hand-written and contains only usage knowledge (which control to pick, scenarios, MVVM, accessibility) — it deliberately keeps no second copy of the theme facts.

### Keeping the usage skill fact-free

`tools/semi-usage-lint` guards that boundary in two layers:

1. **Syntax boundary in code blocks** — any theming syntax fails, whether or not the name is in today's catalog, so stale names from older Semi releases cannot slip through: `Classes=…`/`FlyoutPresenterClasses=…`, `Theme=…` in XAML or C# (the ControlTheme assignment; `RequestedThemeVariant` is Avalonia platform API and stays legal), `{DynamicResource …}`, `{StaticResource …}` unless the name is a generic `*Geometry`/`*IconGeometry`/`*Converter` resource, and every hard-coded visual color (`#RGB`/`#RRGGBB`/`#AARRGGBB`, `Brushes.<Color>`, `Brush.Parse(…)`, `rgb()/rgba()`).
2. **Contract-derived facts in prose and tables** — the sync tool copies the hash-verified contract to `provenance/semi-avalonia.contract.json`, and the lint reads every class, ControlTheme variant, Semi pseudo-class, control override key and global token from it; none may be spelled out in the usage documents — not even a single name in a table cell or a backticked mention. Avalonia platform vocabulary (built-in pseudo-classes like `:checked`, Alignment/PlacementMode/FontWeight/ThemeVariant/NotificationSeverity enum values, control names) is exempt.

Run it after editing `skills/semi-avalonia-usage/` and after every sync:

```bash
dotnet run --project tools/semi-usage-lint -- .
```

Exit code 0 means clean; violations are reported as `file:line: reason`. Narrow exceptions live in `tools/semi-usage-lint/allowlist.json` — every entry must name its file, term and a non-empty reason, or the run fails. Both guards have their own test suites: `dotnet test tools/semi-sync.tests` (path safety, hash checks, failed commits roll back to the previous skill) and `dotnet test tools/semi-usage-lint.tests` (the lint rules themselves).

## Installation

### Claude Code

Add this repo as a marketplace source, then install the plugins:

```text
/plugin marketplace add irihitech/eureka-skills
/plugin install semi-avalonia@eureka-skills
/plugin install ursa-avalonia@eureka-skills
/plugin install irihi-lingua@eureka-skills
/plugin install avalonia-headless-test@eureka-skills
```

### GitHub Copilot CLI

Use `.github/plugin/marketplace.json` as the marketplace entry point.

### Cursor

Add this repository as a plugin marketplace and install the `semi-avalonia` or `ursa-avalonia` plugins.

### Other compatible clients

Use `.agents/plugins/marketplace.json` as the marketplace entry point for Codex and clients that follow the open Agent Skills plugin format.
