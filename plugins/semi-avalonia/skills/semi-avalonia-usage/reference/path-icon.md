---
category: Components
title: PathIcon
subtitle: 路径图标
description: 基于路径几何数据渲染的可缩放矢量图标控件。
---

# PathIcon / 路径图标

A lightweight control that renders a vector icon from a `Geometry` path. `PathIcon` inherits from `IconElement` and renders the geometry using the current `Foreground` brush. It is resolution-independent and scales cleanly at any size — ideal for toolbars, buttons, menu items, and status indicators.

基于 `Geometry` 路径数据渲染矢量图标的轻量控件。`PathIcon` 继承自 `IconElement`，使用当前 `Foreground` 画刷渲染几何图形。它是分辨率无关的，可在任何尺寸下清晰缩放 —— 适用于工具栏、按钮、菜单项和状态指示器。

## When to Use / 何时使用

Use `PathIcon` whenever you need a monochrome vector icon that inherits its color from the foreground. It is the standard icon control in Avalonia and Semi.Avalonia — used in `Button.Content`, `MenuItem.Icon`, `TextBox` inner buttons (password reveal, clear), and `DataValidationErrors` error indicators. For multi-color or complex SVG icons, consider `Image` with an SVG library instead.

当你需要一个会从前景色继承颜色的单色矢量图标时使用 `PathIcon`。它是 Avalonia 和 Semi.Avalonia 中的标准图标控件 —— 用于 `Button.Content`、`MenuItem.Icon`、`TextBox` 内部按钮（密码显示/隐藏、清除）以及 `DataValidationErrors` 错误指示器。对于多色或复杂的 SVG 图标，考虑使用 `Image` 配合 SVG 库。

## Basic Usage / 基本使用

```xml
<!-- Using a StreamGeometry path -->
<PathIcon Data="{StaticResource HomeIconGeometry}"
          Width="24" Height="24" />
```

```xml
<!-- Inline geometry -->
<PathIcon Width="16" Height="16">
    <PathIcon.Data>
        <StreamGeometry>M12,4A4,4 0 0,1 16,8A4,4 0 0,1 12,12A4,4 0 0,1 8,8A4,4 0 0,1 12,4M12,14C16.42,14 20,15.79 20,18V20H4V18C4,15.79 7.58,14 12,14Z</StreamGeometry>
    </PathIcon.Data>
</PathIcon>
```

```csharp
// Programmatic creation
var icon = new PathIcon
{
    Data = Geometry.Parse("M12,4A4,4 0 0,1 16,8A4,4 0 0,1 12,12A4,4 0 0,1 8,8A4,4 0 0,1 12,4M12,14C16.42,14 20,15.79 20,18V20H4V18C4,15.79 7.58,14 12,14Z"),
    Width = 24,
    Height = 24
};
```

## Common Scenarios / 常用场景

### Icon Button / 图标按钮

Use `PathIcon` as `Button.Content` of a plain `Button`. Semi ships a ControlTheme variant for
compact icon-only buttons — its key is listed in the generated `semi-avalonia` skill.

```xml
<Button Width="32" Height="32">
    <PathIcon Data="{StaticResource CloseIconGeometry}"
              Width="16" Height="16" />
</Button>
```

### Menu Item Icon / 菜单项图标

Set `PathIcon` as `MenuItem.Icon`.

```xml
<MenuItem Header="Save">
    <MenuItem.Icon>
        <PathIcon Data="{StaticResource SaveIconGeometry}"
                  Width="16" Height="16" />
    </MenuItem.Icon>
</MenuItem>
```

### TextBox Inner Icon / 文本框内部图标

A `PathIcon` placed inside `TextBox` adornments works the same way; Semi defines an inner-icon
ControlTheme variant for it (see the generated `semi-avalonia` skill).

```xml
<PathIcon Data="{StaticResource SearchIconGeometry}"
          Width="16" Height="16" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Data` | `Geometry?` | The geometry data that defines the icon shape. Typically a `StreamGeometry` string. / 定义图标形状的几何数据。通常是 `StreamGeometry` 字符串。 |
| `Width` | `double` | The rendered width of the icon. / 图标的渲染宽度。 |
| `Height` | `double` | The rendered height of the icon. / 图标的渲染高度。 |
| `Foreground` | `IBrush?` | The brush used to fill the icon. The geometry is filled with this color. / 用于填充图标的画刷。几何图形使用此颜色填充。 |
| `IsEnabled` | `bool` | Whether the icon is enabled; disabled icons are rendered at reduced opacity. Inherited from `InputElement`. / 图标是否启用；禁用的图标以降低的不透明度渲染。继承自 `InputElement`。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How do I color a PathIcon? / 如何给 PathIcon 上色？**

A: Set the `Foreground` property to any `IBrush`. `PathIcon` fills the geometry with the foreground color. For Semi themes, use one of the brushes listed in the `semi-avalonia` skill's token reference. `PathIcon` is inherently monochrome — for multi-color icons, use `Image` with an SVG or bitmap source.

A: 设置 `Foreground` 属性为任意 `IBrush`。`PathIcon` 使用前景色填充几何图形。对于 Semi 主题，使用 `semi-avalonia` skill 的 token 参考中列出的笔刷。`PathIcon` 本质上是单色的 —— 多色图标请使用 `Image` 配合 SVG 或位图源。

**Q: What geometry format does Data accept? / Data 接受什么几何格式？**

A: `Data` is of type `Geometry`. Most commonly, you provide a `StreamGeometry` path string in the format `M x,y ... Z`. These are compact mini-language strings that define move, line, curve, and close commands. You can also assign `PathGeometry`, `EllipseGeometry`, `RectangleGeometry`, or any `Geometry` subclass.

`Data` 的类型为 `Geometry`。最常见的是提供格式为 `M x,y ... Z` 的 `StreamGeometry` 路径字符串。这些是紧凑的迷你语言字符串，定义了移动、线条、曲线和闭合命令。也可以分配 `PathGeometry`、`EllipseGeometry`、`RectangleGeometry` 或任何 `Geometry` 子类。

**Q: How do I make a clickable PathIcon? / 如何制作可点击的 PathIcon？**

A: Wrap `PathIcon` in a `Button` — do not attach click handlers directly to `PathIcon`. For icon-only buttons, Semi ships an icon-button ControlTheme variant; load the generated `semi-avalonia` skill and use its catalog instead of guessing the key. `PathIcon` itself does not have a `Click` event or `Command` property.

将 `PathIcon` 包装在 `Button` 中 —— 不要直接将点击处理程序附加到 `PathIcon`。对于仅图标按钮，Semi 提供了图标按钮 ControlTheme 变体；请加载生成的 `semi-avalonia` skill 并以其清单为准，不要凭记忆猜键名。`PathIcon` 本身没有 `Click` 事件或 `Command` 属性。

**Q: How does PathIcon relate to IconElement? / PathIcon 与 IconElement 的关系是什么？**

A: `IconElement` is the abstract base class for icon controls in Avalonia. `PathIcon` is its primary concrete implementation, rendering vector geometry. `IconElement` provides the framework-level icon infrastructure (size, scaling, and accessibility), while `PathIcon` adds the `Data` property and geometry rendering.

`IconElement` 是 Avalonia 中图标控件的抽象基类。`PathIcon` 是其主要的具象实现，渲染矢量几何图形。`IconElement` 提供框架级别的图标基础设施（尺寸、缩放和无障碍功能），而 `PathIcon` 增加了 `Data` 属性和几何渲染。
