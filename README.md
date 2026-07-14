# IRIHI Tech Agent Skills

This repository is a marketplace of skill plugins for AI coding agents focused on Avalonia and other IRIHI Tech products.

The structure follows the same plugin-first model used by `dotnet/skills`, so the repository can be consumed by multiple agent ecosystems.

## Included Plugins

| Plugin | Description |
| --- | --- |
| [semi-avalonia](plugins/semi-avalonia/) | Semi.Avalonia control references (65 controls) with DynamicResource keys and theme customization. |
| [ursa-avalonia](plugins/ursa-avalonia/) | Ursa.Avalonia custom control references (~70 controls) with usage patterns and theme resources. |

## Agent/Tooling Support

- **Claude Code / Copilot CLI** via `.claude-plugin/marketplace.json`
- **Cursor** via `.cursor-plugin/marketplace.json`
- **Open-standard plugin clients** via `.agents/plugins/marketplace.json`
- **CodeWhale-style marketplaces** via `.codewhale-plugin/marketplace.json`

## Repository Layout

```text
.
├── .agents/plugins/marketplace.json
├── .claude-plugin/marketplace.json
├── .codewhale-plugin/marketplace.json
├── .cursor-plugin/marketplace.json
└── plugins/
    ├── semi-avalonia/
    │   ├── plugin.json
    │   └── skills/
    │       ├── controls/SKILL.md
    │       │   └── reference/ (65 control files)
    │       └── theme/SKILL.md
    └── ursa-avalonia/
        ├── plugin.json
        └── skills/
            └── controls/SKILL.md
                └── reference/ (70+ control files)
```

## Installation

### Claude Code / Copilot CLI

Add this repo as a marketplace source, then install the plugins:

```text
/plugin marketplace add irihitech/eureka-skills
/plugin install semi-avalonia@eureka-skills
/plugin install ursa-avalonia@eureka-skills
```

### Cursor

Add this repository as a plugin marketplace and install the `semi-avalonia` or `ursa-avalonia` plugins.

### Other compatible clients

Use `.agents/plugins/marketplace.json` as the marketplace entry point for clients that follow the open Agent Skills plugin format.
