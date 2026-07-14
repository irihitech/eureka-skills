---
category: Infrastructure
title: OverlayDialogHost
subtitle: 浮层对话框宿主
description: >
  Shared infrastructure for Ursa virtual dialogs (OverlayDialog, MessageBox, Drawer).
  Place anywhere in the visual tree to host overlay content that covers UI placed above it.
  Ursa 虚拟对话框（OverlayDialog、MessageBox、Drawer）的共享基础设施。放置在可视树
  任意位置，承载覆盖其上方 UI 的浮层内容。
---

# OverlayDialogHost / 浮层对话框宿主

`OverlayDialogHost` is the shared infrastructure for Ursa "virtual dialog" controls —
`OverlayDialog`, `MessageBox`, and `Drawer`. Any code location can access the
host through Ursa's internal mechanism; you only need to place it once in the
visual tree.

`OverlayDialogHost` 是 Ursa "虚拟对话框" 控件（`OverlayDialog`、`MessageBox`、
`Drawer`）的共享基础设施。代码的任何位置都可以通过 Ursa 的内部机制访问到宿主；
只需在可视树中放置一次即可。

## How It Works / 工作原理

`OverlayDialogHost` covers content placed **above** it in z-order. Place the UI
you want to be blocked above, then `OverlayDialogHost` below:

`OverlayDialogHost` 按 z-order 覆盖放置在其**上方**的内容。将需要被遮挡的 UI 放在上方，
`OverlayDialogHost` 放在下方：

```xml
<Panel>
    <!-- UI to be blocked by the dialog mask -->
    <Your_UI_Elements_To_Be_Blocked />
    
    <!-- OverlayDialogHost covers the content above -->
    <OverlayDialogHost />
</Panel>
```

> ℹ Unlike some libraries where overlay content goes *inside* the host, Ursa
> requires blocked content to be placed *above* the host.

> ℹ 与某些库中将浮层内容放入宿主*内部*不同，Ursa 要求被遮挡的内容放在宿主*上方*。

## Built-in Host in UrsaWindow / UrsaWindow 内置宿主

`UrsaWindow` includes a built-in `OverlayDialogHost` with `HostId = null`. If
your application uses `UrsaWindow` and the virtual dialog should cover the
entire window, the built-in host is sufficient — no extra placement needed.

`UrsaWindow` 内置了一个 `HostId = null` 的 `OverlayDialogHost`。如果程序已使用
`UrsaWindow` 且虚拟对话框需要覆盖整个窗体，内置宿主即可满足需求，无需额外放置。

## HostId / 宿主标识

Ursa allows multiple `OverlayDialogHost` instances in one visual tree. Use `HostId`
to identify and target a specific host when opening dialogs.

Ursa 允许一个可视树中存在多个 `OverlayDialogHost` 实例。使用 `HostId` 在打开
对话框时标识和定位特定宿主。

| Rule / 规则 | Description / 说明 |
| --- | --- |
| **Per-window uniqueness / 窗体内唯一** | Each `OverlayDialogHost` within a single window must have a different `HostId`. / 同一窗体内的各 `OverlayDialogHost` 必须有不同的 `HostId`。 |
| **Cross-window / 跨窗体** | Different windows may have hosts with the same `HostId`. / 不同窗体的宿主可以有相同的 `HostId`。 |
| **Null HostId** | Only one host can have `HostId = null`. `UrsaWindow`'s built-in host already occupies `null`. Any additional hosts **must** use a non-null `HostId`. / 只能有一个宿主的 `HostId = null`。`UrsaWindow` 内置宿主已占用该值。额外添加的宿主**必须**使用非 null 的 `HostId`。 |
| **Immutable / 不可变** | `HostId` cannot be changed after the host enters the visual tree. / `HostId` 加入视觉树后不可修改。 |

```xml
<Panel>
    <OverlayDialogHost HostId="sidebar-drawer" />
</Panel>
```

## Opening Virtual Dialogs / 打开虚拟对话框

Ursa's virtual dialog APIs (`OverlayDialog`, `MessageBox`, `Drawer`) are called
via static methods. No instance construction needed — call from anywhere
(View or ViewModel).

Ursa 的虚拟对话框 API（`OverlayDialog`、`MessageBox`、`Drawer`）通过静态方法调用。
无需构造实例，可在任何位置（View 或 ViewModel 中）直接调用。

```csharp
// Pass HostId to target a specific OverlayDialogHost
await OverlayDialog.ShowCustom<V, VM>(new VM(), dialogHostId, options);
```

### Host Lookup Rules / 宿主查找规则

| Scenario / 场景 | Behavior / 行为 |
| --- | --- |
| No `hostId` specified / 未指定 hostId | Finds the host with `HostId = null` (default). / 查找 `HostId = null` 的宿主（默认）。 |
| Explicit `hostId` / 显式指定 hostId | Finds the host with the matching `HostId` in the current window. / 在当前窗体中查找匹配 `HostId` 的宿主。 |
| Same `HostId` across multiple windows / 多窗体的相同 HostId | Also specify `TopLevelHashCode` in `options` to select the correct window instance. Without it, the first registered host is used. / 在 `options` 中同时指定 `TopLevelHashCode` 选择正确的窗体实例。不指定时默认使用第一个注册的宿主。 |
| No matching host found / 未找到匹配宿主 | The dialog silently does not open — **no exception is thrown**. / 对话框静默不打开 — **不抛出异常**。 |

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `HostId` | `string?` | Identifier for this host. Use when opening dialogs to target a specific host. / 此宿主的标识符。打开对话框时指定以定位特定宿主。 |

## FAQ / 常见问题

**Q: When do I need to add my own OverlayDialogHost? / 什么情况下需要自己添加 OverlayDialogHost？**

A: You need your own `OverlayDialogHost` with a non-null `HostId` when:
- The dialog should only cover a portion of the window (not the whole window).
- You're using a plain `Window` instead of `UrsaWindow`.

需要在以下情况下添加自己的带非 null `HostId` 的 `OverlayDialogHost`：
- 对话框只需要覆盖窗口的一部分（而非整个窗口）。
- 使用了普通 `Window` 而非 `UrsaWindow`。

**Q: Why doesn't my dialog appear? / 为什么我的对话框不显示？**

A: Check three things:
1. Is an `OverlayDialogHost` with the matching `HostId` present?
2. If using `UrsaWindow` + extra hosts, is the extra `HostId` non-null?
3. If multiple windows share the same `HostId`, is `TopLevelHashCode` specified in options?

检查三点：
1. 是否存在匹配 `HostId` 的 `OverlayDialogHost`？
2. 如果使用 `UrsaWindow` + 额外宿主，额外宿主的 `HostId` 是否非 null？
3. 如果多窗体共享相同 `HostId`，是否在 options 中指定了 `TopLevelHashCode`？
