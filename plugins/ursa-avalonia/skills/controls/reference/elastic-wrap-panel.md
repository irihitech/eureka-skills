---
category: Panels
title: ElasticWrapPanel
subtitle: 弹性换行面板
description: >
  An enhanced WrapPanel that supports fill-to-edge stretching, fixed-to-right-bottom
  items that force line breaks, and explicit item/line spacing. Inherits from
  Avalonia's WrapPanel and adds IsFillHorizontal, IsFillVertical, and FixToRB.
  增强版 WrapPanel，支持填充到边缘拉伸、固定到右/底并强制换行的项目，以及显式的
  项目/行间距。继承自 Avalonia 的 WrapPanel，增加了 IsFillHorizontal、
  IsFillVertical 和 FixToRB。
---

# ElasticWrapPanel / 弹性换行面板

## When to Use / 何时使用

Use `ElasticWrapPanel` when you need a wrap panel that goes beyond basic
wrapping: fill remaining space on each row/column, pin items to the right or
bottom edge (forcing a line break before them), and use explicit spacing
between items and lines. It inherits all `WrapPanel` properties (`Orientation`,
`ItemWidth`, `ItemHeight`) and adds stretch-fill and right-alignment features.

当需要超越基本换行的换行面板时使用 `ElasticWrapPanel`：填充每行/每列的剩余空间，
将项目固定到右侧或底部边缘（强制在其前换行），以及使用显式的项目间距和行间距。
它继承所有 `WrapPanel` 属性（`Orientation`、`ItemWidth`、`ItemHeight`），
并增加了拉伸填充和右对齐功能。

Avoid `ElasticWrapPanel` when a simple `WrapPanel` is sufficient — it adds
complexity for fill and alignment features you may not need.

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<!-- Horizontal wrap with fill and spacing -->
<u:ElasticWrapPanel Orientation="Horizontal"
                     IsFillHorizontal="True"
                     ItemSpacing="8"
                     LineSpacing="4">
    <Button Content="One" />
    <Button Content="Two" />
    <Button Content="Three" />
</u:ElasticWrapPanel>
```

When `IsFillHorizontal` is `true` and a fixed `ItemWidth` is set, remaining
horizontal space on each row is distributed evenly among the items on that
row — items stretch to fill the full width.

当 `IsFillHorizontal` 为 `true` 且设置了固定的 `ItemWidth` 时，每行剩余的
水平空间将均匀分配给该行的项目——项目拉伸以填充整个宽度。

## Common Scenarios / 常用场景

### 1. Fill-to-edge tag cloud / 填充到边缘的标签云

```xml
<u:ElasticWrapPanel IsFillHorizontal="True"
                     ItemSpacing="6" LineSpacing="4"
                     ItemWidth="80">
    <Border Classes="Tag" Background="..." />
    <Border Classes="Tag" Background="..." />
    <!-- tags stretch to fill each row -->
</u:ElasticWrapPanel>
```

### 2. Right-aligned action button / 右对齐操作按钮

Use the `FixToRB` attached property to pin an item to the right (horizontal)
or bottom (vertical), forcing a line break before it:

```xml
<u:ElasticWrapPanel>
    <Button Content="Save" />
    <Button Content="Undo" />
    <!-- This button always appears at the far right on its own line -->
    <Button Content="Delete"
            u:ElasticWrapPanel.FixToRB="True"
            Classes="Danger" />
</u:ElasticWrapPanel>
```

### 3. Vertical wrap with fill / 垂直换行并填充

```xml
<u:ElasticWrapPanel Orientation="Vertical"
                     IsFillVertical="True"
                     ItemSpacing="4"
                     LineSpacing="6">
    <Button Content="A" />
    <Button Content="B" />
    <Button Content="C" />
</u:ElasticWrapPanel>
```

## Property Reference / 属性参考

### Styled Properties / 样式属性

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `IsFillHorizontal` | `bool` | `false` | When `true`, stretches items on each row to fill the available horizontal space / 为 true 时，拉伸每行的项目以填充可用水平空间 |
| `IsFillVertical` | `bool` | `false` | When `true`, stretches items in each column to fill the available vertical space / 为 true 时，拉伸每列的项目以填充可用垂直空间 |
| `LineCount` | `int` | (read-only) | The number of lines (rows or columns depending on orientation) after the last arrange / 上一次排列后的行数（根据方向为行或列数） |

### Attached Property / 附加属性

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `FixToRB` | `bool` | `false` | When `true` on a child, the child is fixed to the right (horizontal) or bottom (vertical) edge and forces a line break before and after it / 在子元素上设置为 true 时，固定在右侧（水平）/底部（垂直）边缘，并在其前后强制换行 |

### Inherited from WrapPanel

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `Orientation` | `Orientation` | `Horizontal` | Direction items flow: `Horizontal` (left-to-right, top-to-bottom) or `Vertical` (top-to-bottom, left-to-right) |
| `ItemWidth` | `double` | `NaN` | Fixed width for all items; `NaN` means auto-size |
| `ItemHeight` | `double` | `NaN` | Fixed height for all items; `NaN` means auto-size |
| `ItemSpacing` | `double` | `0` | Spacing between items on the same line / 同行项目间距 |
| `LineSpacing` | `double` | `0` | Spacing between lines / 行间间距 |

## Events / 事件

No custom events. Inherits standard `Panel` events.

没有自定义事件。继承标准 `Panel` 事件。

## Styling & Templating / 样式与模板

`ElasticWrapPanel` is a `Panel`, not a templated control — it has no theme or
template parts. It affects `Measure` and `Arrange` when any of its layout
properties change.

`ElasticWrapPanel` 是 `Panel`，不是模板化控件——没有主题或模板部件。

## FAQ / 常见问题

**Q: How does IsFillHorizontal work? / IsFillHorizontal 如何工作？**
A: When `ItemWidth` is set and `IsFillHorizontal` is `true`, the panel
calculates the maximum number of items across all rows, then distributes the
remaining horizontal space evenly as extra width per item. This makes all rows
stretch to the same width.

**Q: What's the difference between FixToRB and right-alignment? / FixToRB 与右对齐有何区别？**
A: `FixToRB` not only right-aligns (or bottom-aligns) the item — it also
forces a line break before it. The item always appears on its own line at the
far edge. This is useful for "more", "delete", or action buttons that should
be visually separated from flowing content.

**Q: Can I use FixToRB in vertical orientation? / 可以在垂直方向使用 FixToRB 吗？**
A: Yes. In vertical orientation, `FixToRB` fixes the item to the bottom of
the column, forcing a column break before it.
