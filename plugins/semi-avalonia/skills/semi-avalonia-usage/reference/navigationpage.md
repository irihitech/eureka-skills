---
category: Components
title: NavigationPage
subtitle: 导航页面
description: 导航页面提供基于堆栈的页面导航，支持页面的推入（Push）和弹出（Pop）操作，带有导航栏和返回按钮。
---

## NavigationPage / 导航页面

A page container that manages a stack-based navigation history of `ContentPage` instances. Inherits from `ContentPage`. `NavigationPage` provides a navigation bar with a title, an optional back button, and toolbar items. Pages are pushed onto the stack with `PushAsync` and popped with `PopAsync`. The root page cannot be popped — it forms the base of the navigation stack.

一种管理 `ContentPage` 实例的堆栈式导航历史的页面容器。继承自 `ContentPage`。`NavigationPage` 提供带有标题、可选的返回按钮和工具栏项的导航栏。页面通过 `PushAsync` 推入堆栈，通过 `PopAsync` 弹出。根页面不可弹出 —— 它构成导航堆栈的基础。

## When to Use / 何时使用

Use `NavigationPage` when your application has a drill-down navigation flow — list → detail, settings → sub-settings, wizard steps, or any hierarchical navigation where the user moves forward and backward through a sequence of pages. For flat, same-level navigation between sibling sections, prefer `TabbedPage` or `CarouselPage`. For sidebar-based navigation, wrap a `NavigationPage` inside a `DrawerPage`.

当你的应用具有钻取式导航流程时使用 `NavigationPage` —— 列表 → 详情，设置 → 子设置，向导步骤，或任何用户在一系列页面之间前后移动的层次化导航。对于同级板块之间的平面导航，请使用 `TabbedPage` 或 `CarouselPage`。对于基于侧边栏的导航，请将 `NavigationPage` 包装在 `DrawerPage` 中。

## Basic Usage / 基本使用

```xml
<Window>
    <NavigationPage x:Name="navPage">
        <NavigationPage.Root>
            <local:HomePage Title="Home" />
        </NavigationPage.Root>
    </NavigationPage>
</Window>
```

```csharp
// Push a new page onto the stack
var detailPage = new DetailPage
{
    Title = "Item Detail",
    BindingContext = selectedItem
};
await navPage.Navigation.PushAsync(detailPage);

// Pop back to the previous page
await navPage.Navigation.PopAsync();

// Pop to root (clear all pushed pages)
await navPage.Navigation.PopToRootAsync();
```

## Common Scenarios / 常用场景

### List → Detail Navigation / 列表 → 详情导航

The most common navigation pattern: tap a list item to push a detail page.

```xml
<!-- HomePage with list -->
<ContentPage Title="Products">
    <ListBox ItemsSource="{Binding Products}"
             SelectionChanged="OnProductSelected">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Name}" FontSize="16" Margin="4" />
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
</ContentPage>
```

```csharp
private async void OnProductSelected(object? sender, SelectionChangedEventArgs e)
{
    if (e.AddedItems.Count == 0) return;
    var product = (Product)e.AddedItems[0]!;

    await Navigation.PushAsync(new ProductDetailPage
    {
        Title = product.Name,
        BindingContext = new ProductDetailViewModel(product)
    });

    // Clear selection for when user pops back
    ((ListBox)sender!).SelectedItem = null;
}
```

### Navigation Bar Customization / 导航栏自定义

Control bar visibility, color, and the back button behavior.

```xml
<NavigationPage x:Name="navPage"
                HasNavigationBar="True"
                HasBackButton="True">
    <NavigationPage.Root>
        <local:HomePage Title="Home" />
    </NavigationPage.Root>
</NavigationPage>
```

```csharp
// Hide the navigation bar on a specific page
navPage.HasNavigationBar = false;

// Disable the back button
navPage.HasBackButton = false;
```

### Passing Data Between Pages / 页面间传递数据

```csharp
// Sender: push with data
var editPage = new EditItemPage
{
    Title = "Edit Item",
    BindingContext = new EditItemViewModel(currentItem)
};

editPage.ItemSaved += (s, savedItem) =>
{
    // Receiver: refresh list when detail page saves
    RefreshItemInList(savedItem);
};

await Navigation.PushAsync(editPage);
```

```csharp
// Using Messaging or shared service (MVVM pattern)
public class DetailViewModel : ObservableObject
{
    private readonly IDataService _dataService;

    public async Task SaveAndGoBack()
    {
        await _dataService.SaveAsync(CurrentItem);
        await Navigation.PopAsync();
    }
}
```

### Toolbar Items / 工具栏项

Add action buttons to the navigation bar.

```xml
<ContentPage Title="Edit">
    <ContentPage.ToolbarItems>
        <ToolbarItem Text="Save"
                     Command="{Binding SaveCommand}"
                     Icon="save_icon" />
        <ToolbarItem Text="Delete"
                     Command="{Binding DeleteCommand}" />
    </ContentPage.ToolbarItems>
    <StackPanel>...</StackPanel>
</ContentPage>
```

### Modal Pages / 模态页面

Use `PushModalAsync` to present a page modally (blocks interaction with pages below).

```csharp
// Push a modal login page
var loginPage = new LoginPage { Title = "Sign In" };
await Navigation.PushModalAsync(loginPage);

// Pop the modal
await Navigation.PopModalAsync();
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Root` | `ContentPage` | The root page of the navigation stack. Cannot be popped. / 导航堆栈的根页面。不可弹出。 |
| `CurrentPage` | `ContentPage?` | (Read-only) The page currently displayed on top of the stack. / （只读）当前在堆栈顶部显示的页面。 |
| `HasNavigationBar` | `bool` | Whether the navigation bar is visible. Default `true`. / 导航栏是否可见。默认 `true`。 |
| `HasBackButton` | `bool` | Whether the back button is shown on pushed pages. Default `true`. / 推送页面上是否显示返回按钮。默认 `true`。 |
| `BarBackground` | `IBrush?` | Background brush for the navigation bar. / 导航栏的背景画刷。 |
| `BarForeground` | `IBrush?` | Foreground/text color for the navigation bar title and buttons. / 导航栏标题和按钮的前景/文字颜色。 |
| `Navigation` | `INavigation` | The navigation interface providing `PushAsync`, `PopAsync`, `PopToRootAsync`, `PushModalAsync`, `PopModalAsync`, and stack inspection. / 导航接口，提供 `PushAsync`、`PopAsync`、`PopToRootAsync`、`PushModalAsync`、`PopModalAsync` 和堆栈检查。 |
| `NavigationStack` | `IReadOnlyList<ContentPage>` | (Read-only) The current stack of pages above the root. / （只读）当前在根页面之上的页面堆栈。 |
| `ModalStack` | `IReadOnlyList<ContentPage>` | (Read-only) The current stack of modal pages. / （只读）当前模态页面堆栈。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Pushed` | Raised after a page has been pushed onto the navigation stack. / 页面被推入导航堆栈后触发。 |
| `Popped` | Raised after a page has been popped from the navigation stack. / 页面从导航堆栈弹出后触发。 |
| `PoppedToRoot` | Raised when the stack is cleared back to the root page. / 当堆栈清空回到根页面时触发。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How do I prevent the user from going back? / 如何阻止用户返回？**

A: Set `HasBackButton = false` to hide the back button, and override `OnBackButtonPressed()` in your page to return `true` (handled). Also consider locking the navigation by temporarily removing the ability to call `PopAsync`:

```csharp
// In a page where back should be blocked
protected override bool OnBackButtonPressed()
{
    if (IsSaving)
    {
        // Show a "please wait" indicator instead of going back
        return true;
    }
    return base.OnBackButtonPressed();
}
```

将 `HasBackButton` 设为 `false` 来隐藏返回按钮，并在页面中重写 `OnBackButtonPressed()` 返回 `true`。

**Q: How do I animate the page transition differently? / 如何设置不同的页面过渡动画？**

A: Semi.Avalonia's `NavigationPage` ships with a default push/pop transition; what it looks like is part of the theme (see the generated `semi-avalonia` skill). For custom transitions, set the `PageTransition` property on the `NavigationPage` or override the control template's `TransitioningContentControl` settings. / Semi.Avalonia 的 `NavigationPage` 自带默认的推送/弹出过渡；具体效果属于主题内容（见生成的 `semi-avalonia` skill）。如需自定义过渡，请在 `NavigationPage` 上设置 `PageTransition` 属性，或重写控件模板的 `TransitioningContentControl` 设置。

**Q: Can I have multiple NavigationPages in one app? / 能否在一个应用中使用多个 NavigationPage？**

A: Yes. A common pattern is a `TabbedPage` where each tab contains its own `NavigationPage`, giving each tab an independent navigation stack. The `Navigation` property on a `ContentPage` resolves to the nearest parent `NavigationPage`. / 可以。常见模式是 `TabbedPage` 的每个标签页都包含独立的 `NavigationPage`，使每个标签页拥有独立的导航堆栈。`ContentPage` 上的 `Navigation` 属性会解析到最近的父级 `NavigationPage`。
