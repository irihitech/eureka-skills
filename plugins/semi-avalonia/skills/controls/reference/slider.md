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
| `Orientation` | `Orientation` | `Horizontal` or `Vertical`. Toggles `:horizontal` / `:vertical` pseudo-classes. / 水平或垂直。切换 `:horizontal` / `:vertical` 伪类。 |
| `IsDirectionReversed` | `bool` | When `true`, increasing values go right-to-left or bottom-to-top. / 设为 `true` 时，增加值方向变为从右到左或从下到上。 |
| `IsSnapToTickEnabled` | `bool` | When `true`, the thumb snaps to the nearest tick. / 设为 `true` 时，滑块吸附到最近的刻度。 |
| `TickFrequency` | `double` | Interval between tick marks (0 = no ticks). / 刻度标记间隔（0 = 无刻度）。 |
| `TickPlacement` | `TickPlacement` | Where ticks appear: `None`, `TopLeft`, `BottomRight`, `Outside`. / 刻度显示位置：`None`、`TopLeft`、`BottomRight`、`Outside`。 |
| `Ticks` | `AvaloniaList<double>?` | Custom tick positions (overrides `TickFrequency`). / 自定义刻度位置（覆盖 `TickFrequency`）。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `ValueChanged` | Raised when `Value` changes. / `Value` 改变时触发。 |

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlTheme / Semi.Avalonia 控件主题

Semi.Avalonia defines the main Slider theme `{x:Type Slider}` and three sub-themes:

Semi.Avalonia 定义了 Slider 主题 `{x:Type Slider}` 和三个子主题：

| Theme / 主题 | Resource Key / 资源键 | Purpose / 用途 |
| --- | --- | --- |
| Slider | `{x:Type Slider}` | Main control theme, adapts template for `:horizontal` or `:vertical`. / 主控件主题，根据 `:horizontal` 或 `:vertical` 适配模板。 |
| Horizontal Track | `SliderHorizontalRepeatButton` | Track repeat button for horizontal orientation. / 水平方向的轨道重复按钮。 |
| Vertical Track | `SliderVerticalRepeatButton` | Track repeat button for vertical orientation. / 垂直方向的轨道重复按钮。 |
| Thumb | `SliderThumbTheme` | The draggable thumb with hover/pressed states. / 支持悬停/按下状态的可拖拽滑块。 |

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:horizontal` | Slider is in horizontal orientation (auto-toggled by `Orientation`). / 水平方向（由 `Orientation` 自动切换）。 |
| `:vertical` | Slider is in vertical orientation. / 垂直方向。 |
| `:pressed` | Thumb or track is being pressed. / 滑块或轨道被按下。 |
| `:pointerover` | Mouse is hovering over the Slider. / 鼠标悬停。 |
| `:disabled` | Slider is disabled. / 已禁用。 |

### Key Resource Keys / 关键资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `SliderBorderThickness` | Slider border thickness / 滑块控件边框粗细 |
| `SliderTrackBackground` | Track background color / 轨道背景色 |
| `SliderTrackForeground` | Filled portion of track / 轨道已填充部分 |
| `SliderTrackWidth` | Track thickness / 轨道厚度 |
| `SliderTrackCornerRadius` | Track corner radius / 轨道圆角 |
| `SliderThumbBackground` | Thumb fill color / 滑块填充色 |
| `SliderThumbBorderBrush` | Thumb border color / 滑块边框色 |
| `SliderThumbBorderThickness` | Thumb border width / 滑块边框宽度 |
| `SliderThumbCornerRadius` | Thumb corner radius / 滑块圆角 |
| `SliderThumbPointeroverBorderBrush` | Thumb border on hover / 悬停时滑块边框 |
| `SliderThumbPressedBorderBrush` | Thumb border when pressed / 按下时滑块边框 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Track` | `Track` | The track containing the thumb and repeat buttons. / 包含滑块和重复按钮的轨道。 |
| `PART_DecreaseButton` | `Button` | Button that decreases the value when clicked (repeat button). / 点击时减小值的按钮（重复按钮）。 |
| `PART_IncreaseButton` | `Button` | Button that increases the value when clicked (repeat button). / 点击时增加值的按钮（重复按钮）。 |

## FAQ / 常见问题

**Q: How do I use Slider for discrete integer values? / 如何使用 Slider 选择离散整数值？**

A: Set `TickFrequency="1"` and `IsSnapToTickEnabled="True"`, then bind `Value` to an `int` property with a value converter or use `Minimum="0" Maximum="10" TickFrequency="1"`. The slider will snap to integer positions. Alternatively, handle `ValueChanged` and round the value manually.

设置 `TickFrequency="1"` 和 `IsSnapToTickEnabled="True"`，然后将 `Value` 绑定到 `int` 属性（使用值转换器），或使用 `Minimum="0" Maximum="10" TickFrequency="1"`。滑块将吸附到整数位置。或者处理 `ValueChanged` 事件手动取整。

**Q: Why doesn't my Slider respond to keyboard arrow keys? / 为什么我的 Slider 不响应键盘方向键？**

A: `Slider` derives from `RangeBase` which handles arrow keys for `SmallChange` and PageUp/PageDown for `LargeChange`. Ensure the slider has keyboard focus (set `Focusable="True"` or tab to it). Clicking the track directly also changes value by `LargeChange`.

`Slider` 继承自 `RangeBase`，它处理方向键（`SmallChange`）和 PageUp/PageDown（`LargeChange`）。确保滑块拥有键盘焦点（设置 `Focusable="True"` 或按 Tab 键导航到它）。直接点击轨道也会按 `LargeChange` 步进。
