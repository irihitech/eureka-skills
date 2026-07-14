---
category: Components
title: WindowNotificationManager
subtitle: 窗口通知管理器
description: 在窗口内以可配置位置显示通知卡片（如成功、错误、警告消息）的控件。
---

# WindowNotificationManager / 窗口通知管理器

A control that displays notification cards within a `Window` at configurable positions: top-left, top-right, top-center, bottom-left, bottom-right, or bottom-center. `WindowNotificationManager` uses a `ReversibleStackPanel` to stack notifications, with optional reverse ordering for bottom positions (newest at bottom). It is designed for transient, non-blocking user messages — success confirmations, error alerts, warning notices, or informational toasts.

在 `Window` 内以可配置位置显示通知卡片的控件：左上、右上、上中、左下、右下或下中。`WindowNotificationManager` 使用 `ReversibleStackPanel` 堆叠通知，底部位置可选择反向排序（最新在底部）。它设计用于临时的、非阻塞的用户消息 —— 成功确认、错误提醒、警告通知或信息提示。

## When to Use / 何时使用

Use `WindowNotificationManager` when you need to show transient, non-modal notification messages within a window — similar to toast notifications. It is ideal for operation feedback (save success, network error), status updates, and non-critical alerts. For modal dialogs that require user acknowledgment, use `Window.ShowDialog`. For permanent status indicators, use a status bar.

当你需要在窗口内显示临时的、非模态的通知消息时使用 `WindowNotificationManager` —— 类似于 toast 通知。它非常适用于操作反馈（保存成功、网络错误）、状态更新和非关键警报。需要用户确认的模态对话框使用 `Window.ShowDialog`。永久状态指示器使用状态栏。

## Basic Usage / 基本使用

```xml
<Window xmlns="https://github.com/avaloniaui">
    <Panel>
        <!-- Main content -->
        <DockPanel>
            <Button Content="Show Notification"
                    Command="{Binding ShowNotificationCommand}" />
        </DockPanel>

        <!-- Notification manager overlaid on top of content -->
        <WindowNotificationManager x:Name="NotificationManager"
                                   Classes="topright" />
    </Panel>
</Window>
```

```csharp
// Show a success notification
NotificationManager.Show(new NotificationCard
{
    Title = "Success",
    Content = "File saved successfully.",
    Severity = NotificationSeverity.Success
});

// Show an error notification
NotificationManager.Show(new NotificationCard
{
    Title = "Error",
    Content = "Failed to connect to server.",
    Severity = NotificationSeverity.Error
});

// Show with auto-dismiss after 3 seconds
var card = new NotificationCard
{
    Title = "Info",
    Content = "Operation completed.",
    Severity = NotificationSeverity.Information
};
NotificationManager.Show(card, TimeSpan.FromSeconds(3));
```

## Common Scenarios / 常用场景

### Positioned Notifications / 定位通知

Use Semi pseudo-classes to position the notification stack.

```xml
<!-- Top-right (most common) -->
<WindowNotificationManager Classes="topright" />

<!-- Bottom-center with reverse stacking -->
<WindowNotificationManager Classes="bottomcenter" />

<!-- Multiple managers for different positions -->
<WindowNotificationManager x:Name="TopRightNotifications" Classes="topright" />
<WindowNotificationManager x:Name="BottomLeftNotifications" Classes="bottomleft" />
```

### Multiple Severities / 多种严重程度

```csharp
// Success notification
manager.Show(new NotificationCard
{
    Title = "Saved",
    Content = "Document has been saved.",
    Severity = NotificationSeverity.Success
});

// Warning notification
manager.Show(new NotificationCard
{
    Title = "Low Disk Space",
    Content = "Less than 500 MB remaining.",
    Severity = NotificationSeverity.Warning
});

// Error notification
manager.Show(new NotificationCard
{
    Title = "Upload Failed",
    Content = "The server returned an error. Please try again.",
    Severity = NotificationSeverity.Error
});

// Informational notification
manager.Show(new NotificationCard
{
    Title = "Update Available",
    Content = "Version 2.0 is ready to install.",
    Severity = NotificationSeverity.Information
});
```

### MVVM Integration / MVVM 集成

Expose notification logic from a ViewModel via a service.

```csharp
public class NotificationService
{
    private readonly WindowNotificationManager _manager;

    public NotificationService(WindowNotificationManager manager)
    {
        _manager = manager;
    }

    public void ShowSuccess(string title, string content)
    {
        _manager.Show(new NotificationCard
        {
            Title = title,
            Content = content,
            Severity = NotificationSeverity.Success
        });
    }

    public void ShowError(string title, string content)
    {
        _manager.Show(new NotificationCard
        {
            Title = title,
            Content = content,
            Severity = NotificationSeverity.Error
        });
    }
}
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Items` | `IList<NotificationCard>` | The collection of currently displayed notification cards. / 当前显示的通知卡片集合。 |
| `MaxItems` | `int` | Maximum number of visible notifications; older ones are removed when exceeded. / 最大可见通知数；超出时移除较早的通知。 |

### NotificationCard Properties / NotificationCard 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Title` | `string?` | The notification title (bold header). / 通知标题（粗体标题）。 |
| `Content` | `string?` | The notification body text. / 通知正文文本。 |
| `Severity` | `NotificationSeverity` | Visual style category: `Informational`, `Success`, `Warning`, or `Error`. / 视觉样式类别。 |
| `IsClosable` | `bool` | Whether the user can dismiss the notification (default `true`). / 用户是否可以关闭通知（默认 `true`）。 |

### Methods / 方法

| Method / 方法 | Description / 说明 |
| --- | --- |
| `Show(NotificationCard)` | Shows a notification card. The card stays until dismissed or removed. / 显示通知卡片。卡片保持显示直到被关闭或移除。 |
| `Show(NotificationCard, TimeSpan)` | Shows a notification card that auto-dismisses after the specified duration. / 显示通知卡片，在指定持续时间后自动关闭。 |
| `Dismiss(NotificationCard)` | Programmatically dismisses a specific notification. / 编程方式关闭特定通知。 |
| `DismissAll()` | Dismisses all currently displayed notifications. / 关闭所有当前显示的通知。 |

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlTheme / Semi.Avalonia 控件主题

Semi.Avalonia provides a `{x:Type WindowNotificationManager}` ControlTheme. The template consists of a `ReversibleStackPanel` named `PART_Items` that stacks notification cards vertically.

Semi.Avalonia 提供 `{x:Type WindowNotificationManager}` 的 ControlTheme。模板由一个名为 `PART_Items` 的 `ReversibleStackPanel` 组成，垂直堆叠通知卡片。

### Position Pseudo-classes / 位置伪类

Apply exactly one position pseudo-class to control where notifications appear and how they stack:

应用且仅应用一个位置伪类来控制通知出现的位置和堆叠方式：

| Pseudo-class / 伪类 | Alignment / 对齐 | Stack Order / 堆叠顺序 |
| --- | --- | --- |
| `:topleft` | Top-left / 左上 | Newest at top / 最新在顶部 |
| `:topright` | Top-right / 右上 | Newest at top / 最新在顶部 |
| `:topcenter` | Top-center / 上中 | Newest at top / 最新在顶部 |
| `:bottomleft` | Bottom-left / 左下 | **Reversed**: newest at bottom / **反向**：最新在底部 |
| `:bottomright` | Bottom-right / 右下 | **Reversed**: newest at bottom / **反向**：最新在底部 |
| `:bottomcenter` | Bottom-center / 下中 | **Reversed**: newest at bottom / **反向**：最新在底部 |

```xml
<!-- Top-right (default recommendation) -->
<WindowNotificationManager Classes="topright" />

<!-- Bottom-left with reverse stacking for chat-like notifications -->
<WindowNotificationManager Classes="bottomleft" />
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Items` | `ReversibleStackPanel` | Stacks notification cards vertically. Supports `ReverseOrder` for bottom-positioned notifications. / 垂直堆叠通知卡片。支持底部位置通知的 `ReverseOrder`。 |

### NotificationCard Styling / NotificationCard 样式

`NotificationCard` is styled by Semi.Avalonia's `NotificationCard.axaml` theme. Each severity level (`Success`, `Warning`, `Error`, `Information`) has distinct colors for background, border, icon, and text.

`NotificationCard` 由 Semi.Avalonia 的 `NotificationCard.axaml` 主题进行样式设置。每个严重程度级别（`Success`、`Warning`、`Error`、`Information`）具有不同的背景、边框、图标和文本颜色。

## FAQ / 常见问题

**Q: How do I position the notification manager? / 如何定位通知管理器？**

A: Add the `WindowNotificationManager` as the last child of a `Panel` (so it renders on top) and apply one of the position pseudo-classes: `topright`, `topleft`, `topcenter`, `bottomright`, `bottomleft`, or `bottomcenter`. Each pseudo-class sets the `VerticalAlignment` and `HorizontalAlignment` of the internal stack panel.

将 `WindowNotificationManager` 作为 `Panel` 的最后一个子元素（使其渲染在最上层），并应用以下位置伪类之一：`topright`、`topleft`、`topcenter`、`bottomright`、`bottomleft` 或 `bottomcenter`。每个伪类设置内部堆叠面板的 `VerticalAlignment` 和 `HorizontalAlignment`。

**Q: Can I show multiple notifications simultaneously? / 可以同时显示多个通知吗？**

A: Yes. Each call to `Show()` adds a new `NotificationCard` to the `Items` collection. Notifications stack vertically according to the position pseudo-class. Set `MaxItems` to limit the number of visible notifications; older ones are automatically removed when the limit is exceeded.

可以。每次调用 `Show()` 都会向 `Items` 集合添加一个新的 `NotificationCard`。通知根据位置伪类垂直堆叠。设置 `MaxItems` 限制可见通知数量；超出限制时，较早的通知会自动移除。

**Q: How do I auto-dismiss notifications? / 如何自动关闭通知？**

A: Use the `Show(NotificationCard, TimeSpan)` overload. After the specified duration, the notification is automatically removed. For manual control, keep a reference to the `NotificationCard` and call `Dismiss(card)` or call `DismissAll()` to clear all notifications.

使用 `Show(NotificationCard, TimeSpan)` 重载。在指定持续时间后，通知会自动移除。需要手动控制时，保留对 `NotificationCard` 的引用并调用 `Dismiss(card)`，或调用 `DismissAll()` 清除所有通知。

**Q: Can I use WindowNotificationManager outside a Window? / 可以在 Window 之外使用 WindowNotificationManager 吗？**

A: `WindowNotificationManager` is designed for use inside a `Window` (or `EmbeddableControlRoot`). It is typically placed in a `Panel` as an overlay. Technically it can be used in any `TopLevel`, but its positioning pseudo-classes assume it is the last child in a `Panel` that fills the entire window.

`WindowNotificationManager` 设计用于 `Window`（或 `EmbeddableControlRoot`）内部。通常作为覆盖层放置在 `Panel` 中。技术上可以在任何 `TopLevel` 中使用，但其定位伪类假设它是填充整个窗口的 `Panel` 中的最后一个子元素。
