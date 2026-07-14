---
category: Components
title: AutoCompleteBox
subtitle: 自动完成
description: Ursa 增强的自动完成输入控件，带下拉建议和自定义模板。
---

# AutoCompleteBox / 自动完成

Ursa's enhanced auto-complete text input with dropdown suggestions, custom item templates, and filtering support. Extends Avalonia's core `AutoCompleteBox` with Ursa Semi theme styling.

Ursa 增强的自动完成文本输入控件，带下拉建议、自定义项模板和筛选支持。基于 Avalonia 核心 `AutoCompleteBox` 并应用 Ursa Semi 主题样式。

## When to Use / 何时使用

Use Ursa's `AutoCompleteBox` when you need text input with suggestion-based completion — search bars, tag entry, address lookup. The Ursa variant provides Semi theme styling consistent with other Ursa controls.

当需要带建议完成功能的文本输入时使用 —— 搜索栏、标签输入、地址查找。Ursa 变体提供与其他 Ursa 控件一致的 Semi 主题样式。

## Basic Usage / 基本使用

```xml
<ursa:AutoCompleteBox Watermark="Search..."
                       ItemsSource="{Binding Suggestions}"
                       FilterMode="StartsWith" />
```

## Styling & Templating / 样式与模板

Theme resources: `AutoCompleteBoxBackground`, `AutoCompleteBoxBorderBrush`, `AutoCompleteBoxPopupBackground`, `AutoCompleteBoxPopupBorderBrush`.
