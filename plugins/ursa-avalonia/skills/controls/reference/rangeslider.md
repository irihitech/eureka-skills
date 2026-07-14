---
category: Input
title: RangeSlider
subtitle: 范围滑块
description: >
  Dual-thumb slider for selecting a value range (lower–upper). Supports horizontal
  and vertical orientation, tick marks with snap-to-tick, direction reversal, and
  customisable track sections. Each thumb fires distinct ValueChanged events with
  IsLower flag.
  双滑块范围选择控件，用于选择数值区间（下限–上限）。支持水平和垂直方向、刻度线
  与吸附、方向反转和自定义轨道段。每个滑块通过 IsLower 标志触发独立的 ValueChanged
  事件。
---

# RangeSlider / 范围滑块

## When to Use / 何时使用

Use `RangeSlider` when the user needs to select a closed interval `[LowerValue,
UpperValue]` — for example price filters, date ranges, or any bounded numeric
range. Prefer it over two separate `Slider` controls when the upper bound must
stay ≥ the lower bound.

当用户需要选择一个闭区间 `[LowerValue, UpperValue]` 时使用 —— 例如价格筛选、
日期范围或任意有界数值范围。当上限必须 ≥ 下限时优先选择它而非两个独立 `Slider`。

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<u:RangeSlider Minimum="0"
               Maximum="1000"
               LowerValue="200"
               UpperValue="800" />
```

### Two-way binding / 双向绑定

```xml
<u:RangeSlider Minimum="{Binding MinPrice}"
               Maximum="{Binding MaxPrice}"
               LowerValue="{Binding SelectedMin, Mode=TwoWay}"
               UpperValue="{Binding SelectedMax, Mode=TwoWay}" />
```

### Vertical orientation / 垂直方向

```xml
<u:RangeSlider Orientation="Vertical"
               Height="300"
               Minimum="0"
               Maximum="100"
               LowerValue="20"
               UpperValue="80" />
```

## Common Scenarios / 常用场景

### 1. With tick marks / 带刻度线

```xml
<u:RangeSlider Minimum="0"
               Maximum="100"
               LowerValue="25"
               UpperValue="75"
               TickFrequency="10"
               TickPlacement="BottomRight" />
```

`TickPlacement` values: `None` (default), `TopLeft`, `BottomRight`, `Outside`.

### 2. Snap to ticks / 吸附到刻度

```xml
<u:RangeSlider Minimum="0"
               Maximum="100"
               LowerValue="25"
               UpperValue="75"
               TickFrequency="10"
               IsSnapToTick="True" />
```

When `IsSnapToTick` is `true`, thumb positions snap to the nearest tick on
pointer release. If `Ticks` (explicit list) is provided it takes priority over
`TickFrequency`.

当 `IsSnapToTick` 为 `true` 时，滑块在指针释放时吸附到最近的刻度。若提供了
`Ticks`（显式列表），则优先于 `TickFrequency`。

### 3. Custom track width / 自定义轨道宽度

```xml
<u:RangeSlider Minimum="0" Maximum="100"
               LowerValue="30" UpperValue="70"
               TrackWidth="8" />
```

`TrackWidth` controls the visual thickness of the track bars (default: 4).

### 4. Reversed direction / 反向

```xml
<u:RangeSlider Minimum="0" Maximum="100"
               LowerValue="10" UpperValue="90"
               IsDirectionReversed="True" />
```

Reverses the visual direction so the minimum appears on the right (horizontal)
or bottom (vertical).

反转可视方向，使最小值出现在右侧（水平）或底部（垂直）。

### 5. Read-only display / 只读展示

```xml
<u:RangeSlider IsEnabled="False"
               Minimum="0" Maximum="100"
               LowerValue="30" UpperValue="70" />
```

Disabling the control shows the range visually but prevents interaction.

禁用控件可显示范围但不允许交互。

## Property Reference / 属性参考

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Minimum` | `double` | `0` | Minimum value of the range. / 范围最小值 |
| `Maximum` | `double` | `100` | Maximum value of the range. / 范围最大值 |
| `LowerValue` | `double` | `0` | Selected lower bound. Coerced ≤ `UpperValue`. / 选中的下限，强制 ≤ UpperValue |
| `UpperValue` | `double` | `100` | Selected upper bound. Coerced ≥ `LowerValue`. / 选中的上限，强制 ≥ LowerValue |
| `Orientation` | `Orientation` | `Horizontal` | Horizontal or vertical track. / 轨道方向 |
| `IsDirectionReversed` | `bool` | `false` | Reverse the visual direction. / 反转可视方向 |
| `TrackWidth` | `double` | (theme) | Visual thickness of the track bar. / 轨道条的视觉粗细 |
| `TickFrequency` | `double` | `0` | Interval between tick marks (0 = none). / 刻度线间隔（0 = 不显示） |
| `Ticks` | `AvaloniaList<double>?` | `null` | Explicit tick positions (overrides `TickFrequency`). / 显式刻度位置（覆盖 TickFrequency） |
| `TickPlacement` | `TickPlacement` | `None` | Where to show tick marks. / 刻度线位置 |
| `IsSnapToTick` | `bool` | `false` | Snap thumb to nearest tick on release. / 释放时吸附到最近刻度 |

**Pseudo-classes:** `:horizontal`, `:vertical`, `:pressed`, `:disabled`, `:error`.

## Events / 事件

| Event | Args | Description / 说明 |
|---|---|---|
| `ValueChanged` | `RangeValueChangedEventArgs` | Fires when `LowerValue` or `UpperValue` changes. Check `IsLower` to distinguish. / 当 LowerValue 或 UpperValue 变化时触发。通过 `IsLower` 区分 |

### RangeValueChangedEventArgs / 范围值变更事件参数

| Property | Type | Description |
|---|---|---|
| `OldValue` | `double` | Previous value / 旧值 |
| `NewValue` | `double` | New value / 新值 |
| `IsLower` | `bool` | `true` = lower thumb moved; `false` = upper thumb moved / `true` = 下滑块移动; `false` = 上滑块移动 |

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `SliderTrackBackground` | Lower/upper sections | Unselected track colour |
| `SliderTrackForeground` | Inner section | Selected range track colour |
| `SliderTrackDisabledForeground` | Inner section (disabled) | Selected range colour when disabled |
| `SliderTrackDisabledBackground` | Lower/upper sections (disabled) | Track colour when disabled |
| `SliderTickForeground` | TickBar | Tick mark colour |
| `SliderTickHorizontalHeight` | Horizontal TickBar | Height of horizontal tick marks |
| `SliderThumbTheme` | Thumb (both) | `ControlTheme` applied to each thumb |
| `SliderThumbDisabledBorderBrush` | Thumb (disabled) | Thumb border colour when disabled |
| `DataValidationErrorsSelectedBorderBrush` | Thumb (`:error`) | Thumb border on validation error |

### Template Parts / 模板部件

| Part Name | Type | Description |
|---|---|---|
| `PART_Track` | `RangeTrack` | The internal track that hosts thumbs and sections |

### Internal RangeTrack structure / 内部 RangeTrack 结构

The `RangeTrack` arranges five logical zones:

| Zone | Property | Visual |
|---|---|---|
| Lower section | `LowerSection` | Track from `Minimum` to `LowerValue` (background colour) |
| Lower thumb | `LowerThumb` | Draggable thumb at `LowerValue` |
| Inner section | `InnerSection` | Selected range from `LowerValue` to `UpperValue` (foreground colour) |
| Upper thumb | `UpperThumb` | Draggable thumb at `UpperValue` |
| Upper section | `UpperSection` | Track from `UpperValue` to `Maximum` (background colour) |

### Class Selectors / 类选择器

| Class | Effect |
|---|---|
| `:error` | Applied during data validation errors; changes thumb border to error colour |

## FAQ / 常见问题

**Q: How do I prevent the lower value from exceeding the upper value? / 如何防止下限超过上限？**
A: The control coerces values automatically: `LowerValue` is clamped to
`[Minimum, UpperValue]` and `UpperValue` to `[LowerValue, Maximum]`. During
drag, if you push one thumb past the other, the other thumb moves along.

控件自动强制限制：`LowerValue` 被限制在 `[Minimum, UpperValue]`，
`UpperValue` 被限制在 `[LowerValue, Maximum]`。拖动时若将一个滑块推过另一个，
另一个滑块会随之移动。

**Q: What's the difference between RangeSlider and two Sliders? / RangeSlider 与两个 Slider 有什么区别？**
A: `RangeSlider` uses a single `RangeTrack` with co-dependent thumbs — values
stay ordered automatically. Two separate `Slider` controls require manual
validation to keep `LowerValue ≤ UpperValue`.

`RangeSlider` 使用单个 `RangeTrack` 和相互依赖的滑块 —— 值自动保持有序。
两个独立 `Slider` 控件需要手动验证以保证 `LowerValue ≤ UpperValue`。

**Q: Can I customise the section visuals? / 可以自定义轨道段外观吗？**
A: The default template uses `Border` elements with `SliderTrackBackground`
and `SliderTrackForeground` resources. Override the `ControlTheme` to replace
`LowerSection`, `InnerSection`, and `UpperSection` with custom controls.

默认模板使用 `Border` 元素和 `SliderTrackBackground`/`SliderTrackForeground`
资源。可覆盖 `ControlTheme` 以自定义控件替换 `LowerSection`、`InnerSection`
和 `UpperSection`。

**Q: How do I handle the ValueChanged event to know which thumb moved? / 如何通过 ValueChanged 事件知道哪个滑块移动了？**
A: Check `RangeValueChangedEventArgs.IsLower`: `true` = lower thumb;
`false` = upper thumb.

检查 `RangeValueChangedEventArgs.IsLower`：`true` = 下滑块；`false` = 上滑块。
