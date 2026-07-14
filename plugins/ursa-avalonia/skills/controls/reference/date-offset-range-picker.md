---
category: Components
title: DateOffsetRangePicker
subtitle: 日期偏移范围选择器
description: >
  A date range picker with UTC offset selection. Combines the dual-calendar
  range selection of `DateRangePickerBase<T>` with the offset combo of offset
  pickers. Uses `DateTimeOffset` for `SelectedStartDate` / `SelectedEndDate`
  two-way binding. Supports `OffsetDefinitions`, `SelectedOffset`, and
  `ShowOffsetSelection`.
  带 UTC 偏移选择的日期范围选择器。结合了 `DateRangePickerBase<T>` 的双日历
  范围选择和偏移选择器的偏移下拉框。使用 `DateTimeOffset` 进行
  `SelectedStartDate` / `SelectedEndDate` 双向绑定。支持 `OffsetDefinitions`、
  `SelectedOffset` 和 `ShowOffsetSelection`。
---

# DateOffsetRangePicker / 日期偏移范围选择器

## When to Use / 何时使用

Use `DateOffsetRangePicker` when you need a date range picker where each date
carries a UTC offset — for example, selecting multi-day event dates across
timezones, or booking a trip with departure and return dates in a specific
offset. It combines dual calendars with an offset selection combo box.

当需要每个日期都携带 UTC 偏移的日期范围选择器时使用 `DateOffsetRangePicker`
——例如选择跨时区的多日活动日期，或预订特定偏移的出发和返回日期。它结合了
双日历和偏移选择下拉框。

Do NOT use `DateOffsetRangePicker` when offsets are irrelevant — use
`DateRangePicker` (DateTime) or `DateOnlyRangePicker` (DateOnly). Do NOT use
it for time-of-day selection — it only handles dates.

在偏移无关时不要使用——应使用 `DateRangePicker`（DateTime）或
`DateOnlyRangePicker`（DateOnly）。不要用它选择具体时间——它仅处理日期。

## Basic Usage / 基本使用

### Default (Local offset) / 默认（本地偏移）

```xml
xmlns:u="https://irihi.tech/ursa"

<u:DateOffsetRangePicker Width="400" DisplayFormat="yyyy-MM-dd" />
```

### With custom offsets / 带自定义偏移

```xml
<u:DateOffsetRangePicker Width="400" DisplayFormat="yyyy-MM-dd">
    <u:DateOffsetRangePicker.OffsetDefinitions>
        <u:OffsetDefinitions>
            <u:OffsetDefinition Offset="UTC" />
            <u:OffsetDefinition Offset="Local" />
            <u:OffsetDefinition DisplayName="Beijing (CST)" Offset="+08:00" />
            <u:OffsetDefinition DisplayName="New York (EST)" Offset="-05:00" />
        </u:OffsetDefinitions>
    </u:DateOffsetRangePicker.OffsetDefinitions>
</u:DateOffsetRangePicker>
```

### Comma-separated shorthand / 逗号分隔简写

```xml
<u:DateOffsetRangePicker OffsetDefinitions="UTC, Local, +08:00, -05:00" />
```

### Two-way binding / 双向绑定

```xml
<u:DateOffsetRangePicker Width="400"
                   SelectedStartDate="{Binding StartDate, Mode=TwoWay}"
                   SelectedEndDate="{Binding EndDate, Mode=TwoWay}">
    <u:DateOffsetRangePicker.OffsetDefinitions>
        <u:OffsetDefinitions>
            <u:OffsetDefinition Offset="UTC" />
            <u:OffsetDefinition Offset="Local" />
        </u:OffsetDefinitions>
    </u:DateOffsetRangePicker.OffsetDefinitions>
</u:DateOffsetRangePicker>
```

### Hide offset selection / 隐藏偏移选择

```xml
<u:DateOffsetRangePicker ShowOffsetSelection="False" />
```

### Read-only / 只读

```xml
<u:DateOffsetRangePicker Width="400"
                         IsReadOnly="True"
                         SelectedStartDate="2025-06-26+08:00"
                         SelectedEndDate="2025-06-30+08:00" />
```

### Clear button / 清除按钮

```xml
<u:DateOffsetRangePicker Width="400" Classes="ClearButton" />
```

## Common Scenarios / 常用场景

### 1. Multi-timezone date range binding / 多时区日期范围绑定

```xml
<TextBlock Text="{Binding StartDate, StringFormat='Start: {0:yyyy-MM-dd zzz}'}" />
<TextBlock Text="{Binding EndDate, StringFormat='End: {0:yyyy-MM-dd zzz}'}" />
<u:DateOffsetRangePicker Width="400"
                   SelectedStartDate="{Binding StartDate, Mode=TwoWay}"
                   SelectedEndDate="{Binding EndDate, Mode=TwoWay}">
    <u:DateOffsetRangePicker.OffsetDefinitions>
        <u:OffsetDefinitions>
            <u:OffsetDefinition Offset="UTC" />
            <u:OffsetDefinition Offset="Local" />
            <u:OffsetDefinition DisplayName="Beijing (CST)" Offset="+08:00" />
            <u:OffsetDefinition DisplayName="New York (EST)" Offset="-05:00" />
        </u:OffsetDefinitions>
    </u:DateOffsetRangePicker.OffsetDefinitions>
</u:DateOffsetRangePicker>
```

### 2. Changing the offset updates both dates / 更改偏移会更新两个日期

When the user changes `SelectedOffset`, both `SelectedStartDate` and
`SelectedEndDate` are re-created with the new offset while preserving their
date parts.

当用户更改 `SelectedOffset` 时，`SelectedStartDate` 和 `SelectedEndDate`
都会用新的偏移重新创建，同时保留其日期部分。

## Property Reference / 属性参考

### DateOffsetRangePicker Properties / DateOffsetRangePicker 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedStartDate` | `DateTimeOffset?` | `null` | Start date with offset (two-way) / 带偏移的开始日期（双向绑定） |
| `SelectedEndDate` | `DateTimeOffset?` | `null` | End date with offset (two-way) / 带偏移的结束日期（双向绑定） |
| `DisplayFormat` | `string?` | `"yyyy-MM-dd"` | Date display format for both text boxes / 两个文本框的日期显示格式 |
| `OffsetDefinitions` | `OffsetDefinitions?` | `[Local]` | Available offset entries / 可用的偏移条目 |
| `SelectedOffset` | `OffsetDefinition?` | (first) | Currently selected offset (two-way) / 当前选中的偏移（双向绑定） |
| `ShowOffsetSelection` | `bool` | `true` | Show/hide the offset combo box / 显示/隐藏偏移下拉框 |
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

### Offset Types / 偏移类型

See the `DateOffsetPicker` / `DateTimeOffsetPicker` reference for full details
on `OffsetDefinition`, `OffsetDefinitions`, and `OffsetValue`.

有关 `OffsetDefinition`、`OffsetDefinitions` 和 `OffsetValue` 的完整详情，
请参阅 `DateOffsetPicker` / `DateTimeOffsetPicker` 参考页。

## Styling & Templating / 样式与模板

### Style Classes / 样式类

| Class | Effect |
|---|---|
| `ClearButton` | Shows a clear button on hover when at least one date is set / 至少设置一个日期时悬停显示清除按钮 |
| `Large` | Increases `MinHeight` to `TextBoxLargeHeight` / 将 `MinHeight` 增大到 `TextBoxLargeHeight` |
| `Small` | Decreases `MinHeight` to `TextBoxSmallHeight` / 将 `MinHeight` 减小到 `TextBoxSmallHeight` |

### Theme Resources / 主题资源

DateOffsetRangePicker uses its own theme key (`DateOffsetRangePicker`) inheriting
from standard text box and popup resources.

| Resource Key | Applies To | Description |
|---|---|---|
| `TextBoxDefaultBackground` | Background | Default background / 默认背景 |
| `TextBoxForeground` | Text | Default text color / 默认文字颜色 |
| `TextBoxDefaultBorderBrush` | Border | Default border brush / 默认边框画刷 |
| `TextBoxDefaultCornerRadius` | Border | Corner radius / 圆角 |
| `TextBoxPlaceholderForeground` | Placeholder | Placeholder text color / 占位文字颜色 |
| `ComboBoxPopupBackground` | Popup | Popup background / 弹出框背景 |
| `ComboBoxPopupBorderBrush` | Popup border | Popup border brush / 弹出框边框画刷 |
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
| `PART_OffsetComboBox` | `ComboBox` | The offset selection combo / 偏移选择下拉框 |

## API Reference / API 参考

- **Namespace**: `Ursa.Controls`
- **Base class**: `DateRangePickerBase<DateTimeOffset>` → `DateRangePickerBase` → `TemplatedControl`
- **Interfaces**: `IInnerContentControl`, `IPopupInnerContent`, `IClearControl`

## FAQ / 常见问题

**Q: How does changing the offset affect both dates? / 更改偏移如何影响两个日期？**
A: When `SelectedOffset` changes, the control re-creates both
`SelectedStartDate` and `SelectedEndDate` with the new offset, preserving
the date part (year/month/day). The time part is reset to `00:00:00`.

**Q: Can I have different offsets for start and end dates? / 可以使用不同的开始和结束日期偏移吗？**
A: No. The single `SelectedOffset` applies to both dates. If different offsets
are needed, use two separate `DateOffsetPicker` controls.

**Q: Where is the `NeedConfirmation` property? / `NeedConfirmation` 属性在哪里？**
A: The `DateRangePickerBase` does not expose `NeedConfirmation`. The confirm
button section is commented out in the Semi theme template. Selection commits
immediately on click.
