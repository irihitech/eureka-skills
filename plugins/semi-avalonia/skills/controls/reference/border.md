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
<Border Background="{DynamicResource SemiBackground1Color}"
        BorderBrush="{DynamicResource SemiBorderColor}"
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

## Styling & Templating / 样式与模板

Semi.Avalonia provides semantic corner radius resources: `SemiCornerRadiusSmall`, `SemiCornerRadiusMedium`, `SemiCornerRadiusLarge`. Border colors: `SemiBorderColor`.

## FAQ / 常见问题

**Q: How to add a shadow to a card? / 如何给卡片添加阴影？**

A: Use `BoxShadow="0 2 8 0 #20000000"`. Semi provides `SemiBoxShadowLevel1/2/3` DynamicResources. / 使用 `BoxShadow` 属性，Semi 提供预定义阴影级别资源。