---
category: Components
title: ImageViewer
subtitle: 图片查看器
description: 支持拖拽平移、鼠标滚轮缩放、双击重置和触控缩放的交互式图片查看控件，适合图片预览和图像查看场景。
---

## ImageViewer / 图片查看器

An interactive image viewer `TemplatedControl` with drag-to-pan, mouse-wheel zoom, double-click-to-fit, pinch-to-zoom gesture support, and keyboard arrow-key panning. Wraps an internal `ImageViewerPresenter` that handles rendering. Supports an `Overlayer` for adorner-based overlays, configurable zoom range, and fine-grained pan step sizes.

交互式图片查看器 `TemplatedControl`，支持拖拽平移、鼠标滚轮缩放、双击自适应、双指缩放手势和键盘方向键平移。包裹内部 `ImageViewerPresenter` 进行渲染。支持基于装饰器的 `Overlayer`、可配置的缩放范围和精细平移步长。

## When to Use / 何时使用

Use `ImageViewer` when you need a pan-and-zoom capable image display — for example, photo galleries, document viewers, map tiles, or medical image viewers. For simple static image display without interaction, use Avalonia's `Image` control. For thumbnail grids, use `ListBox` with `Image`.

当你需要可平移和缩放的图片显示时使用 `ImageViewer` —— 例如照片画廊、文档查看器、地图瓦片或医学图像查看器。对于无交互的简单静态图片显示，请使用 Avalonia 的 `Image` 控件。对于缩略图网格，请使用 `ListBox` 与 `Image`。

## Basic Usage / 基本使用

```xml
<u:ImageViewer Source="{Binding MyImage}" />
```

```csharp
// Code-behind
var viewer = new ImageViewer
{
    Source = new Bitmap("path/to/image.jpg"),
    Stretch = Stretch.Uniform,
    MinZoom = 0.1,
    MaxZoom = 10.0
};
```

## Common Scenarios / 常用场景

### Full Interactive Image Viewer / 完整交互式图片查看器

```xml
<Grid RowDefinitions="*, Auto" ColumnDefinitions="*, Auto">
    <u:ImageViewer Grid.Row="0" Grid.Column="0"
                   x:Name="Viewer"
                   Source="{Binding Source}" />
    <!-- Side panel with controls -->
    <Border Grid.Row="0" Grid.Column="1" Width="220" Padding="12">
        <StackPanel Spacing="12">
            <u:PathPicker AllowMultiple="False" UsePickerType="OpenFile"
                          DefaultFileExtension="[,.jpg, .png]"
                          Command="{Binding OpenFileCommand}" />
            <TextBlock x:Name="ZoomLabel" Text="Zoom: 1.00×" />
            <Slider Minimum="0.1" Maximum="5.0"
                    Value="{Binding #Viewer.Zoom, Mode=TwoWay}" />
            <Slider Minimum="-1000" Maximum="1000"
                    Value="{Binding #Viewer.OffsetX, Mode=TwoWay}" />
            <Slider Minimum="-1000" Maximum="1000"
                    Value="{Binding #Viewer.OffsetY, Mode=TwoWay}" />
            <Button Content="Reset View" Click="ResetView_Click" />
        </StackPanel>
    </Border>
</Grid>
```

### Programmatic Fit-to-View / 编程自适应

```csharp
// Reset zoom and offsets to fit the image in the viewport
viewer.FitToView();

// Reset on double-click (already built-in)
// Also triggered when Source, Stretch, or StretchDirection changes
```

### Configuring Stretch / 配置拉伸模式

```xml
<!-- Uniform: fit within bounds, preserving aspect ratio (default) -->
<u:ImageViewer Source="{Binding Image}" Stretch="Uniform" />

<!-- Fill: stretch to fill, may distort -->
<u:ImageViewer Source="{Binding Image}" Stretch="Fill" />

<!-- None: native size, scrollable -->
<u:ImageViewer Source="{Binding Image}" Stretch="None" />

<!-- UniformToFill: fill and crop -->
<u:ImageViewer Source="{Binding Image}" Stretch="UniformToFill" />
```

### Custom Overlayer / 自定义覆盖层

Place an adorner on top of the image via `Overlayer`:

```xml
<u:ImageViewer Source="{Binding Image}">
    <u:ImageViewer.Overlayer>
        <Border Background="#20FF0000" BorderBrush="Red"
                BorderThickness="2" Width="100" Height="100" />
    </u:ImageViewer.Overlayer>
</u:ImageViewer>
```

The overlayer is set as an `AdornerLayer` adorner on the `ImageViewer`.

### Keyboard Panning / 键盘平移

```xml
<u:ImageViewer Source="{Binding Image}"
               SmallChange="5"
               LargeChange="50"
               Focusable="True" />
```

| Key / 按键 | Action / 动作 |
| --- | --- |
| Arrow keys / 方向键 | Pan by `SmallChange` pixels. / 平移 `SmallChange` 像素。 |
| Ctrl + Arrow keys / Ctrl+方向键 | Pan by `LargeChange` pixels. / 平移 `LargeChange` 像素。 |

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Source` | `IImage?` | The image to display. Also the `[Content]` property. / 要显示的图片。也是 `[Content]` 属性。 |
| `Stretch` | `Stretch` | How the image fits the viewport: `Uniform` (default), `Fill`, `None`, `UniformToFill`. / 图片适配视口的方式：`Uniform`（默认）、`Fill`、`None`、`UniformToFill`。 |
| `StretchDirection` | `StretchDirection` | Direction constraint for stretching: `Both` (default), `UpOnly`, `DownOnly`. / 拉伸方向约束：`Both`（默认）、`UpOnly`、`DownOnly`。 |
| `BlendMode` | `BitmapBlendingMode` | Blend mode used when rendering the image. / 渲染图片时使用的混合模式。 |
| `Zoom` | `double` | Current zoom level. 1.0 = native pixel size. Clamped `[MinZoom, MaxZoom]`. / 当前缩放级别。1.0 = 原始像素大小。限制在 `[MinZoom, MaxZoom]`。 |
| `MinZoom` | `double` | Minimum zoom level. Default `0.1`. / 最小缩放级别。默认 `0.1`。 |
| `MaxZoom` | `double` | Maximum zoom level. Default `10.0`. / 最大缩放级别。默认 `10.0`。 |
| `OffsetX` | `double` | Horizontal pixel offset (positive = right). / 水平像素偏移（正值向右）。 |
| `OffsetY` | `double` | Vertical pixel offset (positive = down). / 垂直像素偏移（正值向下）。 |
| `SmallChange` | `double` | Keyboard pan step size (arrow keys). Default `1`. / 键盘平移步长（方向键）。默认 `1`。 |
| `LargeChange` | `double` | Keyboard pan step size (Ctrl+arrow keys). Default `10`. / 键盘平移步长（Ctrl+方向键）。默认 `10`。 |
| `Overlayer` | `Control?` | Optional adorner overlay placed on top of the image. / 可选的装饰器覆盖层，置于图片之上。 |

### Obsolete Properties / 已废弃属性

| Old Name / 旧名称 | Replacement / 替代 | Description / 说明 |
| --- | --- | --- |
| `Scale` | `Zoom` | Renamed for clarity. / 为清晰起见重命名。 |
| `MinScale` | `MinZoom` | Renamed for clarity. / 为清晰起见重命名。 |
| `TranslateX` | `OffsetX` | Renamed for clarity. / 为清晰起见重命名。 |
| `TranslateY` | `OffsetY` | Renamed for clarity. / 为清晰起见重命名。 |

## Styling & Templating / 样式与模板

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Image` | `ImageViewerPresenter` | The internal image presenter. Binds `Source`, `Stretch`, `StretchDirection`, `BlendMode`, `Zoom`, `OffsetX`, `OffsetY`. / 内部图片呈现器。 |
| `PART_Layer` | `VisualLayerManager` | Layer manager hosting the image and overlays. / 托管图片和覆盖层的图层管理器。 |

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:moving` | Set during drag/pan operation. Sets cursor to `Hand`. / 拖拽/平移操作期间设置。光标变为 `Hand`。 |

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `SemiGrey1` | Default background. / 默认背景色。 |

### Interaction Model / 交互模型

| Gesture / 手势 | Action / 动作 |
| --- | --- |
| **Left-drag / 左键拖拽** | Pan the image. / 平移图片。 |
| **Mouse wheel / 鼠标滚轮** | Zoom in/out, centered on cursor position. / 以光标位置为中心缩放。 |
| **Double-click / 双击** | Reset to fit-to-view (`FitToView()`). / 重置为自适应（`FitToView()`）。 |
| **Pinch / 双指缩放** | Pinch-to-zoom with pan (touch devices). / 触控双指缩放和平移。 |
| **Arrow keys / 方向键** | Pan by `SmallChange` / `LargeChange`. / 按 `SmallChange`/`LargeChange` 平移。 |

## FAQ / 常见问题

**Q: How does zoom anchoring work? / 缩放锚定如何工作？**

A: Zoom operations (mouse wheel, pinch) keep the point under the cursor/fingers fixed on screen. The control re-calculates `OffsetX` and `OffsetY` to maintain this anchor point. / 缩放操作（鼠标滚轮、双指）保持光标/手指下的点固定在屏幕上。控件重新计算 `OffsetX` 和 `OffsetY` 以维持此锚点。

**Q: Can I display non-bitmap images? / 可以显示非位图图片吗？**

A: `Source` is `IImage?`, which accepts `Bitmap`, `DrawingImage`, and other `IImage` implementations. For SVG, use an SVG-to-`DrawingImage` converter. / `Source` 类型为 `IImage?`，接受 `Bitmap`、`DrawingImage` 和其他 `IImage` 实现。对于 SVG，请使用 SVG 到 `DrawingImage` 的转换器。

**Q: When is FitToView called automatically? / FitToView 何时自动调用？**

A: `FitToView` is called automatically when `Source`, `Stretch`, or `StretchDirection` changes, or when the control is first sized (via `OnSizeChanged`). It only runs once per "session" (tracked by `_hasInitialFit`). Call `FitToView()` manually to reset at any time. / 当 `Source`、`Stretch` 或 `StretchDirection` 变化时，或控件首次获得尺寸（通过 `OnSizeChanged`）时，`FitToView` 会自动调用。每个"会话"仅运行一次（由 `_hasInitialFit` 跟踪）。随时可手动调用 `FitToView()` 重置。

**Q: How does the Overlayer property work? / Overlayer 属性如何工作？**

A: Setting `Overlayer` to a `Control` places it as an adorner via `AdornerLayer.SetAdorner(this, control)`. This allows positioning UI elements (like selection rectangles or annotations) on top of the image. / 将 `Overlayer` 设置为 `Control` 会通过 `AdornerLayer.SetAdorner(this, control)` 将其作为装饰器放置。这允许在图片上定位 UI 元素（如选择矩形或注释）。
