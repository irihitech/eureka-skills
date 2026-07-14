---
category: Display
title: QRCode
subtitle: 二维码
description: >
  Renders a QR code from string data with configurable error correction level,
  rounded symbol corners, gradient brush support, and optional quiet zone.
  Pure Avalonia rendering — no image generation required.
  从字符串数据渲染二维码，支持可配置的纠错级别、圆角符号、渐变画刷和可选静区。
  纯 Avalonia 渲染——无需生成图片。
---

# QRCode / 二维码

## When to Use / 何时使用

Use `QRCode` to display machine-readable QR codes in your Avalonia application.
Common use cases: sharing URLs, displaying identifiers, payment codes, Wi-Fi
credentials.

使用 `QRCode` 在 Avalonia 应用中显示机器可读的二维码。常见场景：分享链接、显示
标识符、支付码、Wi-Fi 凭据。

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<u:QRCode Width="300"
           Height="300"
           Data="https://irihi.tech"
           Foreground="Black" />
```

The `Data` property accepts any string — the QR code is generated from it.

`Data` 属性接受任意字符串——二维码由该字符串生成。

### With error correction / 带纠错级别

```xml
<u:QRCode Width="300"
           Height="300"
           Data="Hello Avalonia"
           ErrorCorrection="High"
           Foreground="White" />
```

## Common Scenarios / 常用场景

### 1. Rounded corners on QR symbols / 圆角二维码符号

```xml
<u:QRCode Width="400"
           Height="400"
           Data="{Binding #text.Text}"
           SymbolCornerRatio="0.5"
           CornerRadius="8"
           ErrorCorrection="{Binding #eccLevel.Value}" />
```

`SymbolCornerRatio` ranges from `0.0` (sharp) to `0.5` (fully rounded).
`CornerRadius` controls the outer border rounding.

### 2. Gradient foreground / 渐变前景

```xml
<u:QRCode Width="300" Height="300" Data="Hello">
    <u:QRCode.Foreground>
        <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
            <GradientStop Offset="0" Color="Blue" />
            <GradientStop Offset="1" Color="Purple" />
        </LinearGradientBrush>
    </u:QRCode.Foreground>
</u:QRCode>
```

### 3. Custom padding (no quiet zone) / 自定义内边距（无静区）

```xml
<u:QRCode Width="300"
           Height="300"
           Data="Compact QR"
           IsQuietZoneEnabled="False"
           Padding="8" />
```

### 4. Data-bound QR code / 数据驱动的二维码

```xml
<Grid ColumnDefinitions="*, Auto">
    <u:QRCode Width="400"
               Height="400"
               Data="{Binding #text.Text}"
               ErrorCorrection="{Binding #eccLevel.Value}" />
    <StackPanel Grid.Column="1">
        <TextBox Name="text" Text="Hello Avalonia" />
        <ComboBox Name="eccLevel"
                  SelectedIndex="1">
            <ComboBoxItem>Low</ComboBoxItem>
            <ComboBoxItem>Medium</ComboBoxItem>
            <ComboBoxItem>Quality</ComboBoxItem>
            <ComboBoxItem>High</ComboBoxItem>
        </ComboBox>
    </StackPanel>
</Grid>
```

## Property Reference / 属性参考

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Data` | `string?` | `null` | String to encode / 要编码的字符串 |
| `ErrorCorrection` | `EccLevel` | `Medium` | Error correction level / 纠错级别 |
| `Foreground` | `IBrush?` | theme | Data symbol brush / 数据符号画刷 |
| `Background` | `IBrush?` | theme (transparent) | Background brush / 背景画刷 |
| `CornerRadius` | `CornerRadius` | `0` | Outer border corner radius / 外边框圆角 |
| `SymbolCornerRatio` | `double` | `0.5` | Symbol corner roundness (0.0–0.5) / 符号圆角比例 |
| `Padding` | `Thickness` | `0` | Custom padding / 自定义内边距 |
| `IsQuietZoneEnabled` | `bool` | `true` | Add standard 4-module quiet zone / 添加标准 4 模块静区 |

### EccLevel Enum / 纠错级别枚举

| Value | Recovery | Use Case |
|---|---|---|
| `Lowest` | ~7% | Smallest code, minimal redundancy / 最小码，最少冗余 |
| `Medium` | ~15% | Good balance (default) / 良好平衡（默认） |
| `Quality` | ~25% | Higher reliability / 较高可靠性 |
| `Highest` | ~30% | Maximum reliability, largest code / 最高可靠性，最大码 |

## Events / 事件

No custom events. `QRCode` extends `Control` and supports standard input events.

无自定义事件。`QRCode` 继承自 `Control`，支持标准输入事件。

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `QrCodeForeground` | `QRCode` | Default foreground brush / 默认前景画刷 |

### Rendering Notes / 渲染说明

- `QRCode` renders via `PathGeometry` — it is a vector, not a bitmap. Resizing
  the control regenerates crisp geometry.
- `QRCode` 通过 `PathGeometry` 渲染——是矢量图而非位图。调整控件大小会重新生成清晰几何。
- Properties that change rendering only (no data re-encoding): `Background`,
  `Foreground`, `CornerRadius`, `Width`, `Height`.
- Properties that trigger re-encoding: `Data`, `ErrorCorrection`.
- The internal `QrCode` bitmap is cached until `Data` or `ErrorCorrection`
  changes.

## FAQ / 常见问题

**Q: What encoding library does QRCode use? / QRCode 使用什么编码库？**
A: It uses `Gma.QrCodeNet.Encoding` internally. The QR code standard (ISO
18004) is followed.

**Q: Why is my QR code blurry when I resize? / 为什么调整大小时二维码模糊？**
A: QRCode renders vector geometry — it should remain sharp at any size. If you
see blurriness, ensure `UseLayoutRounding="True"` on the parent.

**Q: How large should I make the QR code? / 二维码应该多大？**
A: At least 200×200 pixels for reliable scanning. Larger is better for
low-contrast or long-distance scanning. Keep it square (equal Width and Height).

**Q: What happens if Data is empty or null? / 如果 Data 为空或 null 会怎样？**
A: Nothing is rendered — no geometry is generated. Set a placeholder or hide
the control when no data is available.

```xml
<u:QRCode Data="{Binding QrText}"
           IsVisible="{Binding QrText, Converter={StaticResource IsNotNullOrEmpty}}" />
```

**Q: Can I save the QR code as an image? / 能将二维码保存为图片吗？**
A: QRCode does not have a built-in export method. Use
`RenderTargetBitmap.RenderAsync()` to capture the control as a bitmap:

```csharp
var bitmap = new RenderTargetBitmap(
    new PixelSize((int)qrCode.Width, (int)qrCode.Height));
await bitmap.RenderAsync(qrCode);
bitmap.Save("qrcode.png");
```
