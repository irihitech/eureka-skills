---
category: Components
title: Resizers
subtitle: 调整大小控件
description: >
  A family of controls for window and dialog resizing: WindowResizer,
  WindowResizerThumb, DialogResizer, DialogResizerThumb, and ResizeDirection
  flags enum. Provides edge and corner drag handles for resizable windows
  and overlay dialogs.
  一组用于窗口和对话框调整大小的控件：WindowResizer、WindowResizerThumb、
  DialogResizer、DialogResizerThumb 和 ResizeDirection 标志枚举。为可调整
  大小的窗口和覆盖对话框提供边缘和角落拖拽手柄。
---

# Resizers / 调整大小控件

## When to Use / 何时使用

Use `WindowResizer` inside a `Window` template to add edge and corner resize
handles. Use `DialogResizer` inside an overlay dialog template for the same
purpose but with direction filtering via `ResizeDirection`. Both are
`TemplatedControl` subclasses that host eight `Thumb`-derived drag handles
(top, bottom, left, right, and four corners).

在 `Window` 模板中使用 `WindowResizer` 添加边缘和角落调整手柄。在覆盖对话框
模板中使用 `DialogResizer` 实现相同目的，但可通过 `ResizeDirection` 过滤方向。
两者都是 `TemplatedControl` 子类，承载八个 `Thumb` 派生的拖拽手柄。

Do NOT use `WindowResizer` inside a dialog — use `DialogResizer` instead.
Do NOT use `DialogResizerThumb` or `WindowResizerThumb` standalone outside
their parent resizer templates.

不要在对话框中使用 `WindowResizer`——应使用 `DialogResizer`。不要在父级
调整器模板之外单独使用 `DialogResizerThumb` 或 `WindowResizerThumb`。

## Control Overview / 控件概览

| Control | Base Class | Purpose / 用途 |
|---|---|---|
| `WindowResizer` | `TemplatedControl` | Window-level resize handles; always shows all 8 directions / 窗口级调整手柄；始终显示全部 8 个方向 |
| `WindowResizerThumb` | `Thumb` | Individual edge/corner handle for windows; binds to parent `Window` / 窗口的单个边缘/角落手柄；绑定父级 Window |
| `DialogResizer` | `TemplatedControl` | Dialog-level resize handles; direction filtered via `ResizeDirection` / 对话框级调整手柄；通过 ResizeDirection 过滤方向 |
| `DialogResizerThumb` | `Thumb` | Individual edge/corner handle for dialogs; binds to parent `OverlayFeedbackElement` / 对话框的单个边缘/角落手柄；绑定父级 OverlayFeedbackElement |
| `ResizeDirection` | `[Flags] enum` | Bitmask controlling which edges/corners are active / 控制哪些边缘/角落处于活动状态的位掩码 |

## Basic Usage / 基本使用

### WindowResizer / 窗口调整器

```xml
xmlns:u="https://irihi.tech/ursa"

<!-- Inside a Window template, place the resizer as an overlay -->
<u:WindowResizer />
```

`WindowResizer` has no configurable properties — it renders all 8 resize
thumbs unconditionally. Place it as the last child in a `Grid` overlay so
it captures input on top of window content.

`WindowResizer` 无可配置属性——它无条件渲染全部 8 个调整手柄。将其放置为
`Grid` 覆盖层的最后一个子元素，以捕获窗口内容上方的输入。

### DialogResizer / 对话框调整器

```xml
<!-- Full resize (default) -->
<u:DialogResizer ResizeDirection="All" />

<!-- Horizontal-only resize -->
<u:DialogResizer ResizeDirection="Left, Right" />

<!-- Bottom-right corner only -->
<u:DialogResizer ResizeDirection="BottomRight" />
```

### WindowResizerThumb (standalone) / 独立窗口手柄

```xml
<u:WindowResizerThumb ResizeDirection="BottomRight"
                       Cursor="BottomRightCorner"
                       Width="8" Height="8" />
```

`WindowResizerThumb` maps its `ResizeDirection` to a `WindowEdge` and calls
`Window.BeginResizeDrag()` on left-button press.

`WindowResizerThumb` 将其 `ResizeDirection` 映射到 `WindowEdge` 并在
左键按下时调用 `Window.BeginResizeDrag()`。

### DialogResizerThumb (standalone) / 独立对话框手柄

```xml
<u:DialogResizerThumb ResizeDirection="Top"
                       Cursor="TopSide"
                       Height="4" />
```

`DialogResizerThumb` works identically to `WindowResizerThumb` but binds
to the logical ancestor `OverlayFeedbackElement` instead of `Window`.

`DialogResizerThumb` 与 `WindowResizerThumb` 工作方式相同，但绑定到逻辑
祖先 `OverlayFeedbackElement` 而非 `Window`。

## Property Reference / 属性参考

### DialogResizer Properties / DialogResizer 属性

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `ResizeDirection` | `ResizeDirection` | `All` | Bitmask of allowed resize directions / 允许的调整方向位掩码 |

### WindowResizerThumb Properties / WindowResizerThumb 属性

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `ResizeDirection` | `ResizeDirection` | (required) | The edge/corner this thumb controls / 此手柄控制的边缘/角落 |

### DialogResizerThumb Properties / DialogResizerThumb 属性

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `ResizeDirection` | `ResizeDirection` | (required) | The edge/corner this thumb controls / 此手柄控制的边缘/角落 |

### ResizeDirection Enum / ResizeDirection 枚举

`ResizeDirection` is a `[Flags]` enum. Combine values with `,` in XAML
or `|` in code.

`ResizeDirection` 是 `[Flags]` 枚举。在 XAML 中用 `,` 组合，在代码中用 `|` 组合。

| Value | Bit | Edge/Corner / 边缘/角落 |
|---|---|---|
| `Top` | 1 | Top edge / 顶部边缘 |
| `Bottom` | 2 | Bottom edge / 底部边缘 |
| `Left` | 4 | Left edge / 左侧边缘 |
| `Right` | 8 | Right edge / 右侧边缘 |
| `TopLeft` | 16 | Top-left corner / 左上角 |
| `TopRight` | 32 | Top-right corner / 右上角 |
| `BottomLeft` | 64 | Bottom-left corner / 左下角 |
| `BottomRight` | 128 | Bottom-right corner / 右下角 |

| Composite Value | Composition / 组合 |
|---|---|
| `Sides` | `Top \| Bottom \| Left \| Right` |
| `Corners` | `TopLeft \| TopRight \| BottomLeft \| BottomRight` |
| `All` | `Sides \| Corners` |

### Cursor Mapping / 光标映射

Each `ResizeDirection` maps to a standard `WindowEdge` and cursor:

| ResizeDirection | WindowEdge | Cursor |
|---|---|---|
| `Top` | `North` | `TopSide` |
| `TopRight` | `NorthEast` | `TopRightCorner` |
| `Right` | `East` | `RightSide` |
| `BottomRight` | `SouthEast` | `BottomRightCorner` |
| `Bottom` | `South` | `BottomSide` |
| `BottomLeft` | `SouthWest` | `BottomLeftCorner` |
| `Left` | `West` | `LeftSide` |
| `TopLeft` | `NorthWest` | `TopLeftCorner` |

## Styling & Templating / 样式与模板

### Theme Keys / 主题 Key

| Theme Key | Description / 说明 |
|---|---|
| `{x:Type u:WindowResizer}` | 3×3 Grid with 8 WindowResizerThumb handles / 含 8 个 WindowResizerThumb 手柄的 3×3 网格 |
| `{x:Type u:WindowResizerThumb}` | Transparent background `PureRectangle` / 透明背景 PureRectangle |
| `{x:Type u:DialogResizer}` | 3×3 Grid with 8 DialogResizerThumb handles, named parts / 含 8 个命名 DialogResizerThumb 手柄的 3×3 网格 |
| `{x:Type u:DialogResizerThumb}` | Transparent background inside a `Panel` / 透明背景，包裹在 Panel 中 |

### Theme Resources / 主题资源

| Resource Key | Applies To | Description / 说明 |
|---|---|---|
| `ResizerThumbHeight` | Edge thumbs (top/bottom) | Height of horizontal edge resize handles / 水平边缘调整手柄的高度 |
| `ResizerThumbWidth` | Edge thumbs (left/right) | Width of vertical edge resize handles / 垂直边缘调整手柄的宽度 |

### Template Parts (DialogResizer) / 模板部件

| Part Name | Type | Description / 说明 |
|---|---|---|
| `PART_Top` | `DialogResizerThumb` | Top edge handle / 顶部边缘手柄 |
| `PART_Bottom` | `DialogResizerThumb` | Bottom edge handle / 底部边缘手柄 |
| `PART_Left` | `DialogResizerThumb` | Left edge handle / 左侧边缘手柄 |
| `PART_Right` | `DialogResizerThumb` | Right edge handle / 右侧边缘手柄 |
| `PART_TopLeft` | `DialogResizerThumb` | Top-left corner handle / 左上角手柄 |
| `PART_TopRight` | `DialogResizerThumb` | Top-right corner handle / 右上角手柄 |
| `PART_BottomLeft` | `DialogResizerThumb` | Bottom-left corner handle / 左下角手柄 |
| `PART_BottomRight` | `DialogResizerThumb` | Bottom-right corner handle / 右下角手柄 |

All 8 parts are resolved in `OnApplyTemplate` via `NameScope.Find<Thumb>()`.
Visibility is controlled by `ResizeDirection` flags: each thumb is shown only
when its corresponding flag is set.

全部 8 个部件在 `OnApplyTemplate` 中通过 `NameScope.Find<Thumb>()` 解析。
可见性由 `ResizeDirection` 标志控制：每个手柄仅在对应标志设置时显示。

## FAQ / 常见问题

**Q: How do I add resize to a custom Window? / 如何为自定义窗口添加调整大小功能？**
A: Add a `<u:WindowResizer />` as the last child in your window's root `Grid`.
Ensure the `Window` has `CanResize="True"` and `ExtendClientAreaToDecorationsHint`
set appropriately.

**Q: Can I limit resize directions on a dialog? / 可以限制对话框的调整方向吗？**
A: Yes. Set `ResizeDirection` on `DialogResizer` to a subset like `"Bottom, Right"`
or `"BottomRight"`.

**Q: Do resizer thumbs work with touch? / 调整手柄支持触摸吗？**
A: The current implementation only responds to left mouse button
(`Properties.IsLeftButtonPressed`). Touch support is noted as TODO in the source.

**Q: How do I change the thumb size? / 如何更改手柄大小？**
A: Override `ResizerThumbHeight` and `ResizerThumbWidth` resources in your
application theme.
