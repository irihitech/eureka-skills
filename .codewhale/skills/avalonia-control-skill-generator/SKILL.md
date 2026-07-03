---
name: avalonia-control-skill-generator
description: >
  Repository-local meta-skill for generating a skill that covers a specific
  Avalonia control. Scaffolds a SKILL.md under the irihi-avalonia plugin with
  control-specific goals and practices.
license: MIT
---

# Avalonia Control Skill Generator

Use this skill when asked to create a skill for a specific Avalonia control
inside the `irihi-avalonia` plugin.

## Workflow

1. Ask the user for the control name and a one-line description.
2. Create `plugins/irihi-avalonia/skills/<control-name>/SKILL.md`.
3. Populate using the template below.

## SKILL.md Template

```markdown
---
name: <control-name>
description: >
  Guidance for using the Avalonia <ControlName> control in IRIHI Tech
  applications. Covers common patterns, styling, and best practices.
license: MIT
---

# <ControlName>

<One-line description of when to use this control, mapped from the sample's
"何时使用" section.>

## 基本使用

<Simplest XAML + C# snippet — equivalent to the "基本使用" demo.>

## 常用场景

<2-4 representative scenarios with XAML/C# snippets, analogous to the sample's
demo sections (e.g. sizing, data binding, event handling). Each scenario gets a
short heading and code block.>

## 属性参考

<Key properties and events table. Not an exhaustive API dump; focus on the
properties agents most often need when generating or reviewing Avalonia code.
Format: | 属性 | 类型 | 说明 |, optionally with a version/备注 column.>

## 样式与模板

<How to style the control, relevant style keys, ControlTheme structure, and
Template Parts — mapping from the sample's "Semantic DOM" section.>

## 常见问题

<1-3 known pitfalls or frequently asked questions, analogous to "FAQ".>
```

## Rules

- Output path is always `plugins/irihi-avalonia/skills/<control-name>/SKILL.md`.
- Derive code snippets from the official Avalonia documentation and IRIHI Tech
  conventions, not from the React sample directly.
- Keep the property table focused on what an agent actually needs — not a
  copy-paste of the full API reference.
- After writing, read back the file and confirm the front matter is valid YAML.
