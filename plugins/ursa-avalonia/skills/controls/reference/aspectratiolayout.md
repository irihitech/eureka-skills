---
category: Components
title: AspectRatioLayout
subtitle: 宽高比自适应布局
description: 根据容器宽高比自动切换显示内容的布局控件，支持按宽高比区间或宽高比模式匹配子项，并带交叉淡入淡出过渡动画。
---

## AspectRatioLayout / 宽高比自适应布局

A layout control that automatically switches its displayed content based on the container's current aspect ratio (width / height). Inherits from `TransitioningContentControl`. Each child `AspectRatioLayoutItem` defines when it should be shown — either by an `AspectRatioMode` enum (`Square`, `HorizontalRectangle`, `VerticalRectangle`) or by a numeric `StartAspectRatioValue`–`EndAspectRatioValue` range. Transitions between items use a cross-fade animation.

根据容器当前宽高比自动切换显示内容的布局控件。继承自 `TransitioningContentControl`。每个子 `AspectRatioLayoutItem` 定义其显示条件 —— 通过 `AspectRatioMode` 枚举（`Square`、`HorizontalRectangle`、`VerticalRectangle`）或数值区间 `StartAspectRatioValue`–`EndAspectRatioValue`。项目之间的切换使用交叉淡入淡出动画。

## When to Use / 何时使用

Use `AspectRatioLayout` when you need responsive layouts that change based on the container shape rather than just width breakpoints — for example, a media player that shows different controls for wide vs. tall windows, or a dashboard card that rearranges itself when the panel is resized.

当你需要根据容器形状而非仅宽度断点来改变响应式布局时使用 `AspectRatioLayout` —— 例如媒体播放器在宽窗与高窗之间显示不同控件，或仪表板卡片在面板调整大小时重新排列。

## Basic Usage / 基本使用

```xml
<u:AspectRatioLayout>
    <u:AspectRatioLayoutItem AcceptAspectRatioMode="HorizontalRectangle">
        <Button>Wide Layout</Button>
    </u:AspectRatioLayoutItem>
    <u:AspectRatioLayoutItem AcceptAspectRatioMode="VerticalRectangle">
        <Button>Tall Layout</Button>
    </u:AspectRatioLayoutItem>
    <u:AspectRatioLayoutItem AcceptAspectRatioMode="Square">
        <Button>Square Layout</Button>
    </u:AspectRatioLayoutItem>
</u:AspectRatioLayout>
```

## Common Scenarios / 常用场景

### Mode-based Matching / 基于模式的匹配

Use `AcceptAspectRatioMode` to switch on broad shape categories:

```xml
<u:AspectRatioLayout>
    <u:AspectRatioLayoutItem AcceptAspectRatioMode="HorizontalRectangle">
        <!-- Wide layout: horizontal stack -->
        <StackPanel Orientation="Horizontal" Spacing="8">
            <Border Background="Red" Width="200" Height="100" />
            <Border Background="Green" Width="200" Height="100" />
        </StackPanel>
    </u:AspectRatioLayoutItem>
    <u:AspectRatioLayoutItem AcceptAspectRatioMode="VerticalRectangle">
        <!-- Tall layout: vertical stack -->
        <StackPanel Orientation="Vertical" Spacing="8">
            <Border Background="Red" Width="100" Height="200" />
            <Border Background="Green" Width="100" Height="200" />
        </StackPanel>
    </u:AspectRatioLayoutItem>
</u:AspectRatioLayout>
```

### Numeric Range Matching / 数值区间匹配

Use `StartAspectRatioValue` and `EndAspectRatioValue` for fine-grained control:

```xml
<u:AspectRatioLayout>
    <!-- Ultra-wide: ratio >= 2.0 and < 2.2 -->
    <u:AspectRatioLayoutItem StartAspectRatioValue="2.0" EndAspectRatioValue="2.2">
        <TextBlock Text="Ultra-wide layout" />
    </u:AspectRatioLayoutItem>
    <!-- Wide: ratio >= 2.0 and < 2.4 -->
    <u:AspectRatioLayoutItem StartAspectRatioValue="2.0" EndAspectRatioValue="2.4">
        <TextBlock Text="Wide layout" />
    </u:AspectRatioLayoutItem>
    <!-- Narrow: ratio >= 1.3 and < 1.5 -->
    <u:AspectRatioLayoutItem StartAspectRatioValue="1.3" EndAspectRatioValue="1.5">
        <TextBlock Text="Narrow layout" />
    </u:AspectRatioLayoutItem>
</u:AspectRatioLayout>
```

Ranges are matched in order; the first matching item wins. If no range matches, falls back to `AcceptAspectRatioMode` matching, then to the first item as default.

### Adjusting Sensitivity / 调整灵敏度

Use `AspectRatioTolerance` to control the boundary between Square and Rectangle modes:

```xml
<u:AspectRatioLayout AspectRatioTolerance="0.15">
    <!-- Higher tolerance = wider "square" zone -->
</u:AspectRatioLayout>
```

The tolerance value (default `0.2`) defines how much the ratio can deviate from 1.0 and still be considered "Square". A ratio is Square when `1 - tolerance < ratio < 1 + tolerance`.

### Monitoring Aspect Ratio / 监控宽高比

Bind to `AspectRatioValue` to display the current ratio:

```xml
<u:AspectRatioLayout Name="layout" AspectRatioTolerance="0.2">
    <!-- items -->
</u:AspectRatioLayout>
<TextBlock Text="{Binding #layout.AspectRatioValue, StringFormat='Aspect Ratio: {0:F3}'}" />
```

## Property Reference / 属性参考

### AspectRatioLayout Properties / AspectRatioLayout 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Items` | `List<AspectRatioLayoutItem>` | Content collection. Each item defines a layout for a specific aspect ratio. / 内容集合。每个项目为特定宽高比定义布局。 |
| `AspectRatioTolerance` | `double` | Tolerance for the "Square" mode. Default `0.2`. Square = ratio within `[1 - tol, 1 + tol]`. / "Square" 模式的容差。默认 `0.2`。Square = 宽高比在 `[1 - tol, 1 + tol]` 范围内。 |
| `AspectRatioValue` | `double` | Read-only current aspect ratio (width / height). / 只读当前宽高比（宽/高）。 |
| `CurrentAspectRatioMode` | `AspectRatioMode` | Read-only current mode: `None`, `Square`, `HorizontalRectangle`, `VerticalRectangle`. / 只读当前模式。 |

### AspectRatioLayoutItem Properties / AspectRatioLayoutItem 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `AcceptAspectRatioMode` | `AspectRatioMode` | The aspect ratio mode this item targets. / 此项对应的宽高比模式。 |
| `StartAspectRatioValue` | `double` | Start of the numeric ratio range. Default `NaN` (disabled). / 数值宽高比区间起始值。默认 `NaN`（禁用）。 |
| `EndAspectRatioValue` | `double` | End of the numeric ratio range. Default `NaN` (disabled). / 数值宽高比区间结束值。默认 `NaN`（禁用）。 |
| `IsUseAspectRatioRange` | `bool` | Read-only. True when both Start and End are valid and Start ≤ End. / 只读。当 Start 和 End 均有效且 Start ≤ End 时为 true。 |
| `Content` | `object?` | The content to display (inherited from `ContentControl`). / 要显示的内容（继承自 `ContentControl`）。 |

### AspectRatioMode Enum / AspectRatioMode 枚举

| Value / 值 | Description / 说明 |
| --- | --- |
| `None` | No mode matched. Fallback to first item. / 无匹配模式。回退到第一个项目。 |
| `Square` | Ratio is within `[1 - tolerance, 1 + tolerance]`. / 宽高比在容差范围内的正方形区。 |
| `HorizontalRectangle` | Ratio ≥ `1 + tolerance` (wider than tall). / 宽大于高（横向矩形）。 |
| `VerticalRectangle` | Ratio ≤ `1 - tolerance` (taller than wide). / 高大于宽（纵向矩形）。 |

## Styling & Templating / 样式与模板

`AspectRatioLayout` uses the `TransitioningContentControl` style key and does not define its own `ControlTheme`. The default page transition is a `PCrossFade` with 0.55-second duration and `QuadraticEaseInOut` easing.

### Default Transition / 默认过渡

| Property / 属性 | Default / 默认值 |
| --- | --- |
| `PageTransition` | Cross-fade, 0.55s, QuadraticEaseInOut |
| `StyleKeyOverride` | `typeof(TransitioningContentControl)` |

## FAQ / 常见问题

**Q: How does matching priority work? / 匹配优先级如何工作？**

A: Items with valid `StartAspectRatioValue`–`EndAspectRatioValue` ranges are checked first, in declaration order. The first range containing the current ratio wins. If no range matches, items with `AcceptAspectRatioMode` matching the current mode are checked. If still no match, the first item in the collection is used as a fallback. / 首先按声明顺序检查具有有效 `StartAspectRatioValue`–`EndAspectRatioValue` 区间的项目。第一个包含当前宽高比的区间获胜。如果没有区间匹配，则检查 `AcceptAspectRatioMode` 匹配当前模式的项目。如果仍然没有匹配，则使用集合中的第一项作为回退。

**Q: Can I use AspectRatioLayout inside a Grid or other layout? / 可以在 Grid 或其他布局中使用吗？**

A: Yes. The control reacts to `BoundsProperty` changes, so any container that reports its bounds will trigger aspect ratio recalculation. For best results, ensure the parent provides a non-zero size. / 可以。控件响应 `BoundsProperty` 变化，因此任何报告其边界的容器都会触发宽高比重计算。为获得最佳效果，请确保父级提供非零尺寸。

**Q: How can I change the transition animation? / 如何更改过渡动画？**

A: Set the `PageTransition` property to a custom `IPageTransition` implementation. The default is a cross-fade. / 将 `PageTransition` 属性设置为自定义 `IPageTransition` 实现。默认为交叉淡入淡出。

```xml
<u:AspectRatioLayout>
    <u:AspectRatioLayout.PageTransition>
        <u:SlideTransition Duration="0:0:0.3" />
    </u:AspectRatioLayout.PageTransition>
    <!-- items -->
</u:AspectRatioLayout>
```
