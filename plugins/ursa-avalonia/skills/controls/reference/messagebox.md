---
category: Dialog
title: MessageBox
subtitle: 消息框
description: >
  Modal dialog for alerts, confirmations, and simple user prompts. Supports
  standard button combinations (OK/Cancel/Yes/No) and icons. Available as a
  traditional Window dialog or an Overlay-hosted modal.
  模态对话框，用于提示、确认和简单的用户交互。支持标准按钮组合（确认/取消/是/否）
  及图标。可作为传统 Window 对话框或 Overlay 承载的模态框使用。
---

# MessageBox / 消息框

> ℹ `MessageBox.ShowAsync()` opens a **Window**-based dialog (no OverlayDialogHost needed).
> `OverlayMessageBox.ShowAsync()` opens an **overlay**-hosted dialog (requires `OverlayDialogHost` → `UrsaWindow`/`UrsaView`).
>
> ℹ `MessageBox.ShowAsync()` 打开**窗口**对话框（无需 OverlayDialogHost）。
> `OverlayMessageBox.ShowAsync()` 打开**浮层**对话框（需要 `OverlayDialogHost` → `UrsaWindow`/`UrsaView`）。

## When to Use / 何时使用

Use `MessageBox` for simple modal prompts: alerts, confirmations, yes/no
questions. For complex forms or custom dialogs, use `OverlayDialog` or a custom
`Window` instead.

使用 `MessageBox` 进行简单模态提示：警告、确认、是/否询问。复杂表单或自定义对话框
应使用 `OverlayDialog` 或自定义 `Window`。

## Basic Usage / 基本使用

### Window-based MessageBox (Desktop only)

```csharp
using Ursa.Controls;

// Simple alert
await MessageBox.ShowAsync("Operation completed.");

// With title, icon, and buttons
var result = await MessageBox.ShowAsync(
    "Are you sure you want to delete this item?",
    "Confirm Delete",
    MessageBoxIcon.Warning,
    MessageBoxButton.YesNo);

if (result == MessageBoxResult.Yes)
{
    // Delete
}
```

### Overlay-based MessageBox (Desktop + Browser)

```csharp
using Ursa.Controls;

var result = await OverlayMessageBox.ShowAsync(
    "Item deleted successfully.",
    "Success",
    icon: MessageBoxIcon.Success,
    button: MessageBoxButton.OK);
```

### Reactive/Observable content / 响应式内容

```csharp
var message = SomeService.StatusObservable;
var title = Observable.Return("Progress");
await MessageBox.ShowAsync(message, title, MessageBoxIcon.Information);
```

## Property Reference / 属性参考

### MessageBox Static Methods / MessageBox 静态方法

| Overload | Description |
|---|---|
| `ShowAsync(string message, ...)` | Simple string message / 简单字符串消息 |
| `ShowAsync(Window owner, string message, ...)` | With owner window / 指定所有者窗口 |
| `ShowAsync(IObservable<string> message, ...)` | Reactive message content / 响应式消息内容 |
| `ShowAsync(Window owner, IObservable<string> message, ...)` | Reactive with owner / 指定所有者的响应式 |

### OverlayMessageBox Static Methods / OverlayMessageBox 静态方法

| Overload | Description |
|---|---|
| `ShowAsync(string message, string? hostId, ...)` | Overlay-hosted with optional host ID |
| `ShowAsync(IObservable<string> message, ...)` | Reactive in overlay |

### MessageBoxButton Enum / 按钮枚举

| Value | Buttons Shown / 显示的按钮 |
|---|---|
| `OK` | OK |
| `OKCancel` | OK, Cancel |
| `YesNo` | Yes, No |
| `YesNoCancel` | Yes, No, Cancel |

### MessageBoxIcon Enum / 图标枚举

| Value | Aliases | Visual |
|---|---|---|
| `None` | — | No icon / 无图标 |
| `Information` | `Asterisk` | ℹ Information / 信息 |
| `Success` | — | ✓ Success / 成功 |
| `Warning` | `Exclamation` | ⚠ Warning / 警告 |
| `Error` | `Hand`, `Stop` | ✗ Error / 错误 |
| `Question` | — | ? Question / 问题 |

### MessageBoxResult Enum / 结果枚举

| Value | Meaning / 含义 |
|---|---|
| `OK` | OK button clicked / 点击确定 |
| `Cancel` | Cancel or close / 取消或关闭 |
| `Yes` | Yes clicked / 点击是 |
| `No` | No clicked / 点击否 |
| `None` | No result (e.g., non-desktop lifetime) / 无结果 |

### MessageBoxWindow Properties / 窗口属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `MessageIcon` | `MessageBoxIcon` | `None` | Icon displayed in the dialog / 对话框中显示的图标 |
| `TitleSource` | `IObservable<string>?` | `null` | Reactive title / 响应式标题 |
| `ContentSource` | `IObservable<string>?` | `null` | Reactive content / 响应式内容 |

### MessageBoxControl Properties (Overlay) / 叠加层对话框属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `MessageIcon` | `MessageBoxIcon` | `None` | Icon / 图标 |
| `Buttons` | `MessageBoxButton` | `OK` | Button combination / 按钮组合 |
| `Title` | `string?` | `null` | Dialog title / 对话框标题 |
| `TitleSource` | `IObservable<string>?` | `null` | Reactive title / 响应式标题 |
| `ContentSource` | `IObservable<string>?` | `null` | Reactive content / 响应式内容 |

## Events / 事件

No custom routed events. The return value of `ShowAsync` is the primary
interaction mechanism.

无自定义路由事件。`ShowAsync` 的返回值是主要的交互机制。

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `MessageBoxBackground` | Window, Control | Dialog background / 对话框背景 |
| `DialogInfoIconForeground` | Icon | Information icon color / 信息图标颜色 |
| `DialogErrorIconForeground` | Icon | Error icon color / 错误图标颜色 |
| `DialogWarningIconForeground` | Icon | Warning icon color / 警告图标颜色 |
| `DialogQuestionIconForeground` | Icon | Question icon color / 问题图标颜色 |
| `DialogSuccessIconForeground` | Icon | Success icon color / 成功图标颜色 |
| `DialogInformationIconGlyph` | Icon | Information icon path data |
| `DialogErrorIconGlyph` | Icon | Error icon path data |
| `DialogWarningIconGlyph` | Icon | Warning icon path data |
| `DialogQuestionIconGlyph` | Icon | Question icon path data |
| `DialogSuccessIconGlyph` | Icon | Success icon path data |

### Template Parts (MessageBoxControl) / 模板部件

| Part Name | Type | Description |
|---|---|---|
| `PART_YesButton` | `Button` | Yes button / "是"按钮 |
| `PART_NoButton` | `Button` | No button / "否"按钮 |
| `PART_OKButton` | `Button` | OK button / "确定"按钮 |
| `PART_CancelButton` | `Button` | Cancel button / "取消"按钮 |
| `PART_CloseButton` | `Button` | Close button (on Window) / 关闭按钮 |
| `PART_Icon` | `PathIcon` | Icon presenter / 图标展示 |

### Style Classes / 样式类

Pass a `styleClass` string to `ShowAsync` to add CSS-like classes to the
dialog. In Semi theme, setting `class="Primary"` on the OK button styles it as
the primary action.

向 `ShowAsync` 传递 `styleClass` 字符串可为对话框添加样式类。Semi 主题中，在确定按钮上
设置 `class="Primary"` 会将其渲染为主操作按钮样式。

## FAQ / 常见问题

**Q: Window-based vs Overlay-based — which should I use?**
A: Use `MessageBox.ShowAsync` for classic desktop apps. Use
`OverlayMessageBox.ShowAsync` for browser (WASM) support or when you want
in-window modals without a separate OS window.

**Q: 桌面端和浏览器端应该用哪个？**
A: 经典桌面应用使用 `MessageBox.ShowAsync`；浏览器（WASM）或需要窗口内模态框时
使用 `OverlayMessageBox.ShowAsync`。

**Q: How do I customize the button text? / 如何自定义按钮文字？**
A: Override the resource keys `STRING_MENU_DIALOG_OK`, `STRING_MENU_DIALOG_CANCEL`,
`STRING_MENU_DIALOG_YES`, `STRING_MENU_DIALOG_NO` in your application resources.

**Q: Can I put arbitrary content in a MessageBox?**
A: `MessageBoxControl.Content` is `object`, but the template is designed for
text. For rich content use `OverlayDialog` with a custom control.

**Q: How does ESC key behave? / ESC 键的行为？**
A: ESC closes with `OK` for `OK`-only, `Cancel` for `OKCancel` and
`YesNoCancel`, and does nothing for `YesNo`.
