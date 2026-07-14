---
category: Components
title: DropDownButton
subtitle: 下拉按钮
description: 下拉按钮点击时展开一个浮层，提供上下文操作菜单。
---

## DropDownButton / 下拉按钮

A button that, when clicked, opens an associated `Flyout` (typically a `MenuFlyout`) for displaying contextual actions. Unlike a regular `Button` with a flyout, the dropdown arrow visual indicator makes the flyout affordance explicit. Inherits from `Button`.

点击时打开关联 `Flyout`（通常为 `MenuFlyout`）以显示上下文操作的按钮。与带有浮层的普通 `Button` 不同，下拉箭头视觉指示器使浮层交互明确可见。继承自 `Button`。

## When to Use / 何时使用

Use `DropDownButton` when you need a button that reveals a menu of related actions — "Export" with PDF/Excel/CSV options, "Add" with sub-item types, or "Share" with destination options. The dropdown arrow signals to users that more options are available. For a single primary action with an optional secondary dropdown area, use `SplitButton` instead. For a standalone button with a flyout (no arrow), use `Button.Flyout`.

当你需要一个揭示相关操作菜单的按钮时使用 `DropDownButton` —— 如带 PDF/Excel/CSV 选项的"导出"按钮、带子项类型的"添加"按钮或带目标选项的"分享"按钮。下拉箭头向用户提示有更多选项可用。对于带有单个主要操作和可选次要下拉区域的按钮，请使用 `SplitButton`。对于带浮层但没有箭头的独立按钮，使用 `Button.Flyout`。

## Basic Usage / 基本使用

```xml
<DropDownButton Content="Export">
    <DropDownButton.Flyout>
        <MenuFlyout>
            <MenuItem Header="Export as PDF"
                      Command="{Binding ExportPdfCommand}" />
            <MenuItem Header="Export as Excel"
                      Command="{Binding ExportExcelCommand}" />
            <Separator />
            <MenuItem Header="Export as CSV"
                      Command="{Binding ExportCsvCommand}" />
        </MenuFlyout>
    </DropDownButton.Flyout>
</DropDownButton>
```

```csharp
// Programmatic creation
var dropDown = new DropDownButton
{
    Content = "Actions"
};
dropDown.Flyout = new MenuFlyout
{
    Items =
    {
        new MenuItem { Header = "Edit",   Command = EditCommand },
        new MenuItem { Header = "Delete", Command = DeleteCommand },
        new MenuItem { Header = "Archive", Command = ArchiveCommand }
    }
};
```

## Common Scenarios / 常用场景

### Command Menu / 命令菜单

Group related commands under a single dropdown for toolbar or ribbon UIs.

```xml
<DropDownButton Content="New" Classes="Primary"
                Theme="{DynamicResource SolidButton}">
    <DropDownButton.Flyout>
        <MenuFlyout>
            <MenuItem Header="New File"       InputGesture="Ctrl+N" />
            <MenuItem Header="New Folder"     InputGesture="Ctrl+Shift+N" />
            <MenuItem Header="New Window"     InputGesture="Ctrl+Shift+W" />
        </MenuFlyout>
    </DropDownButton.Flyout>
</DropDownButton>
```

### Data-Bound Menu Items / 数据绑定菜单项

Dynamically populate menu items from a collection.

```xml
<DropDownButton Content="Share"
                Classes="Secondary">
    <DropDownButton.Flyout>
        <MenuFlyout ItemsSource="{Binding ShareTargets}">
            <MenuFlyout.ItemTemplate>
                <DataTemplate>
                    <MenuItem Header="{Binding Name}"
                              Command="{Binding ShareCommand}"
                              CommandParameter="{Binding}" />
                </DataTemplate>
            </MenuFlyout.ItemTemplate>
        </MenuFlyout>
    </DropDownButton.Flyout>
</DropDownButton>
```

### Open/Close State Handling / 打开关闭状态处理

React to the flyout opening and closing using the `:flyout-open` pseudo-class or events.

```xml
<DropDownButton x:Name="OptionsBtn"
                Content="Options">
    <DropDownButton.Flyout>
        <MenuFlyout Opened="OnFlyoutOpened"
                    Closed="OnFlyoutClosed">
            <MenuItem Header="Settings" />
            <MenuItem Header="Help" />
        </MenuFlyout>
    </DropDownButton.Flyout>
</DropDownButton>
```

```csharp
private void OnFlyoutOpened(object? sender, EventArgs e)
{
    // Refresh dynamic menu items when flyout opens
    RefreshMenuItems();
}
```

### Inline Positioning / 内联定位

Control flyout placement with `Placement` to anchor below, above, or aligned to the button edge.

```xml
<DropDownButton Content="Align Bottom">
    <DropDownButton.Flyout>
        <MenuFlyout Placement="BottomEdgeAlignedLeft">
            <MenuItem Header="Item 1" />
            <MenuItem Header="Item 2" />
        </MenuFlyout>
    </DropDownButton.Flyout>
</DropDownButton>
```

## Property Reference / 属性参考

DropDownButton inherits all properties from `Button`. Key properties:

DropDownButton 继承 `Button` 的所有属性。关键属性：

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Content` | `object` | Inherited from `ContentControl`. The button label text or content. / 继承自 `ContentControl`。按钮标签文本或内容。 |
| `Flyout` | `FlyoutBase?` | Inherited from `Button`. The flyout displayed when the button is clicked. Opens automatically on click. / 继承自 `Button`。点击按钮时显示的浮层。点击时自动打开。 |
| `Command` | `ICommand?` | Inherited from `Button`. Invoked on button click (before the flyout opens). / 继承自 `Button`。点击按钮时调用（在浮层打开之前）。 |
| `CommandParameter` | `object?` | Inherited from `Button`. Parameter passed to the command. / 继承自 `Button`。传递给命令的参数。 |
| `ClickMode` | `ClickMode` | Inherited from `Button`. When to fire `Click`: `Release` (default) or `Press`. / 继承自 `Button`。`Click` 触发时机：`Release`（默认）或 `Press`。 |
| `IsPressed` | `bool` | Inherited from `Button`. (Read-only) Whether the button is currently pressed. / 继承自 `Button`。（只读）按钮当前是否被按下。 |
| `HotKey` | `KeyGesture?` | Inherited from `Button`. Keyboard shortcut to activate the dropdown. / 继承自 `Button`。激活下拉菜单的键盘快捷键。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Click` | Inherited from `Button`. Raised when the button is clicked. The flyout opens automatically after this event. / 继承自 `Button`。点击按钮时触发。浮层在此事件后自动打开。 |
| `IsPressedChanged` | Inherited from `Button`. Raised when the pressed state changes. / 继承自 `Button`。按下状态改变时触发。 |

Flyout events are accessed via `DropDownButton.Flyout`:

浮层事件通过 `DropDownButton.Flyout` 访问：

| Flyout Event / 浮层事件 | Description / 说明 |
| --- | --- |
| `Flyout.Opened` | Raised when the dropdown menu opens. / 下拉菜单打开时触发。 |
| `Flyout.Closed` | Raised when the dropdown menu closes. / 下拉菜单关闭时触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia styles `DropDownButton` with a dropdown arrow glyph appended to the content area. All `Button` themes (Light, Solid, Outline, Borderless), color classes, and size classes apply to `DropDownButton`.

Semi.Avalonia 为 `DropDownButton` 在内容区域附加了一个下拉箭头字形。所有 `Button` 主题（Light、Solid、Outline、Borderless）、颜色类和尺寸类均适用于 `DropDownButton`。

### Theme Variants / 主题变体

```xml
<DropDownButton Content="Solid Dropdown"
                Theme="{DynamicResource SolidButton}">
    <DropDownButton.Flyout>...</DropDownButton.Flyout>
</DropDownButton>

<DropDownButton Content="Outline Dropdown"
                Theme="{DynamicResource OutlineButton}">
    <DropDownButton.Flyout>...</DropDownButton.Flyout>
</DropDownButton>
```

### Color Classes / 颜色类

Same six colors as `Button`: Primary (default), Secondary, Tertiary, Success, Warning, Danger.

与 `Button` 相同的六种颜色：Primary（默认）、Secondary、Tertiary、Success、Warning、Danger。

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:pointerover` | Mouse is hovering over the button. / 鼠标悬停。 |
| `:pressed` | Button is being pressed. / 正在被按下。 |
| `:flyout-open` | The attached flyout is currently open. The dropdown arrow may rotate or change color. / 浮层已打开。下拉箭头可能旋转或变色。 |
| `:disabled` | Button is disabled (`IsEnabled = false`). / 已禁用。 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the `Content` property (button label). / 渲染 `Content` 属性（按钮标签）。 |
| `PART_DropDownGlyph` | `PathIcon` or `Panel` | The dropdown arrow indicator. Semi.Avalonia themes style this part for open/close transitions. / 下拉箭头指示器。Semi.Avalonia 主题为此部件设置打开/关闭过渡样式。 |

## FAQ / 常见问题

**Q: When should I use DropDownButton vs. SplitButton? / 何时使用 DropDownButton 而非 SplitButton？**

A: Use `DropDownButton` when the entire button click opens the menu — clicking anywhere on the button shows the flyout. Use `SplitButton` when there is a primary action (click = execute) plus a secondary dropdown arrow for related actions. `DropDownButton` has one click target; `SplitButton` has two distinct click targets (action area vs. arrow).

当整个按钮点击都打开菜单时使用 `DropDownButton` —— 点击按钮任意位置都显示浮层。当有主要操作（点击即执行）和次要下拉箭头用于相关操作时使用 `SplitButton`。`DropDownButton` 只有一个点击目标；`SplitButton` 有两个独立的点击目标（操作区域和箭头）。

**Q: Can DropDownButton have a default menu item that triggers on Enter? / DropDownButton 可以有按 Enter 触发的默认菜单项吗？**

A: `DropDownButton` itself does not select a default menu item. However, you can set `IsDefault="True"` on the `DropDownButton` to respond to Enter like any `Button` — this will open the flyout. To have a specific menu item respond to a keyboard shortcut, set `InputGesture` on the `MenuItem` (e.g., `InputGesture="Ctrl+Enter"`).

`DropDownButton` 本身不会选择默认菜单项。但可以在 `DropDownButton` 上设置 `IsDefault="True"` 使其像普通 `Button` 一样响应 Enter 键 —— 这会打开浮层。要让特定菜单项响应键盘快捷键，请在 `MenuItem` 上设置 `InputGesture`（如 `InputGesture="Ctrl+Enter"`）。

**Q: How do I dynamically enable/disable menu items? / 如何动态启用/禁用菜单项？**

A: Bind each `MenuItem.Command` to an `ICommand` with `CanExecute` logic. The menu item's `IsEnabled` automatically reflects `CanExecute`. For items without commands, bind `MenuItem.IsEnabled` to a view-model property or use a value converter. Refresh `CanExecute` by calling `CommandManager.InvalidateRequerySuggested()` or implementing `INotifyPropertyChanged` on the relevant property.

将每个 `MenuItem.Command` 绑定到具有 `CanExecute` 逻辑的 `ICommand`。菜单项的 `IsEnabled` 会自动反映 `CanExecute`。对于没有命令的项，将 `MenuItem.IsEnabled` 绑定到视图模型属性或使用值转换器。通过调用 `CommandManager.InvalidateRequerySuggested()` 或对相关属性实现 `INotifyPropertyChanged` 来刷新 `CanExecute`。
