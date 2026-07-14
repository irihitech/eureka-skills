---
category: Components
title: DateTimePicker
subtitle: 日期时间选择器
description: 结合日历与时间选择器的完整日期时间输入控件，支持确认模式、黑名单日期和自定义格式。
---

## DateTimePicker / 日期时间选择器

A combined date-and-time picker that opens a dropdown with a calendar and time selector panel side by side. Inherits from `DateTimePickerBase<DateTime>`. The control supports text input with custom format strings, confirmation mode (user must click Confirm before the value is committed), and blackout date rules.

结合日历与时间选择器的完整日期时间输入控件，点击后弹出包含日历和时间选择面板的下拉框。继承自 `DateTimePickerBase<DateTime>`。支持带自定义格式字符串的文本输入、确认模式（用户需点击确认按钮才会提交值）和黑名单日期规则。

## When to Use / 何时使用

Use `DateTimePicker` when you need a single control for both date and time selection with a dropdown UI. For date-only selection, use `DatePicker` (Ursa) or `CalendarDatePicker` (Avalonia). For time-only, use `TimePicker` (Ursa). When you need confirmation before committing (e.g., in forms with expensive validation), enable `NeedConfirmation`.

当你需要一个同时选择日期和时间的下拉控件时使用 `DateTimePicker`。如果仅需日期选择，请使用 `DatePicker`（Ursa）或 `CalendarDatePicker`（Avalonia）。如果仅需时间选择，请使用 `TimePicker`（Ursa）。当你需要在提交前确认（例如具有昂贵验证的表单），请启用 `NeedConfirmation`。

## Basic Usage / 基本使用

```xml
<u:DateTimePicker SelectedDate="{Binding MyDateTime}" />
```

```csharp
// Code-behind
var picker = new DateTimePicker
{
    SelectedDate = DateTime.Now,
    DisplayFormat = "yyyy-MM-dd HH:mm:ss"
};
```

## Common Scenarios / 常用场景

### Custom Display Format / 自定义显示格式

Control how the selected date-time is displayed and parsed:

```xml
<u:DateTimePicker
    SelectedDate="{Binding EventTime}"
    DisplayFormat="yyyy年MM月dd日 HH时mm分ss秒" />
```

### Confirmation Mode / 确认模式

Require explicit confirmation before the value is committed:

```xml
<u:DateTimePicker
    SelectedDate="{Binding ConfirmedDate}"
    NeedConfirmation="True"
    DisplayFormat="yyyy-MM-dd HH:mm:ss" />
```

When `NeedConfirmation="True"`, the popup shows a Confirm button. Changes to date or time are held as pending until the user clicks Confirm. The `Confirm()` method can also be called programmatically.

### Custom Time Panel Format / 自定义时间面板格式

Control the time selector layout via `PanelFormat`:

```xml
<u:DateTimePicker
    SelectedDate="{Binding MeetingTime}"
    PanelFormat="hh mm ss" />
```

`PanelFormat` accepts a space-separated token string: `HH`/`hh` for hours, `mm` for minutes, `ss` for seconds.

### Blackout Dates / 黑名单日期

Prevent selection of specific dates:

```xml
<u:DateTimePicker SelectedDate="{Binding Date}">
    <u:DateTimePicker.BlackoutDates>
        <u:DateRange Start="2025-01-01" End="2025-01-03" />
    </u:DateTimePicker.BlackoutDates>
</u:DateTimePicker>
```

For dynamic rules, implement `IDateSelector` and bind to `BlackoutDateRule`.

### Inner Content Slots / 内嵌内容插槽

Add custom content inside the text box or popup:

```xml
<u:DateTimePicker SelectedDate="{Binding Date}">
    <u:DateTimePicker.InnerLeftContent>
        <PathIcon Data="{DynamicResource CalendarIcon}" />
    </u:DateTimePicker.InnerLeftContent>
</u:DateTimePicker>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `SelectedDate` | `DateTime?` | The currently selected date-time. Two-way binding. / 当前选中的日期时间。支持双向绑定。 |
| `DisplayFormat` | `string?` | .NET format string for display and text parsing. Default: `"yyyy-MM-dd HH:mm:ss"`. / 用于显示和文本解析的 .NET 格式字符串。 |
| `PanelFormat` | `string` | Time selector layout tokens. Default `"HH mm ss"`. / 时间选择器布局标记。 |
| `NeedConfirmation` | `bool` | When true, the popup shows a Confirm button and changes are pending until confirmed. / 设为 true 时弹出框显示确认按钮，变更需确认后生效。 |
| `IsReadOnly` | `bool` | When true, the text box is read-only and the popup is suppressed. / 设为 true 时文本框只读且不弹出下拉。 |
| `IsDropdownOpen` | `bool` | Whether the popup dropdown is open. Two-way bindable. / 下拉弹出框是否打开。支持双向绑定。 |
| `BlackoutDates` | `AvaloniaList<DateRange>` | List of date ranges that cannot be selected. / 不可选择的日期范围列表。 |
| `BlackoutDateRule` | `IDateSelector?` | Dynamic blackout rule (e.g., weekends). / 动态黑名单规则（如周末）。 |
| `FirstDayOfWeek` | `DayOfWeek` | First day shown in the calendar. / 日历中显示的每周第一天。 |
| `IsTodayHighlighted` | `bool` | Whether today's date is highlighted in the calendar. Default `true`. / 是否在日历中高亮今天。默认 `true`。 |
| `PlaceholderText` | `string?` | Placeholder text when no date is selected. / 未选择日期时显示的占位文本。 |
| `PlaceholderForeground` | `IBrush?` | Brush for placeholder text. / 占位文本的笔刷。 |
| `InnerLeftContent` | `object?` | Custom content displayed inside the text box on the left. / 文本框内左侧自定义内容。 |
| `InnerRightContent` | `object?` | Custom content displayed inside the text box on the right. / 文本框内右侧自定义内容。 |
| `PopupInnerTopContent` | `object?` | Custom content at the top of the popup. / 弹出框顶部自定义内容。 |
| `PopupInnerBottomContent` | `object?` | Custom content at the bottom of the popup. / 弹出框底部自定义内容。 |
| `DefaultDateKind` | `DateTimeKind` | The `DateTimeKind` assigned to parsed/combined values. Default `Unspecified`. / 分配给解析/组合值的 `DateTimeKind`。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectedDate` property change | Raised via `PropertyChanged` when `SelectedDate` changes. / 通过 `PropertyChanged` 在 `SelectedDate` 变更时触发。 |

### Methods / 方法

| Method / 方法 | Description / 说明 |
| --- | --- |
| `Clear()` | Clears the selected date-time. / 清除所选日期时间。 |
| `Confirm()` | Commits pending date and time when `NeedConfirmation` is true. / 当 `NeedConfirmation` 为 true 时提交待确认的日期和时间。 |
| `Dismiss()` | Closes the popup without committing changes. / 关闭弹出框但不提交更改。 |

## Styling & Templating / 样式与模板

Ursa.Avalonia provides a `ControlTheme` keyed to `DateTimePickerBase` (shared by all DateTime/Date/Time picker variants).

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_TextBox` | `TextBox` | Text input field. / 文本输入字段。 |
| `PART_Popup` | `Popup` | Dropdown popup. / 下拉弹出框。 |
| `PART_Calendar` | `DatePickerCalendarView` | Calendar component inside the popup. / 弹出框内的日历组件。 |
| `PART_TimePicker` | `TimePickerPresenter` | Time selector inside the popup. / 弹出框内的时间选择器。 |

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:empty` | Set when `SelectedDate` is null. / 当 `SelectedDate` 为空时设置。 |
| `:pointerover` | Mouse is hovering over the control. / 鼠标悬停在控件上。 |
| `:focus` / `:focus-within` | Control or its text box has focus. / 控件或其文本框获得焦点。 |
| `:disabled` | Control is disabled (`IsEnabled = false`). / 控件已禁用。 |

### Theme Resource Keys / 主题资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `CalendarDatePickerBackground` | Default background. / 默认背景。 |
| `CalendarDatePickerForeground` | Default foreground. / 默认前景色。 |
| `CalendarDatePickerBorderBrush` | Default border brush. / 默认边框笔刷。 |
| `CalendarDatePickerBorderThickness` | Border thickness. / 边框粗细。 |
| `CalendarDatePickerCornerRadius` | Corner radius. / 圆角半径。 |
| `CalendarDatePickerDefaultHeight` | Default minimum height. / 默认最小高度。 |
| `CalendarDatePickerPointeroverBackground` | Background on hover. / 悬停时的背景。 |
| `CalendarDatePickerFocusBorderBrush` | Border brush when focused. / 聚焦时的边框笔刷。 |
| `CalendarDatePickerDisabledBackground` | Background when disabled. / 禁用时的背景。 |
| `CalendarDatePickerDisabledIconForeground` | Icon foreground when disabled. / 禁用时的图标前景色。 |
| `DateTimePickerGlyph` | Path data for the calendar icon. / 日历图标的路径数据。 |
| `ComboBoxPopupBackground` / `ComboBoxPopupBorderBrush` / `ComboBoxPopupBorderThickness` / `ComboBoxPopupBoxShadow` | Popup styling. / 弹出框样式。 |
| `CalendarCornerRadius` | Calendar panel corner radius. / 日历面板圆角半径。 |
| `TextBoxPlaceholderForeground` | Placeholder text foreground. / 占位文本前景色。 |

### Size Classes / 尺寸类

| Class / 类 | Effect / 效果 |
| --- | --- |
| `Large` | Sets `MinHeight` to `TextBoxLargeHeight`. / 设置 `MinHeight` 为 `TextBoxLargeHeight`。 |
| `Small` | Sets `MinHeight` to `TextBoxSmallHeight`. / 设置 `MinHeight` 为 `TextBoxSmallHeight`。 |
| `clearButton` / `ClearButton` | Shows a clear button on hover when the text is not empty. / 文本非空时悬停显示清除按钮。 |

## FAQ / 常见问题

**Q: How is DateTimePicker different from DatePicker? / DateTimePicker 与 DatePicker 有何区别？**

A: `DateTimePicker` selects both date and time in a single dropdown with calendar + time panel. `DatePicker` selects only a date via year/month/day combo-box style selectors. Use `DateTimePicker` when you need time precision; use `DatePicker` for date-only scenarios. / `DateTimePicker` 在单个下拉框中通过日历+时间面板同时选择日期和时间。`DatePicker` 仅通过年/月/日下拉框选择日期。需要时间精度时使用 `DateTimePicker`；仅需日期时使用 `DatePicker`。

**Q: How do I customize the time selector layout? / 如何自定义时间选择器布局？**

A: Set `PanelFormat` to a space-separated token string. Valid tokens: `HH` (24-hour), `hh` (12-hour), `mm` (minutes), `ss` (seconds). For example, `"HH mm"` shows only hours and minutes. / 设置 `PanelFormat` 为空格分隔的标记字符串。有效标记：`HH`（24小时制）、`hh`（12小时制）、`mm`（分钟）、`ss`（秒）。例如 `"HH mm"` 仅显示小时和分钟。

**Q: How does NeedConfirmation mode work? / 确认模式如何工作？**

A: When `NeedConfirmation="True"`, selecting a date or time in the popup does not immediately update `SelectedDate`. The values are held as pending until the user clicks the Confirm button (or `Confirm()` is called programmatically). Dismissing the popup discards pending changes. / 当 `NeedConfirmation="True"` 时，在弹出框中选择日期或时间不会立即更新 `SelectedDate`。值将暂存为待确认状态，直到用户点击确认按钮（或程序调用 `Confirm()`）。关闭弹出框会丢弃待确认的更改。

**Q: SelectedDate is DateTime? but I need DateTimeOffset. / SelectedDate 是 DateTime?，但我需要 DateTimeOffset。**

A: Use `DateTimeOffsetPicker` instead, which extends `DateTimePickerBase<DateTimeOffset>` and returns `DateTimeOffset?`. / 请改用 `DateTimeOffsetPicker`，它继承自 `DateTimePickerBase<DateTimeOffset>` 并返回 `DateTimeOffset?`。
