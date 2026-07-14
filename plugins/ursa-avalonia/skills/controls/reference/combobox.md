---
category: Components
title: ComboBox
subtitle: 组合框
description: Ursa 增强的下拉选择控件，带 Semi 主题样式。
---

# ComboBox / 组合框

Ursa's enhanced dropdown selection control with Semi theme styling. Extends Avalonia's core `ComboBox` with consistent Ursa visual design and theme resources.

Ursa 增强的下拉选择控件，带 Semi 主题样式。基于 Avalonia 核心 `ComboBox` 并应用一致的 Ursa 视觉设计和主题资源。

## When to Use / 何时使用

Use Ursa's `ComboBox` when you need a dropdown selector styled consistently with other Ursa controls. Supports data binding, custom item templates, and editable mode.

当需要与其他 Ursa 控件风格一致的下拉选择器时使用。支持数据绑定、自定义项模板和可编辑模式。

## Basic Usage / 基本使用

```xml
<ursa:ComboBox ItemsSource="{Binding Options}"
               SelectedItem="{Binding SelectedOption}"
               PlaceholderText="Select an option..." />
```

## Styling & Templating / 样式与模板

Theme resources: `ComboBoxBackground`, `ComboBoxBorderBrush`, `ComboBoxPopupBackground`, `ComboBoxItemBackground`, `ComboBoxItemPointeroverBackground`, `ComboBoxItemSelectedBackground`.
