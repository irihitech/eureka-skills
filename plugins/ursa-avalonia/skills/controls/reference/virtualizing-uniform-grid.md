---
category: Layout
title: VirtualizingUniformGrid
subtitle: 虚拟化均匀网格
description: >
  A high-performance virtualizing panel that arranges items in a uniform grid
  with a fixed number of columns. Only visible items (plus a configurable
  buffer) are realized; off-screen containers are recycled. Supports scroll
  snap points and keyboard navigation.
  高性能虚拟化面板，将项目排列为固定列数的均匀网格。仅实现可见项（加可配置缓冲），
  屏幕外的容器被回收。支持滚动对齐点和键盘导航。
---

# VirtualizingUniformGrid / 虚拟化均匀网格

## When to Use / 何时使用

Use `VirtualizingUniformGrid` as an `ItemsPanel` inside a `ScrollViewer` for
large data sets displayed in a grid — photo galleries, file explorers, product
grids, or any collection with hundreds or thousands of items. It virtualizes
both UI containers and layout calculations, only realizing items currently in
or near the viewport.

当需要在 `ScrollViewer` 中使用网格显示大型数据集时，使用
`VirtualizingUniformGrid` 作为 `ItemsPanel`——相册、文件浏览器、产品网格
或任何包含成百上千项集合的场景。它虚拟化 UI 容器和布局计算，仅实现视口内
或附近的项。

Avoid `VirtualizingUniformGrid` for small item counts (e.g., < 20 items) —
use `UniformGrid` or `WrapPanel` instead. Virtualization overhead is not
worthwhile for tiny collections.

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<ScrollViewer>
    <ItemsControl ItemsSource="{Binding Images}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <u:VirtualizingUniformGrid Columns="4"
                                           ItemWidth="200"
                                           ItemHeight="200" />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Border Background="{DynamicResource SemiColorFill0}"
                        Margin="4">
                    <Image Source="{Binding ThumbnailUrl}" />
                </Border>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
</ScrollViewer>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `Columns` | `int` | `4` | Number of columns (> 0) / 列数（> 0） |
| `ItemWidth` | `double` | `NaN` | Fixed item width; `NaN` = auto-calculated from panel width / 固定项宽度；NaN = 根据面板宽度自动计算 |
| `ItemHeight` | `double` | `NaN` | Fixed item height; `NaN` = auto-calculated / 固定项高度；NaN = 自动计算 |
| `CacheLength` | `double` | `0.5` | Buffer factor (0–2) — extra viewport's worth of rows to realize above/below / 缓冲系数（0–2）——上下额外预实现的行数 |
| `UniformItemHeight` | `bool` | `true` | When `true`, all rows share the same height; when `false`, each row sizes to its tallest item / `true` 时所有行等高；`false` 时每行高度由最高项决定 |

### Read-Only Properties / 只读属性

| Property / 属性 | Type / 类型 | Description / 说明 |
|---|---|---|
| `FirstRealizedIndex` | `int` | Index of the first currently realized item / 当前第一个已实现项的索引 |
| `LastRealizedIndex` | `int` | Index of the last currently realized item / 当前最后一个已实现项的索引 |

## Events / 事件

| Event / 事件 | Description / 说明 |
|---|---|
| `HorizontalSnapPointsChanged` | Fires when horizontal scroll snap points change / 水平滚动对齐点变化时触发 |
| `VerticalSnapPointsChanged` | Fires when vertical scroll snap points change / 垂直滚动对齐点变化时触发 |

Implements `IScrollSnapPointsInfo` for scroll snapping.

## Keyboard Navigation / 键盘导航

`VirtualizingUniformGrid` implements `IInputElement` navigation with full
directional support:

| Key | Behavior / 行为 |
|---|---|
| `Left` | Move to previous column in same row / 移到同行前一列 |
| `Right` | Move to next column in same row / 移到同行下一列 |
| `Up` | Move to same column in previous row / 移到同列上一行 |
| `Down` | Move to same column in next row / 移到同列下一行 |
| `Home` / `Ctrl+Home` | First item / 第一项 |
| `End` / `Ctrl+End` | Last item / 最后一项 |

## Styling & Templating / 样式与模板

`VirtualizingUniformGrid` is a pure layout panel (`VirtualizingPanel`) with
no built-in theme or control template. It inherits default `Panel` styling.

`VirtualizingUniformGrid` 是纯布局面板（继承 `VirtualizingPanel`），没有
内置主题或控件模板。仅继承默认 `Panel` 样式。

## Performance Notes / 性能说明

- **Container recycling**: Off-screen containers are returned to a recycle pool
  keyed by `RecycleKey`. New items reuse existing containers instead of
  creating new ones.
- **CacheLength**: Higher values (up to 2.0) reduce pop-in during fast scrolling
  at the cost of more realized containers. Default `0.5` adds half a viewport
  of buffer above and below.
- **UniformItemHeight = false**: When items have varying heights, each row
  height is determined by its tallest item. This mode has more measurement
  overhead but is necessary for text-heavy or variable-size content.

## FAQ / 常见问题

**Q: What's the difference between ItemWidth/ItemHeight and the actual cell size? / ItemWidth/ItemHeight 与实际单元格大小有何区别？**
A: When `ItemWidth` or `ItemHeight` is `NaN` (default), the cell size is
computed by dividing the available panel width by `Columns`. Setting explicit
values overrides auto-calculation.

**Q: Can I use this without a ScrollViewer? / 可以在没有 ScrollViewer 的情况下使用吗？**
A: No. Virtualization requires a `ScrollViewer` ancestor to track the viewport
and scroll offset. Without one, no items will be realized.

**Q: How does scrolling to an item work? / 如何滚动到某个项？**
A: Call `ItemsControl.ScrollIntoView(item)` or use the panel's
`ScrollIntoView(index)` method. The panel creates/measures the target item,
arranges it at its estimated position, and calls `BringIntoView()`.
