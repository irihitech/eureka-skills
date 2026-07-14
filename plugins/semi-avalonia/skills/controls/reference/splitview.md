---
category: Components
title: SplitView
subtitle: 分割视图
description: 分割视图提供可折叠的侧边导航面板和主内容区域。
---

# SplitView / 分割视图

A container with a collapsible side pane and a main content area. Used for navigation drawers, master-detail layouts. Inherits from `ContentControl`.

带有可折叠侧面板和主内容区域的容器。用于导航抽屉、主从布局。继承自 `ContentControl`。

## When to Use / 何时使用

Use `SplitView` for app-shell navigation patterns — hamburger menus, settings with sidebar, email client layouts. The pane can overlay or push content.

用于应用外壳导航模式——汉堡菜单、带侧边栏的设置、邮件客户端布局。侧面板可覆盖或推移内容。

## Basic Usage / 基本使用

```xml
<SplitView IsPaneOpen="{Binding IsDrawerOpen}"
           DisplayMode="CompactOverlay"
           PanePlacement="Left"
           OpenPaneLength="240"
           CompactPaneLength="48">
    <SplitView.Pane>
        <ListBox ItemsSource="{Binding NavItems}" />
    </SplitView.Pane>
    <ContentControl Content="{Binding MainContent}" />
</SplitView>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Pane` | `object?` | The side panel content. / 侧面板内容。 |
| `Content` | `object?` | The main content. / 主内容。 |
| `IsPaneOpen` | `bool` | Whether the pane is open. / 侧面板是否打开。 |
| `DisplayMode` | `SplitViewDisplayMode` | `Overlay`, `Inline`, `CompactOverlay`, `CompactInline`. |
| `PanePlacement` | `SplitViewPanePlacement` | `Left` or `Right`. / `Left` 或 `Right`。 |
| `OpenPaneLength` | `double` | Width of the open pane. / 打开时的宽度。 |
| `CompactPaneLength` | `double` | Width when compact (CompactOverlay/Inline). / 紧凑模式宽度。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides `SplitView` theming with `SplitViewPaneBackground`, `SplitViewLightDismissOverlayBackground`. Pseudo-classes: `:paneopen`, `:paneclosed`.

## FAQ / 常见问题

**Q: When to use SplitView vs DrawerPage? / SplitView 和 DrawerPage 的区别？**

A: `SplitView` is a low-level container. `DrawerPage` wraps `SplitView` with pre-built gesture/animation behavior. Use `DrawerPage` for mobile-style navigation; use raw `SplitView` for desktop layouts. / `SplitView` 是底层容器，`DrawerPage` 封装了手势/动画。移动端导航用 `DrawerPage`，桌面布局用原始 `SplitView`。