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

Semi.Avalonia provides `CardCheckBox` and `PureCardCheckBox` themes for card-like checkbox appearance.

```xml
<CheckBox Content="Option A"
          Theme="{DynamicResource CardCheckBox}" />
<CheckBox Content="Option B"
          Theme="{DynamicResource PureCardCheckBox}" />
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

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlTheme / Semi.Avalonia 控件主题

Semi.Avalonia defines three CheckBox themes:

Semi.Avalonia 定义了三种 CheckBox 主题：

| Theme / 主题 | Resource Key / 资源键 | Description / 说明 |
| --- | --- | --- |
| Default | `{x:Type CheckBox}` | Standard checkbox with visible box and check mark glyph. / 标准复选框，带可见框和勾选标记。 |
| Card | `CardCheckBox` | Card-style with full background fill when checked. / 卡片样式，选中时完全填充背景。 |
| Pure Card | `PureCardCheckBox` | Card-style without visible check box, only background change. / 卡片样式，无可见复选框，仅背景变化。 |

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:checked` | CheckBox is in the checked state. / 处于选中状态。 |
| `:unchecked` | CheckBox is in the unchecked state. / 处于未选中状态。 |
| `:indeterminate` | CheckBox is in the indeterminate state. / 处于不确定状态。 |
| `:pointerover` | Mouse is hovering over the CheckBox. / 鼠标悬停。 |
| `:pressed` | CheckBox is being pressed. / 正在被按下。 |
| `:disabled` | CheckBox is disabled. / 已禁用。 |

### Key Resource Keys / 关键资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `CheckBoxForeground` | Label text color / 标签文本颜色 |
| `CheckBoxDefaultBackground` | Box background / 框背景 |
| `CheckBoxDefaultBorderBrush` | Box border / 框边框 |
| `CheckBoxBoxCornerRadius` | Box corner rounding / 框圆角 |
| `CheckBoxBoxWidth` / `CheckBoxBoxHeight` | Box dimensions / 框尺寸 |
| `CheckBoxGlyphForeground` | Check mark color / 勾选标记颜色 |
| `CheckBoxDisabledForeground` | Text color when disabled / 禁用时文本颜色 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_GlyphPanel` | `Panel` | Contains the check mark glyph that appears when checked. / 包含选中时显示的勾选标记。 |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the `Content` label text. / 渲染 `Content` 标签文本。 |

## FAQ / 常见问题

**Q: When should I use CheckBox vs. ToggleSwitch? / 何时使用 CheckBox 而非 ToggleSwitch？**

A: Use `CheckBox` for settings that require explicit confirmation (e.g., "I agree to terms", multi-select filters) — it represents a **state** that is part of a form or selection. Use `ToggleSwitch` for immediate on/off **actions** where the change takes effect instantly (e.g., enabling Wi-Fi, dark mode). CheckBox is typically used in forms; ToggleSwitch is typically used in settings toolbars.

`CheckBox` 用于需要明确确认的设置（如"我同意条款"、多选筛选）—— 它表示表单或选择中的**状态**。`ToggleSwitch` 用于立即生效的开/关**操作**（如启用 Wi-Fi、深色模式）。CheckBox 通常用于表单中；ToggleSwitch 通常用于设置工具栏中。

**Q: How do indeterminate CheckBoxes work? / 不确定状态复选框如何工作？**

A: Set `IsThreeState="True"` and bind `IsChecked` to a `bool?` property. The control cycles through: unchecked (`false`) → checked (`true`) → indeterminate (`null`) → unchecked. Indeterminate is commonly used for "select all" checkboxes where some (but not all) child items are selected.

设置 `IsThreeState="True"` 并将 `IsChecked` 绑定到 `bool?` 属性。控件循环顺序为：未选中（`false`）→ 选中（`true`）→ 不确定（`null`）→ 未选中。不确定状态通常用于"全选"复选框，表示部分（而非全部）子项被选中。
