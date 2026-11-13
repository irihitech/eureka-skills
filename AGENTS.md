# Repository Instructions

This repository stores skill plugins under `plugins/`.

Each folder under `plugins/` is an independent plugin with:

- `plugin.json` metadata
- optional plugin `README.md`
- one or more skills under `skills/<skill-name>/SKILL.md`

Marketplace manifests are available for multiple agent ecosystems:

- `.claude-plugin/marketplace.json`
- `.cursor-plugin/marketplace.json`
- `.codewhale-plugin/marketplace.json`
- `.agents/plugins/marketplace.json`

## Generated content

`plugins/semi-avalonia/skills/semi-avalonia/` is generated from the Semi.Avalonia sources — never edit it by hand. Sync it with `tools/semi-sync` (`dotnet run --project tools/semi-sync -- <Semi.Avalonia.Llms output dir>`), which verifies the generator's `ai/provenance.json` hashes before replacing the directory and records them in `plugins/semi-avalonia/provenance/semi-avalonia.json`. Hand-written knowledge belongs in `plugins/semi-avalonia/skills/semi-avalonia-usage/`, which must not duplicate theme facts (classes, variants, resource keys, token values) — it points at the generated skill instead.

`tools/semi-usage-lint` (`dotnet run --project tools/semi-usage-lint -- .`) enforces that boundary in two layers: inside code blocks, any theming syntax fails outright (`Classes=`, `Theme=` (XAML or C#), `{DynamicResource}`, non-generic `{StaticResource}`, hard-coded colors) so stale names from older Semi releases cannot slip through; in prose and tables, the class/variant/pseudo-class/override-key/token names read from the synced `provenance/semi-avalonia.contract.json` (copied by `tools/semi-sync`) must not be spelled out — single names in table cells or backticked mentions fail too, while lines documenting an Avalonia enum (Severity, FontWeight, Placement, Alignment, …) are exempt for that vocabulary. Run it after touching `skills/semi-avalonia-usage/` and after every sync; exceptions go in `tools/semi-usage-lint/allowlist.json` with a non-empty reason (an entry without one fails the run). `tools/semi-sync.tests` and `tools/semi-usage-lint.tests` pin both tools' rules.

**Both tools are behavior-frozen on purpose.** Their job is to keep AI assistants supplied with accurate theme facts, not to survive every conceivable filesystem mishap: `semi-sync` verifies hashes, stages, and swaps, and any failure is recovered by rerunning it (it is idempotent) or by git — not by deeper transaction machinery. Do not add further defensive layers (backup transactions, rollback-of-rollback, stale-state aborts) without a concrete failure that rerunning the sync cannot repair.
