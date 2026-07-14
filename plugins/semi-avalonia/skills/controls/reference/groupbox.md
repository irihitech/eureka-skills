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

### Theme Architecture / 主题架构

The `GroupBox` control's default theme (`{x:Type GroupBox}`) is defined in `GroupBox.axaml` as a `StaticResource` alias that forwards to the `GroupBox` key in `HeaderedContentControl.axaml`:

`GroupBox` 控件的默认主题（`{x:Type GroupBox}`）在 `GroupBox.axaml` 中定义为 `StaticResource` 别名，转发到 `HeaderedContentControl.axaml` 中的 `GroupBox` 键：

```xml
<!-- GroupBox.axaml -->
<StaticResource x:Key="{x:Type GroupBox}" ResourceKey="GroupBox"/>
```

The actual `GroupBox` `ControlTheme` (TargetType: `HeaderedContentControl`) lives in `HeaderedContentControl.axaml`. It renders a bordered container with a header row, an optional separator line (visible only when both Header and Content are non-null), and a content area. See the `HeaderedContentControl` reference page for the complete `GroupBox` theme documentation.

实际的 `GroupBox` `ControlTheme`（TargetType: `HeaderedContentControl`）位于 `HeaderedContentControl.axaml` 中。它渲染一个带边框的容器，包含标题行、可选的分隔线（仅当标题和内容均非 null 时可见）和内容区域。完整的 `GroupBox` 主题文档请参见 `HeaderedContentControl` 参考页。

### Special ControlThemes / 特殊控件主题

The `GroupBox` theme itself is a special non-default theme on `HeaderedContentControl`. Refer to the [HeaderedContentControl](headeredcontentcontrol.md) page for the full `GroupBox` theme specification, dynamic resource keys, and template parts.

`GroupBox` 主题本身是 `HeaderedContentControl` 上的一个特殊非默认主题。完整的 `GroupBox` 主题规范、动态资源键和模板部件请参见 [HeaderedContentControl](headeredcontentcontrol.md) 页面。

## FAQ / 常见问题

**Q: GroupBox vs Expander? / GroupBox 和 Expander 的区别？**

A: `GroupBox` is always visible — for permanent grouping. `Expander` can collapse — for optional sections. / `GroupBox` 始终可见——用于永久分组。`Expander` 可折叠——用于可选区域。