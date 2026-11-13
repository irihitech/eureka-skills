---
category: Components
title: TabStrip
subtitle: 选项卡条
description: 选项卡条显示一行可点击的选项卡标题，通常与 Carousel 配合使用。
---

# TabStrip / 选项卡条

A row of clickable tab headers. Typically paired with `Carousel` using `{Binding SelectedItem}` to switch content. Inherits from `ItemsControl`.

一行可点击的选项卡标题。通常与 `Carousel` 搭配使用，通过 `{Binding SelectedItem}` 切换内容。

## When to Use / 何时使用

Use `TabStrip` + `Carousel` when you need custom content transition animations not available in `TabControl`. For standard tab UI, use `TabControl` which bundles strip + content.

需要 `TabControl` 中没有的自定义内容过渡动画时使用。标准选项卡 UI 用 `TabControl`。

## Basic Usage / 基本使用

```xml
<TabStrip Name="strip" ItemsSource="{Binding Tabs}" />
<Carousel ItemsSource="{Binding Tabs}"
          SelectedItem="{Binding SelectedItem, ElementName=strip}" />
```

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: TabStrip vs TabControl? / 何时用 TabStrip 而非 TabControl？**

A: Use `TabControl` for most cases. Use `TabStrip` + `Carousel` only when you need custom page transitions. / 大多数情况用 `TabControl`。仅在需要自定义页面过渡时使用 `TabStrip` + `Carousel`。