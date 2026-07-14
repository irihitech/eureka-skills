---
category: Components
title: GroupBox
subtitle: 分组框
description: 分组框用于将相关控件分组并显示标题和边框。
---

# GroupBox / 分组框

A container control that groups related controls with a titled border. Inherits from `HeaderedContentControl`.

用于将相关控件分组并带有标题边框的容器控件。继承自 `HeaderedContentControl`。

## When to Use / 何时使用

Use `GroupBox` to visually group related form fields or settings. Best for moderate groups (3-8 controls). For simple labels, use `Label`.

用于视觉上分组相关的表单字段或设置。适合中等规模分组（3-8 个控件）。简单标签使用 `Label`。

## Basic Usage / 基本使用

```xml
<GroupBox Header="Connection Settings">
    <StackPanel Spacing="8">
        <TextBox Watermark="Server address" />
        <TextBox Watermark="Port" />
    </StackPanel>
</GroupBox>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Header` | `object?` | The group title. / 分组标题。 |
| `Content` | `object?` | The grouped controls. / 分组的控件。 |

## Styling & Templating / 样式与模板

Semi.Avalonia styles `GroupBox` with themed header and border. DynamicResource keys: `GroupBoxHeaderForeground`, `GroupBoxBorderBrush`. Template part: `PART_HeaderPresenter`.

## FAQ / 常见问题

**Q: GroupBox vs Expander? / GroupBox 和 Expander 的区别？**

A: `GroupBox` is always visible — for permanent grouping. `Expander` can collapse — for optional sections. / `GroupBox` 始终可见——用于永久分组。`Expander` 可折叠——用于可选区域。