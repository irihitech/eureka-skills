---
category: Components
title: TabControl
subtitle: 选项卡控件
description: 选项卡控件用于在多个内容页面之间切换，每次显示一个页面。
---

# TabControl / 选项卡控件

A control that displays multiple pages with clickable tab headers. Each page is a `TabItem`. Inherits from `SelectingItemsControl`.

显示多个内容页面的控件，带有可点击的选项卡标题。每个页面是 `TabItem`。继承自 `SelectingItemsControl`。

## When to Use / 何时使用

Use `TabControl` when you need to switch between multiple content views where only one is visible at a time. For wizard-style sequential flow, use `Carousel`. For mobile navigation, use `TabbedPage`.

需要在多个内容视图之间切换且每次只显示一个时使用。向导式顺序流程用 `Carousel`。移动导航用 `TabbedPage`。

## Basic Usage / 基本使用

```xml
<TabControl>
    <TabItem Header="General">
        <StackPanel><!-- settings --></StackPanel>
    </TabItem>
    <TabItem Header="Advanced">
        <StackPanel><!-- advanced --></StackPanel>
    </TabItem>
</TabControl>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `SelectedIndex` | `int` | Selected tab index. / 选中的选项卡索引。 |
| `SelectedItem` | `object?` | The selected `TabItem`. / 选中的 `TabItem`。 |
| `TabStripPlacement` | `Dock` | Tab strip position: `Top`, `Bottom`, `Left`, `Right`. |

## Styling & Templating / 样式与模板

Semi.Avalonia themes `TabControl` and `TabItem` with `TabItemBackground`, `TabItemForeground`, `TabItemSelectedBackground`. Pseudo-classes on `TabItem`: `:selected`, `:pointerover`, `:pressed`.

### Theme Variants / 主题变体

| Theme / 主题 | Resource Key / 资源键 | Description / 说明 |
| --- | --- | --- |
| **Default** | `{x:Type TabControl}` | Based on `BaseTabControl`. Default tab separator position. / 基于 `BaseTabControl`。默认标签分隔条位置。 |
| **Line** | `LineTabControl` | Minimal underline indicator. Sets `ItemContainerTheme` to `LineTabItem`. / 极简下划线指示器。将 `ItemContainerTheme` 设为 `LineTabItem`。 |
| **Card** | `CardTabControl` | Connected card tabs with rounded corners. Overrides template for border-separator-first layout. / 带圆角的连接卡片标签。重写模板以实现边框-分隔条优先布局。 |
| **Button** | `ButtonTabControl` | Toggle-button style tabs. Hides border separator. / 切换按钮式标签。隐藏边框分隔条。 |
| **Scroll** | `ScrollTabControl` | Scrollable tab strip. Based on `BaseScrollTabControl`. / 可滚动标签条。基于 `BaseScrollTabControl`。 |
| **ScrollLine** | `ScrollLineTabControl` | Scrollable + line style. / 可滚动 + 线条样式。 |
| **ScrollCard** | `ScrollCardTabControl` | Scrollable + card style. / 可滚动 + 卡片样式。 |
| **ScrollButton** | `ScrollButtonTabControl` | Scrollable + button style. / 可滚动 + 按钮样式。 |

### Special ControlThemes / 特殊控件主题

Semi.Avalonia defines two abstract base themes in `TabControl.axaml` that serve as foundations for all concrete `TabControl` theme variants.

Semi.Avalonia 在 `TabControl.axaml` 中定义了两个抽象基础主题，作为所有具体 `TabControl` 主题变体的基础。

#### `BaseTabControl`

**TargetType:** `TabControl`
**Resource Key:** `BaseTabControl`

The foundational theme shared by `{x:Type TabControl}`, `LineTabControl`, `CardTabControl`, and `ButtonTabControl`. Renders a `Border` wrapping a `DockPanel` with `ItemsPresenter` and `ContentPresenter`. Includes a `PART_BorderSeparator` border that adapts its position and orientation based on `TabStripPlacement` (height for Top/Bottom, width for Left/Right). Also adjusts the `ItemsPanel` for Left/Right placements to use a vertical `WrapPanel`.

`{x:Type TabControl}`、`LineTabControl`、`CardTabControl` 和 `ButtonTabControl` 共享的基础主题。渲染一个包裹 `DockPanel` 的 `Border`，内含 `ItemsPresenter` 和 `ContentPresenter`。包含一个 `PART_BorderSeparator` 边框，根据 `TabStripPlacement`（上/下为高度，左/右为宽度）调整其位置和方向。还为左/右放置调整 `ItemsPanel` 以使用垂直 `WrapPanel`。

```xml
<!-- Used as BasedOn for concrete themes; not typically applied directly -->
<TabControl Theme="{StaticResource BaseTabControl}" TabStripPlacement="Top">
    <TabItem Header="Tab 1" />
    <TabItem Header="Tab 2" />
</TabControl>
```

**Key responsibility:** Border-separator positioning, `TabStripPlacement` adaptivity, `ItemsPanel` switching.

#### `BaseScrollTabControl`

**TargetType:** `TabControl`
**Resource Key:** `BaseScrollTabControl`

The foundational theme for scrollable tab variants (`ScrollTabControl`, `ScrollLineTabControl`, `ScrollCardTabControl`, `ScrollButtonTabControl`). Identical in structure to `BaseTabControl` but wraps `PART_ItemsPresenter` in a `ScrollViewer` (`PART_ScrollViewer`) so the tab strip can scroll when tabs overflow the available width/height. Sets default `ItemsPanel` to `VirtualizingStackPanel` with horizontal orientation and configures scroll bar visibility per `TabStripPlacement`.

可滚动标签变体（`ScrollTabControl`、`ScrollLineTabControl`、`ScrollCardTabControl`、`ScrollButtonTabControl`）的基础主题。结构与 `BaseTabControl` 相同，但将 `PART_ItemsPresenter` 包裹在 `ScrollViewer`（`PART_ScrollViewer`）中，因此标签条可以在标签超出可用宽度/高度时滚动。设置默认 `ItemsPanel` 为水平方向的 `VirtualizingStackPanel`，并根据 `TabStripPlacement` 配置滚动条可见性。

```xml
<TabControl Theme="{StaticResource ScrollLineTabControl}">
    <!-- Many tabs will scroll instead of squishing -->
    <TabItem Header="Tab 1" />
    <TabItem Header="Tab 2" />
    <!-- ... -->
    <TabItem Header="Tab 20" />
</TabControl>
```

**Key responsibility:** Scrollable tab strip, `VirtualizingStackPanel` items panel, adaptive scroll bar visibility.

## FAQ / 常见问题

**Q: TabControl vs TabStrip? / TabControl 和 TabStrip 的区别？**

A: `TabControl` includes both the tab strip and content area. `TabStrip` is the tab header row only — pair it with `Carousel` for custom content switching. / `TabControl` 包含选项卡条和内容区。`TabStrip` 仅是选项卡标题行——搭配 `Carousel` 实现自定义内容切换。