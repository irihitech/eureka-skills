---
category: Components
title: Border
subtitle: 边框
description: 边框控件用于绘制边框、背景，并可围绕单个子元素设置圆角。
---

# Border / 边框

A decorator control that draws a border, background, and optional corner radius around a single child. Supports `BoxShadow` for shadow effects. Inherits from `Decorator`.

围绕单个子元素绘制边框、背景和可选圆角的装饰控件。支持 `BoxShadow` 阴影效果。继承自 `Decorator`。

## When to Use / 何时使用

Use `Border` to add visual separation — card containers, highlighted sections, image frames. For clipping without a border, `Border` also supports `ClipToBounds`.

用于添加视觉分隔——卡片容器、高亮区域、图片框架。无需边框的裁剪也可使用 `ClipToBounds`。

## Basic Usage / 基本使用

```xml
<Border
        BorderThickness="1"
        CornerRadius="8"
        Padding="16">
    <TextBlock Text="Card content" />
</Border>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Background` | `IBrush?` | Fill color. / 填充颜色。 |
| `BorderBrush` | `IBrush?` | Border color. / 边框颜色。 |
| `BorderThickness` | `Thickness` | Border width. / 边框宽度。 |
| `CornerRadius` | `CornerRadius` | Rounding radius. / 圆角半径。 |
| `BoxShadow` | `BoxShadows` | Shadow effect. / 阴影效果。 |
| `Child` | `Control?` | The single child element. / 单个子元素。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How to add a shadow to a card? / 如何给卡片添加阴影？**

A: Set the `BoxShadow` property on the `Border`. Semi ships predefined shadow-level DynamicResources — pick one from the generated `semi-avalonia` skill's token reference instead of hand-writing a color. / 在 `Border` 上设置 `BoxShadow` 属性。Semi 提供预定义的阴影级别 DynamicResource —— 从生成的 `semi-avalonia` skill 的 token 参考中选取，而不是手写颜色值。