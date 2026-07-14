---
category: Components
title: GroupBox (Ursa)
subtitle: 分组框（Ursa）
description: >
  A bordered container with an optional header that cuts a gap into the top border,
  similar to a HTML fieldset/legend. Supports rounded corners, asymmetric corner
  radii, border styling, background fill, and arbitrary header controls (not just
  text). Built on custom geometry rendering with StreamGeometry for precise
  gap-and-cap border paths.
  带可选标题的边框容器，标题会在顶部边框上切出一个缺口，类似 HTML 的
  fieldset/legend。支持圆角、不对称角半径、边框样式、背景填充和任意标题控件
  （不仅限于文本）。基于自定义 StreamGeometry 渲染实现精确的缺口和端点边框路径。
---

# GroupBox (Ursa) / 分组框（Ursa）

## When to Use / 何时使用

Use `UrsaGroupBox` to visually group related controls or content under a labeled
border — settings panels, filter sections, form sections. The header sits inside
a cut-out gap in the top border, similar to the HTML `<fieldset>` with `<legend>`.

当需要在带标签的边框下对相关控件或内容进行视觉分组时使用 `UrsaGroupBox`——如设置
面板、筛选区域、表单区域。标题位于顶部边框的切口中，类似 HTML 的 `<fieldset>`
配合 `<legend>`。

Do NOT use `UrsaGroupBox` for simple padding or margin — use a `Border` with
`Padding` instead. The custom border geometry has a non-trivial rendering cost
compared to a plain `Border`.

不要将 `UrsaGroupBox` 用于简单的边距需求——应使用带 `Padding` 的 `Border`。与
普通 `Border` 相比，自定义边框几何体的渲染开销更高。

## Basic Usage / 基本使用

### Simple GroupBox with text header / 带文本标题的简单分组框

```xml
xmlns:u="https://irihi.tech/ursa"

<u:UrsaGroupBox Header="Connection Settings" HeaderSpacing="12">
    <StackPanel Spacing="8">
        <TextBlock Text="Host: localhost" />
        <TextBlock Text="Port: 5432" />
    </StackPanel>
</u:UrsaGroupBox>
```

`Header` accepts plain text (rendered via `ContentPresenter`) or any control.
`HeaderSpacing` controls extra horizontal space on each side of the header inside
the border gap.

`Header` 接受纯文本（通过 `ContentPresenter` 渲染）或任意控件。`HeaderSpacing`
控制标题在边框缺口中每侧的额外水平空间。

### GroupBox with custom header control / 带自定义标题控件的分组框

```xml
<u:UrsaGroupBox BorderBrush="{DynamicResource SemiColorSecondary}"
                BorderThickness="2"
                CornerRadius="12"
                HeaderSpacing="12">
    <u:UrsaGroupBox.Header>
        <TextBlock FontWeight="SemiBold"
                   Foreground="{DynamicResource SemiColorSecondary}"
                   Text="Appearance" />
    </u:UrsaGroupBox.Header>
    <StackPanel Spacing="8">
        <TextBlock Text="Font size: 14" />
        <TextBlock Text="Accent colour: SteelBlue" />
    </StackPanel>
</u:UrsaGroupBox>
```

### GroupBox without header (plain rounded border) / 无标题分组框（纯圆角边框）

```xml
<u:UrsaGroupBox BorderThickness="1" CornerRadius="8">
    <StackPanel Spacing="8">
        <TextBlock Text="This GroupBox has no header." />
        <TextBlock Text="The border is a complete rounded rectangle." />
    </StackPanel>
</u:UrsaGroupBox>
```

When `Header` is `null`, a closed rounded-rectangle border is drawn.

当 `Header` 为 `null` 时，绘制完整的圆角矩形边框。

## Common Scenarios / 常用场景

### 1. Asymmetric corner radius / 不对称圆角

```xml
<u:UrsaGroupBox BorderBrush="{DynamicResource SemiColorWarning}"
                BorderThickness="2"
                CornerRadius="16,4,16,4"
                Header="Asymmetric Corners"
                HeaderSpacing="12">
    <TextBlock Text="TopLeft=16 TopRight=4 BottomRight=16 BottomLeft=4" />
</u:UrsaGroupBox>
```

### 2. With background fill / 带背景填充

```xml
<u:UrsaGroupBox Background="{DynamicResource SemiColorDangerLight}"
                BorderBrush="{DynamicResource SemiColorDanger}"
                BorderThickness="1.5"
                CornerRadius="6"
                Header="With Background"
                HeaderSpacing="12">
    <Button HorizontalAlignment="Left" Content="Click Me" />
</u:UrsaGroupBox>
```

### 3. Rich header with icon / 带图标的富标题

```xml
<u:UrsaGroupBox BorderBrush="{DynamicResource SemiColorSuccess}"
                CornerRadius="48"
                HeaderSpacing="12">
    <u:UrsaGroupBox.Header>
        <StackPanel Orientation="Horizontal" Spacing="6">
            <Ellipse Width="8" Height="8"
                     Fill="{DynamicResource SemiColorSuccess}" />
            <TextBlock FontWeight="SemiBold"
                       Foreground="{DynamicResource SemiColorSuccess}"
                       Text="Online" />
        </StackPanel>
    </u:UrsaGroupBox.Header>
    <TextBlock Text="The header can be any Avalonia Control." />
</u:UrsaGroupBox>
```

### 4. Uneven border thickness / 不均匀边框厚度

```xml
<u:UrsaGroupBox BorderThickness="8,8,24,24"
                CornerRadius="48"
                Header="Thick Border"
                HeaderSpacing="12">
    <Calendar />
</u:UrsaGroupBox>
```

## Property Reference / 属性参考

### UrsaGroupBox Properties / UrsaGroupBox 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Header` | `object?` | `null` | Header content (inherited from HeaderedContentControl) / 标题内容（继承自 HeaderedContentControl） |
| `HeaderTemplate` | `IDataTemplate?` | `null` | Template for the header (inherited) / 标题模板（继承） |
| `Content` | `object?` | `null` | Inner content (inherited) / 内部内容（继承） |
| `ContentTemplate` | `IDataTemplate?` | `null` | Template for inner content (inherited) / 内部内容模板（继承） |
| `HeaderSpacing` | `double` | `4.0` | Extra horizontal space on each side of the header within the border gap / 标题在边框缺口中每侧的额外水平空间 |
| `Background` | `IBrush?` | `null` | Background brush painted inside the border / 边框内绘制的背景画刷 |
| `BorderBrush` | `IBrush?` | (theme) | Brush for the border stroke / 边框描边画刷 |
| `BorderThickness` | `Thickness` | (theme) | Thickness of the border / 边框粗细 |
| `CornerRadius` | `CornerRadius` | (theme) | Corner radius of the border / 边框圆角半径 |
| `Padding` | `Thickness` | (theme) | Inner padding between border and content / 边框与内容之间的内边距 |

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `BorderCardBorderBrush` | Default BorderBrush | Default border color / 默认边框颜色 |
| `RadiusCardCornerRadius` | Default CornerRadius | Default corner radius / 默认圆角 |
| `ThicknessCardBorderThickness` | Default BorderThickness | Default border thickness / 默认边框粗细 |
| `ThicknessCardPadding` | Default Padding | Default inner padding / 默认内边距 |

### Template Parts / 模板部件

The `UrsaGroupBox` template uses `GroupBoxBorder` (a custom `Decorator`) as its
root element. `GroupBoxBorder` has its own `Header` property that receives the
`ContentPresenter` for the header.

`UrsaGroupBox` 模板使用 `GroupBoxBorder`（自定义 `Decorator`）作为根元素。
`GroupBoxBorder` 有自己的 `Header` 属性，接收标题的 `ContentPresenter`。

### How the Border Rendering Works / 边框渲染原理

`GroupBoxBorder` builds two `StreamGeometry` objects in `ArrangeOverride`:

1. **Fill geometry**: A closed rounded rectangle used to fill `Background`.
2. **Border geometry**: When a header is present, an open-gap path with
   semicircular end-caps at the header cut-out. Without a header, the same
   closed path doubles as the stroke path.

A third **clip geometry** is applied to the child to clip content to the rounded
corners. `GroupBoxBorderGeometryHelper` computes outer corner radii from the
inner corner radii plus border thickness.

`GroupBoxBorder` 在 `ArrangeOverride` 中构建两个 `StreamGeometry` 对象：

1. **填充几何体**：用于填充 `Background` 的封闭圆角矩形。
2. **边框几何体**：有标题时，在标题切口处使用半圆形端点的开放缺口路径。无标题时，
   同一封闭路径兼作描边路径。

第三个 **裁剪几何体** 应用于子控件，将内容裁剪到圆角范围内。
`GroupBoxBorderGeometryHelper` 根据内部圆角半径加边框厚度计算外部圆角半径。

## API Reference / API 参考

### UrsaGroupBox Class / UrsaGroupBox 类

- **Namespace**: `Ursa.Controls`
- **Base class**: `HeaderedContentControl`

### GroupBoxBorder Class / GroupBoxBorder 类

- **Namespace**: `Ursa.Controls`
- **Base class**: `Decorator`
- **Properties**: `Background`, `BorderBrush`, `BorderThickness`, `CornerRadius`,
  `Header` (Control?), `HeaderSpacing` (double, default 4)

### GroupBoxBorderGeometryHelper Class / GroupBoxBorderGeometryHelper 类

- **Namespace**: `Ursa.Controls`
- **Visibility**: `internal static`
- **Role**: Builds `StreamGeometry` for fill, border ring (closed/gap), and clip.
