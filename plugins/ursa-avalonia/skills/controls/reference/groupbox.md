---
category: Components
title: GroupBox
subtitle: 分组框
description: Ursa 增强的分组框控件，带 Semi 主题样式。
---

# GroupBox / 分组框

Ursa's enhanced group box control with Semi theme styling. Provides a bordered container with a header label for grouping related controls. Extends `HeaderedContentControl`.

Ursa 增强的分组框控件，带 Semi 主题样式。提供带标题标签的边框容器，用于分组相关控件。继承自 `HeaderedContentControl`。

## When to Use / 何时使用

Use Ursa's `GroupBox` to visually group related form controls under a common header — settings categories, filter sections, configuration panels. The Ursa variant provides Semi theme styling.

使用 Ursa `GroupBox` 在共同标题下视觉分组相关表单控件 —— 设置分类、筛选区域、配置面板。Ursa 变体提供 Semi 主题样式。

## Basic Usage / 基本使用

```xml
<ursa:GroupBox Header="Connection Settings">
    <StackPanel Spacing="8">
        <TextBox Watermark="Server address" />
        <TextBox Watermark="Port" />
    </StackPanel>
</ursa:GroupBox>
```

## Styling & Templating / 样式与模板

Theme resources: `GroupBoxBackground`, `GroupBoxBorderBrush`, `GroupBoxBorderThickness`, `GroupBoxCornerRadius`, `GroupBoxHeaderBackground`, `GroupBoxHeaderForeground`.
