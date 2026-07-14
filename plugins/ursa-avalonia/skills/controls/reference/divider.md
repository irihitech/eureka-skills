---
category: Components
title: Divider
subtitle: 分割线
description: >
  A horizontal or vertical separator line with optional text content. Inherits
  from ContentControl so you can embed labels, icons, or any content in the
  divider. Supports horizontal (left/center/right/stretch content alignment)
  and vertical orientations.
  水平或垂直分割线，支持可选的文本内容。继承自 ContentControl，可在分割线中嵌入
  标签、图标或任意内容。支持水平（左/中/右/拉伸内容对齐）和垂直方向。
---

# Divider / 分割线

## When to Use / 何时使用

Use `Divider` to visually separate sections of content in a layout. With
horizontal orientation, it renders a line with optional content in the middle
(or aligned left/right). With vertical orientation, it renders a simple vertical
line — useful in toolbars or horizontal stacks.

使用 `Divider` 在布局中可视化分隔内容区域。水平方向时，它渲染一条线，可在中间
（或左/右对齐）放置可选内容。垂直方向时，它渲染一条简单的竖线——适用于工具栏或
水平堆叠。

## Basic Usage / 基本使用

### Horizontal Divider with Text / 带文字的水平分割线

```xml
<u:Divider Content="Section One" />
```

### Plain Horizontal Divider / 纯水平分割线

```xml
<u:Divider />
```

### Vertical Divider / 垂直分割线

```xml
<u:Divider Orientation="Vertical" Height="40" />
```

## Common Scenarios / 常用场景

### Content Alignment / 内容对齐

Control text alignment via `HorizontalContentAlignment`:

```xml
<!-- Text on the left -->
<u:Divider Content="Left-aligned" HorizontalContentAlignment="Left" />

<!-- Text centered (default) -->
<u:Divider Content="Centered" HorizontalContentAlignment="Center" />

<!-- Text on the right -->
<u:Divider Content="Right-aligned" HorizontalContentAlignment="Right" />

<!-- Stretch (same as Center) -->
<u:Divider Content="Stretch" HorizontalContentAlignment="Stretch" />
```

### Custom Content / 自定义内容

Since `Divider` extends `ContentControl`, you can embed any content:

```xml
<u:Divider>
    <PathIcon Data="{DynamicResource SomeIcon}" />
</u:Divider>
```

### In a StackPanel / 在 StackPanel 中使用

```xml
<StackPanel Spacing="12">
    <TextBlock Text="Section A" />
    <u:Divider />
    <TextBlock Text="Section B" />
    <u:Divider Content="OR" />
    <TextBlock Text="Section C" />
</StackPanel>
```

### Vertical Divider in a Toolbar / 工具栏中的垂直分割线

```xml
<StackPanel Orientation="Horizontal" Spacing="8">
    <Button Content="Save" />
    <u:Divider Orientation="Vertical" Height="24" />
    <Button Content="Delete" />
</StackPanel>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `Orientation` | `Orientation` | `Horizontal` | Line direction. / 线条方向。 |
| `HorizontalContentAlignment` | `HorizontalAlignment` | `Center` | Text/content horizontal alignment (inherited, default overridden). / 文本/内容的水平对齐（继承属性，默认值被覆盖）。 |

Inherited from `ContentControl`:

| Property | Type | Description / 说明 |
|---|---|---|
| `Content` | `object?` | Content displayed in the divider. / 分割线中显示的内容。 |
| `ContentTemplate` | `IDataTemplate?` | Template for content. / 内容模板。 |
| `Background` | `IBrush?` | Background of the content area. / 内容区域背景。 |
| `Foreground` | `IBrush?` | Foreground of the content. / 内容前景色。 |
| `FontSize` | `double` | Font size for text content. Default `14` in Semi theme. / 文本字号。Semi 主题默认为 `14`。 |

## Events / 事件

No custom events. Inherits standard `ContentControl` events.

无自定义事件。继承标准的 `ContentControl` 事件。

## Styling & Templating / 样式与模板

### ControlTheme Keys

| Theme Key | Target Type | Description / 说明 |
|---|---|---|
| `{x:Type u:Divider}` | `Divider` | Main divider theme. / 主分割线主题。 |
| `DividerLeftLine` | `Rectangle` | Left-side line style. / 左侧线条样式。 |
| `DividerRightLine` | `Rectangle` | Right-side line style. / 右侧线条样式。 |

### Theme Resources / 主题资源

| Resource Key | Applies To | Description / 说明 |
|---|---|---|
| `DividerBorderBrush` | Rectangle | Line color. / 线条颜色。 |
| `SizeDividerWidth` | Rectangle | Line thickness (height in horizontal, width in vertical). / 线条粗细（水平时为高度，垂直时为宽度）。 |
| `SizeDividerLeftMinWidth` | Rectangle | Minimum width of the left line segment. / 左侧线段最小宽度。 |
| `SizeDividerRightMinWidth` | Rectangle | Minimum width of the right line segment. / 右侧线段最小宽度。 |
| `ThicknessDividerTextMargin` | ContentPresenter | Margin around text content. / 文本内容周围的外边距。 |
| `SizeDividerVerticalHeight` | Rectangle | Default height for vertical divider. / 垂直分割线默认高度。 |
| `ThicknessDividerVerticalMargin` | Divider | Margin for vertical divider. / 垂直分割线外边距。 |

### Template Parts / 模板部件

No named template parts — the template uses inline `Rectangle` elements for lines
and a `ContentPresenter` for the content.

无命名模板部件——模板使用内联 `Rectangle` 元素绘制线条，使用 `ContentPresenter`
显示内容。

### Pseudo-classes / 伪类

| Pseudo-class | Description / 说明 |
|---|---|
| `[Orientation=Horizontal]` | Horizontal layout with line-content-line. / 水平布局：线条-内容-线条。 |
| `[Orientation=Vertical]` | Single vertical line (no content shown). / 单条竖线（不显示内容）。 |
| `[HorizontalContentAlignment=Left]` | Content on the left, line fills remaining space on the right. / 内容靠左，右侧线条填充剩余空间。 |
| `[HorizontalContentAlignment=Center]` | Content centered between two lines. / 内容居中，两侧各一条线。 |
| `[HorizontalContentAlignment=Right]` | Content on the right, line fills remaining space on the left. / 内容靠右，左侧线条填充剩余空间。 |
| `[HorizontalContentAlignment=Stretch]` | Same as `Center`. / 与 `Center` 相同。 |

## FAQ / 常见问题

**Q: Can I change the divider line color? / 可以更改分割线颜色吗？**
A: Override the `DividerBorderBrush` resource in your application resources:
```xml
<SolidColorBrush x:Key="DividerBorderBrush" Color="Red" />
```

**Q: Does the vertical divider support content? / 垂直分割线支持内容吗？**
A: No. When `Orientation="Vertical"`, the template renders only a single
`Rectangle` — no `ContentPresenter` is included. Use a horizontal divider or
a custom layout for vertical text.

**Q: How do I increase the line thickness? / 如何增加线条粗细？**
A: Override `SizeDividerWidth` (for horizontal lines) or use `Height`/`Width`
for the vertical orientation:
```xml
<u:Divider Orientation="Vertical" Width="2" />
```

**Q: Can I hide the lines and only show text? / 可以隐藏线条只显示文字吗？**
A: Override `DividerBorderBrush` to `Transparent` or use a plain `TextBlock`
instead. The divider is designed to always show lines alongside content.

**Q: What's the difference between Left, Center, Right, and Stretch alignment?**
A: `Left` places content on the left with line on the right. `Right` places
content on the right with line on the left. `Center` and `Stretch` both
center the content with lines on both sides. `Center` is the default.
