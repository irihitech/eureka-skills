---
category: Components
title: Expander
subtitle: 展开器
description: 展开器用于显示可折叠的内容区域，点击标题可展开或收起内容。
---

# Expander / 展开器

A control with a clickable header that expands or collapses a content area. Inherits from `HeaderedContentControl`. Supports expand direction and accordion patterns.

带有可点击标题的控件，可展开或收起内容区域。继承自 `HeaderedContentControl`。支持展开方向和手风琴模式。

## When to Use / 何时使用

Use `Expander` to show/hide content sections to reduce visual clutter — settings categories, help sections, collapsible sidebars, FAQ accordions. For automatic content switching, use `TabControl`.

使用 `Expander` 显示/隐藏内容区域以减轻视觉混乱。自动内容切换使用 `TabControl`。

## Basic Usage / 基本使用

```xml
<Expander Header="Advanced Settings">
    <StackPanel Spacing="8">
        <CheckBox Content="Enable logging" />
        <TextBox Watermark="Log path" />
    </StackPanel>
</Expander>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Header` | `object?` | The clickable header content. / 可点击的标题内容。 |
| `Content` | `object?` | The collapsible content. / 可折叠的内容。 |
| `IsExpanded` | `bool` | Whether content is visible (default `false`). / 内容是否可见。 |
| `ExpandDirection` | `ExpandDirection` | `Down`, `Up`, `Left`, `Right`. / 展开方向。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Expanded` | Content becomes visible. / 内容展开。 |
| `Collapsed` | Content becomes hidden. / 内容收起。 |

## Styling & Templating / 样式与模板

Semi.Avalonia styles `Expander` with a toggle button in the header. Pseudo-classes: `:expanded`, `:collapsed`. Key resources: `ExpanderHeaderBackground`, `ExpanderContentBackground`. Template part: `PART_HeaderToggleButton`.

## FAQ / 常见问题

**Q: How to create an accordion? / 如何创建手风琴效果？**

A: Bind each `Expander.IsExpanded` in a ViewModel group so expanding one collapses others. / 在 ViewModel 中绑定 `IsExpanded`，展开一个时收起其他的。