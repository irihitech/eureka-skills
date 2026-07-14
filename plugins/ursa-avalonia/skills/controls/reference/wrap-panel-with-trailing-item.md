---
category: Layout
title: WrapPanelWithTrailingItem
subtitle: 带尾随项的换行面板
description: >
  A Panel that arranges children like a WrapPanel (left-to-right, wrapping rows)
  but reserves a trailing item that either fits on the last line or wraps to a
  new line based on a configurable width threshold.
  像 WrapPanel 一样排列子元素的 Panel（从左到右，自动换行），但保留一个尾随项，
  根据可配置的宽度阈值决定尾随项放在最后一行还是换到新行。
---

# WrapPanelWithTrailingItem / 带尾随项的换行面板

## When to Use / 何时使用

Use `WrapPanelWithTrailingItem` when you have a flow of items (like tags,
chips, or filter pills) with a trailing action element (like a "more" button
or "+N" indicator) that should stay on the last line if there is room, or
wrap to its own line if the remaining space is too narrow.

当有一组流动项目（如标签、芯片或筛选胶囊）且末尾有一个操作元素（如"更多"
按钮或"+N"指示器）时使用 `WrapPanelWithTrailingItem`。尾随项在空间充足时
保持在最后一行，空间不足时换到新行。

Avoid this panel for simple wrapping — use `WrapPanel` instead. The trailing
item feature adds complexity that is only worthwhile when you need the
threshold-based wrap behavior for the last item.

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<u:WrapPanelWithTrailingItem TrailingWrapWidth="80">
    <Button Content="Tag 1" />
    <Button Content="Tag 2" />
    <Button Content="Tag 3" />
    <Button Content="Tag 4" />
    <Button Content="Tag 5" />

    <!-- Trailing item: shows on last line if ≥80px space, else wraps to new line -->
    <u:WrapPanelWithTrailingItem.TrailingItem>
        <Button Content="+3 More" Classes="Link" />
    </u:WrapPanelWithTrailingItem.TrailingItem>
</u:WrapPanelWithTrailingItem>
```

## How It Works / 工作原理

1. All regular children are arranged like a `WrapPanel`: left-to-right,
   wrapping to the next row when the current row is full.
2. After all regular children are placed, the `TrailingItem` is measured.
3. If the remaining space on the last line is **≥ TrailingWrapWidth**, the
   trailing item is placed on that line (rightmost position).
4. If the remaining space is **< TrailingWrapWidth**, the trailing item wraps
   to a new line below the last row of regular children, spanning the full
   width.

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `TrailingItem` | `Layoutable?` | `null` | The item to place at the end of the last row / 放在最后一行末尾的项目 |
| `TrailingWrapWidth` | `double` | `0` | Minimum width required on the last line for the trailing item to stay inline; if less, wraps to a new line / 尾随项保持内联所需的最小行宽；不足时换到新行 |

When `TrailingItem` is set, it is added to both `VisualChildren` and
`LogicalChildren` (unless the panel is an `ItemsHost`). When changed, the
old item is removed and the new one is added.

当设置 `TrailingItem` 时，它同时添加到 `VisualChildren` 和 `LogicalChildren`
（除非面板是 `ItemsHost`）。变更时，旧项目被移除，新项目被添加。

Inherits all properties from `Panel` (`Background`, `Children`, etc.).

继承 `Panel` 的全部属性。

## Styling & Templating / 样式与模板

`WrapPanelWithTrailingItem` is a pure layout `Panel` with no built-in theme or
control template. It inherits default `Panel` styling only.

`WrapPanelWithTrailingItem` 是纯布局 `Panel`，没有内置主题或控件模板。
仅继承默认 `Panel` 样式。

## FAQ / 常见问题

**Q: Can I use this as an ItemsPanel? / 可以将其用作 ItemsPanel 吗？**
A: Yes. When `IsItemsHost` is `true`, `LogicalChildren` management is skipped
for the trailing item (it only adds to `VisualChildren`).

**Q: What happens if TrailingItem is null? / 如果 TrailingItem 为 null 会怎样？**
A: The panel behaves like a simple `WrapPanel`. No trailing item is measured
or arranged.

**Q: How is the trailing item sized? / 尾随项如何确定大小？**
A: The trailing item is measured with the full available size. On the last
line, it fills the remaining width. On a new line, it fills the full width.
