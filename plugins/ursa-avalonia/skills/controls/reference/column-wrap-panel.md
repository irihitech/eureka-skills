---
category: Layout
title: ColumnWrapPanel
subtitle: 列换行面板
description: >
  A Panel that arranges children into a fixed number of columns, wrapping items
  to the next row when they exceed the column width. Items can span multiple
  columns based on their desired width. Supports keyboard navigation.
  将子元素排列为固定列数的 Panel，当元素超出列宽时换行到下一行。元素可根据
  期望宽度跨越多列。支持键盘导航。
---

# ColumnWrapPanel / 列换行面板

## When to Use / 何时使用

Use `ColumnWrapPanel` when you need a grid-like layout with a fixed number of
columns where items wrap to the next row automatically. Unlike `UniformGrid`,
items can span multiple columns based on their desired width, making it ideal
for responsive card grids, image galleries, and dashboard layouts.

当需要固定列数的网格布局且元素自动换行到下一行时，使用 `ColumnWrapPanel`。
与 `UniformGrid` 不同，元素可根据期望宽度跨越多列，非常适合响应式卡片网格、
图片画廊和仪表板布局。

Avoid `ColumnWrapPanel` for simple uniform grids — use `UniformGrid` or
`VirtualizingUniformGrid` instead. Avoid for horizontal single-row layouts —
use `StackPanel` or `WrapPanel`.

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<u:ColumnWrapPanel Column="3">
    <Border Background="Red" Height="100" />
    <Border Background="Green" Height="100" />
    <Border Background="Blue" Height="100" />
    <Border Background="Yellow" Height="100" />
    <Border Background="Purple" Height="100" />
    <Border Background="Orange" Height="100" />
</u:ColumnWrapPanel>
```

With `Column="3"`, the panel divides the available width into 3 equal columns.
Items are placed left-to-right, wrapping to the next row when the current row
is full.

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `Column` | `int` | `int.MaxValue` | Number of columns in the grid (must be > 0) / 网格列数（必须 > 0） |

Inherits all properties from `Panel` (`Background`, `Children`, etc.).

继承 `Panel` 的全部属性。

## Layout Behavior / 布局行为

- The available width is divided equally by `Column` to determine the unit
  column width.
- Each child is measured. Its column span is calculated as
  `ceil(desiredWidth / unitWidth)`, clamped to `Column`.
- Children wrap to the next row when the remaining space on the current row
  is insufficient.
- A child whose desired width exceeds the total panel width is clamped to
  `Column` columns and fills the entire row.

## Styling & Templating / 样式与模板

`ColumnWrapPanel` is a pure layout `Panel` with no built-in theme or
control template. It inherits default `Panel` styling only.

`ColumnWrapPanel` 是纯布局 `Panel`，没有内置主题或控件模板。仅继承默认
`Panel` 样式。

## FAQ / 常见问题

**Q: What happens when Column is very large? / Column 很大时会发生什么？**
A: `Column` defaults to `int.MaxValue`, which effectively means "no column
limit" — items are placed with their natural widths and wrap only when the
panel width is exceeded.

**Q: Can items span multiple columns? / 元素可以跨越多列吗？**
A: Yes. Each child's column span is automatically computed from its desired
width relative to the unit column width. Wider items naturally occupy more
columns.

**Q: Does it support keyboard navigation? / 支持键盘导航吗？**
A: `ColumnWrapPanel` implements `INavigableContainer`, but `GetControl()`
returns `null` — directional navigation is not implemented (returns `null`
for all directions).
