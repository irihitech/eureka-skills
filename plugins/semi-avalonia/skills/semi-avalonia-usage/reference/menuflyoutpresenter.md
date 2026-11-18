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
            <MenuItem Header="Delete" Command="{Binding DeleteCommand}" />
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

Semi.Avalonia themes `MenuFlyoutPresenter` and `MenuItem` automatically — no explicit
`Theme` is needed. The theme keys Semi defines for them are listed in the `semi-avalonia`
skill:

```xml
<Button Content="Actions">
    <Button.Flyout>
        <MenuFlyout>
            <MenuItem Header="Copy" />
            <MenuItem Header="Paste" />
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
                    <PathIcon Data="{StaticResource NewFileIconGeometry}" />
                </MenuItem.Icon>
            </MenuItem>
            <MenuItem Header="Open Folder" HotKey="Ctrl+O">
                <MenuItem.Icon>
                    <PathIcon Data="{StaticResource OpenFolderIconGeometry}" />
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

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


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
