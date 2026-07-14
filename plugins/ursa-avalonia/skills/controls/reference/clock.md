---
category: Components
title: Clock
subtitle: 时钟
description: >
  A customizable analog clock control with hour/minute/second hands, configurable
  tick marks, smooth sweep animation, and two-way DateTime binding. Renders hands
  via RotateTransform driven by computed HourAngle / MinuteAngle / SecondAngle.
  可自定义的模拟时钟控件，支持时/分/秒指针、可配置的刻度线、平滑扫秒动画和双向
  DateTime 绑定。通过 RotateTransform 驱动的计算角度 HourAngle / MinuteAngle /
  SecondAngle 渲染指针。
---

# Clock / 时钟

## When to Use / 何时使用

Use `Clock` to display an analog clock face with configurable hands and tick marks.
It binds two-way to a `DateTime` and updates hand angles automatically. It is
suitable for time-picker dials, status panels, or any UI that needs a visual
clock representation.

使用 `Clock` 显示可配置指针和刻度的模拟时钟表盘。它与 `DateTime` 进行双向绑定，
并自动更新指针角度。适用于时间选择器表盘、状态面板或任何需要可视化时钟的 UI。

Do NOT use `Clock` as a duration timer or stopwatch — it renders a clock face,
not elapsed-time logic. Use a standard `Timer` for timing needs.

不要将 `Clock` 用作持续计时器或秒表——它渲染的是时钟表盘，而非经过时间的逻辑。
如需计时功能，请使用标准 `Timer`。

## Basic Usage / 基本使用

### Simple clock with time binding / 带时间绑定的简单时钟

```xml
xmlns:u="https://irihi.tech/ursa"

<u:Clock Time="{Binding CurrentTime}" />
```

### Clock with only hour and minute hands / 仅有时针和分针的时钟

```xml
<u:Clock Time="{Binding CurrentTime}"
         ShowSecondHand="False" />
```

### Smooth sweep second hand / 平滑扫秒

```xml
<u:Clock Time="{Binding CurrentTime}"
         IsSmooth="True" />
```

When `IsSmooth` is `True`, the second hand uses a 1-second `Animation` to
smoothly transition between seconds instead of jumping.

当 `IsSmooth` 为 `True` 时，秒针使用 1 秒 `Animation` 在秒之间平滑过渡，而非跳变。

### Custom hand color / 自定义指针颜色

```xml
<u:Clock Time="{Binding CurrentTime}"
         HandBrush="{DynamicResource SemiColorPrimary}" />
```

### Hide ticks / 隐藏刻度

```xml
<u:Clock Time="{Binding CurrentTime}"
         ShowHourTicks="False"
         ShowMinuteTicks="False" />
```

## Common Scenarios / 常用场景

### 1. Live clock with smooth sweep / 带平滑扫秒的实时时钟

Bind `Time` to a `DateTime` property that updates every second. Enable `IsSmooth`
for a continuous sweep look.

将 `Time` 绑定到每秒更新的 `DateTime` 属性。启用 `IsSmooth` 获得连续扫秒效果。

```xml
<u:Clock Time="{Binding Now}" IsSmooth="True" />
```

### 2. Time picker companion / 时间选择器伴侣

Use `Clock` inside a time-picker popup to let users visually confirm the selected
time.

在时间选择器弹出框中使用 `Clock`，让用户直观确认所选时间。

```xml
<Popup IsOpen="{Binding IsPickerOpen}">
    <u:Clock Time="{Binding SelectedTime}" />
</Popup>
```

### 3. Minimalist clock (no ticks, no seconds) / 极简时钟（无刻度，无秒针）

```xml
<u:Clock Time="{Binding Time}"
         ShowHourTicks="False"
         ShowMinuteTicks="False"
         ShowSecondHand="False" />
```

## Property Reference / 属性参考

### Clock Properties / Clock 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Time` | `DateTime` | (default) | Current time displayed on the clock (two-way) / 时钟显示的当前时间（双向绑定） |
| `ShowHourTicks` | `bool` | `true` | Show 12 hour tick marks / 显示 12 个小时刻度 |
| `ShowMinuteTicks` | `bool` | `true` | Show 60 minute tick marks / 显示 60 个分钟刻度 |
| `ShowHourHand` | `bool` | `true` | Show the hour hand / 显示时针 |
| `ShowMinuteHand` | `bool` | `true` | Show the minute hand / 显示分针 |
| `ShowSecondHand` | `bool` | `true` | Show the second hand / 显示秒针 |
| `HandBrush` | `IBrush?` | (theme) | Brush for all clock hands / 所有指针的画刷 |
| `IsSmooth` | `bool` | `false` | Animate second hand between seconds / 在秒之间动画秒针 |
| `HourAngle` | `double` | (read-only) | Computed hour hand angle in degrees / 计算出的时针角度（度） |
| `MinuteAngle` | `double` | (read-only) | Computed minute hand angle in degrees / 计算出的分针角度（度） |
| `SecondAngle` | `double` | (read-only) | Computed second hand angle in degrees / 计算出的秒针角度（度） |

### ClockTicks Properties (child control) / ClockTicks 属性（子控件）

`ClockTicks` is the internal control that renders tick marks. Its properties are
exposed via `Clock` with the same names.

`ClockTicks` 是渲染刻度的内部控件。其属性通过 `Clock` 以相同名称暴露。

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `HourTickForeground` | `IBrush?` | (theme) | Foreground for hour tick marks / 小时刻度前景色 |
| `MinuteTickForeground` | `IBrush?` | (theme) | Foreground for minute tick marks / 分钟刻度前景色 |
| `HourTickLength` | `double` | `10` | Length of hour tick marks / 小时刻度长度 |
| `MinuteTickLength` | `double` | `5` | Length of minute tick marks / 分钟刻度长度 |
| `HourTickWidth` | `double` | `2` | Stroke width of hour tick marks / 小时刻度线宽 |
| `MinuteTickWidth` | `double` | `1` | Stroke width of minute tick marks / 分钟刻度线宽 |

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `ClockHandBrush` | All hands | Default hand brush / 默认指针画刷 |
| `ClockHourTickForeground` | Hour ticks | Hour tick mark color / 小时刻度颜色 |
| `ClockMinuteTickForeground` | Minute ticks | Minute tick mark color / 分钟刻度颜色 |
| `ClockArborFill` | Center ellipse | Fill of the central arbor dot / 中心轴点填充 |
| `ClockArborStroke` | Center ellipse | Stroke of the central arbor dot / 中心轴点描边 |

### Template Parts / 模板部件

| Part Name | Type | Description |
|---|---|---|
| `PART_ClockTicks` | `ClockTicks` | The tick-mark rendering control / 刻度渲染控件 |

### How the Template Works / 模板工作原理

The default template uses three `UniformGrid` panels (Rows=2) stacked on top of
each other, each containing a `Border` that acts as one hand. Each hand has a
`RotateTransform` bound to the corresponding `*Angle` property. The hour and
minute hand lengths are computed by `ClockHandLengthConverter` based on the
parent's `Bounds.Width`. A centered `Ellipse` covers the hand intersection point.

默认模板使用三个堆叠的 `UniformGrid` 面板（Rows=2），每个面板包含一个作为指针的
`Border`。每个指针都有一个 `RotateTransform` 绑定到相应的 `*Angle` 属性。时针
和分针的长度由 `ClockHandLengthConverter` 基于父级 `Bounds.Width` 计算得出。
居中的 `Ellipse` 覆盖指针交叉点。

## API Reference / API 参考

### Clock Class / Clock 类

- **Namespace**: `Ursa.Controls`
- **Base class**: `TemplatedControl`
- **Child control**: `ClockTicks`

### ClockTicks Class / ClockTicks 类

- **Namespace**: `Ursa.Controls`
- **Base class**: `Control`
- **Rendering**: Custom `Render` override using `DrawingContext` with rotation
  matrices for each tick mark.
