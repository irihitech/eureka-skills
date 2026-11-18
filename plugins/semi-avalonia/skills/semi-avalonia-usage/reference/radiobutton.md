---
category: Components
title: RadioButton
subtitle: 单选按钮
description: 单选按钮用于在一组互斥选项中选择一项。
---

# RadioButton / 单选按钮

A selection control that allows users to choose exactly one option from a mutually exclusive group. Inherits from `ToggleButton` and adds no additional public properties — all behavior is inherited, with grouping managed by `GroupName` or parent container. Use for exclusive single-choice scenarios where exactly one option must be selected.

允许用户从一组互斥选项中恰好选择一项的选择控件。继承自 `ToggleButton`，不添加额外的公共属性 —— 所有行为均来自继承，分组由 `GroupName` 或父容器管理。用于必须恰好选择一项的排他性单选场景。

## When to Use / 何时使用

Use `RadioButton` when users must select exactly one option from a small, fixed set of mutually exclusive choices — such as payment methods, shipping options, or preference settings. For independent boolean choices where each option can be toggled independently, use `CheckBox`. For an immediate on/off action (not a selection from a group), use `ToggleSwitch`.

当用户必须从一组小型、固定的互斥选项中恰好选择一项时使用 `RadioButton` —— 例如支付方式、配送选项或偏好设置。对于每个选项可独立切换的布尔选择，请使用 `CheckBox`。对于即时的开/关操作（而非从组中选择），请使用 `ToggleSwitch`。

## Basic Usage / 基本使用

```xml
<StackPanel Spacing="8">
    <RadioButton Content="Option A"
                 GroupName="MyGroup"
                 IsChecked="True" />
    <RadioButton Content="Option B"
                 GroupName="MyGroup" />
    <RadioButton Content="Option C"
                 GroupName="MyGroup" />
</StackPanel>
```

```csharp
// React to selection change
myRadioButton.IsCheckedChanged += (s, e) =>
{
    if (myRadioButton.IsChecked == true)
    {
        // This RadioButton is now selected
    }
};
```

## Common Scenarios / 常用场景

### Group Binding with Enum / 枚举分组绑定

Bind RadioButton groups to an enum property in your ViewModel using a value converter or per-button bindings.

```xml
<StackPanel Spacing="8">
    <RadioButton Content="Light"
                 IsChecked="{Binding Theme, Converter={StaticResource EnumToBoolConverter}, ConverterParameter=Light}" />
    <RadioButton Content="Dark"
                 IsChecked="{Binding Theme, Converter={StaticResource EnumToBoolConverter}, ConverterParameter=Dark}" />
    <RadioButton Content="System"
                 IsChecked="{Binding Theme, Converter={StaticResource EnumToBoolConverter}, ConverterParameter=System}" />
</StackPanel>
```

```csharp
public enum ThemeOption { Light, Dark, System }

public ThemeOption Theme
{
    get => _theme;
    set { _theme = value; OnPropertyChanged(); }
}
```

### GroupName Across Containers / 跨容器分组

Use `GroupName` to group RadioButtons that are not in the same logical parent. All RadioButtons with the same `GroupName` value participate in mutual exclusion.

```xml
<StackPanel Orientation="Horizontal" Spacing="16">
    <StackPanel>
        <TextBlock Text="Fruits" FontWeight="Bold" />
        <RadioButton Content="Apple"  GroupName="Food" />
        <RadioButton Content="Banana" GroupName="Food" />
    </StackPanel>
    <StackPanel>
        <TextBlock Text="Drinks" FontWeight="Bold" />
        <RadioButton Content="Coffee" GroupName="Drink" />
        <RadioButton Content="Tea"    GroupName="Drink" />
    </StackPanel>
</StackPanel>
```

### IsThreeState (Inherited) / 三态支持（继承）

RadioButton inherits `IsThreeState` from `ToggleButton`, though indeterminate state is rarely used with RadioButtons.

```xml
<!-- Rare: allows cycling through unchecked → checked → indeterminate -->
<RadioButton Content="Three-state"
             IsThreeState="True" />
```

## Property Reference / 属性参考

RadioButton inherits all properties from `ToggleButton`. Key inherited properties:

RadioButton 继承 `ToggleButton` 的所有属性。关键继承属性：

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `IsChecked` | `bool?` | `true` = selected, `false` = unselected. RadioButton ignores `null` (indeterminate) for group exclusion unless `IsThreeState` is `true`. / `true` = 选中，`false` = 未选中。RadioButton 在组排除中忽略 `null`（不确定），除非 `IsThreeState` 为 `true`。 |
| `GroupName` | `string?` | Logical group identifier. RadioButtons with the same `GroupName` are mutually exclusive, even across different visual containers. / 逻辑组标识符。具有相同 `GroupName` 的 RadioButton 互斥，即使位于不同视觉容器中。 |
| `IsThreeState` | `bool` | Inherited from `ToggleButton`. Enables indeterminate state cycling. / 继承自 `ToggleButton`。启用不确定状态循环。 |
| `Content` | `object` | Label text or content next to the radio button. / 单选按钮旁边的标签文本或内容。 |
| `Command` | `ICommand?` | Command invoked when the checked state changes. / 选中状态改变时调用的命令。 |
| `CommandParameter` | `object?` | Parameter passed to the command. / 传递给命令的参数。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `IsCheckedChanged` | Raised when `IsChecked` changes. / `IsChecked` 改变时触发。 |
| `Checked` | Raised when `IsChecked` becomes `true`. / `IsChecked` 变为 `true` 时触发。 |
| `Unchecked` | Raised when `IsChecked` becomes `false` (another RadioButton in the group is selected). / `IsChecked` 变为 `false` 时触发（组内其他 RadioButton 被选中）。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: When should I use RadioButton vs. ComboBox? / 何时使用 RadioButton 而非 ComboBox？**

A: Use `RadioButton` when you have 2–5 options and want all choices visible at once — the user can scan and compare before selecting. Use `ComboBox` (or `DropDownButton`) when you have 6+ options or limited horizontal space — it shows only the selected value until opened. RadioButtons expose all options; ComboBoxes hide them behind a click.

当有 2–5 个选项且希望所有选项同时可见时使用 `RadioButton` —— 用户可以在选择之前浏览和比较。当有 6 个以上选项或水平空间有限时使用 `ComboBox`（或 `DropDownButton`）—— 它在打开之前仅显示选中的值。RadioButton 暴露所有选项；ComboBox 将其隐藏在点击之后。

**Q: How does GroupName work when RadioButtons are inside different containers? / GroupName 在 RadioButton 位于不同容器内时如何工作？**

A: `GroupName` creates a logical group that spans the entire visual tree, ignoring container boundaries. Two RadioButtons with `GroupName="Theme"` will be mutually exclusive even if one is in a `StackPanel` and the other in a `Grid` on a different branch. The group is scoped to the same `Window` or `TopLevel`.

`GroupName` 创建一个跨越整个视觉树的逻辑组，忽略容器边界。两个设置了 `GroupName="Theme"` 的 RadioButton 即使一个在 `StackPanel` 中、另一个在不同分支的 `Grid` 中，也会互斥。组的作用范围限于同一 `Window` 或 `TopLevel`。

**Q: Why isn't my RadioButton unchecking when I click it again? / 为什么我再次点击 RadioButton 时它不会取消选中？**

A: By design, a RadioButton in a group cannot be unchecked by clicking it again — once selected, it stays selected. This is the standard behavior for mutually exclusive selection. If you need toggleable on/off behavior per item, use `CheckBox` instead. If you need a group where the same item can be deselected, handle the `Checked` event to programmatically clear the selection when the same button is clicked twice.

按照设计，组中的 RadioButton 无法通过再次点击来取消选中 —— 一旦选中，它将保持选中状态。这是互斥选择的标准行为。如果需要每项的开关行为，请使用 `CheckBox`。如果需要同一项可以被取消选中的组，请在 `Checked` 事件中通过编程方式处理，当同一按钮被点击两次时清除选择。
