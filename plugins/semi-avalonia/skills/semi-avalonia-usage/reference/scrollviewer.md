---
category: Components
title: ScrollViewer
subtitle: 滚动查看器
description: 滚动查看器为超出可视区域的内容提供水平和垂直滚动功能。
---

# ScrollViewer / 滚动查看器

A container that provides scrollable viewport for content that exceeds the available space. Supports horizontal/vertical scroll bars, smooth scrolling, and scroll chaining. Inherits from `ContentControl`.

为超出可用空间的内容提供可滚动视口的容器。支持水平/垂直滚动条、平滑滚动和滚动链。继承自 `ContentControl`。

## When to Use / 何时使用

Use `ScrollViewer` whenever content may exceed its allocated space — long lists, images, code editors, chat logs. Most list controls (`ListBox`, `TreeView`) include built-in `ScrollViewer`.

当内容可能超出分配空间时使用——长列表、图片、代码编辑器、聊天日志。大多数列表控件已内置 `ScrollViewer`。

## Basic Usage / 基本使用

```xml
<ScrollViewer HorizontalScrollBarVisibility="Auto"
              VerticalScrollBarVisibility="Auto">
    <Image Source="{Binding LargeImage}" />
</ScrollViewer>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `HorizontalScrollBarVisibility` | `ScrollBarVisibility` | `Disabled`, `Auto`, `Hidden`, `Visible`. |
| `VerticalScrollBarVisibility` | `ScrollBarVisibility` | Same as above. / 同上。 |
| `Offset` | `Vector` | Current scroll offset. / 当前滚动偏移。 |
| `Extent` | `Size` | Total content size (read-only). / 内容总大小。 |
| `Viewport` | `Size` | Visible area size (read-only). / 可见区域大小。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How to detect when the user scrolls to the bottom? / 如何检测用户滚动到底部？**

A: Listen to `ScrollChanged` event and compare `Offset.Y + Viewport.Height >= Extent.Height`. / 监听 `ScrollChanged` 事件，比较偏移量和范围。