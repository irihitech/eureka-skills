---
category: Theme
title: Semi Design Tokens
subtitle: 设计令牌
description: >
  Complete reference of all Semi.Avalonia base design tokens — sizing, spacing,
  border, typography, opacity, shadow, animation, and color palette values.
  Semi.Avalonia 全部基础设计令牌参考 —— 尺寸、间距、边框、字体、透明度、阴影、
  动画和色板值。
---

# Semi Design Tokens / Semi 设计令牌

Design tokens are the foundation of the Semi.Avalonia theme system. Every
control references these base values through `DynamicResource` keys located in
`/src/Semi.Avalonia/Tokens/`. Override any token in `App.axaml` to globally
change the appearance of all controls.

设计令牌是 Semi.Avalonia 主题系统的基础。所有控件通过位于 `/src/Semi.Avalonia/Tokens/`
的 `DynamicResource` 键引用这些基础值。在 `App.axaml` 中覆写任意令牌即可全局更改
所有控件的外观。

## Token Sources / 令牌来源

| File / 文件 | Content / 内容 |
| --- | --- |
| `Variables.axaml` | All tokens: sizing, spacing, border, typography, opacity, shadow, animation / 全部令牌 |
| `Palette/` | Color palette: 16 colors × 14 shades (Light + Dark) / 色板：16 色 × 14 色阶 |
| `HighContrast/` | High-contrast color overrides for accessibility / 高对比度无障碍颜色覆盖 |
| `_index.axaml` | Merged token dictionary (includes Variables + Palette) / 合并令牌字典 |

## Sizing / 尺寸令牌

### Control Height / 控件高度

| Key / 键 | Value / 值 | Usage / 用途 |
| --- | --- | --- |
| `SemiHeightControlSmall` | 24 | 小尺寸控件 |
| `SemiHeightControlDefault` | 32 | 默认尺寸控件 |
| `SemiHeightControlLarge` | 40 | 大尺寸控件 |

### Icon Size / 图标尺寸

| Key / 键 | Value / 值 | Usage / 用途 |
| --- | --- | --- |
| `SemiWidthIconExtraSmall` | 8 | 超小图标 |
| `SemiWidthIconSmall` | 12 | 小图标 |
| `SemiWidthIconMedium` | 16 | 中图标 |
| `SemiWidthIconLarge` | 20 | 大图标 |
| `SemiWidthIconExtraLarge` | 24 | 超大图标 |

## Border / 边框令牌

### Border Radius / 圆角

| Key / 键 | Value / 值 | Usage / 用途 |
| --- | --- | --- |
| `SemiBorderRadiusSpacingExtraSmall` | 3 | 超小圆角基数 |
| `SemiBorderRadiusSpacingSmall` | 3 | 小圆角基数 |
| `SemiBorderRadiusSpacingMedium` | 6 | 中圆角基数 |
| `SemiBorderRadiusSpacingLarge` | 12 | 大圆角基数 |
| `SemiBorderRadiusSpacingFull` | 9999 | 全圆圆角基数 |

| Key / 键 | Value / 值 | Usage / 用途 |
| --- | --- | --- |
| `SemiBorderRadiusExtraSmall` | `3` (CornerRadius) | 超小圆角 |
| `SemiBorderRadiusSmall` | `3` (CornerRadius) | 小圆角 |
| `SemiBorderRadiusMedium` | `6` (CornerRadius) | 中圆角 |
| `SemiBorderRadiusLarge` | `12` (CornerRadius) | 大圆角 |
| `SemiBorderRadiusFull` | `9999` (CornerRadius) | 全圆圆角 |

### Border Thickness / 描边宽度

| Key / 键 | Value / 值 | Usage / 用途 |
| --- | --- | --- |
| `SemiBorderThickness` | `0` | 零描边宽度 |
| `SemiBorderThicknessControl` | `1` | 默认控件描边宽度 |
| `SemiBorderThicknessControlFocus` | `1` | 聚焦控件描边宽度 |
| `SemiBorderSpacing` | `0` | 零描边间距 |
| `SemiBorderSpacingControl` | `1` | 默认描边间距 |
| `SemiBorderSpacingControlFocus` | `1` | 聚焦描边间距 |

## Spacing / 间距令牌

| Key / 键 | Value / 值 | Level / 级别 |
| --- | --- | --- |
| `SemiSpacingNone` | 0 | None（零） |
| `SemiSpacingSuperTight` | 2 | SuperTight（极紧凑） |
| `SemiSpacingExtraTight` | 4 | ExtraTight（超紧凑） |
| `SemiSpacingTight` | 8 | Tight（紧凑） |
| `SemiSpacingBaseTight` | 12 | BaseTight（偏紧凑） |
| `SemiSpacingBase` | 16 | Base（默认） |
| `SemiSpacingBaseLoose` | 20 | BaseLoose（偏宽松） |
| `SemiSpacingLoose` | 24 | Loose（宽松） |
| `SemiSpacingExtraLoose` | 32 | ExtraLoose（超宽松） |
| `SemiSpacingSuperLoose` | 40 | SuperLoose（极宽松） |

## Thickness / 厚度令牌

| Key / 键 | Value / 值 | Usage / 用途 |
| --- | --- | --- |
| `SemiThicknessNone` | `0` | 零厚度 |
| `SemiThicknessExtraTight` | `4` | 超紧凑 |
| `SemiThicknessTight` | `8` | 紧凑 |
| `SemiThicknessBaseTight` | `12` | 偏紧凑 |
| `SemiThicknessBase` | `16` | 默认 |
| `SemiThicknessBaseLoose` | `20` | 偏宽松 |
| `SemiThicknessLoose` | `24` | 宽松 |
| `SemiThicknessExtraLoose` | `32` | 超宽松 |

## Typography / 字体

### Font Size / 字号

| Key / 键 | Value / 值 | Usage / 用途 |
| --- | --- | --- |
| `SemiFontSizeHeaderExtraSmall` | 12 | 超小标题 |
| `SemiFontSizeHeaderSmall` | 14 | 小标题 |
| `SemiFontSizeHeaderMedium` | 16 | 中标题 |
| `SemiFontSizeHeaderLarge` | 18 | 大标题 |
| `SemiFontSizeHeaderExtraLarge` | 20 | 超大标题 |
| `SemiFontSizeParagraphExtraSmall` | 12 | 超小正文 |
| `SemiFontSizeParagraphSmall` | 14 | 小正文（默认） |
| `SemiFontSizeParagraphMedium` | 16 | 中正文 |
| `SemiFontSizeParagraphLarge` | 18 | 大正文 |
| `SemiFontSizeParagraphExtraLarge` | 20 | 超大正文 |

### Font Weight / 字重

| Key / 键 | Value / 值 | Usage / 用途 |
| --- | --- | --- |
| `SemiTypoFontWeightExtraLight` | ExtraLight | 极细 |
| `SemiTypoFontWeightLight` | Light | 细体 |
| `SemiTypoFontWeightNormal` | Normal | 正常 |
| `SemiTypoFontWeightBold` | SemiBold | 半粗 |
| `SemiTypoFontWeightExtraBold` | Bold | 粗体 |
| `SemiTypoFontWeightBlack` | ExtraBlack | 极粗 |

## Opacity / 透明度

| Key / 键 | Value / 值 | Usage / 用途 |
| --- | --- | --- |
| `SemiOpacityHover` | 80% (`0.8`) | Hover state / 悬停态 |
| `SemiOpacityDisabled` | 62% (`0.62`) | Disabled state / 禁用态 |
| `SemiOpacityClick` | 76% (`0.76`) | Click state / 点击态 |
| `SemiOpacityDisabledText` | 40% (`0.40`) | Disabled text / 禁用文本 |

## Shadow / 阴影

All shadows are `BoxShadows` resources. / 全部阴影为 `BoxShadows` 资源。

| Key / 键 | Usage / 用途 |
| --- | --- |
| `SemiShadowDefault` | 默认阴影（较小偏移） |
| `SemiShadowCard` | 卡片阴影（大偏移，模糊半径大） |
| `SemiShadowPopup` | Popup 弹出阴影 |
| `SemiShadowTooltip` | Tooltip 提示阴影 |
| `SemiShadowDropdown` | Dropdown 下拉阴影 |
| `SemiShadowModal` | Modal 模态框阴影（最大） |

## Animation / 动画

### Duration / 时长

| Key / 键 | Value / 值 | Usage / 用途 |
| --- | --- | --- |
| `SemiDurationFast` | 200ms | 快速动画（hover/click feedback） |
| `SemiDurationNormal` | 500ms | 默认动画（transition） |
| `SemiDurationSlow` | 1000ms | 慢速动画（large transitions） |

### Easing Functions / 缓动函数

| Key / 键 | Usage / 用途 |
| --- | --- |
| `SemiEaseInOut` | EaseInOut — 标准缓入缓出 |
| `SemiEaseOut` | EaseOut — 缓出 |
| `SemiEaseIn` | EaseIn — 缓入 |
| `SemiLinear` | Linear — 线性 |

## Color Palette / 色板

Semi.Avalonia defines a 16-color palette. The lighter shades (0–9) are in the
Palette files; higher shades (10–13) are typically defined per-theme. Separate
`Light` and `Dark` theme dictionaries exist.

Semi.Avalonia 定义了 16 色调色板。较浅色阶（0–9）在 Palette 文件中定义；
较高色阶（10–13）通常按主题定义。存在独立的 `Light` 和 `Dark` 主题字典。

### Two Key Types / 两种键类型

Each shade is available in two forms:

每个色阶有两种形式：

| Type / 类型 | Pattern / 模式 | Example / 示例 | Resource Type / 资源类型 |
| --- | --- | --- | --- |
| **Brush** | `Semi{ColorName}{Shade}` | `SemiBlue5` | `SolidColorBrush` |
| **Color** | `Semi{ColorName}{Shade}Color` | `SemiBlue5Color` | `Color` |

### Color List (Brush Keys) / 颜色列表（Brush 键）

All 16 colors × shades 0–9. Each also has a corresponding `{Key}Color` variant.

全部 16 色 × 色阶 0–9。每个键都有对应的 `{Key}Color` 变体。

| Color / 颜色 | Brush Keys / Brush 键 | Shades / 色阶 |
| --- | --- | --- |
| **Amber** | `SemiAmber0`–`SemiAmber9` | 0–9 |
| **Blue** | `SemiBlue0`–`SemiBlue9` | 0–9 |
| **Cyan** | `SemiCyan0`–`SemiCyan9` | 0–9 |
| **Green** | `SemiGreen0`–`SemiGreen9` | 0–9 |
| **Grey** | `SemiGrey0`–`SemiGrey9` | 0–9 |
| **Indigo** | `SemiIndigo0`–`SemiIndigo9` | 0–9 |
| **LightBlue** | `SemiLightBlue0`–`SemiLightBlue9` | 0–9 |
| **LightGreen** | `SemiLightGreen0`–`SemiLightGreen9` | 0–9 |
| **Lime** | `SemiLime0`–`SemiLime9` | 0–9 |
| **Orange** | `SemiOrange0`–`SemiOrange9` | 0–9 |
| **Pink** | `SemiPink0`–`SemiPink9` | 0–9 |
| **Purple** | `SemiPurple0`–`SemiPurple9` | 0–9 |
| **Red** | `SemiRed0`–`SemiRed9` | 0–9 |
| **Teal** | `SemiTeal0`–`SemiTeal9` | 0–9 |
| **Violet** | `SemiViolet0`–`SemiViolet9` | 0–9 |
| **Yellow** | `SemiYellow0`–`SemiYellow9` | 0–9 |

Special: `SemiWhite`, `SemiBlack`, `SemiWhiteColor`, `SemiBlackColor`.

特殊：`SemiWhite`、`SemiBlack`、`SemiWhiteColor`、`SemiBlackColor`。

### Customizing Palette Colors / 自定义色板颜色

Override a brush in `App.axaml`:

```xml
<Application.Resources>
    <SolidColorBrush x:Key="SemiBlue5" Color="#0055CC" />
</Application.Resources>
```

Or override the underlying `Color`:

```xml
<Application.Resources>
    <Color x:Key="SemiBlue5Color">#0055CC</Color>
</Application.Resources>
```

### Semantic Color Keys / 语义颜色键

The palette feeds into semantic color keys used by controls:

色板驱动控件使用的语义颜色键：

| Semantic Key / 语义键 | Maps to / 映射至 |
| --- | --- |
| `SemiColorPrimary` | `SemiBlue5` (Light) / `SemiBlue6` (Dark) |
| `SemiColorPrimaryHover` | `SemiBlue4` |
| `SemiColorPrimaryActive` | `SemiBlue6` |
| `SemiColorPrimaryDisabled` | `SemiBlue2` |
| `SemiColorSecondary` | `SemiLightBlue5` |
| `SemiColorTertiary` | `SemiGrey2` |
| `SemiColorDanger` | `SemiRed5` |
| `SemiColorWarning` | `SemiOrange5` |
| `SemiColorSuccess` | `SemiGreen5` |
| `SemiColorText0` | `SemiGrey9` (nearly black) |
| `SemiColorText1` | `SemiGrey8` |
| `SemiColorText2` | `SemiGrey6` |
| `SemiColorTextDisabled` | `SemiGrey4` |
| `SemiColorBg0` | `SemiGrey0` (white) |
| `SemiColorBg1` | `SemiGrey1` |

> ℹ These semantic keys map to different palette shades in Dark theme.
> 这些语义键在暗色主题中映射到不同色阶。

## High Contrast / 高对比度

High-contrast overrides live under `/Tokens/HighContrast/`. They replace
low-opacity and subtle color values with higher-contrast alternatives for
accessibility (WCAG compliance). Enabled by setting the system high-contrast
theme or overriding `RequestedThemeVariant`.

高对比度覆盖位于 `/Tokens/HighContrast/`，将低透明度和微妙色彩值替换为更高对比度的
替代方案，以满足无障碍要求（WCAG 合规）。通过设置系统高对比度主题或覆写
`RequestedThemeVariant` 启用。

## Authoring New Controls / 编写新控件

When creating a new Semi.Avalonia control or custom theme, always reference base
tokens rather than hardcoding values. This ensures theme consistency and
automatic Light/Dark support.

编写新的 Semi.Avalonia 控件或自定义主题时，始终引用基础令牌而非硬编码值。
这确保主题一致性并自动支持亮色/暗色模式。

### Step 1: Use Base Tokens Directly / 直接使用基础令牌

For spacing, sizing, and border values, reference base tokens:

间距、尺寸和边框值直接引用基础令牌：

```xml
<!-- ✅ Good: use base tokens -->
<Setter Property="Height" Value="{DynamicResource SemiHeightControlDefault}" />
<Setter Property="CornerRadius" Value="{DynamicResource SemiBorderRadiusMedium}" />
<Setter Property="Padding" Value="{DynamicResource SemiThicknessBase}" />

<!-- ❌ Bad: hardcoded values -->
<Setter Property="Height" Value="32" />
<Setter Property="CornerRadius" Value="6" />
```

### Step 2: Create Semantic Aliases for Colors / 为颜色创建语义别名

For control-specific colors, create a meaningful semantic key that aliases a
base token. Use `StaticResource` with `ResourceKey` to redirect without copying
values. This makes the control's theme file self-documenting.

控件专属颜色应为基底令牌创建有意义的语义别名。使用 `StaticResource` 配合
`ResourceKey` 重定向而不复制值，使控件主题文件自文档化。

```xml
<!-- ✅ Good: semantic alias pointing to base token -->
<StaticResource x:Key="AdornerLayerSolidBorderBrush"
                ResourceKey="SemiColorText0" />

<!-- ❌ Bad: hardcoded color -->
<SolidColorBrush x:Key="AdornerLayerSolidBorderBrush" Color="Black" />
```

### Step 3: Customize Per-Theme / 按主题自定义

Override the semantic key in Light/Dark theme dictionaries when the value
should differ between themes:

当值在亮色/暗色主题间不同时，在对应主题字典中覆写语义键：

```xml
<!-- Light theme -->
<ResourceDictionary x:Key="Light">
    <SolidColorBrush x:Key="MyControlBackground" Color="{StaticResource SemiGrey0Color}" />
</ResourceDictionary>

<!-- Dark theme -->
<ResourceDictionary x:Key="Dark">
    <SolidColorBrush x:Key="MyControlBackground" Color="{StaticResource SemiGrey9Color}" />
</ResourceDictionary>
```

### Naming Convention / 命名约定

| Scope / 范围 | Pattern / 模式 | Example / 示例 |
| --- | --- | --- |
| Base token / 基础令牌 | `Semi{Category}{Variant}` | `SemiColorText0`, `SemiSpacingBase` |
| Control-specific / 控件专属 | `{ControlName}{Role}` | `AdornerLayerSolidBorderBrush`, `ButtonDefaultBackground` |

Base tokens live in `/Tokens/` and are shared across all controls. Control-
specific keys live in the control's AXAML file (`/Controls/{Control}.axaml`)
and should all ultimately resolve to base tokens.

基础令牌位于 `/Tokens/`，跨所有控件共享。控件专属键位于控件的 AXAML 文件中
（`/Controls/{Control}.axaml`），最终都解析为基础令牌。
