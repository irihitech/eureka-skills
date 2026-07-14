---
category: Components
title: ContextMenu
subtitle: 上下文菜单
description: 右键点击时显示的弹出式菜单，用于提供与当前上下文相关的操作选项。
---

# ContextMenu / 上下文菜单

A popup menu that appears on right-click (or long-press) to provide context-sensitive actions. `ContextMenu` is an attached property on `Control` that hosts a `NativeMenu` or a list of `MenuItem` / `Separator` elements. It inherits from `MenuBase` and integrates with Avalonia's focus and input systems.

右键点击（或长按）时弹出的菜单，用于提供与当前上下文相关的操作选项。`ContextMenu` 是 `Control` 上的附加属性，承载 `NativeMenu` 或 `MenuItem` / `Separator` 元素列表。它继承自 `MenuBase`，与 Avalonia 的焦点和输入系统集成。

## When to Use / 何时使用

Use `ContextMenu` when you need to present a set of actions that depend on the specific element the user right-clicked — such as cut/copy/paste for a text box, file operations in a file manager, or row actions in a data grid. Avoid overloading the context menu with too many items; group related actions with `Separator` and keep the menu depth shallow (prefer one level of nesting).

当你需要根据用户右键点击的特定元素提供一组操作时使用 `ContextMenu` —— 例如文本框的剪切/复制/粘贴、文件管理器中的文件操作、数据网格中的行操作。避免在上下文中塞入过多项目；使用 `Separator` 对相关操作进行分组，并保持菜单深度较浅（建议仅一层嵌套）。

## Basic Usage / 基本使用

```xml
<TextBox Text="Right-click me">
    <TextBox.ContextMenu>
        <ContextMenu>
            <MenuItem Header="Cut" Command="{Binding CutCommand}" />
            <MenuItem Header="Copy" Command="{Binding CopyCommand}" />
            <MenuItem Header="Paste" Command="{Binding PasteCommand}" />
            <Separator />
            <MenuItem Header="Select All" Command="{Binding SelectAllCommand}" />
        </ContextMenu>
    </TextBox.ContextMenu>
</TextBox>
```

```csharp
// Programmatic creation
var textBox = new TextBox();
textBox.ContextMenu = new ContextMenu
{
    ItemsSource = new[]
    {
        new MenuItem { Header = "Cut" },
        new MenuItem { Header = "Copy" },
        new MenuItem { Header = "-" },  // separator
        new MenuItem { Header = "Paste" },
    }
};
```

## Common Scenarios / 常用场景

### Context Menu on Data Grid Row / 数据网格行上下文菜单

Provide row-level actions like edit, delete, or view details when the user right-clicks a data row.

```xml
<DataGrid ItemsSource="{Binding Items}">
    <DataGrid.ContextMenu>
        <ContextMenu>
            <MenuItem Header="Edit" Command="{Binding EditCommand}" />
            <MenuItem Header="Delete" Command="{Binding DeleteCommand}" 
                      Classes="Danger" />
            <Separator />
            <MenuItem Header="Refresh" Command="{Binding RefreshCommand}" />
        </ContextMenu>
    </DataGrid.ContextMenu>
</DataGrid>
```

### Dynamic Context Menu via ItemsSource / 通过 ItemsSource 动态生成

Bind `ItemsSource` to a collection in your ViewModel for dynamic menu items.

```xml
<Border ContextMenu="{DynamicResource SemiContextMenu}">
    <Border.ContextMenu>
        <ContextMenu ItemsSource="{Binding MenuItems}" />
    </Border.ContextMenu>
</Border>
```

```csharp
public ObservableCollection<MenuItem> MenuItems { get; } = new()
{
    new MenuItem { Header = "Option 1", Command = ... },
    new MenuItem { Header = "Option 2", Command = ... },
};
```

### ContextMenu with Opening/Closing Events / 带打开/关闭事件的上下文菜单

Use `ContextMenuOpening` and `ContextMenuClosing` events to dynamically populate or validate the menu before it appears.

```xml
<Border ContextMenuOpening="OnContextMenuOpening"
        ContextMenuClosing="OnContextMenuClosing">
    <Border.ContextMenu>
        <ContextMenu x:Name="MyContextMenu" />
    </Border.ContextMenu>
</Border>
```

```csharp
private void OnContextMenuOpening(object? sender, CancelEventArgs e)
{
    // Dynamically populate menu items based on context
    MyContextMenu.ItemsSource = GetDynamicMenuItems();
}
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `ItemsSource` | `IEnumerable?` | Collection of items to display in the menu. Supports binding to dynamic lists. Inherited from `ItemsControl`. / 菜单中显示的项集合。支持绑定到动态列表。继承自 `ItemsControl`。 |
| `ItemTemplate` | `IDataTemplate?` | Template used to render each item. Inherited from `ItemsControl`. / 用于渲染每个项的模板。继承自 `ItemsControl`。 |
| `HorizontalScrollBarVisibility` | `ScrollBarVisibility` | Horizontal scrollbar visibility. Default is `Hidden`. / 水平滚动条可见性。默认为 `Hidden`。 |
| `VerticalScrollBarVisibility` | `ScrollBarVisibility` | Vertical scrollbar visibility. Default is `Auto`. / 垂直滚动条可见性。默认为 `Auto`。 |
| `Placement` | `PlacementMode` | Where the menu appears relative to the target: `Pointer`, `Bottom`, `Right`, `Top`, `Left`, `Center`, `AnchorAndGravity`, `Custom`. / 菜单相对于目标出现的位置。 |
| `PlacementTarget` | `Control?` | The control the menu positions relative to. Defaults to the control that opened the menu. / 菜单定位所相对的控件。默认为打开菜单的控件。 |
| `IsOpen` | `bool` | Whether the context menu is currently open (read-only). / 上下文菜单当前是否打开（只读）。 |
| `HorizontalOffset` | `double` | Horizontal offset from the placement position. / 相对于放置位置的水平偏移。 |
| `VerticalOffset` | `double` | Vertical offset from the placement position. / 相对于放置位置的垂直偏移。 |
| `WindowManagerAddShadowHint` | `bool` | Whether to add a drop shadow (platform-dependent). / 是否添加投影（取决于平台）。 |

## Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Opened` | Raised when the context menu opens. / 上下文菜单打开时触发。 |
| `Closed` | Raised when the context menu closes. / 上下文菜单关闭时触发。 |
| `MenuOpened` | Static attached event on `Control`; fired when any context menu opens. / `Control` 上的静态附加事件；任何上下文菜单打开时触发。 |
| `MenuClosed` | Static attached event on `Control`; fired when any context menu closes. / `Control` 上的静态附加事件；任何上下文菜单关闭时触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides a styled `ContextMenu` theme (`SemiContextMenu`) with rounded corners, Semi color palette, and consistent padding. Context menus in Semi follow the popup/overlay design language.

Semi.Avalonia 提供了带样式的 `ContextMenu` 主题（`SemiContextMenu`），具有圆角、Semi 调色板和一致的内边距。Semi 中的上下文菜单遵循弹出/覆盖设计语言。

### Theme Application / 主题应用

```xml
<Border>
    <Border.ContextMenu>
        <ContextMenu Theme="{DynamicResource SemiContextMenu}">
            <MenuItem Header="Action 1" />
            <MenuItem Header="Action 2" />
        </ContextMenu>
    </Border.ContextMenu>
</Border>
```

### Pseudo-classes / 伪类

Semi.Avalonia styles the following pseudo-classes on `ContextMenu`:

Semi.Avalonia 为 `ContextMenu` 设置了以下伪类样式：

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:open` | The context menu is currently visible. / 上下文菜单当前可见。 |

### DynamicResource Keys / 动态资源键

Context menus use the Semi overlay/popup resource keys:

```
SemiContextMenuBackground
SemiContextMenuBorderBrush
SemiContextMenuForeground
SemiContextMenuBorderThickness
SemiContextMenuCornerRadius
SemiContextMenuPadding
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Popup` | `Popup` | The popup host that manages positioning and overlay behavior. / 管理定位和覆盖行为的弹出主机。 |
| `PART_ItemsPresenter` | `ItemsPresenter` | Renders the collection of `MenuItem` elements. / 渲染 `MenuItem` 元素集合。 |
| `PART_ScrollViewer` | `ScrollViewer` | Provides scrolling when the menu exceeds available space. / 当菜单超出可用空间时提供滚动。 |

## FAQ / 常见问题

**Q: How do I disable the default context menu on a control? / 如何禁用控件上的默认上下文菜单？**

A: Set `ContextMenu` to `null` or handle the `ContextRequested` event and set `e.Handled = true`. For controls like `TextBox` that have a built-in context menu, you can override it by setting a custom empty ContextMenu or handling the event.

将 `ContextMenu` 设置为 `null`，或处理 `ContextRequested` 事件并设置 `e.Handled = true`。对于 `TextBox` 等具有内置上下文菜单的控件，可以通过设置自定义空 ContextMenu 或处理事件来覆盖。

**Q: How do I style individual MenuItems inside a ContextMenu? / 如何为 ContextMenu 中的单个 MenuItem 设置样式？**

A: Use Semi.Avalonia's `MenuItem` themes. Each `MenuItem` inside a `ContextMenu` can receive its own `Theme` (e.g., `SemiMenuItem`, `DangerMenuItem`) and `Classes` (e.g., `Danger`, `Warning`). The context menu is just a container; menu item styling is inherited from the `MenuItem` control.

使用 Semi.Avalonia 的 `MenuItem` 主题。`ContextMenu` 中的每个 `MenuItem` 都可以有自己的 `Theme`（如 `SemiMenuItem`、`DangerMenuItem`）和 `Classes`（如 `Danger`、`Warning`）。上下文菜单只是一个容器；菜单项的样式继承自 `MenuItem` 控件。

**Q: Can I nest sub-menus in a ContextMenu? / 可以在 ContextMenu 中嵌套子菜单吗？**

A: Yes. Add a `MenuItem` as a child and set its `Items` or `ItemsSource` to populate the sub-menu. Avalonia supports one level of nesting by default. Deep nesting is discouraged for usability.

可以。添加一个 `MenuItem` 作为子项，并设置其 `Items` 或 `ItemsSource` 来填充子菜单。Avalonia 默认支持一层嵌套。出于可用性考虑，不建议深层嵌套。
