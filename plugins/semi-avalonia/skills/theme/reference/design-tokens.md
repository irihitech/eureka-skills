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

Semi.Avalonia defines a 16-color palette with 14 shades per color (0-13,
lightest to darkest). Separate `Light` and `Dark` theme dictionaries exist.

Semi.Avalonia 定义了 16 色调色板，每种颜色 14 个色阶（0-13，由浅到深）。
存在独立的 `Light` 和 `Dark` 主题字典。

### Naming Convention / 命名约定

```
{Semi|Color|Palette}-{ColorName}-{Shade}
```

Example: `SemiColorPaletteBlue5`

### Color List / 颜色列表

| Color / 颜色 | Primary Keys (Light) / 主键（亮色） | Typical Shade Range / 常用色阶 |
| --- | --- | --- |
| **Amber** | `SemiColorPaletteAmber0`–`Amber13` | 0–11 |
| **Blue** | `SemiColorPaletteBlue0`–`Blue13` | 0–11 |
| **Cyan** | `SemiColorPaletteCyan0`–`Cyan13` | 0–11 |
| **Green** | `SemiColorPaletteGreen0`–`Green13` | 0–11 |
| **Grey** | `SemiColorPaletteGrey0`–`Grey13` | 0–13 |
| **Indigo** | `SemiColorPaletteIndigo0`–`Indigo13` | 0–11 |
| **LightBlue** | `SemiColorPaletteLightBlue0`–`LightBlue13` | 0–11 |
| **LightGreen** | `SemiColorPaletteLightGreen0`–`LightGreen13` | 0–11 |
| **Lime** | `SemiColorPaletteLime0`–`Lime13` | 0–11 |
| **Orange** | `SemiColorPaletteOrange0`–`Orange13` | 0–11 |
| **Pink** | `SemiColorPalettePink0`–`Pink13` | 0–11 |
| **Purple** | `SemiColorPalettePurple0`–`Purple13` | 0–11 |
| **Red** | `SemiColorPaletteRed0`–`Red13` | 0–11 |
| **Teal** | `SemiColorPaletteTeal0`–`Teal13` | 0–11 |
| **Violet** | `SemiColorPaletteViolet0`–`Violet13` | 0–11 |
| **Yellow** | `SemiColorPaletteYellow0`–`Yellow13` | 0–11 |

### Customizing Palette Colors / 自定义色板颜色

Override individual shade in `App.axaml`:

```xml
<Application.Resources>
    <SolidColorBrush x:Key="SemiColorPaletteBlue5"
                     Color="#0055CC" />
</Application.Resources>
```

### Semantic Color Keys / 语义颜色键

The palette feeds into semantic color keys used by controls. Examples:

色板驱动控件使用的语义颜色键。示例：

| Semantic Key / 语义键 | Maps to / 映射至 |
| --- | --- |
| `SemiColorPrimary` | `SemiColorPaletteBlue5` (Light) / `SemiColorPaletteBlue6` (Dark) |
| `SemiColorPrimaryHover` | `SemiColorPaletteBlue4` |
| `SemiColorPrimaryActive` | `SemiColorPaletteBlue6` |
| `SemiColorPrimaryDisabled` | `SemiColorPaletteBlue2` |
| `SemiColorSecondary` | `SemiColorPaletteLightBlue5` |
| `SemiColorTertiary` | `SemiColorPaletteGrey2` |
| `SemiColorDanger` | `SemiColorPaletteRed5` |
| `SemiColorWarning` | `SemiColorPaletteOrange5` |
| `SemiColorSuccess` | `SemiColorPaletteGreen5` |
| `SemiColorText0` | `SemiColorPaletteGrey13` (nearly black) |
| `SemiColorText1` | `SemiColorPaletteGrey11` |
| `SemiColorText2` | `SemiColorPaletteGrey8` |
| `SemiColorTextDisabled` | `SemiColorPaletteGrey6` |
| `SemiColorBg0` | `SemiColorPaletteGrey0` (white) |
| `SemiColorBg1` | `SemiColorPaletteGrey1` |

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
