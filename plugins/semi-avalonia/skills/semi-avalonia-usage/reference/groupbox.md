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
        <TextBox PlaceholderText="Server address" />
        <TextBox PlaceholderText="Port" />
    </StackPanel>
</GroupBox>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Header` | `object?` | The group title. / 分组标题。 |
| `Content` | `object?` | The grouped controls. / 分组的控件。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: GroupBox vs Expander? / GroupBox 和 Expander 的区别？**

A: `GroupBox` is always visible — for permanent grouping. `Expander` can collapse — for optional sections. / `GroupBox` 始终可见——用于永久分组。`Expander` 可折叠——用于可选区域。