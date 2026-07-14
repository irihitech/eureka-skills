---
category: Components
title: CalendarDatePicker
subtitle: 日历日期选择器
description: 日历日期选择器结合了文本输入框与下拉日历，用于紧凑的日期选择。
---

## CalendarDatePicker / 日历日期选择器

A compact date picker that combines a text field displaying the selected date with a dropdown `Calendar` for visual date selection. Inherits from `TemplatedControl`. The user can either type a date directly into the text field or click the dropdown button to pick from a calendar view. Supports custom date format strings and date range constraints.

紧凑型日期选择器，将显示所选日期的文本字段与下拉 `Calendar` 结合，用于可视化日期选择。继承自 `TemplatedControl`。用户可以直接在文本字段中输入日期，也可以点击下拉按钮从日历视图中选择。支持自定义日期格式字符串和日期范围约束。

## When to Use / 何时使用

Use `CalendarDatePicker` when you need a compact date input in a form or dialog — it saves space by showing the text field inline and the calendar only on demand. Ideal for date-of-birth fields, filter date inputs, and any single-date form field where screen real estate is limited. For an always-visible calendar, use `Calendar`. For a spinner-style year/month/day selector, use `DatePicker`.

当你在表单或对话框中需要紧凑的日期输入时使用 `CalendarDatePicker` —— 它通过内联显示文本字段、按需显示日历来节省空间。非常适合出生日期字段、筛选日期输入以及任何屏幕空间有限的单日期表单字段。对于始终可见的日历，请使用 `Calendar`。对于旋钮式的年/月/日选择器，请使用 `DatePicker`。

## Basic Usage / 基本使用

```xml
<CalendarDatePicker SelectedDate="{Binding DateOfBirth}"
                    Watermark="Select a date"
                    SelectedDateFormat="Short" />
```

```csharp
// Code-behind
var picker = new CalendarDatePicker
{
    SelectedDate = DateTime.Today,
    Watermark = "Select a date",
    SelectedDateFormat = CalendarDatePickerFormat.Short
};
picker.SelectedDateChanged += (s, e) =>
{
    // Handle new date
};
```

## Common Scenarios / 常用场景

### Date Range Constraints / 日期范围约束

Restrict pickable dates with `DisplayDateStart` and `DisplayDateEnd`. Dates outside the range are grayed out in the dropdown calendar and rejected if typed.

通过 `DisplayDateStart` 和 `DisplayDateEnd` 限制可选日期。范围外的日期在下拉日历中灰显，手动输入也会被拒绝。

```xml
<CalendarDatePicker SelectedDate="{Binding BookingDate}"
                    DisplayDateStart="2025-01-01"
                    DisplayDateEnd="2025-12-31"
                    SelectedDateFormat="Long" />
```

### Custom Date Format / 自定义日期格式

```xml
<CalendarDatePicker SelectedDate="{Binding Date}"
                    CustomDateFormatString="yyyy-MM-dd" />
```

```csharp
picker.CustomDateFormatString = "yyyy年MM月dd日";
```

### Blackout Dates / 不可选日期

```xml
<CalendarDatePicker x:Name="businessDayPicker"
                    SelectedDateFormat="Short" />
```

```csharp
// Block weekends
var end = DateTime.Today.AddYears(1);
for (var d = DateTime.Today; d <= end; d = d.AddDays(1))
{
    if (d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday)
        businessDayPicker.BlackoutDates.Add(new CalendarDateRange(d));
}
```

### Validation Error Handling / 验证错误处理

Handle `DateValidationError` when the user types an invalid date.

```xml
<CalendarDatePicker x:Name="datePicker"
                    DateValidationError="OnDateValidationError" />
```

```csharp
private void OnDateValidationError(object? sender,
    CalendarDatePickerDateValidationErrorEventArgs e)
{
    // e.Text contains the invalid text
    // e.Exception contains the parse exception
    // Set e.ThrowException = false to suppress the exception
    e.ThrowException = false;
    // Optionally show a tooltip or error message
}
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `SelectedDate` | `DateTime?` | The currently selected date. `null` when no date is selected. / 当前选中的日期。未选择时为空。 |
| `DisplayDate` | `DateTime` | The month shown in the dropdown calendar. Defaults to `DateTime.Today` or `SelectedDate`. / 下拉日历中显示的月份。默认为当日或 `SelectedDate`。 |
| `DisplayDateStart` | `DateTime?` | Earliest selectable date. / 最早可选日期。 |
| `DisplayDateEnd` | `DateTime?` | Latest selectable date. / 最晚可选日期。 |
| `IsDropDownOpen` | `bool` | Whether the calendar dropdown is currently open. Two-way bindable. / 日历下拉是否打开。支持双向绑定。 |
| `SelectedDateFormat` | `CalendarDatePickerFormat` | How the selected date is formatted in the text field: `Short`, `Long`, or `Custom`. / 文本字段中选中日期的格式：`Short`、`Long` 或 `Custom`。 |
| `CustomDateFormatString` | `string?` | Custom .NET date format string, used when `SelectedDateFormat = Custom`. / 自定义 .NET 日期格式字符串，当 `SelectedDateFormat` 为 `Custom` 时使用。 |
| `Watermark` | `string?` | Placeholder text displayed when no date is selected. / 未选择日期时显示的占位文本。 |
| `Text` | `string?` | The raw text displayed in the text field. Read the current display text. / 文本字段中显示的原始文本。可读取当前显示文本。 |
| `BlackoutDates` | `CalendarBlackoutDatesCollection` | Collection of date ranges not selectable in the dropdown. / 下拉菜单中不可选的日期范围集合。 |
| `IsTodayHighlighted` | `bool` | Whether today is highlighted in the dropdown calendar. / 下拉日历中是否高亮今日。 |
| `FirstDayOfWeek` | `DayOfWeek` | First day of the week column. / 周的第一列。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectedDateChanged` | Raised when `SelectedDate` changes (pick or clear). / 当 `SelectedDate` 变更（选择或清除）时触发。 |
| `CalendarOpened` | Raised when the dropdown calendar opens. / 当下拉日历打开时触发。 |
| `CalendarClosed` | Raised when the dropdown calendar closes. / 当下拉日历关闭时触发。 |
| `DateValidationError` | Raised when the user types an invalid date string. / 当用户输入无效日期字符串时触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia styles `CalendarDatePicker` with a consistent text-field-plus-dropdown-button appearance. The internal `Calendar` uses its own theme.

Semi.Avalonia 为 `CalendarDatePicker` 提供了一致的文本字段加下拉按钮外观。内部的 `Calendar` 使用自己的主题。

### Theme Variants / 主题变体

| Theme Key / 主题键 | Appearance / 外观 |
| --- | --- |
| `{x:Type CalendarDatePicker}` (default Light) | Standard text field with calendar icon button. / 标准文本字段配日历图标按钮。 |
| `CalendarDatePickerOutline` | Text field with border outline, transparent fill. / 带边框轮廓、透明填充的文本字段。 |

```xml
<CalendarDatePicker Theme="{DynamicResource CalendarDatePickerOutline}" />
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:pointerover` | Mouse is hovering over the control. / 鼠标悬停在控件上。 |
| `:focus` | The text field has keyboard focus. / 文本字段拥有键盘焦点。 |
| `:disabled` | Control is disabled (`IsEnabled = false`). / 控件已禁用。 |
| `:dropdown-open` | The calendar dropdown is open (`IsDropDownOpen = true`). / 日历下拉已打开。 |
| `:invalid` | The text field contains an unparseable date string. / 文本字段包含无法解析的日期字符串。 |

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `CalendarDatePickerBackground` | Control background. / 控件背景。 |
| `CalendarDatePickerBorderBrush` | Control border brush. / 控件边框笔刷。 |
| `CalendarDatePickerForeground` | Control foreground. / 控件前景色。 |
| `CalendarDatePickerFocusBorderBrush` | Focus border brush. / 聚焦边框笔刷。 |
| `CalendarDatePickerFocusForeground` | Focus foreground. / 聚焦前景色。 |
| `CalendarDatePickerButtonBackground` | Dropdown button background. / 下拉按钮背景。 |
| `CalendarDatePickerButtonForeground` | Dropdown button foreground. / 下拉按钮前景色。 |
| `CalendarDatePickerButtonHeight` | Dropdown button height. / 下拉按钮高度。 |
| `CalendarDatePickerButtonWidth` | Dropdown button width. / 下拉按钮宽度。 |
| `CalendarDatePickerDefaultHeight` | Default control height. / 默认控件高度。 |
| `CalendarDatePickerLargeHeight` | Large control height. / 大号控件高度。 |
| `CalendarDatePickerSmallHeight` | Small control height. / 小号控件高度。 |
| `CalendarDatePickerIconData` | Calendar icon geometry data. / 日历图标几何数据。 |
| `CalendarDatePickerPlaceholderForeground` | Placeholder text foreground. / 占位文本前景色。 |
| `CalendarDatePickerSelectedForeground` | Selected date foreground. / 选中日期前景色。 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Root` | `Panel` | Root layout. / 根布局。 |
| `PART_TextBox` | `TextBox` | Text field for date display and manual input. / 用于日期显示和手动输入的文本字段。 |
| `PART_Button` | `Button` | Dropdown toggle button with calendar icon. / 带日历图标的下拉切换按钮。 |
| `PART_Popup` | `Popup` | The popup container for the calendar. / 日历的弹出容器。 |
| `PART_Calendar` | `Calendar` | The embedded calendar control for visual date picking. / 用于可视化日期选择的嵌入式日历控件。 |

## FAQ / 常见问题

**Q: How do I clear the selected date programmatically? / 如何通过代码清除已选日期？**

A: Set `SelectedDate = null`. The text field will show the `Watermark` text. / 设置 `SelectedDate = null`。文本字段将显示 `Watermark` 占位文本。

```csharp
picker.SelectedDate = null;
```

**Q: How does CalendarDatePicker differ from DatePicker? / CalendarDatePicker 与 DatePicker 有何区别？**

A: `CalendarDatePicker` shows a text field with a calendar dropdown — the user types or picks a date. `DatePicker` shows separate spinners/combo-boxes for year, month, and day. Choose `CalendarDatePicker` for compact single-date inputs; choose `DatePicker` when you want explicit year/month/day selection without a calendar grid. / `CalendarDatePicker` 显示带有日历下拉的文本字段 —— 用户可以输入或选择日期。`DatePicker` 显示年/月/日的独立选择器。选择 `CalendarDatePicker` 用于紧凑的单日期输入；当你需要不依赖日历网格的显式年/月/日选择时选择 `DatePicker`。

**Q: The dropdown calendar doesn't respond to theme changes. Why? / 下拉日历不响应主题更改，为什么？**

A: The embedded `Calendar` inside the `Popup` may use a different visual tree. Ensure your Semi.Avalonia theme resources are applied application-wide, not scoped to a specific `Window` or `UserControl`. Popup children are hosted in a separate visual root and may not inherit styles from the parent tree. / `Popup` 内部嵌入的 `Calendar` 可能使用不同的可视树。请确保 Semi.Avalonia 主题资源是应用全局应用的，而非限定在特定 `Window` 或 `UserControl` 范围内。Popup 的子元素托管在独立的可视根中，可能不会从父树继承样式。
