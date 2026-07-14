---
category: Components
title: ThemeSelector
subtitle: 主题选择器
description: >
  Base class and toggle button for selecting or indicating the current theme
  variant (Light, Dark, Default). ThemeToggleButton cycles through themes on
  click and updates either the application-level or a scoped
  ThemeVariantScope.RequestedThemeVariant. Supports Controller and Indicator
  modes, optional three-state cycling, and pseudo-classes for per-theme styling.
  用于选择或指示当前主题变体（Light、Dark、Default）的基类和切换按钮。
  ThemeToggleButton 在点击时循环切换主题，并更新应用程序级或作用域内的
  ThemeVariantScope.RequestedThemeVariant。支持 Controller 和 Indicator 模式、
  可选的三态循环以及用于每个主题样式的伪类。
---

# ThemeSelector / 主题选择器

## When to Use / 何时使用

Use `ThemeSelector` (via `ThemeToggleButton`) to let users toggle between light,
dark, and default (system) themes. It can operate as a **controller** (actively
changes the theme) or an **indicator** (reflects the current theme without
changing it). It can target the application globally or a specific
`ThemeVariantScope`.

使用 `ThemeSelector`（通过 `ThemeToggleButton`）让用户在浅色、深色和默认
（系统）主题之间切换。它可作为**控制器**（主动更改主题）或**指示器**（反映
当前主题而不更改）。可以全局作用于应用程序，也可以作用于特定的
`ThemeVariantScope`。

Do NOT use `ThemeToggleButton` to select arbitrary `ThemeVariant` values beyond
Light/Dark/Default — `ThemeSelectorBase` can be subclassed for custom
selection UIs.

不要使用 `ThemeToggleButton` 选择 Light/Dark/Default 之外的任意 `ThemeVariant`
值——可以子类化 `ThemeSelectorBase` 来实现自定义选择 UI。

## Basic Usage / 基本使用

### Global theme toggle / 全局主题切换

```xml
xmlns:u="https://irihi.tech/ursa"

<u:ThemeToggleButton />
```

By default, this toggles the application's `RequestedThemeVariant` between
Light and Dark (two-state mode).

默认情况下，这会在 Light 和 Dark 之间切换应用程序的 `RequestedThemeVariant`
（双状态模式）。

### Three-state toggle (Light / Dark / Default) / 三态切换

```xml
<u:ThemeToggleButton IsThreeState="True" />
```

Cycles: Light → Dark → Default → Light → ...

循环：Light → Dark → Default → Light → ...

### Indicator mode / 指示器模式

```xml
<u:ThemeToggleButton Mode="Indicator" />
```

In `Indicator` mode, the button reflects the current theme but does not change
it when clicked. Useful for display-only theme status.

在 `Indicator` 模式下，按钮反映当前主题，但点击时不更改主题。适用于仅显示
主题状态。

### Scoped theme toggle / 作用域主题切换

```xml
<ThemeVariantScope Name="scope" RequestedThemeVariant="Dark">
    <Border Theme="{DynamicResource CardBorder}">
        <StackPanel>
            <u:ThemeToggleButton TargetScope="{Binding #scope}" />
            <Button Content="Inside scope" />
        </StackPanel>
    </Border>
</ThemeVariantScope>
```

The toggle button controls only the theme of the targeted `ThemeVariantScope`,
not the entire application.

切换按钮仅控制目标 `ThemeVariantScope` 的主题，而非整个应用程序。

## Common Scenarios / 常用场景

### 1. Settings panel theme switch / 设置面板主题切换

```xml
<StackPanel Spacing="10">
    <TextBlock Text="Application Theme" FontWeight="Bold" />
    <u:ThemeToggleButton IsThreeState="True" />
</StackPanel>
```

### 2. Per-section theme control / 分区主题控制

```xml
<Grid ColumnDefinitions="Auto, *">
    <StackPanel Grid.Column="0">
        <TextBlock Text="Global" />
        <u:ThemeToggleButton />
        <TextBlock Text="Scoped" />
        <u:ThemeToggleButton TargetScope="{Binding #section}" />
    </StackPanel>
    <ThemeVariantScope Grid.Column="1" Name="section" RequestedThemeVariant="Dark">
        <Border Theme="{DynamicResource CardBorder}">
            <Calendar />
        </Border>
    </ThemeVariantScope>
</Grid>
```

### 3. Theme indicator in status bar / 状态栏中的主题指示器

```xml
<StatusBar>
    <u:ThemeToggleButton Mode="Indicator" />
</StatusBar>
```

## Property Reference / 属性参考

### ThemeSelectorBase Properties / ThemeSelectorBase 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedTheme` | `ThemeVariant?` | `null` | Currently selected theme variant / 当前选中的主题变体 |
| `Mode` | `ThemeSelectorMode` | `Controller` | `Controller` changes the theme; `Indicator` only displays it / `Controller` 更改主题；`Indicator` 仅显示 |
| `TargetScope` | `ThemeVariantScope?` | `null` | Optional scope to control. Null targets the application globally. / 可选的控制范围。为 null 则全局作用于应用程序。 |

### ThemeSelectorMode Enum / ThemeSelectorMode 枚举

| Value | Description / 说明 |
|---|---|
| `Controller` | Clicking changes the theme (default) / 点击更改主题（默认） |
| `Indicator` | Clicking does not change the theme; the button reflects the current state / 点击不更改主题；按钮反映当前状态 |

### ThemeToggleButton Properties / ThemeToggleButton 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `IsThreeState` | `bool` | `false` | Enable three-state cycling (Light/Dark/Default) instead of two / 启用三态循环（Light/Dark/Default）而非双态 |

### Scope Resolution / 范围解析

When `TargetScope` is not set, the control searches for a `ThemeVariantScope`
among its logical ancestors on attach. If none is found, it targets
`Application.Current`.

当未设置 `TargetScope` 时，控件在附加时会在逻辑祖先中搜索
`ThemeVariantScope`。如果找不到，则作用于 `Application.Current`。

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `ThemeSelectorButtonLightGlyph` | `PART_ThemeButton.Icon` | Icon shown when theme is Light / 主题为 Light 时显示的图标 |
| `ThemeSelectorButtonDarkGlyph` | `PART_ThemeButton.Icon` | Icon shown when theme is Dark / 主题为 Dark 时显示的图标 |
| `ThemeSelectorButtonDefaultGlyph` | `PART_ThemeButton.Icon` | Icon shown when theme is Default / 主题为 Default 时显示的图标 |
| `STRING_THEME_TOGGLE_LIGHT` | `PART_ThemeButton.ToolTip` | Tooltip for Light state / Light 状态的工具提示 |
| `STRING_THEME_TOGGLE_DARK` | `PART_ThemeButton.ToolTip` | Tooltip for Dark state / Dark 状态的工具提示 |
| `STRING_THEME_TOGGLE_SYSTEM` | `PART_ThemeButton.ToolTip` | Tooltip for Default state / Default 状态的工具提示 |

### Pseudo-classes / 伪类

| Pseudo-class | Condition / 条件 |
|---|---|
| `:light` | `SelectedTheme == ThemeVariant.Light` |
| `:dark` | `SelectedTheme == ThemeVariant.Dark` |
| `:default` | `SelectedTheme == null` or `ThemeVariant.Default` |

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_ThemeButton` | `ThemeToggleButton` | `IconButton` |

### Icon Selection / 图标选择

| Pseudo-class | Icon Resource / 图标资源 | ToolTip Resource |
|---|---|---|
| `:dark` | `ThemeSelectorButtonDarkGlyph` | `STRING_THEME_TOGGLE_DARK` |
| `:light` | `ThemeSelectorButtonLightGlyph` | `STRING_THEME_TOGGLE_LIGHT` |
| _(default)_ | `ThemeSelectorButtonDefaultGlyph` | `STRING_THEME_TOGGLE_SYSTEM` |

## FAQ / 常见问题

**Q: How does ThemeToggleButton differ from ThemeSelectorBase? / ThemeToggleButton 与 ThemeSelectorBase 有何不同？**
A: `ThemeSelectorBase` is the abstract base that manages scope tracking and
theme synchronization. `ThemeToggleButton` is the concrete UI implementation
that cycles Light ↔ Dark (↔ Default if `IsThreeState`). Subclass
`ThemeSelectorBase` to create custom theme selectors (e.g., a dropdown-based
picker).

`ThemeSelectorBase` 是管理范围跟踪和主题同步的抽象基类。`ThemeToggleButton`
是循环 Light ↔ Dark（如果 `IsThreeState` 则包含 Default）的具体 UI 实现。
子类化 `ThemeSelectorBase` 可创建自定义主题选择器（例如基于下拉菜单的选择器）。

**Q: What happens in Indicator mode when clicked? / Indicator 模式下点击会发生什么？**
A: In `Indicator` mode, clicking still cycles the internal `_state` and
updates `SelectedTheme`, but does NOT propagate the change to the target scope
or application. The `OnSelectedThemeChanged` override checks `_syncFromScope`
and `Mode` before applying.

在 `Indicator` 模式下，点击仍会循环内部 `_state` 并更新 `SelectedTheme`，但
不会将更改传播到目标范围或应用程序。`OnSelectedThemeChanged` 覆盖在应用前
检查 `_syncFromScope` 和 `Mode`。

**Q: How does two-state mode differ from three-state? / 双态模式与三态模式有何不同？**
A: In two-state mode (`IsThreeState="False"`), clicking toggles only between
Light and Dark. The `Default` state is not reachable via clicking. In three-state
mode, clicking cycles Light → Dark → Default → Light.

在双态模式（`IsThreeState="False"`）下，点击仅在 Light 和 Dark 之间切换。
无法通过点击到达 `Default` 状态。在三态模式下，点击循环 Light → Dark →
Default → Light。

**Q: Can I apply this to only part of my UI? / 可以仅应用于 UI 的一部分吗？**
A: Yes. Set `TargetScope` to a specific `ThemeVariantScope` that wraps the part
of the UI you want to control.

可以。将 `TargetScope` 设置为包裹要控制的 UI 部分的特定 `ThemeVariantScope`。
