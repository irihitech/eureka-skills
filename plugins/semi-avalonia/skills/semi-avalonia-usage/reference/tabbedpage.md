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

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: What is the recommended number of tabs in a TabbedPage? / TabbedPage 推荐多少个标签页？**

A: Semi Design recommends 3–5 tabs for optimal usability. Two tabs waste the bar space; six or more tabs make targets too small and harder to distinguish. If you need more destinations, consider using a `DrawerPage` with `NavigationPage` for secondary destinations, or use `TabbedPage` for the top 3–4 and place the rest in a "More" tab. / Semi Design 推荐 3–5 个标签页以获得最佳可用性。两个标签页浪费栏位空间；六个及以上标签页使触控目标过小且难以区分。如需更多目的地，请考虑使用 `DrawerPage` 配合 `NavigationPage` 存放次要目的地，或使用 `TabbedPage` 存放前 3–4 个，其余放到"更多"标签页中。

**Q: Can I embed a CarouselPage inside a TabbedPage tab? / 能否在 TabbedPage 标签页内嵌入 CarouselPage？**

A: Yes. This is a valid pattern when one tab needs a swipeable sub-section. For example, a "Home" tab could contain a `CarouselPage` that swipes between "For You", "Trending", and "Following" feeds. / 可以。当某个标签页需要可滑动的子板块时，这是一种有效的模式。例如，"首页"标签页可以包含一个 `CarouselPage`，在"推荐"、"热门"和"关注"之间滑动切换。

**Q: How do I hide the tab bar on a specific page? / 如何在特定页面上隐藏标签栏？**

A: The tab bar visibility is controlled at the `TabbedPage` level. To hide it temporarily, set `TabBarBackground = Transparent` and reduce `TabBarHeight` to `0`, or push a modal page that covers the entire `TabbedPage`. For more granular control, consider using `NavigationPage.PushModalAsync` to present a full-screen page over the `TabbedPage`. / 标签栏可见性在 `TabbedPage` 级别控制。要临时隐藏，可将 `TabBarBackground` 设为 `Transparent` 并将 `TabBarHeight` 减小到 `0`，或推送一个覆盖整个 `TabbedPage` 的模态页面。如需更精细的控制，请考虑使用 `NavigationPage.PushModalAsync` 在 `TabbedPage` 上显示全屏页面。
