---
category: Components
title: ContentPage
subtitle: 内容页面
description: 内容页面是最基础的页面容器，用于承载单个内容视图，是其他导航页面的基类。
---

## ContentPage / 内容页面

The simplest page container in the Semi.Avalonia navigation framework. Inherits from `UserControl`. `ContentPage` wraps a single child element — typically a layout panel — and provides the foundational surface for all other page types (`NavigationPage`, `TabbedPage`, `DrawerPage`, `CarouselPage`). Use it as the leaf page that holds the actual UI content of your application.

Semi.Avalonia 导航框架中最简单的页面容器。继承自 `UserControl`。`ContentPage` 包裹单个子元素 —— 通常是布局面板 —— 并为所有其他页面类型（`NavigationPage`、`TabbedPage`、`DrawerPage`、`CarouselPage`）提供基础表面。将其用作承载应用实际 UI 内容的叶子页面。

## When to Use / 何时使用

Use `ContentPage` as the primary building block for individual views in your application — settings pages, detail views, dashboard panels, or any standalone screen that does not require its own navigation structure. Compose `ContentPage` instances inside `NavigationPage` (for stack navigation), `TabbedPage` (for tabbed navigation), or `CarouselPage` (for swipe-based navigation). For pages that need a sidebar, use `DrawerPage` instead.

将 `ContentPage` 用作应用中各个视图的主要构建块 —— 设置页面、详情视图、仪表板面板，或任何不需要自身导航结构的独立屏幕。将 `ContentPage` 实例组合到 `NavigationPage`（用于堆栈导航）、`TabbedPage`（用于标签页导航）或 `CarouselPage`（用于滑动导航）中。对于需要侧边栏的页面，请使用 `DrawerPage`。

## Basic Usage / 基本使用

```xml
<ContentPage xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             x:Class="MyApp.Views.SettingsPage"
             Title="Settings">
    <StackPanel Spacing="12" Margin="16">
        <TextBlock Text="Settings" FontSize="24" FontWeight="Bold" />
        <TextBox Watermark="Username" />
        <TextBox Watermark="Email" />
        <Button Content="Save" Theme="{DynamicResource SolidButton}" />
    </StackPanel>
</ContentPage>
```

```csharp
// Code-behind
public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }
}

// Programmatic creation
var page = new ContentPage
{
    Title = "Settings",
    Content = new StackPanel
    {
        Spacing = 12,
        Margin = new Thickness(16),
        Children =
        {
            new TextBlock { Text = "Settings", FontSize = 24 },
            new TextBox { Watermark = "Username" },
            new Button { Content = "Save" }
        }
    }
};
```

## Common Scenarios / 常用场景

### Title & Navigation Bar Integration / 标题与导航栏集成

`ContentPage.Title` propagates to the parent `NavigationPage`'s navigation bar. Bind it for dynamic titles.

```xml
<ContentPage Title="{Binding PageTitle}">
    <ScrollViewer>
        <StackPanel Spacing="8" Margin="16">
            <TextBlock Text="{Binding DetailContent}" TextWrapping="Wrap" />
        </StackPanel>
    </ScrollViewer>
</ContentPage>
```

```csharp
public class DetailViewModel : ObservableObject
{
    private string _pageTitle = "Detail";
    public string PageTitle
    {
        get => _pageTitle;
        set => SetProperty(ref _pageTitle, value);
    }
}
```

### ContentPage inside NavigationPage / ContentPage 放在 NavigationPage 内

`NavigationPage` wraps a root `ContentPage` and manages a navigation stack.

```xml
<Window>
    <NavigationPage>
        <NavigationPage.Root>
            <local:HomePage Title="Home" />
        </NavigationPage.Root>
    </NavigationPage>
</Window>
```

```csharp
// Navigate to another ContentPage
await Navigation.PushAsync(new DetailPage { Title = "Item Detail" });

// Navigate back
await Navigation.PopAsync();
```

### ContentPage inside TabbedPage / ContentPage 放在 TabbedPage 内

```xml
<TabbedPage>
    <local:HomePage Title="Home" Icon="home_icon" />
    <local:SearchPage Title="Search" Icon="search_icon" />
    <local:ProfilePage Title="Profile" Icon="profile_icon" />
</TabbedPage>
```

### Lifecycle Events / 生命周期事件

`ContentPage` provides lifecycle overrides for appearing/disappearing and navigation events.

```csharp
public partial class DashboardPage : ContentPage
{
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Page is about to become visible — load data
        LoadDashboardData();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // Page is about to be hidden — pause updates
        PauseDataRefresh();
    }

    protected override bool OnBackButtonPressed()
    {
        // Handle platform back button / ESC key
        if (HasUnsavedChanges)
        {
            ShowDiscardDialog();
            return true; // Handled — prevent default back navigation
        }
        return base.OnBackButtonPressed();
    }
}
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Title` | `string?` | The page title displayed in the parent navigation bar or window title. / 显示在父级导航栏或窗口标题中的页面标题。 |
| `Content` | `object?` | The single child element displayed on the page. Inherited from `ContentControl`. / 页面上显示的单个子元素。继承自 `ContentControl`。 |
| `Navigation` | `INavigation?` | (Read-only) Reference to the nearest navigation host, providing `PushAsync`, `PopAsync`, and stack manipulation methods. / （只读）对最近导航主机的引用，提供 `PushAsync`、`PopAsync` 和堆栈操作方法。 |
| `IsBusy` | `bool` | When `true`, indicates the page is performing a long-running operation. Often used to show a loading indicator. / 设为 `true` 时表示页面正在执行长时间操作。通常用于显示加载指示器。 |
| `ToolbarItems` | `IList<ToolbarItem>` | Collection of toolbar items displayed in the parent navigation bar. / 显示在父级导航栏中的工具栏项集合。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Appearing` | Raised when the page is about to become visible. Use for data loading or subscription setup. / 页面即将变为可见时触发。用于数据加载或订阅设置。 |
| `Disappearing` | Raised when the page is about to be hidden. Use for cleanup and unsubscribing. / 页面即将隐藏时触发。用于清理和取消订阅。 |

### Lifecycle Methods / 生命周期方法

| Method / 方法 | Description / 说明 |
| --- | --- |
| `OnAppearing()` | Called when the page is about to appear. Override to load data or refresh state. / 页面即将出现时调用。重写以加载数据或刷新状态。 |
| `OnDisappearing()` | Called when the page is about to disappear. Override to save state or pause tasks. / 页面即将消失时调用。重写以保存状态或暂停任务。 |
| `OnBackButtonPressed()` | Called when the platform back button (or Escape key) is pressed. Return `true` to handle, `false` to let the system navigate back. / 当平台返回按钮（或 Escape 键）被按下时调用。返回 `true` 表示已处理，返回 `false` 让系统执行返回导航。 |

## Styling & Templating / 样式与模板

Semi.Avalonia styles `ContentPage` as a transparent full-surface container. The page itself contributes no visible chrome — all styling is delegated to its `Content` child and the parent navigation host. Semi.Avalonia provides consistent background, padding, and color resources that respond to the active theme.

Semi.Avalonia 将 `ContentPage` 样式化为透明全表面容器。页面本身不贡献任何可见装饰 —— 所有样式由 `Content` 子元素和父级导航主机处理。Semi.Avalonia 提供一致的背景、内边距和颜色资源，可响应活动主题。

### Theme Variants / 主题变体

| Theme / 主题 | Resource Key / 资源键 | Appearance / 外观 |
| --- | --- | --- |
| **Default** | `{x:Type ContentPage}` | Transparent background, fills available space. / 透明背景，填充可用空间。 |

```xml
<ContentPage Title="My Page" Background="{DynamicResource PageBackgroundBrush}">
    <StackPanel>...</StackPanel>
</ContentPage>
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:busy` | Applied when `IsBusy` is `true`. Use for loading overlays. / 当 `IsBusy` 为 `true` 时应用。用于加载遮罩。 |

### DynamicResource Keys / 动态资源键

```
PageBackgroundBrush       → Content page background
PageForegroundBrush       → Default text color
PagePadding               → Standard page margin
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the `Content` property. / 渲染 `Content` 属性。 |

## FAQ / 常见问题

**Q: What is the difference between ContentPage and a regular UserControl? / ContentPage 与普通 UserControl 有什么区别？**

A: `ContentPage` extends `UserControl` with navigation integration, lifecycle events (`Appearing`/`Disappearing`), a `Title` property for navigation bars, and `BackButton` handling. Use `ContentPage` when the view participates in Semi.Avalonia navigation. Use `UserControl` for reusable sub-components that are embedded inside pages. / `ContentPage` 扩展了 `UserControl`，增加了导航集成、生命周期事件（`Appearing`/`Disappearing`）、用于导航栏的 `Title` 属性以及返回按钮处理。当视图参与 Semi.Avalonia 导航时使用 `ContentPage`。对于嵌入页面内的可复用子组件，请使用 `UserControl`。

**Q: How do I show a loading indicator when IsBusy is true? / 如何在 IsBusy 为 true 时显示加载指示器？**

A: Semi.Avalonia applies the `:busy` pseudo-class. Style a loading overlay in your page template:

```xml
<ContentPage IsBusy="{Binding IsLoading}">
    <Grid>
        <StackPanel>...content...</StackPanel>
        <!-- Loading overlay, visible when :busy is active -->
        <Border Classes="loading-overlay" IsVisible="{Binding IsBusy}">
            <ProgressBar IsIndeterminate="True" Width="120" />
        </Border>
    </Grid>
</ContentPage>
```

Semi.Avalonia 会应用 `:busy` 伪类。在页面模板中为加载遮罩设置样式。

**Q: Can ContentPage.Content be changed at runtime? / ContentPage.Content 能否在运行时更改？**

A: Yes. `Content` is a bindable property. Swap it to replace the entire page body:

```csharp
page.Content = new StackPanel { Children = { new TextBlock { Text = "New content" } } };
```

However, for most MVVM scenarios, prefer keeping the content structure stable and using data binding to update the views inside, or use `Navigation.PushAsync` to push a new page. / 可以。`Content` 是一个可绑定属性。但在大多数 MVVM 场景中，建议保持内容结构稳定并从内部通过数据绑定更新视图，或使用 `Navigation.PushAsync` 推送新页面。
