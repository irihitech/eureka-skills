---
category: Components
title: GridSplitter
subtitle: 网格分割器
description: 网格分割器用于在运行时拖动调整 Grid 行或列的大小。
---

# GridSplitter / 网格分割器

A control that allows the user to resize `Grid` rows or columns by dragging a splitter bar. Inherits from `Thumb`.

允许用户通过拖动分割条来调整 `Grid` 行或列大小的控件。继承自 `Thumb`。

## When to Use / 何时使用

Use `GridSplitter` for resizable panels — split-pane layouts, adjustable sidebars, resizable property panels. For a full navigation drawer pattern, use `SplitView`.

用于可调整大小的面板——分割布局、可调侧边栏、可调属性面板。完整导航抽屉模式用 `SplitView`。

## Basic Usage / 基本使用

```xml
<Grid ColumnDefinitions="*,Auto,*">
    <Border Grid.Column="0" />
    <GridSplitter Grid.Column="1" Width="4"
                  ResizeDirection="Columns"
                  Background="Gray" />
    <Border Grid.Column="2" />
</Grid>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `ResizeDirection` | `GridResizeDirection` | `Columns`, `Rows`, `Auto`. |
| `ResizeBehavior` | `GridResizeBehavior` | `BasedOnAlignment`, `CurrentAndNext`, `PreviousAndCurrent`, `PreviousAndNext`. |
| `KeyboardIncrement` | `double` | Pixels to resize per arrow key press. / 每次按键调整的像素数。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How to create a vertical splitter? / 如何创建垂直分割器？**

A: Place `GridSplitter` in a column with `ResizeDirection="Columns"`. Set its `Width` to the desired grab area (e.g., 4px). / 将 `GridSplitter` 放在一列中，设置 `ResizeDirection="Columns"`。设置 `Width` 为期望的抓取区域。