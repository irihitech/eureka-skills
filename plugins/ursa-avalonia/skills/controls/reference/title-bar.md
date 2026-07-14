---
category: Navigation
title: TitleBar
subtitle: 标题栏
description: >
  A customizable title bar with Left, Center, and Right content slots. Used
  internally by UrsaWindow and UrsaView; also usable standalone in custom
  chrome layouts.
  可自定义的标题栏，提供左、中、右三个内容插槽。由 UrsaWindow 和 UrsaView
  内部使用，也可在自定义窗口边框布局中独立使用。
---

# TitleBar / 标题栏

## When to Use / 何时使用

Use `TitleBar` when you need a three-slot (Left / Center / Right) layout for
window chrome — typically inside `UrsaWindow` or `UrsaView`, which expose
`LeftContent`, `TitleBarContent` (center), and `RightContent` properties that
map directly to `TitleBar` slots. Use it standalone only when building a fully
custom window decoration template.

当需要为窗口边框提供三区域（左/中/右）布局时使用 `TitleBar`——通常配合
`UrsaWindow` 或 `UrsaView`，它们暴露的 `LeftContent`、`TitleBarContent`（中）
和 `RightContent` 属性会直接映射到 `TitleBar` 的插槽。仅当构建完全自定义的窗口
装饰模板时才独立使用。

`TitleBar` is a `TemplatedControl` — it does not inherit from `ContentControl`
and provides no built-in drag or window-state buttons. Window-drag behavior
comes from `WindowThumb` and the `WindowDecorationProperties.ElementRole`
attached property set in the template.

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<!-- Inside UrsaWindow (recommended) -->
<u:UrsaWindow ...>
    <u:UrsaWindow.LeftContent>
        <u:IconButton Icon="🏠" Theme="{StaticResource BorderlessIconButton}" />
    </u:UrsaWindow.LeftContent>
    <u:UrsaWindow.TitleBarContent>
        <TextBlock Text="My Application" />
    </u:UrsaWindow.TitleBarContent>
    <u:UrsaWindow.RightContent>
        <StackPanel Orientation="Horizontal">
            <u:IconButton Icon="⚙" Theme="{StaticResource BorderlessIconButton}" />
        </StackPanel>
    </u:UrsaWindow.RightContent>
    <!-- main content -->
</u:UrsaWindow>
```

The `UrsaWindow` template automatically instantiates a `TitleBar` (named
`PART_TitleBar`) and binds its `LeftContent`, `CenterContent`, and
`RightContent` to the window-level properties.

## Common Scenarios / 常用场景

### 1. Standalone TitleBar with WindowThumb / 独立 TitleBar + 拖拽区域

```xml
<DockPanel>
    <!-- Replace the OS title bar area -->
    <u:TitleBar DockPanel.Dock="Top"
                WindowDecorationProperties.ElementRole="TitleBar">
        <u:TitleBar.LeftContent>
            <Image Source="/Assets/logo.png" Width="16" Height="16" />
        </u:TitleBar.LeftContent>
        <u:TitleBar.CenterContent>
            <TextBlock Text="{Binding Title}" />
        </u:TitleBar.CenterContent>
        <u:TitleBar.RightContent>
            <StackPanel Orientation="Horizontal">
                <Button Content="_" Command="{Binding MinimizeCommand}" />
                <Button Content="□" Command="{Binding RestoreCommand}" />
                <Button Content="✕" Command="{Binding CloseCommand}" />
            </StackPanel>
        </u:TitleBar.RightContent>
    </u:TitleBar>
    <!-- content -->
</DockPanel>
```

### 2. WindowThumb for draggable area / 可拖拽区域

```xml
<u:TitleBar ...>
    <u:TitleBar.LeftContent>
        <!-- WindowThumb handles drag-to-move and double-click maximize -->
        <u:WindowThumb>
            <Image Source="/Assets/logo.png" Width="16" Height="16" />
        </u:WindowThumb>
    </u:TitleBar.LeftContent>
    ...
</u:TitleBar>
```

`WindowThumb` captures `PointerPressed` (triggers `Window.BeginMoveDrag`) and
`DoubleTapped` (toggles maximize/restore). It also supports `Background` for
rendering.

### 3. Using with UrsaView (single-page navigation) / 与 UrsaView 配合

```xml
<u:UrsaView ...>
    <u:UrsaView.RightContent>
        <views:TitleBarRightContent />
    </u:UrsaView.RightContent>
    <views:MainView />
</u:UrsaView>
```

### 4. Hiding the TitleBar / 隐藏标题栏

```xml
<u:UrsaWindow IsTitleBarVisible="False" ...>
    <!-- custom chrome without TitleBar -->
</u:UrsaWindow>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `LeftContent` | `object?` | `null` | Content rendered on the left side / 左侧内容 |
| `CenterContent` | `object?` | `null` | Content rendered in the center / 中间内容 |
| `RightContent` | `object?` | `null` | Content rendered on the right side / 右侧内容 |

`TitleBar` extends `TemplatedControl` and inherits standard layout properties
(`Margin`, `Padding`, `HorizontalAlignment`, etc.).

### WindowDecorationProperties.ElementRole

Set `WindowDecorationProperties.ElementRole="TitleBar"` on the `TitleBar` or
its root `DockPanel` so the OS treats the area as a title bar (enables
right-click system menu, etc.).

## Events / 事件

No custom events. `TitleBar` inherits standard `TemplatedControl` events
(`PointerPressed`, etc.). Drag and maximize behavior is provided by the
companion `WindowThumb` control.

## Styling & Templating / 样式与模板

### Theme Key / 主题 Key

| Theme Key | Description / 说明 |
|---|---|
| `{x:Type u:TitleBar}` | Default theme. Transparent background, DockPanel layout / 默认主题，透明背景，DockPanel 布局 |

### Template Parts / 模板部件

| Part Name | Type | Description / 说明 |
|---|---|---|
| `PART_LeftContentPresenter` | `ContentPresenter` | Hosts `LeftContent`, docked left / 承载 LeftContent，左停靠 |
| `PART_RightContentPresenter` | `ContentPresenter` | Hosts `RightContent`, docked right / 承载 RightContent，右停靠 |
| `PART_ContentPresenter` | `ContentPresenter` | Hosts `CenterContent`, stretches to fill / 承载 CenterContent，拉伸填充 |

### Template Structure / 模板结构

```
DockPanel (Transparent, WindowDecorationProperties.ElementRole="TitleBar")
├── PART_LeftContentPresenter  (DockPanel.Dock="Left")
├── PART_RightContentPresenter (DockPanel.Dock="Right")
└── PART_ContentPresenter      (stretches center)
```

### Theme Resources in UrsaWindow / UrsaWindow 中的主题资源

| Resource Key | Applies To | Description / 说明 |
|---|---|---|
| `TitleBarBackground` | `UrsaWindow` decorations | Title bar strip background / 标题栏条背景 |
| `WindowBackground` | `UrsaWindow` border | Window border background / 窗口边框背景 |
| `WindowBorderBrush` | `UrsaWindow` border | Window border color / 窗口边框颜色 |

## FAQ / 常见问题

**Q: How do I add drag-to-move to my custom TitleBar? / 如何为自定义 TitleBar 添加拖拽移动？**
A: Wrap your content in `WindowThumb`, or add
`WindowDecorationProperties.ElementRole="TitleBar"` to the panel. The
`UrsaWindow` template already handles this — you rarely need to manage it
manually.

```xml
<u:TitleBar WindowDecorationProperties.ElementRole="TitleBar">
    <!-- content is drag area -->
</u:TitleBar>
```

**Q: How do I put minimize/maximize/close buttons in the TitleBar?**
A: Place them in `RightContent` (or `UrsaWindow.RightContent`). For standard
window chrome buttons, use `UrsaWindow`'s built-in properties:
`IsMinimizeButtonVisible`, `IsRestoreButtonVisible`, `IsCloseButtonVisible`,
`IsFullScreenButtonVisible`. These render native-looking buttons drawn by the
`WindowDrawnDecorations` template.

**Q: Can I use TitleBar outside of UrsaWindow?**
A: Yes. `TitleBar` is a standalone `TemplatedControl` with no dependency on
`UrsaWindow`. Just be sure to set `WindowDecorationProperties.ElementRole`
appropriately and handle drag yourself via `WindowThumb`.
