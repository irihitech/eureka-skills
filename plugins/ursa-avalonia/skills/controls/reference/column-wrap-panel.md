---
category: Panels
title: ColumnWrapPanel
subtitle: 列换行面板
description: >
  A Panel that arranges child elements in a fixed number of columns, wrapping
  to the next row when the current row is full. Children can span multiple
  columns based on their desired width. Implements INavigableContainer.
  按固定列数排列子元素的 Panel，当前行满时自动换行。子元素可根据所需宽度跨越多列。
  实现了 INavigableContainer。
---

# ColumnWrapPanel / 列换行面板

## When to Use / 何时使用

Use `ColumnWrapPanel` when you need a grid-like layout where items wrap across
a fixed number of columns, and each item can span multiple columns based on
its desired width. This is ideal for dashboard widgets, card grids, toolbar
buttons, and any layout where items should flow in columns with automatic
wrapping.

当需要固定列数的网格布局，且每个项目根据所需宽度自动跨列换行时，使用
`ColumnWrapPanel`。适用于仪表板小部件、卡片网格、工具栏按钮以及任何需要按列
流动并自动换行的布局。

Avoid `ColumnWrapPanel` for uniform grids — use `UniformGrid` instead.
Avoid `ColumnWrapPanel` for virtualized large datasets — use
`VirtualizingUniformGrid` instead.

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<u:ColumnWrapPanel Column="3">
    <Border Background="Red" Height="80" Width="120" />
    <Border Background="Green" Height="80" Width="200" />  <!-- spans 2 cols -->
    <Border Background="Blue" Height="80" Width="100" />
    <Border Background="Orange" Height="80" Width="150" />
</u:ColumnWrapPanel>
```

Items are arranged left-to-right. When an item's desired width exceeds the
remaining space in the current row, it wraps to the next row. Each item
occupies `ceil(DesiredWidth / (PanelWidth / Column))` column slots.

子元素从左到右排列。当某个项目的所需宽度超过当前行剩余空间时，换到下一行。
每个项目占据 `ceil(DesiredWidth / (PanelWidth / Column))` 列槽。

## Common Scenarios / 常用场景

### 1. Card grid with variable-width cards / 可变宽度的卡片网格

```xml
<u:ColumnWrapPanel Column="4">
    <Border Classes="Card" Width="300">  <!-- wide card, spans 2+ cols -->
        <TextBlock Text="Featured" />
    </Border>
    <Border Classes="Card" Width="150">
        <TextBlock Text="Normal" />
    </Border>
    <Border Classes="Card" Width="150">
        <TextBlock Text="Normal" />
    </Border>
</u:ColumnWrapPanel>
```

### 2. Toolbar button wrap / 工具栏按钮换行

```xml
<u:ColumnWrapPanel Column="6">
    <Button Content="Cut" Width="80" />
    <Button Content="Copy" Width="80" />
    <Button Content="Paste with formatting" Width="180" />  <!-- wide -->
    <Button Content="Delete" Width="80" />
</u:ColumnWrapPanel>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `Column` | `int` | `int.MaxValue` | Number of columns to divide the available width into. Must be > 0 / 将可用宽度划分的列数，必须 > 0 |

Inherits all properties from `Panel` (`Children`, `Background`, etc.).

继承 `Panel` 的全部属性。

## Events / 事件

No custom events. Standard `Panel` events apply.

没有自定义事件。应用标准 `Panel` 事件。

## Styling & Templating / 样式与模板

`ColumnWrapPanel` is a `Panel`, not a templated control — it has no theme or
template parts. It affects `Measure` and `Arrange` when `Column` changes.

`ColumnWrapPanel` 是 `Panel`，不是模板化控件——没有主题或模板部件。当 `Column`
变化时影响 `Measure` 和 `Arrange`。

### Layout Algorithm / 布局算法

1. Compute `unit = availableWidth / Column`
2. For each child, compute `colSpan = ceil(desiredWidth / unit)`, clamped to `Column`
3. If the child doesn't fit in the current row, start a new row
4. Each child gets `colSpan * unit` width (stretched to column grid)

## FAQ / 常见问题

**Q: How is ColumnWrapPanel different from WrapPanel? / ColumnWrapPanel 与 WrapPanel 有何不同？**
A: `WrapPanel` wraps by pixel width — items flow until they don't fit.
`ColumnWrapPanel` divides the space into a fixed number of equal-width
columns, and items occupy an integer number of column slots. This produces a
column-aligned grid even when items vary in width.

**Q: What happens if Column is very large? / 如果 Column 很大会怎样？**
A: The default is `int.MaxValue`, which effectively disables the column
constraint — items never wrap. Set a reasonable number like 2, 3, or 4.

**Q: Does ColumnWrapPanel support keyboard navigation? / ColumnWrapPanel 支持键盘导航吗？**
A: It implements `INavigableContainer` but `GetControl` currently returns
`null` — keyboard navigation is not yet implemented.
