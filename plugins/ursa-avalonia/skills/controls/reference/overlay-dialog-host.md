---
category: Infrastructure
title: OverlayDialogHost
subtitle: 浮层对话框宿主
description: >
  Canvas-based overlay host embedded in UrsaWindow/UrsaView that manages Dialog,
  Drawer and OverlayMessageBox layers with modal masking, safe-area padding, and snap-to-edge.
  嵌入 UrsaWindow/UrsaView 的 Canvas 浮层宿主，管理 Dialog、Drawer、OverlayMessageBox 的层级、
  模态遮罩、安全区域内边距和边缘吸附。
---

# OverlayDialogHost / 浮层对话框宿主

A `Canvas`-based container embedded in `UrsaWindow` and `UrsaView` templates (via
`PART_DialogHost`) that hosts all overlay controls. Derived from `Canvas`.

嵌入 `UrsaWindow` 和 `UrsaView` 模板（通过 `PART_DialogHost`）的 `Canvas` 容器，
承载所有浮层控件。派生自 `Canvas`。

## When to Use / 何时使用

You rarely instantiate `OverlayDialogHost` directly. It is included automatically
in `UrsaWindow` and `UrsaView` templates. Every application using `OverlayDialog.Show()`,
`OverlayDrawer.Show()`, or `MessageBox.ShowAsync()` must have an `UrsaWindow` or
`UrsaView` as the root. Without it, a host lookup failure occurs.

很少需要直接实例化 `OverlayDialogHost`。它自动包含在 `UrsaWindow` 和 `UrsaView`
模板中。每个使用 `OverlayDialog.Show()`、`OverlayDrawer.Show()` 或 `MessageBox.ShowAsync()`
的应用必须以 `UrsaWindow` 或 `UrsaView` 为根。没有宿主会导致查找失败。

## Basic Usage / 基本使用

`OverlayDialogHost` is used implicitly — no direct instantiation needed:

`OverlayDialogHost` 隐式使用 —— 无需直接实例化：

```xml
<!-- UrsaWindow automatically includes OverlayDialogHost via PART_DialogHost -->
<u:UrsaWindow xmlns:u="https://irihi.tech/ursa"
              Width="800" Height="600">
    <!-- Dialog.Show() and Drawer.Show() will find the host automatically -->
    <Button Content="Open Dialog"
            Click="OnOpenDialog" />
</u:UrsaWindow>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `IsModalStatusReporter` | `bool` | When `true`, sets `IsInModalStatus` attached property on the scope root while any modal overlay is open. / 任何模态浮层打开时，在范围根上设置 `IsInModalStatus` 附加属性。 |
| `IsAnimationDisabled` | `bool` | Disables appear/disappear animations for overlay controls. / 禁用浮层控件出现/消失动画。 |
| `IsTopLevel` | `bool` | Indicates this host is the top-level overlay manager (window level vs. nested). / 指示此宿主是顶级浮层管理器（窗口级 vs 嵌套）。 |
| `SnapThickness` | `Thickness` | Snap-to-edge threshold for draggable dialog controls. / 可拖动对话框控件的吸附边缘阈值。 |
| `SafePadding` | `Thickness` | Padding that respects window decoration margins for safe dialog placement. / 遵守窗口装饰边距的安全对话框放置内边距。 |

### Attached Properties / 附加属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `IsModalStatusScope` | `bool` (attached) | Marks a visual root as a modal status boundary. Set automatically on `UrsaWindow`/`UrsaView`. / 标记可视根为模态状态边界。在 `UrsaWindow`/`UrsaView` 上自动设置。 |
| `IsInModalStatus` | `bool` (attached, read) | Read-only property indicating whether any modal overlay is currently active (triggers `:ismodal` pseudo-class). / 只读属性，指示是否有任何模态浮层当前活动（触发 `:ismodal` 伪类）。 |

## Controls Using OverlayDialogHost / 使用 OverlayDialogHost 的控件

| Control | API / 调用方式 |
| --- | --- |
| **Dialog** | `OverlayDialog.Show()` / `OverlayDialog.ShowCustom()` |
| **Drawer** | `OverlayDrawer.Show()` |
| **OverlayMessageBox** | `OverlayMessageBox.ShowAsync()` |

## Styling & Templating / 样式与模板

Theme resource: `OverlayDialogHost` ControlTheme key. Primary resource: `OverlayDialogMaskBrush` — the semi-transparent mask brush displayed behind modal dialogs.

主题资源：`OverlayDialogHost` ControlTheme 键。主要资源：`OverlayDialogMaskBrush` —— 模态对话框背后的半透明遮罩画刷。

## FAQ / 常见问题

**Q: How do I add OverlayDialogHost to a non-Ursa window? / 如何在非 Ursa 窗口中添加 OverlayDialogHost？**

A: Use `UrsaView` instead of a plain `Window`. `UrsaView` includes `OverlayDialogHost` in its template and can be embedded inside any Avalonia `Window` or used as a standalone root.

使用 `UrsaView` 替代普通 `Window`。`UrsaView` 在其模板中包含 `OverlayDialogHost`，可嵌入任何 Avalonia `Window` 或作为独立根使用。

**Q: Why do I get "MissingHostException" when calling Dialog.Show()? / 调用 Dialog.Show() 时为什么出现 "MissingHostException"？**

A: The visual tree does not contain an `OverlayDialogHost`. Ensure your application root is `UrsaWindow` or that your dialog is called from within an `UrsaView`.

可视树中不包含 `OverlayDialogHost`。确保应用根为 `UrsaWindow`，或对话框在 `UrsaView` 内调用。
