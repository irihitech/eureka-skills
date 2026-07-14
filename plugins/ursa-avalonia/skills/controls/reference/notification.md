---
category: Feedback
title: Notification
subtitle: 通知
description: >
  In-window notification manager that displays toast-like messages at
  configurable screen positions. Supports Information, Success, Warning, and
  Error types with automatic expiration and slide-in animations.
  窗口内通知管理器，在可配置的屏幕位置显示类 Toast 消息。支持信息、成功、警告和
  错误类型，具有自动过期和滑入动画。
---

# Notification / 通知

## When to Use / 何时使用

Use `WindowNotificationManager` for non-blocking, transient feedback messages
that appear at the edge of a window and auto-dismiss. Ideal for operation
results, status updates, and lightweight alerts.

使用 `WindowNotificationManager` 显示非阻塞的、临时的反馈消息，出现在窗口边缘并
自动消失。适用于操作结果、状态更新和轻量级提醒。

Do NOT use notifications for blocking confirmations — use `MessageBox` instead.

不要用通知做阻塞式确认——使用 `MessageBox`。

## Basic Usage / 基本使用

### Setup the manager in your Window / 在窗口中设置管理器

```xml
<Window ...>
    <Panel>
        <!-- Your content -->
        <u:WindowNotificationManager Name="Notifier"
                                      Position="TopRight" />
    </Panel>
</Window>
```

### Show a notification from code-behind or view-model

```csharp
// Simple string notification
Notifier.Show("Item saved successfully.", NotificationType.Success);

// Full-control notification object
Notifier.Show(new Notification(
    "Save Complete",
    "The document has been saved to the cloud.",
    NotificationType.Success,
    expiration: TimeSpan.FromSeconds(5),
    showClose: true,
    onClick: () => Console.WriteLine("Clicked"),
    onClose: reason => Console.WriteLine($"Closed: {reason}")));
```

### Using INotificationManager via DI / 通过依赖注入使用

```csharp
public class MyViewModel
{
    private readonly INotificationManager _notifier;
    
    public MyViewModel(INotificationManager notifier)
    {
        _notifier = notifier;
    }
    
    public async Task SaveAsync()
    {
        await _service.SaveAsync();
        _notifier.Show(new Notification("Success", "Data saved."));
    }
}
```

## Common Scenarios / 常用场景

### 1. Different positions / 不同位置

```xml
<u:WindowNotificationManager Position="TopRight" />   <!-- default -->
<u:WindowNotificationManager Position="TopLeft" />
<u:WindowNotificationManager Position="TopCenter" />
<u:WindowNotificationManager Position="BottomRight" />
<u:WindowNotificationManager Position="BottomLeft" />
<u:WindowNotificationManager Position="BottomCenter" />
```

### 2. Notification with click action / 带点击操作的通知

```csharp
_notifier.Show(new Notification(
    "New Message",
    "You have a new message from Alice.",
    NotificationType.Information,
    onClick: () => _navigation.NavigateTo("/messages"),
    expiration: TimeSpan.Zero  // stays until manual close
));
```

### 3. Persistent notification / 持久通知

Set `expiration` to `TimeSpan.Zero` — the notification stays until the user
closes it or you call `Close()`.

```csharp
_notifier.Show(new Notification(
    "Update Available",
    "Version 2.0 is ready to install.",
    NotificationType.Warning,
    expiration: TimeSpan.Zero));
```

### 4. Close notifications programmatically / 编程关闭

```csharp
// Close a specific notification
_notifier.Close(someNotification);

// Close all
_notifier.CloseAll();
```

## Property Reference / 属性参考

### WindowNotificationManager

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Position` | `NotificationPosition` | `TopRight` | Corner/side for notifications / 通知显示位置 |
| `MaxItems` | `int` | (inherited) | Maximum visible notifications / 最大可见通知数 |

### NotificationPosition Enum / 位置枚举

| Value | Location / 位置 |
|---|---|
| `TopLeft` | 左上 |
| `TopRight` | 右上（默认） |
| `TopCenter` | 顶部居中 |
| `BottomLeft` | 左下 |
| `BottomRight` | 右下 |
| `BottomCenter` | 底部居中 |

### Notification (the message object) / 通知消息对象

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Title` | `string?` | `null` | Bold title line / 粗体标题行 |
| `Content` | `string?` | `null` | Body text / 正文 |
| `Type` | `NotificationType` | `Information` | Visual style / 视觉样式 |
| `Expiration` | `TimeSpan` | 3s | Auto-close delay (`Zero` = persistent) / 自动关闭延迟 |
| `ShowIcon` | `bool` | `false` | Show type icon / 显示类型图标 |
| `ShowClose` | `bool` | `true` | Show close button / 显示关闭按钮 |
| `OnClick` | `Action?` | `null` | Callback on card click / 点击卡片回调 |
| `OnClose` | `Action<MessageCloseReason>?` | `null` | Callback on close / 关闭回调 |

### NotificationType Enum / 类型枚举

| Value | Icon & Color |
|---|---|
| `Information` | ℹ Blue / 蓝色 |
| `Success` | ✓ Green / 绿色 |
| `Warning` | ⚠ Orange / 橙色 |
| `Error` | ✗ Red / 红色 |

## Events / 事件

`NotificationCard` has a `MessageClosed` event (used internally). The primary
interaction is via `OnClick` and `OnClose` callbacks on the `Notification`
object.

主要通过 `Notification` 对象的 `OnClick` 和 `OnClose` 回调进行交互。

## Styling & Templating / 样式与模板

### Pseudo-classes / 伪类

#### WindowNotificationManager

| Pseudo-class | Condition |
|---|---|
| `:topleft` | `Position == TopLeft` |
| `:topright` | `Position == TopRight` |
| `:topcenter` | `Position == TopCenter` |
| `:bottomleft` | `Position == BottomLeft` |
| `:bottomright` | `Position == BottomRight` |
| `:bottomcenter` | `Position == BottomCenter` |

#### NotificationCard

Same six position pseudo-classes as `WindowNotificationManager`.

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `NotificationCardBorderThickness` | `NotificationCard` | Card border thickness |
| `NotificationCardInfoBackground` | Card (Info) | Info card background |
| `NotificationCardSuccessBackground` | Card (Success) | Success card background |
| `NotificationCardWarningBackground` | Card (Warning) | Warning card background |
| `NotificationCardErrorBackground` | Card (Error) | Error card background |

### Animations / 动画

`NotificationCard` includes built-in entrance animations:
- Fade-in + scaleY (300ms) for all positions
- Slide from left (TopLeft/`topleft`) or right (TopRight/`topright`) with
  easing

`NotificationCard` 内置入场动画：所有位置均有淡入+缩放效果；左右位置有滑入效果。

## FAQ / 常见问题

**Q: How is this different from Toast? / 这和 Toast 有什么区别？**
A: `Notification` is for in-window messages tied to a specific window.
`Toast` (under development) targets OS-level notifications. Use `Notification`
for app-internal feedback.

**Q: How many notifications can show at once? / 一次能显示多少条通知？**
A: Controlled by the inherited `MaxItems` property from `WindowMessageManager`.
Excess notifications displace older ones.

**Q: Can I style individual notifications? / 能单独设置通知样式吗？**
A: Pass a `classes` array to `WindowNotificationManager.Show(...)`. Style
classes are added to the `NotificationCard`:

```csharp
Notifier.Show("Message", NotificationType.Information, classes: ["Light"]);
```
