---
category: Components
title: TabStrip
subtitle: 选项卡条
description: 选项卡条显示一行可点击的选项卡标题，通常与 Carousel 配合使用。
---

# TabStrip / 选项卡条

A row of clickable tab headers. Typically paired with `Carousel` using `{Binding SelectedItem}` to switch content. Inherits from `ItemsControl`.

一行可点击的选项卡标题。通常与 `Carousel` 搭配使用，通过 `{Binding SelectedItem}` 切换内容。

## When to Use / 何时使用

Use `TabStrip` + `Carousel` when you need custom content transition animations not available in `TabControl`. For standard tab UI, use `TabControl` which bundles strip + content.

需要 `TabControl` 中没有的自定义内容过渡动画时使用。标准选项卡 UI 用 `TabControl`。

## Basic Usage / 基本使用

```xml
<TabStrip Name="strip" ItemsSource="{Binding Tabs}" />
<Carousel ItemsSource="{Binding Tabs}"
          SelectedItem="{Binding SelectedItem, ElementName=strip}" />
```

## Styling & Templating / 样式与模板

Semi.Avalonia themes `TabStrip` with `TabStripItem` styling. Key resources: `TabStripItemBackground`, `TabStripItemSelectedForeground`. Pseudo-classes: `:selected`, `:pointerover`.

### Theme Variants / 主题变体

| Theme / 主题 | Resource Key / 资源键 | Description / 说明 |
| --- | --- | --- |
| **Default** | `{x:Type TabStrip}` | Default tab strip with bottom border separator. / 默认标签条，带底部边框分隔条。 |
| **Line** | `LineTabStrip` | Line-style tab strip. Sets `ItemContainerTheme` to `LineTabStripItem`. / 线条式标签条。将 `ItemContainerTheme` 设为 `LineTabStripItem`。 |
| **Card** | `CardTabStrip` | Card-style tab strip with separator rendered before items. / 卡片式标签条，分隔条在项目之前渲染。 |
| **Button** | `ButtonTabStrip` | Button-style tab strip. Hides border separator. / 按钮式标签条。隐藏边框分隔条。 |

### Special ControlThemes / 特殊控件主题

Semi.Avalonia defines the `BaseTabStripItem` theme in `TabStrip.axaml` as the abstract foundation for all concrete `TabStripItem` theme variants.

Semi.Avalonia 在 `TabStrip.axaml` 中定义了 `BaseTabStripItem` 主题，作为所有具体 `TabStripItem` 主题变体的抽象基础。

#### `BaseTabStripItem`

**TargetType:** `TabStripItem`
**Resource Key:** `BaseTabStripItem`

The foundational theme for all `TabStripItem` variants (`{x:Type TabStripItem}`, `LineTabStripItem`, `CardTabStripItem`, `ButtonTabStripItem`). Renders a single `ContentPresenter` (`PART_ContentPresenter`) with background, border, and foreground bindings. Provides `:selected` state styling that sets bold `FontWeight` and `TabItemLineHeaderSelectedForeground`. The `:not(:selected)` state sets `Cursor="Hand"` and applies `:pointerover` foreground changes.

所有 `TabStripItem` 变体（`{x:Type TabStripItem}`、`LineTabStripItem`、`CardTabStripItem`、`ButtonTabStripItem`）的基础主题。渲染一个带有背景、边框和前景绑定的 `ContentPresenter`（`PART_ContentPresenter`）。提供 `:selected` 状态样式，设置粗体 `FontWeight` 和 `TabItemLineHeaderSelectedForeground`。`:not(:selected)` 状态设置 `Cursor="Hand"` 并应用 `:pointerover` 前景变化。

```xml
<!-- Used as BasedOn for concrete TabStripItem themes -->
<TabStripItem Theme="{StaticResource BaseTabStripItem}"
              Content="Tab 1" />
```

**Direct children of `BaseTabStripItem`:**
- `{x:Type TabStripItem}` — adds `Padding="8 4"`, `BorderThickness="0 0 0 2"`, selected/pointerover/pressed border brush changes.
- `LineTabStripItem` — adds `Margin="0 0 24 0"`, `Padding="4 16 4 14"`, same border brush logic.
- `CardTabStripItem` — adds card-style border, `CornerRadius="3 3 0 0"`, background-based selected/hover/pressed states.
- `ButtonTabStripItem` — adds button-style `CornerRadius`, background-based selected/hover/pressed states.

## FAQ / 常见问题

**Q: TabStrip vs TabControl? / 何时用 TabStrip 而非 TabControl？**

A: Use `TabControl` for most cases. Use `TabStrip` + `Carousel` only when you need custom page transitions. / 大多数情况用 `TabControl`。仅在需要自定义页面过渡时使用 `TabStrip` + `Carousel`。