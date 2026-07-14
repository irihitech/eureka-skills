---
category: Components
title: CarouselPage
subtitle: 轮播页面
description: 轮播页面通过水平滑动在多个子页面之间切换，每个子页面占据整个内容区域，支持手势滑动和编程式导航。
---

## CarouselPage / 轮播页面

A multi-page container that displays its child `ContentPage` instances one at a time, with swipe-gesture navigation between them. Inherits from `ContentPage`. Unlike `TabbedPage` which uses a visible tab bar, `CarouselPage` relies on horizontal swipe gestures (and optional page indicators) for navigation. Built on top of the `Carousel` control, it is ideal for onboarding flows, image galleries, and content feeds with swipeable sections.

一种多页面容器，每次显示一个子 `ContentPage` 实例，并通过滑动手势在它们之间导航。继承自 `ContentPage`。与使用可见标签栏的 `TabbedPage` 不同，`CarouselPage` 依靠水平滑动手势（和可选的页面指示器）进行导航。基于 `Carousel` 控件构建，非常适合引导流程、图片画廊和具有可滑动板块的内容资讯流。

## When to Use / 何时使用

Use `CarouselPage` when you want users to swipe horizontally between peer pages — onboarding wizards, content feeds with "For You" / "Trending" / "Following" sections, product image galleries, or any scenario where users expect a swipe-to-navigate experience. For tab-based navigation with explicit tab labels, prefer `TabbedPage`. For stack-based drill-down, use `NavigationPage`. For a sidebar menu, use `DrawerPage`.

当你希望用户在平等页面之间水平滑动时使用 `CarouselPage` —— 引导向导、具有"推荐"/"热门"/"关注"板块的内容流、产品图片画廊，或任何用户期望滑动导航体验的场景。对于带有明确标签的标签式导航，请使用 `TabbedPage`。对于基于堆栈的钻取导航，请使用 `NavigationPage`。对于侧边栏菜单，请使用 `DrawerPage`。

## Basic Usage / 基本使用

```xml
<CarouselPage x:Name="onboardingCarousel">
    <local:WelcomePage Title="Welcome" />
    <local:FeaturesPage Title="Features" />
    <local:GetStartedPage Title="Get Started" />
</CarouselPage>
```

```csharp
// Programmatic creation
var carouselPage = new CarouselPage();

carouselPage.Children.Add(new WelcomePage { Title = "Welcome" });
carouselPage.Children.Add(new FeaturesPage { Title = "Features" });
carouselPage.Children.Add(new GetStartedPage { Title = "Get Started" });

// Navigate programmatically
carouselPage.SelectedIndex = 1;     // Go to Features page
carouselPage.Next();                // Advance to next page
carouselPage.Previous();            // Go back to previous page
```

## Common Scenarios / 常用场景

### Onboarding Flow / 引导流程

A swipeable onboarding wizard with a page indicator (PipsPager) and action buttons.

```xml
<Grid RowDefinitions="*,Auto">
    <!-- Carousel pages -->
    <CarouselPage Grid.Row="0"
                  x:Name="onboardingCarousel"
                  SelectedIndex="{Binding CurrentStep}">
        <CarouselPage.PageTransition>
            <PageSlide Orientation="Horizontal" Duration="0:0:0.3" />
        </CarouselPage.PageTransition>
        <local:OnboardingPage1 />
        <local:OnboardingPage2 />
        <local:OnboardingPage3 />
    </CarouselPage>

    <!-- Footer with pips and buttons -->
    <StackPanel Grid.Row="1" Spacing="16" Margin="24,16">
        <PipsPager NumberOfPages="3"
                   SelectedPageIndex="{Binding #onboardingCarousel.SelectedIndex}" />
        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" Spacing="12">
            <Button Content="Skip" Classes="Borderless"
                    Command="{Binding SkipCommand}" />
            <Button Content="Next" Theme="{DynamicResource SolidButton}"
                    Command="{Binding NextCommand}" />
        </StackPanel>
    </StackPanel>
</Grid>
```

```csharp
public class OnboardingViewModel : ObservableObject
{
    private int _currentStep;
    public int CurrentStep
    {
        get => _currentStep;
        set => SetProperty(ref _currentStep, value);
    }

    public ICommand NextCommand { get; }
    public ICommand SkipCommand { get; }

    public OnboardingViewModel()
    {
        NextCommand = new RelayCommand(OnNext);
        SkipCommand = new RelayCommand(OnSkip);
    }

    private void OnNext()
    {
        if (CurrentStep < 2)
            CurrentStep++;
        else
            OnComplete();
    }

    private void OnSkip() => OnComplete();
    private void OnComplete() { /* navigate to main app */ }
}
```

### Content Feed with Sections / 带板块的内容资讯流

Use `CarouselPage` as a swipeable feed container where each page represents a content section.

```xml
<Grid RowDefinitions="Auto,*">
    <!-- Section tabs at top -->
    <ListBox Grid.Row="0"
             ItemsSource="{Binding Sections}"
             SelectedIndex="{Binding #feedCarousel.SelectedIndex}"
             Classes="HorizontalTabStrip">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Title}" Margin="12,8" />
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>

    <!-- Swipeable content pages -->
    <CarouselPage Grid.Row="1"
                  x:Name="feedCarousel"
                  SelectedIndex="{Binding SelectedSectionIndex}">
        <local:ForYouFeedPage Title="For You" />
        <local:TrendingFeedPage Title="Trending" />
        <local:FollowingFeedPage Title="Following" />
    </CarouselPage>
</Grid>
```

### With PageIndicator (PipsPager) / 配合页面指示器

```xml
<Grid RowDefinitions="*,Auto">
    <CarouselPage x:Name="galleryCarousel"
                  SelectedIndex="{Binding CurrentImageIndex}">
        <CarouselPage.PageTransition>
            <CrossFade Duration="0:0:0.2" />
        </CarouselPage.PageTransition>
        <local:ImageViewPage ImageSource="photo1.jpg" />
        <local:ImageViewPage ImageSource="photo2.jpg" />
        <local:ImageViewPage ImageSource="photo3.jpg" />
        <local:ImageViewPage ImageSource="photo4.jpg" />
    </CarouselPage>

    <PipsPager Grid.Row="1"
               NumberOfPages="4"
               SelectedPageIndex="{Binding #galleryCarousel.SelectedIndex}"
               HorizontalAlignment="Center"
               Margin="0,12" />
</Grid>
```

### Loop & Auto-Play / 循环与自动播放

Combine `CarouselPage` with a timer for auto-advancing carousels (e.g., hero banners).

```csharp
public partial class HeroCarouselPage : CarouselPage
{
    private Timer? _autoPlayTimer;

    public HeroCarouselPage()
    {
        InitializeComponent();

        // Start auto-play: advance every 4 seconds
        _autoPlayTimer = new Timer(_ =>
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (SelectedIndex < Children.Count - 1)
                    SelectedIndex++;
                else
                    SelectedIndex = 0; // Loop back to start
            });
        }, null, TimeSpan.FromSeconds(4), TimeSpan.FromSeconds(4));
    }

    // Pause auto-play when user manually swipes
    private void OnUserInteraction(object? sender, PointerPressedEventArgs e)
    {
        _autoPlayTimer?.Change(Timeout.Infinite, Timeout.Infinite);
    }

    // Resume after a delay
    private void OnUserInteractionEnd(object? sender, PointerReleasedEventArgs e)
    {
        _autoPlayTimer?.Change(TimeSpan.FromSeconds(8), TimeSpan.FromSeconds(4));
    }
}
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `SelectedIndex` | `int` | The zero-based index of the currently displayed page. / 当前显示页面的从零开始的索引。 |
| `SelectedItem` | `ContentPage?` | The currently displayed child page. / 当前显示的子页面。 |
| `Children` | `IList<ContentPage>` | The collection of child pages displayed in the carousel. / 在轮播中显示的子页面集合。 |
| `PageTransition` | `IPageTransition?` | The transition animation when switching pages. Default is a horizontal `PageSlide`. Supports `CrossFade`, `PageSlide`, and `Rotate3DTransition`. / 切换页面时的过渡动画。默认为水平 `PageSlide`。支持 `CrossFade`、`PageSlide` 和 `Rotate3DTransition`。 |
| `IsSwipeEnabled` | `bool` | Whether the user can swipe to change pages. Default `true`. Set to `false` for programmatic-only navigation. / 用户是否可以通过滑动切换页面。默认 `true`。设为 `false` 则仅允许编程式导航。 |
| `Loop` | `bool` | Whether navigation wraps around from the last page back to the first (and vice versa). Default `false`. / 导航是否从最后一页回到第一页（反之亦然）。默认 `false`。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectionChanged` | Raised when `SelectedIndex` or `SelectedItem` changes, carrying the old and new values. / 当 `SelectedIndex` 或 `SelectedItem` 变更时触发，携带旧值和新值。 |
| `PageAppearing` | Raised when a child page is about to become visible. / 当子页面即将变为可见时触发。 |
| `PageDisappearing` | Raised when a child page is about to be hidden. / 当子页面即将隐藏时触发。 |

### Methods / 方法

| Method / 方法 | Description / 说明 |
| --- | --- |
| `Next()` | Advances to the next page. Wraps if `Loop` is `true`, otherwise stops at the last page. / 前进到下一页。如果 `Loop` 为 `true` 则回绕，否则停在最后一页。 |
| `Previous()` | Goes back to the previous page. Wraps if `Loop` is `true`, otherwise stops at the first page. / 后退到上一页。如果 `Loop` 为 `true` 则回绕，否则停在第一页。 |

## Styling & Templating / 样式与模板

Semi.Avalonia styles `CarouselPage` as a minimal swipe container with a smooth horizontal slide transition. The control contributes no visible chrome — visual presentation is handled by the child pages and optional `PipsPager` indicator. Semi Design conventions recommend using `PipsPager` for onboarding flows and segmented tab strips for content feeds.

Semi.Avalonia 将 `CarouselPage` 样式化为极简滑动容器，带有平滑的水平滑动过渡。控件不贡献任何可见装饰 —— 视觉呈现由子页面和可选的 `PipsPager` 指示器处理。Semi Design 约定建议在引导流程中使用 `PipsPager`，在内容资讯流中使用分段标签条。

### Theme Variants / 主题变体

| Theme / 主题 | Resource Key / 资源键 | Appearance / 外观 |
| --- | --- | --- |
| **Default** | `{x:Type CarouselPage}` | Transparent container with horizontal slide transition. / 透明容器，带水平滑动过渡。 |

```xml
<CarouselPage SelectedIndex="0">
    <CarouselPage.PageTransition>
        <PageSlide Orientation="Horizontal" Duration="0:0:0.3" />
    </CarouselPage.PageTransition>
    <local:PageA />
    <local:PageB />
</CarouselPage>
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:first` | Applied when the first page is displayed (no previous page available). / 当显示第一页时应用（无上一页可用）。 |
| `:last` | Applied when the last page is displayed (no next page available). / 当显示最后一页时应用（无下一页可用）。 |
| `:swiping` | Applied during an active swipe gesture. / 在活跃滑动手势期间应用。 |
| `:disabled` | Control is disabled (`IsEnabled = false`). Swipe is blocked. / 控件已禁用。滑动被阻止。 |

### DynamicResource Keys / 动态资源键

```
CarouselPageBackground        → Transparent
CarouselPageTransitionDuration → 0.3 seconds
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Carousel` | `Carousel` | The internal `Carousel` control that hosts and transitions between child pages. / 承载子页面并在它们之间过渡的内部 `Carousel` 控件。 |
| `PART_PageHost` | `ContentPresenter` | Displays the currently selected child page. / 显示当前选中的子页面。 |

## FAQ / 常见问题

**Q: How does CarouselPage differ from a plain Carousel control? / CarouselPage 与普通 Carousel 控件有何不同？**

A: `CarouselPage` is purpose-built for page-level navigation. It expects children to be `ContentPage` instances, integrates with the page lifecycle (`Appearing`/`Disappearing` events), supports `Loop` and `IsSwipeEnabled` at the page level, and works seamlessly with `PipsPager`. Use `Carousel` directly when you need generic item transitions (e.g., image galleries without page semantics), and use `CarouselPage` when each child is a full page with its own `BindingContext` and lifecycle. / `CarouselPage` 专为页面级导航而设计。它期望子元素为 `ContentPage` 实例，与页面生命周期（`Appearing`/`Disappearing` 事件）集成，支持页面级别的 `Loop` 和 `IsSwipeEnabled`，并与 `PipsPager` 无缝协作。当你需要通用项过渡（如无页面语义的图片画廊）时直接使用 `Carousel`；当每个子元素都是具有自身 `BindingContext` 和生命周期的完整页面时使用 `CarouselPage`。

**Q: Can I combine CarouselPage with TabbedPage? / 能否将 CarouselPage 与 TabbedPage 组合使用？**

A: Yes. A common pattern is a `TabbedPage` where one tab (e.g., "Home") contains a `CarouselPage` for swiping between content sections like "For You", "Trending", and "Following". Each section is a `ContentPage` child of the `CarouselPage`. / 可以。常见模式是 `TabbedPage` 中某个标签页（如"首页"）包含一个 `CarouselPage`，用于在"推荐"、"热门"、"关注"等内容板块之间滑动。每个板块是 `CarouselPage` 的一个 `ContentPage` 子元素。

**Q: How do I sync a PipsPager or tab strip with the CarouselPage? / 如何将 PipsPager 或标签条与 CarouselPage 同步？**

A: Bind `PipsPager.SelectedPageIndex` or the tab strip's `SelectedIndex` to `CarouselPage.SelectedIndex` using two-way binding, or use a compiled binding with `x:Reference`:

```xml
<PipsPager NumberOfPages="4"
           SelectedPageIndex="{Binding #myCarousel.SelectedIndex}" />
<CarouselPage x:Name="myCarousel" SelectedIndex="0">
    ...
</CarouselPage>
```

For a tab strip, bind `ListBox.SelectedIndex` to `CarouselPage.SelectedIndex` with two-way binding. The carousel follows the tab strip selection and vice versa. / 将 `PipsPager.SelectedPageIndex` 或标签条的 `SelectedIndex` 通过双向绑定或 `x:Reference` 编译绑定到 `CarouselPage.SelectedIndex`。轮播会跟随标签条的选择，反之亦然。
