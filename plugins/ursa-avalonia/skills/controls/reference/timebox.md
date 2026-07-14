---
category: Components
title: TimeBox
subtitle: 时间输入框
description: >
  A segmented time input control with four sections: hours, minutes, seconds,
  and milliseconds. Supports keyboard typing, drag-to-adjust, and auto-carry
  (e.g., 70 seconds → 1 minute 10 seconds). Two input modes: Normal and Fast
  (auto-advance after 2 digits). Configurable drag orientation and leading
  zero display.
  分段式时间输入控件，包含四个部分：时、分、秒和毫秒。支持键盘输入、拖拽调整
  和自动进位（如 70 秒 → 1 分 10 秒）。两种输入模式：Normal 和 Fast（2 位数字
  后自动前进）。可配置拖拽方向和前导零显示。
---

# TimeBox / 时间输入框

## When to Use / 何时使用

Use `TimeBox` when you need a specialized time input that is more efficient than
a full `DateTimePicker` for time-only values. It provides direct keyboard entry
per segment (hours/minutes/seconds/milliseconds), drag-based adjustment, and
automatic carry-over between segments.

使用 `TimeBox` 当您需要一个比完整 `DateTimePicker` 更高效的时间专用输入时。它
为每个部分（时/分/秒/毫秒）提供直接键盘输入、拖拽调整和段间自动进位。

Do NOT use `TimeBox` for date input — it only handles `TimeSpan`. For dates, use
`DatePicker` or `DateTimePicker`.

不要使用 `TimeBox` 输入日期——它仅处理 `TimeSpan`。如需日期，请使用 `DatePicker`
或 `DateTimePicker`。

## Basic Usage / 基本使用

### Simple Time Input / 简单时间输入

```xml
xmlns:u="https://irihi.tech/ursa"

<u:TimeBox Width="200" />
```

### With Binding / 带绑定

```xml
<u:TimeBox Width="200" Time="{Binding MyTimeSpan}" />
```

### Fast Input Mode / 快速输入模式

```xml
<u:TimeBox Width="200" InputMode="Fast" />
```

In `Fast` mode, after typing 2 digits in a section, focus automatically moves to
the next section.

在 `Fast` 模式下，在某个部分输入 2 位数字后，焦点自动移动到下一部分。

## Common Scenarios / 常用场景

### 1. Drag Adjustment / 拖拽调整

```xml
<u:TimeBox Width="200" AllowDrag="True" DragOrientation="Vertical" />
```

When `AllowDrag="True"`, dragging on a section with the mouse increases or
decreases the value. `DragOrientation` controls whether horizontal or vertical
mouse movement drives the change.

当 `AllowDrag="True"` 时，在某个部分上拖拽鼠标可以增加或减少该值。
`DragOrientation` 控制水平或垂直鼠标移动是否驱动更改。

### 2. Leading Zero Display / 前导零显示

```xml
<u:TimeBox Width="200" ShowLeadingZero="True" />
```

When `ShowLeadingZero="True"` (default), hours display as "01", minutes as "05",
etc. When `False`, they display as "1", "5".

当 `ShowLeadingZero="True"`（默认）时，小时显示为 "01"，分钟为 "05" 等。
当 `False` 时，显示为 "1"、"5"。

### 3. Time Loop Mode / 时间循环模式

```xml
<u:TimeBox Width="200" IsTimeLoop="True" />
```

When `IsTimeLoop="True"`, incrementing past the maximum wraps to the minimum
(e.g., 23:59:59 → 00:00:00). When `False`, values clamp at the boundary.

当 `IsTimeLoop="True"` 时，递增超过最大值会循环到最小值（如 23:59:59 →
00:00:00）。当 `False` 时，值在边界处钳制。

### 4. Disabled State / 禁用状态

```xml
<u:TimeBox Width="200" IsEnabled="False" Time="{Binding TimeSpan}" />
```

## Property Reference / 属性参考

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Time` | `TimeSpan?` | `null` | The current time value. Two-way binding. / 当前时间值。双向绑定。 |
| `ShowLeadingZero` | `bool` | `true` (theme) | Whether to display leading zeros (e.g. "01" vs "1"). / 是否显示前导零（如 "01" 与 "1"）。 |
| `InputMode` | `TimeBoxInputMode` | `Normal` | Normal: manual tab; Fast: auto-advance after 2 digits. / Normal：手动 Tab；Fast：2 位数字后自动前进。 |
| `AllowDrag` | `bool` | `false` | Enable drag-based value adjustment. / 启用拖拽调整值。 |
| `DragOrientation` | `TimeBoxDragOrientation` | `Horizontal` | Drag direction: Horizontal or Vertical. / 拖拽方向：Horizontal 或 Vertical。 |
| `IsTimeLoop` | `bool` | `false` | When true, value wraps around at boundaries. / 为 true 时值在边界处循环。 |
| `TextAlignment` | `TextAlignment` | `Center` (theme) | Text alignment in each section. / 每个部分的文字对齐方式。 |
| `SelectionBrush` | `IBrush?` | (theme) | Brush for selected text. / 选中文本的画刷。 |
| `SelectionForegroundBrush` | `IBrush?` | (theme) | Foreground brush for selected text. / 选中文本的前景画刷。 |
| `CaretBrush` | `IBrush?` | (theme) | Brush for the caret. / 光标的画刷。 |

### TimeBoxInputMode Enum / TimeBoxInputMode 枚举

| Value | Description / 说明 |
|---|---|
| `Normal` | User must press Tab or click to move between sections. / 用户必须按 Tab 或点击在各部分间移动。 |
| `Fast` | After entering 2 digits, focus automatically advances. / 输入 2 位数字后，焦点自动前进。 |

### TimeBoxDragOrientation Enum / TimeBoxDragOrientation 枚举

| Value | Description / 说明 |
|---|---|
| `Horizontal` | Left/right mouse movement adjusts values. / 左右鼠标移动调整值。 |
| `Vertical` | Up/down mouse movement adjusts values. / 上下鼠标移动调整值。 |

## Events / 事件

No custom events. Inherits standard `TemplatedControl` events. Value changes are
communicated through the `Time` property (two-way binding). Pressing `Enter`
commits the current input and fires `OnKeyDown`.

无自定义事件。继承标准 `TemplatedControl` 事件。值变化通过 `Time` 属性（双向
绑定）传递。按 `Enter` 键提交当前输入并触发 `OnKeyDown`。

## Styling & Templating / 样式与模板

### ControlTheme Key

| Theme Key | Target Type | Description / 说明 |
|---|---|---|
| `{x:Type u:TimeBox}` | `TimeBox` | Main theme: a `Border` with a 4-section `Grid` (HH : MM : SS . mmm). / 主主题：带 4 部分 `Grid`（HH : MM : SS . mmm）的 `Border`。 |

### Template Parts / 模板部件

| Part Name | Control | Type | Section |
|---|---|---|---|
| `PART_HourBorder` | `TimeBox` | `Border` | Hours / 时 |
| `PART_MinuteBorder` | `TimeBox` | `Border` | Minutes / 分 |
| `PART_SecondBorder` | `TimeBox` | `Border` | Seconds / 秒 |
| `PART_MilliSecondBorder` | `TimeBox` | `Border` | Milliseconds / 毫秒 |
| `PART_HourTextPresenter` | `TimeBox` | `TextPresenter` | Hours text / 时文字 |
| `PART_MinuteTextPresenter` | `TimeBox` | `TextPresenter` | Minutes text / 分文字 |
| `PART_SecondTextPresenter` | `TimeBox` | `TextPresenter` | Seconds text / 秒文字 |
| `PART_MillisecondTextPresenter` | `TimeBox` | `TextPresenter` | Ms text / 毫秒文字 |
| `PART_HourDragPanel` | `TimeBox` | `Panel` | Hours drag / 时拖拽 |
| `PART_MinuteDragPanel` | `TimeBox` | `Panel` | Minutes drag / 分拖拽 |
| `PART_SecondDragPanel` | `TimeBox` | `Panel` | Seconds drag / 秒拖拽 |
| `PART_MilliSecondDragPanel` | `TimeBox` | `Panel` | Ms drag / 毫秒拖拽 |

### Pseudo-classes / 伪类

| Pseudo-class | Description / 说明 |
|---|---|
| `:focus-within` | Border brush changes to focus color. / 边框画刷变为焦点颜色。 |
| `:disabled` | Disabled background/foreground/border. / 禁用背景/前景/边框。 |
| `[DragOrientation=Horizontal]` | Drag panels show east-west cursor. / 拖拽面板显示东西方向光标。 |
| `[DragOrientation=Vertical]` | Drag panels show north-south cursor. / 拖拽面板显示南北方向光标。 |

### Theme Resources

| Resource Key | Applies To | Description / 说明 |
|---|---|---|
| `TextBoxDefaultBackground` | Border background | Default background. / 默认背景。 |
| `TextBoxDefaultBorderBrush` | Border border | Default border. / 默认边框。 |
| `TextBoxDefaultCornerRadius` | Border, section borders | Corner radius. / 圆角。 |
| `TextBoxDefaultHeight` | MinHeight | Minimum height. / 最小高度。 |
| `TextBoxBorderThickness` | BorderThickness | Border thickness. / 边框粗细。 |
| `TextBoxFocusBorderBrush` | Focus border | Focus state border. / 焦点状态边框。 |
| `TextBoxSelectionBackground` | SelectionBrush | Selection highlight. / 选择高亮。 |
| `TextBoxSelectionForeground` | SelectionForegroundBrush | Selection text color. / 选择文字颜色。 |
| `TextBoxTextCaretBrush` | CaretBrush | Caret color. / 光标颜色。 |
| `TextBoxDisabledBackground` | Disabled state | Disabled background. / 禁用背景。 |
| `TextBoxDisabledForeground` | Disabled state | Disabled foreground. / 禁用前景。 |
| `TextBoxDisabledBorderBrush` | Disabled state | Disabled border. / 禁用边框。 |

## FAQ / 常见问题

**Q: How do I get the TimeSpan value? / 如何获取 TimeSpan 值？**
A: Bind the `Time` property or read it programmatically:
```csharp
TimeSpan? time = myTimeBox.Time;
```

**Q: What are the valid ranges for each section? / 每个部分的有效范围是多少？**
A: Hours: 0–23, Minutes: 0–59, Seconds: 0–59, Milliseconds: 0–999. The control
automatically handles carry-over (e.g., 70 minutes → 1 hour 10 minutes).

**Q: Can I restrict input to only hours and minutes? / 可以限制仅输入小时和分钟吗？**
A: Not directly — all four sections are always rendered. You could re-template
the control or set the seconds/milliseconds sections to read-only if needed.

**Q: What's the difference between Normal and Fast input modes?**
A: In `Normal` mode, the user must press Tab or click to move between sections.
In `Fast` mode, after typing 2 digits (or 3 for milliseconds), the cursor
auto-advances to the next section.

**Q: How does drag adjustment work? / 拖拽调整如何工作？**
A: When `AllowDrag="True"`, a transparent drag panel overlays each section.
Dragging left/right (`Horizontal`) or up/down (`Vertical`) increases/decreases
the value. The drag panel is hidden when the section is actively being edited.
