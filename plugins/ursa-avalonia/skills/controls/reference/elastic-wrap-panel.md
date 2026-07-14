---
category: Layout
title: ElasticWrapPanel
subtitle: 弹性换行面板
description: >
  A WrapPanel extension with fill modes and a FixToRB attached property for
  fixed-to-right/bottom items that force line breaks. Supports IsFillHorizontal
  and IsFillVertical to stretch items within each row/column.
  WrapPanel 扩展，提供填充模式和 FixToRB 附加属性（固定到右侧/底部的元素强制
  换行）。支持 IsFillHorizontal 和 IsFillVertical 以拉伸每行/列中的元素。
---

# ElasticWrapPanel / 弹性换行面板

## When to Use / 何时使用

Use `ElasticWrapPanel` when you need a wrapping layout with the ability to
pin certain items to the right edge (horizontal) or bottom edge (vertical),
forcing a line break before them. It extends `WrapPanel` and adds fill modes
that stretch items to fill available space in each row or column.

当需要换行布局且能将某些元素固定在右侧（水平）或底部（垂直）并强制其前换行时，
使用 `ElasticWrapPanel`。它继承自 `WrapPanel`，增加了填充模式以拉伸每行或
每列中的元素填满可用空间。

Avoid `ElasticWrapPanel` for simple wrapping without fill or pinning — use
plain `WrapPanel` instead.

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<!-- Simple elastic wrap (like WrapPanel but with horizontal fill) -->
<u:ElasticWrapPanel IsFillHorizontal="True" ItemSpacing="8">
    <Button Content="One" />
    <Button Content="Two" />
    <Button Content="Three" Width="120" />
    <Button Content="Four" />
</u:ElasticWrapPanel>
```

## Attached Properties / 附加属性

### FixToRB — Fixed to Right/Bottom / 固定到右侧/底部

```xml
<u:ElasticWrapPanel Orientation="Horizontal">
    <Button Content="Item 1" />
    <Button Content="Item 2" />
    <!-- This item forces a line break and sticks to the right -->
    <Button Content="Right-Aligned"
            u:ElasticWrapPanel.FixToRB="True" />
</u:ElasticWrapPanel>
```

When `FixToRB="True"`:
- In **Horizontal** orientation: the item is fixed to the **right** edge and
  forces a line break before itself.
- In **Vertical** orientation: the item is fixed to the **bottom** edge and
  forces a column break before itself.

`FixToRB="True"` 时：
- **Horizontal** 方向：元素固定在**右侧**边缘，并强制其前换行。
- **Vertical** 方向：元素固定在**底部**边缘，并强制其前列换行。

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `IsFillHorizontal` | `bool` | `false` | When `true`, items in each row are stretched to fill the available horizontal space / 为 `true` 时拉伸每行元素填满水平可用空间 |
| `IsFillVertical` | `bool` | `false` | When `true`, items in each column are stretched to fill the available vertical space / 为 `true` 时拉伸每列元素填满垂直可用空间 |
| `LineCount` | `int` | (computed) | Read-only number of lines/rows in the current layout / 只读，当前布局的行数 |

### Attached Properties / 附加属性

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `u:ElasticWrapPanel.FixToRB` | `bool` | `false` | Fix item to right (horizontal) or bottom (vertical); forces a line break / 固定到右侧（水平）或底部（垂直）；强制换行 |

Inherits all properties from `WrapPanel` (`Orientation`, `ItemWidth`,
`ItemHeight`, `ItemSpacing`, `LineSpacing`).

继承 `WrapPanel` 的全部属性。

## Fill Behavior / 填充行为

- `IsFillHorizontal`: In horizontal orientation, each row's items are
  proportionally stretched horizontally to consume the full row width.
- `IsFillVertical`: In horizontal orientation, all items in a row are
  stretched vertically to match the tallest item in that row.
- The fill direction semantics flip for vertical orientation (`IsFillHorizontal`
  becomes vertical fill, `IsFillVertical` becomes horizontal fill).

## Styling & Templating / 样式与模板

`ElasticWrapPanel` is a pure layout `Panel` with no built-in theme or
control template. It inherits default `Panel` styling only.

`ElasticWrapPanel` 是纯布局 `Panel`，没有内置主题或控件模板。仅继承默认
`Panel` 样式。

## FAQ / 常见问题

**Q: How is FixToRB different from HorizontalAlignment="Right"? / FixToRB 与 HorizontalAlignment="Right" 有何不同？**
A: `FixToRB` forces a **line break** before the item, then pins it to the
right/bottom edge of the available space. `HorizontalAlignment` only affects
positioning within the current line without breaking.

**Q: Can I use both IsFillHorizontal and IsFillVertical together? / 可以同时使用 IsFillHorizontal 和 IsFillVertical 吗？**
A: Yes. When both are `true`, items fill both dimensions within their row/column.

**Q: Does LineCount update dynamically? / LineCount 动态更新吗？**
A: Yes. `LineCount` is recalculated during each `MeasureOverride` pass.
