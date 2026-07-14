---
category: Components
title: DatePicker
subtitle: 日期选择器
description: >
  A single-date picker with a dropdown calendar. Supports DateTime selection, 
  blackout dates, configurable first day of week, today highlighting, editable 
  text input with format validation, and confirmation mode. Based on 
  DatePickerBase&lt;DateTime&gt;.
  单日期选择器，带有下拉日历。支持 DateTime 选择、禁用日期、可配置每周第一天、
  今天高亮、带格式验证的可编辑文本输入和确认模式。基于 DatePickerBase&lt;DateTime&gt;。
---

# DatePicker / 日期选择器

## When to Use / 何时使用

Use `DatePicker` when you need the user to pick a single date (day, month, year)
without a time component. The control wraps a text box with a dropdown calendar
popup. It supports free-form text input parsed according to `DisplayFormat`,
click-to-open calendar navigation, and keyboard shortcuts.

当需要用户选择单个日期（日、月、年）而不包含时间时使用 `DatePicker`。该控件
包装了一个文本框，并带有下拉日历弹出层。支持根据 `DisplayFormat` 解析的自由文本
输入、点击打开日历导航以及键盘快捷键。

Do NOT use `DatePicker` for picking date ranges — use `DateRangePicker`. For
DateOnly (.NET 6+) types use `DateOnlyPicker`.

不要使用 `DatePicker` 选择日期范围——应使用 `DateRangePicker`。对于 DateOnly
（.NET 6+）类型，请使用 `DateOnlyPicker`。

## Basic Usage / 基本使用

### Single date binding / 单日期绑定

```xml
xmlns:u="https://irihi.tech/ursa"

<u:DatePicker SelectedDate="{Binding StartDate}" />
```

```csharp
// ViewModel
public DateTime? StartDate { get; set; }
```

### With display format / 带显示格式

```xml
<u:DatePicker SelectedDate="{Binding BirthDate}"
              DisplayFormat="yyyy/MM/dd" />
```

### Read-only mode / 只读模式

```xml
<u:DatePicker SelectedDate="{Binding InvoiceDate}"
              IsReadOnly="True" />
```

### With confirmation / 带确认

```xml
<u:DatePicker SelectedDate="{Binding EventDate}"
              NeedConfirmation="True" />
```

When `NeedConfirmation` is `True`, the dropdown shows a Confirm button. The
selection is only committed when the user clicks Confirm or calls `Confirm()`.

当 `NeedConfirmation` 为 `True` 时，下拉框显示确认按钮。仅当用户点击确认或调用
`Confirm()` 时才提交选择。

## Common Scenarios / 常用场景

### 1. Blackout dates (blocklist) / 禁用日期（黑名单）

```xml
<u:DatePicker SelectedDate="{Binding DeliveryDate}">
    <u:DatePicker.BlackoutDates>
        <u:DateRange Start="2025-12-24" End="2025-12-26" />
        <u:DateRange Start="2026-01-01" />
    </u:DatePicker.BlackoutDates>
</u:DatePicker>
```

### 2. Blackout date rule (weekends) / 禁用日期规则（周末）

```xml
<u:DatePicker SelectedDate="{Binding ShipDate}"
              BlackoutDateRule="{x:Static u:WeekendDateSelector.Instance}" />
```

### 3. Custom first day of week / 自定义每周第一天

```xml
<u:DatePicker SelectedDate="{Binding Date}"
              FirstDayOfWeek="Monday" />
```

### 4. Without today highlighting / 取消今天高亮

```xml
<u:DatePicker SelectedDate="{Binding Date}"
              IsTodayHighlighted="False" />
```

### 5. Programmatic open / 编程打开下拉

```xml
<u:DatePicker x:Name="MyDatePicker"
              SelectedDate="{Binding Date}" />
```

```csharp
// Open dropdown programmatically
MyDatePicker.IsDropdownOpen = true;

// Clear selection programmatically
MyDatePicker.Clear();

// Dismiss dropdown
MyDatePicker.Dismiss();
```

### 6. Placeholder text / 占位文本

```xml
<u:DatePicker PlaceholderText="请选择日期"
              PlaceholderForeground="Gray" />
```

## Property Reference / 属性参考

### DatePicker Properties / DatePicker 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedDate` | `DateTime?` | `null` | The selected date (two-way binding) / 选中的日期（双向绑定） |
| `DefaultDateKind` | `DateTimeKind` | `Unspecified` | Kind applied to parsed/created DateTime values / 应用于解析/创建的 DateTime 值的 Kind |
| `DisplayFormat` | `string?` | `"yyyy-MM-dd"` | .NET format string for display and parsing / 用于显示和解析的 .NET 格式字符串 |
| `BlackoutDates` | `AvaloniaList<DateRange>` | (empty) | List of date ranges that cannot be selected / 不可选择的日期范围列表 |
| `BlackoutDateRule` | `IDateSelector?` | `null` | Rule-based date exclusion (e.g. weekend) / 基于规则的日期排除（如周末） |
| `FirstDayOfWeek` | `DayOfWeek` | (culture) | First day shown in calendar / 日历显示的第一天 |
| `IsTodayHighlighted` | `bool` | `true` | Whether today's date is visually highlighted / 是否视觉高亮今天的日期 |
| `IsDropdownOpen` | `bool` | `false` | Whether the calendar popup is open (two-way) / 日历弹出层是否打开（双向） |
| `IsReadOnly` | `bool` | `false` | Prevent user editing and dropdown / 禁止用户编辑和下拉 |
| `NeedConfirmation` | `bool` | `false` | Require explicit confirmation before committing / 提交前需要显式确认 |
| `PlaceholderText` | `string?` | `null` | Text shown when no date is selected / 未选择日期时显示的文本 |
| `PlaceholderForeground` | `IBrush?` | (theme) | Brush for placeholder text / 占位文本的画刷 |
| `InnerLeftContent` | `object?` | `null` | Content placed inside the text box on the left / 文本框内左侧内容 |
| `InnerRightContent` | `object?` | `null` | Content placed inside the text box on the right / 文本框内右侧内容 |
| `PopupInnerTopContent` | `object?` | `null` | Content placed at the top of the popup / 弹出层顶部内容 |
| `PopupInnerBottomContent` | `object?` | `null` | Content placed at the bottom of the popup / 弹出层底部内容 |

### DateRange (blackout dates) / DateRange（禁用日期）

| Constructor | Description / 说明 |
|---|---|
| `DateRange(DateTime day)` | Single-day range / 单日范围 |
| `DateRange(DateTime start, DateTime end)` | Inclusive range / 包含范围 |

### IDateSelector / IDateSelector 接口

| Member | Description / 说明 |
|---|---|
| `bool Match(DateTime? date)` | Return `true` to black out the date / 返回 `true` 表示禁用该日期 |

Built-in: `WeekendDateSelector.Instance` — blocks Saturday and Sunday.

内置：`WeekendDateSelector.Instance` — 禁止周六和周日。

### Methods / 方法

| Method | Description / 说明 |
|---|---|
| `Clear()` | Clears the selected date / 清除选中日期 |
| `Confirm()` | Commits pending selection (confirmation mode) / 提交待定选择（确认模式） |
| `Dismiss()` | Closes the dropdown without committing / 关闭下拉框但不提交 |

## Events / 事件

`DatePicker` inherits standard `TemplatedControl` events (GotFocus, LostFocus,
PointerPressed, KeyDown). There are no additional routed events on `DatePicker`
itself. Date selection changes are observed via the `SelectedDate` property
(binding or `PropertyChanged`).

`DatePicker` 继承标准 `TemplatedControl` 事件（GotFocus、LostFocus、
PointerPressed、KeyDown）。`DatePicker` 本身没有额外的路由事件。日期选择变更
通过 `SelectedDate` 属性（绑定或 `PropertyChanged`）观察。

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
| `:empty` | No date selected (`SelectedDate` is `null`) / 未选择日期 |
| `:pointerover` | Mouse over the control / 鼠标悬停在控件上 |
| `:disabled` | Control is disabled / 控件已禁用 |
| `:focus-within` | Focus is within the control / 焦点在控件内 |

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_Popup` | `DatePickerBase` | `Popup` |
| `PART_TextBox` | `DatePickerBase` | `TextBox` |
| `PART_Calendar` | `DatePickerBase` | `DatePickerCalendarView` |

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
| `CalendarDatePickerIconGlyph` | Icon | Calendar icon path data / 日历图标路径数据 |
| `ComboBoxPopupBackground` | Popup border | Popup background / 弹出层背景 |
| `ComboBoxPopupBorderBrush` | Popup border | Popup border / 弹出层边框 |
| `ComboBoxPopupBorderThickness` | Popup border | Popup border thickness / 弹出层边框粗细 |
| `ComboBoxPopupBoxShadow` | Popup border | Popup shadow / 弹出层阴影 |
| `CalendarCornerRadius` | Popup border | Popup corner radius / 弹出层圆角 |
| `STRING_DATE_TIME_CONFIRM` | Confirm button | Confirm button text / 确认按钮文本 |
| `IconButtonClearData` | Clear button | Clear button icon / 清除按钮图标 |

## FAQ / 常见问题

**Q: How do I bind the selected date to a ViewModel? / 如何将选中日期绑定到 ViewModel？**

A: Use `SelectedDate="{Binding MyDate}"`. The property is two-way by default.
In your ViewModel, declare `public DateTime? MyDate { get; set; }` with
change notification.

使用 `SelectedDate="{Binding MyDate}"`。该属性默认为双向绑定。在 ViewModel 中
声明 `public DateTime? MyDate { get; set; }` 并实现变更通知。

**Q: How do I disable specific weekdays? / 如何禁用特定工作日？**

A: Implement `IDateSelector` to return `true` for dates to block. Assign to
`BlackoutDateRule`. The built-in `WeekendDateSelector.Instance` is an example.

实现 `IDateSelector`，对要屏蔽的日期返回 `true`。赋值给 `BlackoutDateRule`。
内置的 `WeekendDateSelector.Instance` 是一个示例。

**Q: Can users type dates directly? / 用户可以手动输入日期吗？**

A: Yes. When `IsReadOnly` is `false`, the text box accepts free-form input
parsed against `DisplayFormat`. Invalid input clears the selection.

可以。当 `IsReadOnly` 为 `false` 时，文本框接受自由格式输入并根据
`DisplayFormat` 解析。无效输入会清除选择。

**Q: How do I localize calendar day names? / 如何本地化日历的日期名称？**

A: Day-of-week headers follow `CultureInfo.CurrentCulture.DateTimeFormat`.
Override `FirstDayOfWeek` to match locale conventions.

星期标题遵循 `CultureInfo.CurrentCulture.DateTimeFormat`。覆盖
`FirstDayOfWeek` 以匹配当地惯例。

**Q: What is the difference between `DatePicker` and `DateOnlyPicker`?**
A: `DatePicker` uses `DateTime` (with a `DateTimeKind`) while `DateOnlyPicker`
uses the .NET 6+ `DateOnly` type. If your project targets .NET 6+, prefer
`DateOnlyPicker` for date-only semantics.

A: `DatePicker` 使用 `DateTime`（带 `DateTimeKind`），而 `DateOnlyPicker` 使用
.NET 6+ 的 `DateOnly` 类型。如果项目目标为 .NET 6+，建议使用 `DateOnlyPicker`
以获得仅日期语义。
