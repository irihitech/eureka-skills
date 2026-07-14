---
category: Components
title: NumericUpDown
subtitle: 数字增减器
description: 数字增减器用于通过按钮或键盘调整数值。
---

# NumericUpDown / 数字增减器

A control for entering and adjusting numeric values via spinner buttons, keyboard, or mouse wheel. Inherits from `TemplatedControl`. Supports value clamping, custom increment steps, format strings, and optional text input validation.

数字增减器控件，通过微调按钮、键盘或鼠标滚轮输入和调整数值。继承自 `TemplatedControl`。支持数值范围限制、自定义步进量、格式化字符串以及可选的文本输入验证。

## When to Use / 何时使用

Use `NumericUpDown` when you need a compact input for numeric values with increment/decrement buttons — such as quantity selectors, setting adjustment panels, time/duration inputs, or any bounded numeric entry. For slider-style continuous ranges, consider `Slider` instead. For currency or percentage, use `NumericUpDown` with a `FormatString`. When the spinner buttons are unnecessary, set `ShowButtonSpinner="False"` to show only the text input.

当你需要一个带有增减按钮的紧凑数字输入时使用 `NumericUpDown` —— 例如数量选择器、设置调整面板、时间/时长输入或任何有界数值输入。对于滑块式的连续范围，请考虑使用 `Slider`。对于货币或百分比，使用带 `FormatString` 的 `NumericUpDown`。当不需要微调按钮时，设置 `ShowButtonSpinner="False"` 仅显示文本输入。

## Basic Usage / 基本使用

```xml
<NumericUpDown Value="5"
               Minimum="0"
               Maximum="100"
               Increment="1" />
```

```csharp
// Code-behind event handling
var numericUpDown = new NumericUpDown
{
    Value = 5,
    Minimum = 0,
    Maximum = 100,
    Increment = 1
};
numericUpDown.ValueChanged += (s, e) =>
{
    Console.WriteLine($"New value: {e.NewValue}");
};
```

## Common Scenarios / 常用场景

### Custom Increment / 自定义步进

Use a non-default `Increment` for coarse adjustments, and `ClipValueToMinMax` to enforce bounds.

```xml
<NumericUpDown Minimum="0"
               Maximum="1000"
               Increment="50"
               ClipValueToMinMax="True" />
```

```csharp
numericUpDown.Increment = 50;
```

### Format String / 格式化字符串

Display values as currency, percentage, or with custom decimal places using `FormatString`.

```xml
<NumericUpDown Value="98.6"
               FormatString="F1" />   <!-- "98.6" -->

<NumericUpDown Value="0.85"
               FormatString="P0" />   <!-- "85%" -->
```

```csharp
numericUpDown.FormatString = "C2";    // "$98.60" (culture-dependent)
```

### Button Spinner Visibility / 微调按钮可见性

Hide the spinner buttons for a plain numeric text input, or control their placement.

```xml
<!-- Plain text-only numeric input -->
<NumericUpDown ShowButtonSpinner="False" />

<!-- Buttons on the left side -->
<NumericUpDown ButtonSpinnerLocation="Left"
               ShowButtonSpinner="True" />
```

### Data Binding / 数据绑定

Bind `Value` to a ViewModel property for MVVM scenarios. Handle `ValueChanged` for side effects.

```xml
<NumericUpDown Value="{Binding Quantity}"
               Minimum="1"
               Maximum="99" />
```

```csharp
public class OrderViewModel : ObservableObject
{
    private int _quantity = 1;
    public int Quantity
    {
        get => _quantity;
        set => SetProperty(ref _quantity, value);
    }
}
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Value` | `double` | The current numeric value. Defaults to `0`. / 当前数值。默认为 `0`。 |
| `Minimum` | `double` | The lower bound (inclusive) for the value. / 数值的下限（含）。 |
| `Maximum` | `double` | The upper bound (inclusive) for the value. / 数值的上限（含）。 |
| `Increment` | `double` | The step amount for each spinner button press or mouse wheel tick. Defaults to `1`. / 每次微调按钮按下或鼠标滚轮滚动时的步进量。默认为 `1`。 |
| `FormatString` | `string?` | .NET format string applied to `Value` when displayed. When `null`, raw value is shown. / 显示时应用于 `Value` 的 .NET 格式字符串。为 `null` 时显示原始值。 |
| `ShowButtonSpinner` | `bool` | Whether the spinner buttons are visible. `true` by default. / 是否显示微调按钮。默认为 `true`。 |
| `ButtonSpinnerLocation` | `SpinnerLocation` | `Right` (default) or `Left` — where the spinner buttons appear relative to the text input. / `Right`（默认）或 `Left` — 微调按钮相对于文本输入的位置。 |
| `AllowSpin` | `bool` | When `true` (default), spinner buttons and keyboard up/down are enabled. Set to `false` to disable spinning but keep edit. / 为 `true`（默认）时启用微调按钮和键盘上下键。设为 `false` 禁止旋转但保留编辑。 |
| `ClipValueToMinMax` | `bool` | When `true`, `Value` is clamped to `[Minimum, Maximum]` on text input. Default `false`. / 为 `true` 时，文本输入后 `Value` 被限制在 `[Minimum, Maximum]` 范围。默认为 `false`。 |
| `IsReadOnly` | `bool` | When `true`, the text input portion is read-only (spinner buttons still work). / 为 `true` 时文本输入为只读（微调按钮仍然可用）。 |
| `Text` | `string?` | The raw text displayed in the input field. Read from `FormatString`-formatted `Value`. / 输入字段中显示的原始文本。从格式化的 `Value` 读取。 |
| `Watermark` | `string?` | Placeholder text when no value is entered. / 未输入值时显示的占位符文本。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `ValueChanged` | Raised after the value has changed. `NumericUpDownValueChangedEventArgs` provides `OldValue` and `NewValue`. / 数值改变后触发。`NumericUpDownValueChangedEventArgs` 提供 `OldValue` 和 `NewValue`。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides a rich styling system for `NumericUpDown` with theme variants, color classes, and size classes. All themes use nested `Style` selectors targeting `TextBox#PART_TextBox` and `ButtonSpinner#PART_Spinner`.

Semi.Avalonia 为 `NumericUpDown` 提供了丰富的样式系统，包含主题变体、颜色类和尺寸类。所有主题均使用嵌套 `Style` 选择器定位 `TextBox#PART_TextBox` 和 `ButtonSpinner#PART_Spinner`。

### Theme Variants / 主题变体

| Theme / 主题 | Resource Key / 资源键 | Appearance / 外观 |
| --- | --- | --- |
| **Default** | `{x:Type NumericUpDown}` | Standard bordered input with spinner buttons. / 标准带边框输入框配合微调按钮。 |

```xml
<!-- Default theme: no explicit assignment -->
<NumericUpDown Value="42" />
```

### Color Classes / 颜色类

Apply via the `Classes` attached property. Defaults to `Primary` when no color class is specified.

| Class / 类名 | Description / 说明 |
| --- | --- |
| `Primary` | (default) Blue accent focus ring. / （默认）蓝色强调焦点环。 |
| `Secondary` | Neutral gray tone. / 中性灰色调。 |
| `Success` | Green tone for valid/confirmed entries. / 绿色调，用于有效/已确认的输入。 |
| `Warning` | Amber tone for cautionary values. / 琥珀色调，用于警示性数值。 |
| `Danger` | Red tone for invalid or over-limit values. / 红色调，用于无效或超出限制的数值。 |

```xml
<NumericUpDown Value="5" Classes="Secondary" />
<NumericUpDown Value="120" Classes="Warning" />
```

### Size Classes / 尺寸类

| Class / 类名 | Description / 说明 |
| --- | --- |
| *(default)* | Standard size. / 标准尺寸。 |
| `Large` | Larger input with increased padding and font size. / 大号输入框，增加内边距和字体大小。 |
| `Small` | Compact input for dense UIs. / 紧凑输入框，适用于密集 UI。 |

```xml
<NumericUpDown Value="10" Classes="Small" />
<NumericUpDown Value="10" Classes="Large" />
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:disabled` | Control is disabled (`IsEnabled = false`). / 控件已禁用。 |
| `:pointerover` | Mouse is hovering over the control. / 鼠标悬停在控件上。 |
| `:focused` | The text input has keyboard focus. / 文本输入获得键盘焦点。 |

### ControlTheme Structure / 控件主题结构

The `NumericUpDown` theme wraps a `TextBox#PART_TextBox` and `ButtonSpinner#PART_Spinner`. Color classes set `Foreground` and `BorderBrush` on the `TextBox` part. The spinner buttons inside `ButtonSpinner` use `InnerButton` theme resources inherited from `Button` styling.

`NumericUpDown` 主题包装了 `TextBox#PART_TextBox` 和 `ButtonSpinner#PART_Spinner`。颜色类在 `TextBox` 部件上设置 `Foreground` 和 `BorderBrush`。`ButtonSpinner` 内部的微调按钮使用继承自 `Button` 样式的 `InnerButton` 主题资源。

### DynamicResource Keys / 动态资源键

```
NumericUpDownPrimaryForeground
NumericUpDownPrimaryBorderBrush
NumericUpDownPrimaryFocusedBorderBrush
NumericUpDownSecondaryForeground
NumericUpDownDangerBorderBrush
...
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_TextBox` | `TextBox` | The text input field displaying the formatted numeric value. / 显示格式化数值的文本输入字段。 |
| `PART_Spinner` | `ButtonSpinner` | The composite control containing the increase and decrease buttons. / 包含增加和减少按钮的复合控件。 |
| `PART_IncreaseButton` | `RepeatButton` | The up/increase spinner button. Uses `InnerButton` theme. / 增加微调按钮。使用 `InnerButton` 主题。 |
| `PART_DecreaseButton` | `RepeatButton` | The down/decrease spinner button. Uses `InnerButton` theme. / 减少微调按钮。使用 `InnerButton` 主题。 |

## FAQ / 常见问题

**Q: How do I restrict the value to whole numbers only? / 如何将值限制为仅整数？**

A: Set `Increment="1"` and `FormatString="N0"` or `"F0"`. Additionally, handle `ValueChanged` to round `Value` to the nearest integer. Avalonia's `NumericUpDown` does not have a built-in `IsIntegerOnly` property, unlike some WPF implementations.

设置 `Increment="1"` 和 `FormatString="N0"` 或 `"F0"`。此外，处理 `ValueChanged` 事件将 `Value` 四舍五入到最近的整数。与某些 WPF 实现不同，Avalonia 的 `NumericUpDown` 没有内置的 `IsIntegerOnly` 属性。

**Q: Why does my ValueChanged event fire twice when I type a value? / 为什么输入值时 ValueChanged 事件会触发两次？**

A: The event fires once when the text is committed (focus lost or Enter pressed) and once during internal value update. Use `NumericUpDownValueChangedEventArgs` to compare `OldValue` vs `NewValue` and only react when they differ meaningfully.

事件在文本提交时（焦点丢失或 Enter 按下）触发一次，内部值更新时再触发一次。使用 `NumericUpDownValueChangedEventArgs` 比较 `OldValue` 和 `NewValue`，仅在两者有实质差异时才做出响应。

**Q: How does Semi.Avalonia style the spinner buttons? / Semi.Avalonia 如何设置微调按钮样式？**

A: The increase/decrease buttons inside `PART_Spinner` are styled as `InnerButton` theme variants. They inherit the color class from the parent `NumericUpDown`, so a `Classes="Danger"` on the `NumericUpDown` flows through to the spinner button hover/press states.

`PART_Spinner` 内的增减按钮使用 `InnerButton` 主题变体进行样式设置。它们从父级 `NumericUpDown` 继承颜色类，因此 `NumericUpDown` 上的 `Classes="Danger"` 会传递到微调按钮的悬停/按下状态。
