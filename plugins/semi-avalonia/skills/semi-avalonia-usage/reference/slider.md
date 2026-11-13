---
category: Components
title: Slider
subtitle: 滑块
description: 滑块用于在连续或离散的数值范围内选择一个值。
---

# Slider / 滑块

A control that lets the user select from a range of values by moving a Thumb along a Track. Inherits from `RangeBase` which provides `Minimum`, `Maximum`, `Value`, `SmallChange`, and `LargeChange`. Supports horizontal/vertical orientation, tick marks, snapping, and direction reversal.

允许用户通过沿轨道移动滑块来选择数值范围的控件。继承自 `RangeBase`，提供 `Minimum`、`Maximum`、`Value`、`SmallChange` 和 `LargeChange` 属性。支持水平/垂直方向、刻度标记、吸附和方向反转。

## When to Use / 何时使用

Use `Slider` for numeric input where the exact value is less important than the relative position — volume controls, brightness, zoom levels, playback position. The visual track gives immediate feedback about where the value sits in the range. For precise numeric input where the user types an exact number, use `NumericUpDown`. For progress-only display without interaction, use `ProgressBar`.

使用 `Slider` 进行数值输入，其中相对位置比精确值更重要 —— 音量控制、亮度、缩放级别、播放位置。可视化轨道能直观反馈数值在范围内的位置。需要用户输入精确数字时使用 `NumericUpDown`。仅需显示进度而无需交互时使用 `ProgressBar`。

## Basic Usage / 基本使用

```xml
<Slider Minimum="0"
        Maximum="100"
        Value="{Binding Volume}"
        Width="200" />
```

```csharp
// React to value changes
mySlider.ValueChanged += (s, e) =>
{
    double newValue = e.NewValue;
};
```

## Common Scenarios / 常用场景

### Vertical Slider / 垂直滑块

```xml
<Slider Orientation="Vertical"
        Minimum="0"
        Maximum="100"
        Height="200" />
```

### Tick Marks / 刻度标记

Enable tick marks with `TickFrequency` for discrete value selection.

```xml
<Slider Minimum="0"
        Maximum="100"
        TickFrequency="10"
        IsSnapToTickEnabled="True"
        TickPlacement="BottomRight" />
```

### Reversed Direction / 反向滑块

Set `IsDirectionReversed` for right-to-left or bottom-to-top value increase.

```xml
<Slider IsDirectionReversed="True"
        Minimum="0"
        Maximum="100" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Value` | `double` | The current value. Inherited from `RangeBase`. / 当前值。继承自 `RangeBase`。 |
| `Minimum` | `double` | The minimum allowed value (default 0). / 最小允许值（默认 0）。 |
| `Maximum` | `double` | The maximum allowed value (default 100). / 最大允许值（默认 100）。 |
| `SmallChange` | `double` | Value change on arrow key press (default 1). / 按方向键时的值变化量（默认 1）。 |
| `LargeChange` | `double` | Value change on PageUp/PageDown or track click (default 10). / PageUp/PageDown 或点击轨道时的值变化量（默认 10）。 |
| `Orientation` | `Orientation` | `Horizontal` or `Vertical`. / 水平或垂直。 |
| `IsDirectionReversed` | `bool` | When `true`, increasing values go right-to-left or bottom-to-top. / 设为 `true` 时，增加值方向变为从右到左或从下到上。 |
| `IsSnapToTickEnabled` | `bool` | When `true`, the thumb snaps to the nearest tick. / 设为 `true` 时，滑块吸附到最近的刻度。 |
| `TickFrequency` | `double` | Interval between tick marks (0 = no ticks). / 刻度标记间隔（0 = 无刻度）。 |
| `TickPlacement` | `TickPlacement` | Where ticks appear: `None`, `TopLeft`, `BottomRight`, `Outside`. / 刻度显示位置：`None`、`TopLeft`、`BottomRight`、`Outside`。 |
| `Ticks` | `AvaloniaList<double>?` | Custom tick positions (overrides `TickFrequency`). / 自定义刻度位置（覆盖 `TickFrequency`）。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `ValueChanged` | Raised when `Value` changes. / `Value` 改变时触发。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How do I use Slider for discrete integer values? / 如何使用 Slider 选择离散整数值？**

A: Set `TickFrequency="1"` and `IsSnapToTickEnabled="True"`, then bind `Value` to an `int` property with a value converter or use `Minimum="0" Maximum="10" TickFrequency="1"`. The slider will snap to integer positions. Alternatively, handle `ValueChanged` and round the value manually.

设置 `TickFrequency="1"` 和 `IsSnapToTickEnabled="True"`，然后将 `Value` 绑定到 `int` 属性（使用值转换器），或使用 `Minimum="0" Maximum="10" TickFrequency="1"`。滑块将吸附到整数位置。或者处理 `ValueChanged` 事件手动取整。

**Q: Why doesn't my Slider respond to keyboard arrow keys? / 为什么我的 Slider 不响应键盘方向键？**

A: `Slider` derives from `RangeBase` which handles arrow keys for `SmallChange` and PageUp/PageDown for `LargeChange`. Ensure the slider has keyboard focus (set `Focusable="True"` or tab to it). Clicking the track directly also changes value by `LargeChange`.

`Slider` 继承自 `RangeBase`，它处理方向键（`SmallChange`）和 PageUp/PageDown（`LargeChange`）。确保滑块拥有键盘焦点（设置 `Focusable="True"` 或按 Tab 键导航到它）。直接点击轨道也会按 `LargeChange` 步进。
