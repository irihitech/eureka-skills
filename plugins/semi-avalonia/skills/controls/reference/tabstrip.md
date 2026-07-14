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

## Styling & Templating / 样式与模板

Semi.Avalonia themes `TabStrip` with `TabStripItem` styling. Key resources: `TabStripItemBackground`, `TabStripItemSelectedForeground`. Pseudo-classes: `:selected`, `:pointerover`.

## FAQ / 常见问题

**Q: TabStrip vs TabControl? / 何时用 TabStrip 而非 TabControl？**

A: Use `TabControl` for most cases. Use `TabStrip` + `Carousel` only when you need custom page transitions. / 大多数情况用 `TabControl`。仅在需要自定义页面过渡时使用 `TabStrip` + `Carousel`。