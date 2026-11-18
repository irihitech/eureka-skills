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

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


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
