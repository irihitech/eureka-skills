---
category: Components
title: NumberDisplayer
subtitle: 数字显示器
description: >
  An animated number display control that smoothly interpolates between old and
  new values when they change. Supports Int32, Int64, Double, and DateTime
  variants, with configurable duration, string format, and selectable text mode.
  Ideal for dashboards, counters, and statistics displays.
  一个带动画的数字显示控件，当值变化时在旧值和新值之间平滑插值。支持 Int32、
  Int64、Double 和 DateTime 变体，可配置持续时间、字符串格式和可选文本模式。
  适用于仪表盘、计数器和统计数据显示。
---

# NumberDisplayer / 数字显示器

## When to Use / 何时使用

Use `NumberDisplayer` (and its derived classes) to display numeric or date
values with a smooth animation transition when the value changes. It is ideal
for dashboards, live counters, statistics panels, and anywhere you want values
to "tick" up or down rather than snap instantly.

使用 `NumberDisplayer`（及其派生类）在新旧值之间以平滑动画过渡显示数字或日期值。
适用于仪表盘、实时计数器、统计面板以及任何希望值以"滚动"方式变化而非瞬间跳变的
场景。

Do NOT use `NumberDisplayer` for editable number input — use `NumericUpDown`
or `TextBox` instead. `NumberDisplayer` is read-only display.

不要将 `NumberDisplayer` 用于可编辑的数字输入——应使用 `NumericUpDown` 或
`TextBox`。`NumberDisplayer` 是只读显示。

## Basic Usage / 基本使用

### Int32 Display / Int32 显示

```xml
xmlns:u="https://irihi.tech/ursa"

<u:Int32Displayer Value="{Binding Count}" />
```

### Double with Format / 带格式的 Double

```xml
<u:DoubleDisplayer StringFormat="N2" Value="{Binding Percentage}" />
```

### DateTime Display / DateTime 显示

```xml
<u:DateDisplay
    FontSize="30"
    StringFormat="yyyy-MM-dd"
    Value="{Binding DateValue}" />
```

### Selectable Text / 可选文本

```xml
<u:Int32Displayer Value="{Binding Count}" IsSelectable="True" />
```

## Common Scenarios / 常用场景

### Dashboard Counter / 仪表盘计数器

```xml
<StackPanel>
    <Button Command="{Binding IncreaseCommand}" Content="Increase" />
    <u:Int32Displayer Value="{Binding Value}" Duration="0:0:0.5" FontSize="48" />
</StackPanel>
```

When `Value` changes, the display smoothly animates from the old value to the
new one over the configured `Duration` (default 0.2 seconds).

当 `Value` 变化时，显示器在配置的 `Duration`（默认 0.2 秒）内从旧值平滑动画到
新值。

## Property Reference / 属性参考

### NumberDisplayerBase Properties / NumberDisplayerBase 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Duration` | `TimeSpan` | `0:0:0.2` | Animation duration for value transitions. / 值过渡的动画持续时间。 |
| `StringFormat` | `string` | `""` | .NET format string for display (e.g. "N2", "yyyy-MM-dd"). / 显示的 .NET 格式字符串（如 "N2"、"yyyy-MM-dd"）。 |
| `IsSelectable` | `bool` | `false` | When true, the text is selectable (uses `SelectableTextBlock`). / 为 true 时文本可选择（使用 `SelectableTextBlock`）。 |
| `InternalText` | `string?` | `null` | (Read-only) The current animated display text. / （只读）当前动画显示文本。 |

### NumberDisplayer<T> Properties / NumberDisplayer\<T\> 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Value` | `T?` | `null` | The bound value. Two-way binding. Changing this triggers animation. / 绑定的值。双向绑定。更改此值会触发动画。 |

### Derived Classes / 派生类

| Class | Value Type | Description / 说明 |
|---|---|---|
| `Int32Displayer` | `int` | Animated integer display. / 带动画的整数显示。 |
| `Int64Displayer` | `long` | Animated 64-bit integer display. / 带动画的 64 位整数显示。 |
| `DoubleDisplayer` | `double` | Animated floating-point display. / 带动画的浮点数显示。 |
| `DateDisplay` | `DateTime` | Animated date/time display. / 带动画的日期/时间显示。 |

## Events / 事件

No custom events. Inherits standard `TemplatedControl` events. Value changes
are communicated through the `Value` property (two-way binding).

无自定义事件。继承标准 `TemplatedControl` 事件。值变化通过 `Value` 属性（双向
绑定）传递。

## Styling & Templating / 样式与模板

### ControlTheme Key

| Theme Key | Target Type | Description / 说明 |
|---|---|---|
| `{x:Type u:NumberDisplayerBase}` | `NumberDisplayerBase` | Main theme for all derived classes. Renders a `TextBlock`. / 所有派生类的主主题。渲染一个 `TextBlock`。 |

### Pseudo-classes / 伪类

| Pseudo-class | Description / 说明 |
|---|---|
| `[IsSelectable=True]` | Switches to `SelectableTextBlock` instead of `TextBlock`. / 切换为 `SelectableTextBlock` 而非 `TextBlock`。 |

### Inherited Styling Properties

Since `NumberDisplayerBase` extends `TemplatedControl`, standard font and
foreground properties apply:

| Property | Description / 说明 |
|---|---|
| `FontSize` | Text size. / 文字大小。 |
| `Foreground` | Text color. / 文字颜色。 |
| `FontFamily` | Text font. / 文字字体。 |
| `FontWeight` | Text weight. / 文字粗细。 |
| `Background` | Background color. / 背景颜色。 |

## FAQ / 常见问题

**Q: How do I change the animation speed? / 如何更改动画速度？**
A: Set the `Duration` property to the desired `TimeSpan`:
```xml
<u:Int32Displayer Value="{Binding Count}" Duration="0:0:1" />
```

**Q: What happens if I set Value to null? / 如果 Value 设为 null 会怎样？**
A: The display shows an empty string when `Value` is `null`.

**Q: Can I animate custom numeric types? / 可以动画自定义数值类型吗？**
A: You would need to create a new class deriving from `NumberDisplayer<T>` and
implement `GetAnimator()` and `GetString()`. The built-in types cover int, long,
double, and DateTime.

**Q: Does the control support text selection? / 控件支持文本选择吗？**
A: Set `IsSelectable="True"` to switch from `TextBlock` to `SelectableTextBlock`.
By default text is not selectable.

**Q: How do I format the displayed value? / 如何格式化显示的值？**
A: Use `StringFormat` with standard .NET format specifiers:
```xml
<u:DoubleDisplayer StringFormat="N2" Value="{Binding Price}" />
<u:DateDisplay StringFormat="yyyy-MM-dd" Value="{Binding Date}" />
```
