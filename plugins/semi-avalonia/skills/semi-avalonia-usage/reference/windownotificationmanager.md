---
category: Components
title: WindowNotificationManager
subtitle: 窗口通知管理器
description: 窗口通知管理器用于管理应用窗口中的通知卡片队列和显示。
---

# WindowNotificationManager / 窗口通知管理器

Manages a queue of `NotificationCard` instances displayed in a `Window`. Handles stacking, animation, and auto-dismiss. Inherits from `TemplatedControl`.

管理在 `Window` 中显示的 `NotificationCard` 实例队列。处理堆叠、动画和自动关闭。继承自 `TemplatedControl`。

## When to Use / 何时使用

Use `WindowNotificationManager` when you need a managed notification system. Attach it to a `Window` and call `Show()` with `NotificationCard` instances.

需要托管通知系统时使用。附加到 `Window` 上，使用 `NotificationCard` 实例调用 `Show()`。

## Basic Usage / 基本使用

```xml
<Window>
    <WindowNotificationManager Name="notifier" />
    <!-- window content -->
</Window>
```

```csharp
notifier.Show(new NotificationCard
{
    Title = "Saved",
    Content = "Changes saved successfully",
    Severity = NotificationSeverity.Success
});
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Position` | `NotificationPosition` | `Top`, `Bottom`, `TopRight`, etc. |
| `MaxNotifications` | `int` | Maximum visible notifications. / 最大可见通知数。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How to use across pages? / 如何在页面间使用？**

A: Register `WindowNotificationManager` in the root `Window` and pass it via DI or a static reference. All pages share the same manager. / 在根 `Window` 中注册，通过 DI 或静态引用传递。所有页面共享同一个管理器。