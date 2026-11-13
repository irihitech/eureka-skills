---
category: Components
title: CheckBox
subtitle: 复选框
description: 复选框用于在选中和未选中状态之间切换。
---

# CheckBox / 复选框

A selectable control that toggles between checked, unchecked, and optionally indeterminate states. Inherits from `ToggleButton` and adds no additional public properties — all behavior is inherited. Use for boolean options, multi-select lists, and agreement confirmations.

可在选中、未选中和可选的不确定状态之间切换的选择控件。继承自 `ToggleButton`，不添加额外的公共属性 —— 所有行为均来自继承。用于布尔选项、多选列表和协议确认。

## When to Use / 何时使用

Use `CheckBox` for independent boolean choices where users toggle a single option on or off. Common in settings pages, filter panels, and multi-select lists. For mutually exclusive choices (only one option in a group), use `RadioButton`. For an immediate on/off action (not a state), use `ToggleSwitch`. For a three-state scenario (checked/unchecked/indeterminate), set `IsThreeState="True"` — useful for nested checkboxes representing partial selection.

使用 `CheckBox` 进行独立的布尔选择，用户切换单个选项的开或关。常见于设置页面、筛选面板和多选列表。互斥选择（一组中只能选一个）使用 `RadioButton`。即时开/关操作（非状态）使用 `ToggleSwitch`。三态场景（选中/未选中/不确定）设置 `IsThreeState="True"` — 适用于表示部分选择的嵌套复选框。

## Basic Usage / 基本使用

```xml
<CheckBox Content="I agree to the terms"
          IsChecked="{Binding AgreedToTerms}" />
```

```csharp
// React to state changes
myCheckBox.IsCheckedChanged += (s, e) =>
{
    bool isChecked = myCheckBox.IsChecked == true;
};
```

## Common Scenarios / 常用场景

### Three-state CheckBox / 三态复选框

Enable `IsThreeState` for parent-child selection patterns where "indeterminate" means "some children selected."

```xml
<CheckBox Content="Select All"
          IsThreeState="True"
          IsChecked="{Binding AllSelectedState}" />
```

### Data-bound List / 数据绑定列表

Bind a collection of selectable items with a `CheckBox` in each row.

```xml
<ListBox ItemsSource="{Binding Options}">
    <ListBox.ItemTemplate>
        <DataTemplate>
            <CheckBox Content="{Binding Label}"
                      IsChecked="{Binding IsSelected, Mode=TwoWay}" />
        </DataTemplate>
    </ListBox.ItemTemplate>
</ListBox>
```

### Card Style / 卡片样式

Semi.Avalonia also provides card-style ControlTheme variants for `CheckBox` — which variants exist
(and their theme keys) is listed in the generated `semi-avalonia` skill; apply them via `Theme`.

```xml
<CheckBox Content="Option A" />
<CheckBox Content="Option B" />
```

## Property Reference / 属性参考

CheckBox inherits all properties from `ToggleButton`. Key inherited properties:

CheckBox 继承 `ToggleButton` 的所有属性。关键继承属性：

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `IsChecked` | `bool?` | `true` = checked, `false` = unchecked, `null` = indeterminate (only when `IsThreeState` is `true`). / `true` = 选中，`false` = 未选中，`null` = 不确定（仅当 `IsThreeState` 为 `true` 时）。 |
| `IsThreeState` | `bool` | Enables indeterminate (`null`) state. / 启用不确定（`null`）状态。 |
| `Content` | `object` | Label text or content next to the check box. / 复选框旁边的标签文本或内容。 |
| `Command` | `ICommand?` | Command invoked when checked state changes. / 选中状态改变时调用的命令。 |
| `CommandParameter` | `object?` | Parameter passed to the command. / 传递给命令的参数。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `IsCheckedChanged` | Raised when `IsChecked` changes. / `IsChecked` 改变时触发。 |
| `Checked` | Raised when `IsChecked` becomes `true`. / `IsChecked` 变为 `true` 时触发。 |
| `Unchecked` | Raised when `IsChecked` becomes `false`. / `IsChecked` 变为 `false` 时触发。 |
| `Indeterminate` | Raised when `IsChecked` becomes `null`. / `IsChecked` 变为 `null` 时触发。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: When should I use CheckBox vs. ToggleSwitch? / 何时使用 CheckBox 而非 ToggleSwitch？**

A: Use `CheckBox` for settings that require explicit confirmation (e.g., "I agree to terms", multi-select filters) — it represents a **state** that is part of a form or selection. Use `ToggleSwitch` for immediate on/off **actions** where the change takes effect instantly (e.g., enabling Wi-Fi, dark mode). CheckBox is typically used in forms; ToggleSwitch is typically used in settings toolbars.

`CheckBox` 用于需要明确确认的设置（如"我同意条款"、多选筛选）—— 它表示表单或选择中的**状态**。`ToggleSwitch` 用于立即生效的开/关**操作**（如启用 Wi-Fi、深色模式）。CheckBox 通常用于表单中；ToggleSwitch 通常用于设置工具栏中。

**Q: How do indeterminate CheckBoxes work? / 不确定状态复选框如何工作？**

A: Set `IsThreeState="True"` and bind `IsChecked` to a `bool?` property. The control cycles through: unchecked (`false`) → checked (`true`) → indeterminate (`null`) → unchecked. Indeterminate is commonly used for "select all" checkboxes where some (but not all) child items are selected.

设置 `IsThreeState="True"` 并将 `IsChecked` 绑定到 `bool?` 属性。控件循环顺序为：未选中（`false`）→ 选中（`true`）→ 不确定（`null`）→ 未选中。不确定状态通常用于"全选"复选框，表示部分（而非全部）子项被选中。
