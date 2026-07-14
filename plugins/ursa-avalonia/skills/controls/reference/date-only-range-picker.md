---
category: Components
title: DateOnlyRangePicker
subtitle: DateOnly 日期范围选择器
description: >
  A date range picker that returns `DateOnly?` values. Identical in behavior to
  `DateRangePicker` but uses `DateOnly` instead of `DateTime` for
  `SelectedStartDate` / `SelectedEndDate`. No time or offset components.
  Shares the `DateRangePickerBase` theme via style key override.
  返回 `DateOnly?` 值的日期范围选择器。行为与 `DateRangePicker` 相同，但使用
  `DateOnly` 而非 `DateTime` 作为 `SelectedStartDate` / `SelectedEndDate`。
  无时间或偏移组件。通过样式键覆盖共享 `DateRangePickerBase` 主题。
---

# DateOnlyRangePicker / DateOnly 日期范围选择器

## When to Use / 何时使用

Use `DateOnlyRangePicker` when your application models dates as `DateOnly`
and you need a range picker. This is the preferred choice for .NET 6+
applications that use the modern date-only type. The API surface is identical
to `DateRangePicker` except the value type is `DateOnly` instead of `DateTime`.

当应用程序将日期建模为 `DateOnly` 且需要范围选择器时使用 `DateOnlyRangePicker`。
这是使用现代 date-only 类型的 .NET 6+ 应用程序的首选。除了值类型是 `DateOnly`
而非 `DateTime` 之外，API 表面与 `DateRangePicker` 完全相同。

Do NOT use `DateOnlyRangePicker` when you need `DateTimeKind` semantics — use
`DateRangePicker` instead. Do NOT use it for time-of-day selection.

当需要 `DateTimeKind` 语义时不要使用——应使用 `DateRangePicker`。不要用它选择
具体时间。

## Basic Usage / 基本使用

### Default / 默认

```xml
xmlns:u="https://irihi.tech/ursa"

<u:DateOnlyRangePicker Width="360" />
```

### With custom display format / 带自定义显示格式

```xml
<u:DateOnlyRangePicker Width="360" DisplayFormat="yyyy/MM/dd" />
```

### Two-way binding / 双向绑定

```xml
<u:DateOnlyRangePicker Width="360"
                       SelectedStartDate="{Binding StartDate, Mode=TwoWay}"
                       SelectedEndDate="{Binding EndDate, Mode=TwoWay}" />
```

```csharp
// ViewModel — uses DateOnly
public DateOnly? StartDate { get; set; }
public DateOnly? EndDate { get; set; }
```

### Read-only with pre-set values / 带预设值的只读模式

```xml
<u:DateOnlyRangePicker Width="360"
                       IsReadOnly="True"
                       SelectedStartDate="2025-06-26"
                       SelectedEndDate="2025-06-30" />
```

### Clear button / 清除按钮

```xml
<u:DateOnlyRangePicker Width="360" Classes="ClearButton" />
```

## Comparison with DateRangePicker / 与 DateRangePicker 的比较

| Aspect | `DateRangePicker` | `DateOnlyRangePicker` |
|---|---|---|
| Value type | `DateTime?` | `DateOnly?` |
| `DefaultDateKind` | Yes (`DateTimeKind`) | No (not applicable) |
| Time component | No (always midnight) | No (pure date) |
| Style key | `DateRangePickerBase` | `DateRangePickerBase` (shared) |
| Base class | `DateRangePickerBase<DateTime>` | `DateRangePickerBase<DateOnly>` |

## Property Reference / 属性参考

### DateOnlyRangePicker Properties / DateOnlyRangePicker 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedStartDate` | `DateOnly?` | `null` | Start date of range (two-way) / 范围的开始日期（双向绑定） |
| `SelectedEndDate` | `DateOnly?` | `null` | End date of range (two-way) / 范围的结束日期（双向绑定） |
| `DisplayFormat` | `string?` | `"yyyy-MM-dd"` | Date display format for both text boxes / 两个文本框的日期显示格式 |
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

## Styling & Templating / 样式与模板

`DateOnlyRangePicker` shares the same theme (`DateRangePickerBase`) and all
style classes with `DateRangePicker`. See the `DateRangePicker` reference page
for the full styling reference.

`DateOnlyRangePicker` 与 `DateRangePicker` 共享相同的主题（`DateRangePickerBase`）
和所有样式类。完整样式参考请参阅 `DateRangePicker` 参考页。

### Style Classes / 样式类

| Class | Effect |
|---|---|
| `ClearButton` | Shows a clear button on hover when at least one date is set / 至少设置一个日期时悬停显示清除按钮 |
| `Large` | Increases `MinHeight` to `TextBoxLargeHeight` / 将 `MinHeight` 增大到 `TextBoxLargeHeight` |
| `Small` | Decreases `MinHeight` to `TextBoxSmallHeight` / 将 `MinHeight` 减小到 `TextBoxSmallHeight` |

### Template Parts / 模板部件

Same as `DateRangePicker` — see that reference page.

与 `DateRangePicker` 相同——请参阅该参考页。

## API Reference / API 参考

- **Namespace**: `Ursa.Controls`
- **Base class**: `DateRangePickerBase<DateOnly>` → `DateRangePickerBase` → `TemplatedControl`
- **Style key override**: `typeof(DateRangePickerBase)` (shares theme with `DateRangePicker`)
- **Interfaces**: `IInnerContentControl`, `IPopupInnerContent`, `IClearControl`

## FAQ / 常见问题

**Q: When should I use `DateOnlyRangePicker` vs `DateRangePicker`? / 何时使用 `DateOnlyRangePicker` 而非 `DateRangePicker`？**
A: Use `DateOnlyRangePicker` when your models use `DateOnly` — this avoids
`DateTimeKind` confusion and midnight-time noise. Use `DateRangePicker` when
you need `DateTimeKind` semantics or compatibility with `DateTime`-based APIs.

**Q: Does XAML accept `DateOnly` strings? / XAML 接受 `DateOnly` 字符串吗？**
A: Yes. Strings like `"2025-06-26"` are parsed via `DateOnly.TryParseExact`
using the `DisplayFormat` (default `"yyyy-MM-dd"`).

**Q: Can I use `DateOnlyRangePicker` with `DateTimeOffset` bindings? / 可以将 `DateOnlyRangePicker` 与 `DateTimeOffset` 绑定一起使用吗？**
A: No — the value types must match. Use `DateOffsetRangePicker` for
`DateTimeOffset` ranges.
