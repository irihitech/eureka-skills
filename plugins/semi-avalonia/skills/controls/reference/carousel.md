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

| Theme / 主题 | Resource Key / 资源键 | Appearance / 外观 |
| --- | --- | --- |
| **Default** | `{x:Type Carousel}` | Transparent container, no background or border. / 透明容器，无背景或边框。 |

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
