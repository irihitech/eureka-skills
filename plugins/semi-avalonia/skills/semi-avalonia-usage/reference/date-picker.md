---
category: Components
title: DatePicker
subtitle: 日期选择器
description: 日期选择器通过独立的年/月/日选择器提供精确的日期输入。
---

## DatePicker / 日期选择器

A date selection control that uses separate selector controls for year, month, and day — typically combo-boxes or spinner-style lists. Inherits from `TemplatedControl`. Unlike `CalendarDatePicker`, it does not embed a calendar grid; the user picks each date component independently. This makes it ideal for scenarios where precise, keyboard-driven date entry is preferred.

日期选择控件，使用年、月、日的独立选择器 —— 通常是下拉框或旋钮式列表。继承自 `TemplatedControl`。与 `CalendarDatePicker` 不同，它不嵌入日历网格；用户独立选择每个日期组件。这使其非常适合需要精确、键盘驱动的日期输入场景。

## When to Use / 何时使用

Use `DatePicker` when you need explicit year/month/day selection without a calendar grid — for example, in locale-independent forms, accessibility-focused UIs, or when you want to show/hide specific components (e.g., year-only selection). For a compact text-field-plus-calendar-dropdown approach, use `CalendarDatePicker`. For an always-visible full calendar, use `Calendar`.

当你需要不依赖日历网格的显式年/月/日选择时使用 `DatePicker` —— 例如与区域无关的表单、注重无障碍的界面，或需要显示/隐藏特定组件（如仅选年份）。对于紧凑的文本字段加日历下拉方式，请使用 `CalendarDatePicker`。对于始终可见的完整日历，请使用 `Calendar`。

## Basic Usage / 基本使用

```xml
<DatePicker SelectedDate="{Binding DateOfBirth}" />
```

```csharp
// Code-behind
var picker = new DatePicker
{
    SelectedDate = DateTime.Today
};
picker.SelectedDateChanged += (s, e) =>
{
    // Handle date change
};
```

## Common Scenarios / 常用场景

### Show/Hide Date Components / 显示/隐藏日期组件

Control which date parts are visible. Useful for year-only or month-year selection.

控制哪些日期部分可见。适用于仅选年份或月-年选择。

```xml
<!-- Year-Month only -->
<DatePicker SelectedDate="{Binding ExpiryDate}"
            DayVisible="False"
            MonthVisible="True"
            YearVisible="True" />

<!-- Year only -->
<DatePicker SelectedDate="{Binding Year}"
            DayVisible="False"
            MonthVisible="False"
            YearVisible="True" />
```

### Year Range Constraints / 年份范围约束

Limit the selectable year range with `MinYear` and `MaxYear`.

通过 `MinYear` 和 `MaxYear` 限制可选年份范围。

```xml
<DatePicker SelectedDate="{Binding BirthDate}"
            MinYear="1900"
            MaxYear="2025" />
```

### Custom Date Format in Display / 自定义显示格式

Control how the selected date is displayed via `SelectedDateFormat`:

```xml
<DatePicker SelectedDate="{Binding Date}"
            SelectedDateFormat="Long" />
<!-- Options: Short, Long, Custom -->
```

```xml
<DatePicker SelectedDate="{Binding Date}"
            CustomDateFormatString="yyyy-MM-dd (dddd)" />
```

### Watermark / 占位文本

```xml
<DatePicker SelectedDate="{Binding OptionalDate}"
            Watermark="Please select a date" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `SelectedDate` | `DateTimeOffset?` | The currently selected date. `null` when no date is selected. / 当前选中的日期。未选择时为空。注意类型为 `DateTimeOffset?`。 |
| `DayVisible` | `bool` | Whether the day selector is visible. Default `true`. / 日选择器是否可见。默认 `true`。 |
| `MonthVisible` | `bool` | Whether the month selector is visible. Default `true`. / 月选择器是否可见。默认 `true`。 |
| `YearVisible` | `bool` | Whether the year selector is visible. Default `true`. / 年选择器是否可见。默认 `true`。 |
| `MinYear` | `DateTimeOffset` | Earliest selectable year. Default is `DateTimeOffset.MinValue`. / 最早可选年份。默认为 `DateTimeOffset.MinValue`。 |
| `MaxYear` | `DateTimeOffset` | Latest selectable year. Default is `DateTimeOffset.MaxValue`. / 最晚可选年份。默认为 `DateTimeOffset.MaxValue`。 |
| `SelectedDateFormat` | `DatePickerFormat` | Display format: `Short`, `Long`, or `Custom`. / 显示格式：`Short`、`Long` 或 `Custom`。 |
| `CustomDateFormatString` | `string?` | Custom .NET format string, used when `SelectedDateFormat = Custom`. / 自定义 .NET 格式字符串，当 `SelectedDateFormat` 为 `Custom` 时使用。 |
| `Watermark` | `string?` | Placeholder text shown when no date is selected. / 未选择日期时显示的占位文本。 |
| `DayFormat` | `string` | Format string for day values. Default `"%d"`. / 日期值的格式化字符串。默认 `"%d"`。 |
| `MonthFormat` | `string` | Format string for month values. Default `"MMM"`. / 月份值的格式化字符串。默认 `"MMM"`。 |
| `YearFormat` | `string` | Format string for year values. Default `"yyyy"`. / 年份值的格式化字符串。默认 `"yyyy"`。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectedDateChanged` | Raised when `SelectedDate` changes. / 当 `SelectedDate` 变更时触发。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How do I use DatePicker when I only need a year selector? / 只选年份时如何使用 DatePicker？**

A: Set `DayVisible="False"` and `MonthVisible="False"`, keeping only `YearVisible="True"`. The control collapses to a single year selector. `SelectedDate` still holds a full `DateTimeOffset`, but only the year portion is relevant. / 设置 `DayVisible="False"` 和 `MonthVisible="False"`，仅保留 `YearVisible="True"`。控件会折叠为单个年份选择器。`SelectedDate` 仍然保存完整的 `DateTimeOffset`，但仅年份部分有效。

```xml
<DatePicker YearVisible="True" DayVisible="False" MonthVisible="False" />
```

**Q: What's the difference between DatePicker and CalendarDatePicker? / DatePicker 与 CalendarDatePicker 有何区别？**

A: `DatePicker` uses independent year/month/day selector controls (combo-box style). `CalendarDatePicker` uses a text field with a calendar dropdown. Use `DatePicker` when you want explicit, keyboard-accessible selectors without a calendar grid. Use `CalendarDatePicker` when you want a compact text field that opens a visual calendar on demand. / `DatePicker` 使用独立的年/月/日选择器控件（下拉框形式）。`CalendarDatePicker` 使用带有日历下拉的文本字段。当你需要不依赖日历网格的显式、键盘可访问选择器时使用 `DatePicker`。当你需要可打开可视化日历的紧凑文本字段时使用 `CalendarDatePicker`。

**Q: SelectedDate on DatePicker is DateTimeOffset? but I need DateTime. / DatePicker 的 SelectedDate 是 DateTimeOffset?，但我需要 DateTime。**

A: Yes, `DatePicker.SelectedDate` is `DateTimeOffset?` while `CalendarDatePicker.SelectedDate` is `DateTime?`. Use `.DateTime` or `.LocalDateTime` on the `DateTimeOffset` to extract a `DateTime`. This design choice ensures timezone-aware date handling. / 是的，`DatePicker.SelectedDate` 是 `DateTimeOffset?`，而 `CalendarDatePicker.SelectedDate` 是 `DateTime?`。可通过 `.DateTime` 或 `.LocalDateTime` 从 `DateTimeOffset` 提取 `DateTime`。这一设计选择确保了时区感知的日期处理。

```csharp
DateTime date = picker.SelectedDate?.DateTime ?? DateTime.Today;
```
