---
category: Components
title: ToggleButton
subtitle: 切换按钮
description: 切换按钮用于在开/关、选中/未选中等二元或三元状态之间切换。
---

## ToggleButton / 切换按钮

A button that supports checked and unchecked states, with optional three-state (indeterminate) support. Inherits from `Button` and serves as the base class for `CheckBox` and `RadioButton`. Use when an action needs to reflect a persistent on/off state rather than a one-shot trigger.

支持选中和未选中状态，可选三态（不确定）的按钮。继承自 `Button`，是 `CheckBox` 和 `RadioButton` 的基类。当操作需要反映持久的开/关状态而非一次性触发时使用。

## When to Use / 何时使用

Use `ToggleButton` when you need a button that stays pressed or unpressed to represent a binary state — toolbar toggles (bold, italic), expand/collapse triggers, or on/off switches that aren't form fields. For form-style boolean choices, prefer `CheckBox`. For repeated actions while held (e.g. scroll arrows), use `RepeatButton`. For single-shot actions, use `Button`.

当你需要一个保持按下或未按下状态的按钮来表示二元状态时使用 `ToggleButton` —— 工具栏切换（粗体、斜体）、展开/折叠触发器或非表单字段的开/关开关。对于表单式的布尔选择，请使用 `CheckBox`。按住时需要重复触发的操作（如滚动箭头）使用 `RepeatButton`。单次触发的操作使用 `Button`。

## Basic Usage / 基本使用

```xml
<ToggleButton Content="Bold"
              IsChecked="{Binding IsBoldEnabled}"
              Classes="Primary" />
```

```csharp
// Code-behind
private void OnToggleChecked(object? sender, RoutedEventArgs e)
{
    var tb = (ToggleButton)sender!;
    bool isOn = tb.IsChecked == true;
    // Apply the toggled state
}
```

```csharp
// Programmatic creation
var toggle = new ToggleButton
{
    Content = "Mute",
    IsChecked = false
};
toggle.IsCheckedChanged += (s, e) => { /* react */ };
```

## Common Scenarios / 常用场景

### Toolbar Toggle / 工具栏切换

Toggle formatting options like bold, italic, or underline in a toolbar.

```xml
<StackPanel Orientation="Horizontal" Spacing="4">
    <ToggleButton Content="B" FontWeight="Bold"
                  IsChecked="{Binding IsBold}" />
    <ToggleButton Content="I" FontStyle="Italic"
                  IsChecked="{Binding IsItalic}" />
    <ToggleButton Content="U" TextDecorations="Underline"
                  IsChecked="{Binding IsUnderline}" />
</StackPanel>
```

### Three-State Toggle / 三态切换

Enable `IsThreeState` to cycle through unchecked → checked → indeterminate.

```xml
<ToggleButton Content="Select All"
              IsThreeState="True"
              IsChecked="{Binding SelectAllState}" />
```

```csharp
public bool? SelectAllState
{
    get => _selectAllState;
    set
    {
        _selectAllState = value;
        // null = indeterminate (some children selected)
        // true = all selected, false = none selected
        OnPropertyChanged();
    }
}
```

### Expand/Collapse Trigger / 展开折叠触发器

Use a `ToggleButton` with `:checked` pseudo-class to drive expandable panels.

```xml
<ToggleButton x:Name="ExpandToggle"
              Content="▼ Details"
              IsChecked="False" />
<Border IsVisible="{Binding IsChecked, ElementName=ExpandToggle}">
    <TextBlock Text="Expanded content here..." />
</Border>
```

### Command Binding / 命令绑定

Bind to a command and use `CommandParameter` to distinguish toggle intent.

```xml
<ToggleButton Content="Pin"
              Command="{Binding TogglePinCommand}"
              CommandParameter="{Binding RelativeSource={RelativeSource Self}, Path=IsChecked}"
              IsChecked="{Binding IsPinned}" />
```

## Property Reference / 属性参考

ToggleButton inherits all properties from `Button`. Key properties:

ToggleButton 继承 `Button` 的所有属性。关键属性：

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `IsChecked` | `bool?` | `true` = checked, `false` = unchecked, `null` = indeterminate (only when `IsThreeState` is `true`). / `true` = 选中，`false` = 未选中，`null` = 不确定（仅当 `IsThreeState` 为 `true` 时）。 |
| `IsThreeState` | `bool` | Enables indeterminate (`null`) state, cycling through three states on click. / 启用不确定（`null`）状态，点击时在三种状态间循环。 |
| `Content` | `object` | Inherited from `ContentControl`. Displayed content. / 继承自 `ContentControl`。显示的内容。 |
| `Command` | `ICommand?` | Inherited from `Button`. Invoked when checked state changes. / 继承自 `Button`。选中状态更改时触发。 |
| `CommandParameter` | `object?` | Inherited from `Button`. Parameter passed to command. / 继承自 `Button`。传递给命令的参数。 |
| `ClickMode` | `ClickMode` | Inherited from `Button`. When to fire: `Release` (default) or `Press`. / 继承自 `Button`。触发时机：`Release`（默认）或 `Press`。 |
| `IsPressed` | `bool` | Inherited from `Button`. (Read-only) Whether currently pressed. / 继承自 `Button`。（只读）当前是否按下。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Checked` | Raised when `IsChecked` becomes `true`. / `IsChecked` 变为 `true` 时触发。 |
| `Unchecked` | Raised when `IsChecked` becomes `false`. / `IsChecked` 变为 `false` 时触发。 |
| `Indeterminate` | Raised when `IsChecked` becomes `null` (three-state only). / `IsChecked` 变为 `null` 时触发（仅三态模式）。 |
| `IsCheckedChanged` | Raised on any `IsChecked` change. Check the new value with `e.RoutedEvent`. / 任何 `IsChecked` 变化时触发。通过 `e.RoutedEvent` 检查新值。 |
| `Click` | Inherited from `Button`. Raised on click in addition to Checked/Unchecked. / 继承自 `Button`。点击时在 Checked/Unchecked 之外额外触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia extends the `Button` styling system to `ToggleButton`, adding checked-state pseudo-classes. All `Button` themes, color classes, and size classes apply to `ToggleButton` as well.

Semi.Avalonia 将 `Button` 样式系统扩展到 `ToggleButton`，增加了选中状态的伪类。所有 `Button` 主题、颜色类和尺寸类同样适用于 `ToggleButton`。

### Theme Variants / 主题变体

Same four themes as `Button`: Light (default), Solid, Outline, Borderless.

与 `Button` 相同的四种主题：Light（默认）、Solid、Outline、Borderless。

```xml
<ToggleButton Content="Toggle" Theme="{DynamicResource SolidButton}" />
<ToggleButton Content="Toggle" Theme="{DynamicResource OutlineButton}" />
<ToggleButton Content="Toggle" Theme="{DynamicResource BorderlessButton}" />
```

### Color Classes / 颜色类

Same six color classes as `Button`: Primary (default), Secondary, Tertiary, Success, Warning, Danger. The checked state uses a stronger fill from the same color family.

与 `Button` 相同的六种颜色类：Primary（默认）、Secondary、Tertiary、Success、Warning、Danger。选中状态使用同色系更强的填充。

### Size Classes / 尺寸类

Same size classes as `Button`: default, `Large`, `Small`.

与 `Button` 相同的尺寸类：默认、`Large`、`Small`。

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:checked` | ToggleButton `IsChecked` is `true`. Visual: filled background. / `IsChecked` 为 `true`。视觉：填充背景。 |
| `:unchecked` | ToggleButton `IsChecked` is `false`. Visual: default appearance. / `IsChecked` 为 `false`。视觉：默认外观。 |
| `:indeterminate` | ToggleButton `IsChecked` is `null`. Visual: partial/hint fill. / `IsChecked` 为 `null`。视觉：部分/提示填充。 |
| `:pointerover` | Mouse is hovering over the control. / 鼠标悬停。 |
| `:pressed` | Control is being pressed. / 正在被按下。 |
| `:disabled` | Control is disabled (`IsEnabled = false`). / 已禁用。 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the `Content` property. All Semi.Avalonia toggle styles target this part. / 渲染 `Content` 属性。所有 Semi.Avalonia 切换样式均通过此部件设置。 |

## FAQ / 常见问题

**Q: When should I use ToggleButton vs. CheckBox? / 何时使用 ToggleButton 而非 CheckBox？**

A: Use `ToggleButton` for toolbar toggles, expand/collapse triggers, and on/off actions where the button itself communicates state visually. Use `CheckBox` for form fields where a label-and-box layout is expected, and where the user needs to distinguish between the label text and the check indicator. `ToggleButton` looks like a button that stays pressed; `CheckBox` looks like a form input.

`ToggleButton` 用于工具栏切换、展开/折叠触发器以及按钮本身通过视觉传达状态的开/关操作。`CheckBox` 用于期望标签加框布局的表单字段，以及用户需要区分标签文本和勾选指示器的情况。`ToggleButton` 看起来像一个保持按下状态的按钮；`CheckBox` 看起来像一个表单输入。

**Q: How do three-state ToggleButtons cycle? / 三态 ToggleButton 如何循环？**

A: When `IsThreeState="True"`, clicking cycles through: unchecked (`false`) → checked (`true`) → indeterminate (`null`) → unchecked (`false`). Indeterminate is commonly used to represent "mixed" or "partial" states — for example, a "Select All" toggle where some (but not all) child items are selected. Programmatically set `IsChecked = null` to enter indeterminate state.

当 `IsThreeState="True"` 时，点击循环顺序为：未选中（`false`）→ 选中（`true`）→ 不确定（`null`）→ 未选中（`false`）。不确定状态通常用于表示"混合"或"部分"状态 —— 例如，部分（而非全部）子项被选中的"全选"切换。通过代码设置 `IsChecked = null` 可进入不确定状态。

**Q: Can I use Button themes (Solid, Outline, etc.) on ToggleButton? / 可以在 ToggleButton 上使用 Button 主题吗？**

A: Yes. Semi.Avalonia `ToggleButton` inherits all `Button` theme resources (`SolidButton`, `OutlineButton`, `BorderlessButton`) and responds to the same color and size classes. Toggle-specific pseudo-classes (`:checked`, `:unchecked`, `:indeterminate`) layer on top to visually indicate the toggle state within the chosen theme.

可以。Semi.Avalonia 的 `ToggleButton` 继承所有 `Button` 主题资源（`SolidButton`、`OutlineButton`、`BorderlessButton`），并响应相同的颜色和尺寸类。特定于切换的伪类（`:checked`、`:unchecked`、`:indeterminate`）在其上层叠加，在所选主题内可视化地指示切换状态。
