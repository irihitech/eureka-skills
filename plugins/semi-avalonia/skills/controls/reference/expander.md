---
category: Components
title: Expander
subtitle: 展开器
description: 展开器用于显示可折叠的内容区域，点击标题可展开或收起内容。
---

# Expander / 展开器

A control with a clickable header that expands or collapses a content area. Inherits from `HeaderedContentControl`. Supports expand direction and accordion patterns.

带有可点击标题的控件，可展开或收起内容区域。继承自 `HeaderedContentControl`。支持展开方向和手风琴模式。

## When to Use / 何时使用

Use `Expander` to show/hide content sections to reduce visual clutter — settings categories, help sections, collapsible sidebars, FAQ accordions. For automatic content switching, use `TabControl`.

使用 `Expander` 显示/隐藏内容区域以减轻视觉混乱。自动内容切换使用 `TabControl`。

## Basic Usage / 基本使用

```xml
<Expander Header="Advanced Settings">
    <StackPanel Spacing="8">
        <CheckBox Content="Enable logging" />
        <TextBox Watermark="Log path" />
    </StackPanel>
</Expander>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Header` | `object?` | The clickable header content. / 可点击的标题内容。 |
| `Content` | `object?` | The collapsible content. / 可折叠的内容。 |
| `IsExpanded` | `bool` | Whether content is visible (default `false`). / 内容是否可见。 |
| `ExpandDirection` | `ExpandDirection` | `Down`, `Up`, `Left`, `Right`. / 展开方向。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Expanded` | Content becomes visible. / 内容展开。 |
| `Collapsed` | Content becomes hidden. / 内容收起。 |

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlThemes / Semi.Avalonia 控件主题

Semi.Avalonia provides a specialised `ExpanderHeaderToggleButtonTheme` for the `ToggleButton` inside the Expander header. This theme strips all button chrome (no border, no background, no padding stack) and renders only a bare `ContentPresenter`, giving the header a clean, text-only appearance. The default `Expander` theme references it internally.

Semi.Avalonia 为 Expander 标题内的 `ToggleButton` 提供了一个专用的 `ExpanderHeaderToggleButtonTheme`。该主题剥离了所有按钮装饰（无边框、无背景、无内边距堆叠），仅渲染一个裸 `ContentPresenter`，使标题呈现简洁的文字外观。默认的 `Expander` 主题在内部引用了它。

```xml
<!-- The Expander header ToggleButton uses this theme internally -->
<ToggleButton Theme="{StaticResource ExpanderHeaderToggleButtonTheme}"
              IsChecked="{Binding IsExpanded, Mode=TwoWay}" />
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:expanded` | Content is visible; header icon rotated 180°. / 内容可见；标题图标旋转 180°。 |
| `:collapsed` | Content is hidden. / 内容已隐藏。 |
| `:right` | Expand direction is `Right`. / 展开方向为右。 |
| `:left` | Expand direction is `Left`. / 展开方向为左。 |
| `:up` | Expand direction is `Up`. / 展开方向为上。 |
| `:down` | Expand direction is `Down` (default). / 展开方向为下（默认）。 |
| `:disabled` | Control is disabled. / 控件已禁用。 |

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `ExpanderHeaderBackground` | Header background. / 标题背景。 |
| `ExpanderHeaderForeground` | Header text color. / 标题文字颜色。 |
| `ExpanderHeaderDefaultBackground` | Default header background. / 默认标题背景。 |
| `ExpanderHeaderHoverBackground` | Header background on pointer over. / 鼠标悬停时的标题背景。 |
| `ExpanderHeaderPressedBackground` | Header background when pressed. / 按下时的标题背景。 |
| `ExpanderHeaderDisabledForeground` | Header text color when disabled. / 禁用时的标题文字颜色。 |
| `ExpanderContentBackground` | Content area background. / 内容区域背景。 |
| `ExpanderContentForeground` | Content area text color. / 内容区域文字颜色。 |
| `ExpanderSeparatorBorderBrush` | Border/separator color. / 边框/分隔线颜色。 |
| `ExpanderIcon` | Chevron icon geometry. / 箭头图标几何数据。 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `ExpanderHeader` | `ToggleButton` | The clickable header toggle. Uses `ExpanderHeaderToggleButtonTheme`. / 可点击的标题切换按钮。使用 `ExpanderHeaderToggleButtonTheme`。 |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the collapsible content. / 渲染可折叠内容。 |
| `PART_PathIcon` | `PathIcon` | The expand/collapse chevron icon. / 展开/收起箭头图标。 |

## FAQ / 常见问题

**Q: How to create an accordion? / 如何创建手风琴效果？**

A: Bind each `Expander.IsExpanded` in a ViewModel group so expanding one collapses others. / 在 ViewModel 中绑定 `IsExpanded`，展开一个时收起其他的。