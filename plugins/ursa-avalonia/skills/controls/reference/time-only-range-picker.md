---
category: Components
title: TimeOnlyRangePicker
subtitle: TimeOnly 时间范围选择器
description: >
  A time range picker that returns `TimeOnly?` values. Identical in behavior to
  `TimeRangePicker` but uses `TimeOnly` instead of `TimeSpan` for
  `SelectedStartTime` / `SelectedEndTime`. Supports `NeedConfirmation`,
  `PanelFormat`, and `ClearButton`. Shares the `TimeRangePickerBase` theme.
  返回 `TimeOnly?` 值的时间范围选择器。行为与 `TimeRangePicker` 相同，但使用
  `TimeOnly` 而非 `TimeSpan` 作为 `SelectedStartTime` / `SelectedEndTime`。
  支持 `NeedConfirmation`、`PanelFormat` 和 `ClearButton`。共享
  `TimeRangePickerBase` 主题。
---

# TimeOnlyRangePicker / TimeOnly 时间范围选择器

## When to Use / 何时使用

Use `TimeOnlyRangePicker` when your application models time as `TimeOnly`
and you need a time range picker. This is the preferred choice for .NET 6+
applications that use the modern time-only type. The API is identical to
`TimeRangePicker` except the value type.

当应用程序将时间建模为 `TimeOnly` 且需要时间范围选择器时使用
`TimeOnlyRangePicker`。这是使用现代 time-only 类型的 .NET 6+ 应用程序的
首选。除了值类型之外，API 与 `TimeRangePicker` 完全相同。

Do NOT use `TimeOnlyRangePicker` when your models use `TimeSpan` — use
`TimeRangePicker` instead. Do NOT use it for date input.

当模型使用 `TimeSpan` 时不要使用——应使用 `TimeRangePicker`。不要用它输入日期。

## Basic Usage / 基本使用

### Default / 默认

```xml
xmlns:u="https://irihi.tech/ursa"

<u:TimeOnlyRangePicker Width="300" />
```

### With custom formats / 带自定义格式

```xml
<u:TimeOnlyRangePicker Width="300"
                       DisplayFormat="HH:mm"
                       PanelFormat="HH mm" />
```

### Two-way binding / 双向绑定

```xml
<u:TimeOnlyRangePicker Width="300"
                       SelectedStartTime="{Binding StartTime, Mode=TwoWay}"
                       SelectedEndTime="{Binding EndTime, Mode=TwoWay}" />
```

```csharp
// ViewModel — uses TimeOnly
public TimeOnly? StartTime { get; set; }
public TimeOnly? EndTime { get; set; }
```

### With NeedConfirmation / 带确认模式

```xml
<u:TimeOnlyRangePicker Width="300"
                       NeedConfirmation="True"
                       SelectedStartTime="{Binding StartTime}"
                       SelectedEndTime="{Binding EndTime}" />
```

### Read-only / 只读

```xml
<u:TimeOnlyRangePicker Width="300"
                       IsReadOnly="True"
                       SelectedStartTime="09:00:00"
                       SelectedEndTime="17:30:00" />
```

### Clear button / 清除按钮

```xml
<u:TimeOnlyRangePicker Width="300" Classes="ClearButton" />
```

## Comparison with TimeRangePicker / 与 TimeRangePicker 的比较

| Aspect | `TimeRangePicker` | `TimeOnlyRangePicker` |
|---|---|---|
| Value type | `TimeSpan?` | `TimeOnly?` |
| Obsolete aliases | `StartTime` / `EndTime` | None |
| Style key | `TimeRangePickerBase` | `TimeRangePickerBase` (shared) |
| Base class | `TimeRangePickerBase<TimeSpan>` | `TimeRangePickerBase<TimeOnly>` |

## Property Reference / 属性参考

### TimeOnlyRangePicker Properties / TimeOnlyRangePicker 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedStartTime` | `TimeOnly?` | `null` | Start time of range (two-way) / 范围的开始时间（双向绑定） |
| `SelectedEndTime` | `TimeOnly?` | `null` | End time of range (two-way) / 范围的结束时间（双向绑定） |
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

### Methods / 方法

| Method | Description / 说明 |
|---|---|
| `Clear()` | Resets both `SelectedStartTime` and `SelectedEndTime` to `null`, clears presenters / 将 `SelectedStartTime` 和 `SelectedEndTime` 都重置为 `null`，清除展示控件 |
| `Confirm()` | Commits pending time selections (when `NeedConfirmation=True`) / 提交待定时间选择（当 `NeedConfirmation=True` 时） |
| `Dismiss()` | Closes the popup without committing / 关闭弹出框但不提交 |

## Styling & Templating / 样式与模板

`TimeOnlyRangePicker` shares the same theme (`TimeRangePickerBase`) and all
style classes with `TimeRangePicker`. See the `TimeRangePicker` reference page
for the full styling reference including theme resources and template parts.

`TimeOnlyRangePicker` 与 `TimeRangePicker` 共享相同的主题（`TimeRangePickerBase`）
和所有样式类。完整样式参考（包括主题资源和模板部件）请参阅 `TimeRangePicker`
参考页。

### Style Classes / 样式类

| Class | Effect |
|---|---|
| `ClearButton` | Shows a clear button on hover when at least one time is set / 至少设置一个时间时悬停显示清除按钮 |
| `Large` | Increases `MinHeight` to `TextBoxLargeHeight` / 将 `MinHeight` 增大到 `TextBoxLargeHeight` |
| `Small` | Decreases `MinHeight` to `TextBoxSmallHeight` / 将 `MinHeight` 减小到 `TextBoxSmallHeight` |

### Template Parts / 模板部件

Same as `TimeRangePicker` — see that reference page.

与 `TimeRangePicker` 相同——请参阅该参考页。

## API Reference / API 参考

- **Namespace**: `Ursa.Controls`
- **Base class**: `TimeRangePickerBase<TimeOnly>` → `TimeRangePickerBase` → `TemplatedControl`
- **Style key override**: `typeof(TimeRangePickerBase)` (shares theme with `TimeRangePicker`)
- **Interfaces**: `IInnerContentControl`, `IPopupInnerContent`, `IClearControl`

## FAQ / 常见问题

**Q: When should I use `TimeOnlyRangePicker` vs `TimeRangePicker`? / 何时使用 `TimeOnlyRangePicker` 而非 `TimeRangePicker`？**
A: Use `TimeOnlyRangePicker` when your models use `TimeOnly` — this provides
clearer semantics and avoids `TimeSpan` confusion (TimeSpan can represent
durations, not just clock times). Use `TimeRangePicker` when your existing
code uses `TimeSpan` for times.

**Q: Does XAML accept `TimeOnly` strings? / XAML 接受 `TimeOnly` 字符串吗？**
A: Yes. Strings like `"09:00:00"`, `"17:30"` are parsed via
`TimeOnly.TryParseExact` using the `DisplayFormat`.

**Q: Does `TimeOnlyRangePicker` have the `StartTime` / `EndTime` obsolete aliases? / `TimeOnlyRangePicker` 有 `StartTime` / `EndTime` 废弃别名吗？**
A: No. The `[Obsolete]` `StartTime` / `EndTime` aliases are only on
`TimeRangePicker` (TimeSpan version). `TimeOnlyRangePicker` only exposes
`SelectedStartTime` / `SelectedEndTime`.
