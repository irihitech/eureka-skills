---
category: Components
title: MenuFlyoutPresenter
subtitle: 菜单浮层呈现器
description: 用于呈现 MenuFlyout 弹出菜单内容的容器控件，提供垂直菜单布局和 Semi 主题样式。
---

# MenuFlyoutPresenter / 菜单浮层呈现器

A popup container that hosts and renders the `MenuItem` elements of a `MenuFlyout`. `MenuFlyoutPresenter` inherits from `MenuBase` and provides the visual template for the vertical dropdown menu that appears when a `MenuFlyout` is shown. Like `FlyoutPresenter`, it is created automatically by the flyout infrastructure.

用于承载和渲染 `MenuFlyout` 的 `MenuItem` 元素的弹出容器。`MenuFlyoutPresenter` 继承自 `MenuBase`，为 `MenuFlyout` 显示时出现的垂直下拉菜单提供可视化模板。与 `FlyoutPresenter` 一样，它由浮层基础设施自动创建。

## When to Use / 何时使用

`MenuFlyoutPresenter` is an internal control — you do not create it directly. Use `MenuFlyout` and attach it to a button or control via `Button.Flyout` or `FlyoutBase.ShowAttachedFlyout()`. The `MenuFlyoutPresenter` is the templated container that the framework creates. Customize its appearance through `MenuFlyout.Placement`, `MenuFlyout.FlyoutPresenterTheme`, or global styles targeting `MenuFlyoutPresenter`.

`MenuFlyoutPresenter` 是一个内部控件 —— 你不直接创建它。使用 `MenuFlyout` 并通过 `Button.Flyout` 或 `FlyoutBase.ShowAttachedFlyout()` 将其附加到按钮或控件。`MenuFlyoutPresenter` 是框架创建的模板化容器。通过 `MenuFlyout.Placement`、`MenuFlyout.FlyoutPresenterTheme` 或针对 `MenuFlyoutPresenter` 的全局样式自定义其外观。

## Basic Usage / 基本使用

`MenuFlyoutPresenter` is created implicitly. Here's how you use `MenuFlyout` (the user-facing API):

```xml
<Button Content="More Options">
    <Button.Flyout>
        <MenuFlyout>
            <MenuItem Header="Edit" Command="{Binding EditCommand}" />
            <MenuItem Header="Duplicate" Command="{Binding DuplicateCommand}" />
            <Separator />
            <MenuItem Header="Delete" Command="{Binding DeleteCommand}" 
                      Classes="Danger" />
        </MenuFlyout>
    </Button.Flyout>
</Button>
```

```csharp
// The framework creates MenuFlyoutPresenter internally
var button = new Button { Content = "More Options" };
button.Flyout = new MenuFlyout
{
    Items =
    {
        new MenuItem { Header = "Edit", Command = editCommand },
        new MenuItem { Header = "Delete", Command = deleteCommand },
    }
};
```

## Common Scenarios / 常用场景

### Styled MenuFlyoutPresenter / 带样式的菜单浮层

Apply a Semi theme to the flyout presenter:

```xml
<Button Content="Actions">
    <Button.Flyout>
        <MenuFlyout FlyoutPresenterTheme="{DynamicResource SemiMenuFlyoutPresenter}">
            <MenuItem Header="Copy" Theme="{DynamicResource SemiMenuItem}" />
            <MenuItem Header="Paste" Theme="{DynamicResource SemiMenuItem}" />
        </MenuFlyout>
    </Button.Flyout>
</Button>
```

### MenuFlyout with Icons and HotKeys / 带图标和热键的菜单浮层

```xml
<Button Content="File">
    <Button.Flyout>
        <MenuFlyout>
            <MenuItem Header="New File" HotKey="Ctrl+N">
                <MenuItem.Icon>
                    <PathIcon Data="{StaticResource NewFileIcon}" />
                </MenuItem.Icon>
            </MenuItem>
            <MenuItem Header="Open Folder" HotKey="Ctrl+O">
                <MenuItem.Icon>
                    <PathIcon Data="{StaticResource OpenFolderIcon}" />
                </MenuItem.Icon>
            </MenuItem>
        </MenuFlyout>
    </Button.Flyout>
</Button>
```

### Dynamic MenuFlyout via ItemsSource / 通过 ItemsSource 动态生成

```xml
<Button Content="Dynamic">
    <Button.Flyout>
        <MenuFlyout ItemsSource="{Binding DynamicMenuItems}" />
    </Button.Flyout>
</Button>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `ItemsSource` | `IEnumerable?` | Collection of MenuItems. Inherited from `ItemsControl`. / MenuItem 的集合。继承自 `ItemsControl`。 |
| `ItemTemplate` | `IDataTemplate?` | Template for generating items. Inherited from `ItemsControl`. / 生成项的模板。继承自 `ItemsControl`。 |
| `ItemContainerTheme` | `ControlTheme?` | Theme applied to each MenuItem container. / 应用于每个 MenuItem 容器的主题。 |
| `HorizontalScrollBarVisibility` | `ScrollBarVisibility` | Horizontal scrollbar visibility. / 水平滚动条可见性。 |
| `VerticalScrollBarVisibility` | `ScrollBarVisibility` | Vertical scrollbar visibility. Default is `Auto`. / 垂直滚动条可见性。默认 `Auto`。 |
| `CornerRadius` | `CornerRadius` | Rounded corner radius for the popup. / 弹出窗口的圆角半径。 |
| `MaxHeight` | `double` | Maximum height; content scrolls if exceeded. / 最大高度；超出时内容可滚动。 |
| `IsOpen` | `bool` | Whether the menu flyout is currently open. / 菜单浮层当前是否打开。 |

## Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Opened` | Raised when the menu flyout opens. / 菜单浮层打开时触发。 |
| `Closed` | Raised when the menu flyout closes. / 菜单浮层关闭时触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides a styled `MenuFlyoutPresenter` theme (`SemiMenuFlyoutPresenter`) with rounded corners, Semi color palette, elevated drop shadow, and consistent padding. Menu items inside inherit `SemiMenuItem` styling.

Semi.Avalonia 提供了带样式的 `MenuFlyoutPresenter` 主题（`SemiMenuFlyoutPresenter`），具有圆角、Semi 调色板、提升投影和一致的内边距。内部的菜单项继承 `SemiMenuItem` 样式。

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:open` | The menu flyout is currently visible. / 菜单浮层当前可见。 |

### DynamicResource Keys / 动态资源键

```
SemiMenuFlyoutPresenterBackground
SemiMenuFlyoutPresenterBorderBrush
SemiMenuFlyoutPresenterForeground
SemiMenuFlyoutPresenterBorderThickness
SemiMenuFlyoutPresenterCornerRadius
SemiMenuFlyoutPresenterPadding
SemiMenuFlyoutPresenterShadowElevation
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Popup` | `Popup` | The popup host for overlay positioning. / 覆盖层定位的弹出主机。 |
| `PART_ItemsPresenter` | `ItemsPresenter` | Renders the `MenuItem` collection vertically. / 垂直渲染 `MenuItem` 集合。 |
| `PART_ScrollViewer` | `ScrollViewer` | Scroll viewer for overflow content. / 用于溢出内容的滚动查看器。 |

### Semi.Avalonia ControlThemes / Semi.Avalonia 控件主题

Semi.Avalonia provides the `HorizontalMenuFlyoutPresenter` ControlTheme as a horizontal variant of the default vertical `MenuFlyoutPresenter`. Items are laid out in a horizontal `StackPanel` with zero padding, suitable for toolbar overflow menus, horizontal action bars, or icon-strip menus.

Semi.Avalonia 提供了 `HorizontalMenuFlyoutPresenter` ControlTheme 作为默认垂直 `MenuFlyoutPresenter` 的水平变体。项目以水平 `StackPanel` 布局，内边距为零，适用于工具栏溢出菜单、水平操作栏或图标条菜单。

| Theme / 主题 | Resource Key / 资源键 | Description / 说明 |
| --- | --- | --- |
| **HorizontalMenuFlyoutPresenter** | `HorizontalMenuFlyoutPresenter` | Horizontal menu flyout with `StackPanel Orientation="Horizontal"` items panel and zero padding. Based on the default `MenuFlyoutPresenter` theme. / 水平菜单浮层，使用 `StackPanel Orientation="Horizontal"` 项目面板，内边距为零。基于默认 `MenuFlyoutPresenter` 主题。 |

```xml
<!-- Default: vertical menu flyout -->
<Button Content="Actions">
    <Button.Flyout>
        <MenuFlyout>
            <MenuItem Header="Edit" />
            <MenuItem Header="Delete" />
        </MenuFlyout>
    </Button.Flyout>
</Button>

<!-- Horizontal: items laid out side by side -->
<Button Content="Tools">
    <Button.Flyout>
        <MenuFlyout FlyoutPresenterTheme="{StaticResource HorizontalMenuFlyoutPresenter}">
            <MenuItem Header="Cut" />
            <MenuItem Header="Copy" />
            <MenuItem Header="Paste" />
        </MenuFlyout>
    </Button.Flyout>
</Button>
```

## FAQ / 常见问题

**Q: How does MenuFlyoutPresenter differ from plain FlyoutPresenter? / MenuFlyoutPresenter 与普通 FlyoutPresenter 有何不同？**

A: `MenuFlyoutPresenter` is optimized for menu-style content — it renders `MenuItem` elements in a vertical list with built-in scrolling, keyboard navigation, and selection tracking. `FlyoutPresenter` is a general-purpose container that hosts arbitrary content. Use `MenuFlyout` + `MenuFlyoutPresenter` when you have a list of commands; use `Flyout` + `FlyoutPresenter` when you have free-form content like forms or info panels.

`MenuFlyoutPresenter` 为菜单式内容优化 —— 它以垂直列表形式渲染 `MenuItem` 元素，具有内置滚动、键盘导航和选择跟踪功能。`FlyoutPresenter` 是承载任意内容的通用容器。当你有命令列表时使用 `MenuFlyout` + `MenuFlyoutPresenter`；当你有自由格式内容（如表单或信息面板）时使用 `Flyout` + `FlyoutPresenter`。

**Q: How do I add a separator between MenuFlyout items? / 如何在 MenuFlyout 项之间添加分隔符？**

A: Add a `<Separator />` element between `MenuItem` elements. In code-behind, use `new Separator()`. You can also use `"-"` as a header string which some templates interpret as a separator.

在 `MenuItem` 元素之间添加 `<Separator />` 元素。在代码后台中使用 `new Separator()`。也可以使用 `"-"` 作为标题字符串，某些模板会将其解释为分隔符。

**Q: Can I change the menu flyout's placement relative to the target? / 可以改变菜单浮层相对于目标的位置吗？**

A: Yes. Use `MenuFlyout.Placement` to control positioning: `Bottom` (default), `Top`, `RightEdgeAlignedTop`, `BottomEdgeAlignedLeft`, etc. Combine with `HorizontalOffset` and `VerticalOffset` for fine-tuning.

可以。使用 `MenuFlyout.Placement` 控制定位：`Bottom`（默认）、`Top`、`RightEdgeAlignedTop`、`BottomEdgeAlignedLeft` 等。结合 `HorizontalOffset` 和 `VerticalOffset` 进行微调。
