---
name: ursa-avalonia-controls
description: >
  Ursa.Avalonia control references with usage patterns, styling conventions,
  and theme resources. Load individual control references from
  `reference/<control-name>.md` when generating or reviewing code involving
  specific Ursa.Avalonia controls.
license: MIT
---

# Ursa.Avalonia Controls / Ursa.Avalonia 控件

Use this skill when working with Ursa.Avalonia controls in XAML or C#. Each
control has a dedicated reference page under `reference/` with property tables,
Ursa-specific styling, theme resources, and bilingual usage guidance.

在 XAML 或 C# 中使用 Ursa.Avalonia 控件时加载此 Skill。每个控件在 `reference/`
下都有专属参考页面，包含属性表格、Ursa 专属样式、主题资源和双语使用指南。

## How to Use / 如何使用

When the user asks about a specific control, load the corresponding reference:

当用户询问某个特定控件时，加载对应的参考文件：

```
reference/<control-name>.md
```

When the user asks about **Ursa.Avalonia-specific themes** or **control-specific
resources**, load the corresponding control reference — the `Styling & Templating`
section documents every special theme and resource key defined by Ursa.Avalonia.

当用户询问 **Ursa.Avalonia 特殊主题**或**控件专属资源**时，加载对应的控件参考文件。

Each reference contains / 每个参考页面包含：
- **When to Use / 何时使用** — criteria to decide whether this control is appropriate. / 判断是否应使用该控件的条件。
- **Basic Usage / 基本使用** — minimal XAML + C# snippet. / 最简 XAML + C# 示例。
- **Common Scenarios / 常用场景** — 2-4 realistic patterns with code. / 2-4 个真实场景及代码。
- **Property Reference / 属性参考** — key properties and events in a table. / 表格形式的属性和事件。
- **Styling & Templating / 样式与模板** — Ursa.Avalonia themes, pseudo-classes, template parts. / Ursa.Avalonia 主题、伪类、模板部件。
- **FAQ / 常见问题** — common pitfalls and cross-control comparisons. / 常见陷阱和跨控件对比。

## Controls Index / 控件索引

Controls to be added as references are created.

控件参考页面将随创建逐步添加。
