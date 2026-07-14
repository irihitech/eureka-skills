---
category: Components
title: Toast
subtitle: 轻提示
description: >
  A lightweight notification popup that appears temporarily and auto-dismisses.
  Supports Information, Success, Warning, and Error types with configurable
  icons, close button, expiration time, click callback, and Light style variant.
  Managed via WindowToastManager or the IToastManager interface.
  临时出现并自动消失的轻量级通知弹出框。支持信息、成功、警告和错误类型，可配置
  图标、关闭按钮、过期时间、点击回调和 Light 样式变体。通过 WindowToastManager
  或 IToastManager 接口进行管理。
---

# Toast / 轻提示

## When to Use / 何时使用

Use `Toast` for brief, non-blocking feedback messages: operation success,
warnings, errors, or informational notices. Toasts appear at the top-center of
the window and auto-dismiss after a configurable duration. For persistent
notifications that stack and require manual dismissal, use `Notification`
instead.

使用 `Toast` 显示简短、非阻塞的反馈消息：操作成功、警告、错误或信息提示。
Toast 出现在窗口顶部居中位置，并在可配置的持续时间后自动消失。需要堆叠显示且
手动关闭的持久通知请使用 `Notification`。

## Basic Usage / 基本使用

### Setup / 设置

Add a `WindowToastManager` to your window or top-level control:

```xml
<Window xmlns:u="https://irihi.tech/ursa">
    <Panel>
        <u:WindowToastManager Name="ToastManager" />
        <!-- your content -->
    </Panel>
</Window>
```

Or install it programmatically:

```csharp
var manager = new WindowToastManager(TopLevel.GetTopLevel(this));
```

### Show a Toast / 显示轻提示

```csharp
using Ursa.Controls;
using Avalonia.Controls.Notifications;

// Simple string toast
ToastManager.Show(new Toast("Operation completed."));

// Typed toast with icon
ToastManager.Show(new Toast(
    "File saved successfully.",
    NotificationType.Success));

// Warning toast
ToastManager.Show(new Toast(
    "Unsaved changes will be lost.",
    NotificationType.Warning));

// Error toast
ToastManager.Show(new Toast(
    "Failed to connect to server.",
    NotificationType.Error));
```

### Toast with Configured Options / 带配置选项的轻提示

```csharp
var toast = new Toast(
    content: "Item deleted.",
    type: NotificationType.Success,
    expiration: TimeSpan.FromSeconds(5),  // auto-close after 5s
    showClose: true,                      // show X button
    onClick: () => Console.WriteLine("Toast clicked!"),
    onClose: reason => Console.WriteLine($"Closed: {reason}")
);

ToastManager.Show(toast);
```

### Using IToastManager / 通过接口使用

```csharp
// For DI / testability
IToastManager manager = new WindowToastManager(topLevel);
manager.Show(new Toast("Hello from interface!"));
manager.CloseAll();
```

## Common Scenarios / 常用场景

### Notification Types / 通知类型

| `NotificationType` | Icon | Style Pseudo-class | Use Case / 使用场景 |
|---|---|---|---|
| `Information` | ℹ | `:information` | General info / 一般信息 |
| `Success` | ✓ | `:success` | Operation succeeded / 操作成功 |
| `Warning` | ⚠ | `:warning` | Caution / 注意事项 |
| `Error` | ✗ | `:error` | Failure / 操作失败 |

### Light Style Variant / Light 样式变体

Add the `Light` class for a lighter, border-accented appearance:

```csharp
var lightToast = new Toast("Light style message", NotificationType.Success);
// Show with Light class
ToastManager.Show("Light message", NotificationType.Success, classes: new[] { "Light" });
```

Each notification type has its own Light variant resource keys (see Styling).

### Persist Toast (No Auto-Dismiss) / 持久化轻提示

Set `expiration` to `TimeSpan.Zero`:

```csharp
var persistent = new Toast(
    "Click to dismiss",
    expiration: TimeSpan.Zero);
ToastManager.Show(persistent);
```

### Click Callback / 点击回调

```csharp
var t = new Toast(
    "New update available!",
    NotificationType.Information,
    onClick: () => { /* navigate to update page */ });
ToastManager.Show(t);
```

### Close Callback / 关闭回调

```csharp
var t = new Toast(
    "Processing...",
    onClose: reason =>
    {
        if (reason == MessageCloseReason.Timeout)
            Console.WriteLine("Timed out");
        else if (reason == MessageCloseReason.User)
            Console.WriteLine("User closed");
    });
ToastManager.Show(t);
```

### Close Specific Toasts / 关闭特定轻提示

```csharp
IToast toast = new Toast("Loading...", expiration: TimeSpan.Zero);
manager.Show(toast);
// later:
manager.Close(toast);
```

### Maximum Visible Toasts / 最大可见数量

When the number of visible toasts exceeds `WindowToastManager.MaxItems` (default
from base `WindowMessageManager`), the oldest non-closing toast is displaced
(closed with `MessageCloseReason.Displaced`).

当可见 Toast 数量超过 `WindowToastManager.MaxItems` 时，最早的非关闭中 Toast
会被替换（以 `MessageCloseReason.Displaced` 关闭）。

## Property Reference / 属性参考

### Toast Class / Toast 类

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `Content` | `string?` | `null` | The toast message text. / 轻提示消息文本。 |
| `Type` | `NotificationType` | `Information` | Toast type (controls icon and color). / 通知类型（控制图标和颜色）。 |
| `ShowIcon` | `bool` | `false` | Whether to show the type icon. / 是否显示类型图标。 |
| `ShowClose` | `bool` | `true` | Whether to show the close (X) button. / 是否显示关闭（X）按钮。 |
| `Expiration` | `TimeSpan` | `3s` | Auto-dismiss delay. `TimeSpan.Zero` persists until manual close. / 自动消失延迟。`TimeSpan.Zero` 表示持久显示。 |
| `OnClick` | `Action?` | `null` | Callback when the toast is clicked. / 点击 Toast 时的回调。 |
| `OnClose` | `Action<MessageCloseReason>?` | `null` | Callback when the toast closes, with reason. / Toast 关闭时的回调，携带关闭原因。 |

### ToastCard Class / ToastCard 类

| Property / 属性 | Type / 类型 | Description / 说明 |
|---|---|---|
| `Content` | `object` | Toast content (string or Toast object). / Toast 内容（字符串或 Toast 对象）。 |
| `NotificationType` | `NotificationType` | Controls icon and pseudo-class. / 控制图标和伪类。 |
| `ShowIcon` | `bool` | Icon visibility. / 图标可见性。 |
| `ShowClose` | `bool` | Close button visibility. / 关闭按钮可见性。 |
| `IsClosing` | `bool` | Read-only; true during close animation. / 只读；关闭动画期间为 true。 |
| `IsClosed` | `bool` | Read-only; true after close animation completes. / 只读；关闭动画完成后为 true。 |

### WindowToastManager Methods / 方法

| Method / 方法 | Description / 说明 |
|---|---|
| `Show(IToast)` | Show a toast from an `IToast` instance. / 显示 `IToast` 实例。 |
| `Show(object, NotificationType, TimeSpan?, bool, bool, Action?, Action<MessageCloseReason>?, string[]?)` | Show with full parameter control. / 通过完整参数控制显示。 |
| `Close(IToast)` | Close a specific toast. / 关闭特定 Toast。 |
| `CloseAll()` | Close all visible toasts. / 关闭所有可见 Toast。 |
| `TryGetToastManager(Visual?, out WindowToastManager?)` | Discover an existing manager in the visual tree. / 在可视树中查找已有的管理器。 |

### IToast Interface / IToast 接口

| Member | Type | Description / 说明 |
|---|---|---|
| `Content` | `string?` | Toast message. / 消息文本。 |

### IToastManager Interface / IToastManager 接口

| Method / 方法 | Description / 说明 |
|---|---|
| `Show(IToast)` | Display a toast. / 显示 Toast。 |
| `Close(IToast)` | Close a specific toast. / 关闭特定 Toast。 |
| `CloseAll()` | Close all toasts. / 关闭所有 Toast。 |

### MessageCloseReason Enum / 关闭原因枚举

| Value | Description / 说明 |
|---|---|
| `Timeout` | Expiration time elapsed. / 过期时间到达。 |
| `User` | User clicked the close button. / 用户点击了关闭按钮。 |
| `Displaced` | Replaced by a newer toast (max items exceeded). / 被更新的 Toast 替换（超出最大数量）。 |

## Events / 事件

| Event / 事件 | Type / 类型 | Description / 说明 |
|---|---|---|
| `ToastCard.MessageClosed` | `EventHandler<MessageClosedEventArgs>` | Fired when the toast card closes. / Toast 卡片关闭时触发。 |
| `ToastCard.PointerPressed` | — | Inherited; used internally for `OnClick`. / 继承；内部用于 `OnClick`。 |
| `Toast.PropertyChanged` | `PropertyChangedEventHandler` | Raised when `Content` changes. / `Content` 变更时触发。 |

## Styling & Templating / 样式与模板

### ControlTheme Keys

| Theme Key | Target Type | Description / 说明 |
|---|---|---|
| `{x:Type u:WindowToastManager}` | `WindowToastManager` | Manager container theme. / 管理器容器主题。 |
| `{x:Type u:ToastCard}` | `ToastCard` | Toast card theme. / Toast 卡片主题。 |

### Theme Resources / 主题资源

| Resource Key | Applies To | Description / 说明 |
|---|---|---|
| `ToastCardBackground` | Border | Default background. / 默认背景。 |
| `ToastCardBorderThickness` | Border | Border thickness. / 边框粗细。 |
| `ToastCardCornerRadius` | Border | Corner radius. / 圆角半径。 |
| `ToastCardMargin` | Border | Outer margin. / 外边距。 |
| `ToastCardMinHeight` | Border | Minimum height. / 最小高度。 |
| `ToastCardPadding` | Border | Inner padding. / 内边距。 |
| `ToastCardIconMargin` | Icon | Icon margin. / 图标外边距。 |
| `NotificationCardBoxShadows` | Border | Box shadow. / 盒阴影。 |
| `NotificationCardInformationIconForeground` | Icon | Information icon color. / 信息图标颜色。 |
| `NotificationCardInformationIconPathData` | Icon | Information icon path. / 信息图标路径。 |
| `NotificationCardSuccessIconForeground` | Icon | Success icon color. / 成功图标颜色。 |
| `NotificationCardSuccessIconPathData` | Icon | Success icon path. / 成功图标路径。 |
| `NotificationCardWarningIconForeground` | Icon | Warning icon color. / 警告图标颜色。 |
| `NotificationCardWarningIconPathData` | Icon | Warning icon path. / 警告图标路径。 |
| `NotificationCardErrorIconForeground` | Icon | Error icon color. / 错误图标颜色。 |
| `NotificationCardErrorIconPathData` | Icon | Error icon path. / 错误图标路径。 |
| `NotificationCardLightBackground` | Control | Light variant outer background. / Light 变体外部背景。 |
| `NotificationCardLightInformationBorderBrush` | Border | Light info border. / Light 信息边框。 |
| `NotificationCardLightInformationBackground` | Border | Light info background. / Light 信息背景。 |
| `NotificationCardLightSuccessBorderBrush` | Border | Light success border. / Light 成功边框。 |
| `NotificationCardLightSuccessBackground` | Border | Light success background. / Light 成功背景。 |
| `NotificationCardLightWarningBorderBrush` | Border | Light warning border. / Light 警告边框。 |
| `NotificationCardLightWarningBackground` | Border | Light warning background. / Light 警告背景。 |
| `NotificationCardLightErrorBorderBrush` | Border | Light error border. / Light 错误边框。 |
| `NotificationCardLightErrorBackground` | Border | Light error background. / Light 错误背景。 |

### Template Parts / 模板部件

| Part Name / 部件 | Type / 类型 | Description / 说明 |
|---|---|---|
| `PART_LayoutTransformControl` | `LayoutTransformControl` | Wrapper for enter/exit animations. / 进入/退出动画包装器。 |
| `PART_RootBorder` | `Border` | Root border container. / 根边框容器。 |
| `PART_Items` (WindowToastManager) | `ReversibleStackPanel` | Items panel. / 项目面板。 |

### Pseudo-classes / 伪类

| Pseudo-class | Applies To | Description / 说明 |
|---|---|---|
| `:information` | `ToastCard` | Set when `NotificationType` is `Information`. |
| `:success` | `ToastCard` | Set when `NotificationType` is `Success`. |
| `:warning` | `ToastCard` | Set when `NotificationType` is `Warning`. |
| `:error` | `ToastCard` | Set when `NotificationType` is `Error`. |
| `[IsClosing=true]` | `ToastCard` | During close animation (opacity + translate + scale). / 关闭动画期间。 |
| `[IsClosed=true]` | `ToastCard` | After close animation completes. / 关闭动画完成后。 |

### Style Classes / 样式类

| Class | Description / 说明 |
|---|---|
| `Light` | Light variant with softer background and colored border per notification type. / 浅色变体，每种通知类型有不同的浅色背景和彩色边框。 |

### Enter/Exit Animations / 进入/退出动画

Toasts animate in with opacity (0→1) and translate Y (−100→0) over 0.3s
with `QuadraticEaseOut`. Close animation reverses (opacity →0, translate Y→−100,
scale Y→0) over 0.3s + 0.15s.

Toast 以透明度（0→1）和平移 Y（−100→0）在 0.3 秒内使用 `QuadraticEaseOut` 动画
进入。关闭动画反转（透明度 →0，平移 Y→−100，缩放 Y→0），持续 0.3 + 0.15 秒。

## FAQ / 常见问题

**Q: What's the difference between Toast and Notification?**
A: `Toast` is transient — it appears briefly and auto-dismisses (typically 3s).
`Notification` is persistent — it stacks in a list and requires manual dismissal.
Use `Toast` for lightweight feedback; use `Notification` for important messages
that the user must acknowledge.

**Q: Toast 和 Notification 有什么区别？**
A: `Toast` 是瞬态的——短暂出现后自动消失（通常 3 秒）。`Notification` 是持久的——
堆叠在列表中并需要手动关闭。轻量级反馈使用 `Toast`；用户必须确认的重要消息使用
`Notification`。

**Q: How do I show a toast without the icon? / 如何显示不带图标的轻提示？**
A: Set `ShowIcon = false` on the `Toast` instance (this is the default):
```csharp
new Toast("message", showIcon: false)
```

**Q: Can I customize the toast duration? / 可以自定义显示时长吗？**
A: Yes, pass a `TimeSpan` as the `expiration` parameter. Default is 3 seconds.
Use `TimeSpan.Zero` for persistent toasts.

**Q: Where do toasts appear? / Toast 出现在哪里？**
A: Toasts appear at the top-center of the window. The `WindowToastManager`
template uses a `ReversibleStackPanel` with `VerticalAlignment="Top"` and
`HorizontalAlignment="Center"`.

**Q: Can I use Toast without a WindowToastManager? / 可以不用 WindowToastManager 使用 Toast 吗？**
A: No — a `WindowToastManager` (or any `IToastManager` implementation) must
be in the visual tree to host `ToastCard` instances. Use
`TryGetToastManager` to discover an existing one, or add one to your view.

**Q: How do I control the maximum number of visible toasts? / 如何控制最大可见 Toast 数量？**
A: Set `MaxItems` on the `WindowToastManager` instance (inherited from
`WindowMessageManager`). When exceeded, the oldest non-closing toast is displaced.
