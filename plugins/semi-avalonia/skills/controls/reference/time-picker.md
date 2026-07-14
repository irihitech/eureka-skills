---
category: Components
title: TimePicker
subtitle: 时间选择器
description: 时间选择器通过独立的小时/分钟/秒选择器提供精确的时间输入。
---

## TimePicker / 时间选择器

A time selection control that uses separate selector controls for hours, minutes, and optionally seconds. Inherits from `TemplatedControl`. Supports both 12-hour (AM/PM) and 24-hour clock formats. The user picks each time component independently, making it ideal for precise, keyboard-driven time entry in forms and scheduling applications.

时间选择控件，使用小时、分钟以及可选的秒的独立选择器。继承自 `TemplatedControl`。支持 12 小时（AM/PM）和 24 小时制两种时钟格式。用户独立选择每个时间组件，非常适合表单和日程应用中精确、键盘驱动的时间输入。

## When to Use / 何时使用

Use `TimePicker` when you need explicit hour/minute/second selection — for example, in appointment scheduling, alarm settings, time tracking, or any form field that requires a specific time of day. For simple time display (not selection), consider a formatted `TextBlock` with a binding converter. `TimePicker` pairs naturally with `DatePicker` for combined date-time input.

当你需要显式的小时/分钟/秒选择时使用 `TimePicker` —— 例如预约安排、闹钟设置、时间追踪或任何需要具体时刻的表单字段。对于简单的时间显示（而非选择），可考虑使用带绑定转换器的格式化 `TextBlock`。`TimePicker` 与 `DatePicker` 自然搭配用于日期时间组合输入。

## Basic Usage / 基本使用

```xml
<TimePicker SelectedTime="{Binding StartTime}"
            ClockIdentifier="24HourClock" />
```

```csharp
// Code-behind
var picker = new TimePicker
{
    SelectedTime = new TimeSpan(9, 0, 0), // 09:00
    ClockIdentifier = "24HourClock"
};
picker.SelectedTimeChanged += (s, e) =>
{
    // Handle time change
};
```

## Common Scenarios / 常用场景

### 12-Hour Clock with AM/PM / 12 小时制带 AM/PM

```xml
<TimePicker SelectedTime="{Binding MeetingTime}"
            ClockIdentifier="12HourClock" />
```

```csharp
// When ClockIdentifier is "12HourClock", the picker shows
// hour (1-12), minute (0-59), second (optional), and an AM/PM selector
picker.ClockIdentifier = "12HourClock";
picker.SelectedTime = new TimeSpan(14, 30, 0); // Displays as 2:30 PM
```

### Seconds Precision / 秒精度

Enable the seconds selector with `UseSeconds`:

通过 `UseSeconds` 启用秒选择器：

```xml
<TimePicker SelectedTime="{Binding LapTime}"
            ClockIdentifier="24HourClock"
            UseSeconds="True" />
```

### Minute Increment / 分钟步长

Restrict minute selection to specific intervals (e.g., every 5, 10, 15 minutes):

通过 `MinuteIncrement` 限制分钟选择到指定间隔：

```xml
<TimePicker SelectedTime="{Binding ReminderTime}"
            MinuteIncrement="15" />
<!-- Selectable minutes: 0, 15, 30, 45 -->
```

### Combined Date + Time / 日期+时间组合

Pair `DatePicker` and `TimePicker` for full date-time input:

```xml
<StackPanel Spacing="8">
    <DatePicker x:Name="datePicker"
                SelectedDate="{Binding AppointmentDate}" />
    <TimePicker SelectedTime="{Binding AppointmentTime}"
                ClockIdentifier="24HourClock" />
</StackPanel>
```

```csharp
// Combine into DateTime
var appointment = datePicker.SelectedDate?.Date + timePicker.SelectedTime;
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `SelectedTime` | `TimeSpan?` | The currently selected time. `null` when no time is selected. / 当前选中的时间。未选择时为空。 |
| `ClockIdentifier` | `string` | Clock format: `"12HourClock"` (default) or `"24HourClock"`. / 时钟格式：`"12HourClock"`（默认）或 `"24HourClock"`。 |
| `MinuteIncrement` | `int` | Interval between minute values in the selector. 0-59, default 1. / 分钟选择器中的分钟间隔。0-59，默认 1。 |
| `UseSeconds` | `bool` | Whether the seconds selector is visible. Default `false`. / 是否显示秒选择器。默认 `false`。 |
| `Watermark` | `string?` | Placeholder text when no time is selected. / 未选择时间时的占位文本。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectedTimeChanged` | Raised when `SelectedTime` changes. / 当 `SelectedTime` 变更时触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides styling for the `TimePicker` control, including the individual selector components for hours, minutes, seconds, and the optional AM/PM selector.

Semi.Avalonia 为 `TimePicker` 控件提供样式，包括小时、分钟、秒以及可选的 AM/PM 选择器组件。

### Theme Variants / 主题变体

| Theme Key / 主题键 | Appearance / 外观 |
| --- | --- |
| `{x:Type TimePicker}` (default Light) | Standard multi-selector layout. / 标准多选择器布局。 |
| `TimePickerOutline` | Outlined variant with border. / 带边框的轮廓变体。 |

```xml
<TimePicker Theme="{DynamicResource TimePickerOutline}" />
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:pointerover` | Mouse is hovering over a selector component. / 鼠标悬停在选择器组件上。 |
| `:focus` | A selector component has keyboard focus. / 选择器组件拥有键盘焦点。 |
| `:disabled` | Control is disabled (`IsEnabled = false`). / 控件已禁用。 |

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `TimePickerBackground` | Control background. / 控件背景。 |
| `TimePickerBorderBrush` | Control border brush. / 控件边框笔刷。 |
| `TimePickerForeground` | Control foreground. / 控件前景色。 |
| `TimePickerIconData` | Clock icon geometry data. / 时钟图标几何数据。 |
| `TimePickerLargeHeight` | Large control height. / 大号控件高度。 |
| `TimePickerSmallHeight` | Small control height. / 小号控件高度。 |
| `TimePickerSpacing` | Spacing between selectors. / 选择器之间的间距。 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Root` | `Panel` | Root layout. / 根布局。 |
| `PART_HourSelector` | `DateTimePickerComponentSelector` | Hour selector (1-12 for 12h, 0-23 for 24h). / 小时选择器（12 小时制为 1-12，24 小时制为 0-23）。 |
| `PART_MinuteSelector` | `DateTimePickerComponentSelector` | Minute selector. Respects `MinuteIncrement`. / 分钟选择器。遵循 `MinuteIncrement` 设置。 |
| `PART_SecondSelector` | `DateTimePickerComponentSelector` | Second selector. Hidden when `UseSeconds = false`. / 秒选择器。当 `UseSeconds = false` 时隐藏。 |
| `PART_PeriodSelector` | `DateTimePickerComponentSelector` | AM/PM selector. Hidden when `ClockIdentifier = "24HourClock"`. / AM/PM 选择器。当 `ClockIdentifier = "24HourClock"` 时隐藏。 |
| `PART_PickerContainer` | `Grid` | Container that lays out the visible selectors. / 布局可见选择器的容器。 |

## FAQ / 常见问题

**Q: How do I change from 12-hour to 24-hour clock at runtime? / 如何在运行时从 12 小时制切换到 24 小时制？**

A: Set `ClockIdentifier` to `"12HourClock"` or `"24HourClock"`. The AM/PM selector appears or disappears automatically. / 将 `ClockIdentifier` 设置为 `"12HourClock"` 或 `"24HourClock"`。AM/PM 选择器会自动显示或隐藏。

```csharp
timePicker.ClockIdentifier = "24HourClock"; // Switch to 24h
timePicker.ClockIdentifier = "12HourClock"; // Switch back to 12h with AM/PM
```

**Q: Can I restrict time selection to business hours (9 AM to 5 PM)? / 能否将时间选择限制在工作时间内（9 AM 到 5 PM）？**

A: `TimePicker` does not have built-in `MinTime`/`MaxTime` properties like `DatePicker` has `MinYear`/`MaxYear`. To enforce a time range, validate `SelectedTime` in your ViewModel or code-behind, or use `MinuteIncrement` to constrain granularity. For UI-level enforcement, consider a `ComboBox` with predefined time slots instead. / `TimePicker` 不像 `DatePicker` 有 `MinYear`/`MaxYear` 那样内置 `MinTime`/`MaxTime` 属性。如需强制时间范围，请在 ViewModel 或代码隐藏中验证 `SelectedTime`，或使用 `MinuteIncrement` 约束粒度。如需 UI 层面的强制限制，可考虑使用预设时间段列表的 `ComboBox`。

**Q: How do I initialize a TimePicker with the current time? / 如何用当前时间初始化 TimePicker？**

A: Use `DateTime.Now.TimeOfDay` to get the current `TimeSpan`: / 使用 `DateTime.Now.TimeOfDay` 获取当前 `TimeSpan`：

```csharp
timePicker.SelectedTime = DateTime.Now.TimeOfDay;
```
