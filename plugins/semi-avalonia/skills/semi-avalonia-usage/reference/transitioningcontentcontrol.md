---
category: Components
title: TransitioningContentControl
subtitle: 过渡内容控件
description: 过渡内容控件在内容切换时提供动画过渡效果。
---

# TransitioningContentControl / 过渡内容控件

A `ContentControl` that animates transitions when its `Content` property changes. Supports configurable transition animations (fade, slide, etc.). Inherits from `ContentControl`.

在 `Content` 属性改变时添加动画过渡的 `ContentControl`。支持可配置的过渡动画（淡入淡出、滑动等）。继承自 `ContentControl`。

## When to Use / 何时使用

Use `TransitioningContentControl` to add polish to content switches — wizard step transitions, dynamic panel content, page navigation within a fixed area. For full-page navigation with history, use `NavigationPage`.

为内容切换添加过渡效果——向导步骤过渡、动态面板内容、固定区域内的页面导航。完整页面导航用 `NavigationPage`。

## Basic Usage / 基本使用

```xml
<TransitioningContentControl Content="{Binding CurrentView}">
    <TransitioningContentControl.Transition>
        <CrossFade Duration="0:0:0.3" />
    </TransitioningContentControl.Transition>
</TransitioningContentControl>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Content` | `object?` | The content to display (animated on change). / 要显示的内容。 |
| `Transition` | `IPageTransition?` | The transition animation. `CrossFade`, `PageSlide`, custom. / 过渡动画。 |
| `IsTransitioning` | `bool` | (Read-only) Whether a transition is in progress. / 过渡是否正在进行中。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How to use different transitions for forward/back navigation? / 如何为前进/后退使用不同过渡？**

A: Change the `Transition` property before setting `Content`. For `NavigationPage`, the page transitions are handled automatically. / 在设置 `Content` 前更改 `Transition` 属性。`NavigationPage` 会自动处理页面过渡。