---
category: Components
title: NotificationCard
subtitle: 通知卡片
description: 通知卡片用于显示应用内的消息通知，支持自动关闭和操作按钮。
---

# NotificationCard / 通知卡片

A card-style notification control for in-app messages — success alerts, warnings, errors, info banners. Supports auto-dismiss, action buttons, and custom content. Inherits from `ContentControl`.

用于应用内消息的卡片式通知控件——成功提示、警告、错误、信息横幅。支持自动关闭、操作按钮和自定义内容。继承自 `ContentControl`。

## When to Use / 何时使用

Use `NotificationCard` for transient in-app notifications. For system-level toasts, use platform notification APIs. For modal dialogs, use `Window` or `TaskDialog`.

用于短暂的应用内通知。系统级 toast 用平台通知 API。模态对话框用 `Window`。

## Basic Usage / 基本使用

```xml
<NotificationCard Title="Success"
                  Content="File saved successfully"
                  Severity="Success"
                  IsClosable="True" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Title` | `string?` | Notification title. / 通知标题。 |
| `Content` | `object?` | Message body. / 消息正文。 |
| `Severity` | `NotificationSeverity` | `Info`, `Success`, `Warning`, `Error`. |
| `IsClosable` | `bool` | Show close button. / 显示关闭按钮。 |
| `DisplayDuration` | `TimeSpan` | Auto-dismiss time (0 = manual). / 自动关闭时间。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How to show multiple notifications? / 如何显示多个通知？**

A: Use `WindowNotificationManager` to manage a notification stack. Individual `NotificationCard` instances are queued and displayed sequentially. / 使用 `WindowNotificationManager` 管理通知栈。单个 `NotificationCard` 实例排队显示。