---
category: Components
title: Marquee
subtitle: 跑马灯
description: >
  Scrolls wrapped content continuously in a configurable direction (left, right,
  up, or down) at a given speed. Content is displayed inside a clipped canvas;
  the marquee auto-loops when content moves out of bounds. Supports alignment
  and start/stop control via IsRunning.
  以可配置方向和给定速度连续滚动包裹的内容。内容显示在裁剪的画布内；当内容移出
  边界时自动循环。支持对齐方式以及通过 IsRunning 进行启停控制。
---

# Marquee / 跑马灯

## When to Use / 何时使用

Use `Marquee` to create a continuously scrolling text or content display —
suitable for news tickers, notification bars, stock tickers, or any horizontal
or vertical scrolling banner. The content is wrapped in a `Canvas` and animates
using a timer-based position update.

使用 `Marquee` 创建连续滚动的文字或内容显示——适用于新闻滚动条、通知栏、股票
行情或任何水平/垂直滚动横幅。内容包裹在 `Canvas` 中，通过基于计时器的位置
更新来实现动画。

Do NOT use `Marquee` for user-scrollable content — use `ScrollViewer` instead.
`Marquee` is for automatic, non-interactive scrolling.

不要将 `Marquee` 用于用户可滚动的内容——应使用 `ScrollViewer`。`Marquee`
用于自动、非交互式的滚动。

## Basic Usage / 基本使用

### Horizontal text ticker / 水平文字滚动

```xml
xmlns:u="https://irihi.tech/ursa"

<u:Marquee
    Height="40"
    Content="Breaking news: Ursa.Avalonia v1.0 released!"
    Direction="Left"
    Speed="80" />
```

### All four directions / 四个方向

```xml
<!-- Scroll left (default) -->
<u:Marquee Direction="Left" Content="Scrolling left..." />

<!-- Scroll right -->
<u:Marquee Direction="Right" Content="Scrolling right..." />

<!-- Scroll up -->
<u:Marquee Direction="Up" Content="Scrolling up..." />

<!-- Scroll down -->
<u:Marquee Direction="Down" Content="Scrolling down..." />
```

### Complex content / 复杂内容

```xml
<u:Marquee Direction="Right" Speed="60">
    <StackPanel Orientation="Horizontal" Spacing="16">
        <TextBlock Text="Item A" />
        <TextBlock Text="Item B" />
        <TextBlock Text="Item C" />
    </StackPanel>
</u:Marquee>
```

Since `Marquee` extends `ContentControl`, any control tree can be used as content.

由于 `Marquee` 继承自 `ContentControl`，任何控件树都可以作为内容使用。

## Common Scenarios / 常用场景

### 1. News ticker / 新闻滚动条

```xml
<u:Marquee
    Height="36"
    Direction="Left"
    Speed="100"
    Background="{DynamicResource SemiBlue1}"
    Foreground="{DynamicResource SemiColorPrimary}">
    <TextBlock Text="{Binding HeadlineText}" />
</u:Marquee>
```

### 2. Vertical notification banner / 垂直通知横幅

```xml
<u:Marquee
    Height="120"
    Direction="Up"
    Speed="40"
    VerticalContentAlignment="Center">
    <StackPanel Spacing="8">
        <TextBlock Text="Notice 1: System maintenance at 2 AM" />
        <TextBlock Text="Notice 2: Please save your work" />
        <TextBlock Text="Notice 3: New feature deployed" />
    </StackPanel>
</u:Marquee>
```

### 3. Start/stop control / 启停控制

```xml
<StackPanel>
    <u:Marquee
        Name="ticker"
        Content="{Binding Message}"
        Direction="Left"
        Speed="60"
        IsRunning="{Binding IsTickerRunning}" />
    <ToggleSwitch IsChecked="{Binding IsTickerRunning}" Content="Run" />
</StackPanel>
```

Set `IsRunning="False"` to pause the marquee; the content stays at its current
position.

设置 `IsRunning="False"` 可暂停跑马灯；内容保持在当前位置。

### 4. Aligned content / 对齐内容

```xml
<u:Marquee
    Direction="Up"
    Height="80"
    HorizontalContentAlignment="Center"
    VerticalContentAlignment="Center"
    Speed="50">
    <TextBlock Text="Centered scrolling text" />
</u:Marquee>
```

`HorizontalContentAlignment` and `VerticalContentAlignment` control how content
is positioned along the non-scrolling axis.

`HorizontalContentAlignment` 和 `VerticalContentAlignment` 控制内容在非滚动
轴上的定位方式。

## Property Reference / 属性参考

### Marquee Properties / Marquee 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `IsRunning` | `bool` | `true` | Start/stop the scrolling animation / 启动/停止滚动动画 |
| `Direction` | `Direction` | `Left` | Scrolling direction / 滚动方向 |
| `Speed` | `double` | `60.0` | Scrolling speed in points per second (coerced to ≥0) / 滚动速度，单位为点/秒（强制 ≥0） |
| `Content` | `object?` | `null` | Content to scroll (inherited from `ContentControl`) / 要滚动的内容（继承自 `ContentControl`） |
| `ContentTemplate` | `IDataTemplate?` | `null` | Template for the content / 内容模板 |
| `HorizontalContentAlignment` | `HorizontalAlignment` | `Center` | Horizontal alignment of content on the non-scrolling axis / 内容在非滚动轴上的水平对齐 |
| `VerticalContentAlignment` | `VerticalAlignment` | `Center` | Vertical alignment of content on the non-scrolling axis / 内容在非滚动轴上的垂直对齐 |

### Direction Enum / Direction 枚举

| Value | Description / 说明 |
|---|---|
| `Left` | Scroll from right to left / 从右向左滚动 |
| `Right` | Scroll from left to right / 从左向右滚动 |
| `Up` | Scroll from bottom to top / 从下向上滚动 |
| `Down` | Scroll from top to bottom / 从上向下滚动 |

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

No custom resource keys are defined. Standard `Background`, `BorderBrush`,
`CornerRadius`, and `BorderThickness` are forwarded via `TemplateBinding`.

未定义自定义资源键。标准的 `Background`、`BorderBrush`、`CornerRadius` 和
`BorderThickness` 通过 `TemplateBinding` 转发。

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_ContentPresenter` | `Marquee` | `ContentPresenter` |

### Pseudoclasses / 伪类

_(none defined)_ / 未定义伪类。

### Behavior Notes / 行为说明

- `ClipToBounds` is overridden to `true` so content outside the marquee bounds
  is hidden.
- `ClipToBounds` 被覆盖为 `true`，因此超出跑马灯边界的内容会被隐藏。
- The timer runs at ~60 fps (`1000/60.0` ms interval) and updates position via
  `Dispatcher.UIThread.Post` at render priority.
- 计时器以约 60 fps（`1000/60.0` 毫秒间隔）运行，并通过渲染优先级的
  `Dispatcher.UIThread.Post` 更新位置。
- When content moves fully out of bounds, it wraps around to the opposite side.
- 当内容完全移出边界时，会从另一侧重新进入。

## FAQ / 常见问题

**Q: How do I make the marquee scroll faster? / 如何让跑马灯滚动更快？**
A: Increase the `Speed` property. Speed is measured in points per second;
higher values move content faster. A typical fast ticker uses 100–200.

增大 `Speed` 属性值。速度以点/秒为单位；值越大内容移动越快。典型的快速滚动
使用 100–200。

**Q: Why doesn't my content scroll? / 为什么我的内容不滚动？**
A: Check that `IsRunning` is `true` (default) and that the content is larger
than the marquee bounds. If content fits inside, it won't need to scroll.
Also ensure `Speed` is non-negative.

检查 `IsRunning` 是否为 `true`（默认值），以及内容是否大于跑马灯边界。如果
内容适合显示区域，则无需滚动。同时确保 `Speed` 为非负值。

**Q: Can Marquee scroll images? / Marquee 可以滚动图片吗？**
A: Yes. Since `Marquee` accepts any `ContentControl` content, you can place
`Image` controls or any visual tree inside it.

可以。由于 `Marquee` 接受任何 `ContentControl` 内容，可以在其中放置 `Image`
控件或任何可视树。

**Q: How does the loop-back work? / 回环如何工作？**
A: When content scrolls past the boundary in the movement direction, its
position is reset to the opposite edge, creating a seamless loop. For example,
`Direction="Down"`: when `top > bounds.height`, position resets to
`-presenterSize.height`.

当内容在运动方向上滚出边界时，其位置会重置到对面边缘，形成无缝循环。例如，
`Direction="Down"`：当 `top > bounds.height` 时，位置重置为
`-presenterSize.height`。
