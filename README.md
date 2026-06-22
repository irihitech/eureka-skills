# IRIHI Tech Agent Skills

This repository is a marketplace of skill plugins for AI coding agents focused on Avalonia and other IRIHI Tech products.

The structure follows the same plugin-first model used by `dotnet/skills`, so the repository can be consumed by multiple agent ecosystems.

## Included Plugins

| Plugin | Description |
| --- | --- |
| [irihi-avalonia](plugins/irihi-avalonia/) | Core Avalonia skills for architecture, MVVM patterns, and styling/theming guidance. |

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
    └── irihi-avalonia/
        ├── plugin.json
        └── skills/
            ├── avalonia-styling-theming/SKILL.md
            └── avalonia-viewmodel-patterns/SKILL.md
```

## Installation

### Claude Code / Copilot CLI

Use the GitHub repository path as marketplace source (`irihitech/eureka-skills`), then install plugins from the `eureka-skills` marketplace manifest.

```text
/plugin marketplace add irihitech/eureka-skills
/plugin install irihi-avalonia@eureka-skills
```

### Cursor

Add this repository as a plugin marketplace and install the `irihi-avalonia` plugin.

### Other compatible clients

Use `.agents/plugins/marketplace.json` as the marketplace entry point for clients that follow the open Agent Skills plugin format.
