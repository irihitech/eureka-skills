---
category: Components
title: TabControl
subtitle: 选项卡控件
description: 选项卡控件用于在多个内容页面之间切换，每次显示一个页面。
---

# TabControl / 选项卡控件

A control that displays multiple pages with clickable tab headers. Each page is a `TabItem`. Inherits from `SelectingItemsControl`.

显示多个内容页面的控件，带有可点击的选项卡标题。每个页面是 `TabItem`。继承自 `SelectingItemsControl`。

## When to Use / 何时使用

Use `TabControl` when you need to switch between multiple content views where only one is visible at a time. For wizard-style sequential flow, use `Carousel`. For mobile navigation, use `TabbedPage`.

需要在多个内容视图之间切换且每次只显示一个时使用。向导式顺序流程用 `Carousel`。移动导航用 `TabbedPage`。

## Basic Usage / 基本使用

```xml
<TabControl>
    <TabItem Header="General">
        <StackPanel><!-- settings --></StackPanel>
    </TabItem>
    <TabItem Header="Advanced">
        <StackPanel><!-- advanced --></StackPanel>
    </TabItem>
</TabControl>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `SelectedIndex` | `int` | Selected tab index. / 选中的选项卡索引。 |
| `SelectedItem` | `object?` | The selected `TabItem`. / 选中的 `TabItem`。 |
| `TabStripPlacement` | `Dock` | Tab strip position: `Top`, `Bottom`, `Left`, `Right`. |

## Styling & Templating / 样式与模板

Semi.Avalonia themes `TabControl` and `TabItem` with `TabItemBackground`, `TabItemForeground`, `TabItemSelectedBackground`. Pseudo-classes on `TabItem`: `:selected`, `:pointerover`, `:pressed`.

## FAQ / 常见问题

**Q: TabControl vs TabStrip? / TabControl 和 TabStrip 的区别？**

A: `TabControl` includes both the tab strip and content area. `TabStrip` is the tab header row only — pair it with `Carousel` for custom content switching. / `TabControl` 包含选项卡条和内容区。`TabStrip` 仅是选项卡标题行——搭配 `Carousel` 实现自定义内容切换。