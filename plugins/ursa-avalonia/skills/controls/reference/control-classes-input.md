---
category: Components
title: ControlClassesInput
subtitle: 控件样式类输入
description: 用于可视化选择和管理 Avalonia 控件 Style Classes 的编辑器。

# ControlClassesInput / 控件样式类输入

A visual editor for selecting and managing Avalonia style classes on controls. Displays available classes as interactive chips/tags that can be toggled on or off.

用于可视化选择和管理 Avalonia 控件样式类的编辑器。将可用类显示为可切换的交互式标签。

## When to Use / 何时使用

Use `ControlClassesInput` in designer tools, theme editors, or dev tools where users need to visually compose a set of style classes for a control. Classes are displayed as toggleable chips.

在设计师工具、主题编辑器或开发工具中使用，用户需可视化组合控件的样式类集合。类以可切换标签形式显示。

## Basic Usage / 基本使用

```xml
<ursa:ControlClassesInput Classes="{Binding ActiveClasses}"
                           AvailableClasses="{Binding AllClasses}" />
```

## Styling & Templating / 样式与模板

Displays each class as a styled chip/tag. Theme resources: `ControlClassesInputChipBackground`, `ControlClassesInputChipForeground`, `ControlClassesInputChipSelectedBackground`.
