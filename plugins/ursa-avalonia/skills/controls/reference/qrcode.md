---
category: Display
title: QRCode
subtitle: 二维码
description: >
  Quick Response code (QR Code) control with smooth rounded data symbols, gradient
  brush support for foreground and background, configurable error correction level,
  customisable quiet zone, and per-symbol corner rounding. Based on the ISO 18004
  standard. Ported from Avalonia.Labs.
  二维码控件，支持平滑圆角数据符号、前景/背景渐变色刷、可配置纠错级别、自定义
  静区（quiet zone）和逐符号圆角。基于 ISO 18004 标准。从 Avalonia.Labs 移植。
---

# QRCode / 二维码

## When to Use / 何时使用

Use `QRCode` to render a 2D barcode that encodes a string. Suitable for
sharing URLs, identifiers, or payment codes in the UI. It is a lightweight
`Control` (not `TemplatedControl`) that renders with `DrawingContext`.

使用 `QRCode` 渲染编码字符串的二维条码。适用于在 UI 中分享 URL、标识符或
支付码。它是一个轻量的 `Control`（而非 `TemplatedControl`），通过
`DrawingContext` 渲染。

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<u:QRCode Width="300"
          Height="300"
          Data="https://example.com"
          Foreground="Black"
          Background="White" />
```

### With gradient / 使用渐变色

```xml
<u:QRCode Width="300" Height="300"
          Data="Hello Ursa!">
    <u:QRCode.Foreground>
        <LinearGradientBrush StartPoint="0%,0%" EndPoint="0%,100%">
            <GradientStop Color="#667eea" Offset="0" />
            <GradientStop Color="#764ba2" Offset="1" />
        </LinearGradientBrush>
    </u:QRCode.Foreground>
</u:QRCode>
```

### Error correction level / 纠错级别

```xml
<u:QRCode Width="300"
          Height="300"
          Data="critical data"
          ErrorCorrection="Highest" />
```

Higher error correction increases the QR code matrix size but makes it more
resilient to damage or occlusion.

纠错级别越高，二维码矩阵越大，但对损坏或遮挡的容忍度也越高。

## Common Scenarios / 常用场景

### 1. Rounded symbols / 圆角符号

```xml
<u:QRCode Width="300" Height="300"
          Data="rounded"
          SymbolCornerRatio="0.5" />
```

`SymbolCornerRatio` (0.0–0.5, default 0.5) controls how rounded each data
module corner appears. At 0.0 modules are sharp squares; at 0.5 they are
fully rounded.

`SymbolCornerRatio`（0.0–0.5，默认 0.5）控制每个数据模块的圆角程度。0.0 为锐利
方块，0.5 为完全圆角。

### 2. Disabling the quiet zone / 禁用静区

```xml
<u:QRCode Width="300"
          Height="300"
          Data="no quiet zone"
          IsQuietZoneEnabled="False"
          Padding="8" />
```

The QR standard requires a 4-module quiet zone. Disable it with
`IsQuietZoneEnabled="False"` and supply fixed `Padding` instead.

QR 标准要求 4 个模块宽度的静区。通过 `IsQuietZoneEnabled="False"` 禁用并改为
提供固定 `Padding`。

### 3. Rounded outer corners / 外边框圆角

```xml
<u:QRCode Width="300" Height="300"
          Data="rounded corners"
          CornerRadius="16" />
```

`CornerRadius` clips the entire control, giving the QR code a card-like
appearance.

`CornerRadius` 裁剪整个控件，使二维码呈现卡片外观。

## Property Reference / 属性参考

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Data` | `string?` | `null` | Text to encode. Empty/null hides the QR code. / 要编码的文本，空/null 时隐藏二维码 |
| `Foreground` | `IBrush?` | theme | Data module (dark) colour. Supports gradients. / 数据模块（深色）颜色，支持渐变 |
| `Background` | `IBrush?` | theme | Background (light) colour behind modules. / 模块背后的背景（浅色）颜色 |
| `ErrorCorrection` | `EccLevel` | `Medium` | Error correction level. / 纠错级别 |
| `SymbolCornerRatio` | `double` | `0.5` | Per-module corner rounding (0.0–0.5). / 逐模块圆角比例 |
| `CornerRadius` | `CornerRadius` | `0` | Outer border corner radius (clips the control). / 外边框圆角（裁剪控件） |
| `Padding` | `Thickness` | `0` | Additional margin inside the quiet zone. / 静区内的额外边距 |
| `IsQuietZoneEnabled` | `bool` | `true` | Include the standard 4-module quiet zone. / 包含标准 4-模块静区 |

### EccLevel Enum / EccLevel 枚举

| Value | Recovery | Description |
|---|---|---|
| `Lowest` | ~7% | Smallest footprint, least error recovery |
| `Medium` | ~15% | Good balance (default) |
| `Quality` | ~25% | Higher reliability |
| `Highest` | ~30% | Maximum recoverable data, largest matrix |

## Events / 事件

No public routed events. `QRCode` inherits from `Control` and redraws on
property changes.

无公开路由事件。`QRCode` 继承自 `Control`，在属性变化时重绘。

## Styling & Templating / 样式与模板

`QRCode` is **not a `TemplatedControl`** — it renders via `DrawingContext.Render`.
There are no template parts or class selectors.

`QRCode` **不是 `TemplatedControl`** —— 它通过 `DrawingContext.Render` 渲染。
没有模板部件或类选择器。

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `QrCodeForeground` | Foreground | Default data-module brush |

### Size guidance / 尺寸建议

- Provide explicit `Width` and `Height` (equal, square). The QR code fills the
  available area minus padding.
- For a sharp rendering, ensure the display size is large enough for the
  module count — larger `Data` inputs produce larger matrices.

- 提供显式的 `Width` 和 `Height`（等值正方形）。二维码填充可用区域减去内边距。
- 为保证清晰渲染，请确保显示尺寸足够大以容纳模块数量 —— 更长的 `Data` 输入
  会产生更大的矩阵。

## FAQ / 常见问题

**Q: Why is nothing rendered? / 为什么什么都看不到？**
A: Check that `Data` is non-null and non-empty, `Width`/`Height` are > 0,
and `Foreground`/`Background` brushes are set (or use theme defaults). A `null`
value in `Data` produces no geometry.

检查 `Data` 是否非 null 非空、`Width`/`Height` 是否 > 0，以及 `Foreground`/
`Background` 画刷是否已设置（或使用主题默认值）。`Data` 为 `null` 时不产生几何图形。

**Q: Can I make the QR code non-square by omitting the quiet zone? / 可否通过省略静区使二维码非正方形？**
A: No — the underlying matrix is always square. `Padding` and
`IsQuietZoneEnabled` only affect interior layout; the control should always be
given equal `Width` and `Height`.

不行 —— 底层矩阵始终是正方形。`Padding` 和 `IsQuietZoneEnabled` 仅影响内部
布局；控件应始终使用相等的 `Width` 和 `Height`。

**Q: What QR Code library is used internally? / 内部使用哪个 QR 码库？**
A: The control was ported from Avalonia.Labs and uses `Gma.QrCodeNet.Encoding`
(not `QRCoder`). The encoding logic is self-contained in the `Encoding`
sub-namespace.

此控件从 Avalonia.Labs 移植，内部使用 `Gma.QrCodeNet.Encoding`（而非 `QRCoder`）。
编码逻辑自包含在 `Encoding` 子命名空间中。

**Q: Can I use animated or binding-reactive brushes? / 可以使用动画或绑定响应式画刷吗？**
A: Yes — `Foreground` and `Background` are standard `IBrush?` properties and
support any `IBrush` including gradients, bindings, and animations.

可以 —— `Foreground` 和 `Background` 是标准 `IBrush?` 属性，支持任何 `IBrush`，
包括渐变、绑定和动画。
