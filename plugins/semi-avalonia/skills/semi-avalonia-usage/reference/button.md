---
category: Components
title: Button
subtitle: 按钮
description: 按钮用于开始一个即时操作。
---

## Button / 按钮

A standard button control that responds to user click, tap, or keyboard interactions to trigger an immediate action. Inherits from `ContentControl` and implements `ICommandSource` and `IClickableControl`.

标准按钮控件，响应用户的点击、触摸或键盘交互以触发即时操作。继承自 `ContentControl`，实现了 `ICommandSource` 和 `IClickableControl`。

## When to Use / 何时使用

Use `Button` when you need a clickable element that triggers a single, immediate action — such as submitting a form, opening a dialog, navigating to another view, or executing a command. `Button` is the primary control for user-initiated actions in dialogs, toolbars, and data-entry forms. For repeated actions while pressed (e.g. spin buttons, media controls), consider `RepeatButton` instead. For toggle-style on/off states, use `ToggleButton`.

当你需要一个可点击元素来触发单次即时操作时使用 `Button` —— 例如提交表单、打开对话框、导航到另一个视图或执行命令。`Button` 是对话框、工具栏和数据录入表单中用户发起操作的主要控件。对于按住时需要重复触发的操作（如微调按钮、媒体控件），请考虑使用 `RepeatButton`。对于开关式的开/关状态，请使用 `ToggleButton`。

## Basic Usage / 基本使用

```xml
<Button Content="Click Me"
        Click="OnButtonClick" />
```

```csharp
// Code-behind
private void OnButtonClick(object? sender, RoutedEventArgs e)
{
    // Handle the click
}
```

```csharp
// Programmatic creation
var button = new Button
{
    Content = "Click Me"
};
button.Click += (s, e) => { /* handle click */ };
```

## Common Scenarios / 常用场景

### Command Binding / 命令绑定

Bind `Button` to an `ICommand` in your ViewModel for MVVM patterns. `CanExecute` automatically controls `IsEnabled`.

```xml
<Button Content="Save"
        Command="{Binding SaveCommand}"
        CommandParameter="{Binding SelectedItem}" />
```

```csharp
public ICommand SaveCommand { get; }

public MyViewModel()
{
    SaveCommand = new RelayCommand<object>(OnSave, CanSave);
}

private bool CanSave(object? parameter) => /* validation */;
private void OnSave(object? parameter) { /* save logic */ }
```

### IsDefault & IsCancel / 默认按钮与取消按钮

Set `IsDefault` to respond to Enter key; `IsCancel` to respond to Escape key. Commonly used in dialogs with OK/Cancel patterns.

```xml
<StackPanel Spacing="8">
    <TextBox PlaceholderText="Enter your name" />
    <StackPanel Orientation="Horizontal" HorizontalAlignment="Right" Spacing="8">
        <Button Content="OK"
                IsDefault="True"
                Command="{Binding OkCommand}" />
        <Button Content="Cancel"
                IsCancel="True"
                Command="{Binding CancelCommand}" />
    </StackPanel>
</StackPanel>
```

### Button with Flyout / 带浮层的按钮

Attach a `Flyout` to show contextual menus or additional options. Supports `:flyout-open` pseudo-class for styling.

```xml
<Button Content="Options">
    <Button.Flyout>
        <MenuFlyout>
            <MenuItem Header="Save" Command="{Binding SaveCommand}" />
            <MenuItem Header="Save As..." Command="{Binding SaveAsCommand}" />
            <Separator />
            <MenuItem Header="Close" Command="{Binding CloseCommand}" />
        </MenuFlyout>
    </Button.Flyout>
</Button>
```

### Keyboard Shortcut / 键盘快捷键

Use `HotKey` to assign a keyboard gesture that activates the button without focus.

```xml
<Button Content="Save (Ctrl+S)"
        HotKey="Ctrl+S"
        Command="{Binding SaveCommand}" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Content` | `object` | The content displayed inside the button. Supports text, controls, or layouts. Inherited from `ContentControl`. / 按钮内显示的内容。支持文本、控件或布局。继承自 `ContentControl`。 |
| `Command` | `ICommand?` | The command to invoke when the button is clicked. Supports `CanExecute` for automatic enabled/disabled state. / 点击按钮时调用的命令。支持 `CanExecute` 实现自动启用/禁用。 |
| `CommandParameter` | `object?` | Parameter passed to the command when invoked. / 调用命令时传递的参数。 |
| `ClickMode` | `ClickMode` | When the `Click` event fires: `Release` (default) or `Press`. / `Click` 事件触发时机：`Release`（默认）或 `Press`。 |
| `IsDefault` | `bool` | When `true`, the button responds to the Enter key. Only one per scope. / 设为 `true` 时按钮响应 Enter 键。每个范围内仅应设一个。 |
| `IsCancel` | `bool` | When `true`, the button responds to the Escape key. Only one per scope. / 设为 `true` 时按钮响应 Escape 键。每个范围内仅应设一个。 |
| `IsPressed` | `bool` | (Read-only) Whether the button is currently in a pressed state. Toggles the `:pressed` pseudo-class. / （只读）按钮当前是否处于按下状态。控制 `:pressed` 伪类。 |
| `HotKey` | `KeyGesture?` | A keyboard shortcut that activates the button without requiring focus. / 无需焦点即可激活按钮的键盘快捷键。 |
| `Flyout` | `FlyoutBase?` | A flyout attached to the button. Toggles the `:flyout-open` pseudo-class when opened. / 附加到按钮的浮层。打开时触发 `:flyout-open` 伪类。 |
| `IsEnabled` | `bool` | Whether the button can respond to interaction. Inherited from `InputElement`. / 按钮是否可以响应交互。继承自 `InputElement`。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Click` | Raised when the button is clicked, respecting `ClickMode`. / 按钮被点击时触发，遵循 `ClickMode` 设置。 |
| `IsPressedChanged` | Raised when the pressed state changes. / 按下状态改变时触发。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: When should I use Button vs. RepeatButton? / 何时使用 Button 而非 RepeatButton？**

A: Use `Button` for single-click actions (submit, navigate, open dialog). Use `RepeatButton` when you need repeated triggers while held down — scroll buttons, spin-box increment/decrement, or media controls. `Button` fires `Click` once per press-release cycle; `RepeatButton` fires `Click` repeatedly at an interval.

`Button` 用于单次点击操作（提交、导航、打开对话框）。`RepeatButton` 用于按住时需要重复触发的情况 —— 如滚动按钮、微调控件增减、媒体控件。`Button` 每次按下-释放循环触发一次 `Click`，`RepeatButton` 则以固定间隔重复触发。

**Q: How do Semi.Avalonia themes differ from stock Avalonia styles? / Semi.Avalonia 主题与标准 Avalonia 样式有何不同？**

A: Semi.Avalonia switches visual variants with ControlThemes assigned via the `Theme` property, separately from style classes — the variants and classes `Button` actually supports are listed in the `semi-avalonia` skill. Stock Avalonia uses a single `Button` theme with flat pseudo-class selectors and relies on attached `Classes` for variants like `accent`.

A: Semi.Avalonia 通过 `Theme` 属性应用 ControlTheme 来切换视觉变体，与样式类相互独立 —— `Button` 实际支持的变体和类以 `semi-avalonia` skill 为准。标准 Avalonia 使用单一 `Button` 主题配合扁平伪类选择器，并依赖附加 `Classes` 实现 `accent` 等变体。

**Q: Why doesn't ClickMode include a "Hover" option? / 为什么 ClickMode 没有 "Hover" 选项？**

A: Unlike some UI frameworks, Avalonia's `Button.ClickMode` only supports Release (default) and Press — there is no built-in hover mode. If you need hover-triggered actions without a click, handle the `PointerEntered` / `PointerExited` events or use the `:pointerover` pseudo-class in styles instead of relying on the `Click` event.

与某些 UI 框架不同，Avalonia 的 `Button.ClickMode` 仅支持 Release（默认）和 Press，没有内置的悬停模式。如需无点击的悬停触发操作，请处理 `PointerEntered` / `PointerExited` 事件，或在样式中使用 `:pointerover` 伪类，而非依赖 `Click` 事件。
