---
category: Components
title: Carousel
subtitle: 轮播
description: 轮播控件用于在多个子项之间以过渡动画形式切换显示单个子项。
---

## Carousel / 轮播

An items control that displays one item at a time from a collection, with configurable transition animations when switching between items. Inherits from `SelectingItemsControl`. Supports `SelectedIndex`, `SelectedItem`, and a `PageTransition` property for custom slide, fade, or crossfade effects.

一种项控件，每次从集合中显示一个子项，在切换项时支持可配置的过渡动画。继承自 `SelectingItemsControl`。支持 `SelectedIndex`、`SelectedItem` 以及用于自定义滑动、淡入淡出或交叉淡入淡出效果的 `PageTransition` 属性。

## When to Use / 何时使用

Use `Carousel` when you need to display a sequence of views one at a time with animated transitions — onboarding wizards, image galleries, step-by-step forms, or any scenario where only one child panel should be visible and switching should feel smooth. For tab-based navigation where the user explicitly picks tabs, consider `TabControl` with `TabItem`. For a multi-page app shell, prefer `CarouselPage` from the Semi.Avalonia navigation framework.

当你需要以动画过渡方式一次显示一个视图序列时使用 `Carousel` —— 引导向导、图片画廊、分步表单，或任何只应显示一个子面板且切换应流畅的场景。对于用户显式选择标签页的标签式导航，请考虑使用 `TabControl` 配合 `TabItem`。对于多页面应用外壳，请使用 Semi.Avalonia 导航框架中的 `CarouselPage`。

## Basic Usage / 基本使用

```xml
<Carousel x:Name="myCarousel"
          SelectedIndex="0">
    <TextBlock Text="Page 1" FontSize="24" />
    <TextBlock Text="Page 2" FontSize="24" />
    <TextBlock Text="Page 3" FontSize="24" />
</Carousel>
```

```csharp
// Programmatic creation
var carousel = new Carousel
{
    SelectedIndex = 0
};
carousel.Items.Add(new TextBlock { Text = "Page 1" });
carousel.Items.Add(new TextBlock { Text = "Page 2" });
carousel.Items.Add(new TextBlock { Text = "Page 3" });

// Navigate programmatically
carousel.SelectedIndex = 1;   // Show page 2
carousel.Next();              // Advance to next item
carousel.Previous();          // Go back to previous item
```

## Common Scenarios / 常用场景

### Image Gallery with Transitions / 带过渡效果的图片画廊

```xml
<Carousel x:Name="imageGallery"
          SelectedIndex="0"
          IsVirtualized="False">
    <Carousel.PageTransition>
        <CrossFade Duration="0:0:0.3" />
    </Carousel.PageTransition>
    <Image Source="photo1.jpg" Stretch="Uniform" />
    <Image Source="photo2.jpg" Stretch="Uniform" />
    <Image Source="photo3.jpg" Stretch="Uniform" />
</Carousel>
```

```csharp
// Navigate gallery with buttons
private void OnNextImage(object? sender, RoutedEventArgs e)
{
    if (imageGallery.SelectedIndex < imageGallery.ItemCount - 1)
        imageGallery.Next();
}

private void OnPrevImage(object? sender, RoutedEventArgs e)
{
    if (imageGallery.SelectedIndex > 0)
        imageGallery.Previous();
}
```

### Slide Transition / 滑动过渡

Use `PageSlide` for a horizontal or vertical slide effect between items.

```xml
<Carousel SelectedIndex="{Binding CurrentStep}">
    <Carousel.PageTransition>
        <PageSlide Orientation="Horizontal" Duration="0:0:0.25" />
    </Carousel.PageTransition>
    <local:Step1View />
    <local:Step2View />
    <local:Step3View />
</Carousel>
```

### MVVM Binding / MVVM 绑定

Bind `SelectedIndex` or `SelectedItem` to a ViewModel property for data-driven navigation.

```xml
<Carousel ItemsSource="{Binding Pages}"
          SelectedItem="{Binding CurrentPage}">
    <Carousel.PageTransition>
        <CrossFade Duration="0:0:0.2" />
    </Carousel.PageTransition>
</Carousel>
```

```csharp
public class WizardViewModel : ObservableObject
{
    public ObservableCollection<object> Pages { get; } = new();

    private object? _currentPage;
    public object? CurrentPage
    {
        get => _currentPage;
        set => SetProperty(ref _currentPage, value);
    }

    public ICommand NextCommand { get; }
    public ICommand PreviousCommand { get; }
}
```

### Virtualized Carousel / 虚拟化轮播

Enable `IsVirtualized` to only create the visible item, improving performance for large collections.

```xml
<Carousel ItemsSource="{Binding LargeCollection}"
          SelectedIndex="{Binding CurrentIndex}"
          IsVirtualized="True">
    <Carousel.PageTransition>
        <CrossFade Duration="0:0:0.15" />
    </Carousel.PageTransition>
</Carousel>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `SelectedIndex` | `int` | The zero-based index of the currently displayed item. Inherited from `SelectingItemsControl`. / 当前显示项的从零开始的索引。继承自 `SelectingItemsControl`。 |
| `SelectedItem` | `object?` | The currently displayed item object. Inherited from `SelectingItemsControl`. / 当前显示的项对象。继承自 `SelectingItemsControl`。 |
| `PageTransition` | `IPageTransition?` | The transition animation applied when switching between items. Supports `CrossFade`, `PageSlide`, `Rotate3DTransition`, and custom implementations. / 切换项时应用的过渡动画。支持 `CrossFade`、`PageSlide`、`Rotate3DTransition` 及自定义实现。 |
| `IsVirtualized` | `bool` | When `true`, only the visible item's container is created. Items are destroyed when not visible. Default `false`. / 设为 `true` 时仅创建可见项的容器。不可见项会被销毁。默认为 `false`。 |
| `ItemsSource` | `IEnumerable?` | Collection of items to display. Inherited from `ItemsControl`. / 要显示的项集合。继承自 `ItemsControl`。 |
| `ItemCount` | `int` | (Read-only) Number of items in the carousel. / （只读）轮播中的项数。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectionChanged` | Raised when the `SelectedIndex` or `SelectedItem` changes, carrying the old and new selection. Inherited from `SelectingItemsControl`. / 当 `SelectedIndex` 或 `SelectedItem` 更改时触发，携带旧值和新值。继承自 `SelectingItemsControl`。 |

### Methods / 方法

| Method / 方法 | Description / 说明 |
| --- | --- |
| `Next()` | Advances to the next item. Wraps to the first item if already at the end. / 前进到下一项。如果已到末尾则回到第一项。 |
| `Previous()` | Goes back to the previous item. Wraps to the last item if already at the start. / 后退到上一项。如果已到开头则跳到末尾。 |

## Styling & Templating / 样式与模板

Semi.Avalonia styles `Carousel` as a minimal container — it applies no visible chrome of its own, delegating all visual presentation to the child items and the chosen `PageTransition`. The control itself is transparent and borderless.

Semi.Avalonia 将 `Carousel` 样式化为最小容器 —— 它本身不应用任何可见装饰，所有视觉呈现由子项和所选的 `PageTransition` 负责。控件本身是透明无边框的。

### Theme Variants / 主题变体

Semi.Avalonia defines two Carousel themes plus three indicator ListBoxItem themes and a navigation Button theme:

Semi.Avalonia 定义了两种 Carousel 主题，以及三种指示器 ListBoxItem 主题和一个导航 Button 主题：

**Carousel themes / Carousel 主题:**

| Theme / 主题 | Resource Key / 资源键 | Target / 目标 | Description / 说明 |
| --- | --- | --- | --- |
| **Default** | `{x:Type Carousel}` | `Carousel` | Transparent container with a `ScrollViewer` and `ItemsPresenter`. No indicators or navigation buttons. / 透明容器，带 `ScrollViewer` 和 `ItemsPresenter`。无指示器或导航按钮。 |
| **FullCarousel** | `FullCarousel` | `Carousel` | Full-featured carousel with built-in previous/next navigation buttons, a page indicator `ListBox` (dots, lines, or columns), and a `PageSlide` transition. Supports `Line`, `Columnar`, `Left`, `Center`, and `Right` style classes for indicator appearance and alignment. / 功能齐全的轮播，带内置上/下导航按钮、页面指示器 `ListBox`（圆点、线条或柱状）以及 `PageSlide` 过渡效果。支持 `Line`、`Columnar`、`Left`、`Center` 和 `Right` 样式类，用于指示器外观和对齐。 |

**Companion themes / 配套主题:**

| Theme / 主题 | Resource Key / 资源键 | Target / 目标 | Description / 说明 |
| --- | --- | --- | --- |
| **CarouselButton** | `CarouselButton` | `Button` | A 32×32 navigation button that renders a `PathIcon`. Used by `FullCarousel` for prev/next arrows. / 一个 32×32 导航按钮，渲染 `PathIcon`。`FullCarousel` 用于上/下箭头。 |
| **CarouselIndicatorDotListBoxItem** | `CarouselIndicatorDotListBoxItem` | `ListBoxItem` | A small ellipse dot indicator (~8×8px) for the page indicator. Selected dot has a different color. / 用于页面指示器的小椭圆点指示器（~8×8px）。选中的点颜色不同。 |
| **CarouselIndicatorLineListBoxItem** | `CarouselIndicatorLineListBoxItem` | `ListBoxItem` | A horizontal line indicator. Based on the dot theme but renders a `Rectangle`. / 水平线指示器。基于圆点主题但渲染 `Rectangle`。 |
| **CarouselIndicatorColumnarListBoxItem** | `CarouselIndicatorColumnarListBoxItem` | `ListBoxItem` | A vertical column indicator. Selected item grows taller with an animated transition. / 垂直柱状指示器。选中项通过动画过渡变高。 |

### Default Theme / 默认主题

```xml
<!-- Default theme: no visible styling -->
<Carousel SelectedIndex="0">
    <Carousel.PageTransition>
        <CrossFade Duration="0:0:0.3" />
    </Carousel.PageTransition>
    <local:PageA />
    <local:PageB />
</Carousel>
```

### FullCarousel / 完整轮播

The `FullCarousel` theme wraps the default carousel with a grid layout that adds navigation buttons (left/right arrows using `CarouselButton`) and a page indicator `ListBox` (using one of the indicator `ListBoxItem` themes). It includes a default `PageSlide` transition.

`FullCarousel` 主题用网格布局包裹默认轮播，添加导航按钮（使用 `CarouselButton` 的左/右箭头）和页面指示器 `ListBox`（使用一种指示器 `ListBoxItem` 主题）。它包含默认的 `PageSlide` 过渡效果。

```xml
<!-- Full carousel with dot indicators (default) -->
<Carousel Theme="{DynamicResource FullCarousel}">
    <Border Background="#EAF5FF">
        <TextBlock Text="Page 1" />
    </Border>
    <Border Background="#F9F9F9">
        <TextBlock Text="Page 2" />
    </Border>
    <Border Background="#FFF8EA">
        <TextBlock Text="Page 3" />
    </Border>
    <Border Background="#FEF2ED">
        <TextBlock Text="Page 4" />
    </Border>
</Carousel>

<!-- With line indicators -->
<Carousel Theme="{DynamicResource FullCarousel}"
          Classes="Line">
    <!-- items... -->
</Carousel>

<!-- With columnar indicators, left-aligned -->
<Carousel Theme="{DynamicResource FullCarousel}"
          Classes="Columnar Left">
    <!-- items... -->
</Carousel>
```

**FullCarousel style classes / FullCarousel 样式类:**

| Class / 类名 | Effect / 效果 |
| --- | --- |
| `Line` | Switches indicators from dots (`CarouselIndicatorDotListBoxItem`) to lines (`CarouselIndicatorLineListBoxItem`) arranged in a `UniformGrid`. / 将指示器从圆点切换为线条，排列在 `UniformGrid` 中。 |
| `Columnar` | Switches indicators to column bars (`CarouselIndicatorColumnarListBoxItem`) with animated height on selection. / 将指示器切换为柱状条，选中时带高度动画。 |
| `Left` | Left-aligns the indicator list. / 指示器列表左对齐。 |
| `Center` | Center-aligns the indicator list (default). / 指示器列表居中对齐（默认）。 |
| `Right` | Right-aligns the indicator list. / 指示器列表右对齐。 |

### CarouselButton / 轮播按钮

A 32×32 `Button` theme that renders its `Content` as a `PathIcon`. Designed for the left/right navigation arrows in `FullCarousel`. Uses `InnerPathIcon` and responds to `:pointerover` with a foreground color change.

一个 32×32 `Button` 主题，将其 `Content` 渲染为 `PathIcon`。设计用于 `FullCarousel` 中的左/右导航箭头。使用 `InnerPathIcon` 并在 `:pointerover` 时以前景色变化响应。

```xml
<!-- Prev button (reusable independently) -->
<Button Theme="{DynamicResource CarouselButton}"
        Content="{StaticResource SemiIconChevronLeft}"
        Command="{Binding PreviousCommand}" />

<!-- Next button -->
<Button Theme="{DynamicResource CarouselButton}"
        Content="{StaticResource SemiIconChevronRight}"
        Command="{Binding NextCommand}" />
```

### CarouselIndicatorDotListBoxItem / 圆点指示器项

An ellipse-based page indicator `ListBoxItem` theme. Each item renders as a small dot (~8×8px ellipse). The selected item uses a different foreground brush. Based on this theme, `CarouselIndicatorLineListBoxItem` renders a `Rectangle` instead, and `CarouselIndicatorColumnarListBoxItem` renders a taller `Rectangle` with animated height transition on selection.

基于椭圆的页面指示器 `ListBoxItem` 主题。每项渲染为一个小圆点（~8×8px 椭圆）。选中项使用不同的前景笔刷。基于此主题，`CarouselIndicatorLineListBoxItem` 渲染 `Rectangle`，而 `CarouselIndicatorColumnarListBoxItem` 渲染更高的 `Rectangle`，选中时带高度动画过渡。

```xml
<!-- Custom indicator list using dot items -->
<ListBox ItemsSource="{Binding Pages}"
         ItemContainerTheme="{DynamicResource CarouselIndicatorDotListBoxItem}"
         SelectedIndex="{Binding CurrentIndex, Mode=TwoWay}">
    <ListBox.ItemsPanel>
        <ItemsPanelTemplate>
            <StackPanel Orientation="Horizontal" />
        </ItemsPanelTemplate>
    </ListBox.ItemsPanel>
</ListBox>
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:disabled` | Control is disabled (`IsEnabled = false`). Transitions do not respond. / 控件已禁用。过渡动画不响应。 |

### DynamicResource Keys / 动态资源键

```
CarouselBackground       → Transparent
CarouselBorderBrush      → Transparent
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_ItemsPresenter` | `ItemsPresenter` | Hosts the panel that arranges and displays items. / 承载排列并显示项的布局面板。 |

## FAQ / 常见问题

**Q: How do I prevent Carousel from wrapping around when calling Next() at the last item? / 如何在最后一项调用 Next() 时防止轮播回绕？**

A: `Next()` and `Previous()` always wrap. To prevent this, check `SelectedIndex` against `ItemCount` before calling them:

```csharp
// Safe advance without wrapping
if (carousel.SelectedIndex < carousel.ItemCount - 1)
    carousel.Next();
```

`Next()` 和 `Previous()` 总是会回绕。要防止此行为，请在调用前将 `SelectedIndex` 与 `ItemCount` 对比。

**Q: Can I use multiple transition effects in the same Carousel? / 能否在同一 Carousel 中使用多种过渡效果？**

A: The `PageTransition` property accepts a single `IPageTransition` instance. For conditional transitions, create a composite transition by swapping the property in code-behind based on navigation direction or context:

```csharp
carousel.PageTransition = isGoingForward
    ? new PageSlide { Orientation = PageSlide.SlideAxis.Horizontal }
    : new CrossFade { Duration = TimeSpan.FromSeconds(0.15) };
carousel.SelectedIndex = newIndex;
```

`PageTransition` 属性接受单个 `IPageTransition` 实例。如需条件过渡，请在代码后台根据导航方向或上下文动态替换。

**Q: How does IsVirtualized affect PageTransition animations? / IsVirtualized 如何影响 PageTransition 动画？**

A: When `IsVirtualized = True`, only the currently selected item is in the visual tree. During a transition, the previous item is destroyed and the new item is created, which means transitions that require both the old and new items simultaneously visible (like `PageSlide`) may not work correctly. Use `IsVirtualized = False` when using `PageSlide` or any cross-item transition. `CrossFade` typically works with virtualization since it only needs the new item. / 当 `IsVirtualized = True` 时，仅当前选中项在视觉树中。过渡期间旧项会被销毁、新项会被创建，这意味着需要新旧项同时可见的过渡效果（如 `PageSlide`）可能无法正常工作。使用 `PageSlide` 或任何跨项过渡时，请设置 `IsVirtualized = False`。`CrossFade` 通常可与虚拟化一起使用，因为它只需要新项。
