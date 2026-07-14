---
category: Components
title: ThemeVariantScope
subtitle: 主题变体范围
description: 主题变体范围用于在局部区域内覆盖当前主题变体（浅色/深色）。
---

# ThemeVariantScope / 主题变体范围

A container that overrides the `ThemeVariant` for all descendants within its subtree. Used for mixing light and dark sections in the same window. Inherits from `Decorator`.

覆盖子树中所有后代 `ThemeVariant` 的容器。用于在同一窗口中混合浅色和深色区域。继承自 `Decorator`。

## When to Use / 何时使用

Use `ThemeVariantScope` to create a dark sidebar in a light-themed app, or preview content in both themes simultaneously. The `RequestedThemeVariant` property cascades to all children.

在浅色主题应用中创建深色侧边栏，或同时预览两种主题的内容。`RequestedThemeVariant` 属性会级联到所有子元素。

## Basic Usage / 基本使用

```xml
<ThemeVariantScope RequestedThemeVariant="Dark">
    <Border Background="{DynamicResource SemiBackground0Color}"
            Padding="16">
        <TextBlock Text="This section is always dark" />
    </Border>
</ThemeVariantScope>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `RequestedThemeVariant` | `ThemeVariant` | `Light`, `Dark`, or `Default` (inherits from parent). / 请求的主题变体。 |
| `Child` | `Control?` | The single child element. / 单个子元素。 |

## Styling & Templating / 样式与模板

`ThemeVariantScope` itself has no visual appearance — it is a pure theme scope container. Semi.Avalonia `DynamicResource` brushes respond automatically to the scoped theme variant.

## FAQ / 常见问题

**Q: How to toggle app-wide theme? / 如何切换应用全局主题？**

A: Set `Application.Current.RequestedThemeVariant` to `Light` or `Dark`. `ThemeVariantScope` is for local overrides. / 设置 `Application.Current.RequestedThemeVariant`。`ThemeVariantScope` 用于局部覆盖。