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

### Semi.Avalonia ControlThemes / Semi.Avalonia 控件主题

Semi.Avalonia provides two additional `ScrollViewer` ControlThemes beyond the default, plus a `ScrollBarRepeatButton` theme used internally by the `ScrollBar` template.

Semi.Avalonia 在默认主题之外提供了两个额外的 `ScrollViewer` ControlTheme，以及一个由 `ScrollBar` 模板内部使用的 `ScrollBarRepeatButton` 主题。

| Theme / 主题 | Resource Key / 资源键 | Description / 说明 |
| --- | --- | --- |
| **StaticScrollViewer** | `StaticScrollViewer` | ScrollViewer where scroll bars always sit outside the content area — equivalent to applying the `InsetContent` style class to the default theme. / 滚动条始终位于内容区域之外的 ScrollViewer — 等同于对默认主题应用 `InsetContent` 样式类。 |
| **ScrollBarRepeatButton** | `ScrollBarRepeatButton` | Transparent, borderless `RepeatButton` theme used by line-up/down and page-up/down buttons inside `ScrollBar`. / 透明无边框的 `RepeatButton` 主题，由 `ScrollBar` 内的上下行按钮和上下页按钮使用。 |

```xml
<!-- StaticScrollViewer: scroll bars stay outside content -->
<ScrollViewer Theme="{StaticResource StaticScrollViewer}"
              HorizontalScrollBarVisibility="Auto"
              VerticalScrollBarVisibility="Auto">
    <Border Width="800" Height="800" Background="LightGray" />
</ScrollViewer>

<!-- The default ScrollViewer uses InsetContent class for similar effect -->
<ScrollViewer Classes="InsetContent"
              HorizontalScrollBarVisibility="Auto"
              VerticalScrollBarVisibility="Auto">
    <Border Width="800" Height="800" Background="LightGray" />
</ScrollViewer>
```

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `ScrollBarBackground` | ScrollBar background. / 滚动条背景。 |
| `ScrollBarButtonBackground` | ScrollBar button background. / 滚动条按钮背景。 |
| `ScrollBarButtonPointeroverBackground` | ScrollBar button background on hover. / 滚动条按钮悬停背景。 |
| `ScrollBarButtonPressedBackground` | ScrollBar button background when pressed. / 滚动条按钮按下背景。 |
| `ScrollBarCornerBackground` | ScrollBar corner background (intersection of horizontal/vertical scroll bars). / 滚动条角落背景（水平与垂直滚动条交叉处）。 |
| `ScrollBarThumbBackground` | ScrollBar thumb color. / 滚动条滑块颜色。 |
| `ScrollBarThumbPointeroverBackground` | Thumb color on hover. / 悬停时的滑块颜色。 |
| `ScrollBarThumbPressedBackground` | ScrollBar thumb color when pressed. / 滚动条滑块按下颜色。 |

## FAQ / 常见问题

**Q: How to detect when the user scrolls to the bottom? / 如何检测用户滚动到底部？**

A: Listen to `ScrollChanged` event and compare `Offset.Y + Viewport.Height >= Extent.Height`. / 监听 `ScrollChanged` 事件，比较偏移量和范围。