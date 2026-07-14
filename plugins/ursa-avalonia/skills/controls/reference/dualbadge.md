---
category: Components
title: DualBadge
subtitle: 双区徽标
description: >
  A two-part badge control with an optional icon, a header label (left section),
  and a content value (right section). Supports four style variants (Flat,
  FlatSquare, Plastic, ForTheBadge) and 16 color themes. Built on
  HeaderedContentControl with dedicated foreground/background brushes per
  section. Ideal for download counters, version badges, and stats displays.
  一个双区徽标控件，包含可选图标、标题标签（左区）和内容值（右区）。支持四种
  样式变体（Flat、FlatSquare、Plastic、ForTheBadge）和 16 种颜色主题。基于
  HeaderedContentControl 构建，每个区域有专用前景/背景画刷。适用于下载计数、
  版本徽标和统计数据显示。
---

# DualBadge / 双区徽标

## When to Use / 何时使用

Use `DualBadge` to display a metric or label with a structured two-part layout:
a header/key section on the left and a value section on the right, with an
optional icon. It is inspired by shields.io badges and works well for download
counts, version badges, CI status, and any key-value display in a compact
badge form.

使用 `DualBadge` 显示带有结构化两部分布局的指标或标签：左侧标题/键部分和右侧
值部分，可选图标。其灵感来自 shields.io 徽章，适用于下载计数、版本徽章、CI
状态以及任何紧凑徽章形式的键值显示。

`DualBadge` extends `HeaderedContentControl`: `Header` is the left label (e.g.,
"downloads"), `Content` is the right value (e.g., "35k"), and `Icon` is an
optional leading icon.

`DualBadge` 继承自 `HeaderedContentControl`：`Header` 是左侧标签（如
"downloads"），`Content` 是右侧值（如 "35k"），`Icon` 是可选的前导图标。

## Basic Usage / 基本使用

### Simple Badge / 简单徽标

```xml
xmlns:u="https://irihi.tech/ursa"

<u:DualBadge Content="35k" />
```

### With Header / 带标题

```xml
<u:DualBadge Content="35k" Header="downloads" />
```

### With Icon / 带图标

```xml
<u:DualBadge
    Content="35k"
    Header="downloads"
    Icon="{StaticResource SemiIconDownload}" />
```

## Common Scenarios / 常用场景

### 1. Style Variants / 样式变体

```xml
<!-- Flat (default): rounded pill with flat colors -->
<u:DualBadge Content="35k" Header="downloads" />

<!-- FlatSquare: rectangular with slight rounding -->
<u:DualBadge Classes="FlatSquare" Content="35k" Header="downloads" />

<!-- Plastic: more padding, semi-transparent header background -->
<u:DualBadge Classes="Plastic" Content="35k" Header="downloads" />

<!-- ForTheBadge: shields.io style, large padding and radius -->
<u:DualBadge Classes="ForTheBadge" Content="35K" Header="DOWNLOADS" />
```

### 2. Color Themes / 颜色主题

```xml
<WrapPanel>
    <u:DualBadge Classes="Red">Red</u:DualBadge>
    <u:DualBadge Classes="Pink">Pink</u:DualBadge>
    <u:DualBadge Classes="Purple">Purple</u:DualBadge>
    <u:DualBadge Classes="Violet">Violet</u:DualBadge>
    <u:DualBadge Classes="Indigo">Indigo</u:DualBadge>
    <u:DualBadge Classes="Blue">Blue</u:DualBadge>
    <u:DualBadge Classes="LightBlue">LightBlue</u:DualBadge>
    <u:DualBadge Classes="Cyan">Cyan</u:DualBadge>
    <u:DualBadge Classes="Teal">Teal</u:DualBadge>
    <u:DualBadge Classes="Green">Green</u:DualBadge>
    <u:DualBadge Classes="LightGreen">LightGreen</u:DualBadge>
    <u:DualBadge Classes="Lime">Lime</u:DualBadge>
    <u:DualBadge Classes="Yellow">Yellow</u:DualBadge>
    <u:DualBadge Classes="Amber">Amber</u:DualBadge>
    <u:DualBadge Classes="Orange">Orange</u:DualBadge>
    <u:DualBadge Classes="Grey">Grey</u:DualBadge>
</WrapPanel>
```

Color classes set the `Background` of the content (right) section. Combine with
any style variant: `Classes="Plastic Red"`, `Classes="FlatSquare Blue"`, etc.

颜色类设置内容（右侧）部分的 `Background`。可与任何样式变体组合：
`Classes="Plastic Red"`、`Classes="FlatSquare Blue"` 等。

### 3. Four Configurations / 四种配置

```xml
<!-- Content only -->
<u:DualBadge Content="35k" />

<!-- Icon + Content -->
<u:DualBadge Content="35k" Icon="{StaticResource SemiIconDownload}" />

<!-- Header + Content -->
<u:DualBadge Content="35k" Header="downloads" />

<!-- Icon + Header + Content -->
<u:DualBadge
    Content="35k"
    Header="downloads"
    Icon="{StaticResource SemiIconDownload}" />
```

When `Header` is omitted, `HeaderBackground` auto-binds to `Background` for a
unified look (via the `:header-empty` pseudo-class).

当省略 `Header` 时，`HeaderBackground` 自动绑定到 `Background` 以实现统一外观
（通过 `:header-empty` 伪类）。

## Property Reference / 属性参考

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Icon` | `object?` | `null` | Optional icon displayed before the header. / 显示在标题之前的可选图标。 |
| `IconTemplate` | `IDataTemplate?` | `null` | Template for the icon content. / 图标内容的模板。 |
| `IconForeground` | `IBrush?` | (theme) | Foreground brush for the icon area. / 图标区域的前景画刷。 |
| `Header` | `object?` | `null` | Left section label (inherited from HeaderedContentControl). / 左侧部分标签（继承自 HeaderedContentControl）。 |
| `HeaderTemplate` | `IDataTemplate?` | `null` | Template for the header. / 标题模板。 |
| `HeaderForeground` | `IBrush?` | (theme) | Foreground brush for the header section. / 标题部分的前景画刷。 |
| `HeaderBackground` | `IBrush?` | (theme) | Background brush for the header section. / 标题部分的背景画刷。 |
| `Content` | `object?` | `null` | Right section value (inherited from ContentControl). / 右侧部分值（继承自 ContentControl）。 |
| `ContentTemplate` | `IDataTemplate?` | `null` | Template for the content. / 内容模板。 |

## Events / 事件

No custom events. Inherits standard `HeaderedContentControl` events.

无自定义事件。继承标准 `HeaderedContentControl` 事件。

## Styling & Templating / 样式与模板

### ControlTheme Key

| Theme Key | Target Type | Description / 说明 |
|---|---|---|
| `{x:Type u:DualBadge}` | `DualBadge` | Main theme. Two-column `Grid`: left `DockPanel` (Icon + Header), right `ContentPresenter`. / 主主题。两列 `Grid`：左侧 `DockPanel`（图标 + 标题），右侧 `ContentPresenter`。 |

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_Icon` | `DualBadge` | `ContentPresenter` |
| `PART_HeaderPresenter` | `DualBadge` | `ContentPresenter` |
| `PART_ContentPresenter` | `DualBadge` | `ContentPresenter` |

### Pseudo-classes / 伪类

| Pseudo-class | Description / 说明 |
|---|---|
| `:icon-empty` | Set when `Icon` is `null`. / 当 `Icon` 为 `null` 时设置。 |
| `:header-empty` | Set when `Header` is `null`. Also binds `HeaderBackground` to `Background` for unified look. / 当 `Header` 为 `null` 时设置。同时将 `HeaderBackground` 绑定到 `Background` 以实现统一外观。 |
| `:content-empty` | Set when `Content` is `null`. / 当 `Content` 为 `null` 时设置。 |

### Style Variant Classes / 样式变体类

| Class | Description / 说明 |
|---|---|
| _(none/Flat)_ | Default rounded pill. / 默认圆角药丸形。 |
| `FlatSquare` | Rounded rectangle (smaller corner radius). / 圆角矩形（较小圆角）。 |
| `Plastic` | Larger padding, distinct header background. / 较大内边距，不同的标题背景。 |
| `ForTheBadge` | Shields.io style: large corner radius and padding. / Shields.io 风格：大圆角和大内边距。 |

### Color Classes / 颜色类

| Class | Description / 说明 |
|---|---|
| `Red` | Red background on content section. / 内容区域红色背景。 |
| `Pink` | Pink background. / 粉色背景。 |
| `Purple` | Purple background. / 紫色背景。 |
| `Violet` | Violet background. / 紫罗兰背景。 |
| `Indigo` | Indigo background. / 靛蓝背景。 |
| `Blue` | Blue background. / 蓝色背景。 |
| `LightBlue` | Light blue background. / 浅蓝背景。 |
| `Cyan` | Cyan background. / 青色背景。 |
| `Teal` | Teal background. / 蓝绿背景。 |
| `Green` | Green background (default). / 绿色背景（默认）。 |
| `LightGreen` | Light green background. / 浅绿背景。 |
| `Lime` | Lime background. / 酸橙背景。 |
| `Yellow` | Yellow background. / 黄色背景。 |
| `Amber` | Amber background. / 琥珀背景。 |
| `Orange` | Orange background. / 橙色背景。 |
| `Grey` | Grey background. / 灰色背景。 |

### Theme Resources / 主题资源

| Resource Key | Applies To | Description / 说明 |
|---|---|---|
| `DualBadgeDefaultIconForeground` | Icon | Default icon foreground. / 默认图标前景。 |
| `DualBadgeDefaultHeaderForeground` | Header | Default header text color. / 默认标题文字颜色。 |
| `DualBadgeDefaultHeaderBackground` | Header | Default header background. / 默认标题背景。 |
| `DualBadgeDefaultForeground` | Content | Default content text color. / 默认内容文字颜色。 |
| `DualBadgeDefaultFontSize` | All text | Default font size. / 默认字号。 |
| `DualBadgeDefaultCornerRadius` | Border | Default corner radius (Flat). / 默认圆角（Flat）。 |
| `DualBadgeDefaultPadding` | Content | Default padding (Flat). / 默认内边距（Flat）。 |
| `DualBadgeFlat{Color}Background` | Content | Background per color in Flat style. / Flat 样式各颜色背景。 |
| `DualBadgeFlatSquareCornerRadius` | Border | Corner radius for FlatSquare. / FlatSquare 的圆角。 |
| `DualBadgePlasticPadding` | Content | Padding for Plastic variant. / Plastic 变体内边距。 |
| `DualBadgePlasticHeaderBackground` | Header | Header background for Plastic. / Plastic 变体标题背景。 |
| `DualBadgePlastic{Color}Background` | Content | Background per color in Plastic. / Plastic 样式各颜色背景。 |
| `DualBadgeForTheBadgeCornerRadius` | Border | Corner radius for ForTheBadge. / ForTheBadge 的圆角。 |
| `DualBadgeForTheBadgePadding` | Content | Padding for ForTheBadge. / ForTheBadge 内边距。 |

## FAQ / 常见问题

**Q: Can I use DualBadge without a Header? / 可以不带 Header 使用 DualBadge 吗？**
A: Yes. When `Header` is `null`, the `:header-empty` pseudo-class binds
`HeaderBackground` to `Background`, creating a single-color badge. Only the
content section is visible.

**Q: How do I combine a color with a style variant? / 如何组合颜色和样式变体？**
A: Set both classes: `Classes="Plastic Red"` or `Classes="FlatSquare Blue"`.
The variant class sets padding/radius; the color class sets the background.

**Q: What types can I use for the Icon? / Icon 可以使用哪些类型？**
A: The theme includes a `DataTemplate` for `Geometry` that renders a
`PathIcon`. You can also provide any content (Image, PathIcon directly, etc.)
using `IconTemplate`.

**Q: How do I customize the icon color? / 如何自定义图标颜色？**
A: Set `IconForeground` to an `IBrush`:
```xml
<u:DualBadge IconForeground="White" Icon="{StaticResource SemiIconDownload}" Content="35k" />
```

**Q: What's the difference between Flat and FlatSquare? / Flat 和 FlatSquare 有什么区别？**
A: `Flat` has a larger corner radius (pill-shaped), while `FlatSquare` has a
smaller corner radius (rounded rectangle). Both use the same padding and
background colors.
