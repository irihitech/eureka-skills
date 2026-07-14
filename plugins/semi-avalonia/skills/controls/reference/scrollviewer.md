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

## Styling & Templating / 样式与模板

Semi themes scroll bars via `ScrollBarThumbBackground`, `ScrollBarThumbPointeroverBackground`, `ScrollBarTrackBackground`. `ScrollViewer` itself delegates to these resources.

## FAQ / 常见问题

**Q: How to detect when the user scrolls to the bottom? / 如何检测用户滚动到底部？**

A: Listen to `ScrollChanged` event and compare `Offset.Y + Viewport.Height >= Extent.Height`. / 监听 `ScrollChanged` 事件，比较偏移量和范围。