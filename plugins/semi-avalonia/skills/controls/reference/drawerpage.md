---
category: Components
title: DrawerPage
subtitle: 抽屉页面
description: 抽屉页面是一个带有侧边抽屉导航的页面容器，支持从左侧或右侧滑出抽屉面板。
---

## DrawerPage / 抽屉页面

A page container that provides a slide-out drawer panel for navigation or auxiliary content. Inherits from `ContentPage`. The drawer is hidden by default and can be opened by swipe gesture, hamburger-button click, or programmatic control. Supports `Left` and `Right` drawer placement, configurable width, and overlay behavior. Commonly used as the root shell for master-detail layouts.

一种带有滑出式抽屉面板的页面容器，用于导航或辅助内容。继承自 `ContentPage`。抽屉默认隐藏，可通过滑动手势、汉堡菜单按钮点击或编程控制打开。支持 `Left` 和 `Right` 抽屉位置、可配置宽度及覆盖行为。通常用作主从布局的根外壳。

## When to Use / 何时使用

Use `DrawerPage` when you need a persistent slide-out navigation panel — app main menus, filter sidebars, setting drawers, or any master-detail pattern where auxiliary controls should be hidden until needed. For bottom-tab navigation, prefer `TabbedPage`. For stack-based drill-down navigation, wrap `ContentPage` children in a `NavigationPage`. For a carousel-style page swiper, use `CarouselPage`.

当你需要一个持久化的滑出导航面板时使用 `DrawerPage` —— 应用主菜单、筛选侧边栏、设置抽屉，或任何辅助控件应按需隐藏的主从模式。对于底部标签导航，请使用 `TabbedPage`。对于基于堆栈的钻取导航，请将 `ContentPage` 子项包装在 `NavigationPage` 中。对于轮播式页面滑动，请使用 `CarouselPage`。

## Basic Usage / 基本使用

```xml
<DrawerPage x:Name="mainDrawer"
            DrawerWidth="280">
    <!-- Main content area -->
    <DrawerPage.Content>
        <NavigationPage>
            <NavigationPage.Root>
                <local:HomePage Title="Home" />
            </NavigationPage.Root>
        </NavigationPage>
    </DrawerPage.Content>

    <!-- Drawer panel content -->
    <DrawerPage.Drawer>
        <Border Background="{DynamicResource SidebarBackgroundBrush}">
            <StackPanel Spacing="4" Margin="12">
                <Button Content="Home" Classes="Borderless"
                        Click="OnNavigateHome" />
                <Button Content="Settings" Classes="Borderless"
                        Click="OnNavigateSettings" />
                <Button Content="About" Classes="Borderless"
                        Click="OnNavigateAbout" />
            </StackPanel>
        </Border>
    </DrawerPage.Drawer>
</DrawerPage>
```

```csharp
// Programmatic control
private void OnHamburgerClick(object? sender, RoutedEventArgs e)
{
    mainDrawer.IsDrawerOpen = !mainDrawer.IsDrawerOpen;
}

private void OnNavigateHome(object? sender, RoutedEventArgs e)
{
    // Navigate and close drawer
    mainDrawer.IsDrawerOpen = false;
}
```

## Common Scenarios / 常用场景

### Hamburger Menu Pattern / 汉堡菜单模式

```xml
<DrawerPage x:Name="appDrawer"
            DrawerWidth="300"
            IsDrawerOpen="{Binding IsMenuOpen}">
    <DrawerPage.Content>
        <Grid RowDefinitions="Auto,*">
            <!-- Top bar with hamburger button -->
            <Border Grid.Row="0" Padding="12"
                    Background="{DynamicResource NavBarBackgroundBrush}">
                <StackPanel Orientation="Horizontal" Spacing="12">
                    <Button Classes="Borderless"
                            Click="OnToggleDrawer">
                        <PathIcon Data="{StaticResource MenuIcon}" />
                    </Button>
                    <TextBlock Text="{Binding CurrentPageTitle}"
                               FontSize="18" VerticalAlignment="Center" />
                </StackPanel>
            </Border>
            <!-- Page content -->
            <ContentControl Grid.Row="1"
                            Content="{Binding CurrentPage}" />
        </Grid>
    </DrawerPage.Content>

    <DrawerPage.Drawer>
        <Border Background="{DynamicResource DrawerBackgroundBrush}">
            <StackPanel Spacing="2" Margin="8">
                <ListBox ItemsSource="{Binding MenuItems}"
                         SelectedItem="{Binding SelectedMenuItem}">
                    <ListBox.ItemTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal" Spacing="8">
                                <PathIcon Data="{Binding Icon}" Width="20" Height="20" />
                                <TextBlock Text="{Binding Label}" />
                            </StackPanel>
                        </DataTemplate>
                    </ListBox.ItemTemplate>
                </ListBox>
            </StackPanel>
        </Border>
    </DrawerPage.Drawer>
</DrawerPage>
```

### Right-side Drawer / 右侧抽屉

Set `DrawerPlacement` to `Right` for auxiliary panels like filters, inspectors, or chat sidebars.

```xml
<DrawerPage DrawerPlacement="Right"
            DrawerWidth="320"
            IsDrawerOpen="{Binding IsInspectorOpen}">
    <DrawerPage.Content>
        <local:DocumentViewer />
    </DrawerPage.Content>
    <DrawerPage.Drawer>
        <Border Padding="16">
            <StackPanel Spacing="8">
                <TextBlock Text="Inspector" FontSize="18" FontWeight="Bold" />
                <!-- Inspector controls -->
            </StackPanel>
        </Border>
    </DrawerPage.Drawer>
</DrawerPage>
```

### MVVM Binding / MVVM 绑定

```xml
<DrawerPage IsDrawerOpen="{Binding IsDrawerOpen}"
            DrawerWidth="{Binding DrawerWidth}">
    <DrawerPage.Content>
        <ContentControl Content="{Binding ActivePage}" />
    </DrawerPage.Content>
    <DrawerPage.Drawer>
        <local:NavigationMenu SelectedItem="{Binding SelectedMenu}"
                              ItemsSource="{Binding MenuItems}" />
    </DrawerPage.Drawer>
</DrawerPage>
```

```csharp
public class ShellViewModel : ObservableObject
{
    private bool _isDrawerOpen;
    public bool IsDrawerOpen
    {
        get => _isDrawerOpen;
        set => SetProperty(ref _isDrawerOpen, value);
    }

    public void ToggleDrawer() => IsDrawerOpen = !IsDrawerOpen;

    public void NavigateTo(object page)
    {
        ActivePage = page;
        IsDrawerOpen = false; // Auto-close on navigation
    }
}
```

### Overlay vs Push Mode / 覆盖模式与推挤模式

Control whether the drawer overlays the content or pushes it aside.

```xml
<!-- Overlay mode (default): drawer floats over content -->
<DrawerPage DrawerMode="Overlay" DrawerWidth="280">
    ...
</DrawerPage>

<!-- Push mode: content is shifted to make room -->
<DrawerPage DrawerMode="Push" DrawerWidth="280">
    ...
</DrawerPage>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `IsDrawerOpen` | `bool` | Whether the drawer panel is currently open. Two-way bindable. / 抽屉面板当前是否打开。支持双向绑定。 |
| `DrawerWidth` | `double` | The width of the drawer panel in device-independent pixels. Default `280`. / 抽屉面板的宽度（设备无关像素）。默认 `280`。 |
| `DrawerPlacement` | `DrawerPlacement` | Which side the drawer appears from: `Left` (default) or `Right`. / 抽屉从哪一侧出现：`Left`（默认）或 `Right`。 |
| `DrawerMode` | `DrawerMode` | How the drawer interacts with content: `Overlay` (floats above, default) or `Push` (shifts content). / 抽屉与内容的交互方式：`Overlay`（浮动在上方，默认）或 `Push`（推移内容）。 |
| `Drawer` | `object?` | The content displayed inside the drawer panel. Accepts any UI element. / 抽屉面板内显示的内容。接受任何 UI 元素。 |
| `Content` | `object?` | The main content area. Inherited from `ContentPage`. / 主内容区域。继承自 `ContentPage`。 |
| `IsSwipeEnabled` | `bool` | Whether swipe gestures can open/close the drawer. Default `true`. / 是否允许滑动手势打开/关闭抽屉。默认 `true`。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `DrawerOpened` | Raised after the drawer has fully opened. Use to set focus or start animations. / 抽屉完全打开后触发。用于设置焦点或启动动画。 |
| `DrawerClosed` | Raised after the drawer has fully closed. Use to clean up transient state. / 抽屉完全关闭后触发。用于清理临时状态。 |
| `DrawerOpening` | Raised when the drawer begins to open. Can be canceled (if supported). / 抽屉开始打开时触发。可以取消（如果支持）。 |
| `DrawerClosing` | Raised when the drawer begins to close. Can be canceled (if supported). / 抽屉开始关闭时触发。可以取消（如果支持）。 |

## Styling & Templating / 样式与模板

Semi.Avalonia styles `DrawerPage` with a semi-transparent overlay scrim behind the drawer and smooth slide animations. The drawer panel itself is styled with a distinct background, shadow, and rounded corners when in overlay mode.

Semi.Avalonia 为 `DrawerPage` 提供了抽屉后方的半透明覆盖遮罩和平滑的滑动动画样式。抽屉面板本身在覆盖模式下具有独特的背景、阴影和圆角。

### Theme Variants / 主题变体

| Theme / 主题 | Resource Key / 资源键 | Appearance / 外观 |
| --- | --- | --- |
| **Default** | `{x:Type DrawerPage}` | Light overlay scrim, subtle drawer shadow, smooth 250ms slide. / 浅色覆盖遮罩，微妙抽屉阴影，平滑 250ms 滑动。 |

```xml
<DrawerPage IsDrawerOpen="True" DrawerWidth="300">
    <DrawerPage.Content>
        <local:MainContent />
    </DrawerPage.Content>
    <DrawerPage.Drawer>
        <local:DrawerMenu />
    </DrawerPage.Drawer>
</DrawerPage>
```

### Color Classes / 颜色类

| Class / 类名 | Description / 说明 |
| --- | --- |
| `Primary` | (default) Blue-accented drawer handle or indicator. / （默认）蓝色强调的抽屉手柄或指示器。 |
| `Secondary` | Neutral-toned drawer. / 中性色调的抽屉。 |

```xml
<DrawerPage Classes="Secondary">
    ...
</DrawerPage>
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:open` | Applied when `IsDrawerOpen` is `true`. Use to style the overlay or content shift. / 当 `IsDrawerOpen` 为 `true` 时应用。用于样式化覆盖层或内容偏移。 |
| `:closed` | Applied when `IsDrawerOpen` is `false`. / 当 `IsDrawerOpen` 为 `false` 时应用。 |
| `:left` | Applied when `DrawerPlacement` is `Left`. / 当 `DrawerPlacement` 为 `Left` 时应用。 |
| `:right` | Applied when `DrawerPlacement` is `Right`. / 当 `DrawerPlacement` 为 `Right` 时应用。 |

### DynamicResource Keys / 动态资源键

```
DrawerPageBackground
DrawerPageOverlayBackground
DrawerPageShadowBrush
DrawerPageBorderBrush
DrawerPageForeground
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_DrawerPanel` | `Panel` | The sliding drawer panel that contains the `Drawer` content. / 包含 `Drawer` 内容的滑动抽屉面板。 |
| `PART_Overlay` | `Border` | The semi-transparent overlay that covers the content area when the drawer is open. Clicking it closes the drawer. / 抽屉打开时覆盖内容区域的半透明遮罩。点击可关闭抽屉。 |
| `PART_ContentHost` | `ContentPresenter` | Hosts the main `Content` area. / 承载主 `Content` 区域。 |

## FAQ / 常见问题

**Q: How do I prevent the drawer from closing when clicking the overlay? / 如何防止点击遮罩时关闭抽屉？**

A: Handle the `DrawerClosing` event and inspect the reason. If the close is triggered by overlay click, you can set `e.Cancel = true` (if supported by the implementation). Alternatively, set the overlay's `IsHitTestVisible` to `false` through a custom style, but this also disables the scrim visual. / 处理 `DrawerClosing` 事件并检查原因。如果关闭是由遮罩点击触发的，可以设置 `e.Cancel = true`（如果实现支持）。或者通过自定义样式将遮罩的 `IsHitTestVisible` 设为 `false`，但这也会禁用遮罩视觉效果。

**Q: Can I nest a NavigationPage inside DrawerPage? / 能否在 DrawerPage 内嵌套 NavigationPage？**

A: Yes, and this is the recommended pattern for master-detail apps. Place a `NavigationPage` as the `Content` of the `DrawerPage`, and push pages onto it as the user navigates. The drawer remains available across all pushed pages. / 可以，这也是主从应用推荐的模式。将 `NavigationPage` 作为 `DrawerPage` 的 `Content`，用户导航时将页面推入其中。抽屉在所有已推送页面之间保持可用。

**Q: How do I animate the drawer opening/closing from code? / 如何通过代码设置抽屉打开/关闭动画？**

A: The slide animation is built into the `DrawerPage` control template. Simply set `IsDrawerOpen` to `true` or `false` and the transition plays automatically. For custom animations, you can override the control template and use `TransitioningContentControl` or keyframe animations triggered by the `:open`/`:closed` pseudo-classes. / 滑动动画内置于 `DrawerPage` 控件模板中。只需将 `IsDrawerOpen` 设为 `true` 或 `false`，过渡就会自动播放。如需自定义动画，可以重写控件模板，使用 `TransitioningContentControl` 或由 `:open`/`:closed` 伪类触发的关键帧动画。
