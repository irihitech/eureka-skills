---
category: Components
title: DateOffsetPicker / DateTimeOffsetPicker
subtitle: 日期偏移选择器 / 日期时间偏移选择器
description: >
  Date-based and date-time pickers with optional UTC offset selection.
  `DateOffsetPicker` selects a `DateTimeOffset` date; `DateTimeOffsetPicker` adds
  time selection. Both expose an offset combo (UTC, Local, or fixed offsets
  like +08:00) driven by `OffsetDefinitions` and `SelectedOffset`.
  带有可选 UTC 偏移选择的日期和日期时间选择器。`DateOffsetPicker` 选择
  `DateTimeOffset` 日期；`DateTimeOffsetPicker` 增加时间选择。两者都暴露一个
  偏移下拉框（UTC、Local 或 +08:00 等固定偏移），由 `OffsetDefinitions` 和
  `SelectedOffset` 驱动。
---

# DateOffsetPicker / DateTimeOffsetPicker / 日期偏移选择器 / 日期时间偏移选择器

## When to Use / 何时使用

Use `DateOffsetPicker` when you need a date picker that records the UTC offset
along with the selected date — for example, booking a flight departure date in
a specific timezone. Use `DateTimeOffsetPicker` when you also need time-of-day
selection with the same offset capability.

当需要在所选日期的同时记录 UTC 偏移时使用 `DateOffsetPicker`——例如，预订特定
时区的航班出发日期。当还需要同时选择具体时间的偏移时使用
`DateTimeOffsetPicker`。

Do NOT use these when the timezone is irrelevant — use `DatePicker` or
`DateTimePicker` instead. Do NOT use `DateOffsetPicker` for time input — it only
provides a calendar view.

在时区无关时不要使用这些——应使用 `DatePicker` 或 `DateTimePicker`。不要使用
`DateOffsetPicker` 输入时间——它只提供日历视图。

## Basic Usage / 基本使用

### DateOffsetPicker with Local offset / 带本地偏移的 DateOffsetPicker

```xml
xmlns:u="https://irihi.tech/ursa"

<u:DateOffsetPicker Width="280" DisplayFormat="yyyy-MM-dd" />
```

### DateTimeOffsetPicker with time / 带时间的 DateTimeOffsetPicker

```xml
<u:DateTimeOffsetPicker Width="360" />
```

### With custom offset definitions / 带自定义偏移定义

```xml
<u:DateOffsetPicker Width="280" DisplayFormat="yyyy-MM-dd">
    <u:DateOffsetPicker.OffsetDefinitions>
        <u:OffsetDefinitions>
            <u:OffsetDefinition Offset="UTC" />
            <u:OffsetDefinition Offset="Local" />
            <u:OffsetDefinition DisplayName="Beijing (CST)" Offset="+08:00" />
            <u:OffsetDefinition DisplayName="New York (EST)" Offset="-05:00" />
        </u:OffsetDefinitions>
    </u:DateOffsetPicker.OffsetDefinitions>
</u:DateOffsetPicker>
```

### Comma-separated shorthand / 逗号分隔简写

```xml
<u:DateOffsetPicker OffsetDefinitions="UTC, Local, +08:00, -05:00" />
```

### Hide offset selection / 隐藏偏移选择

```xml
<u:DateOffsetPicker ShowOffsetSelection="False" />
```

### Two-way binding / 双向绑定

```xml
<u:DateOffsetPicker SelectedDate="{Binding MyDateOffset, Mode=TwoWay}">
    <u:DateOffsetPicker.OffsetDefinitions>
        <u:OffsetDefinitions>
            <u:OffsetDefinition Offset="UTC" />
            <u:OffsetDefinition Offset="Local" />
        </u:OffsetDefinitions>
    </u:DateOffsetPicker.OffsetDefinitions>
</u:DateOffsetPicker>
```

### DateTimeOffsetPicker with NeedConfirmation / 带确认的 DateTimeOffsetPicker

```xml
<u:DateTimeOffsetPicker Width="360" NeedConfirmation="True"
                        SelectedDate="{Binding SelectedDateTime, Mode=TwoWay}" />
```

When `NeedConfirmation="True"`, changes are only committed when the user clicks
the confirm button in the popup. This applies to both date and time selections.

当 `NeedConfirmation="True"` 时，仅当用户在弹出框中点击确认按钮后更改才会提交。
这适用于日期和时间选择。

## Common Scenarios / 常用场景

### 1. Multi-timezone date picker / 多时区日期选择器

```xml
<u:DateOffsetPicker Width="280" SelectedDate="{Binding DepartureDate}">
    <u:DateOffsetPicker.OffsetDefinitions>
        <u:OffsetDefinitions>
            <u:OffsetDefinition Offset="UTC" />
            <u:OffsetDefinition Offset="Local" />
            <u:OffsetDefinition DisplayName="Beijing (CST)" Offset="+08:00" />
            <u:OffsetDefinition DisplayName="New York (EST)" Offset="-05:00" />
            <u:OffsetDefinition DisplayName="London (GMT)" Offset="+00:00" />
        </u:OffsetDefinitions>
    </u:DateOffsetPicker.OffsetDefinitions>
</u:DateOffsetPicker>
```

### 2. Read-only with pre-set value / 带预设值的只读模式

```xml
<u:DateTimeOffsetPicker Width="360" IsReadOnly="True"
                        SelectedDate="2025-06-26T10:30:00+08:00" />
```

### 3. Clear button / 清除按钮

```xml
<u:DateOffsetPicker Width="280" Classes="ClearButton" />
```

The `ClearButton` style class shows a clear button on hover when the picker has a
value. Clicking it calls `IClearControl.Clear()` to reset `SelectedDate` to `null`.

`ClearButton` 样式类在控件有值且鼠标悬停时显示清除按钮。点击它会调用
`IClearControl.Clear()` 将 `SelectedDate` 重置为 `null`。

## Property Reference / 属性参考

### DateOffsetPicker Properties / DateOffsetPicker 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedDate` | `DateTimeOffset?` | `null` | Selected date with offset (two-way) / 带偏移的所选日期（双向绑定） |
| `DisplayFormat` | `string?` | `"yyyy-MM-dd"` | Date display format string / 日期显示格式字符串 |
| `OffsetDefinitions` | `OffsetDefinitions?` | `[Local]` | Available offset entries / 可用的偏移条目 |
| `SelectedOffset` | `OffsetDefinition?` | (first) | Currently selected offset (two-way) / 当前选中的偏移（双向绑定） |
| `ShowOffsetSelection` | `bool` | `true` | Show/hide the offset combo box / 显示/隐藏偏移下拉框 |
| `IsReadOnly` | `bool` | `false` | Disable editing / 禁用编辑 |
| `IsDropdownOpen` | `bool` | `false` | Whether the popup is open (two-way) / 弹出框是否打开（双向绑定） |
| `NeedConfirmation` | `bool` | `false` | Require confirm button to commit / 需要确认按钮才能提交 |
| `FirstDayOfWeek` | `DayOfWeek` | (culture) | First day of week in calendar / 日历中的每周第一天 |
| `IsTodayHighlighted` | `bool` | `true` | Highlight today in calendar / 在日历中高亮今天 |
| `BlackoutDates` | `AvaloniaList<DateRange>` | (empty) | Disallowed date ranges / 不可选择的日期范围 |
| `BlackoutDateRule` | `IDateSelector?` | `null` | Rule-based blackout dates / 基于规则的不可选日期 |
| `InnerLeftContent` | `object?` | `null` | Content in the left side of the text box / 文本框左侧的内容 |
| `InnerRightContent` | `object?` | `null` | Content in the right side of the text box / 文本框右侧的内容 |
| `PopupInnerTopContent` | `object?` | `null` | Content above the calendar in the popup / 弹出框中日历上方的内容 |
| `PopupInnerBottomContent` | `object?` | `null` | Content below the calendar in the popup / 弹出框中日历下方的内容 |
| `PlaceholderText` | `string?` | `null` | Placeholder text when empty / 空时的占位文本 |
| `PlaceholderForeground` | `IBrush?` | (theme) | Foreground of placeholder text / 占位文本的前景色 |

### DateTimeOffsetPicker Additional Properties / DateTimeOffsetPicker 附加属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedDate` | `DateTimeOffset?` | `null` | Selected date-time with offset (two-way) / 带偏移的所选日期时间（双向绑定） |
| `DisplayFormat` | `string?` | `"yyyy-MM-dd HH:mm:ss"` | Date-time display format string / 日期时间显示格式字符串 |
| `PanelFormat` | `string` | `"HH mm ss"` | Format of the time picker panel / 时间选择器面板的格式 |
| `OffsetDefinitions` | `OffsetDefinitions?` | `[Local]` | Available offset entries / 可用的偏移条目 |
| `SelectedOffset` | `OffsetDefinition?` | (first) | Currently selected offset (two-way) / 当前选中的偏移（双向绑定） |
| `ShowOffsetSelection` | `bool` | `true` | Show/hide the offset combo box / 显示/隐藏偏移下拉框 |

All `DateTimeOffsetPicker` instances also support `IsReadOnly`, `IsDropdownOpen`,
`NeedConfirmation`, `FirstDayOfWeek`, `IsTodayHighlighted`, `BlackoutDates`,
`BlackoutDateRule`, `InnerLeftContent`, `InnerRightContent`,
`PopupInnerTopContent`, `PopupInnerBottomContent`, `PlaceholderText`, and
`PlaceholderForeground` from `DateTimePickerBase`.

所有 `DateTimeOffsetPicker` 实例也支持来自 `DateTimePickerBase` 的 `IsReadOnly`、
`IsDropdownOpen`、`NeedConfirmation`、`FirstDayOfWeek`、`IsTodayHighlighted`、
`BlackoutDates`、`BlackoutDateRule`、`InnerLeftContent`、`InnerRightContent`、
`PopupInnerTopContent`、`PopupInnerBottomContent`、`PlaceholderText` 和
`PlaceholderForeground`。

### Methods / 方法

| Method | Description / 说明 |
|---|---|
| `Clear()` | Resets `SelectedDate` to `null` / 将 `SelectedDate` 重置为 `null` |
| `Confirm()` | Commits pending selection (when `NeedConfirmation=True`) / 提交待定选择（当 `NeedConfirmation=True` 时） |
| `Dismiss()` | Closes the popup without committing / 关闭弹出框但不提交 |

### OffsetDefinition Properties / OffsetDefinition 属性

| Property | Type | Description / 说明 |
|---|---|---|
| `Offset` | `OffsetValue` | The UTC offset value: `Utc`, `Local`, or `Fixed(ts)` |
| `DisplayName` | `string?` | Optional display name (falls back to offset string) / 可选的显示名称（回退到偏移字符串） |

**Supported offset string formats** / **支持的偏移字符串格式**：
- `"UTC"` — UTC+00:00
- `"Local"` — machine timezone at call time / 调用时的机器时区
- `"+08:00"`, `"-05:30"` — fixed hour:minute offset / 固定小时:分钟偏移
- `"8"`, `"-5"` — integer hour offset / 整数小时偏移

### OffsetDefinitions / OffsetDefinitions 集合

`OffsetDefinitions` inherits `AvaloniaList<OffsetDefinition>`. It supports
TypeConverter-based XAML parsing from comma-separated strings:

`OffsetDefinitions` 继承自 `AvaloniaList<OffsetDefinition>`。支持通过
TypeConverter 从逗号分隔字符串进行 XAML 解析：

```xml
<u:DateOffsetPicker OffsetDefinitions="UTC, Local, +08:00, -05:00" />
```

## Styling & Templating / 样式与模板

### Style Classes / 样式类

| Class | Effect |
|---|---|
| `ClearButton` | Shows a clear button on hover when not empty / 非空时悬停显示清除按钮 |
| `Large` | Increases `MinHeight` to `TextBoxLargeHeight` / 将 `MinHeight` 增大到 `TextBoxLargeHeight` |
| `Small` | Decreases `MinHeight` to `TextBoxSmallHeight` / 将 `MinHeight` 减小到 `TextBoxSmallHeight` |

### Theme Resources / 主题资源

Both controls share the standard date-picker theme resources:

| Resource Key | Applies To | Description |
|---|---|---|
| `CalendarDatePickerBackground` | Background border | Default background / 默认背景 |
| `CalendarDatePickerForeground` | Text | Default text color / 默认文字颜色 |
| `CalendarDatePickerBorderBrush` | Border | Default border brush / 默认边框画刷 |
| `CalendarDatePickerBorderThickness` | Border | Border thickness / 边框粗细 |
| `CalendarDatePickerCornerRadius` | Border | Corner radius / 圆角 |
| `CalendarDatePickerPointeroverBackground` | Hover | Pointer-over background / 悬停背景 |
| `CalendarDatePickerDisabledBackground` | Disabled | Disabled background / 禁用背景 |
| `CalendarDatePickerDisabledIconForeground` | Disabled icon | Disabled icon color / 禁用图标颜色 |
| `CalendarDatePickerFocusBorderBrush` | Focused | Focus border brush / 聚焦边框画刷 |
| `CalendarDatePickerDefaultHeight` | MinHeight | Default minimum height / 默认最小高度 |
| `CalendarDatePickerIconGlyph` | Calendar icon | Calendar icon path data / 日历图标路径数据 |

### Template Parts / 模板部件

**DateOffsetPicker** (`DatePickerBase` template):

| Part Name | Type | Description |
|---|---|---|
| `PART_Popup` | `Popup` | The dropdown popup / 下拉弹出框 |
| `PART_TextBox` | `TextBox` | The date text input / 日期文本输入 |
| `PART_Calendar` | `DatePickerCalendarView` | The calendar view / 日历视图 |
| `PART_OffsetComboBox` | `ComboBox` | The offset selection combo / 偏移选择下拉框 |

**DateTimeOffsetPicker** (`DateTimePickerBase` template):

| Part Name | Type | Description |
|---|---|---|
| `PART_Popup` | `Popup` | The dropdown popup / 下拉弹出框 |
| `PART_TextBox` | `TextBox` | The date-time text input / 日期时间文本输入 |
| `PART_Calendar` | `DatePickerCalendarView` | The calendar view / 日历视图 |
| `PART_TimePicker` | `TimePickerPresenter` | The time picker presenter / 时间选择器展示控件 |
| `PART_OffsetComboBox` | `ComboBox` | The offset selection combo / 偏移选择下拉框 |

## API Reference / API 参考

### DateOffsetPicker Class / DateOffsetPicker 类

- **Namespace**: `Ursa.Controls`
- **Base class**: `DatePickerBase<DateTimeOffset>` → `DatePickerBase` → `TemplatedControl`
- **Interfaces**: `IInnerContentControl`, `IPopupInnerContent`, `IClearControl`

### DateTimeOffsetPicker Class / DateTimeOffsetPicker 类

- **Namespace**: `Ursa.Controls`
- **Base class**: `DateTimePickerBase<DateTimeOffset>` → `DateTimePickerBase` → `TemplatedControl`
- **Interfaces**: `IInnerContentControl`, `IPopupInnerContent`, `IClearControl`

## FAQ / 常见问题

**Q: What's the difference between `DateOffsetPicker` and `DateTimeOffsetPicker`?**
A: `DateOffsetPicker` selects only a date with offset (uses `DatePickerBase<T>`); the
popup shows only a calendar. `DateTimeOffsetPicker` selects date + time with offset
(uses `DateTimePickerBase<T>`); the popup shows both a calendar and a time picker.

**Q: How do I set the default offset to UTC? / 如何将默认偏移设置为 UTC？**
A: Set `OffsetDefinitions` with UTC first, and optionally `SelectedOffset`:

```xml
<u:DateOffsetPicker OffsetDefinitions="UTC, Local, +08:00"
                    SelectedOffset="UTC" />
```

**Q: How do I change the displayed time format? / 如何更改显示的时间格式？**
A: Set `DisplayFormat` (text box) and `PanelFormat` (time picker panel):
```xml
<u:DateTimeOffsetPicker DisplayFormat="yyyy-MM-dd HH:mm"
                        PanelFormat="HH mm" />
```

**Q: Can I hide the offset selector? / 可以隐藏偏移选择器吗？**
A: Yes — set `ShowOffsetSelection="False"`. The current offset still applies
to the `DateTimeOffset` value returned by `SelectedDate`.
