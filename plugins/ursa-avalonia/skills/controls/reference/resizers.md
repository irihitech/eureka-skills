---
category: Components
title: Resizers
subtitle: 调节器
description: >
  Controls for enabling drag-to-resize on windows and dialogs. WindowResizer and
  DialogResizer provide eight-directional resize thumbs, while WindowResizerThumb
  and DialogResizerThumb handle the low-level drag logic mapped to WindowEdge.
  用于窗口和对话框拖拽调整大小的控件。WindowResizer 和 DialogResizer 提供八个方向的
  调节手柄，WindowResizerThumb 和 DialogResizerThumb 处理映射到 WindowEdge 的底层拖拽逻辑。
---

# Resizers / 调节器

## When to Use / 何时使用

Use `WindowResizer` (with `WindowResizerThumb`) to add resize handles to a
custom `Window` chrome — for example, when you replace the default OS window
frame with a custom title bar. Use `DialogResizer` (with `DialogResizerThumb`)
to add resize handles to an `OverlayDialog` or other overlay-hosted dialog.

当需要为自定义 `Window` 添加调整大小手柄时使用 `WindowResizer`（配合
`WindowResizerThumb`）——例如用自定义标题栏替换默认 OS 窗口边框时。当需要为
`OverlayDialog` 或其他浮层托管对话框添加调整大小手柄时使用 `DialogResizer`
（配合 `DialogResizerThumb`）。

Avoid resizers on fixed-size dialogs (e.g., alert boxes) — set
`ResizeDirection` to limit or disable handles instead.

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"
```

### WindowResizer — Custom Window Chrome / 自定义窗口边框

```xml
<!-- Inside a custom Window template -->
<u:WindowResizer />
```

`WindowResizer` is a `TemplatedControl` that renders a 3×3 grid of
`WindowResizerThumb` instances covering all eight directions (Top, Bottom,
Left, Right, TopLeft, TopRight, BottomLeft, BottomRight). Each thumb invokes
`Window.BeginResizeDrag(windowEdge, e)` on pointer press.

`WindowResizer` 是一个 `TemplatedControl`，渲染一个 3×3 网格，包含覆盖八个方向的
`WindowResizerThumb` 实例。每个手柄在指针按下时调用 `Window.BeginResizeDrag`。

### DialogResizer — Dialog Resize Handles / 对话框调节手柄

```xml
<!-- Inside a dialog overlay template -->
<u:DialogResizer ResizeDirection="Sides|Corners" />
```

`DialogResizer` uses `DialogResizerThumb` instances that locate the parent
`OverlayFeedbackElement` and call `BeginResizeDrag` on it. You can restrict
resize directions with the `ResizeDirection` property.

`DialogResizer` 使用 `DialogResizerThumb` 实例，这些实例定位父级
`OverlayFeedbackElement` 并调用其 `BeginResizeDrag`。可通过
`ResizeDirection` 属性限制调节方向。

## Common Scenarios / 常用场景

### 1. Custom window with all resize edges / 带全部调节边的自定义窗口

```xml
<Window>
    <Panel>
        <!-- Custom title bar -->
        <Border Height="32" Background="..." />
        <!-- Content -->
        <Border Margin="0,32,0,0">
            <ContentPresenter Content="{Binding Content}" />
        </Border>
        <!-- Resize handles around the window edges -->
        <u:WindowResizer />
    </Panel>
</Window>
```

### 2. Dialog resizer with only corners / 仅四角可调节的对话框

```xml
<u:DialogResizer ResizeDirection="Corners" />
```

### 3. Dialog resizer with only horizontal edges / 仅水平边可调节

```xml
<u:DialogResizer ResizeDirection="Left,Right" />
```

### 4. Using a single Thumb directly / 直接使用单个 Thumb

```xml
<!-- A right-edge resize handle -->
<u:WindowResizerThumb ResizeDirection="Right"
                       Cursor="RightSide"
                       Height="Auto" Width="4"
                       HorizontalAlignment="Right" />
```

## Property Reference / 属性参考

### DialogResizer / WindowResizer

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `ResizeDirection` | `ResizeDirection` | `All` | Bitmask of allowed resize directions / 允许的调节方向位掩码 |

### WindowResizerThumb / DialogResizerThumb

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `ResizeDirection` | `ResizeDirection` | (unset) | The direction this thumb controls; maps to a `WindowEdge` value / 此手柄控制的方向；映射到 WindowEdge 值 |

### ResizeDirection enum / ResizeDirection 枚举

| Value | Description / 说明 |
|---|---|
| `Top` (1) | Top edge / 上边 |
| `Bottom` (2) | Bottom edge / 下边 |
| `Left` (4) | Left edge / 左边 |
| `Right` (8) | Right edge / 右边 |
| `TopLeft` (16) | Top-left corner / 左上角 |
| `TopRight` (32) | Top-right corner / 右上角 |
| `BottomLeft` (64) | Bottom-left corner / 左下角 |
| `BottomRight` (128) | Bottom-right corner / 右下角 |
| `Sides` | Combination: `Top \| Bottom \| Left \| Right` / 四条边 |
| `Corners` | Combination: `TopLeft \| TopRight \| BottomLeft \| BottomRight` / 四个角 |
| `All` | Combination: `Sides \| Corners` / 所有方向 |

## Events / 事件

No custom events. `WindowResizerThumb` and `DialogResizerThumb` inherit
`PointerPressed` and other pointer events from `Thumb`. The `OnPointerPressed`
handler translates the `ResizeDirection` to a `WindowEdge` and calls
`BeginResizeDrag`.

没有自定义事件。`WindowResizerThumb` 和 `DialogResizerThumb` 继承自 `Thumb`
的 `PointerPressed` 等指针事件。`OnPointerPressed` 处理器将 `ResizeDirection`
转换为 `WindowEdge` 并调用 `BeginResizeDrag`。

## Styling & Templating / 样式与模板

### Theme Keys / 主题 Key

| Theme Key | Description / 说明 |
|---|---|
| `{x:Type u:WindowResizer}` | Default theme — 3×3 grid of `WindowResizerThumb` instances / 默认主题——WindowResizerThumb 的 3×3 网格 |
| `{x:Type u:DialogResizer}` | Default theme — 3×3 grid of `DialogResizerThumb` instances / 默认主题——DialogResizerThumb 的 3×3 网格 |
| `{x:Type u:WindowResizerThumb}` | Transparent background, stretched `PureRectangle` / 透明背景，拉伸的 PureRectangle |
| `{x:Type u:DialogResizerThumb}` | Transparent background, panel-wrapped `PureRectangle` / 透明背景，Panel 包裹的 PureRectangle |

### Template Parts / 模板部件

| Part Name | Control | Type | Description / 说明 |
|---|---|---|---|
| `PART_Top` | `DialogResizer` | `DialogResizerThumb` | Top edge thumb / 上边手柄 |
| `PART_Bottom` | `DialogResizer` | `DialogResizerThumb` | Bottom edge thumb / 下边手柄 |
| `PART_Left` | `DialogResizer` | `DialogResizerThumb` | Left edge thumb / 左边手柄 |
| `PART_Right` | `DialogResizer` | `DialogResizerThumb` | Right edge thumb / 右边手柄 |
| `PART_TopLeft` | `DialogResizer` | `DialogResizerThumb` | Top-left corner thumb / 左上角手柄 |
| `PART_TopRight` | `DialogResizer` | `DialogResizerThumb` | Top-right corner thumb / 右上角手柄 |
| `PART_BottomLeft` | `DialogResizer` | `DialogResizerThumb` | Bottom-left corner thumb / 左下角手柄 |
| `PART_BottomRight` | `DialogResizer` | `DialogResizerThumb` | Bottom-right corner thumb / 右下角手柄 |

### Theme Resources / 主题资源

| Resource Key | Description / 说明 |
|---|---|
| `ResizerThumbHeight` | Height for top/bottom edge thumbs in the resizer grid / 上/下边手柄的网格高度 |
| `ResizerThumbWidth` | Width for left/right edge thumbs in the resizer grid / 左/右边手柄的网格宽度 |

### Pseudo-classes / 伪类

No custom pseudo-classes. Standard Thumb pseudo-classes apply.

没有自定义伪类。应用标准 Thumb 伪类。

## FAQ / 常见问题

**Q: What's the difference between WindowResizer and DialogResizer? / WindowResizer 和 DialogResizer 的区别？**
A: `WindowResizer` uses `WindowResizerThumb` which finds the `Window` parent
(via `TopLevel.GetTopLevel`) and calls `Window.BeginResizeDrag`. `DialogResizer`
uses `DialogResizerThumb` which finds the parent `OverlayFeedbackElement` and
calls its `BeginResizeDrag`. The underlying resize mechanics differ because
dialogs are overlay-hosted, not native `Window` instances.

**Q: Can I make only certain edges resizable? / 可以只让某些边可调节吗？**
A: Yes, set the `ResizeDirection` property using the flags enum:
```xml
<u:DialogResizer ResizeDirection="Top,Bottom" />
```

**Q: How do I hide specific thumbs? / 如何隐藏特定手柄？**
A: Setting `ResizeDirection` on `DialogResizer` automatically toggles
`IsVisible` on each thumb. `WindowResizer` does not have a direction filter —
all eight thumbs are always in the template; you can hide individual thumbs by
overriding the `WindowResizer` template.

**Q: Do these work with touch? / 支持触屏吗？**
A: `WindowResizerThumb` explicitly checks for left mouse button
(`IsLeftButtonPressed`) and has a TODO comment for touch support.
`DialogResizerThumb` has the same limitation. Touch resizing is not yet
implemented.
