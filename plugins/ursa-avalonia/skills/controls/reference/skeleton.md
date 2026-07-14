---
category: Components
title: Skeleton
subtitle: 骨架屏
description: >
  A placeholder loading indicator that wraps content and displays an animated
  shimmer overlay while data is being fetched. Supports active animation and
  loading state control.
  一种占位加载指示器，包裹内容并在数据加载时显示动画闪光叠加层。
  支持活动动画和加载状态控制。
---

# Skeleton / 骨架屏

## When to Use / 何时使用

Use `Skeleton` to show a placeholder animation while content is loading. It wraps
existing layout content and overlays a shimmer effect controlled by `IsLoading`
and `IsActive`. When `IsLoading` becomes `false`, the skeleton overlay hides and
the real content is revealed.

当内容正在加载时，使用 `Skeleton` 显示占位动画。它包裹现有布局内容，并通过
`IsLoading` 和 `IsActive` 控制闪光叠加效果。当 `IsLoading` 变为 `false` 时，
骨架覆盖层隐藏，真实内容显示。

Do NOT use `Skeleton` for progress bars or spinners — use `Loading` or
`ProgressBar` instead. `Skeleton` is a content wrapper, not a standalone
indicator.

不要将 `Skeleton` 用于进度条或旋转加载器——应使用 `Loading` 或 `ProgressBar`。
`Skeleton` 是内容包裹器，而非独立指示器。

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<!-- Wrap any content with a skeleton loading overlay -->
<u:Skeleton IsLoading="True" IsActive="True">
    <Border Padding="40" Background="{DynamicResource SemiColorFill0}">
        <StackPanel Spacing="8">
            <TextBlock Text="Title placeholder" />
            <TextBlock Text="Description text goes here" />
        </StackPanel>
    </Border>
</u:Skeleton>
```

Toggle `IsLoading` to `false` when data is ready — the skeleton overlay
disappears and the real content is shown.

数据就绪时将 `IsLoading` 切换为 `false`——骨架覆盖层消失，真实内容显示。

## Common Scenarios / 常用场景

### 1. Loading data card / 加载数据卡片

```xml
<u:Skeleton IsLoading="{Binding IsLoading}" IsActive="True">
    <Border Padding="16" Classes="Card">
        <StackPanel Spacing="8">
            <TextBlock Text="{Binding Title}" Classes="h3" />
            <TextBlock Text="{Binding Description}" />
        </StackPanel>
    </Border>
</u:Skeleton>
```

### 2. List loading state / 列表加载状态

```xml
<ItemsControl ItemsSource="{Binding Items}">
    <ItemsControl.ItemsPanel>
        <ItemsPanelTemplate>
            <StackPanel Spacing="8" />
        </ItemsPanelTemplate>
    </ItemsControl.ItemsPanel>
    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <u:Skeleton IsLoading="{Binding IsLoading}" IsActive="True">
                <Border Padding="12" Background="{DynamicResource SemiColorFill0}">
                    <TextBlock Text="{Binding Name}" />
                </Border>
            </u:Skeleton>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
</ItemsControl>
```

### 3. Without active animation / 无活动动画

```xml
<u:Skeleton IsLoading="True" IsActive="False">
    <Border Padding="40">
        <TextBlock Text="Content loading..." />
    </Border>
</u:Skeleton>
```

When `IsActive` is `false`, the skeleton overlay is static (no shimmer animation).
This is useful for low-motion preferences or simple loading states.

`IsActive` 为 `false` 时，骨架覆盖层为静态（无闪光动画）。适用于
低动态偏好或简单加载状态。

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `IsLoading` | `bool` | `false` | When `true`, shows the skeleton overlay / 为 `true` 时显示骨架覆盖层 |
| `IsActive` | `bool` | `false` | When `true`, enables shimmer animation on the overlay / 为 `true` 时启用覆盖层闪光动画 |

Inherits all properties from `ContentControl` (`Content`, `ContentTemplate`,
`Background`, `BorderBrush`, `BorderThickness`, `CornerRadius`, `ClipToBounds`,
`HorizontalContentAlignment`, `VerticalContentAlignment`, etc.).

继承 `ContentControl` 的全部属性。

## Styling & Templating / 样式与模板

### Theme Key / 主题 Key

| Theme Key | Description / 说明 |
|---|---|
| `{x:Type u:Skeleton}` | Default theme for the skeleton wrapper / 骨架包裹器的默认主题 |

### Theme Resources / 主题资源

| Resource Key | Applies To | Description / 说明 |
|---|---|---|
| `SkeletonDefaultBackground` | `PART_LoadingBorder` | Background brush for the loading overlay / 加载覆盖层的背景画刷 |

### Template Parts / 模板部件

| Part Name | Type | Description / 说明 |
|---|---|---|
| `PART_ContentPresenter` | `ContentPresenter` | Hosts the wrapped content / 承载包裹内容 |
| `PART_LoadingBorder` | `PureRectangle` | The loading overlay rectangle with Active pseudo-class / 带 Active 伪类的加载覆盖矩形 |
| `PART_ActiveBorder` | `PureRectangle` | The shimmer animation overlay (hit-test transparent when loading) / 闪光动画覆盖层（加载时点击穿透） |

### Pseudo-classes / 伪类

| Pseudo-class | Condition / 条件 |
|---|---|
| `:active` (on `PART_LoadingBorder`) | `IsActive == True` — enables shimmer animation / 启用闪光动画 |

The `PART_LoadingBorder` uses `Classes.Active` bound to `IsActive`, so the
`:active` pseudo-class applies the shimmer effect. Both `PART_LoadingBorder`
and `PART_ActiveBorder` are `IsHitTestVisible="{TemplateBinding IsLoading}"`,
preventing interaction with content underneath while loading.

`PART_LoadingBorder` 通过 `Classes.Active` 绑定到 `IsActive`，`:active` 伪类
应用闪光效果。两个覆盖层均设置 `IsHitTestVisible="{TemplateBinding IsLoading}"`，
加载时阻止与下方内容的交互。

## FAQ / 常见问题

**Q: How do I customize the skeleton color? / 如何自定义骨架颜色？**
A: Override `SkeletonDefaultBackground` in your application resources:
```xml
<SolidColorBrush x:Key="SkeletonDefaultBackground" Color="#E0E0E0" />
```

**Q: Can I disable the shimmer animation? / 可以禁用闪光动画吗？**
A: Yes. Set `IsActive="False"`. The overlay remains static (no shimmer).

**Q: Does the skeleton preserve layout size? / 骨架会保持布局尺寸吗？**
A: Yes. The wrapped content is always present in the visual tree (just hidden
behind the overlay). Layout measurements are based on the real content, so
the page does not jump when loading completes.
是的。包裹内容始终存在于可视化树中（只是隐藏在覆盖层后面）。布局测量基于真实
内容，因此加载完成时页面不会跳动。
