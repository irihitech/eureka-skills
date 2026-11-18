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
| `PlaceholderText` | `string?` | Placeholder text when no value is entered. / 未输入值时显示的占位符文本。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `ValueChanged` | Raised after the value has changed. `NumericUpDownValueChangedEventArgs` provides `OldValue` and `NewValue`. / 数值改变后触发。`NumericUpDownValueChangedEventArgs` 提供 `OldValue` 和 `NewValue`。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How do I restrict the value to whole numbers only? / 如何将值限制为仅整数？**

A: Set `Increment="1"` and `FormatString="N0"` or `"F0"`. Additionally, handle `ValueChanged` to round `Value` to the nearest integer. Avalonia's `NumericUpDown` does not have a built-in `IsIntegerOnly` property, unlike some WPF implementations.

设置 `Increment="1"` 和 `FormatString="N0"` 或 `"F0"`。此外，处理 `ValueChanged` 事件将 `Value` 四舍五入到最近的整数。与某些 WPF 实现不同，Avalonia 的 `NumericUpDown` 没有内置的 `IsIntegerOnly` 属性。

**Q: Why does my ValueChanged event fire twice when I type a value? / 为什么输入值时 ValueChanged 事件会触发两次？**

A: The event fires once when the text is committed (focus lost or Enter pressed) and once during internal value update. Use `NumericUpDownValueChangedEventArgs` to compare `OldValue` vs `NewValue` and only react when they differ meaningfully.

事件在文本提交时（焦点丢失或 Enter 按下）触发一次，内部值更新时再触发一次。使用 `NumericUpDownValueChangedEventArgs` 比较 `OldValue` 和 `NewValue`，仅在两者有实质差异时才做出响应。

**Q: How does Semi.Avalonia style the spinner buttons? / Semi.Avalonia 如何设置微调按钮样式？**

A: The increase/decrease buttons inside `PART_Spinner` use one of Semi's inner-button ControlThemes. They inherit the color class from the parent `NumericUpDown`, so a color class set on `NumericUpDown` flows through to the spinner button hover/press states (the available classes are listed in the `semi-avalonia` skill).

A: `PART_Spinner` 内的增减按钮使用 Semi 的内部按钮 ControlTheme。它们从父级 `NumericUpDown` 继承颜色类，因此在 `NumericUpDown` 上设置的颜色类会传递到微调按钮的悬停/按下状态（可用类以 `semi-avalonia` skill 为准）。