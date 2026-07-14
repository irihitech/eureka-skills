---
category: Components
title: ThemeVariantMapper
subtitle: 主题变体映射器
description: 用于在多个 ThemeVariant 之间动态切换并传播主题变化的容器控件。
---

# ThemeVariantMapper / 主题变体映射器

A container control that dynamically switches between multiple ThemeVariants and propagates theme changes to child controls. Used for implementing runtime theme switching.

用于在多个 ThemeVariant 之间动态切换并将主题变化传播到子控件的容器控件。用于实现运行时主题切换。

## When to Use / 何时使用

Use `ThemeVariantMapper` when implementing theme switching functionality — light/dark mode toggle, custom theme selection. It maps theme variant keys to actual `ThemeVariant` instances and updates children automatically.

在实现主题切换功能时使用 —— 浅色/深色模式切换、自定义主题选择。将主题变体键映射到 `ThemeVariant` 实例并自动更新子控件。

## Basic Usage / 基本使用

```xml
<ursa:ThemeVariantMapper Variant="{Binding SelectedTheme}">
    <StackPanel>
        <Button Content="Themed Button" />
        <TextBox Watermark="Themed Input" />
    </StackPanel>
</ursa:ThemeVariantMapper>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Variant` | `ThemeVariant` | The active theme variant applied to children. / 应用于子控件的活动主题变体。 |

## Styling & Templating / 样式与模板

Minimal styling — acts as a logical container. Propagates `ThemeVariant` changes to the visual tree.
