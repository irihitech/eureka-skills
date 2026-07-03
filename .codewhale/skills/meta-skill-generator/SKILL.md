---
name: meta-skill-generator
description: >
  Repository-local meta-skill for scaffolding new skill plugins inside the
  eureka-skills repository. Generates plugin.json, SKILL.md, README.md, and
  updates marketplace manifests following the established conventions.
license: MIT
---

# Meta-Skill Generator

Use this skill when asked to create a new skill plugin or add a skill to an
existing plugin inside the `eureka-skills` repository.

## Repository Conventions

```
plugins/<plugin-name>/
├── plugin.json          # plugin metadata
├── README.md            # optional plugin readme
└── skills/
    └── <skill-name>/
        └── SKILL.md     # the skill definition
```

Marketplace manifests (update when a plugin is added):

- `.claude-plugin/marketplace.json`
- `.cursor-plugin/marketplace.json`
- `.codewhale-plugin/marketplace.json`
- `.agents/plugins/marketplace.json`

## Workflow

### 1. Determine Scope

Ask the user:

- Is this a **new plugin** or a **new skill in an existing plugin**?
- What is the plugin name (kebab-case)?
- What is the skill name (kebab-case)?
- Brief description of what the skill covers.

### 2. Create the Plugin (if new)

Create `plugins/<plugin-name>/plugin.json`:

```json
{
  "name": "<plugin-name>",
  "version": "0.1.0",
  "description": "<one-line description>",
  "skills": ["./skills/"]
}
```

Optionally create `plugins/<plugin-name>/README.md` with a short description.

### 3. Create the Skill

Create `plugins/<plugin-name>/skills/<skill-name>/SKILL.md` with this
structure:

```markdown
---
name: <skill-name>
description: >
  <multi-line description of when to use this skill and what it covers.>
license: MIT
---

# <Human-Readable Title>

<Brief: when to use this skill.>

## Goals

- <goal 1>
- <goal 2>

## Practices

1. <practice 1>
2. <practice 2>
```

**Rules for SKILL.md content:**

- The front matter (`---` block) is required. Use `name`, `description`, and
  `license` fields at minimum.
- The description in front matter is used for skill discovery — make it
  descriptive enough that an agent can decide when to load the skill.
- The body is markdown. Keep it focused: goals first, then concrete practices.
- Avoid generic filler. Every practice should be actionable.

### 4. Update Marketplace Manifests

When a **new plugin** is created, add an entry to all four marketplace
manifests:

- `.claude-plugin/marketplace.json`
- `.cursor-plugin/marketplace.json`
- `.codewhale-plugin/marketplace.json`
- `.agents/plugins/marketplace.json`

The entry format:

```json
{
  "name": "<plugin-name>",
  "source": "./plugins/<plugin-name>",
  "description": "<one-line description>"
}
```

Insert the new entry into the `"plugins"` array.

When adding a **skill to an existing plugin**, marketplace manifests do not
need updating — skills are discovered via `plugin.json`'s `"skills"` field.

### 5. Verify

After creating files:

- Read back each created file to confirm content is correct.
- Confirm `plugin.json` is valid JSON.
- Confirm `SKILL.md` front matter is valid YAML.
- Confirm all four marketplace manifests are valid JSON and contain the new
  entry (if a new plugin was created).
