---
category: Feedback
title: Skeleton
subtitle: 骨架屏
description: >
  A placeholder loading control that displays a shimmer animation overlay while
  content is loading. Use Skeleton to mask content during async data fetches,
  reducing perceived latency with a smooth animated placeholder.
  占位加载控件，在内容加载时显示闪烁动画遮罩。使用 Skeleton 在异步数据获取时遮罩内容，
  通过平滑动画占位符降低感知延迟。
---

# Skeleton / 骨架屏

## When to Use / 何时使用

Use `Skeleton` when you need a shimmer-style placeholder that overlays content
while data is being fetched asynchronously. It wraps any child content and
shows an animated loading overlay (via `IsLoading`) together with an optional
shimmer effect (via `IsActive`). This is ideal for card layouts, list items,
tables, and any block-level content that benefits from a skeleton-screen UX
pattern.

当需要在异步获取数据时使用闪烁式占位符覆盖内容时，使用 `Skeleton`。它包裹任意
子内容，并通过 `IsLoading` 显示动画加载遮罩，配合可选的 `IsActive` 闪烁效果。
适用于卡片布局、列表项、表格及任何受益于骨架屏 UX 模式的块级内容。

Avoid `Skeleton` for inline spinners — use `Loading` or `LoadingIcon` instead.
Avoid `Skeleton` for page-level loading masks — use `LoadingContainer` instead.

避免将 `Skeleton` 用于行内旋转动画——应使用 `Loading` 或 `LoadingIcon`。
避免将 `Skeleton` 用于页面级别的加载遮罩——应使用 `LoadingContainer`。

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<!-- Skeleton wrapping a card -->
<u:Skeleton IsLoading="{Binding IsBusy}" IsActive="True">
    <Border Padding="16" Background="{DynamicResource SemiGrey0}">
        <StackPanel Spacing="8">
            <TextBlock Text="{Binding Title}" FontSize="18" FontWeight="Bold" />
            <TextBlock Text="{Binding Description}" TextWrapping="Wrap" />
        </StackPanel>
    </Border>
</u:Skeleton>
```

When `IsLoading` is `true` and `IsActive` is `true`, the content is overlaid
with a shimmer animation (the `PART_ActiveBorder` with a gradient sweep). When
`IsLoading` is `true` but `IsActive` is `false`, a static gray placeholder
(`PART_LoadingBorder`) covers the content instead.

当 `IsLoading` 为 `true` 且 `IsActive` 为 `true` 时，内容被闪烁动画覆盖
（`PART_ActiveBorder` 带渐变扫光）。当 `IsLoading` 为 `true` 但 `IsActive`
为 `false` 时，静态灰色占位符（`PART_LoadingBorder`）覆盖内容。

## Common Scenarios / 常用场景

### 1. List with skeleton items / 列表骨架项

```xml
<!-- Show skeleton cards while data loads -->
<ItemsControl ItemsSource="{Binding Items}">
    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <u:Skeleton IsLoading="{Binding IsStillLoading}" IsActive="True">
                <Border Padding="12" Classes="Card">
                    <StackPanel Spacing="4">
                        <TextBlock Text="{Binding Name}" />
                        <TextBlock Text="{Binding Summary}" />
                    </StackPanel>
                </Border>
            </u:Skeleton>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
</ItemsControl>
```

### 2. Static placeholder (no shimmer) / 静态占位（无闪烁）

```xml
<u:Skeleton IsLoading="{Binding IsBusy}" IsActive="False">
    <DataGrid ItemsSource="{Binding Rows}" />
</u:Skeleton>
```

### 3. Custom corner radius for the overlay / 自定义遮罩圆角

```xml
<u:Skeleton IsLoading="True" IsActive="True"
            CornerRadius="8"
            Background="Transparent">
    <Image Source="{Binding AvatarUrl}" Width="64" Height="64" />
</u:Skeleton>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `IsActive` | `bool` | `false` | Enables shimmer animation on the overlay (`PART_ActiveBorder`) / 启用遮罩闪烁动画 |
| `IsLoading` | `bool` | `false` | Shows/hides the loading overlay; also sets `IsHitTestVisible` on the overlay / 显示/隐藏加载遮罩；同时控制遮罩的命中测试 |

Inherits all properties from `ContentControl` (`Content`, `ContentTemplate`,
`Background`, `BorderBrush`, `BorderThickness`, `CornerRadius`, `ClipToBounds`,
`HorizontalContentAlignment`, `VerticalContentAlignment`, etc.).

继承 `ContentControl` 的全部属性。

## Events / 事件

No custom events. `Skeleton` is a `ContentControl` subclass and supports
standard pointer and property-changed events.

没有自定义事件。`Skeleton` 继承自 `ContentControl`，支持标准指针和属性变更事件。

## Styling & Templating / 样式与模板

### Theme Key / 主题 Key

| Theme Key | Description / 说明 |
|---|---|
| `{x:Type u:Skeleton}` | Default theme — transparent background, two overlay layers / 默认主题——透明背景，双层遮罩 |

### Pseudo-classes / 伪类

| Pseudo-class | Condition / 条件 |
|---|---|
| `:active` | Set when `IsActive` is `true` (applied to `PART_LoadingBorder` via `Classes.Active`) |

### Template Parts / 模板部件

| Part Name | Type | Description / 说明 |
|---|---|---|
| `PART_ContentPresenter` | `ContentPresenter` | Hosts the wrapped content / 承载被包裹的内容 |
| `PART_LoadingBorder` | `PureRectangle` | Static gray overlay; visible when `IsLoading` is `true` / 静态灰色遮罩；IsLoading 为 true 时可见 |
| `PART_ActiveBorder` | `PureRectangle` | Shimmer overlay; visible when `IsLoading` is `true`, animated when `IsActive` is `true` / 闪烁遮罩；IsLoading 为 true 时可见，IsActive 为 true 时动画播放 |

### Theme Resources / 主题资源

| Resource Key | Description / 说明 |
|---|---|
| `SkeletonDefaultBackground` | Background brush for `PART_LoadingBorder` / PART_LoadingBorder 的背景画刷 |

## FAQ / 常见问题

**Q: What's the difference between IsActive and IsLoading? / IsActive 和 IsLoading 的区别？**
A: `IsLoading` controls whether the overlay is shown at all. `IsActive`
controls whether the shimmer animation plays on top. When `IsLoading` is
`false`, neither overlay is visible regardless of `IsActive`.

**Q: How do I style the shimmer color? / 如何自定义闪烁颜色？**
A: Override the `PART_ActiveBorder` style in your application theme, or
customize the `SkeletonDefaultBackground` resource for the static layer.

**Q: Can I use Skeleton without content? / 可以不包裹内容使用 Skeleton 吗？**
A: Yes, but it's less useful — the overlay renders over nothing. For a
standalone placeholder rectangle, just set `Content` to an empty `Border`
with the desired dimensions.

```xml
<u:Skeleton IsLoading="True" IsActive="True" Width="200" Height="20" />
```
