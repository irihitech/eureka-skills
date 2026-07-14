---
category: Components
title: ScrollTo
subtitle: 滚动跳转
description: >
  Attached properties that add auto-hiding scroll-to-direction buttons on any
  ScrollViewer (or Control containing a ScrollViewer). The button appears when
  there is scrollable content in the chosen direction and hides when the
  boundary is reached. Supports custom button themes via ScrollTo.ButtonTheme.
  附加属性，为任何 ScrollViewer（或包含 ScrollViewer 的 Control）添加自动显隐
  的滚动方向按钮。当选定方向有可滚动内容时按钮显示，到达边界时自动隐藏。支持
  通过 ScrollTo.ButtonTheme 自定义按钮主题。
---

# ScrollTo / 滚动跳转

## When to Use / 何时使用

Use `ScrollTo` attached properties to overlay auto-hiding scroll-direction
buttons on any `ScrollViewer` or any control that contains a `ScrollViewer` in
its visual tree. The button appears when there is scrollable content in the
configured direction and auto-hides at the boundary.

使用 `ScrollTo` 附加属性为任何 `ScrollViewer` 或可视树中包含 `ScrollViewer`
的控件叠加自动显隐的滚动方向按钮。当配置方向上有可滚动内容时按钮出现，到达
边界时自动隐藏。

Do NOT use `ScrollTo` to scroll to a specific item or position — use
`ScrollViewer.ScrollToEnd()`, `BringIntoView()`, or `ScrollViewer.Offset`
instead. `ScrollTo` is specifically for "jump-to-end" directional buttons.

不要使用 `ScrollTo` 滚动到特定项目或位置——应使用 `ScrollViewer.ScrollToEnd()`、
`BringIntoView()` 或 `ScrollViewer.Offset`。`ScrollTo` 专用于"跳转到末端"的
方向按钮。

## Basic Usage / 基本使用

### Scroll to top / 滚动到顶部

```xml
xmlns:u="https://irihi.tech/ursa"

<ScrollViewer u:ScrollTo.Direction="Top">
    <Border Height="2000" />
</ScrollViewer>
```

A floating button appears at the bottom-right (default) that scrolls to top
when clicked. The button hides when already at the top.

会出现一个浮动按钮（默认在右下角），点击后滚动到顶部。已在顶部时按钮自动隐藏。

### All four directions / 四个方向

```xml
<ScrollViewer u:ScrollTo.Direction="Top" VerticalScrollBarVisibility="Auto">
    <!-- scrolls to top -->
</ScrollViewer>

<ScrollViewer u:ScrollTo.Direction="Bottom" VerticalScrollBarVisibility="Auto">
    <!-- scrolls to bottom -->
</ScrollViewer>

<ScrollViewer u:ScrollTo.Direction="Left" HorizontalScrollBarVisibility="Auto">
    <!-- scrolls to left -->
</ScrollViewer>

<ScrollViewer u:ScrollTo.Direction="Right" HorizontalScrollBarVisibility="Auto">
    <!-- scrolls to right -->
</ScrollViewer>
```

### Custom button theme / 自定义按钮主题

```xml
<ScrollViewer
    u:ScrollTo.Direction="Top"
    u:ScrollTo.ButtonTheme="{DynamicResource PrimaryScrollToButton}" />
```

Two built-in themes: default (uses `ButtonDefault*` resources) and
`PrimaryScrollToButton` (uses `ButtonSolidPrimary*` resources).

两种内置主题：默认主题（使用 `ButtonDefault*` 资源）和
`PrimaryScrollToButton`（使用 `ButtonSolidPrimary*` 资源）。

## Common Scenarios / 常用场景

### 1. Long list with back-to-top / 带回到顶部的长列表

```xml
<ListBox
    u:ScrollTo.Direction="Top"
    ItemsSource="{Binding Items}" />
```

Works because `ScrollTo` searches the control's visual descendants for a
`ScrollViewer`.

因为 `ScrollTo` 会在控件的可视后代中搜索 `ScrollViewer`，所以可以正常工作。

### 2. Grid layout with four scroll directions / 带四个滚动方向的网格布局

```xml
<Grid ColumnDefinitions="*, *, *, *">
    <ScrollViewer Grid.Column="0" u:ScrollTo.Direction="Top">
        <Border Height="2000" />
    </ScrollViewer>
    <ScrollViewer Grid.Column="1" u:ScrollTo.Direction="Bottom">
        <Border Height="2000" />
    </ScrollViewer>
    <ScrollViewer Grid.Column="2" u:ScrollTo.Direction="Left">
        <Border Width="2000" />
    </ScrollViewer>
    <ScrollViewer Grid.Column="3" u:ScrollTo.Direction="Right">
        <Border Width="2000" />
    </ScrollViewer>
</Grid>
```

### 3. Primary-styled button / 主色样式按钮

```xml
<ScrollViewer
    u:ScrollTo.Direction="Top"
    u:ScrollTo.ButtonTheme="{DynamicResource PrimaryScrollToButton}">
    <ItemsControl ItemsSource="{Binding Products}" />
</ScrollViewer>
```

`PrimaryScrollToButton` uses the `ButtonSolidPrimary` brush family for a
more prominent appearance.

`PrimaryScrollToButton` 使用 `ButtonSolidPrimary` 画刷系列，外观更突出。

## Attached Properties / 附加属性

### ScrollTo.Direction / ScrollTo.Direction

| Property | Type | Description / 说明 |
|---|---|---|
| `ScrollTo.Direction` | `Position?` | Scroll direction. Null removes the button. / 滚动方向。设为 null 移除按钮。 |
| `ScrollTo.ButtonTheme` | `ControlTheme?` | Optional custom theme for the overlay button. / 叠加按钮的可选自定义主题。 |

### Position Enum / Position 枚举

`Position` is defined in `Ursa.Common`:

`Position` 定义在 `Ursa.Common` 中：

| Value | Description / 说明 |
|---|---|
| `Top` | Scroll to top / 滚动到顶部 |
| `Bottom` | Scroll to bottom / 滚动到底部 |
| `Left` | Scroll to left / 滚动到左侧 |
| `Right` | Scroll to right / 滚动到右侧 |

### ScrollToButton (Internal) / ScrollToButton（内部）

`ScrollToButton` is the internal `Button` subclass placed as an `AdornerLayer`
overlay. It is generally not instantiated directly — use the `ScrollTo` attached
properties instead.

`ScrollToButton` 是放置在 `AdornerLayer` 叠加层上的内部 `Button` 子类。
通常不直接实例化——使用 `ScrollTo` 附加属性代替。

| Property | Type | Description / 说明 |
|---|---|---|
| `Target` | `Control` | The control whose visual tree is searched for a `ScrollViewer` / 在其可视树中搜索 `ScrollViewer` 的控件 |
| `Direction` | `Position` | Scroll direction / 滚动方向 |

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `ScrollToButtonIconGlyph` | `PART_Icon` | The arrow icon path data / 箭头图标路径数据 |

### Built-in ControlThemes / 内置 ControlTheme

| Theme Key | Description / 说明 |
|---|---|
| `{x:Type u:ScrollToButton}` | Default theme. Uses `ButtonDefault*` resource brushes. / 默认主题。使用 `ButtonDefault*` 资源画刷。 |
| `PrimaryScrollToButton` | Primary variant. Uses `ButtonSolidPrimary*` resource brushes. / 主色变体。使用 `ButtonSolidPrimary*` 资源画刷。 |

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_Background` | `ScrollToButton` | `Border` |
| `PART_Icon` | `ScrollToButton` | `PathIcon` |

### Direction Icon Rotation / 方向图标旋转

The icon rotates based on the `Direction` property:

图标根据 `Direction` 属性旋转：

| Direction / 方向 | RenderTransform / 旋转变换 |
|---|---|
| `Top` (default) | `rotate(0deg)` |
| `Right` | `rotate(90deg)` |
| `Bottom` | `rotate(180deg)` |
| `Left` | `rotate(270deg)` |

### Pseudo-classes / 伪类

| Pseudo-class | Condition / 条件 |
|---|---|
| `:pointerover` | Mouse is over the button / 鼠标悬停在按钮上 |
| `:pressed` | Button is being pressed / 按钮被按下 |

## FAQ / 常见问题

**Q: The scroll button doesn't appear. Why? / 滚动按钮不出现，为什么？**
A: Ensure the target has scrollable content (content larger than viewport).
The button auto-hides when the boundary in the chosen direction is already
reached.

确保目标内容可滚动（内容大于视口）。当已到达选定方向的边界时，按钮会自动隐藏。

**Q: Can I place the button in a different corner? / 可以将按钮放在不同角落吗？**
A: Yes. Create a custom `ControlTheme` for `ScrollToButton` and set different
`HorizontalAlignment` and `VerticalAlignment` values. Then assign it via
`ScrollTo.ButtonTheme`.

可以。为 `ScrollToButton` 创建自定义 `ControlTheme` 并设置不同的
`HorizontalAlignment` 和 `VerticalAlignment` 值。然后通过
`ScrollTo.ButtonTheme` 分配。

**Q: Does this work on controls other than ScrollViewer? / 这可以在 ScrollViewer 以外的控件上使用吗？**
A: Yes. Any `Control` can be the target. `ScrollTo` searches the control's
visual descendants for the first `ScrollViewer`.

可以。任何 `Control` 都可以作为目标。`ScrollTo` 会在控件的可视后代中搜索
第一个 `ScrollViewer`。

**Q: How is the button placed? / 按钮是如何放置的？**
A: `ScrollTo` uses `AdornerLayer.SetAdorner()` to overlay the `ScrollToButton`
on top of the target control, so it floats above the content.

`ScrollTo` 使用 `AdornerLayer.SetAdorner()` 将 `ScrollToButton` 叠加在目标
控件之上，使其浮动在内容上方。
