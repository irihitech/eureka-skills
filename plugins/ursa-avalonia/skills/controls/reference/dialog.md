---
category: Components
title: Dialog
subtitle: 对话框
description: >
  Modal or modeless overlay dialogs with customizable content, standard button
  layouts, and both Window-based (desktop) and Overlay-based (cross-platform)
  hosting. Supports drag-move, resize, full-screen, light-dismiss, layering,
  and mode-driven icon styling.
  支持自定义内容的模态或非模态叠加对话框，提供标准按钮布局，并同时支持基于 Window
  （桌面端）和 Overlay（跨平台）两种承载方式。支持拖拽移动、调整大小、全屏、
  点击外部关闭、层级管理与模式驱动的图标样式。
---

# Dialog / 对话框

## When to Use / 何时使用

Use `Dialog` for custom modal or modeless overlays that go beyond simple MessageBox
prompts — forms, wizards, multi-step workflows, or any rich-content interaction.
Choose Window-based (`Dialog.ShowStandardAsync` / `Dialog.ShowCustomAsync`) for
classic desktop apps; choose Overlay-based (`OverlayDialog.ShowStandardAsync` /
`OverlayDialog.ShowCustomAsync`) for browser (WASM) support or in-window modals.

当需要超越简单 MessageBox 提示的自定义模态或非模态叠加层时使用 `Dialog`——如表单、
向导、多步骤工作流或任何富内容交互。经典桌面应用选择 Window 方式
（`Dialog.ShowStandardAsync` / `Dialog.ShowCustomAsync`）；浏览器（WASM）支持或
窗口内模态框选择 Overlay 方式（`OverlayDialog.ShowStandardAsync` /
`OverlayDialog.ShowCustomAsync`）。

## Basic Usage / 基本使用

### Window-based Standard Dialog

```csharp
using Ursa.Controls;

// Modal standard dialog with default buttons (OK/Cancel)
var result = await Dialog.ShowStandardAsync<MyView, MyViewModel>(
    new MyViewModel(),
    options: new DialogOptions
    {
        Title = "Settings",
        Button = DialogButton.OKCancel,
        Mode = DialogMode.Info
    });

if (result == DialogResult.OK)
{
    // Handle confirmation
}
```

### Window-based Custom Dialog (full control)

```csharp
// Custom dialog returning any result type
var userChoice = await Dialog.ShowCustomAsync<MyView, MyViewModel, string>(
    new MyViewModel(),
    options: new DialogOptions
    {
        Title = "Select Option",
        CanResize = true
    });
```

### Overlay-based Dialog

```csharp
// Must add OverlayDialogHost to your view first
// <u:OverlayDialogHost HostId="MainHost" />

// Standard overlay dialog
var result = await OverlayDialog.ShowStandardAsync<MyView, MyViewModel>(
    vm, hostId: "MainHost",
    options: new OverlayDialogOptions { FullScreen = false });

// Custom overlay dialog
await OverlayDialog.ShowCustomAsync<string>(
    vm, hostId: "MainHost");
```

### Non-modal / 非模态

Use the non-async overloads to show modeless dialogs:

```csharp
// Window — non-modal
Dialog.ShowCustom<MyView, MyViewModel>(vm);

// Overlay — non-modal
OverlayDialog.ShowStandard<MyView, MyViewModel>(vm, hostId: "MainHost");
```

## Common Scenarios / 常用场景

### Host Setup / 宿主设置

Overlay dialogs require an `OverlayDialogHost` in the visual tree:

```xml
<u:OverlayDialogHost HostId="MainHost" />
```

For Window-based dialogs no host is needed — a new OS window is created.

### Full-Screen Dialog / 全屏对话框

```csharp
var options = new OverlayDialogOptions { FullScreen = true };
OverlayDialog.ShowCustom<MyView, MyViewModel>(vm, hostId: "MainHost", options);
```

### Drag-Move via Title Area / 通过标题区域拖拽

Set `CanDragMove = true` (default) on dialog options. The title area
(`PART_TitleArea`) acts as a drag handle. Disable with `CanDragMove = false`.

### Light Dismiss / 点击外部关闭

```csharp
var options = new OverlayDialogOptions
{
    CanLightDismiss = true  // clicking the mask closes the dialog
};
```

### Dialog with Mode Icon / 带模式图标的对话框

`StandardDialogControl` and `StandardDialogWindow` support a `Mode` property
that shows a contextual icon in the header:

| Mode | Icon Style |
|---|---|
| `None` | No icon / 无图标 |
| `Info` | Information (blue) / 信息（蓝色） |
| `Warning` | Warning (orange) / 警告（橙色） |
| `Error` | Error (red) / 错误（红色） |
| `Question` | Question / 问号 |
| `Success` | Success (green) / 成功（绿色） |

### Layer Management (Overlay only) / 层级管理（仅 Overlay）

Non-modal overlay dialogs support a right-click context menu on the title area with:
- Bring Forward (`DialogLayerChangeType.BringForward`)
- Bring to Front (`DialogLayerChangeType.BringToFront`)
- Send Backward (`DialogLayerChangeType.SendBackward`)
- Send to Back (`DialogLayerChangeType.SendToBack`)

The `LayerChanged` routed event fires on layer changes.

### DialogOptions — Window / 对话框选项 — Window

```csharp
var options = new DialogOptions
{
    Title = "My Dialog",
    StartupLocation = WindowStartupLocation.CenterOwner,
    Position = new PixelPoint(100, 200), // when Manual
    Button = DialogButton.OKCancel,
    Mode = DialogMode.Info,
    IsCloseButtonVisible = true,
    ShowInTaskBar = true,
    CanDragMove = true,
    CanResize = false,
    StyleClass = "MyCustomClass",
    HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
};
```

### OverlayDialogOptions — Overlay 选项

```csharp
var options = new OverlayDialogOptions
{
    Title = "My Dialog",
    FullScreen = false,
    HorizontalAnchor = HorizontalPosition.Center,
    VerticalAnchor = VerticalPosition.Center,
    HorizontalOffset = 20,  // only when not Center
    VerticalOffset = 20,    // only when not Center
    Buttons = DialogButton.OKCancel,
    Mode = DialogMode.Warning,
    IsCloseButtonVisible = true,
    CanLightDismiss = false,
    CanDragMove = true,
    CanResize = false,
    TopLevelHashCode = null,
    StyleClass = "MyClass",
};
```

### IDialogContext Interface / IDialogContext 接口

When a ViewModel implements `IDialogContext`, the dialog's close button and
default close behavior delegate to the context:

```csharp
public class MyViewModel : IDialogContext
{
    public event EventHandler<object?>? RequestClose;

    public void Close() => RequestClose?.Invoke(this, DialogResult.OK);
    public void Close(object? result) => RequestClose?.Invoke(this, result);
}
```

## Property Reference / 属性参考

### DialogControlBase Properties / 基类属性

| Property / 属性 | Type / 类型 | Description / 说明 |
|---|---|---|
| `IsFullScreen` | `bool` | Whether the dialog fills the host area. / 对话框是否填充宿主区域。 |
| `CanResize` | `bool` | Whether the user can resize the dialog via the resizer. / 用户是否可通过调整手柄改变对话框大小。 |

### StandardDialogControl / StandardDialogWindow Properties

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `Title` | `string?` | `null` | Header title text. / 标题文本。 |
| `Buttons` | `DialogButton` | `OKCancel` | Button combination. / 按钮组合。 |
| `Mode` | `DialogMode` | `None` | Contextual icon mode. / 上下文图标模式。 |

### CustomDialogWindow Additional Properties / 额外属性

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `CanDragMove` | `bool` | `true` | Whether the title area initiates drag-move. / 标题区域是否可拖拽移动。 |
| `IsManagedResizerVisible` | `bool` | `false` | Whether the OS-managed resizer is visible. / 操作系统管理的调整手柄是否可见。 |

### DialogButton Enum / 按钮枚举

| Value | Buttons Shown / 显示的按钮 |
|---|---|
| `None` | No buttons / 无按钮 |
| `OK` | OK |
| `OKCancel` | OK, Cancel |
| `YesNo` | Yes, No |
| `YesNoCancel` | Yes, No, Cancel |

### DialogResult Enum / 结果枚举

| Value | Meaning / 含义 |
|---|---|
| `None` | No result / 无结果 |
| `OK` | OK / 确认 |
| `Cancel` | Cancel or close / 取消或关闭 |
| `Yes` | Yes / 是 |
| `No` | No / 否 |

### DialogMode Enum / 模式枚举

| Value | Icon | Description / 说明 |
|---|---|---|
| `None` | — | No icon / 无图标 |
| `Info` | ℹ | Information / 信息 |
| `Warning` | ⚠ | Warning / 警告 |
| `Error` | ✗ | Error / 错误 |
| `Question` | ? | Question / 问题 |
| `Success` | ✓ | Success / 成功 |

### HorizontalPosition Enum / 水平位置枚举

| Value | Description / 说明 |
|---|---|
| `Left` | Anchor to left / 锚定左侧 |
| `Center` | Anchor to center / 锚定居中 |
| `Right` | Anchor to right / 锚定右侧 |

### VerticalPosition Enum / 垂直位置枚举

| Value | Description / 说明 |
|---|---|
| `Top` | Anchor to top / 锚定顶部 |
| `Center` | Anchor to center / 锚定居中 |
| `Bottom` | Anchor to bottom / 锚定底部 |

### Attached Properties / 附加属性

| Property | Type | Applies To | Description / 说明 |
|---|---|---|---|
| `DialogControlBase.CanDragMove` | `bool` | `InputElement` | Make any element a drag handle for the dialog. / 将任意元素设为对话框拖拽手柄。 |
| `DialogControlBase.CanClose` | `bool` | `InputElement` | Clicking the element closes the dialog. / 点击该元素关闭对话框。 |

## Events / 事件

| Event / 事件 | Type / 类型 | Description / 说明 |
|---|---|---|
| `LayerChanged` (routed) | `DialogLayerChangeEventArgs` | Fired on layer change (BringForward, SendBackward, etc.). Only on overlay controls. / 层级变更时触发。仅 Overlay 控件。 |
| `Closed` (overlay) | `ResultEventArgs` | Fired when the overlay element closes, carrying the result. / Overlay 元素关闭时触发，携带结果。 |

## Styling & Templating / 样式与模板

### ControlTheme Keys

| Theme Key | Target Type | Description / 说明 |
|---|---|---|
| `{x:Type u:OverlayDialogHost}` | `OverlayDialogHost` | Host container theme. / 宿主容器主题。 |
| `{x:Type u:CustomDialogControl}` | `CustomDialogControl` | Overlay custom dialog theme. / Overlay 自定义对话框主题。 |
| `{x:Type u:StandardDialogControl}` | `StandardDialogControl` | Overlay standard dialog theme. / Overlay 标准对话框主题。 |
| `{x:Type u:CustomDialogWindow}` | `CustomDialogWindow` | Window custom dialog theme. / Window 自定义对话框主题。 |
| `{x:Type u:StandardDialogWindow}` | `StandardDialogWindow` | Window standard dialog theme. / Window 标准对话框主题。 |

### Theme Resources / 主题资源

| Resource Key | Applies To | Description / 说明 |
|---|---|---|
| `OverlayDialogMaskBrush` | OverlayHost | Mask brush behind modal dialogs. / 模态对话框后方的遮罩笔刷。 |
| `DialogBackground` | Control, Window | Dialog background. / 对话框背景。 |
| `DialogMinWidth` | Control, Window | Minimum width. / 最小宽度。 |
| `DialogMinHeight` | Control, Window | Minimum height. / 最小高度。 |
| `DialogCornerRadius` | Control | Corner radius. / 圆角半径。 |
| `DialogBoxShadow` | Control | Box shadow (overlay only). / 盒阴影（仅 Overlay）。 |
| `DialogInfoIconForeground` | Icon | Information icon color. / 信息图标颜色。 |
| `DialogErrorIconForeground` | Icon | Error icon color. / 错误图标颜色。 |
| `DialogWarningIconForeground` | Icon | Warning icon color. / 警告图标颜色。 |
| `DialogQuestionIconForeground` | Icon | Question icon color. / 问题图标颜色。 |
| `DialogSuccessIconForeground` | Icon | Success icon color. / 成功图标颜色。 |
| `DialogInformationIconGlyph` | Icon | Information icon path data. / 信息图标路径数据。 |
| `DialogErrorIconGlyph` | Icon | Error icon path data. / 错误图标路径数据。 |
| `DialogWarningIconGlyph` | Icon | Warning icon path data. / 警告图标路径数据。 |
| `DialogQuestionIconGlyph` | Icon | Question icon path data. / 问题图标路径数据。 |
| `DialogSuccessIconGlyph` | Icon | Success icon path data. / 成功图标路径数据。 |
| `DialogArrangeBringForwardGlyph` | Icon | Bring forward layer icon. / 上移一层图标。 |
| `DialogArrangeBringToFrontGlyph` | Icon | Bring to front icon. / 置顶图标。 |
| `DialogArrangeSendBackwardGlyph` | Icon | Send backward icon. / 下移一层图标。 |
| `DialogArrangeSendToBackGlyph` | Icon | Send to back icon. / 置底图标。 |

### Template Parts / 模板部件

#### CustomDialogControl / StandardDialogControl (Overlay)

| Part Name / 部件 | Type / 类型 | Description / 说明 |
|---|---|---|
| `PART_CloseButton` | `Button` | Close button. / 关闭按钮。 |
| `PART_TitleArea` | `Panel` | Drag-move title area. / 拖拽移动标题区域。 |
| `PART_Icon` | `PathIcon` | Mode icon (Standard only). / 模式图标（仅 Standard）。 |
| `PART_Title` | `TextBlock` | Title text (Standard only). / 标题文本（仅 Standard）。 |
| `PART_OKButton` | `Button` | OK button (Standard only). / 确定按钮（仅 Standard）。 |
| `PART_CancelButton` | `Button` | Cancel button (Standard only). / 取消按钮（仅 Standard）。 |
| `PART_YesButton` | `Button` | Yes button (Standard only). / "是"按钮（仅 Standard）。 |
| `PART_NoButton` | `Button` | No button (Standard only). / "否"按钮（仅 Standard）。 |

#### CustomDialogWindow / StandardDialogWindow

| Part Name / 部件 | Type / 类型 | Description / 说明 |
|---|---|---|
| `PART_CloseButton` | `Button` | Close button. / 关闭按钮。 |
| `PART_TitleArea` | `Panel` | Drag-move title area. / 拖拽移动标题区域。 |
| `PART_Icon` | `PathIcon` | Mode icon (Standard only). / 模式图标（仅 Standard）。 |
| `PART_Title` | `TextBlock` | Title text (Standard only). / 标题文本（仅 Standard）。 |
| `PART_OKButton` | `Button` | OK button (Standard only). / 确定按钮（仅 Standard）。 |
| `PART_CancelButton` | `Button` | Cancel button (Standard only). / 取消按钮（仅 Standard）。 |
| `PART_YesButton` | `Button` | Yes button (Standard only). / "是"按钮（仅 Standard）。 |
| `PART_NoButton` | `Button` | No button (Standard only). / "否"按钮（仅 Standard）。 |

### Pseudo-classes / 伪类

| Pseudo-class | Applies To | Description / 说明 |
|---|---|---|
| `:modal` | `DialogControlBase` | Set when the dialog is modal. / 对话框为模态时设置。 |
| `:full-screen` | `DialogControlBase` | Set when `IsFullScreen` is true. / `IsFullScreen` 为 true 时设置。 |

### Style Classes / 样式类

Pass a `StyleClass` string to options to add CSS-like classes. In Semi theme,
button classes follow the pattern: `Primary` (OK/Yes), `Danger` (No/Error mode),
`Tertiary` (Cancel), `Warning`, `Success`.

向 options 传递 `StyleClass` 字符串可添加样式类。Semi 主题中，按钮类遵循：
`Primary`（确定/是）、`Danger`（否/错误模式）、`Tertiary`（取消）、`Warning`、`Success`。

## FAQ / 常见问题

**Q: Window-based vs Overlay-based — which should I use?**
A: Use `Dialog.ShowStandardAsync` / `Dialog.ShowCustomAsync` for classic desktop
apps where a separate OS window is fine. Use `OverlayDialog.ShowStandardAsync` /
`OverlayDialog.ShowCustomAsync` for browser (WASM) support or when you want
in-window modals. Overlay dialogs require an `OverlayDialogHost` in the visual tree.

**Q: 桌面端和浏览器端应该用哪个？**
A: 经典桌面应用使用 `Dialog.ShowStandardAsync` / `Dialog.ShowCustomAsync`（独立的
OS 窗口）。需要浏览器（WASM）支持或窗口内模态框时使用
`OverlayDialog.ShowStandardAsync` / `OverlayDialog.ShowCustomAsync`。
Overlay 对话框需要在可视树中添加 `OverlayDialogHost`。

**Q: How do I return a custom result type? / 如何返回自定义结果类型？**
A: Use `Dialog.ShowCustomAsync<TView, TViewModel, TResult>` or
`OverlayDialog.ShowCustomAsync<TResult>`. Implement `IDialogContext` on the
ViewModel and call `RequestClose?.Invoke(this, yourResult)`.

**Q: How do I close a dialog from the ViewModel? / 如何从 ViewModel 关闭对话框？**
A: Implement `IDialogContext` on your ViewModel. The dialog listens to
`RequestClose` events and will close with the provided result object.

**Q: Can I have multiple OverlayDialogHosts? / 可以有多个 OverlayDialogHost 吗？**
A: Yes. Use the `hostId` parameter to target a specific host. Use
`TopLevelHashCode` in options to disambiguate hosts with the same id across
different top-level windows.

**Q: How does ESC key behave? / ESC 键的行为？**
A: For standard dialogs, pressing the close button (X) or ESC (via the overlay
host) performs the default close action, which varies by `Buttons` configuration.
For custom dialogs, rely on `IDialogContext` or the close button.
