---
category: Components
title: PipsPager
subtitle: 页面指示器
description: 页面指示器用于显示分页内容中的当前位置并支持页面导航。
---

# PipsPager / 页面指示器

A navigation control that displays a row of glyphs ("pips") representing pages in a paginated collection. Each pip indicates whether its page is selected, normal, or in an overflow state. Inherits from `Control`. Supports horizontal and vertical orientations, customizable visible pip count, and optional previous/next navigation buttons.

一个导航控件，显示一行代表分页集合中各页面的字形（"pips"）。每个 pip 指示其对应页面是已选中、正常还是溢出状态。继承自 `Control`。支持水平和垂直方向、可自定义的可见 pip 数量以及可选的上一个/下一个导航按钮。

## When to Use / 何时使用

Use `PipsPager` when you need compact page-position indicators tied to a paginated control (e.g. `FlipView`, `ScrollViewer` with snap points, or a custom carousel). It is ideal for onboarding flows, image galleries, dashboards with card pages, or any multi-page surface where the user benefits from knowing which page they are on and how many pages exist. For simple dot indicators without navigation buttons, set `PreviousButtonVisibility` and `NextButtonVisibility` to `Collapsed`.

当你需要与分页控件绑定的紧凑页面位置指示器时使用 `PipsPager` —— 例如 `FlipView`、带吸附点的 `ScrollViewer` 或自定义轮播。它非常适合引导流程、图库、带卡片页面的仪表板或任何多页面界面，用户需要知道自己在哪个页面以及总共有多少页。对于无需导航按钮的简单圆点指示器，将 `PreviousButtonVisibility` 和 `NextButtonVisibility` 设置为 `Collapsed`。

## Basic Usage / 基本使用

```xml
<PipsPager NumberOfPages="5"
            SelectedPageIndex="2" />
```

```csharp
// Code-behind
var pipsPager = new PipsPager
{
    NumberOfPages = 5,
    SelectedPageIndex = 2
};
pipsPager.SelectedPageIndexChanged += (s, e) =>
{
    Console.WriteLine($"Navigated to page {e.SelectedPageIndex}");
};
```

## Common Scenarios / 常用场景

### With FlipView / 与 FlipView 配合

Bind `SelectedPageIndex` to a `FlipView` for synchronized page navigation. This is the most common usage pattern.

```xml
<StackPanel>
    <FlipView x:Name="MyFlipView"
              Width="400" Height="300">
        <FlipView.Items>
            <TextBlock Text="Page 1" FontSize="32" />
            <TextBlock Text="Page 2" FontSize="32" />
            <TextBlock Text="Page 3" FontSize="32" />
        </FlipView.Items>
    </FlipView>
    <PipsPager NumberOfPages="3"
               SelectedPageIndex="{Binding SelectedIndex, ElementName=MyFlipView}" />
</StackPanel>
```

### Vertical Orientation / 垂直方向

Set `Orientation="Vertical"` for a vertical pip layout, useful for side navigation or compact side panels.

```xml
<PipsPager NumberOfPages="4"
            SelectedPageIndex="0"
            Orientation="Vertical" />
```

### Custom Visible Pip Count / 自定义可见 Pip 数量

Limit visible pips with `MaxVisiblePips`. When `NumberOfPages` exceeds this, overflow glyphs appear.

```xml
<PipsPager NumberOfPages="20"
            SelectedPageIndex="5"
            MaxVisiblePips="7" />
```

### Hide Navigation Buttons / 隐藏导航按钮

Collapse the previous/next buttons for a read-only page indicator.

```xml
<PipsPager NumberOfPages="3"
            SelectedPageIndex="1"
            PreviousButtonVisibility="Collapsed"
            NextButtonVisibility="Collapsed" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `NumberOfPages` | `int` | Total number of pages (pips). Must be ≥ 1. Defaults to `0`. / 页面总数（pip 数量）。必须 ≥ 1。默认为 `0`。 |
| `SelectedPageIndex` | `int` | The zero-based index of the currently selected page. Defaults to `-1`. / 当前选中页面的零基索引。默认为 `-1`。 |
| `MaxVisiblePips` | `int` | Maximum number of pips to show before overflow glyphs appear. Defaults to `5`. / 出现溢出字形前显示的最大 pip 数量。默认为 `5`。 |
| `Orientation` | `Orientation` | `Horizontal` (default) or `Vertical` — direction the pips are laid out. / `Horizontal`（默认）或 `Vertical` — pip 的排列方向。 |
| `PreviousButtonVisibility` | `PipPagerButtonVisibility` | Visibility of the previous/back navigation button. Values: `Visible`, `VisibleOnPointerOver`, `Collapsed`. Defaults to `Visible`. / 上一个/后退导航按钮的可见性。值：`Visible`、`VisibleOnPointerOver`、`Collapsed`。默认为 `Visible`。 |
| `NextButtonVisibility` | `PipPagerButtonVisibility` | Visibility of the next/forward navigation button. Same values as above. Defaults to `Visible`. / 下一个/前进导航按钮的可见性。同上。默认为 `Visible`。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectedPageIndexChanged` | Raised after the selected page index changes (via pip click or navigation button). `SelectedPageIndexChangedEventArgs` provides `SelectedPageIndex`. / 选中页面索引更改后触发（通过 pip 点击或导航按钮）。`SelectedPageIndexChangedEventArgs` 提供 `SelectedPageIndex`。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides styling for `PipsPager` with color classes and template part selectors. The pips are rendered as small circular glyphs with distinct visual states for normal, selected, and overflow states.

Semi.Avalonia 通过颜色类和模板部件选择器为 `PipsPager` 提供样式。Pips 渲染为小圆形字形，具有 normal、selected 和 overflow 的不同视觉状态。

### Semi.Avalonia ControlThemes / Semi.Avalonia 控件主题

Semi.Avalonia provides three ControlThemes for `PipsPager` infrastructure — the default `PipsPager` theme plus two sub-themes for internal elements:

Semi.Avalonia 为 `PipsPager` 基础设施提供了三个 ControlTheme — 默认的 `PipsPager` 主题加上两个用于内部元素的子主题：

| Theme / 主题 | Target Type / 目标类型 | Resource Key / 资源键 | Description / 说明 |
| --- | --- | --- | --- |
| **Default** | `PipsPager` | `{x:Type PipsPager}` | Inline pip indicators with optional nav buttons. References `PipsPagerButton` for nav buttons and `PipsPagerIndicatorDotListBoxItem` for pip items. / 内联 pip 指示器，带可选的导航按钮。为导航按钮引用 `PipsPagerButton`，为 pip 项引用 `PipsPagerIndicatorDotListBoxItem`。 |
| **PipsPagerButton** | `Button` | `PipsPagerButton` | Borderless navigation button that renders only a `PathIcon` (triangle glyph) without button chrome. Used for the previous/next buttons in `PipsPager`. Supports `:pointerover` state for colour change. / 无边框导航按钮，仅渲染 `PathIcon`（三角形字形），无按钮装饰。用于 `PipsPager` 中的上一个/下一个按钮。支持 `:pointerover` 状态以改变颜色。 |
| **PipsPagerIndicatorDotListBoxItem** | `ListBoxItem` | `PipsPagerIndicatorDotListBoxItem` | Renders each pip as an `Ellipse` with configurable fill colour. Supports `:pointerover`, `:pressed`, and `:selected` pseudo-classes for visual feedback. / 将每个 pip 渲染为 `Ellipse`，填充颜色可配置。支持 `:pointerover`、`:pressed` 和 `:selected` 伪类以提供视觉反馈。 |

```xml
<!-- Default PipsPager theme (uses sub-themes internally) -->
<PipsPager NumberOfPages="5" SelectedPageIndex="0" />

<!-- The PipsPagerButton theme renders nav arrows as bare PathIcons -->
<!-- The PipsPagerIndicatorDotListBoxItem renders pips as Ellipses -->

<!-- Customise navigation button theme -->
<PipsPager NumberOfPages="5" SelectedPageIndex="0"
           PreviousButtonTheme="{StaticResource PipsPagerButton}"
           NextButtonTheme="{StaticResource PipsPagerButton}" />
```

### Color Classes / 颜色类

Apply via the `Classes` attached property.

| Class / 类名 | Description / 说明 |
| --- | --- |
| `Primary` | (default) Blue accent for the selected pip. / （默认）选中 pip 的蓝色强调色。 |
| `Secondary` | Neutral gray accent. / 中性灰色强调色。 |

```xml
<PipsPager NumberOfPages="3" SelectedPageIndex="0" Classes="Secondary" />
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:disabled` | Control is disabled (`IsEnabled = false`). / 控件已禁用。 |
| `:pointerover` | Mouse is hovering over the control. / 鼠标悬停在控件上。 |
| `:vertical` | Applied when `Orientation` is `Vertical`. / 当 `Orientation` 为 `Vertical` 时应用。 |
| `:horizontal` | Applied when `Orientation` is `Horizontal` (default). / 当 `Orientation` 为 `Horizontal`（默认）时应用。 |
| `:first-page` | Applied when on the first page (previous button hidden). / 在第一页时应用（上一个按钮隐藏）。 |
| `:last-page` | Applied when on the last page (next button hidden). / 在最后一页时应用（下一个按钮隐藏）。 |

Individual pip items carry their own pseudo-classes via `PipsPagerIndicatorDotListBoxItem`:
每个 pip 项通过 `PipsPagerIndicatorDotListBoxItem` 带有自己的伪类：

| Pip Pseudo-class | Description / 说明 |
| --- | --- |
| `:selected` | This pip represents the current page. / 此 pip 代表当前页面。 |
| `:normal` | A standard, non-selected pip within the visible range. / 可见范围内的标准非选中 pip。 |
| `:overflow` | An overflow glyph indicating hidden pages exist before or after visible pips. / 溢出字形，指示可见 pip 之前或之后存在隐藏页面。 |
| `:pointerover` | Mouse is hovering over this pip (changes colour). / 鼠标悬停在此 pip 上（改变颜色）。 |
| `:pressed` | This pip is being pressed (changes colour). / 此 pip 正在被按下（改变颜色）。 |

### ControlTheme Structure / 控件主题结构

The default `PipsPager` theme uses `PipsPagerButton` for its `PreviousButtonTheme` and `NextButtonTheme`, and `PipsPagerIndicatorDotListBoxItem` as the `ItemContainerTheme` for the inner `ListBox` that hosts pip items. Navigation buttons render triangle `PathIcon` glyphs; pip items render as `Ellipse` elements with colour transitions on pointerover, pressed, and selected states.

默认 `PipsPager` 主题使用 `PipsPagerButton` 作为其 `PreviousButtonTheme` 和 `NextButtonTheme`，并使用 `PipsPagerIndicatorDotListBoxItem` 作为承载 pip 项的内部 `ListBox` 的 `ItemContainerTheme`。导航按钮渲染三角形 `PathIcon` 字形；pip 项渲染为 `Ellipse` 元素，在 pointerover、pressed 和 selected 状态下有颜色过渡。

### DynamicResource Keys / 动态资源键

```
PipsPagerPrimarySelectedBackground
PipsPagerPrimarySelectedForeground
PipsPagerPrimaryNormalBackground
PipsPagerNormalForeground
PipsPagerOverflowForeground
PipsPagerNavigationButtonBackground
PipsPagerNavigationButtonPointeroverBackground
...
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_PipsArea` | `PipsPagerItemsPresenter` | Hosts the pip glyphs. Pip items are generated via `ItemTemplate` based on `NumberOfPages`. / 托管 pip 字形。Pip 项通过 `ItemTemplate` 基于 `NumberOfPages` 生成。 |
| `PART_PreviousButton` | `NavigationButton` | The button that navigates to the previous page. Visibility controlled by `PreviousButtonVisibility`. / 导航到上一页的按钮。可见性由 `PreviousButtonVisibility` 控制。 |
| `PART_NextButton` | `NavigationButton` | The button that navigates to the next page. Visibility controlled by `NextButtonVisibility`. / 导航到下一页的按钮。可见性由 `NextButtonVisibility` 控制。 |

## FAQ / 常见问题

**Q: How do I synchronize PipsPager with a FlipView? / 如何将 PipsPager 与 FlipView 同步？**

A: Bind `PipsPager.SelectedPageIndex` to `FlipView.SelectedIndex` with a two-way binding. Set `PipsPager.NumberOfPages` to match the item count. The binding is:
```
<PipsPager NumberOfPages="{Binding ElementName=MyFlipView, Path=Items.Count}"
           SelectedPageIndex="{Binding ElementName=MyFlipView, Path=SelectedIndex,
                               Mode=TwoWay}" />
```

将 `PipsPager.SelectedPageIndex` 与 `FlipView.SelectedIndex` 双向绑定。设置 `PipsPager.NumberOfPages` 匹配项数量。绑定方式见上例。

**Q: Why do overflow pips appear when I only have 5 pages? / 为什么我只有 5 页时会出现溢出 pip？**

A: The `MaxVisiblePips` property defaults to `5`. If you have 6+ pages, overflow pips appear. To show all pips without overflow, set `MaxVisiblePips` to a value ≥ `NumberOfPages`, or set it to a very large number like `int.MaxValue`.

`MaxVisiblePips` 属性默认为 `5`。如果你有 6+ 页，溢出 pip 就会出现。要显示所有 pip 而不溢出，将 `MaxVisiblePips` 设置为 ≥ `NumberOfPages` 的值，或设置为一个非常大的数字如 `int.MaxValue`。

**Q: Can I use PipsPager without a paged control? / 可以在没有分页控件的情况下使用 PipsPager 吗？**

A: Yes. `PipsPager` is a standalone navigation control. Handle `SelectedPageIndexChanged` and use the index to update any visual element. It is not coupled to `FlipView` or any specific paginated control — the binding is entirely up to you.

可以。`PipsPager` 是一个独立的导航控件。处理 `SelectedPageIndexChanged` 事件，使用索引更新任何视觉元素。它不与 `FlipView` 或任何特定分页控件耦合 —— 绑定完全由你决定。
