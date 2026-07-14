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

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlTheme / Semi.Avalonia 控件主题

Semi.Avalonia defines four RadioButton themes:

Semi.Avalonia 定义了四种 RadioButton 主题：

| Theme / 主题 | Resource Key / 资源键 | Description / 说明 |
| --- | --- | --- |
| Default | `{x:Type RadioButton}` | Standard radio button with visible circle indicator and glyph dot. / 标准单选按钮，带可见圆形指示器和字形圆点。 |
| Button | `ButtonRadioButton` | Button-style radio button (no radio circle) — appears as a selectable button. Supports `Small` and `Large` size classes. / 按钮式单选按钮（无单选圆圈）—— 外观类似可选中按钮。支持 `Small` 和 `Large` 尺寸类。 |
| Card | `CardRadioButton` | Card-style with visible radio circle icon and card border. The entire card highlights on selection. / 卡片式，带可见单选圆圈图标和卡片边框。选中时整个卡片高亮。 |
| Pure Card | `PureCardRadioButton` | Card-style without the radio circle icon — only the card background changes state. / 卡片式，无单选圆圈图标 —— 仅卡片背景改变状态。 |

### Default Theme / 默认主题

```xml
<RadioButton Content="Option A"
             GroupName="MyGroup"
             IsChecked="True" />
```

The glyph (dot indicator) and label are styled through nested `Style` selectors targeting `Ellipse#OuterEllipse`, `Ellipse#CheckGlyph`, and `ContentPresenter#PART_ContentPresenter`.

字形（圆点指示器）和标签通过嵌套 `Style` 选择器定位 `Ellipse#OuterEllipse`、`Ellipse#CheckGlyph` 和 `ContentPresenter#PART_ContentPresenter` 进行样式设置。

### ButtonRadioButton / 按钮式单选按钮

Applies a button-like appearance to `RadioButton`, hiding the radio circle entirely. Best for toggle-button groups or segmented controls where the button itself conveys selection. Supports `Small` and `Large` size classes.

将按钮式外观应用于 `RadioButton`，完全隐藏单选圆圈。最适用于切换按钮组或分段控件，按钮本身传达选中状态。支持 `Small` 和 `Large` 尺寸类。

```xml
<StackPanel Orientation="Horizontal" Spacing="4">
    <RadioButton Content="Daily"
                 GroupName="Frequency"
                 Theme="{DynamicResource ButtonRadioButton}"
                 IsChecked="True" />
    <RadioButton Content="Weekly"
                 GroupName="Frequency"
                 Theme="{DynamicResource ButtonRadioButton}" />
    <RadioButton Content="Monthly"
                 GroupName="Frequency"
                 Theme="{DynamicResource ButtonRadioButton}" />
</StackPanel>

<!-- With size classes -->
<RadioButton Content="Small Button"
             Theme="{DynamicResource ButtonRadioButton}"
             Classes="Small" />
<RadioButton Content="Large Button"
             Theme="{DynamicResource ButtonRadioButton}"
             Classes="Large" />
```

### CardRadioButton / 卡片式单选按钮

Presents each `RadioButton` as a card with a visible radio circle icon. The card border and background change based on selection state. Ideal for settings pages where each option needs a larger hit area and descriptive content.

将每个 `RadioButton` 呈现为带可见单选圆圈图标的卡片。卡片边框和背景根据选中状态变化。适用于设置页面，每个选项需要更大的点击区域和描述性内容。

```xml
<StackPanel Spacing="8">
    <RadioButton Content="Free Plan"
                 GroupName="Plan"
                 Theme="{DynamicResource CardRadioButton}"
                 IsChecked="True" />
    <RadioButton Content="Pro Plan"
                 GroupName="Plan"
                 Theme="{DynamicResource CardRadioButton}" />
    <RadioButton Content="Enterprise Plan"
                 GroupName="Plan"
                 Theme="{DynamicResource CardRadioButton}" />
</StackPanel>
```

### PureCardRadioButton / 纯卡片式单选按钮

Like `CardRadioButton` but completely omits the radio circle icon. Selection is conveyed purely through the card's background and border color change. Use for image or rich-content selection cards where a radio circle would be visually distracting.

类似 `CardRadioButton`，但完全省略单选圆圈图标。选中状态仅通过卡片的背景和边框颜色变化传达。用于图片或富内容选择卡片，单选圆圈会造成视觉干扰的场景。

```xml
<StackPanel Spacing="8">
    <RadioButton GroupName="Avatar"
                 Theme="{DynamicResource PureCardRadioButton}"
                 IsChecked="True">
        <StackPanel>
            <Image Source="avatar1.png" Width="64" Height="64" />
            <TextBlock Text="Avatar A" HorizontalAlignment="Center" />
        </StackPanel>
    </RadioButton>
    <RadioButton GroupName="Avatar"
                 Theme="{DynamicResource PureCardRadioButton}">
        <StackPanel>
            <Image Source="avatar2.png" Width="64" Height="64" />
            <TextBlock Text="Avatar B" HorizontalAlignment="Center" />
        </StackPanel>
    </RadioButton>
</StackPanel>
```

### RadioButtonGroupBorder / 单选按钮组边框

A companion theme for `Border` used to wrap a group of `RadioButton` controls with shared rounded corners and background. Apply `Theme="{DynamicResource RadioButtonGroupBorder}"` on the wrapping `Border`.

一个配套的 `Border` 主题，用于包裹一组 `RadioButton` 控件，提供共享的圆角和背景。在包裹的 `Border` 上应用 `Theme="{DynamicResource RadioButtonGroupBorder}"`。

```xml
<Border Theme="{DynamicResource RadioButtonGroupBorder}" Padding="4">
    <StackPanel Spacing="2">
        <RadioButton Content="Option 1"
                     GroupName="Grouped"
                     Theme="{DynamicResource ButtonRadioButton}" />
        <RadioButton Content="Option 2"
                     GroupName="Grouped"
                     Theme="{DynamicResource ButtonRadioButton}" />
    </StackPanel>
</Border>
```

### Pseudo-classes / 伪类

Semi.Avalonia styles the following pseudo-classes on `RadioButton`:

Semi.Avalonia 为 `RadioButton` 设置了以下伪类样式：

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:checked` | RadioButton is selected. / 处于选中状态。 |
| `:unchecked` | RadioButton is not selected. / 处于未选中状态。 |
| `:pointerover` | Mouse is hovering over the RadioButton. / 鼠标悬停。 |
| `:pressed` | RadioButton is being pressed. / 正在被按下。 |
| `:disabled` | RadioButton is disabled. / 已禁用。 |

### Key Resource Keys / 关键资源键

Resource keys follow the naming convention `RadioButton{Property}` and resolve via `DynamicResource`:

资源键遵循命名约定 `RadioButton{属性}`，通过 `DynamicResource` 解析：

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `RadioButtonBoxCornerRadius` | Outer box corner radius / 外框圆角 |
| `RadioButtonCheckGlyphFill` | Check glyph (dot) fill color when checked / 选中时勾选字形（圆点）填充色 |
| `RadioButtonContentMargin` | Content presenter margin / 内容展示区内边距 |
| `RadioButtonDefaultBackground` | Outer circle background in default state / 默认状态下外圈背景 |
| `RadioButtonDefaultBorderBrush` | Outer circle border brush in default state / 默认状态下外圈边框画刷 |
| `RadioButtonDisabledForeground` | Label text color when disabled / 禁用时标签文本颜色 |
| `RadioButtonFontSize` | Label font size / 标签字体大小 |
| `RadioButtonForeground` | Label text color / 标签文本颜色 |
| `RadioButtonGlyphRadius` | Check glyph (dot) radius / 勾选字形（圆点）半径 |
| `RadioButtonIconRadius` | Outer icon circle radius / 外圈图标半径 |
| `RadioButtonUncheckIconDefaultBackground` | Unchecked icon background in default state / 默认状态下未选中图标背景 |
| `RadioButtonUncheckIconDefaultBorderBrush` | Unchecked icon border brush in default state / 默认状态下未选中图标边框画刷 |
| `RadioButtonUncheckIconDefaultThickness` | Unchecked icon border thickness in default state / 默认状态下未选中图标边框粗细 |
| `RadioButtonUncheckIconDisabledBackground` | Unchecked icon background when disabled / 禁用时未选中图标背景 |
| `RadioButtonUncheckIconDisabledBorderBrush` | Unchecked icon border brush when disabled / 禁用时未选中图标边框画刷 |
| `RadioButtonUncheckIconPointeroverBackground` | Unchecked icon background on pointerover / 指针悬停时未选中图标背景 |
| `RadioButtonUncheckIconPointeroverBorderBrush` | Unchecked icon border brush on pointerover / 指针悬停时未选中图标边框画刷 |
| `RadioButtonUncheckIconPressedBackground` | Unchecked icon background when pressed / 按下时未选中图标背景 |
| `RadioButtonUncheckIconPressedBorderBrush` | Unchecked icon border brush when pressed / 按下时未选中图标边框画刷 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Glyph` | `Ellipse` | The inner dot that appears when the RadioButton is checked. / 选中时显示的内部圆点。 |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the `Content` label text. / 渲染 `Content` 标签文本。 |

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
