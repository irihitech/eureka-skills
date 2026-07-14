---
category: Components
title: TimeOnlyPicker
subtitle: TimeOnly 时间选择器
description: >
  A single time picker using .NET 6+ TimeOnly type. Identical API to TimePicker
  but operates on TimeOnly values instead of TimeSpan, providing cleaner semantics
  for clock-time selection. Based on TimePickerBase&lt;TimeOnly&gt;.
  使用 .NET 6+ TimeOnly 类型的单时间选择器。API 与 TimePicker 相同，但操作于
  TimeOnly 值而非 TimeSpan，为时钟时间选择提供更清晰的语义。基于
  TimePickerBase&lt;TimeOnly&gt;。
---

# TimeOnlyPicker / TimeOnly 时间选择器

## When to Use / 何时使用

Use `TimeOnlyPicker` when you need clock-time selection without date semantics,
and your project targets .NET 6 or later. It is functionally identical to
`TimePicker` but the `SelectedTime` property is typed as `TimeOnly?` instead of
`TimeSpan?`. `TimeOnly` represents a time of day (00:00–23:59:59) rather than an
arbitrary duration, making it the better choice for scheduling and alarm
applications.

当需要时钟时间选择（无日期语义）且项目目标为 .NET 6 或更高版本时，使用
`TimeOnlyPicker`。它在功能上与 `TimePicker` 相同，但 `SelectedTime` 属性类型为
`TimeOnly?` 而非 `TimeSpan?`。`TimeOnly` 表示一天中的时间（00:00–23:59:59），
而非任意持续时间，因此更适合日程安排和闹钟应用。

If you target older .NET versions or need duration semantics, use `TimePicker`.

如果面向较旧的 .NET 版本或需要持续时间语义，请使用 `TimePicker`。

## Basic Usage / 基本使用

### TimeOnly binding / TimeOnly 绑定

```xml
xmlns:u="https://irihi.tech/ursa"

<u:TimeOnlyPicker SelectedTime="{Binding AlarmTime}" />
```

```csharp
// ViewModel (.NET 6+)
public TimeOnly? AlarmTime { get; set; }
```

### With display format / 带显示格式

```xml
<u:TimeOnlyPicker SelectedTime="{Binding StartTime}"
                  DisplayFormat="HH:mm" />
```

### 12-hour mode / 12 小时制

```xml
<u:TimeOnlyPicker SelectedTime="{Binding ReminderTime}"
                  DisplayFormat="hh:mm:ss tt"
                  PanelFormat="hh mm t" />
```

### Read-only mode / 只读模式

```xml
<u:TimeOnlyPicker SelectedTime="{Binding LogTime}"
                  IsReadOnly="True" />
```

### With confirmation / 带确认

```xml
<u:TimeOnlyPicker SelectedTime="{Binding MeetingTime}"
                  NeedConfirmation="True" />
```

## Common Scenarios / 常用场景

### 1. Hours and minutes only / 仅时和分

```xml
<u:TimeOnlyPicker SelectedTime="{Binding Time}"
                  DisplayFormat="HH:mm"
                  PanelFormat="HH mm" />
```

### 2. With seconds / 带秒

```xml
<u:TimeOnlyPicker SelectedTime="{Binding PreciseTime}"
                  DisplayFormat="HH:mm:ss"
                  PanelFormat="HH mm ss" />
```

### 3. Programmatic control / 编程控制

```xml
<u:TimeOnlyPicker x:Name="MyTimePicker"
                  SelectedTime="{Binding Time}" />
```

```csharp
// Open dropdown
MyTimePicker.IsDropdownOpen = true;

// Clear selection
MyTimePicker.Clear();

// Dismiss without committing
MyTimePicker.Dismiss();
```

## Property Reference / 属性参考

### TimeOnlyPicker Properties / TimeOnlyPicker 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedTime` | `TimeOnly?` | `null` | The selected time (two-way binding) / 选中的时间（双向绑定） |
| `DisplayFormat` | `string?` | `"HH:mm:ss"` | .NET format string for display and parsing / 用于显示和解析的 .NET 格式字符串 |
| `PanelFormat` | `string` | `"HH mm ss"` | Controls which time columns appear and their order / 控制显示哪些时间列及其顺序 |
| `NeedConfirmation` | `bool` | `false` | Require explicit confirmation before committing / 提交前需要显式确认 |
| `IsDropdownOpen` | `bool` | `false` | Whether the popup is open (two-way) / 弹出层是否打开（双向） |
| `IsReadOnly` | `bool` | `false` | Prevent user editing and dropdown / 禁止用户编辑和下拉 |
| `PlaceholderText` | `string?` | `null` | Text shown when no time is selected / 未选择时间时显示的文本 |
| `PlaceholderForeground` | `IBrush?` | (theme) | Brush for placeholder text / 占位文本的画刷 |
| `InnerLeftContent` | `object?` | `null` | Content inside text box on the left / 文本框内左侧内容 |
| `InnerRightContent` | `object?` | `null` | Content inside text box on the right / 文本框内右侧内容 |
| `PopupInnerTopContent` | `object?` | `null` | Content at popup top / 弹出层顶部内容 |
| `PopupInnerBottomContent` | `object?` | `null` | Content at popup bottom / 弹出层底部内容 |

### Differences from TimePicker / 与 TimePicker 的区别

| Feature | TimePicker | TimeOnlyPicker |
|---|---|---|
| Selected value type | `TimeSpan?` | `TimeOnly?` |
| Semantics | Duration since midnight | Time of day (clock time) |
| .NET version | All | .NET 6+ |
| Typical use case | Elapsed time, durations | Schedules, alarms, clock times |

### PanelFormat Tokens / PanelFormat 标记

| Token | Meaning / 含义 | Example Values / 示例值 |
|---|---|---|
| `HH` | 24-hour hours / 24小时制 | 00–23 |
| `hh` | 12-hour hours / 12小时制 | 01–12 |
| `mm` | Minutes / 分钟 | 00–59 |
| `ss` | Seconds / 秒 | 00–59 |
| `t` | AM/PM period / 上下午 | AM, PM |

### Methods / 方法

| Method | Description / 说明 |
|---|---|
| `Clear()` | Clears the selected time / 清除选中时间 |
| `Confirm()` | Commits pending selection (confirmation mode) / 提交待定选择（确认模式） |
| `Dismiss()` | Closes the dropdown without committing / 关闭下拉框但不提交 |

## Events / 事件

`TimeOnlyPicker` inherits standard `TemplatedControl` events. Time changes are
observed via `SelectedTime` (binding or `PropertyChanged`).

`TimeOnlyPicker` 继承标准 `TemplatedControl` 事件。时间变更通过 `SelectedTime`
（绑定或 `PropertyChanged`）观察。

### Keyboard shortcuts / 键盘快捷键

| Key | Action / 动作 |
|---|---|
| `↓` (Down) | Open dropdown / 打开下拉 |
| `Escape` | Close dropdown / 关闭下拉 |
| `Tab` | Close dropdown / 关闭下拉 |
| `Enter` | Commit input and close / 提交输入并关闭 |

## Styling & Templating / 样式与模板

`TimeOnlyPicker` shares the exact same theme as `TimePicker` — it targets
`TimePickerBase` as its `StyleKeyOverride`. Refer to the TimePicker reference
page for the complete styling table including all theme resources.

`TimeOnlyPicker` 与 `TimePicker` 共享完全相同的主题——其 `StyleKeyOverride`
指向 `TimePickerBase`。完整的样式表（包括所有主题资源）请参阅 TimePicker
参考页面。

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_TextBox` | `TimePickerBase` | `TextBox` |
| `PART_Popup` | `TimePickerBase` | `Popup` |
| `PART_Presenter` | `TimePickerBase` | `TimePickerPresenter` |

### Style Classes / 样式类

| Class | Effect / 效果 |
|---|---|
| `Large` | Increases `MinHeight` to `TextBoxLargeHeight` |
| `Small` | Decreases `MinHeight` to `TextBoxSmallHeight` |
| `clearButton` / `ClearButton` | Enables clear-button hover behavior |

### Pseudo-classes / 伪类

| Pseudo-class | Condition / 条件 |
|---|---|
| `:empty` | No time selected / 未选择时间 |
| `:pointerover` | Mouse over the control / 鼠标悬停 |
| `:disabled` | Control is disabled / 控件已禁用 |
| `:focus-within` | Focus is within the control / 焦点在控件内 |

## FAQ / 常见问题

**Q: When should I use TimeOnlyPicker instead of TimePicker?**

A: Use `TimeOnlyPicker` when your data model uses `TimeOnly` (e.g., business
hours, alarm times, meeting schedules). If you need `TimeSpan` semantics (e.g.,
elapsed duration) or target older .NET versions, use `TimePicker`.

当数据模型使用 `TimeOnly`（如营业时间、闹钟时间、会议日程）时使用
`TimeOnlyPicker`。如果需要 `TimeSpan` 语义（如经过时间）或面向较旧的 .NET 版本，
请使用 `TimePicker`。

**Q: Can TimeOnly represent durations longer than 24 hours?**

A: No. `TimeOnly` is limited to 00:00–23:59:59.9999999. For durations or
intervals, use `TimePicker` (which wraps `TimeSpan`).

不能。`TimeOnly` 限制在 00:00–23:59:59.9999999 范围内。对于持续时间或间隔，
请使用 `TimePicker`（封装 `TimeSpan`）。

**Q: How do I convert between TimePicker and TimeOnlyPicker bindings?**

A: Convert via `TimeOnly.FromTimeSpan(ts)` and `timeOnly.ToTimeSpan()`. Choose
the picker that matches your property type.

通过 `TimeOnly.FromTimeSpan(ts)` 和 `timeOnly.ToTimeSpan()` 转换。选择与属性
类型匹配的选择器。

**Q: Does TimeOnlyPicker support 12-hour (AM/PM) mode?**

A: Yes. Set `PanelFormat="hh mm t"` and `DisplayFormat` to include `tt`
(e.g., `"hh:mm:ss tt"`). All time pickers share the same `TimePickerPresenter`.

支持。设置 `PanelFormat="hh mm t"` 并将 `DisplayFormat` 设置为包含 `tt`
（如 `"hh:mm:ss tt"`）。所有时间选择器共享相同的 `TimePickerPresenter`。

**Q: Can I use TimeOnlyPicker for time range selection?**

A: Use `TimeOnlyRangePicker` (extends `TimeRangePickerBase<TimeOnly>`) for
selecting a start and end time using `TimeOnly` values.

对于使用 `TimeOnly` 值选择开始和结束时间，请使用 `TimeOnlyRangePicker`
（继承自 `TimeRangePickerBase<TimeOnly>`）。
