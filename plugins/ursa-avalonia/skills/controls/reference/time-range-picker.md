---
category: Components
title: TimeRangePicker
subtitle: 时间范围选择器
description: >
  Selects a start and end time range using dual time picker presenters.
  The popup shows two time-picker panels side by side (Start Time / End Time)
  with hour, minute, and second columns. Uses `TimeSpan` for
  `SelectedStartTime` / `SelectedEndTime` two-way binding. Supports
  `NeedConfirmation`, `PanelFormat`, and `ClearButton`.
  使用双时间选择器面板选择起止时间范围。弹出框并排显示两个时间选择器面板
  （开始时间 / 结束时间），包含时、分、秒列。使用 `TimeSpan` 进行
  `SelectedStartTime` / `SelectedEndTime` 双向绑定。支持 `NeedConfirmation`、
  `PanelFormat` 和 `ClearButton`。
---

# TimeRangePicker / 时间范围选择器

## When to Use / 何时使用

Use `TimeRangePicker` when users need to select a time range — for example,
business hours, a meeting time slot, or a shift schedule. The popup presents
two time-picker panels labeled "Start Time" and "End Time", each with
hour/minute/second columns.

当用户需要选择时间范围时使用 `TimeRangePicker`——例如营业时间、会议时间段或
班次安排。弹出框并排显示两个标有 "开始时间" 和 "结束时间" 的时间选择器面板，
每个面板包含时/分/秒列。

Do NOT use `TimeRangePicker` for date input — it only handles time. For
date+time ranges, combine with a date picker. For `TimeOnly` ranges, use
`TimeOnlyRangePicker`.

不要使用 `TimeRangePicker` 输入日期——它仅处理时间。如需日期+时间范围，请与日期
选择器结合使用。对于 `TimeOnly` 范围，请使用 `TimeOnlyRangePicker`。

## Basic Usage / 基本使用

### Default / 默认

```xml
xmlns:u="https://irihi.tech/ursa"

<u:TimeRangePicker Width="300" />
```

### With custom formats / 带自定义格式

```xml
<u:TimeRangePicker Width="300"
                   DisplayFormat="HH:mm"
                   PanelFormat="HH mm" />
```

### Two-way binding / 双向绑定

```xml
<u:TimeRangePicker Width="300"
                   SelectedStartTime="{Binding StartTime, Mode=TwoWay}"
                   SelectedEndTime="{Binding EndTime, Mode=TwoWay}" />
```

### With NeedConfirmation / 带确认模式

```xml
<u:TimeRangePicker Width="300"
                   NeedConfirmation="True"
                   SelectedStartTime="{Binding StartTime}"
                   SelectedEndTime="{Binding EndTime}" />
```

When `NeedConfirmation="True"`, changes are only committed when the user clicks
the confirm button. Otherwise, each time picker change takes effect immediately.

当 `NeedConfirmation="True"` 时，仅当用户点击确认按钮后更改才会提交。否则，
每个时间选择器的更改立即生效。

### Read-only with pre-set values / 带预设值的只读模式

```xml
<u:TimeRangePicker Width="300"
                   IsReadOnly="True"
                   SelectedStartTime="09:00:00"
                   SelectedEndTime="17:30:00" />
```

### Clear button / 清除按钮

```xml
<u:TimeRangePicker Width="300" Classes="ClearButton" />
```

## Common Scenarios / 常用场景

### 1. Business hours picker / 营业时间选择器

```xml
<u:TimeRangePicker Width="300"
                   DisplayFormat="HH:mm"
                   PanelFormat="tt HH mm"
                   SelectedStartTime="{Binding OpenTime, Mode=TwoWay}"
                   SelectedEndTime="{Binding CloseTime, Mode=TwoWay}" />
```

The `PanelFormat` supports AM/PM via the `"tt"` token when the culture's
`LongTimePattern` includes it.

`PanelFormat` 在文化设置的 `LongTimePattern` 包含 AM/PM 时支持通过 `"tt"` 标记
显示 AM/PM。

### 2. Confirmation mode / 确认模式

```xml
<ToggleSwitch Name="needConfirm" Content="Need Confirm" />
<TextBlock Text="{Binding #confirmPicker.SelectedStartTime,
                         StringFormat='Start: {0}'}" />
<TextBlock Text="{Binding #confirmPicker.SelectedEndTime,
                         StringFormat='End: {0}'}" />
<u:TimeRangePicker Name="confirmPicker"
                   Width="300"
                   NeedConfirmation="{Binding #needConfirm.IsChecked}" />
```

## Property Reference / 属性参考

### TimeRangePicker Properties / TimeRangePicker 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedStartTime` | `TimeSpan?` | `null` | Start time of range (two-way) / 范围的开始时间（双向绑定） |
| `SelectedEndTime` | `TimeSpan?` | `null` | End time of range (two-way) / 范围的结束时间（双向绑定） |
| `DisplayFormat` | `string?` | `"HH:mm:ss"` | Time display format for both text boxes / 两个文本框的时间显示格式 |
| `PanelFormat` | `string` | `"HH mm ss"` | Format of the time picker panels / 时间选择器面板的格式 |
| `NeedConfirmation` | `bool` | `false` | Require confirm button to commit / 需要确认按钮才能提交 |
| `IsReadOnly` | `bool` | `false` | Disable editing / 禁用编辑 |
| `IsDropdownOpen` | `bool` | `false` | Whether the popup is open (two-way) / 弹出框是否打开（双向绑定） |
| `StartPlaceholderText` | `string?` | (empty) | Placeholder for start text box / 开始文本框的占位文本 |
| `EndPlaceholderText` | `string?` | (empty) | Placeholder for end text box / 结束文本框的占位文本 |
| `PlaceholderForeground` | `IBrush?` | (theme) | Foreground of placeholder text / 占位文本的前景色 |
| `InnerLeftContent` | `object?` | `null` | Content in the left side of the start text box / 开始文本框左侧的内容 |
| `InnerRightContent` | `object?` | `null` | Content in the right side of the end text box / 结束文本框右侧的内容 |
| `PopupInnerTopContent` | `object?` | `null` | Content above the time pickers in the popup / 弹出框中时间选择器上方的内容 |
| `PopupInnerBottomContent` | `object?` | `null` | Content below the time pickers in the popup / 弹出框中时间选择器下方的内容 |

> **Obsolete**: `StartTime` / `EndTime` property aliases and `StartTimeProperty` /
> `EndTimeProperty` static fields are marked `[Obsolete]`. Use
> `SelectedStartTime` / `SelectedEndTime` instead.

> **已弃用**：`StartTime` / `EndTime` 属性别名和 `StartTimeProperty` /
> `EndTimeProperty` 静态字段已标记为 `[Obsolete]`。请改用
> `SelectedStartTime` / `SelectedEndTime`。

### Methods / 方法

| Method | Description / 说明 |
|---|---|
| `Clear()` | Resets both `SelectedStartTime` and `SelectedEndTime` to `null`, clears presenters / 将 `SelectedStartTime` 和 `SelectedEndTime` 都重置为 `null`，清除展示控件 |
| `Confirm()` | Commits pending time selections (when `NeedConfirmation=True`) / 提交待定时间选择（当 `NeedConfirmation=True` 时） |
| `Dismiss()` | Closes the popup without committing / 关闭弹出框但不提交 |

## How the Dual-Time Flow Works / 双时间流程工作原理

1. User clicks the start text box or the picker body → focus goes to start
   time picker. The popup opens with both time pickers.

2. User adjusts the start time via the hour/minute/second columns or by typing.
   Focus automatically moves to the end text box after selecting the start time.

3. User adjusts the end time. When the end text box loses focus, the popup closes.

4. If `NeedConfirmation="True"`, neither selection commits until the confirm
   button is clicked. The cancel (light dismiss) button discards both.

1. 用户点击开始文本框或选择器主体 → 焦点移到开始时间选择器。弹出框打开并显示
   两个时间选择器。

2. 用户通过时/分/秒列或输入调整开始时间。选择开始时间后焦点自动移到结束文本框。

3. 用户调整结束时间。当结束文本框失去焦点时，弹出框关闭。

4. 如果 `NeedConfirmation="True"`，在点击确认按钮之前两个选择都不会提交。
   取消（轻触关闭）按钮会丢弃两者。

## Styling & Templating / 样式与模板

### Style Classes / 样式类

| Class | Effect |
|---|---|
| `ClearButton` | Shows a clear button on hover when at least one time is set / 至少设置一个时间时悬停显示清除按钮 |
| `Large` | Increases `MinHeight` to `TextBoxLargeHeight` / 将 `MinHeight` 增大到 `TextBoxLargeHeight` |
| `Small` | Decreases `MinHeight` to `TextBoxSmallHeight` / 将 `MinHeight` 减小到 `TextBoxSmallHeight` |

### Theme Resources / 主题资源

TimeRangePicker uses `TimeRangePickerBase` theme key. Standard resources apply:

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
| `DateTimePickerSeparatorBackground` | Separator | Color for the vertical divider between start/end panels / 开始/结束面板之间垂直分隔线的颜色 |
| `STRING_DATE_TIME_CONFIRM` | Confirm button | Localized confirm button text / 本地化的确认按钮文字 |
| `STRING_DATE_TIME_START_TIME` | Label | "Start Time" label text / "开始时间" 标签文字 |
| `STRING_DATE_TIME_END_TIME` | Label | "End Time" label text / "结束时间" 标签文字 |

### Template Parts / 模板部件

| Part Name | Type | Description |
|---|---|---|
| `PART_Popup` | `Popup` | The dropdown popup / 下拉弹出框 |
| `PART_StartTextBox` | `TextBox` | Start time text input / 开始时间文本输入 |
| `PART_EndTextBox` | `TextBox` | End time text input / 结束时间文本输入 |
| `PART_StartPresenter` | `TimePickerPresenter` | Start time picker panel / 开始时间选择器面板 |
| `PART_EndPresenter` | `TimePickerPresenter` | End time picker panel / 结束时间选择器面板 |

## API Reference / API 参考

- **Namespace**: `Ursa.Controls`
- **Base class**: `TimeRangePickerBase<TimeSpan>` → `TimeRangePickerBase` → `TemplatedControl`
- **Style key override**: `typeof(TimeRangePickerBase)` (shares theme with `TimeOnlyRangePicker`)
- **Interfaces**: `IInnerContentControl`, `IPopupInnerContent`, `IClearControl`

## FAQ / 常见问题

**Q: How do I change the text of "Start Time" / "End Time" labels? / 如何更改"开始时间"/"结束时间"标签文字？**
A: Override the `STRING_DATE_TIME_START_TIME` and `STRING_DATE_TIME_END_TIME`
resource keys in your application resources.

**Q: What is `PanelFormat`? / `PanelFormat` 是什么？**
A: It controls the column layout of the time picker panels. `"HH mm ss"` shows
three columns (hours, minutes, seconds). `"HH mm"` shows two. `"tt HH mm"`
adds an AM/PM column.

**Q: How does `NeedConfirmation` work? / `NeedConfirmation` 如何工作？**
A: When `True`, time selections are held as pending and only committed when the
user clicks the confirm button in the popup. Light-dismiss discards changes.

当为 `True` 时，时间选择被保持为待定状态，仅当用户点击弹出框中的确认按钮时
才会提交。轻触关闭会放弃更改。

**Q: What's the difference between `TimeRangePicker` and `TimeOnlyRangePicker`? / `TimeRangePicker` 和 `TimeOnlyRangePicker` 有什么区别？**
A: `TimeRangePicker` uses `TimeSpan` for `SelectedStartTime`/`SelectedEndTime`.
`TimeOnlyRangePicker` uses `TimeOnly`. API surface is otherwise identical.
