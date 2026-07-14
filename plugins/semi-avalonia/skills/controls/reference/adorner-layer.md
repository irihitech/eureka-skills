---
category: Components
title: AdornerLayer
subtitle: 装饰层
description: 用于在控件上方渲染装饰元素（如图标、指示器、拖拽预览）的叠加层控件。
---

# AdornerLayer / 装饰层

An overlay layer that renders adorners — visual decorations such as icons, indicators, drag previews, and selection handles — on top of a control. `AdornerLayer` is part of Avalonia's visual layer system and is managed by `VisualLayerManager`. Adorners are rendered in a separate layer above all standard content, ensuring they always appear on top.

渲染装饰元素（如图标、指示器、拖拽预览和选择手柄等视觉装饰）的叠加层控件。`AdornerLayer` 是 Avalonia 视觉层系统的一部分，由 `VisualLayerManager` 管理。装饰器在独立于所有标准内容之上的层中渲染，确保它们始终显示在最上层。

## When to Use / 何时使用

Use `AdornerLayer` when you need to render visual elements that must appear above all other content in a container — drag-and-drop previews, resize handles, focus cues, validation icons, or tooltip overlays. In most applications you do not create `AdornerLayer` directly; instead, you attach adorners to existing `AdornerLayer` instances via `AdornerLayer.GetAdornerLayer(visual)`.

当你需要在容器中渲染必须显示在所有其他内容之上的视觉元素时使用 `AdornerLayer` —— 拖放预览、调整大小手柄、焦点提示、验证图标或工具提示覆盖层。在大多数应用程序中，你不需要直接创建 `AdornerLayer`；而是通过 `AdornerLayer.GetAdornerLayer(visual)` 将装饰器附加到现有的 `AdornerLayer` 实例。

## Basic Usage / 基本使用

```csharp
// Get the AdornerLayer for a visual
var layer = AdornerLayer.GetAdornerLayer(myControl);
if (layer != null)
{
    // Create an adorner control
    var adorner = new Border
    {
        Background = Brushes.Red,
        Width = 16,
        Height = 16,
        CornerRadius = new CornerRadius(8)
    };

    // Add the adorner, positioned relative to the adorned element
    AdornerLayer.SetAdornedElement(adorner, myControl);
    layer.Children.Add(adorner);
}
```

```csharp
// Remove an adorner
layer.Children.Remove(adorner);
```

## Common Scenarios / 常用场景

### Drag-and-Drop Preview / 拖放预览

Show a semi-transparent preview of a dragged item following the cursor.

```csharp
var layer = AdornerLayer.GetAdornerLayer(dropTarget);
var preview = new Border
{
    Opacity = 0.7,
    Background = Brushes.LightGray,
    Child = new TextBlock { Text = "Dragging..." }
};
AdornerLayer.SetAdornedElement(preview, dropTarget);
layer.Children.Add(preview);

// Update position during drag
Canvas.SetLeft(preview, pointerX);
Canvas.SetTop(preview, pointerY);
```

### Validation Error Indicator / 验证错误指示器

Attach a red error dot to a control when validation fails.

```csharp
public static void ShowErrorAdorner(Control target)
{
    var layer = AdornerLayer.GetAdornerLayer(target);
    if (layer == null) return;

    var errorDot = new Border
    {
        Width = 10,
        Height = 10,
        CornerRadius = new CornerRadius(5),
        Background = Brushes.Red,
        Margin = new Thickness(-5, -5, 0, 0) // top-left corner
    };
    AdornerLayer.SetAdornedElement(errorDot, target);
    layer.Children.Add(errorDot);
}
```

### Selection Handles / 选择手柄

Draw resize handles around a selected element in a designer or canvas.

```csharp
var layer = AdornerLayer.GetAdornerLayer(canvas);
foreach (var handle in CreateSelectionHandles(selectedElement))
{
    AdornerLayer.SetAdornedElement(handle, selectedElement);
    layer.Children.Add(handle);
}
```

## Property Reference / 属性参考

`AdornerLayer` is a `Panel` subclass. Key members:

| Member / 成员 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Children` | `Controls` | Collection of adorner controls in this layer. Inherited from `Panel`. / 此层中的装饰器控件集合。继承自 `Panel`。 |
| `AdornedElement` (attached) | `Visual` | The element an adorner is associated with, for positioning. / 装饰器所关联的元素，用于定位。 |

### Static Methods / 静态方法

| Method / 方法 | Description / 说明 |
| --- | --- |
| `GetAdornerLayer(Visual)` | Returns the `AdornerLayer` for a given visual, if one exists in its `VisualLayerManager`. / 返回给定可视元素的 `AdornerLayer`（如果其 `VisualLayerManager` 中存在）。 |
| `SetAdornedElement(Visual, Visual)` | Associates an adorner with the element it decorates (for positioning). / 将装饰器与其装饰的元素关联（用于定位）。 |
| `GetAdornedElement(Visual)` | Returns the adorned element for a given adorner visual. / 返回给定装饰器视觉元素的被装饰元素。 |

## Styling & Templating / 样式与模板

### Relationship with VisualLayerManager / 与 VisualLayerManager 的关系

`AdornerLayer` is managed by `VisualLayerManager`, which is included in the `Window` and `EmbeddableControlRoot` control templates via the `PART_VisualLayerManager` part. Each `TopLevel` (Window) has a `VisualLayerManager` that hosts an `AdornerLayer` as one of its managed layers.

`AdornerLayer` 由 `VisualLayerManager` 管理，后者通过 `PART_VisualLayerManager` 部件包含在 `Window` 和 `EmbeddableControlRoot` 控件模板中。每个 `TopLevel`（Window）都有一个 `VisualLayerManager`，其中托管一个 `AdornerLayer` 作为其管理的层之一。

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_VisualLayerManager` (in Window/EmbeddableControlRoot) | `VisualLayerManager` | Hosts the `AdornerLayer` and manages its z-order. / 托管 `AdornerLayer` 并管理其 Z 顺序。 |

### Z-Order / Z 顺序

Adorners are always rendered on top of normal content. Within the `AdornerLayer`, the z-order follows the `Children` collection order: later children appear on top of earlier ones.

装饰器始终渲染在普通内容之上。在 `AdornerLayer` 内部，Z 顺序遵循 `Children` 集合顺序：后面的子元素显示在前面的子元素之上。

### Special ControlThemes / 特殊控件主题

Semi.Avalonia defines the `AdornerLayerBorder` theme in `AdornerLayer.axaml` for focus-adorner border styling.

Semi.Avalonia 在 `AdornerLayer.axaml` 中定义了 `AdornerLayerBorder` 主题，用于焦点装饰器边框样式。

#### `AdornerLayerBorder`

**TargetType:** `Border`
**Resource Key:** `AdornerLayerBorder`

A `Border` theme used by focus adorners throughout the Semi.Avalonia theme system. It is referenced in the default `AdornerLayer` theme's `DefaultFocusAdorner` template and is also used by `SolidSplitButton` and `ToggleSplitButton` (via `FocusAdornerTemplate`). Applies semi-transparent border styling from `AdornerLayerBorderBrush` with a configurable `AdornerLayerBorderThickness` and `AdornerLayerCornerRadius`. Supports a `.Solid` class selector that switches to `AdornerLayerSolidBorderBrush` for high-contrast focus indication on solid-background controls.

一个在整个 Semi.Avalonia 主题系统中被焦点装饰器使用的 `Border` 主题。它在默认 `AdornerLayer` 主题的 `DefaultFocusAdorner` 模板中被引用，也被 `SolidSplitButton` 和 `ToggleSplitButton`（通过 `FocusAdornerTemplate`）使用。应用来自 `AdornerLayerBorderBrush` 的半透明边框样式，带有可配置的 `AdornerLayerBorderThickness` 和 `AdornerLayerCornerRadius`。支持 `.Solid` 类选择器，切换为 `AdornerLayerSolidBorderBrush`，用于实色背景控件上的高对比度焦点指示。

```xml
<!-- Used internally by focus adorners; can be referenced for custom focus styles -->
<Border Theme="{StaticResource AdornerLayerBorder}" />

<!-- Solid variant for high-contrast focus -->
<Border Theme="{StaticResource AdornerLayerBorder}" Classes="Solid" />
```

**Key resources:** `AdornerLayerBorderThickness`, `AdornerLayerBorderBrush`, `AdornerLayerCornerRadius`, `AdornerLayerSolidBorderBrush`

**Class selectors:** `.Solid` — switches border brush to `AdornerLayerSolidBorderBrush`

## FAQ / 常见问题

**Q: Do I need to create an AdornerLayer manually? / 我需要手动创建 AdornerLayer 吗？**

A: No. Each `Window` and `EmbeddableControlRoot` already includes a `VisualLayerManager` with an `AdornerLayer` in its control template. Use `AdornerLayer.GetAdornerLayer(visual)` to retrieve the existing layer. Only create one manually if you are building a custom `TopLevel` or a custom hosted control root.

不需要。每个 `Window` 和 `EmbeddableControlRoot` 的控件模板中已经包含一个带有 `AdornerLayer` 的 `VisualLayerManager`。使用 `AdornerLayer.GetAdornerLayer(visual)` 获取现有层。仅在构建自定义 `TopLevel` 或自定义托管控件根时才需要手动创建。

**Q: How do I position an adorner relative to its adorned element? / 如何相对于被装饰元素定位装饰器？**

A: Set `AdornerLayer.SetAdornedElement(adorner, target)`. The adorner's position in the `AdornerLayer` will be automatically updated to follow the target element. You can use `Canvas.Left`/`Canvas.Top` or `Margin` on the adorner to add offsets from the target's origin.

设置 `AdornerLayer.SetAdornedElement(adorner, target)`。装饰器在 `AdornerLayer` 中的位置会自动更新以跟随目标元素。可以在装饰器上使用 `Canvas.Left`/`Canvas.Top` 或 `Margin` 来添加相对于目标原点的偏移。

**Q: Can adorners receive input events? / 装饰器可以接收输入事件吗？**

A: Yes. Adorners are full `Visual` or `Control` instances in the visual tree and can handle pointer, keyboard, and focus events. However, they sit in a separate layer, so hit-testing may behave differently depending on how the `AdornerLayer` is configured. Set `IsHitTestVisible="True"` on your adorner if you need interaction.

可以。装饰器是视觉树中完整的 `Visual` 或 `Control` 实例，可以处理指针、键盘和焦点事件。不过它们位于独立层中，因此命中测试的行为可能因 `AdornerLayer` 的配置而异。如需交互，在装饰器上设置 `IsHitTestVisible="True"`。
