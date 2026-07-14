---
category: Components
title: Label
subtitle: 标签
description: 标签控件用于显示文本标签，可关联焦点目标控件。
---

# Label / 标签

A text label that can be associated with a target control via the `Target` property. Pressing the access key (Alt+key) moves focus to the target. Inherits from `ContentControl`.

可通过 `Target` 属性关联目标控件的文本标签。按下访问键（Alt+键）将焦点移到目标。继承自 `ContentControl`。

## When to Use / 何时使用

Use `Label` when you need a form field label with keyboard accessibility. For plain display text without target association, use `TextBlock`.

需要带键盘可访问性的表单字段标签时使用。无需目标关联的纯显示文本用 `TextBlock`。

## Basic Usage / 基本使用

```xml
<Label Target="nameBox" Content="_Name" />
<TextBox Name="nameBox" />
<!-- Alt+N focuses the TextBox -->
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Target` | `IInputElement?` | The control to focus. / 要聚焦的控件。 |
| `Content` | `object?` | Label text (use `_` for access key). / 标签文本（`_` 表示访问键）。 |

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlThemes / Semi.Avalonia 控件主题

Semi.Avalonia provides the `TagLabel` ControlTheme which transforms a `Label` into a tag/chip component. It supports three variant styles (Light/ghost, Ghost, Solid), two sizes (default Small, Large), two shapes (Square, Circle), 17 colour classes, and AI-assisted styles (Colorful, Gradient).

Semi.Avalonia 提供了 `TagLabel` ControlTheme，将 `Label` 转换为标签/芯片组件。它支持三种变体样式（Light/ghost 浅色、Ghost 幽灵、Solid 实色）、两种尺寸（默认 Small 小、Large 大）、两种形状（Square 方形、Circle 圆形）、17 种颜色类以及 AI 辅助样式（Colorful 多彩、Gradient 渐变）。

| Theme / 主题 | Resource Key / 资源键 | Description / 说明 |
| --- | --- | --- |
| **TagLabel** | `TagLabel` | Tag/chip theme with Light/Ghost/Solid variants, 17 colours, 2 sizes, 2 shapes, and Colorful/Gradient AI styles. / 标签/芯片主题，支持 Light/Ghost/Solid 变体、17 种颜色、2 种尺寸、2 种形状以及 Colorful/Gradient AI 样式。 |

```xml
<!-- Default tag (Light style, Grey colour, Small size, Square shape) -->
<Label Theme="{StaticResource TagLabel}" Content="Tag" />

<!-- Large circle tag -->
<Label Theme="{StaticResource TagLabel}" Classes="Large Circle" Content="Circle" />

<!-- Ghost red tag -->
<Label Theme="{StaticResource TagLabel}" Classes="Ghost Red" Content="Red Ghost" />

<!-- Solid blue tag -->
<Label Theme="{StaticResource TagLabel}" Classes="Solid Blue" Content="Blue Solid" />

<!-- Colorful gradient tag -->
<Label Theme="{StaticResource TagLabel}" Classes="Colorful Gradient" Content="Gradient" />
```

### TagLabel Variant Classes / TagLabel 变体类

| Style Class / 样式类 | Description / 说明 |
| --- | --- |
| _(default / 默认)_ | Light background with coloured text. / 浅色背景配彩色文字。 |
| `Ghost` | Transparent background with coloured border and text. / 透明背景配彩色边框和文字。 |
| `Solid` | Solid coloured background with white text. / 实色背景配白色文字。 |

### TagLabel Colour Classes / TagLabel 颜色类

`Red`, `Pink`, `Purple`, `Violet`, `Indigo`, `Blue`, `LightBlue`, `Cyan`, `Teal`, `Green`, `LightGreen`, `Lime`, `Yellow`, `Amber`, `Orange`, `Grey` (default), `White`.

### TagLabel Size & Shape Classes / TagLabel 尺寸与形状类

| Style Class / 样式类 | Description / 说明 |
| --- | --- |
| _(default / 默认)_ | Small size, square shape. / 小尺寸，方形。 |
| `Large` | Larger padding and height. / 更大的内边距和高度。 |
| `Circle` | Fully rounded corners. / 完全圆角。 |

### AI Style Classes / AI 样式类

| Style Class / 样式类 | Description / 说明 |
| --- | --- |
| `Colorful` | Vibrant gradient text and backgrounds. / 渐变鲜艳的文字和背景。 |
| `Colorful` + `Gradient` | Gradient background with gradient text. / 渐变背景配渐变文字。 |

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `LabelFontSize` | Default font size for Label / Label 的默认字体大小 |
| `LabelFontWeight` | Default font weight for Label / Label 的默认字体粗细 |
| `LabelForeground` | Default foreground color for Label / Label 的默认前景色 |
| `TagLabelBackground` | Default background for TagLabel / TagLabel 的默认背景 |
| `TagLabelBorderBrush` | Border brush for TagLabel / TagLabel 的边框画刷 |
| `TagLabelBorderThickness` | Border thickness for TagLabel / TagLabel 的边框厚度 |
| `TagLabelCornerRadius` | Corner radius for TagLabel / TagLabel 的圆角 |
| `TagLabelFontSize` | Font size for TagLabel / TagLabel 的字体大小 |
| `TagLabelFontWeight` | Font weight for TagLabel / TagLabel 的字体粗细 |
| `TagLabelForeground` | Foreground color for TagLabel / TagLabel 的前景色 |
| `TagLabelPadding` | Padding inside TagLabel / TagLabel 的内边距 |

## FAQ / 常见问题

**Q: Label vs TextBlock? / Label 和 TextBlock 的区别？**

A: `Label` supports `Target` and access keys for form accessibility. `TextBlock` supports inline formatting (`Run`, `Bold`) and text wrapping. / `Label` 支持 `Target` 和访问键用于表单可访问性。`TextBlock` 支持内联格式化（`Run`、`Bold`）和文本换行。