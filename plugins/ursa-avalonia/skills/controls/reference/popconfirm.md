---
category: Components
title: PopConfirm
subtitle: 气泡确认框
description: 用于在二次确认后执行操作的气泡提示框。
---

# PopConfirm / 气泡确认框

A popover control that asks the user to confirm an action before executing it. Typically wraps around a Button or other trigger element. Supports custom title, content, and confirm/cancel buttons.

在操作执行前要求用户二次确认的气泡控件。通常包裹 Button 或其他触发元素。支持自定义标题、内容和确认/取消按钮。

## When to Use / 何时使用

Use `PopConfirm` for destructive or irreversible actions (delete, remove, reset) where a simple click is too risky. The popover appears near the trigger element. For simple yes/no dialogs, consider `MessageBox` instead.

使用 `PopConfirm` 处理破坏性或不可逆操作（删除、移除、重置），单纯的点击风险太大。气泡出现在触发元素附近。简单的确认对话框可使用 `MessageBox`。

## Basic Usage / 基本使用

```xml
<ursa:PopConfirm Title="Delete this item?"
                 Content="This action cannot be undone."
                 ConfirmText="Delete"
                 CancelText="Cancel">
    <Button Content="Delete" Classes="Danger" />
</ursa:PopConfirm>
```

## Common Scenarios / 常用场景

### Custom Confirm Handler / 自定义确认处理

```xml
<ursa:PopConfirm Title="Are you sure?"
                 OnConfirm="OnDeleteConfirmed">
    <Button Content="Delete" />
</ursa:PopConfirm>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Title` | `string` | Title text displayed in the popover. / 气泡中显示的标题文本。 |
| `Content` | `string` | Body text below the title. / 标题下方的正文。 |
| `ConfirmText` | `string` | Text for the confirm button (default "OK"). / 确认按钮文本（默认"OK"）。 |
| `CancelText` | `string` | Text for the cancel button (default "Cancel"). / 取消按钮文本（默认"Cancel"）。 |
| `Placement` | `PlacementMode` | Where the popover appears relative to trigger. / 气泡相对触发器的位置。 |

## Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `OnConfirm` | Raised when user clicks confirm button. / 用户点击确认按钮时触发。 |

## Styling & Templating / 样式与模板

Theme resources: `PopConfirmBackground`, `PopConfirmBorderBrush`, `PopConfirmForeground`, `PopConfirmBorderThickness`, `PopConfirmCornerRadius`.

## FAQ / 常见问题

**Q: PopConfirm vs. MessageBox? / PopConfirm 与 MessageBox 的区别？**

A: `PopConfirm` appears as a popover near the trigger (contextual confirmation). `MessageBox` appears as a modal dialog in the center of the window.

`PopConfirm` 显示在触发器附近的气泡中（上下文确认），`MessageBox` 显示在窗口中央的模态对话框中。
