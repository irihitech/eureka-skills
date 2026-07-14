---
category: Components
title: DateTimePicker
subtitle: 日期时间选择器
description: >
  A combined date and time picker. Displays a side-by-side calendar and scrolling
  time columns in a single dropdown. Supports DateTime selection, configurable
  formats, blackout dates, confirmation mode, and editable text input. Based on
  DateTimePickerBase&lt;DateTime&gt;.
  组合日期和时间选择器。在单个下拉框中并排显示日历和滚动时间列。支持 DateTime
  选择、可配置格式、禁用日期、确认模式和可编辑文本输入。基于
  DateTimePickerBase&lt;DateTime&gt;。
---

# DateTimePicker / 日期时间选择器

## When to Use / 何时使用

Use `DateTimePicker` when you need the user to pick both a date and a time in a
single control. The popup shows a calendar on the left and scrolling time columns
on the right, combined in a side-by-side layout. It is the most complete picker
in the family.

当需要用户在单个控件中同时选择日期和时间时使用 `DateTimePicker`。弹出层左侧显示
日历，右侧显示滚动时间列，采用并排布局。它是该系列中最完整的选择器。

If you only need a date, use `DatePicker`. If you only need a time, use
`TimePicker`. For DateOnly/TimeOnly types, use `DateOnlyPicker` / `TimeOnlyPicker`.

如果只需要日期，请使用 `DatePicker`。如果只需要时间，请使用 `TimePicker`。对于
DateOnly/TimeOnly 类型，请使用 `DateOnlyPicker` / `TimeOnlyPicker`。

## Basic Usage / 基本使用

### Single datetime binding / 单日期时间绑定

```xml
xmlns:u="https://irihi.tech/ursa"

<u:DateTimePicker SelectedDate="{Binding Appointment}" />
```

```csharp
// ViewModel
public DateTime? Appointment { get; set; }
```

### With display format / 带显示格式

```xml
<u:DateTimePicker SelectedDate="{Binding Deadline}"
                  DisplayFormat="yyyy/MM/dd HH:mm:ss" />
```

The default `DisplayFormat` is the system's full date/time pattern
(`CultureInfo.InvariantCulture.DateTimeFormat.FullDateTimePattern`).

默认 `DisplayFormat` 为系统的完整日期/时间模式。

### With 12-hour time / 12 小时制时间

```xml
<u:DateTimePicker SelectedDate="{Binding Meeting}"
                  DisplayFormat="yyyy-MM-dd hh:mm tt"
                  PanelFormat="hh mm t" />
```

### Read-only mode / 只读模式

```xml
<u:DateTimePicker SelectedDate="{Binding Timestamp}"
                  IsReadOnly="True" />
```

### With confirmation / 带确认

```xml
<u:DateTimePicker SelectedDate="{Binding EventTime}"
                  NeedConfirmation="True" />
```

When `NeedConfirmation` is `True`, the popup shows a Confirm button. Changes to
either date or time are held pending until `Confirm()` is called.

当 `NeedConfirmation` 为 `True` 时，弹出层显示确认按钮。日期或时间的更改会暂存，
直到调用 `Confirm()` 才提交。

## Common Scenarios / 常用场景

### 1. Blackout dates / 禁用日期

```xml
<u:DateTimePicker SelectedDate="{Binding ShipDate}">
    <u:DateTimePicker.BlackoutDates>
        <u:DateRange Start="2025-12-25" End="2025-12-26" />
    </u:DateTimePicker.BlackoutDates>
</u:DateTimePicker>
```

### 2. Custom time panel (hours only) / 自定义时间面板（仅小时）

```xml
<u:DateTimePicker SelectedDate="{Binding Time}"
                  DisplayFormat="yyyy-MM-dd HH:mm"
                  PanelFormat="HH mm" />
```

### 3. Specifying DateTimeKind / 指定 DateTimeKind

```xml
<u:DateTimePicker SelectedDate="{Binding UtcTime}"
                  DefaultDateKind="Utc" />
```

Values are `Utc`, `Local`, or `Unspecified` (default).

值可以为 `Utc`、`Local` 或 `Unspecified`（默认）。

### 4. Programmatic control / 编程控制

```xml
<u:DateTimePicker x:Name="MyPicker"
                  SelectedDate="{Binding DateTime}" />
```

```csharp
// Open dropdown
MyPicker.IsDropdownOpen = true;

// Clear selection
MyPicker.Clear();

// Dismiss without committing
MyPicker.Dismiss();
```

## Property Reference / 属性参考

### DateTimePicker Properties / DateTimePicker 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedDate` | `DateTime?` | `null` | The selected date+time (two-way binding) / 选中的日期时间（双向绑定） |
| `DefaultDateKind` | `DateTimeKind` | `Unspecified` | Kind applied to parsed/created DateTime values / 应用于解析/创建的 DateTime 值的 Kind |
| `DisplayFormat` | `string?` | (full pattern) | .NET format string for display and parsing / 用于显示和解析的 .NET 格式字符串 |
| `PanelFormat` | `string` | `"HH mm ss"` | Controls which time columns appear / 控制显示哪些时间列 |
| `BlackoutDates` | `AvaloniaList<DateRange>` | (empty) | List of date ranges that cannot be selected / 不可选择的日期范围列表 |
| `BlackoutDateRule` | `IDateSelector?` | `null` | Rule-based date exclusion (e.g. weekend) / 基于规则的日期排除（如周末） |
| `FirstDayOfWeek` | `DayOfWeek` | (culture) | First day shown in calendar / 日历显示的第一天 |
| `IsTodayHighlighted` | `bool` | `true` | Whether today is visually highlighted / 是否视觉高亮今天 |
| `IsDropdownOpen` | `bool` | `false` | Whether the popup is open (two-way) / 弹出层是否打开（双向） |
| `IsReadOnly` | `bool` | `false` | Prevent user editing and dropdown / 禁止用户编辑和下拉 |
| `NeedConfirmation` | `bool` | `false` | Require explicit confirmation before committing / 提交前需要显式确认 |
| `PlaceholderText` | `string?` | `null` | Text shown when empty / 未选择时显示的文本 |
| `PlaceholderForeground` | `IBrush?` | (theme) | Brush for placeholder text / 占位文本的画刷 |
| `InnerLeftContent` | `object?` | `null` | Content inside text box on the left / 文本框内左侧内容 |
| `InnerRightContent` | `object?` | `null` | Content inside text box on the right / 文本框内右侧内容 |
| `PopupInnerTopContent` | `object?` | `null` | Content at popup top / 弹出层顶部内容 |
| `PopupInnerBottomContent` | `object?` | `null` | Content at popup bottom / 弹出层底部内容 |

### Methods / 方法

| Method | Description / 说明 |
|---|---|
| `Clear()` | Clears the selected date+time / 清除选中日期时间 |
| `Confirm()` | Commits pending date+time selection / 提交待定日期时间选择 |
| `Dismiss()` | Closes the dropdown without committing / 关闭下拉框但不提交 |

## Events / 事件

`DateTimePicker` inherits standard `TemplatedControl` events. Selection changes
are observed via `SelectedDate` (binding or `PropertyChanged`).

`DateTimePicker` 继承标准 `TemplatedControl` 事件。选择变更通过 `SelectedDate`
（绑定或 `PropertyChanged`）观察。

### Keyboard shortcuts / 键盘快捷键

| Key | Action / 动作 |
|---|---|
| `↓` (Down) | Open dropdown / 打开下拉 |
| `Escape` | Close dropdown / 关闭下拉 |
| `Tab` | Close dropdown / 关闭下拉 |
| `Enter` | Close dropdown and commit input / 关闭下拉并提交输入 |

## Styling & Templating / 样式与模板

### Style Classes / 样式类

| Class | Effect / 效果 |
|---|---|
| `Large` | Increases `MinHeight` to `TextBoxLargeHeight` / 增加最小高度至文本框大尺寸 |
| `Small` | Decreases `MinHeight` to `TextBoxSmallHeight` / 减小最小高度至文本框小尺寸 |
| `clearButton` / `ClearButton` | Enables clear-button hover behavior / 启用清除按钮悬停行为 |

### Pseudo-classes / 伪类

| Pseudo-class | Condition / 条件 |
|---|---|
| `:empty` | No date selected (`SelectedDate` is `null`) / 未选择日期时间 |
| `:pointerover` | Mouse over the control / 鼠标悬停在控件上 |
| `:disabled` | Control is disabled / 控件已禁用 |
| `:focus-within` | Focus is within the control / 焦点在控件内 |

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_Popup` | `DateTimePickerBase` | `Popup` |
| `PART_TextBox` | `DateTimePickerBase` | `TextBox` |
| `PART_Calendar` | `DateTimePickerBase` | `DatePickerCalendarView` |
| `PART_TimePicker` | `DateTimePickerBase` | `TimePickerPresenter` |

### Theme Resources (Semi) / 主题资源（Semi）

| Resource Key | Applies To | Description / 说明 |
|---|---|---|
| `CalendarDatePickerBackground` | Control background | Default background / 默认背景 |
| `CalendarDatePickerForeground` | Text | Text color / 文字颜色 |
| `CalendarDatePickerBorderBrush` | Border | Default border brush / 默认边框画刷 |
| `CalendarDatePickerBorderThickness` | Border | Border thickness / 边框粗细 |
| `CalendarDatePickerCornerRadius` | Border | Corner radius / 圆角 |
| `CalendarDatePickerDefaultHeight` | MinHeight | Default minimum height / 默认最小高度 |
| `CalendarDatePickerPointeroverBackground` | Background | Hover background / 悬停背景 |
| `CalendarDatePickerDisabledBackground` | Background | Disabled background / 禁用背景 |
| `CalendarDatePickerDisabledIconForeground` | Icon | Disabled icon color / 禁用图标颜色 |
| `CalendarDatePickerFocusBorderBrush` | Border | Focus border brush / 焦点边框画刷 |
| `DateTimePickerGlyph` | Icon | DateTime icon path data / 日期时间图标路径数据 |
| `DateTimePickerSeparatorBackground` | Separator | Time column separator color / 时间列分隔符颜色 |
| `ComboBoxPopupBackground` | Popup border | Popup background / 弹出层背景 |
| `ComboBoxPopupBorderBrush` | Popup border | Popup border / 弹出层边框 |
| `ComboBoxPopupBorderThickness` | Popup border | Popup border thickness / 弹出层边框粗细 |
| `ComboBoxPopupBoxShadow` | Popup border | Popup shadow / 弹出层阴影 |
| `CalendarCornerRadius` | Popup border | Popup corner radius / 弹出层圆角 |
| `STRING_DATE_TIME_CONFIRM` | Confirm button | Confirm button text / 确认按钮文本 |
| `IconButtonClearData` | Clear button | Clear button icon / 清除按钮图标 |
| `DateTimePickerItem` | ListBoxItem | Time column item theme / 时间列项主题 |

## FAQ / 常见问题

**Q: How do I bind both date and time to a ViewModel? / 如何将日期和时间绑定到 ViewModel？**

A: Bind `SelectedDate` to a `DateTime?` property. The control manages both the
calendar and time presenter internally, combining them into a single `DateTime`.

将 `SelectedDate` 绑定到 `DateTime?` 属性。控件内部管理日历和时间演示器，将它们
组合为单个 `DateTime`。

**Q: How do I use 12-hour time in DateTimePicker? / 如何在 DateTimePicker 中使用 12 小时制？**

A: Set `PanelFormat="hh mm t"` and adjust `DisplayFormat` to include `hh` and
`tt` (e.g., `"yyyy-MM-dd hh:mm:ss tt"`).

设置 `PanelFormat="hh mm t"` 并调整 `DisplayFormat` 包含 `hh` 和 `tt`
（如 `"yyyy-MM-dd hh:mm:ss tt"`）。

**Q: What happens when the user selects a date but no time? / 用户选择日期但未选择时间会怎样？**

A: When a date is clicked and no time has been selected before, the current
system time is used as the time component. This behavior is handled internally.

当点击日期且之前未选择时间时，将使用当前系统时间作为时间组件。此行为由内部处理。

**Q: How do I restrict time entry to business hours? / 如何将时间输入限制为工作时间？**

A: There is no built-in min/max time property. You can validate in your ViewModel
by rejecting out-of-range values in the `SelectedDate` setter. Use
`enableDataValidation: true` on the binding.

没有内置的最小/最大时间属性。可以在 ViewModel 中通过拒绝 `SelectedDate` setter
中超出范围的值来验证。在绑定中使用 `enableDataValidation: true`。

**Q: What is the difference between `DateTimePicker` and using `DatePicker` + `TimePicker` separately?**

A: `DateTimePicker` combines both in one compact control with shared popup,
shared confirmation, and a single `DateTime?` binding. Two separate controls
require two bindings and two popups.

A: `DateTimePicker` 将两者组合在一个紧凑控件中，具有共享弹出层、共享确认和
单个 `DateTime?` 绑定。两个独立控件需要两个绑定和两个弹出层。
