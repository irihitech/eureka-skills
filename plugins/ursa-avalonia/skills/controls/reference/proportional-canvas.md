---
category: Layout
title: ProportionalCanvas
subtitle: 比例画布
description: >
  A Panel that positions children using proportional (percentage-based) or
  absolute coordinates via the RelativeScalar value type. Supports Left, Top,
  Right, and Bottom attached properties with RelativeUnit.Relative (%) or
  RelativeUnit.Absolute (px). Children auto-reposition on panel resize.
  通过 RelativeScalar 值类型使用比例（百分比）或绝对坐标定位子元素的 Panel。
  支持 Left、Top、Right、Bottom 附加属性，配合 RelativeUnit.Relative（%）
  或 RelativeUnit.Absolute（px）。子元素在面板调整大小时自动重新定位。
---

# ProportionalCanvas / 比例画布

## When to Use / 何时使用

Use `ProportionalCanvas` when you need child elements to maintain proportional
positions relative to the panel size — for example, overlay markers on an image,
responsive annotations, or data-visualization overlays. Unlike `Canvas`, which
uses fixed pixel offsets, `ProportionalCanvas` recalculates positions whenever
the panel resizes.

当需要子元素相对面板大小保持比例位置时使用 `ProportionalCanvas`——例如图像上
的叠加标记、响应式注释或数据可视化叠加层。与使用固定像素偏移的 `Canvas` 不同，
`ProportionalCanvas` 在面板调整大小时重新计算位置。

Avoid `ProportionalCanvas` for simple absolute positioning — use `Canvas`.
Avoid for grid-like layouts — use `Grid` or `UniformGrid`.

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<!-- 25% from left, 10% from top (absolute px also works) -->
<u:ProportionalCanvas Width="400" Height="300">
    <Border u:ProportionalCanvas.Left="25%"
            u:ProportionalCanvas.Top="10%"
            Width="100" Height="50" Background="Red" />

    <!-- Stretch between 25% left and 25% right, between 40% top and 10% bottom -->
    <Border u:ProportionalCanvas.Left="25%"
            u:ProportionalCanvas.Right="25%"
            u:ProportionalCanvas.Top="40%"
            u:ProportionalCanvas.Bottom="10%"
            Background="Blue" />
</u:ProportionalCanvas>
```

## Positioning Rules / 定位规则

- **Left only + Top only**: position from top-left corner.
- **Left + Right**: stretch width between the two offsets.
- **Top + Bottom**: stretch height between the two offsets.
- **All four**: fill the defined rectangle (stretch both dimensions).
- **Unset properties**: default to `0 (Absolute)`.

## Attached Properties / 附加属性

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `u:ProportionalCanvas.Left` | `RelativeScalar` | `0 (Absolute)` | Distance from the left edge / 距左边缘的距离 |
| `u:ProportionalCanvas.Top` | `RelativeScalar` | `0 (Absolute)` | Distance from the top edge / 距顶部边缘的距离 |
| `u:ProportionalCanvas.Right` | `RelativeScalar` | `0 (Absolute)` | Distance from the right edge / 距右边缘的距离 |
| `u:ProportionalCanvas.Bottom` | `RelativeScalar` | `0 (Absolute)` | Distance from the bottom edge / 距底部边缘的距离 |

## Value Types / 值类型

### RelativeUnit Enum / RelativeUnit 枚举

| Value | Description / 说明 |
|---|---|
| `Absolute` | Value in device-independent pixels / 设备无关像素值 |
| `Relative` | Value as a fraction of the panel dimension (0.0–1.0) / 面板尺寸的比例（0.0–1.0） |

### RelativeScalar Struct / RelativeScalar 结构

| Property | Type | Description / 说明 |
|---|---|---|
| `Scalar` | `double` | The numeric value / 数值 |
| `Unit` | `RelativeUnit` | The unit: `Absolute` or `Relative` / 单位：Absolute 或 Relative |

### XAML Syntax / XAML 语法

```xml
<!-- Percentage (Relative): use % suffix -->
u:ProportionalCanvas.Left="25%"

<!-- Absolute pixels: use number only (or explicit "px") -->
u:ProportionalCanvas.Top="40"
u:ProportionalCanvas.Left="40px"
```

In code, use the constructor:
```csharp
ProportionalCanvas.SetLeft(child, new RelativeScalar(0.25, RelativeUnit.Relative));
ProportionalCanvas.SetTop(child, new RelativeScalar(40, RelativeUnit.Absolute));
```

## Styling & Templating / 样式与模板

`ProportionalCanvas` is a pure layout `Panel` with no built-in theme or
control template. It inherits default `Panel` styling only.

`ProportionalCanvas` 是纯布局 `Panel`，没有内置主题或控件模板。仅继承默认
`Panel` 样式。

## FAQ / 常见问题

**Q: What happens when only Left is set? / 只设置 Left 会怎样？**
A: The child is positioned at the resolved Left offset with its desired width
and `Top=0`. Similarly, only `Top` positions at `Left=0` with the resolved
Top offset.

**Q: How does Right positioning work? / Right 定位如何工作？**
A: When only `Right` is set (no `Left`), the child is positioned so its right
edge is at `panelWidth - resolvedRight`. Its width is the desired width.

**Q: Can I mix Relative and Absolute on different edges? / 可以在不同边缘混合 Relative 和 Absolute 吗？**
A: Yes. Each attached property is resolved independently. For example:
```xml
u:ProportionalCanvas.Left="25%"    <!-- Relative -->
u:ProportionalCanvas.Top="40"      <!-- Absolute px -->
```

**Q: What is the default for unset properties? / 未设置属性的默认值是什么？**
A: Unset properties resolve to `0 (Absolute)`. The sentinel is
`RelativeScalar(double.NaN, RelativeUnit.Absolute)`, which `IsSet()` detects
and treats as `0`.
