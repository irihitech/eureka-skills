---
category: Components
title: ThemeSelector / ThemeToggleButton
subtitle: 主题选择器/主题切换按钮
description: >
  A toggle button that switches the application or a scoped region between
  Light, Dark, and Default (system) theme variants. Supports Controller mode
  (drives theme changes) and Indicator mode (reflects the current theme). Can
  target a specific ThemeVariantScope or operate globally via the Application.
  一个切换按钮，可在 Light、Dark 和 Default（系统）主题变体之间切换应用程序或
  局部区域的主题。支持 Controller 模式（驱动主题变更）和 Indicator 模式（反映
  当前主题）。可指定目标 ThemeVariantScope 或通过 Application 全局操作。
---

# ThemeSelector / ThemeToggleButton / 主题选择器

## When to Use / 何时使用

Use `ThemeToggleButton` to let users toggle between light, dark, and system
(default) theme variants. It acts as a three-state button: Light, Dark, and
Default. Place it in toolbars, settings pages, or title bars.

使用 `ThemeToggleButton` 让用户在 Light、Dark 和系统（Default）主题变体之间切换。
它是一个三态按钮：Light、Dark 和 Default。可放置在工具栏、设置页面或标题栏中。

`ThemeToggleButton` inherits from `ThemeSelectorBase`, which handles the theme
synchronization logic. `ThemeSelectorBase` is an abstract `TemplatedControl` that
manages `SelectedTheme`, `TargetScope`, and `Mode` with proper two-way binding
between the selector and the scope.

`ThemeToggleButton` 继承自 `ThemeSelectorBase`，后者处理主题同步逻辑。
`ThemeSelectorBase` 是一个抽象的 `TemplatedControl`，它通过适当的两向绑定管理
`SelectedTheme`、`TargetScope` 和 `Mode`。

## Basic Usage / 基本使用

### Global Theme Toggle / 全局主题切换

```xml
xmlns:u="https://irihi.tech/ursa"

<u:ThemeToggleButton />
```

This toggles the application-wide `RequestedThemeVariant`. The button cycles
through Light → Dark → Default on each click.

这将在应用程序范围内切换 `RequestedThemeVariant`。每次单击时按钮依次循环
Light → Dark → Default。

### Indicator Mode / 指示器模式

```xml
<u:ThemeToggleButton Mode="Indicator" />
```

In `Indicator` mode the button only *reflects* the current theme — clicking does
not change it directly.

在 `Indicator` 模式下，按钮仅*反映*当前主题——单击不会直接更改主题。

### Two-State Toggle / 双态切换

```xml
<u:ThemeToggleButton IsThreeState="False" />
```

When `IsThreeState="False"`, the button toggles only between Light and Dark.

当 `IsThreeState="False"` 时，按钮仅在 Light 和 Dark 之间切换。

## Common Scenarios / 常用场景

### Target a Specific Scope / 指定目标作用域

```xml
<StackPanel>
    <u:ThemeToggleButton TargetScope="{Binding #scope}" />
    <ThemeVariantScope Name="scope" RequestedThemeVariant="Dark">
        <Border Theme="{DynamicResource CardBorder}">
            <Button Content="Hello World" />
        </Border>
    </ThemeVariantScope>
</StackPanel>
```

The `TargetScope` property binds to a `ThemeVariantScope` so the toggle only
affects that region, not the entire application.

`TargetScope` 属性绑定到 `ThemeVariantScope`，使切换仅影响该区域，而非整个应用。

### Auto-Detect Parent Scope / 自动检测父级作用域

If `TargetScope` is not set, the control walks up the logical tree to find the
nearest ancestor `ThemeVariantScope`. If none is found, it falls back to
`Application.Current`.

如果未设置 `TargetScope`，控件会沿逻辑树向上查找最近的祖先
`ThemeVariantScope`。如果未找到，则回退到 `Application.Current`。

## Property Reference / 属性参考

### ThemeSelectorBase Properties / ThemeSelectorBase 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedTheme` | `ThemeVariant?` | `null` | The currently selected theme variant (Light/Dark/Default). Two-way. / 当前选中的主题变体（Light/Dark/Default）。双向绑定。 |
| `Mode` | `ThemeSelectorMode` | `Controller` | Controller drives theme changes; Indicator only reflects. / Controller 驱动主题更改；Indicator 仅反映。 |
| `TargetScope` | `ThemeVariantScope?` | `null` | Specific scope to target. If null, auto-detects or uses Application. / 要指定的目标作用域。如果为 null，自动检测或使用 Application。 |

### ThemeToggleButton Properties / ThemeToggleButton 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `IsThreeState` | `bool` | `true` | When true, cycles Light→Dark→Default. When false, only Light↔Dark. / 为 true 时循环 Light→Dark→Default；为 false 时仅 Light↔Dark。 |

### ThemeSelectorMode Enum / ThemeSelectorMode 枚举

| Value | Description / 说明 |
|---|---|
| `Controller` | Clicking the button changes the theme in the target scope. / 单击按钮更改目标作用域中的主题。 |
| `Indicator` | Button only reflects the current theme; clicking does not change it. / 按钮仅反映当前主题；单击不会更改主题。 |

## Events / 事件

No custom events. Inherits standard `TemplatedControl` events. Theme changes
are communicated through the `SelectedTheme` property and
`ThemeVariantScope.ActualThemeVariantChanged`.

无自定义事件。继承标准 `TemplatedControl` 事件。主题变更通过 `SelectedTheme`
属性和 `ThemeVariantScope.ActualThemeVariantChanged` 传递。

## Styling & Templating / 样式与模板

### ControlTheme Key

| Theme Key | Target Type | Description / 说明 |
|---|---|---|
| `{x:Type u:ThemeToggleButton}` | `ThemeToggleButton` | Main theme. Uses an `IconButton` with themed glyphs. / 主主题。使用带主题图标的 `IconButton`。 |

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_ThemeButton` | `ThemeToggleButton` | `IconButton` |

### Pseudo-classes / 伪类

| Pseudo-class | Description / 说明 |
|---|---|
| `:light` | Theme is Light. / 当前为 Light 主题。 |
| `:dark` | Theme is Dark. / 当前为 Dark 主题。 |
| `:default` | Theme is Default (system). / 当前为 Default（系统）主题。 |

### Theme Resources / 主题资源

| Resource Key | Applies To | Description / 说明 |
|---|---|---|
| `ThemeSelectorButtonLightGlyph` | Icon (Light) | Icon shown when Light is selected. / Light 选中时显示的图标。 |
| `ThemeSelectorButtonDarkGlyph` | Icon (Dark) | Icon shown when Dark is selected. / Dark 选中时显示的图标。 |
| `ThemeSelectorButtonDefaultGlyph` | Icon (Default) | Icon shown when Default is selected. / Default 选中时显示的图标。 |

### ToolTip Resources

| Resource Key | Description / 说明 |
|---|---|
| `STRING_THEME_TOGGLE_LIGHT` | Light mode tooltip / Light 模式工具提示 |
| `STRING_THEME_TOGGLE_DARK` | Dark mode tooltip / Dark 模式工具提示 |
| `STRING_THEME_TOGGLE_SYSTEM` | System/default mode tooltip / 系统/默认模式工具提示 |

## FAQ / 常见问题

**Q: How is this different from a regular ToggleButton? / 与普通 ToggleButton 有何不同？**
A: `ThemeToggleButton` directly integrates with Avalonia's `ThemeVariant`
system. It discovers the nearest `ThemeVariantScope` automatically and supports
both Controller and Indicator modes for scoped or global theme management.

**Q: How do I toggle only between Light and Dark? / 如何仅在 Light 和 Dark 之间切换？**
A: Set `IsThreeState="False"`. The Default/System option is removed from the
cycle.

**Q: What happens when TargetScope is not set? / 未设置 TargetScope 时会发生什么？**
A: The control walks up the logical tree searching for a `ThemeVariantScope`
ancestor. If found, it binds to that scope. Otherwise it uses
`Application.Current` for global theme control.

**Q: Can I customize the icon? / 可以自定义图标吗？**
A: Override `ThemeSelectorButtonLightGlyph`, `ThemeSelectorButtonDarkGlyph`,
and `ThemeSelectorButtonDefaultGlyph` resources with your own `Geometry` values.

**Q: What is the difference between Controller and Indicator modes?**
A: `Controller` mode drives theme changes — clicking the button updates the
scope's `RequestedThemeVariant`. `Indicator` mode only reflects the current
theme; it is read-only. Use `Indicator` when you want the button to display
the current theme without allowing user changes.
