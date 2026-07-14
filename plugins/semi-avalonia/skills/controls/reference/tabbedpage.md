---
category: Components
title: TabbedPage
subtitle: 标签页导航
description: 标签页导航页面通过底部或顶部的标签栏，在多个子页面之间进行切换，每个标签页拥有独立的内容。
---

## TabbedPage / 标签页导航

A multi-page container that displays a tab bar — typically at the bottom — allowing the user to switch between two or more child `ContentPage` instances. Inherits from `ContentPage`. Each child page is represented by a tab with an icon, title, and optional badge. `TabbedPage` is the recommended shell for apps with 3–5 top-level destinations.

一种多页面容器，显示一个标签栏 —— 通常位于底部 —— 允许用户在两个或更多子 `ContentPage` 实例之间切换。继承自 `ContentPage`。每个子页面由一个标签表示，包含图标、标题和可选徽章。`TabbedPage` 是拥有 3–5 个顶级版块的应用推荐的外壳方案。

## When to Use / 何时使用

Use `TabbedPage` as the root shell for applications with a fixed set of top-level destinations — home, search, notifications, profile — where each destination is a peer of the others. The tab bar stays visible while the user interacts with each tab's content. For hierarchical navigation within a tab, place a `NavigationPage` as the tab's child. For a swipeable page carousel, use `CarouselPage`. For a sidebar-based menu, use `DrawerPage`.

将 `TabbedPage` 用作拥有固定顶级目的地的应用根外壳 —— 首页、搜索、通知、个人资料 —— 其中每个目的地彼此平等。用户与每个标签页内容交互时标签栏保持可见。对于标签页内的层次化导航，将 `NavigationPage` 作为标签页的子元素。对于可滑动的页面轮播，请使用 `CarouselPage`。对于基于侧边栏的菜单，请使用 `DrawerPage`。

## Basic Usage / 基本使用

```xml
<TabbedPage x:Name="mainTabs">
    <local:HomePage Title="Home" Icon="home_icon" />
    <local:SearchPage Title="Search" Icon="search_icon" />
    <local:NotificationsPage Title="Alerts" Icon="bell_icon" />
    <local:ProfilePage Title="Profile" Icon="user_icon" />
</TabbedPage>
```

```csharp
// Programmatic creation
var tabbedPage = new TabbedPage();

tabbedPage.Children.Add(new HomePage
{
    Title = "Home",
    Icon = "home_icon"
});
tabbedPage.Children.Add(new SearchPage
{
    Title = "Search",
    Icon = "search_icon"
});
tabbedPage.Children.Add(new ProfilePage
{
    Title = "Profile",
    Icon = "user_icon"
});

// Select a tab programmatically
tabbedPage.SelectedIndex = 1; // Switch to Search
```

## Common Scenarios / 常用场景

### TabbedPage with NavigationPage per Tab / 每个标签页嵌入 NavigationPage

The recommended pattern for apps that need stack navigation within each tab.

```xml
<TabbedPage>
    <TabbedPage.Children>
        <NavigationPage Title="Home" Icon="home_icon">
            <NavigationPage.Root>
                <local:HomePage Title="Home" />
            </NavigationPage.Root>
        </NavigationPage>

        <NavigationPage Title="Browse" Icon="search_icon">
            <NavigationPage.Root>
                <local:BrowsePage Title="Browse" />
            </NavigationPage.Root>
        </NavigationPage>

        <NavigationPage Title="Cart" Icon="cart_icon">
            <NavigationPage.Root>
                <local:CartPage Title="Cart" />
            </NavigationPage.Root>
        </NavigationPage>

        <NavigationPage Title="Me" Icon="user_icon">
            <NavigationPage.Root>
                <local:ProfilePage Title="Me" />
            </NavigationPage.Root>
        </NavigationPage>
    </TabbedPage.Children>
</TabbedPage>
```

### Tab Bar Placement / 标签栏位置

Control whether the tab bar appears at the bottom or top.

```xml
<!-- Bottom tab bar (default, recommended for mobile-like layouts) -->
<TabbedPage TabBarPlacement="Bottom">
    <local:HomePage Title="Home" />
    <local:SearchPage Title="Search" />
</TabbedPage>

<!-- Top tab bar -->
<TabbedPage TabBarPlacement="Top">
    <local:TabA Title="First" />
    <local:TabB Title="Second" />
</TabbedPage>
```

### Badge Notifications / 徽章通知

Show unread counts or status indicators on tab items.

```xml
<TabbedPage>
    <local:HomePage Title="Home" Icon="home_icon" />
    <local:MessagesPage Title="Messages" Icon="mail_icon"
                        BadgeText="{Binding UnreadCount}"
                        BadgeColor="Danger" />
    <local:ProfilePage Title="Profile" Icon="user_icon" />
</TabbedPage>
```

```csharp
public class MessagesViewModel : ObservableObject
{
    private string? _unreadCount;
    public string? UnreadCount
    {
        get => _unreadCount;
        set => SetProperty(ref _unreadCount, value);
    }

    public async Task LoadUnreadCountAsync()
    {
        var count = await _messageService.GetUnreadCountAsync();
        UnreadCount = count > 0 ? count.ToString() : null;
    }
}
```

### MVVM with ItemsSource / 通过 ItemsSource 实现 MVVM

```xml
<TabbedPage ItemsSource="{Binding Tabs}"
            SelectedItem="{Binding SelectedTab}">
    <TabbedPage.ItemTemplate>
        <DataTemplate>
            <ContentControl Content="{Binding Page}" />
        </DataTemplate>
    </TabbedPage.ItemTemplate>
</TabbedPage>
```

```csharp
public class TabInfo
{
    public string Title { get; set; }
    public string Icon { get; set; }
    public ContentPage Page { get; set; }
}

public class ShellViewModel : ObservableObject
{
    public ObservableCollection<TabInfo> Tabs { get; } = new();

    private TabInfo? _selectedTab;
    public TabInfo? SelectedTab
    {
        get => _selectedTab;
        set => SetProperty(ref _selectedTab, value);
    }

    public ShellViewModel()
    {
        Tabs.Add(new TabInfo
        {
            Title = "Home", Icon = "home_icon",
            Page = new NavigationPage { Root = new HomePage() }
        });
        Tabs.Add(new TabInfo
        {
            Title = "Settings", Icon = "settings_icon",
            Page = new NavigationPage { Root = new SettingsPage() }
        });
    }
}
```

### Tab Selection Handling / 标签页选择处理

```csharp
public partial class MainTabs : TabbedPage
{
    public MainTabs()
    {
        InitializeComponent();
        SelectedIndexChanged += OnTabChanged;
    }

    private void OnTabChanged(object? sender, EventArgs e)
    {
        if (SelectedItem is ContentPage page)
        {
            Console.WriteLine($"Switched to tab: {page.Title}");
            // Refresh data on tab switch
            if (page.BindingContext is IRefreshable refreshable)
                refreshable.Refresh();
        }
    }
}
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `SelectedIndex` | `int` | The zero-based index of the currently selected tab. / 当前选中标签页的从零开始的索引。 |
| `SelectedItem` | `ContentPage?` | The currently selected child page. / 当前选中的子页面。 |
| `TabBarPlacement` | `TabBarPlacement` | Where the tab bar appears: `Bottom` (default) or `Top`. / 标签栏出现位置：`Bottom`（默认）或 `Top`。 |
| `TabBarBackground` | `IBrush?` | Background brush for the tab bar. / 标签栏的背景画刷。 |
| `TabBarForeground` | `IBrush?` | Foreground/text color for tab labels. / 标签文字的前景/文字颜色。 |
| `ItemsSource` | `IEnumerable?` | Collection used when generating tabs from a data source. / 从数据源生成标签页时使用的集合。 |
| `Children` | `IList<ContentPage>` | The collection of child pages displayed as tabs. / 作为标签页显示的子页面集合。 |
| `ItemTemplate` | `IDataTemplate?` | Template applied to each item when using `ItemsSource`. / 使用 `ItemsSource` 时应用于每个项的模板。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectedIndexChanged` | Raised when the selected tab changes. Use to refresh data or track analytics. / 选中标签页变更时触发。用于刷新数据或跟踪分析。 |

## Styling & Templating / 样式与模板

Semi.Avalonia styles `TabbedPage` with a modern bottom tab bar following Semi Design conventions: icon-above-label layout, animated selection indicator, and support for color classes. The tab bar includes a subtle top border separator and responsive touch targets.

Semi.Avalonia 遵循 Semi Design 约定，为 `TabbedPage` 提供了现代化的底部标签栏样式：图标在上标签在下的布局、动画选中指示器以及对颜色类的支持。标签栏包含微妙的上边框分割线和响应式触控区域。

### Theme Variants / 主题变体

| Theme / 主题 | Resource Key / 资源键 | Appearance / 外观 |
| --- | --- | --- |
| **Default** | `{x:Type TabbedPage}` | Bottom tab bar with icon + label, animated indicator. / 底部标签栏，图标+标签，动画指示器。 |

```xml
<TabbedPage TabBarBackground="{DynamicResource TabBarBackgroundBrush}"
            TabBarForeground="{DynamicResource TabBarForegroundBrush}">
    <local:HomePage Title="Home" Icon="home_icon" />
    <local:SearchPage Title="Search" Icon="search_icon" />
</TabbedPage>
```

### Color Classes / 颜色类

Apply via the `Classes` attached property on the `TabbedPage`.

| Class / 类名 | Description / 说明 |
| --- | --- |
| `Primary` | (default) Blue-accented active tab indicator and icon. / （默认）蓝色强调的活动标签指示器和图标。 |
| `Secondary` | Neutral gray accent. / 中性灰色强调。 |

```xml
<TabbedPage Classes="Secondary">
    <local:HomePage Title="Home" />
    <local:SearchPage Title="Search" />
</TabbedPage>
```

### Pseudo-classes / 伪类

Semi.Avalonia styles these pseudo-classes on individual tab items in the bar:

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:selected` | Applied to the currently active tab item. / 应用于当前活动的标签项。 |
| `:pointerover` | Mouse is hovering over a tab item. / 鼠标悬停在标签项上。 |
| `:pressed` | Tab item is being pressed. / 标签项被按下。 |

### DynamicResource Keys / 动态资源键

```
TabbedPageBarBackground
TabbedPageBarForeground
TabbedPageBarBorderBrush
TabbedPageSelectedForeground
TabbedPageUnselectedForeground
TabbedPageBarHeight
TabbedPageIconSize
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_TabBar` | `ItemsControl` | The tab bar that renders tab items. / 渲染标签项的标签栏。 |
| `PART_SelectedContentHost` | `ContentPresenter` | Displays the content of the selected tab. / 显示选中标签页的内容。 |

### Special ControlThemes / 特殊控件主题

Semi.Avalonia defines two alternative `TabbedPage` themes in `TabbedPage.axaml` that change the visual style of the tab bar.

Semi.Avalonia 在 `TabbedPage.axaml` 中定义了两个替代 `TabbedPage` 主题，用于改变标签栏的视觉风格。

#### `CardTabbedPage`

**TargetType:** `TabbedPage`
**Resource Key:** `CardTabbedPage`

A card-style `TabbedPage` variant where tabs are rendered with the `CardTabControl` theme and `CardTabItem` item container theme. Tabs appear as connected cards with subtle backgrounds and rounded top corners, with icons positioned above labels. The tab strip items are evenly distributed in a `UniformGrid`.

卡片式 `TabbedPage` 变体，标签使用 `CardTabControl` 主题和 `CardTabItem` 项容器主题渲染。标签呈现为连接的卡片，带有微妙背景和顶部圆角，图标位于标签上方。标签条项目在 `UniformGrid` 中均匀分布。

```xml
<TabbedPage Theme="{StaticResource CardTabbedPage}">
    <ContentPage Title="Home" Icon="{StaticResource HomeIcon}" />
    <ContentPage Title="Search" Icon="{StaticResource SearchIcon}" />
    <ContentPage Title="Settings" Icon="{StaticResource SettingsIcon}" />
</TabbedPage>
```

**Uses:** `CardTabControl` for the inner `TabControl`, `CardTabItem` for the item container, `UniformGrid` for even tab distribution, `TabItem.Padding="8"`, icons docked to `Top`.

#### `ButtonTabbedPage`

**TargetType:** `TabbedPage`
**Resource Key:** `ButtonTabbedPage`

A button-style `TabbedPage` variant where tabs are rendered with the `ButtonTabControl` theme and `ButtonTabItem` item container theme. Selected tabs have a solid fill background with rounded corners, similar to toggle-button groups. Icons are positioned above labels with slightly more padding for a button-like feel.

按钮式 `TabbedPage` 变体，标签使用 `ButtonTabControl` 主题和 `ButtonTabItem` 项容器主题渲染。选中的标签具有实色填充背景和圆角，类似于切换按钮组。图标位于标签上方，内边距稍大，呈现按钮般的触感。

```xml
<TabbedPage Theme="{StaticResource ButtonTabbedPage}">
    <ContentPage Title="Home" Icon="{StaticResource HomeIcon}" />
    <ContentPage Title="Search" Icon="{StaticResource SearchIcon}" />
    <ContentPage Title="Profile" Icon="{StaticResource ProfileIcon}" />
</TabbedPage>
```

**Uses:** `ButtonTabControl` for the inner `TabControl`, `ButtonTabItem` for the item container, `UniformGrid` for even tab distribution, `TabItem.Padding="12"`, icons docked to `Top`.

## FAQ / 常见问题

**Q: What is the recommended number of tabs in a TabbedPage? / TabbedPage 推荐多少个标签页？**

A: Semi Design recommends 3–5 tabs for optimal usability. Two tabs waste the bar space; six or more tabs make targets too small and harder to distinguish. If you need more destinations, consider using a `DrawerPage` with `NavigationPage` for secondary destinations, or use `TabbedPage` for the top 3–4 and place the rest in a "More" tab. / Semi Design 推荐 3–5 个标签页以获得最佳可用性。两个标签页浪费栏位空间；六个及以上标签页使触控目标过小且难以区分。如需更多目的地，请考虑使用 `DrawerPage` 配合 `NavigationPage` 存放次要目的地，或使用 `TabbedPage` 存放前 3–4 个，其余放到"更多"标签页中。

**Q: Can I embed a CarouselPage inside a TabbedPage tab? / 能否在 TabbedPage 标签页内嵌入 CarouselPage？**

A: Yes. This is a valid pattern when one tab needs a swipeable sub-section. For example, a "Home" tab could contain a `CarouselPage` that swipes between "For You", "Trending", and "Following" feeds. / 可以。当某个标签页需要可滑动的子板块时，这是一种有效的模式。例如，"首页"标签页可以包含一个 `CarouselPage`，在"推荐"、"热门"和"关注"之间滑动切换。

**Q: How do I hide the tab bar on a specific page? / 如何在特定页面上隐藏标签栏？**

A: The tab bar visibility is controlled at the `TabbedPage` level. To hide it temporarily, set `TabBarBackground = Transparent` and reduce `TabBarHeight` to `0`, or push a modal page that covers the entire `TabbedPage`. For more granular control, consider using `NavigationPage.PushModalAsync` to present a full-screen page over the `TabbedPage`. / 标签栏可见性在 `TabbedPage` 级别控制。要临时隐藏，可将 `TabBarBackground` 设为 `Transparent` 并将 `TabBarHeight` 减小到 `0`，或推送一个覆盖整个 `TabbedPage` 的模态页面。如需更精细的控制，请考虑使用 `NavigationPage.PushModalAsync` 在 `TabbedPage` 上显示全屏页面。
