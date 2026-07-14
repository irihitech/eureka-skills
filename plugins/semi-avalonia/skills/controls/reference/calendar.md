---
category: Components
title: Calendar
subtitle: 日历
description: 日历控件用于显示月份视图并允许用户选择单个日期或日期范围。
---

## Calendar / 日历

A month-view calendar control that displays a grid of dates and allows single-date or date-range selection. Inherits from `TemplatedControl`. Supports `SingleDate`, `SingleRange`, `MultipleRange`, and `None` selection modes. Often embedded inside `CalendarDatePicker` or used standalone for scheduling UIs.

月份视图日历控件，以网格形式显示日期，支持单日期或日期范围选择。继承自 `TemplatedControl`。支持 `SingleDate`、`SingleRange`、`MultipleRange` 和 `None` 选择模式。通常嵌入 `CalendarDatePicker` 中使用，也可独立用于日程安排界面。

## When to Use / 何时使用

Use `Calendar` when you need a full month-view date selector embedded directly in a page — for example, in a scheduling application, a booking form that shows availability across a month, or a dashboard date-range filter. For a compact date picker with a text field and dropdown, prefer `CalendarDatePicker`. For a spinner-style date input (year/month/day), use `DatePicker`.

当你需要在页面中直接嵌入完整的月份视图日期选择器时使用 `Calendar` —— 例如在日程应用、展示整月可用性的预订表单或仪表板日期范围筛选器中。对于带有文本字段和下拉菜单的紧凑型日期选择器，请使用 `CalendarDatePicker`。对于旋钮式日期输入（年/月/日），请使用 `DatePicker`。

## Basic Usage / 基本使用

```xml
<Calendar SelectedDate="{Binding SelectedDate}"
          DisplayDate="{Binding DisplayDate}"
          SelectionMode="SingleDate" />
```

```csharp
// Code-behind
var calendar = new Calendar
{
    SelectedDate = DateTime.Today,
    DisplayDate = DateTime.Today,
    SelectionMode = CalendarSelectionMode.SingleDate
};
calendar.SelectedDatesChanged += (s, e) =>
{
    // Handle selection change
};
```

## Common Scenarios / 常用场景

### Date Range Selection / 日期范围选择

```xml
<Calendar SelectionMode="SingleRange"
          SelectedDates="{Binding SelectedDates}" />
```

```csharp
// The SelectedDates collection contains the range
// e.g., user clicks Jan 5 then Jan 10
```

### Blackout Dates / 不可选日期

Restrict selectable dates using `BlackoutDates`. Useful for blocking weekends, holidays, or past dates.

使用 `BlackoutDates` 限制可选日期，常用于屏蔽周末、节假日或过去的日期。

```xml
<Calendar x:Name="bookingCalendar"
          SelectionMode="SingleDate" />
```

```csharp
// Block all dates before today
bookingCalendar.BlackoutDates.Add(
    new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1)));

// Block weekends for the next year
var end = DateTime.Today.AddYears(1);
for (var d = DateTime.Today; d <= end; d = d.AddDays(1))
{
    if (d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday)
        bookingCalendar.BlackoutDates.Add(new CalendarDateRange(d));
}
```

### Display Date Range / 显示日期范围

Restrict the navigable range of months with `DisplayDateStart` and `DisplayDateEnd`.

通过 `DisplayDateStart` 和 `DisplayDateEnd` 限制可导航的月份范围。

```xml
<Calendar DisplayDateStart="2025-01-01"
          DisplayDateEnd="2025-12-31" />
```

### Today Highlighting & Mode Switching / 今日高亮与模式切换

```xml
<StackPanel Spacing="8">
    <CheckBox IsChecked="{Binding #cal.IsTodayHighlighted}">Highlight Today</CheckBox>
    <ComboBox SelectedIndex="0"
              SelectionChanged="OnModeChanged">
        <ComboBoxItem>SingleDate</ComboBoxItem>
        <ComboBoxItem>SingleRange</ComboBoxItem>
        <ComboBoxItem>MultipleRange</ComboBoxItem>
        <ComboBoxItem>None</ComboBoxItem>
    </ComboBox>
    <Calendar x:Name="cal"
              IsTodayHighlighted="True"
              SelectionMode="SingleDate" />
</StackPanel>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `SelectedDate` | `DateTime?` | The currently selected date (SingleDate mode). / 当前选中的日期（SingleDate 模式）。 |
| `SelectedDates` | `SelectedDatesCollection` | Collection of selected dates for range modes. / 范围模式下的选中日期集合。 |
| `DisplayDate` | `DateTime` | The date that determines which month is shown. Defaults to `DateTime.Today`. / 决定显示哪个月份的日期。默认为当日。 |
| `DisplayDateStart` | `DateTime?` | Earliest navigable date. / 最早可导航日期。 |
| `DisplayDateEnd` | `DateTime?` | Latest navigable date. / 最晚可导航日期。 |
| `SelectionMode` | `CalendarSelectionMode` | `SingleDate` (default), `SingleRange`, `MultipleRange`, or `None`. / 选择模式：`SingleDate`（默认）、`SingleRange`、`MultipleRange` 或 `None`。 |
| `IsTodayHighlighted` | `bool` | Whether the today date is visibly highlighted. Default `true`. / 是否高亮显示今日日期。默认为 `true`。 |
| `BlackoutDates` | `CalendarBlackoutDatesCollection` | Collection of date ranges that are not selectable. / 不可选择的日期范围集合。 |
| `FirstDayOfWeek` | `DayOfWeek` | Which day appears as the first column. Defaults to system locale. / 哪一天作为第一列显示。默认跟随系统区域设置。 |
| `DisplayMode` | `CalendarMode` | `Month` (default), `Year`, or `Decade`. Controls the view granularity. / 显示模式：`Month`（默认）、`Year` 或 `Decade`。控制视图粒度。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectedDatesChanged` | Raised when the `SelectedDates` collection changes. / 当 `SelectedDates` 集合变更时触发。 |
| `DisplayDateChanged` | Raised when the displayed month/year changes. / 当显示的月份/年份变更时触发。 |
| `DisplayModeChanged` | Raised when `DisplayMode` changes (month → year → decade). / 当 `DisplayMode` 变更时触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia styles `Calendar` with the same theme system used across all controls. Calendar-specific styling targets the day buttons, header navigation, and month/year views.

Semi.Avalonia 使用与其他控件相同的主题系统为 `Calendar` 提供样式。日历相关样式针对日期按钮、标题导航和月/年视图。

### Theme Variants / 主题变体

| Theme Key / 主题键 | Appearance / 外观 |
| --- | --- |
| `{x:Type Calendar}` (default Light) | Subtle background, visible on hover. / 微妙背景，悬停时可见。 |
| `CalendarOutline` | Outer border with transparent inner. / 外边框，内部透明。 |

```xml
<Calendar Theme="{DynamicResource CalendarOutline}" />
```

### Pseudo-classes / 伪类

Calendar applies styling through these pseudo-classes on internal day buttons and navigation elements:

Calendar 通过以下伪类对内部日期按钮和导航元素应用样式：

| Pseudo-class / 伪类 | Applies To / 作用对象 | Description / 说明 |
| --- | --- | --- |
| `:pointerover` | Day buttons, navigation buttons | Mouse hover. / 鼠标悬停。 |
| `:pressed` | Day buttons, navigation buttons | Pressed state. / 按下状态。 |
| `:selected` | Day buttons | Currently selected date(s). / 当前选中的日期。 |
| `:today` | Today's day button | Applied when the day is today (`IsTodayHighlighted`). / 当日日期。 |
| `:inactive` | Day buttons outside current month | Days from adjacent months shown in current view. / 当前视图中的相邻月份日期。 |
| `:blackout` | Day buttons in blackout range | Non-selectable dates. / 不可选日期。 |
| `:disabled` | Entire control | When `IsEnabled = false`. / 控件禁用时。 |
| `:focus` | Entire control | Keyboard focus. / 键盘焦点。 |

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `CalendarBackground` | Calendar background. / 日历背景。 |
| `CalendarBorderBrush` | Calendar border brush. / 日历边框笔刷。 |
| `CalendarForeground` | Calendar foreground. / 日历前景色。 |
| `CalendarBlackoutBackground` | Blackout date background. / 不可选日期背景。 |
| `CalendarBlackoutForeground` | Blackout date foreground. / 不可选日期前景色。 |
| `CalendarButtonBackground` | Navigation button background. / 导航按钮背景。 |
| `CalendarButtonBorderBrush` | Navigation button border brush. / 导航按钮边框笔刷。 |
| `CalendarButtonBorderThickness` | Navigation button border thickness. / 导航按钮边框厚度。 |
| `CalendarButtonCornerRadius` | Navigation button corner radius. / 导航按钮圆角半径。 |
| `CalendarButtonFontSize` | Navigation button font size. / 导航按钮字体大小。 |
| `CalendarButtonForeground` | Navigation button foreground. / 导航按钮前景色。 |
| `CalendarButtonPointeroverBackground` | Navigation button pointerover background. / 导航按钮悬停背景。 |
| `CalendarButtonPointeroverBorderBrush` | Navigation button pointerover border brush. / 导航按钮悬停边框笔刷。 |
| `CalendarButtonPressedBackground` | Navigation button pressed background. / 导航按钮按下背景。 |
| `CalendarButtonPressedBorderBrush` | Navigation button pressed border brush. / 导航按钮按下边框笔刷。 |
| `CalendarDayButtonBackground` | Day button background. / 日期按钮背景。 |
| `CalendarDayButtonBorderBrush` | Day button border brush. / 日期按钮边框笔刷。 |
| `CalendarDayButtonBorderThickness` | Day button border thickness. / 日期按钮边框厚度。 |
| `CalendarDayButtonCornerRadius` | Day button corner radius. / 日期按钮圆角半径。 |
| `CalendarDayButtonDisabledBackground` | Day button disabled background. / 日期按钮禁用背景。 |
| `CalendarDayButtonDisabledBorderBrush` | Day button disabled border brush. / 日期按钮禁用边框笔刷。 |
| `CalendarDayButtonDisabledForeground` | Day button disabled foreground. / 日期按钮禁用前景色。 |
| `CalendarDayButtonFontSize` | Day button font size. / 日期按钮字体大小。 |
| `CalendarDayButtonForeground` | Day button foreground. / 日期按钮前景色。 |
| `CalendarDayButtonPointeroverBackground` | Day button pointerover background. / 日期按钮悬停背景。 |
| `CalendarDayButtonPointeroverBorderBrush` | Day button pointerover border brush. / 日期按钮悬停边框笔刷。 |
| `CalendarDayButtonPressedBackground` | Day button pressed background. / 日期按钮按下背景。 |
| `CalendarDayButtonPressedBorderBrush` | Day button pressed border brush. / 日期按钮按下边框笔刷。 |
| `CalendarDayButtonSelectedBackground` | Day button selected background. / 日期按钮选中背景。 |
| `CalendarDayButtonSelectedBorderBrush` | Day button selected border brush. / 日期按钮选中边框笔刷。 |
| `CalendarDayButtonSelectedPointeroverBackground` | Day button selected pointerover background. / 日期按钮选中悬停背景。 |
| `CalendarDayButtonSelectedPointeroverBorderBrush` | Day button selected pointerover border brush. / 日期按钮选中悬停边框笔刷。 |
| `CalendarDayButtonSelectedPressedBackground` | Day button selected pressed background. / 日期按钮选中按下背景。 |
| `CalendarDayButtonSelectedPressedBorderBrush` | Day button selected pressed border brush. / 日期按钮选中按下边框笔刷。 |
| `CalendarDayButtonTodayBorderBrush` | Today day button border brush. / 今日日期按钮边框笔刷。 |
| `CalendarHeaderBackground` | Header background. / 标题背景。 |
| `CalendarHeaderFontSize` | Header font size. / 标题字体大小。 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Root` | `Panel` | Root layout panel. / 根布局面板。 |
| `PART_MonthView` | `Grid` | The month-view day grid (7×6+). / 月份日期网格。 |
| `PART_HeaderButton` | `Button` | Button that shows the current month/year, triggers mode switch. / 显示当前月/年并触发模式切换的按钮。 |
| `PART_PreviousButton` | `Button` | Navigates to the previous month/year/decade. / 导航到上一个月/年/十年。 |
| `PART_NextButton` | `Button` | Navigates to the next month/year/decade. / 导航到下一个月/年/十年。 |
| `PART_YearView` | `Grid` | Year-mode view (12 months). / 年份视图（12 个月）。 |
| `PART_DecadeView` | `Grid` | Decade-mode view (10 years). / 十年视图（10 年）。 |

## FAQ / 常见问题

**Q: How do I programmatically navigate the Calendar to a specific month? / 如何通过代码将日历导航到指定月份？**

A: Set `DisplayDate` to any date within the target month. The Calendar automatically shows that month. To navigate without selecting, set `DisplayDate` while `SelectionMode` is `None`. / 将 `DisplayDate` 设为目标月份内的任意日期。日历会自动显示该月份。如需导航但不选中，可在 `SelectionMode` 为 `None` 时设置 `DisplayDate`。

```csharp
calendar.DisplayDate = new DateTime(2025, 6, 1); // Shows June 2025
```

**Q: Why are my BlackoutDates not visually distinct? / 为什么我的 BlackoutDates 在视觉上没有区别？**

A: Semi.Avalonia styles blackout dates with a reduced-opacity foreground via the `:blackout` pseudo-class. Ensure your Semi.Avalonia theme is loaded and that you're adding `CalendarDateRange` instances (not just `DateTime` values) to `BlackoutDates`. / Semi.Avalonia 通过 `:blackout` 伪类以降低透明度的前景色样式化不可选日期。请确保已加载 Semi.Avalonia 主题，并且向 `BlackoutDates` 添加的是 `CalendarDateRange` 实例（而非单独的 `DateTime` 值）。

**Q: Can I use Calendar without a CalendarDatePicker? / 能否不使用 CalendarDatePicker 直接使用 Calendar？**

A: Yes. `Calendar` is a standalone control. Use it directly when you need an always-visible month view. `CalendarDatePicker` wraps `Calendar` inside a dropdown popup for compact UIs. / 可以。`Calendar` 是独立控件。当你需要始终可见的月份视图时可直接使用。`CalendarDatePicker` 将 `Calendar` 包装在下拉弹出窗口中，适用于紧凑 UI。
