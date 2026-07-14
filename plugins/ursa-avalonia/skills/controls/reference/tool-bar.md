---
category: Navigation
title: ToolBar
subtitle: 工具栏
description: >
  A headered toolbar with horizontal/vertical orientation, overflow panel for
  items that don't fit, and a companion ToolBarSeparator. Supports per-item
  OverflowMode (AsNeeded, Always, Never).
  带标题的工具栏，支持水平/垂直方向、溢出项自动折叠面板，以及配套的
  ToolBarSeparator。支持按项设置 OverflowMode（AsNeeded, Always, Never）。
---

# ToolBar / 工具栏

## When to Use / 何时使用

Use `ToolBar` when you need a row (or column) of controls — buttons, text
boxes, toggle buttons, combo boxes — that automatically manages overflow:
items that don't fit in the available space move into a popup panel accessible
via an expand toggle button. This is the classic "ribbon-like" or
"overflow toolbar" pattern.

当需要一排（或一列）控件——按钮、文本框、切换按钮、下拉框——并希望自动管理溢出
时使用 `ToolBar`：超出可用空间的控件会自动移入通过展开按钮访问的弹出面板。
这是经典的"Ribbon 式"或"溢出工具栏"模式。

Use `ToolBarSeparator` to insert visual dividers between toolbar items.
Dividers at the beginning or end of the overflow panel are automatically hidden.

Avoid `ToolBar` for simple static button rows — use a `StackPanel` or
`ButtonGroup` instead.

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<u:ToolBar Header="Edit">
    <Button Content="Cut" />
    <Button Content="Copy" />
    <u:ToolBarSeparator />
    <Button Content="Paste" />
    <TextBox Width="100" VerticalAlignment="Center" />
</u:ToolBar>
```

When the toolbar is too narrow for all items, a "…" toggle button appears.
Clicking it opens a popup with the overflowing items.

## Common Scenarios / 常用场景

### 1. Overflow control per item / 按项控制溢出

```xml
<u:ToolBar Header="File">
    <!-- Never overflow — always visible -->
    <Button Content="New" u:ToolBar.OverflowMode="Never" />
    <Button Content="Open" u:ToolBar.OverflowMode="Never" />

    <u:ToolBarSeparator />

    <!-- AsNeeded (default) — overflow when space is tight -->
    <Button Content="Save" u:ToolBar.OverflowMode="AsNeeded" />
    <Button Content="Print" u:ToolBar.OverflowMode="AsNeeded" />

    <u:ToolBarSeparator />

    <!-- Always — always in overflow popup -->
    <Button Content="Advanced" u:ToolBar.OverflowMode="Always" />
</u:ToolBar>
```

### 2. Vertical orientation / 垂直方向

```xml
<u:ToolBar Header="Tools" Orientation="Vertical">
    <Button Content="Select" />
    <Button Content="Draw" />
    <u:ToolBarSeparator />
    <Button Content="Erase" />
</u:ToolBar>
```

When `Orientation="Vertical"`, the popup placement changes to
`RightEdgeAlignedTop`, the header docks top, and the expand button moves to the
bottom.

### 3. Data-bound items / 数据绑定

```xml
<u:ToolBar ItemsSource="{Binding Tools}">
    <u:ToolBar.ItemTemplate>
        <DataTemplate>
            <Button Content="{Binding Name}" Command="{Binding Command}" />
        </DataTemplate>
    </u:ToolBar.ItemTemplate>
</u:ToolBar>
```

### 4. Rich editing toolbar / 富文本编辑工具栏

```xml
<u:ToolBar>
    <ToggleButton Name="bold">
        <PathIcon Data="{DynamicResource SemiIconBold}" />
    </ToggleButton>
    <ToggleButton Name="italic">
        <PathIcon Data="{DynamicResource SemiIconItalic}" />
    </ToggleButton>
    <u:ToolBarSeparator />
    <StackPanel Orientation="Horizontal">
        <TextBlock Margin="8,0" VerticalAlignment="Center" Text="Font Size" />
        <ComboBox Name="size" Width="90" SelectedIndex="0">
            <x:Double>8</x:Double>
            <x:Double>16</x:Double>
            <x:Double>32</x:Double>
        </ComboBox>
    </StackPanel>
</u:ToolBar>
```

### 5. Header with toolbar items / 带标题的工具栏

```xml
<u:ToolBar Header="Formatting">
    <Button Content="B" FontWeight="Bold" />
    <Button Content="I" FontStyle="Italic" />
    <Button Content="U">
        <Button.TextDecorations>
            <TextDecorationCollection>
                <TextDecoration Location="Underline" />
            </TextDecorationCollection>
        </Button.TextDecorations>
    </Button>
</u:ToolBar>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `Header` | `object?` | `null` | Header content displayed at the start of the toolbar / 工具栏头部内容 |
| `HeaderTemplate` | `IDataTemplate?` | `null` | Data template for the header / 头部 DataTemplate |
| `Orientation` | `Orientation` | `Horizontal` | Layout direction: `Horizontal` or `Vertical` / 布局方向 |
| `PopupPlacement` | `PlacementMode` | `BottomEdgeAlignedLeft` (H) / `RightEdgeAlignedTop` (V) | Placement of the overflow popup / 溢出弹窗位置 |

Inherits from `HeaderedItemsControl` (`Items`, `ItemsSource`, `ItemTemplate`,
`ItemsPanel`, etc.).

### Attached Properties / 附加属性

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `u:ToolBar.OverflowMode` | `OverflowMode` | `AsNeeded` | Controls overflow behavior per child / 控制每个子项的溢出行为 |

### OverflowMode enum / OverflowMode 枚举

| Value | Description / 说明 |
|---|---|
| `AsNeeded` | Item overflows only when space is insufficient (default) / 空间不足时才溢出（默认） |
| `Always` | Item always appears in the overflow popup / 始终在溢出弹窗中 |
| `Never` | Item never overflows — always visible in the main bar / 始终在主工具栏中可见 |

## Events / 事件

No custom events. `ToolBar` inherits standard `HeaderedItemsControl` events.

## Styling & Templating / 样式与模板

### Theme Keys / 主题 Key

| Theme Key | Description / 说明 |
|---|---|
| `{x:Type u:ToolBar}` | Default toolbar theme / 默认工具栏主题 |
| `{x:Type u:ToolBarSeparator}` | Default separator theme / 默认分隔符主题 |
| `ToolBarExpandToggleButton` | Theme for the overflow expand toggle button / 溢出展开按钮主题 |

### Pseudo-classes / 伪类

| Pseudo-class | Control | Condition / 条件 |
|---|---|---|
| `:overflow` | `ToolBar` | Set when `HasOverflowItems` is true (any item in overflow) / 有溢出项时设置 |
| `:overflow` | Each child (via attached) | Set on the child control when it is in overflow / 控件处于溢出状态时设置 |
| `:vertical` | `ToolBarSeparator` | Set when `Orientation == Vertical` / 垂直方向时设置 |

### Template Parts / 模板部件

| Part Name | Control | Type | Description / 说明 |
|---|---|---|---|
| `PART_OverflowPanel` | `ToolBar` | `Panel` | Hosts overflowed items inside the popup / 承载弹出面板中的溢出项 |
| `PART_BackgroundBorder` | `ToolBar` | `Border` | Root border of the toolbar / 工具栏根 Border |
| `PART_Header` | `ToolBar` | `ContentPresenter` | Header presenter / 头部呈现器 |
| `PART_PopupButtonPanel` | `ToolBar` | `Panel` | Wrapper for the expand toggle button + popup / 展开按钮+弹窗的容器 |
| `PART_Icon` | `ToolBar` | `PathIcon` | The "…" icon on the expand button / 展开按钮上的"…"图标 |
| `PART_Rect` | `ToolBarSeparator` | `Rectangle` | Separator line / 分隔线 |

### ToolBarSeparator / 分隔符

`ToolBarSeparator` is a `TemplatedControl` that auto-detects orientation from
its parent `ToolBar` via logical tree walk. It renders a 1px line:
- Horizontal toolbar: vertical bar, 1px wide, stretched height
- Vertical toolbar: horizontal bar, 1px tall, stretched width

### Theme Resources / 主题资源

| Resource Key | Description / 说明 |
|---|---|
| `ToolBarHeaderForeground` | Header text color / 标题文字颜色 |
| `ToolBarSeparatorForeground` | Separator line color / 分隔线颜色 |
| `ToolBarHorizontalMoreGlyph` | "…" icon data (horizontal) / 水平"…"图标路径数据 |
| `ToolBarVerticalMoreGlyph` | "…" icon data (vertical) / 垂直"…"图标路径数据 |

### Default ItemsPanel / 默认项目面板

```xml
<ItemsPanelTemplate>
    <u:ToolBarPanel />
</ItemsPanelTemplate>
```

`ToolBarPanel` is a custom `StackPanel` subclass that measures children and
moves overflowing items into `PART_OverflowPanel` in the popup. It preserves
child order: once an item overflows, all subsequent `AsNeeded` items overflow
too.

## FAQ / 常见问题

**Q: How does overflow decide which items to move? / 溢出如何决定哪些项移入弹窗？**
A: `ToolBarPanel.MeasureOverride` iterates children in order. Each child is
measured; if it fits in the remaining space and `OverflowMode` is `AsNeeded`,
it stays. Once one item doesn't fit, all subsequent `AsNeeded` items overflow.
`OverflowMode.Never` items always stay; `OverflowMode.Always` items always
overflow.

**Q: Can I customize the overflow toggle button icon?**
A: Override `ToolBarHorizontalMoreGlyph` and `ToolBarVerticalMoreGlyph` in
your theme resources, or retemplate `ToolBarExpandToggleButton`.

**Q: How do I hide the toolbar header?**
A: Simply omit `Header`. The `PART_Header` content presenter is hidden
automatically when `Header` is null (via `IsVisible` converter).

**Q: Does ToolBar support nested toolbars?**
A: Yes — embed a `ToolBar` as a child of another `ToolBar`. Each nested
toolbar gets its own overflow management. Be mindful of horizontal space.

**Q: Can I use non-Button items in ToolBar?**
A: Yes. `ToolBar.CreateContainerForItemOverride` returns the item as-is if
it's already a `Control`. You can place `TextBox`, `ComboBox`, `StackPanel`,
`ToggleButton`, or any `Control` directly inside a `ToolBar`.
