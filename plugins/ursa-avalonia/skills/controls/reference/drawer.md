---
category: Components
title: Drawer
subtitle: 抽屉
description: >
  A panel that slides in from any screen edge (Left, Top, Right, Bottom),
  overlay-hosted with optional standard button layouts and light dismiss.
  Supports custom or standard content, modal or modeless, and resizable panels.
  从屏幕任意边缘（左、上、右、下）滑入的面板，基于 Overlay 承载，支持标准按钮布局
  和点击外部关闭。支持自定义或标准内容、模态或非模态以及可调整大小的面板。
---

# Drawer / 抽屉

> ⚠ **Requires `OverlayDialogHost`** — `OverlayDrawer.Show()` requires an `OverlayDialogHost` in the visual tree. Use `UrsaWindow` or `UrsaView`.
>
> ⚠ **需要 `OverlayDialogHost`** — `OverlayDrawer.Show()` 需要可视树中存在 `OverlayDialogHost`。使用 `UrsaWindow` 或 `UrsaView`。

## When to Use / 何时使用

Use `Drawer` for side panels, settings panels, filter sheets, or any secondary
content that slides in from a screen edge. It is overlay-hosted (requires
`OverlayDialogHost`) and works on desktop and browser (WASM). Prefer `Drawer`
over `Dialog` when edge-anchored slide-in UX is appropriate.

使用 `Drawer` 显示侧边面板、设置面板、筛选面板或任何从屏幕边缘滑入的辅助内容。
它基于 Overlay 承载（需要 `OverlayDialogHost`），适用于桌面端和浏览器端（WASM）。
当需要边缘锚定的滑入式交互时，优先使用 `Drawer` 而非 `Dialog`。

## Basic Usage / 基本使用

### Host Setup / 宿主设置

Add an `OverlayDialogHost` to your view (shared with Dialog):

```xml
<u:OverlayDialogHost HostId="MainHost" />
```

### Standard Drawer (non-modal)

```csharp
using Ursa.Controls;

OverlayDrawer.ShowStandard<MyView, MyViewModel>(
    new MyViewModel(),
    hostId: "MainHost",
    options: new DrawerOptions
    {
        Position = Position.Right,
        Title = "Settings"
    });
```

### Standard Drawer (modal, awaitable result)

```csharp
var result = await OverlayDrawer.ShowStandardAsync<MyView, MyViewModel>(
    vm, hostId: "MainHost",
    options: new DrawerOptions
    {
        Position = Position.Left,
        Buttons = DialogButton.OKCancel,
        CanLightDismiss = true
    });

if (result == DialogResult.OK) { /* confirmed */ }
```

### Custom Drawer (full control)

```csharp
// Non-modal
OverlayDrawer.ShowCustom<MyView, MyViewModel>(vm, hostId: "MainHost");

// Modal with custom result type
var choice = await OverlayDrawer.ShowCustomAsync<MyView, MyViewModel, string>(
    vm, hostId: "MainHost");
```

## Common Scenarios / 常用场景

### Positioning / 定位

Set `DrawerOptions.Position` to control the slide-in edge:

| Position | Behavior / 行为 |
|---|---|
| `Left` | Slides in from left edge. / 从左侧滑入。 |
| `Top` | Slides in from top edge. / 从顶部滑入。 |
| `Right` | Slides in from right edge (default). / 从右侧滑入（默认）。 |
| `Bottom` | Slides in from bottom edge. / 从底部滑入。 |

```csharp
var options = new DrawerOptions { Position = Position.Bottom };
```

### Size Constraints / 尺寸约束

Control minimum and maximum dimensions:

```csharp
var options = new DrawerOptions
{
    MinWidth = 300,
    MaxWidth = 600,
    MinHeight = 200,
    MaxHeight = 800
};
```

### Light Dismiss / 点击外部关闭

`CanLightDismiss` is `true` by default — clicking the mask closes the drawer.
Set to `false` to require explicit close.

```csharp
var options = new DrawerOptions { CanLightDismiss = false };
```

### Close Button Visibility / 关闭按钮可见性

```csharp
var options = new DrawerOptions { IsCloseButtonVisible = false };
```

When the ViewModel implements `IDialogContext`, close button behavior delegates
to the context.

### Resizable Drawer / 可调整大小

```csharp
var options = new DrawerOptions
{
    CanResize = true,
    Position = Position.Right  // resizer appears on the inner edge
};
```

### Full DrawerOptions Reference / 完整选项参考

```csharp
var options = new DrawerOptions
{
    Position = Position.Right,
    CanLightDismiss = true,
    IsCloseButtonVisible = true,
    MinWidth = 280,
    MaxWidth = 500,
    MinHeight = null,
    MaxHeight = null,
    Buttons = DialogButton.OKCancel,
    Title = "Filter",
    CanResize = false,
    TopLevelHashCode = null,
    StyleClass = "MyDrawerClass",
    HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
};
```

## Property Reference / 属性参考

### DrawerControlBase Properties / 基类属性

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `Position` | `Position` | `Right` | Edge from which the drawer slides in. / 抽屉从哪个边缘滑入。 |
| `IsOpen` | `bool` | `false` | Whether the drawer is currently open. / 抽屉当前是否打开。 |
| `CanResize` | `bool` | `false` | Whether the drawer can be resized by the user. / 用户是否可调整抽屉大小。 |

### StandardDrawerControl Properties / 标准抽屉属性

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `Title` | `string?` | `null` | Header title text. / 标题文本。 |
| `Buttons` | `DialogButton` | `OKCancel` | Button combination. / 按钮组合。 |
| `Mode` | `DialogMode` | `None` | Contextual icon mode (no icon in drawer template). / 上下文图标模式（抽屉模板中无图标）。 |

### DrawerOptions Properties / 选项属性

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `Position` | `Position` | `Right` | Slide-in edge. / 滑入边缘。 |
| `CanLightDismiss` | `bool` | `true` | Clicking the mask closes the drawer. / 点击遮罩关闭抽屉。 |
| `IsCloseButtonVisible` | `bool?` | `true` | Close button visibility. / 关闭按钮可见性。 |
| `MinWidth` | `double?` | `null` | Minimum width. / 最小宽度。 |
| `MaxWidth` | `double?` | `null` | Maximum width. / 最大宽度。 |
| `MinHeight` | `double?` | `null` | Minimum height. / 最小高度。 |
| `MaxHeight` | `double?` | `null` | Maximum height. / 最大高度。 |
| `Buttons` | `DialogButton` | `OKCancel` | Button combination (Standard only). / 按钮组合（仅 Standard）。 |
| `Title` | `string?` | `null` | Title text (Standard only). / 标题（仅 Standard）。 |
| `CanResize` | `bool` | `false` | Enable resizer. / 启用调整手柄。 |
| `TopLevelHashCode` | `int?` | `null` | Top-level host disambiguation. / 顶层宿主消歧。 |
| `StyleClass` | `string?` | `null` | Additional style classes. / 额外样式类。 |
| `HorizontalScrollBarVisibility` | `ScrollBarVisibility` | `Auto` | Horizontal scrollbar. / 水平滚动条可见性。 |
| `VerticalScrollBarVisibility` | `ScrollBarVisibility` | `Auto` | Vertical scrollbar. / 垂直滚动条可见性。 |

### Position Enum / 位置枚举

| Value | Description / 说明 |
|---|---|
| `Left` | Left edge / 左侧 |
| `Top` | Top edge / 顶部 |
| `Right` | Right edge / 右侧 |
| `Bottom` | Bottom edge / 底部 |

## Events / 事件

| Event / 事件 | Type / 类型 | Description / 说明 |
|---|---|---|
| `Closed` | `ResultEventArgs` | Fired when the drawer closes, carrying the result. / 抽屉关闭时触发，携带结果。 |

## Styling & Templating / 样式与模板

### ControlTheme Keys

| Theme Key | Target Type | Description / 说明 |
|---|---|---|
| `{x:Type u:CustomDrawerControl}` | `CustomDrawerControl` | Custom drawer theme. / 自定义抽屉主题。 |
| `{x:Type u:StandardDrawerControl}` | `StandardDrawerControl` | Standard drawer theme. / 标准抽屉主题。 |

### Theme Resources / 主题资源

| Resource Key | Applies To | Description / 说明 |
|---|---|---|
| `DrawerBackground` | Border | Drawer panel background. / 抽屉面板背景。 |
| `DrawerMargin` | Control | Padding (used as margin on the anchored edge). / 内边距（用作锚定边缘的外边距）。 |
| `DrawerBorderThickness` | Border | Drawer border thickness. / 抽屉边框粗细。 |
| `DrawerCornerRadius` | Border | Drawer corner radius. / 抽屉圆角半径。 |

### Template Parts / 模板部件

#### CustomDrawerControl

| Part Name / 部件 | Type / 类型 | Description / 说明 |
|---|---|---|
| `PART_CloseButton` | `Button` | Close button. / 关闭按钮。 |

#### StandardDrawerControl

| Part Name / 部件 | Type / 类型 | Description / 说明 |
|---|---|---|
| `PART_CloseButton` | `Button` | Close button. / 关闭按钮。 |
| `PART_TitleArea` | `Panel` | Title area (shared with DialogControlBase). / 标题区域。 |
| `PART_OKButton` | `Button` | OK button. / 确定按钮。 |
| `PART_CancelButton` | `Button` | Cancel button. / 取消按钮。 |
| `PART_YesButton` | `Button` | Yes button. / "是"按钮。 |
| `PART_NoButton` | `Button` | No button. / "否"按钮。 |

### Style Classes / 样式类

Button classes in Semi theme follow: `Primary` (OK/Yes), `Danger` (No), `Tertiary`
(Cancel). The drawer border respects `Position` for correct margin/corner
application.

Semi 主题中按钮样式类遵循：`Primary`（确定/是）、`Danger`（否）、`Tertiary`
（取消）。抽屉边框根据 `Position` 应用正确的边距和圆角。

## FAQ / 常见问题

**Q: What's the difference between Drawer and Dialog?**
A: `Drawer` slides in from a screen edge and is always overlay-hosted. `Dialog`
appears centered (or anchored) and supports both Window and Overlay hosting.
Use `Drawer` for edge-attached panels; use `Dialog` for centered or free-form
overlays.

**Q: Drawer 和 Dialog 有什么区别？**
A: `Drawer` 从屏幕边缘滑入，始终基于 Overlay 承载。`Dialog` 居中显示（或指定锚点），
同时支持 Window 和 Overlay 两种承载方式。边缘附着面板使用 `Drawer`；
居中或自由形式的叠加层使用 `Dialog`。

**Q: Can I use Drawer without OverlayDialogHost?**
A: No. Drawer is overlay-hosted and requires `OverlayDialogHost` in the visual
tree. Without it, `OverlayDrawer` methods silently return (no-op).

**Q: 可以不用 OverlayDialogHost 使用 Drawer 吗？**
A: 不可以。Drawer 基于 Overlay 承载，必须在可视树中添加 `OverlayDialogHost`。
没有它，`OverlayDrawer` 方法会静默返回（无操作）。

**Q: How do I close a drawer from the ViewModel? / 如何从 ViewModel 关闭抽屉？**
A: Implement `IDialogContext` on the ViewModel. The drawer listens to
`RequestClose` events.

**Q: Can I resize a drawer? / 可以调整抽屉大小吗？**
A: Yes, set `CanResize = true`. A `DialogResizer` is shown on the inner edge
(opposite the anchored edge). The resizer direction adapts to `Position`.
