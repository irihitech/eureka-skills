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

```markdown
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

- Output is a plain markdown reference page — **no YAML front matter**, not a
  standalone `SKILL.md`.
- Path: `plugins/<library-name>/skills/<parent-skill>/<control-name>.md`.
- Derive code snippets from the official Avalonia documentation and IRIHI Tech
  conventions, not from the React sample directly.
- Keep the property table focused on what an agent actually needs — not a
  copy-paste of the full API reference.
- After writing, read back the file to confirm correctness.
