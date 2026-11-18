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
        <TextBox PlaceholderText="Log path" />
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

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How to create an accordion? / 如何创建手风琴效果？**

A: Bind each `Expander.IsExpanded` in a ViewModel group so expanding one collapses others. / 在 ViewModel 中绑定 `IsExpanded`，展开一个时收起其他的。