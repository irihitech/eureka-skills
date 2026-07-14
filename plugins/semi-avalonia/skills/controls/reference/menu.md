---
category: Components
title: Menu
subtitle: 菜单
description: 水平菜单栏，用于显示应用程序的顶层导航或命令菜单。
---

# Menu / 菜单

A horizontal menu bar control that hosts top-level `MenuItem` elements for application navigation and commands. `Menu` inherits from `MenuBase` and `ItemsControl`, supporting data binding, keyboard navigation (arrow keys, Alt activation), and accessibility. It is the standard container for File, Edit, View, Help-style menus.

水平菜单栏控件，承载顶层 `MenuItem` 元素，用于应用程序导航和命令。`Menu` 继承自 `MenuBase` 和 `ItemsControl`，支持数据绑定、键盘导航（方向键、Alt 激活）和无障碍功能。它是文件、编辑、视图、帮助式菜单的标准容器。

## When to Use / 何时使用

Use `Menu` when you need a persistent horizontal bar of top-level commands at the top of your application window. For right-click context actions, use `ContextMenu`. For a standalone dropdown list (without a menu bar), consider `ComboBox` or `DropDownButton`. `Menu` is ideal for desktop applications with multiple top-level categories.

当你需要在应用程序窗口顶部显示持久水平顶层命令栏时使用 `Menu`。对于右键上下文操作，请使用 `ContextMenu`。对于独立的下列列表（无需菜单栏），可考虑 `ComboBox` 或 `DropDownButton`。`Menu` 非常适合具有多个顶层类别的桌面应用程序。

## Basic Usage / 基本使用

```xml
<DockPanel>
    <Menu DockPanel.Dock="Top">
        <MenuItem Header="_File">
            <MenuItem Header="_New" Command="{Binding NewCommand}" 
                      HotKey="Ctrl+N" />
            <MenuItem Header="_Open" Command="{Binding OpenCommand}" 
                      HotKey="Ctrl+O" />
            <Separator />
            <MenuItem Header="E_xit" Command="{Binding ExitCommand}" 
                      HotKey="Alt+F4" />
        </MenuItem>
        <MenuItem Header="_Edit">
            <MenuItem Header="_Undo" Command="{Binding UndoCommand}" 
                      HotKey="Ctrl+Z" />
            <MenuItem Header="_Redo" Command="{Binding RedoCommand}" 
                      HotKey="Ctrl+Y" />
        </MenuItem>
        <MenuItem Header="_Help">
            <MenuItem Header="_About" Command="{Binding AboutCommand}" />
        </MenuItem>
    </Menu>
    <!-- Main content area -->
</DockPanel>
```

```csharp
// Programmatic creation
var menu = new Menu();
var fileMenu = new MenuItem { Header = "_File" };
fileMenu.ItemsSource = new[]
{
    new MenuItem { Header = "_New", Command = newCommand, HotKey = new KeyGesture(Key.N, KeyModifiers.Control) },
    new MenuItem { Header = "_Open", Command = openCommand },
    new Separator(),
    new MenuItem { Header = "E_xit", Command = exitCommand },
};
menu.ItemsSource = new[] { fileMenu };
```

## Common Scenarios / 常用场景

### Menu with Data Binding / 数据绑定菜单

Bind `ItemsSource` to a hierarchical ViewModel collection:

```xml
<Menu ItemsSource="{Binding MenuItems}" />
```

```csharp
public ObservableCollection<MenuItemViewModel> MenuItems { get; } = new()
{
    new MenuItemViewModel
    {
        Header = "_File",
        Children = new[]
        {
            new MenuItemViewModel { Header = "_New", Command = NewCommand },
            new MenuItemViewModel { Header = "_Open", Command = OpenCommand },
            new MenuItemViewModel { Header = "-" },
            new MenuItemViewModel { Header = "E_xit", Command = ExitCommand },
        }
    },
    new MenuItemViewModel
    {
        Header = "_Edit",
        Children = new[]
        {
            new MenuItemViewModel { Header = "_Undo", Command = UndoCommand },
        }
    },
};
```

### Styled Menu Bar / 带样式的菜单栏

Apply Semi.Avalonia theme for a consistent look:

```xml
<Menu Theme="{DynamicResource SemiMenu}"
      DockPanel.Dock="Top">
    <MenuItem Header="_File" Theme="{DynamicResource SemiMenuItem}">
        <MenuItem Header="_New" />
        <MenuItem Header="_Open" />
    </MenuItem>
</Menu>
```

### Menu with Icons and Shortcuts / 带图标和快捷键的菜单

Enhance menu items with icons and keyboard shortcut badges:

```xml
<Menu>
    <MenuItem Header="_File">
        <MenuItem Header="_New">
            <MenuItem.Icon>
                <PathIcon Data="{StaticResource NewIconGeometry}" />
            </MenuItem.Icon>
            <MenuItem.HotKey>
                <KeyGesture Key="N" Modifiers="Control" />
            </MenuItem.HotKey>
        </MenuItem>
    </MenuItem>
</Menu>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `ItemsSource` | `IEnumerable?` | Collection of top-level MenuItems. Inherited from `ItemsControl`. / 顶层 MenuItem 的集合。继承自 `ItemsControl`。 |
| `ItemTemplate` | `IDataTemplate?` | Template for generating menu items from data. Inherited from `ItemsControl`. / 从数据生成菜单项的模板。继承自 `ItemsControl`。 |
| `ItemContainerTheme` | `ControlTheme?` | Theme applied to each MenuItem container. / 应用于每个 MenuItem 容器的主题。 |
| `IsMainMenu` | `bool` | When `true`, Alt key activates the menu. Typically set on the primary window menu. / 设为 `true` 时，Alt 键激活菜单。通常在窗口主菜单上设置。 |
| `SelectedIndex` | `int` | Index of the currently selected item (-1 if none). / 当前选中项的索引（-1 表示无）。 |
| `SelectedItem` | `object?` | The currently selected item. / 当前选中的项。 |
| `Orientation` | `Orientation` | Layout direction: `Horizontal` (default) or `Vertical`. / 布局方向：`Horizontal`（默认）或 `Vertical`。 |

## Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `MenuOpened` | Raised when any sub-menu opens. / 任何子菜单打开时触发。 |
| `MenuClosed` | Raised when any sub-menu closes. / 任何子菜单关闭时触发。 |
| `SelectionChanged` | Raised when the selected item changes. / 选中项改变时触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides a styled `Menu` theme (`SemiMenu`) with background color, border, and consistent spacing that matches the Semi toolbar/header design language.

Semi.Avalonia 提供了带样式的 `Menu` 主题（`SemiMenu`），具有背景颜色、边框和一致的间距，与 Semi 工具栏/标题设计语言相匹配。

### Theme Application / 主题应用

```xml
<Menu Theme="{DynamicResource SemiMenu}" DockPanel.Dock="Top">
    <MenuItem Header="_File" Theme="{DynamicResource SemiMenuItem}">
        <!-- ... -->
    </MenuItem>
</Menu>
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:active` | The menu has keyboard focus. / 菜单具有键盘焦点。 |

### DynamicResource Keys / 动态资源键

```
SemiMenuBackground
SemiMenuBorderBrush
SemiMenuForeground
SemiMenuBorderThickness
SemiMenuPadding
SemiMenuItemHeight
SemiMenuItemHorizontalPadding
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_ItemsPresenter` | `ItemsPresenter` | Renders the collection of top-level `MenuItem` elements in a horizontal stack. / 以水平堆叠方式渲染顶层 `MenuItem` 元素集合。 |

## FAQ / 常见问题

**Q: How do I create a vertical sidebar menu instead of a horizontal menu bar? / 如何创建垂直侧边栏菜单而不是水平菜单栏？**

A: Set `Orientation="Vertical"` on the `Menu` control. This changes the layout to a vertical stack, suitable for sidebar navigation. Combine with `DockPanel.Dock="Left"` or place inside a `Grid` column for sidebar placement.

在 `Menu` 控件上设置 `Orientation="Vertical"`。这会将布局改为垂直堆叠，适用于侧边栏导航。配合 `DockPanel.Dock="Left"` 或放置在 `Grid` 列中实现侧边栏效果。

**Q: How do I enable keyboard navigation with the Alt key? / 如何通过 Alt 键启用键盘导航？**

A: Set `IsMainMenu="True"` on the `Menu` control. This enables Alt-key activation — pressing Alt highlights the first menu item, and arrow keys navigate between items. Underscore prefixes (`_File`) define access keys (Alt+F opens the File menu).

在 `Menu` 控件上设置 `IsMainMenu="True"`。这将启用 Alt 键激活 —— 按 Alt 高亮第一个菜单项，方向键在项目间导航。下划线前缀（`_File`）定义访问键（Alt+F 打开文件菜单）。

**Q: Can I mix MenuItem with other controls inside a Menu? / 可以在 Menu 中混合 MenuItem 和其他控件吗？**

A: `Menu` is designed for `MenuItem` children. While you can technically add other controls, they won't integrate with the menu's selection and keyboard navigation system. For a toolbar with mixed controls (buttons, search boxes, etc.), use `ToolBar` or a custom `StackPanel` instead.

`Menu` 专为 `MenuItem` 子项设计。虽然技术上可以添加其他控件，但它们不会与菜单的选择和键盘导航系统集成。对于混合控件（按钮、搜索框等）的工具栏，请改用 `ToolBar` 或自定义 `StackPanel`。
