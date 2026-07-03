---
name: avalonia-control-skill-generator
description: >
  Repository-local meta-skill for generating a control reference page inside an
  existing skill under an Avalonia control library plugin. Does not produce a
  standalone skill.
license: MIT
---

# Avalonia Control Skill Generator

Use this skill when asked to create a reference for a specific Avalonia control
inside an existing skill of a control library plugin.

## Workflow

1. Ask the user:
   - **Library name** (e.g. `irihi-avalonia`) — determines the plugin directory.
   - **Parent skill** (e.g. `controls`) — the existing skill this reference
     belongs to.
   - **Control name** (kebab-case, e.g. `color-picker`).
   - **One-line description** of what the control does.
2. Create the reference at:
   `plugins/<library-name>/skills/<parent-skill>/<control-name>.md`
3. Populate using the template below.

## Template

All generated references must be **dual-language** (English + Simplified Chinese).
Every section heading is bilingual. Descriptive text is provided in both
languages. Code snippets are language-agnostic.

```markdown
# <ControlName> / <控件名>

## When to Use / 何时使用

<English: one paragraph describing when this control is appropriate.>

<中文：一段描述该控件适用场景的文字。This is the most important section —
agents use it to decide whether to load the reference.>

## Basic Usage / 基本使用

<Simplest XAML + C# snippet — equivalent to the "基本使用" demo.>

## Common Scenarios / 常用场景

<2-4 representative scenarios with XAML/C# snippets, analogous to the sample's
demo sections (e.g. sizing, data binding, event handling). Each scenario gets a
bilingual heading and code block.>

## Property Reference / 属性参考

<Key properties and events table. Not an exhaustive API dump; focus on the
properties agents most often need when generating or reviewing Avalonia code.

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| ... | ... | ... |

Optionally include a version/备注 column.>

## Styling & Templating / 样式与模板

<How to style the control, relevant style keys, ControlTheme structure, and
Template Parts — mapping from the sample's "Semantic DOM" section.
Dual-language description.>

## FAQ / 常见问题

<1-3 known pitfalls or frequently asked questions. Each Q&A pair in both
languages.>
```

## Rules

- Output is a plain markdown reference page — **no YAML front matter**, not a
  standalone `SKILL.md`.
- Path: `plugins/<library-name>/skills/<parent-skill>/<control-name>.md`.
- **Dual-language**: every heading and descriptive paragraph in both English and
  Simplified Chinese. Code blocks are language-neutral.
- **When to Use / 何时使用** is the most critical section — it must be clear
  and specific so agents can decide when to load this reference.
- Derive code snippets from the official Avalonia documentation and IRIHI Tech
  conventions, not from the React sample directly.
- Keep the property table focused on what an agent actually needs — not a
  copy-paste of the full API reference.
- After writing, read back the file to confirm correctness.
