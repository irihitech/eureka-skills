---
category: Components
title: DateRangePicker
subtitle: 日期范围选择器
description: >
  Selects a start and end date range using dual calendar views. The picker uses
  a two-step flow: first click selects the start date from the left calendar,
  then the end date from the right calendar. Uses `DateTime` with configurable
  `DefaultDateKind` (Unspecified, Utc, Local). Binds `SelectedStartDate` and
  `SelectedEndDate` two-way.
  使用双日历视图选择起止日期范围。选择器使用两步流程：第一次点击从左日历选择
  起始日期，然后从右日历选择结束日期。使用 `DateTime` 并支持可配置的
  `DefaultDateKind`（Unspecified、Utc、Local）。双向绑定 `SelectedStartDate`
  和 `SelectedEndDate`。
---

# DateRangePicker / 日期范围选择器

## When to Use / 何时使用

Use `DateRangePicker` when users need to select a date range (e.g., hotel check-in
to check-out, project start to end, report period). It presents two calendars
side-by-side in a dropdown popup, with a text input area showing
"Start date ~ End date".

当用户需要选择日期范围时使用 `DateRangePicker`（例如酒店入住到退房、项目开始到
结束、报表周期）。它在下拉弹出框中并排显示两个日历，文本输入区显示
"开始日期 ~ 结束日期"。

Do NOT use `DateRangePicker` for single-date selection — use `DatePicker` or
`DateOffsetPicker`. Do NOT use it when you need time-of-day — this control
only handles dates (no time component).

不要使用 `DateRangePicker` 选择单个日期——应使用 `DatePicker` 或 `DateOffsetPicker`。
不要用它选择具体时间——此控件仅处理日期（无时间组件）。

## Basic Usage / 基本使用

### Default / 默认

```xml
xmlns:u="https://irihi.tech/ursa"

<u:DateRangePicker Width="360" />
```

### With custom display format / 带自定义显示格式

```xml
<u:DateRangePicker Width="360" DisplayFormat="yyyy/MM/dd" />
```

### Two-way binding / 双向绑定

```xml
<u:DateRangePicker Width="360"
                   SelectedStartDate="{Binding StartDate, Mode=TwoWay}"
                   SelectedEndDate="{Binding EndDate, Mode=TwoWay}" />
```

### With DefaultDateKind / 带 DefaultDateKind

```xml
<u:DateRangePicker Width="360"
                   DefaultDateKind="Utc"
                   SelectedStartDate="{Binding StartDate}"
                   SelectedEndDate="{Binding EndDate}" />
```

### Read-only with pre-set values / 带预设值的只读模式

```xml
<u:DateRangePicker Width="360"
                   IsReadOnly="True"
                   SelectedStartDate="2025-06-26"
                   SelectedEndDate="2025-06-30" />
```

### Clear button / 清除按钮

```xml
<u:DateRangePicker Width="360" Classes="ClearButton" />
```

## Common Scenarios / 常用场景

### 1. Vacation booking range / 假期预订范围

```xml
<u:DateRangePicker Width="360"
                   DisplayFormat="yyyy-MM-dd"
                   SelectedStartDate="{Binding CheckInDate, Mode=TwoWay}"
                   SelectedEndDate="{Binding CheckOutDate, Mode=TwoWay}" />
```

### 2. Custom placeholder text / 自定义占位文本

```xml
<u:DateRangePicker Width="360"
                   StartPlaceholderText="Check-in"
                   EndPlaceholderText="Check-out" />
```

### 3. Blackout dates / 不可选日期

```xml
<u:DateRangePicker Width="360">
    <u:DateRangePicker.BlackoutDates>
        <u:DateRange Start="2025-07-01" End="2025-07-05" />
        <u:DateRange Start="2025-07-10" End="2025-07-10" />
    </u:DateRangePicker.BlackoutDates>
</u:DateRangePicker>
```

### 4. Popup additional content / 弹出框附加内容

```xml
<u:DateRangePicker Width="360" SelectedStartDate="{Binding StartDate}"
                   SelectedEndDate="{Binding EndDate}">
    <u:DateRangePicker.PopupInnerTopContent>
        <TextBlock Text="Select your travel dates" FontWeight="Bold" />
    </u:DateRangePicker.PopupInnerTopContent>
</u:DateRangePicker>
```

## How the Two-Calendar Flow Works / 双日历流程工作原理

1. User clicks the start text box or the picker body → left calendar receives focus.
   The left calendar shows the current month; the right shows the following month.

2. User selects a date from either calendar → this becomes `SelectedStartDate`.
   Focus automatically moves to the end text box. The right calendar adjusts
   to show the month after the selected start date.

3. User selects a second date → this becomes `SelectedEndDate`.
   Both calendars update their highlight ranges and the popup closes.

4. If the selected end date is before the start date, the start date is cleared
   and the user must re-select. The status resets so you can restart the flow.

1. 用户点击开始文本框或选择器主体 → 左日历获得焦点。左日历显示当前月份；
   右日历显示下个月。

2. 用户从任一日历选择日期 → 这成为 `SelectedStartDate`。焦点自动移到结束文本框。
   右日历调整为显示所选开始日期之后的月份。

3. 用户选择第二个日期 → 这成为 `SelectedEndDate`。两个日历更新其高亮范围，
   弹出框关闭。

4. 如果选择的结束日期早于开始日期，开始日期将被清除，用户需要重新选择。
   状态重置以便重新开始流程。

## Property Reference / 属性参考

### DateRangePicker Properties / DateRangePicker 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedStartDate` | `DateTime?` | `null` | Start date of range (two-way) / 范围的开始日期（双向绑定） |
| `SelectedEndDate` | `DateTime?` | `null` | End date of range (two-way) / 范围的结束日期（双向绑定） |
| `DisplayFormat` | `string?` | `"yyyy-MM-dd"` | Date display format for both text boxes / 两个文本框的日期显示格式 |
| `DefaultDateKind` | `DateTimeKind` | `Unspecified` | Kind applied to parsed/created DateTime values / 应用于解析/创建的 DateTime 值的 Kind |
| `IsReadOnly` | `bool` | `false` | Disable editing / 禁用编辑 |
| `IsDropdownOpen` | `bool` | `false` | Whether the popup is open (two-way) / 弹出框是否打开（双向绑定） |
| `FirstDayOfWeek` | `DayOfWeek` | (culture) | First day of week in both calendars / 两个日历中的每周第一天 |
| `IsTodayHighlighted` | `bool` | `true` | Highlight today in calendars / 在日历中高亮今天 |
| `StartPlaceholderText` | `string?` | `"Start date"` | Placeholder for start text box / 开始文本框的占位文本 |
| `EndPlaceholderText` | `string?` | `"End date"` | Placeholder for end text box / 结束文本框的占位文本 |
| `PlaceholderForeground` | `IBrush?` | (theme) | Foreground of placeholder text / 占位文本的前景色 |
| `BlackoutDates` | `AvaloniaList<DateRange>` | (empty) | Disallowed date ranges / 不可选择的日期范围 |
| `BlackoutDateRule` | `IDateSelector?` | `null` | Rule-based blackout dates / 基于规则的不可选日期 |
| `InnerLeftContent` | `object?` | `null` | Content in the left side of the start text box / 开始文本框左侧的内容 |
| `InnerRightContent` | `object?` | `null` | Content in the right side of the end text box / 结束文本框右侧的内容 |
| `PopupInnerTopContent` | `object?` | `null` | Content above the calendars in the popup / 弹出框中日历上方的内容 |
| `PopupInnerBottomContent` | `object?` | `null` | Content below the calendars in the popup / 弹出框中日历下方的内容 |

### Methods / 方法

| Method | Description / 说明 |
|---|---|
| `Clear()` | Resets both `SelectedStartDate` and `SelectedEndDate` to `null` / 将 `SelectedStartDate` 和 `SelectedEndDate` 都重置为 `null` |

### DateRange Struct / DateRange 结构

Used by `BlackoutDates`. A simple inclusive date range for blackout specification.

| Property | Type | Description / 说明 |
|---|---|---|
| `Start` | `DateTime` | Start date (date portion only) / 开始日期（仅日期部分） |
| `End` | `DateTime` | End date (date portion only) / 结束日期（仅日期部分） |

| Constructor | Description / 说明 |
|---|---|
| `DateRange(DateTime day)` | Single-day range / 单日范围 |
| `DateRange(DateTime start, DateTime end)` | Multi-day range; end clamped to start if earlier / 多日范围；若 end 早于 start 则钳制为 start |

## Styling & Templating / 样式与模板

### Style Classes / 样式类

| Class | Effect |
|---|---|
| `ClearButton` | Shows a clear button on hover when at least one date is set / 至少设置一个日期时悬停显示清除按钮 |
| `Large` | Increases `MinHeight` to `TextBoxLargeHeight` / 将 `MinHeight` 增大到 `TextBoxLargeHeight` |
| `Small` | Decreases `MinHeight` to `TextBoxSmallHeight` / 将 `MinHeight` 减小到 `TextBoxSmallHeight` |

### Theme Resources / 主题资源

DateRangePicker uses `DateRangePickerBase` theme key. Standard TextBox resources apply:

| Resource Key | Applies To | Description |
|---|---|---|
| `TextBoxDefaultBackground` | Background | Default background / 默认背景 |
| `TextBoxForeground` | Text | Default text color / 默认文字颜色 |
| `TextBoxDefaultBorderBrush` | Border | Default border brush / 默认边框画刷 |
| `TextBoxBorderThickness` | Border | Border thickness / 边框粗细 |
| `TextBoxDefaultCornerRadius` | Border | Corner radius / 圆角 |
| `TextBoxPlaceholderForeground` | Placeholder | Placeholder text color / 占位文字颜色 |
| `ComboBoxPopupBackground` | Popup | Popup background / 弹出框背景 |
| `ComboBoxPopupBorderBrush` | Popup border | Popup border brush / 弹出框边框画刷 |
| `ComboBoxPopupBorderThickness` | Popup border | Popup border thickness / 弹出框边框粗细 |
| `ComboBoxPopupBoxShadow` | Popup | Popup box shadow / 弹出框阴影 |
| `CalendarCornerRadius` | Popup border | Popup corner radius / 弹出框圆角 |
| `CalendarDatePickerFocusBorderBrush` | Focused | Focus border brush / 聚焦边框画刷 |
| `CalendarDatePickerDisabledBackground` | Disabled | Disabled background / 禁用背景 |
| `CalendarDatePickerIconGlyph` | Calendar icon | Calendar icon path data / 日历图标路径数据 |

### Template Parts / 模板部件

| Part Name | Type | Description |
|---|---|---|
| `PART_Popup` | `Popup` | The dropdown popup / 下拉弹出框 |
| `PART_StartCalendar` | `DatePickerCalendarView` | Left calendar view / 左日历视图 |
| `PART_EndCalendar` | `DatePickerCalendarView` | Right calendar view / 右日历视图 |
| `PART_StartTextBox` | `TextBox` | Start date text input / 开始日期文本输入 |
| `PART_EndTextBox` | `TextBox` | End date text input / 结束日期文本输入 |

## API Reference / API 参考

- **Namespace**: `Ursa.Controls`
- **Base class**: `DateRangePickerBase<DateTime>` → `DateRangePickerBase` → `TemplatedControl`
- **Style key override**: `typeof(DateRangePickerBase)` (shares theme with `DateOnlyRangePicker`)
- **Interfaces**: `IInnerContentControl`, `IPopupInnerContent`, `IClearControl`

## FAQ / 常见问题

**Q: How do I set the default kind to UTC? / 如何将默认 Kind 设置为 UTC？**
A: Set `DefaultDateKind="Utc"`. This applies `DateTime.SpecifyKind` to parsed
inputs and internally-created date values.

**Q: What happens if the end date is before the start date? / 如果结束日期早于开始日期会怎样？**
A: The start date is cleared (`null`), and the flow resets. The end date is also
cleared if you try to confirm an invalid range.

**Q: Can I bind only the start date? / 可以只绑定开始日期吗？**
A: Yes — you can bind `SelectedStartDate` and leave `SelectedEndDate` unbound
(or bind only one of them). The other value remains independently settable.

**Q: How do I change the separator text? / 如何更改分隔符文字？**
A: The "~" separator is defined in the template. Override the
`DateRangePickerBase` theme to change or replace it.
