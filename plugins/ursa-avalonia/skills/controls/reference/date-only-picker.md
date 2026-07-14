---
category: Components
title: DateOnlyPicker
subtitle: DateOnly 日期选择器
description: >
  A single-date picker using .NET 6+ DateOnly type. Identical API to DatePicker
  but operates on DateOnly values instead of DateTime, avoiding time-zone and
  time-component ambiguity. Based on DatePickerBase&lt;DateOnly&gt;.
  使用 .NET 6+ DateOnly 类型的单日期选择器。API 与 DatePicker 相同，但操作于
  DateOnly 值而非 DateTime，避免时区和时间组件歧义。基于
  DatePickerBase&lt;DateOnly&gt;。
---

# DateOnlyPicker / DateOnly 日期选择器

## When to Use / 何时使用

Use `DateOnlyPicker` when you need date-only semantics without any time component,
and your project targets .NET 6 or later. It is functionally identical to
`DatePicker` but the `SelectedDate` property is typed as `DateOnly?` instead of
`DateTime?`. This avoids DateTimeKind confusion and makes intent clearer in your
data model.

当需要仅日期语义（无时间组件）且项目目标为 .NET 6 或更高版本时，使用
`DateOnlyPicker`。它在功能上与 `DatePicker` 相同，但 `SelectedDate` 属性类型为
`DateOnly?` 而非 `DateTime?`。这避免了 DateTimeKind 混淆，并使数据模型中的意图
更加清晰。

If you need DateTimeKind control or are targeting older .NET versions, use
`DatePicker` instead.

如果需要 DateTimeKind 控制或面向较旧的 .NET 版本，请使用 `DatePicker`。

## Basic Usage / 基本使用

### DateOnly binding / DateOnly 绑定

```xml
xmlns:u="https://irihi.tech/ursa"

<u:DateOnlyPicker SelectedDate="{Binding BirthDate}" />
```

```csharp
// ViewModel (.NET 6+)
public DateOnly? BirthDate { get; set; }
```

### With display format / 带显示格式

```xml
<u:DateOnlyPicker SelectedDate="{Binding Anniversary}"
                  DisplayFormat="yyyy/MM/dd" />
```

### Read-only mode / 只读模式

```xml
<u:DateOnlyPicker SelectedDate="{Binding ReleaseDate}"
                  IsReadOnly="True" />
```

### With confirmation / 带确认

```xml
<u:DateOnlyPicker SelectedDate="{Binding EventDate}"
                  NeedConfirmation="True" />
```

## Common Scenarios / 常用场景

### 1. Birthday picker (date-only semantics) / 生日选择器

```xml
<u:DateOnlyPicker SelectedDate="{Binding Birthday}"
                  DisplayFormat="yyyy-MM-dd"
                  IsTodayHighlighted="False" />
```

### 2. Blackout dates / 禁用日期

```xml
<u:DateOnlyPicker SelectedDate="{Binding ShipDate}">
    <u:DateOnlyPicker.BlackoutDates>
        <u:DateRange Start="2025-01-01" End="2025-01-03" />
    </u:DateOnlyPicker.BlackoutDates>
</u:DateOnlyPicker>
```

### 3. Weekend blackout rule / 周末禁用规则

```xml
<u:DateOnlyPicker SelectedDate="{Binding Date}"
                  BlackoutDateRule="{x:Static u:WeekendDateSelector.Instance}" />
```

### 4. Programmatic control / 编程控制

```xml
<u:DateOnlyPicker x:Name="MyPicker"
                  SelectedDate="{Binding Date}" />
```

```csharp
// Open/close programmatically
MyPicker.IsDropdownOpen = true;
MyPicker.Clear();
MyPicker.Dismiss();
```

## Property Reference / 属性参考

### DateOnlyPicker Properties / DateOnlyPicker 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedDate` | `DateOnly?` | `null` | The selected date (two-way binding) / 选中的日期（双向绑定） |
| `DisplayFormat` | `string?` | `"yyyy-MM-dd"` | .NET format string for display and parsing / 用于显示和解析的 .NET 格式字符串 |
| `BlackoutDates` | `AvaloniaList<DateRange>` | (empty) | List of date ranges that cannot be selected / 不可选择的日期范围列表 |
| `BlackoutDateRule` | `IDateSelector?` | `null` | Rule-based date exclusion / 基于规则的日期排除 |
| `FirstDayOfWeek` | `DayOfWeek` | (culture) | First day shown in calendar / 日历显示的第一天 |
| `IsTodayHighlighted` | `bool` | `true` | Whether today is visually highlighted / 是否视觉高亮今天 |
| `IsDropdownOpen` | `bool` | `false` | Whether the popup is open (two-way) / 弹出层是否打开（双向） |
| `IsReadOnly` | `bool` | `false` | Prevent user editing and dropdown / 禁止用户编辑和下拉 |
| `NeedConfirmation` | `bool` | `false` | Require explicit confirmation before committing / 提交前需要显式确认 |
| `PlaceholderText` | `string?` | `null` | Text shown when no date is selected / 未选择日期时显示的文本 |
| `PlaceholderForeground` | `IBrush?` | (theme) | Brush for placeholder text / 占位文本的画刷 |
| `InnerLeftContent` | `object?` | `null` | Content inside text box on the left / 文本框内左侧内容 |
| `InnerRightContent` | `object?` | `null` | Content inside text box on the right / 文本框内右侧内容 |
| `PopupInnerTopContent` | `object?` | `null` | Content at popup top / 弹出层顶部内容 |
| `PopupInnerBottomContent` | `object?` | `null` | Content at popup bottom / 弹出层底部内容 |

### Differences from DatePicker / 与 DatePicker 的区别

| Feature | DatePicker | DateOnlyPicker |
|---|---|---|
| Selected value type | `DateTime?` | `DateOnly?` |
| `DefaultDateKind` | Yes | No (not applicable) |
| .NET version | All | .NET 6+ |
| Time-zone ambiguity | Present | None |

### Methods / 方法

| Method | Description / 说明 |
|---|---|
| `Clear()` | Clears the selected date / 清除选中日期 |
| `Confirm()` | Commits pending selection (confirmation mode) / 提交待定选择（确认模式） |
| `Dismiss()` | Closes the dropdown without committing / 关闭下拉框但不提交 |

## Events / 事件

`DateOnlyPicker` inherits standard `TemplatedControl` events. Date changes are
observed via `SelectedDate` (binding or `PropertyChanged`).

`DateOnlyPicker` 继承标准 `TemplatedControl` 事件。日期变更通过 `SelectedDate`
（绑定或 `PropertyChanged`）观察。

### Keyboard shortcuts / 键盘快捷键

| Key | Action / 动作 |
|---|---|
| `↓` (Down) | Open dropdown / 打开下拉 |
| `Escape` | Close dropdown / 关闭下拉 |
| `Tab` | Close dropdown / 关闭下拉 |
| `Enter` | Close dropdown and commit input / 关闭下拉并提交输入 |

## Styling & Templating / 样式与模板

`DateOnlyPicker` shares the exact same theme as `DatePicker` — it targets
`DatePickerBase` as its `StyleKeyOverride`. Refer to the DatePicker reference
page for the complete styling table.

`DateOnlyPicker` 与 `DatePicker` 共享完全相同的主题——其 `StyleKeyOverride`
指向 `DatePickerBase`。完整的样式表请参阅 DatePicker 参考页面。

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_Popup` | `DatePickerBase` | `Popup` |
| `PART_TextBox` | `DatePickerBase` | `TextBox` |
| `PART_Calendar` | `DatePickerBase` | `DatePickerCalendarView` |

### Style Classes / 样式类

| Class | Effect / 效果 |
|---|---|
| `Large` | Increases `MinHeight` to `TextBoxLargeHeight` |
| `Small` | Decreases `MinHeight` to `TextBoxSmallHeight` |
| `clearButton` / `ClearButton` | Enables clear-button hover behavior |

### Pseudo-classes / 伪类

| Pseudo-class | Condition / 条件 |
|---|---|
| `:empty` | No date selected / 未选择日期 |
| `:pointerover` | Mouse over the control / 鼠标悬停 |
| `:disabled` | Control is disabled / 控件已禁用 |
| `:focus-within` | Focus is within the control / 焦点在控件内 |

## FAQ / 常见问题

**Q: When should I use DateOnlyPicker instead of DatePicker?**

A: Use `DateOnlyPicker` when your data model uses `DateOnly` (e.g., birth dates,
anniversaries, release dates). If you need DateTimeKind or interop with older
code, use `DatePicker`.

当数据模型使用 `DateOnly`（如生日、纪念日、发布日期）时使用 `DateOnlyPicker`。
如果需要 DateTimeKind 或与旧代码的互操作，请使用 `DatePicker`。

**Q: Does DateOnlyPicker have DateTimeKind?**

A: No. `DateOnly` has no concept of UTC/Local/Unspecified — that is the entire
point. If you need DateTimeKind, use `DatePicker` with its `DefaultDateKind`
property.

没有。`DateOnly` 没有 UTC/Local/Unspecified 的概念——这正是其意义所在。如果
需要 DateTimeKind，请使用带 `DefaultDateKind` 属性的 `DatePicker`。

**Q: Can I convert between DatePicker and DateOnlyPicker bindings?**

A: Yes. In your ViewModel, convert via `DateOnly.FromDateTime(dt)` and
`dateOnly.ToDateTime(TimeOnly.MinValue)`. Choose the picker that matches your
property type to avoid conversion.

可以。在 ViewModel 中通过 `DateOnly.FromDateTime(dt)` 和
`dateOnly.ToDateTime(TimeOnly.MinValue)` 转换。选择与属性类型匹配的选择器以
避免转换。

**Q: Are blackout dates and rules the same as DatePicker?**

A: Yes. `DateRange` works with `DateTime`, and `IDateSelector.Match` receives
`DateTime?`. The conversion is handled internally.

是的。`DateRange` 使用 `DateTime`，`IDateSelector.Match` 接收 `DateTime?`。
转换在内部处理。
