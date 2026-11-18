---
category: Components
title: TabItem
subtitle: 标签页项
description: 标签页项用于在 TabControl 中表示单个标签页面，包含页眉和内容。
---

## TabItem / 标签页项

Represents a single selectable tab inside a `TabControl`. Inherits from `HeaderedItemsControl`. Each `TabItem` provides a `Header` (the clickable tab strip element) and `Content` (the panel shown when the tab is selected). Supports `IsSelected` for programmatic tab switching and integrates with Semi.Avalonia's tab styling system.

表示 `TabControl` 中单个可选择的标签页。继承自 `HeaderedItemsControl`。每个 `TabItem` 提供 `Header`（可点击的标签条元素）和 `Content`（标签页选中时显示的面板）。支持 `IsSelected` 用于编程式标签切换，并与 Semi.Avalonia 的标签样式系统集成。

## When to Use / 何时使用

Use `TabItem` as a child of `TabControl` when you need to organize content into mutually exclusive tabs — settings pages, multi-panel dashboards, property editors, or any UI where the user switches between several views within the same container. For bottom-navigation-bar patterns, consider `TabbedPage` from the Semi.Avalonia navigation framework. For wizard-style sequential views, use `Carousel`.

当需要将内容组织成互斥的标签页时，将 `TabItem` 用作 `TabControl` 的子项 —— 设置页面、多面板仪表板、属性编辑器，或任何用户在同一容器内的多个视图之间切换的界面。对于底部导航栏模式，请考虑使用 Semi.Avalonia 导航框架中的 `TabbedPage`。对于向导式顺序视图，请使用 `Carousel`。

## Basic Usage / 基本使用

```xml
<TabControl>
    <TabItem Header="General">
        <StackPanel Spacing="8">
            <TextBlock Text="General settings content" />
        </StackPanel>
    </TabItem>
    <TabItem Header="Advanced">
        <StackPanel Spacing="8">
            <TextBlock Text="Advanced settings content" />
        </StackPanel>
    </TabItem>
    <TabItem Header="About">
        <TextBlock Text="About information" />
    </TabItem>
</TabControl>
```

```csharp
// Programmatic creation
var tabControl = new TabControl();

var generalTab = new TabItem
{
    Header = "General",
    Content = new TextBlock { Text = "General settings" }
};

var advancedTab = new TabItem
{
    Header = "Advanced",
    Content = new TextBlock { Text = "Advanced settings" }
};

tabControl.Items.Add(generalTab);
tabControl.Items.Add(advancedTab);

// Select programmatically
generalTab.IsSelected = true;
```

## Common Scenarios / 常用场景

### Rich Header Content / 富文本页眉

`TabItem.Header` accepts any object, not just strings. Use a `StackPanel` to create headers with icons.

```xml
<TabControl>
    <TabItem>
        <TabItem.Header>
            <StackPanel Orientation="Horizontal" Spacing="6">
                <PathIcon Data="{StaticResource HomeIconGeometry}" Width="16" Height="16" />
                <TextBlock Text="Home" />
            </StackPanel>
        </TabItem.Header>
        <local:HomeView />
    </TabItem>
    <TabItem>
        <TabItem.Header>
            <StackPanel Orientation="Horizontal" Spacing="6">
                <PathIcon Data="{StaticResource SettingsIconGeometry}" Width="16" Height="16" />
                <TextBlock Text="Settings" />
            </StackPanel>
        </TabItem.Header>
        <local:SettingsView />
    </TabItem>
</TabControl>
```

### TabStripPlacement / 标签条位置

Use `TabStripPlacement` on `TabControl` to position tabs on any side.

```xml
<!-- Tabs on the left side -->
<TabControl TabStripPlacement="Left">
    <TabItem Header="General">
        <TextBlock Text="Content" />
    </TabItem>
    <TabItem Header="Security">
        <TextBlock Text="Content" />
    </TabItem>
</TabControl>

<!-- Tabs on the bottom -->
<TabControl TabStripPlacement="Bottom">
    <TabItem Header="Tab 1" />
    <TabItem Header="Tab 2" />
</TabControl>
```

### MVVM with ItemsSource / 通过 ItemsSource 实现 MVVM

Use `TabControl.ItemsSource` with data templates for dynamic tab generation.

```xml
<TabControl ItemsSource="{Binding Tabs}"
            SelectedItem="{Binding SelectedTab}">
    <TabControl.ItemTemplate>
        <DataTemplate>
            <TextBlock Text="{Binding Title}" />
        </DataTemplate>
    </TabControl.ItemTemplate>
    <TabControl.ContentTemplate>
        <DataTemplate>
            <ContentControl Content="{Binding View}" />
        </DataTemplate>
    </TabControl.ContentTemplate>
</TabControl>
```

```csharp
public class TabViewModel
{
    public string Title { get; set; }
    public object View { get; set; }
}

public class MainViewModel : ObservableObject
{
    public ObservableCollection<TabViewModel> Tabs { get; } = new();

    private TabViewModel? _selectedTab;
    public TabViewModel? SelectedTab
    {
        get => _selectedTab;
        set => SetProperty(ref _selectedTab, value);
    }

    public MainViewModel()
    {
        Tabs.Add(new TabViewModel { Title = "Home", View = new HomeView() });
        Tabs.Add(new TabViewModel { Title = "Settings", View = new SettingsView() });
    }
}
```

### Programmatic Selection & Events / 编程选择与事件

```xml
<TabControl x:Name="mainTabs">
    <TabItem Header="Tab 1" IsSelected="True">
        <TextBlock Text="First tab" />
    </TabItem>
    <TabItem Header="Tab 2">
        <TextBlock Text="Second tab" />
    </TabItem>
</TabControl>
```

```csharp
// Handle selection change
mainTabs.SelectionChanged += (s, e) =>
{
    if (e.AddedItems.Count > 0)
    {
        var selectedTab = (TabItem)e.AddedItems[0]!;
        Console.WriteLine($"Selected: {selectedTab.Header}");
    }
};
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Header` | `object?` | The content displayed in the tab strip for this item. Accepts text, controls, or layouts. Inherited from `HeaderedItemsControl`. / 在标签条中为此项显示的内容。接受文本、控件或布局。继承自 `HeaderedItemsControl`。 |
| `Content` | `object?` | The content displayed when the tab is selected. Inherited from `ContentControl`. / 标签页选中时显示的内容。继承自 `ContentControl`。 |
| `IsSelected` | `bool` | Whether this tab is currently selected. Setting to `true` selects the tab; setting to `false` deselects it (selecting another tab instead). / 此标签页当前是否被选中。设为 `true` 选中标签页；设为 `false` 取消选中（转而选中其他标签页）。 |
| `TabStripPlacement` | `Dock` | Determines which side the tab strip appears on. Set on the parent `TabControl`: `Top` (default), `Bottom`, `Left`, or `Right`. / 决定标签条出现在哪一侧。在父级 `TabControl` 上设置：`Top`（默认）、`Bottom`、`Left` 或 `Right`。 |
| `IsEnabled` | `bool` | Whether the tab can be selected. Disabled tabs appear grayed out. / 此标签页是否可选择。禁用的标签页显示为灰色。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `IsSelectedChanged` | Raised when the `IsSelected` property changes, typically on user click or programmatic selection. Carries `RoutedEventArgs`. / 当 `IsSelected` 属性变更时触发，通常在用户点击或编程选择时。携带 `RoutedEventArgs`。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How do I hide the tab strip and control tabs programmatically? / 如何隐藏标签条并以编程方式控制标签页？**

A: Set the `TabStripPlacement` to an off-screen value and use `IsSelected` or `SelectedIndex` to switch tabs programmatically. Alternatively, use `Carousel` which has no visible tab strip by design. / 将 `TabStripPlacement` 设置为屏幕外的值，使用 `IsSelected` 或 `SelectedIndex` 进行编程切换。或者使用 `Carousel`，它天然没有可见标签条。

**Q: Can TabItem.Content be lazy-loaded? / TabItem.Content 能否延迟加载？**

A: Avalonia `TabControl` creates all tab content eagerly by default. For lazy loading, use `ItemsSource` with `ContentTemplate` — the template is applied when each item becomes selected. Alternatively, use `ContentControl` inside `TabItem` with a deferred binding. / Avalonia `TabControl` 默认会积极创建所有标签页内容。要实现延迟加载，请使用 `ItemsSource` 配合 `ContentTemplate` —— 模板在每个项被选中时应用。或者，在 `TabItem` 内使用 `ContentControl` 配合延迟绑定。

**Q: How do I style individual tabs differently? / 如何为不同标签页设置不同样式？**

A: Apply classes directly to individual `TabItem` instances or use a `DataTemplate` selector on `TabControl.ItemTemplate`. Semi.Avalonia's pseudo-classes (`:selected`, `:pointerover`) work per-item, so conditional styling based on the selected state is automatic. / 直接对各个 `TabItem` 实例应用类，或在 `TabControl.ItemTemplate` 上使用 `DataTemplate` 选择器。Semi.Avalonia 的伪类（`:selected`、`:pointerover`）按项生效，因此基于选中状态的条件样式是自动应用的。
