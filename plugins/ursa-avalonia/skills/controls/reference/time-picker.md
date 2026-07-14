---
category: Components
title: TimePicker
subtitle: 时间选择器
description: >
  A single time picker with a scrolling column selector for hours, minutes,
  seconds, and AM/PM. Supports TimeSpan selection, configurable time format,
  confirmation mode, and editable text input. Based on TimePickerBase&lt;TimeSpan&gt;.
  带有滚动列选择器的单时间选择器，可选择时、分、秒和 AM/PM。支持 TimeSpan 选择、
  可配置时间格式、确认模式和可编辑文本输入。基于 TimePickerBase&lt;TimeSpan&gt;。
---

# TimePicker / 时间选择器

## When to Use / 何时使用

Use `TimePicker` when you need the user to pick a time of day (hours, minutes,
seconds) without a date component. The control wraps a text box with a dropdown
popup containing scrolling time columns. It supports 12-hour (AM/PM) and 24-hour
modes via `PanelFormat`.

当需要用户选择一天中的时间（时、分、秒）而不包含日期时使用 `TimePicker`。该控件
包装了一个文本框，并带有包含滚动时间列的下拉弹出层。通过 `PanelFormat` 支持
12 小时制（AM/PM）和 24 小时制。

For TimeOnly (.NET 6+) types use `TimeOnlyPicker`. For time ranges use
`TimeRangePicker`.

对于 TimeOnly（.NET 6+）类型，请使用 `TimeOnlyPicker`。对于时间范围，请使用
`TimeRangePicker`。

## Basic Usage / 基本使用

### Single time binding / 单时间绑定

```xml
xmlns:u="https://irihi.tech/ursa"

<u:TimePicker SelectedTime="{Binding StartTime}" />
```

```csharp
// ViewModel
public TimeSpan? StartTime { get; set; }
```

### With display format / 带显示格式

```xml
<u:TimePicker SelectedTime="{Binding AlarmTime}"
              DisplayFormat="HH:mm" />
```

### 12-hour mode / 12 小时制

```xml
<u:TimePicker SelectedTime="{Binding ReminderTime}"
              PanelFormat="hh mm t" />
```

The `PanelFormat` property controls which columns appear and in what order. Use
`HH` for 24-hour hours, `hh` for 12-hour hours, `mm` for minutes, `ss` for
seconds, and `t` for AM/PM.

`PanelFormat` 属性控制哪些列出现及其顺序。使用 `HH` 表示 24 小时制，`hh` 表示
12 小时制，`mm` 表示分钟，`ss` 表示秒，`t` 表示 AM/PM。

### Read-only mode / 只读模式

```xml
<u:TimePicker SelectedTime="{Binding LogTime}"
              IsReadOnly="True" />
```

### With confirmation / 带确认

```xml
<u:TimePicker SelectedTime="{Binding MeetingTime}"
              NeedConfirmation="True" />
```

## Common Scenarios / 常用场景

### 1. Hours and minutes only (no seconds) / 仅时和分（无秒）

```xml
<u:TimePicker SelectedTime="{Binding Time}"
              DisplayFormat="HH:mm"
              PanelFormat="HH mm" />
```

### 2. With seconds / 带秒

```xml
<u:TimePicker SelectedTime="{Binding PreciseTime}"
              DisplayFormat="HH:mm:ss"
              PanelFormat="HH mm ss" />
```

### 3. Programmatic control / 编程控制

```xml
<u:TimePicker x:Name="MyTimePicker"
              SelectedTime="{Binding Time}" />
```

```csharp
// Open dropdown
MyTimePicker.IsDropdownOpen = true;

// Clear selection
MyTimePicker.Clear();

// Dismiss dropdown without committing
MyTimePicker.Dismiss();
```

### 4. Placeholder / 占位文本

```xml
<u:TimePicker PlaceholderText="请选择时间"
              PlaceholderForeground="Gray" />
```

## Property Reference / 属性参考

### TimePicker Properties / TimePicker 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedTime` | `TimeSpan?` | `null` | The selected time (two-way binding) / 选中的时间（双向绑定） |
| `DisplayFormat` | `string?` | `"HH:mm:ss"` | .NET format string for display and parsing / 用于显示和解析的 .NET 格式字符串 |
| `PanelFormat` | `string` | `"HH mm ss"` | Controls which time columns appear and their order / 控制显示哪些时间列及其顺序 |
| `NeedConfirmation` | `bool` | `false` | Require explicit confirmation before committing / 提交前需要显式确认 |
| `IsDropdownOpen` | `bool` | `false` | Whether the popup is open (two-way) / 弹出层是否打开（双向） |
| `IsReadOnly` | `bool` | `false` | Prevent user editing and dropdown / 禁止用户编辑和下拉 |
| `PlaceholderText` | `string?` | `null` | Text shown when no time is selected / 未选择时间时显示的文本 |
| `PlaceholderForeground` | `IBrush?` | (theme) | Brush for placeholder text / 占位文本的画刷 |
| `InnerLeftContent` | `object?` | `null` | Content placed inside the text box on the left / 文本框内左侧内容 |
| `InnerRightContent` | `object?` | `null` | Content placed inside the text box on the right / 文本框内右侧内容 |
| `PopupInnerTopContent` | `object?` | `null` | Content placed at the top of the popup / 弹出层顶部内容 |
| `PopupInnerBottomContent` | `object?` | `null` | Content placed at the bottom of the popup / 弹出层底部内容 |

### PanelFormat Tokens / PanelFormat 标记

| Token | Meaning / 含义 | Example Values / 示例值 |
|---|---|---|
| `HH` | 24-hour hours / 24小时制 | 00–23 |
| `hh` | 12-hour hours / 12小时制 | 01–12 |
| `mm` | Minutes / 分钟 | 00–59 |
| `ss` | Seconds / 秒 | 00–59 |
| `t` | AM/PM period / 上下午 | AM, PM |

Tokens are separated by spaces, hyphens, or colons. The default `"HH mm ss"`
produces three scrollable columns: hours (24h), minutes, seconds.

标记之间用空格、连字符或冒号分隔。默认 `"HH mm ss"` 产生三个可滚动列：小时
（24h）、分钟、秒。

### Methods / 方法

| Method | Description / 说明 |
|---|---|
| `Clear()` | Clears the selected time / 清除选中时间 |
| `Confirm()` | Commits pending selection (confirmation mode) / 提交待定选择（确认模式） |
| `Dismiss()` | Closes the dropdown without committing / 关闭下拉框但不提交 |

## Events / 事件

`TimePicker` inherits standard `TemplatedControl` events. Time selection changes
are observed via the `SelectedTime` property (binding or `PropertyChanged`).

`TimePicker` 继承标准 `TemplatedControl` 事件。时间选择变更通过 `SelectedTime`
属性（绑定或 `PropertyChanged`）观察。

Internally, the `TimePickerPresenter` raises `SelectedTimeChanged` (a routed
event with `TimeChangedEventArgs`), but consumers should bind to `SelectedTime`
on the `TimePicker` itself.

内部，`TimePickerPresenter` 引发 `SelectedTimeChanged`（带有
`TimeChangedEventArgs` 的路由事件），但使用者应绑定到 `TimePicker` 本身的
`SelectedTime`。

### Keyboard shortcuts / 键盘快捷键

| Key | Action / 动作 |
|---|---|
| `↓` (Down) | Open dropdown / 打开下拉 |
| `Escape` | Close dropdown / 关闭下拉 |
| `Tab` | Close dropdown / 关闭下拉 |
| `Enter` | Commit input and close / 提交输入并关闭 |

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
| `:empty` | No time selected (`SelectedTime` is `null`) / 未选择时间 |
| `:pointerover` | Mouse over the control / 鼠标悬停在控件上 |
| `:disabled` | Control is disabled / 控件已禁用 |
| `:focus-within` | Focus is within the control / 焦点在控件内 |

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_TextBox` | `TimePickerBase` | `TextBox` |
| `PART_Popup` | `TimePickerBase` | `Popup` |
| `PART_Presenter` | `TimePickerBase` | `TimePickerPresenter` |

The `TimePickerPresenter` itself contains these sub-parts:

`TimePickerPresenter` 本身包含以下子部件：

| Part Name | Type | Description / 说明 |
|---|---|---|
| `PART_HourSelector` | `DateTimePickerPanel` | Hour scrolling list / 小时滚动列表 |
| `PART_MinuteSelector` | `DateTimePickerPanel` | Minute scrolling list / 分钟滚动列表 |
| `PART_SecondSelector` | `DateTimePickerPanel` | Second scrolling list / 秒滚动列表 |
| `PART_AmPmSelector` | `DateTimePickerPanel` | AM/PM selector / 上下午选择器 |
| `PART_FirstSeparator` | `Rectangle` | Separator after hours / 小时后分隔符 |
| `PART_SecondSeparator` | `Rectangle` | Separator after minutes / 分钟后分隔符 |
| `PART_ThirdSeparator` | `Rectangle` | Separator after seconds / 秒后分隔符 |

### Theme Resources (Semi) / 主题资源（Semi）

| Resource Key | Applies To | Description / 说明 |
|---|---|---|
| `TextBoxDefaultBackground` | Control background | Default background / 默认背景 |
| `TextBoxForeground` | Text | Text color / 文字颜色 |
| `TextBoxDefaultBorderBrush` | Border | Default border brush / 默认边框画刷 |
| `TextBoxBorderThickness` | Border | Border thickness / 边框粗细 |
| `TextBoxDefaultCornerRadius` | Border | Corner radius / 圆角 |
| `TextBoxPlaceholderForeground` | Placeholder | Placeholder text color / 占位文本颜色 |
| `CalendarDatePickerPointeroverBackground` | Background | Hover background / 悬停背景 |
| `CalendarDatePickerDisabledBackground` | Background | Disabled background / 禁用背景 |
| `CalendarDatePickerDisabledIconForeground` | Icon | Disabled icon color / 禁用图标颜色 |
| `CalendarDatePickerFocusBorderBrush` | Border | Focus border brush / 焦点边框画刷 |
| `TimePickerIconGlyph` | Icon | Clock icon path data / 时钟图标路径数据 |
| `DateTimePickerSeparatorBackground` | Separator | Column separator color / 列分隔符颜色 |
| `ComboBoxPopupBackground` | Popup border | Popup background / 弹出层背景 |
| `ComboBoxPopupBorderBrush` | Popup border | Popup border / 弹出层边框 |
| `ComboBoxPopupBorderThickness` | Popup border | Popup border thickness / 弹出层边框粗细 |
| `ComboBoxPopupBoxShadow` | Popup border | Popup shadow / 弹出层阴影 |
| `STRING_DATE_TIME_CONFIRM` | Confirm button | Confirm button text / 确认按钮文本 |
| `IconButtonClearData` | Clear button | Clear button icon / 清除按钮图标 |
| `DateTimePickerItem` | ListBoxItem | Time column item theme / 时间列项主题 |
| `TextBoxLargeHeight` | Large size | Height when `.Large` is applied / 应用 `.Large` 时的高度 |
| `TextBoxSmallHeight` | Small size | Height when `.Small` is applied / 应用 `.Small` 时的高度 |

## FAQ / 常见问题

**Q: How do I use 12-hour format with AM/PM? / 如何使用带 AM/PM 的 12 小时制？**

A: Set `PanelFormat="hh mm t"` and `DisplayFormat="hh:mm:ss tt"`. The `hh`
token enables 12-hour mode, and `t` shows the AM/PM column. The display format
follows standard .NET time format strings.

设置 `PanelFormat="hh mm t"` 和 `DisplayFormat="hh:mm:ss tt"`。`hh` 标记启用
12 小时制，`t` 显示 AM/PM 列。显示格式遵循标准 .NET 时间格式字符串。

**Q: How do I remove the seconds column? / 如何移除秒列？**

A: Set `PanelFormat="HH mm"`. This shows only hours and minutes. Adjust
`DisplayFormat` to match (e.g., `"HH:mm"`).

设置 `PanelFormat="HH mm"`。这将仅显示小时和分钟。调整 `DisplayFormat` 以匹配
（如 `"HH:mm"`）。

**Q: Can users type times directly? / 用户可以手动输入时间吗？**

A: Yes. The text box accepts free-form input parsed against `DisplayFormat`.
Invalid input clears the selection.

可以。文本框接受自由格式输入并根据 `DisplayFormat` 解析。无效输入会清除选择。

**Q: How is SelectedTime different from DateTime? / SelectedTime 与 DateTime 有何不同？**

A: `TimePicker` binds to `TimeSpan?`, representing a duration since midnight —
not a clock-time DateTime. If you need both date and time, use `DateTimePicker`.

`TimePicker` 绑定到 `TimeSpan?`，表示从午夜开始的持续时间——而非时钟时间
DateTime。如果需要同时选择日期和时间，请使用 `DateTimePicker`。

**Q: What is the difference between `TimePicker` and `TimeOnlyPicker`?**

A: `TimePicker` uses `TimeSpan` while `TimeOnlyPicker` uses the .NET 6+ `TimeOnly`
type. Use whichever matches your data model.

A: `TimePicker` 使用 `TimeSpan`，而 `TimeOnlyPicker` 使用 .NET 6+ 的 `TimeOnly`
类型。选择与数据模型匹配的类型即可。
