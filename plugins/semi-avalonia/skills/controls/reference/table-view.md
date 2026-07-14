---
category: Components
title: TableView
subtitle: 表格视图
description: 只读表格控件，以可配置列的形式展示数据项。
---

# TableView / 表格视图

A read-only tabular control that presents items in configurable columns. `TableView` inherits from `ListBox` and provides column-based layout with `TableViewColumn` definitions, resizable column headers, and row virtualization. Unlike `DataGrid`, it is read-only — no inline editing.

只读表格控件，以可配置列的形式展示数据项。`TableView` 继承自 `ListBox`，通过 `TableViewColumn` 定义提供基于列的布局、可调整大小的列标题和行虚拟化。与 `DataGrid` 不同，它是只读的 —— 不支持内联编辑。

## When to Use / 何时使用

Use `TableView` for read-only tabular data display — property grids, log tables, read-only lists with multiple fields, or any scenario where you need a lightweight column-based view without editing. For editable grids with sorting, filtering, and inline editing, use `DataGrid`. For simple single-column lists, use `ListBox`.

使用 `TableView` 展示只读表格数据 —— 属性网格、日志表格、多字段只读列表，或任何需要轻量级基于列的视图但不需要编辑的场景。需要排序、过滤和内联编辑的可编辑网格使用 `DataGrid`。简单的单列列表使用 `ListBox`。

## Basic Usage / 基本使用

```xml
<TableView ItemsSource="{Binding Items}"
           CanUserResizeColumns="True">
    <TableView.Columns>
        <TableViewColumn Header="Name"
                         Width="2*"
                         Binding="{Binding Name}" />
        <TableViewColumn Header="Value"
                         Width="*"
                         Binding="{Binding Value}" />
        <TableViewColumn Header="Type"
                         Width="120"
                         Binding="{Binding Type}" />
    </TableView.Columns>
</TableView>
```

```csharp
// Programmatic creation
var tableView = new TableView
{
    ItemsSource = items,
    CanUserResizeColumns = true
};

tableView.Columns.Add(new TableViewColumn
{
    Header = "Name",
    Width = GridLength.Star,
    Binding = new Binding("Name")
});
tableView.Columns.Add(new TableViewColumn
{
    Header = "Value",
    Width = new GridLength(120),
    Binding = new Binding("Value")
});
```

## Common Scenarios / 常用场景

### Property Grid / 属性网格

Display key-value pairs with a two-column `TableView`.

```xml
<TableView ItemsSource="{Binding Properties}"
           CanUserResizeColumns="True"
           BorderThickness="1"
           BorderBrush="{DynamicResource DefaultBorderBrush}">
    <TableView.Columns>
        <TableViewColumn Header="Property" Width="150"
                         Binding="{Binding Key}" />
        <TableViewColumn Header="Value" Width="*"
                         Binding="{Binding Value}" />
    </TableView.Columns>
</TableView>
```

### Custom Cell Template / 自定义单元格模板

Use `CellTemplate` on a `TableViewColumn` for custom cell rendering.

```xml
<TableView ItemsSource="{Binding LogEntries}">
    <TableView.Columns>
        <TableViewColumn Header="Level" Width="80">
            <TableViewColumn.CellTemplate>
                <DataTemplate>
                    <Border CornerRadius="4" Padding="4,2"
                            Classes.error="{Binding IsError}"
                            Classes.warning="{Binding IsWarning}"
                            Background="{DynamicResource TertiaryLight}">
                        <TextBlock Text="{Binding Level}" FontSize="12" />
                    </Border>
                </DataTemplate>
            </TableViewColumn.CellTemplate>
        </TableViewColumn>
        <TableViewColumn Header="Message" Width="*"
                         Binding="{Binding Message}" />
        <TableViewColumn Header="Timestamp" Width="180"
                         Binding="{Binding Timestamp}" />
    </TableView.Columns>
</TableView>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Columns` | `AvaloniaList<TableViewColumn>?` | The collection of column definitions. Columns define header, width, binding, and cell template. / 列定义集合。列定义了标题、宽度、绑定和单元格模板。 |
| `CanUserResizeColumns` | `bool` | Whether the user can resize columns by dragging column header separators (default `true`). / 用户是否可以通过拖动列标题分隔符来调整列宽（默认 `true`）。 |
| `ItemsSource` | `IEnumerable?` | The data source. Inherited from `ItemsControl`. / 数据源。继承自 `ItemsControl`。 |
| `SelectedItem` | `object?` | The currently selected item. Inherited from `ListBox`. / 当前选中的项。继承自 `ListBox`。 |
| `SelectionMode` | `SelectionMode` | Selection behavior: `Single`, `Multiple`, `Toggle`, `AlwaysSelected`. Inherited from `ListBox`. / 选择行为。继承自 `ListBox`。 |

> **Note:** `TableView` explicitly obsoletes `DisplayMemberBinding` and `ItemTemplate` — use `TableViewColumn.Binding` and `TableViewColumn.CellTemplate` instead.

> **注意：** `TableView` 明确废弃了 `DisplayMemberBinding` 和 `ItemTemplate` —— 请使用 `TableViewColumn.Binding` 和 `TableViewColumn.CellTemplate`。

### TableViewColumn Properties / TableViewColumn 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Header` | `object?` | The column header content (typically a string). / 列标题内容（通常是字符串）。 |
| `Width` | `GridLength` | Column width. Supports `Auto`, `*` (star), and fixed pixel values. / 列宽。支持 `Auto`、`*`（星号比例）和固定像素值。 |
| `MinWidth` | `double` | Minimum column width. / 列最小宽度。 |
| `MaxWidth` | `double` | Maximum column width. / 列最大宽度。 |
| `Binding` | `IBinding?` | Binding for the cell value. / 单元格值的绑定。 |
| `CellTemplate` | `IDataTemplate?` | Custom template for rendering the cell content. / 用于渲染单元格内容的自定义模板。 |
| `CanUserResize` | `bool?` | Per-column override for `CanUserResizeColumns`. / 每列的 `CanUserResizeColumns` 覆盖设置。 |

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlThemes / Semi.Avalonia 控件主题

Semi.Avalonia provides a comprehensive `TableView` styling suite:

Semi.Avalonia 提供了全面的 `TableView` 样式套件：

| Theme / 主题 | TargetType / 目标类型 | Description / 说明 |
| --- | --- | --- |
| `{x:Type TableView}` | `TableView` | Main control theme with border and scroll viewer. / 带边框和滚动查看器的主控件主题。 |
| `TableViewScrollViewerTheme` | `ScrollViewer` | Internal scroll viewer with column headers pinned to the top. / 内置滚动查看器，列标题固定在顶部。 |
| `{x:Type TableViewColumnHeader}` | `TableViewColumnHeader` | Column header with foreground, background, padding, and resizer thumb. / 带前景、背景、内边距和调整大小拖动手柄的列标题。 |
| `{x:Type TableViewRow}` | `TableViewRow` | Row theme with hover, pressed, selected, and disabled states. / 含悬停、按下、选中和禁用状态的行主题。 |
| `{x:Type TableViewCell}` | `TableViewCell` | Cell with default padding. / 带默认内边距的单元格。 |

### Row Pseudo-classes / 行伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:pointerover` | Mouse is hovering over the row. / 鼠标悬停在行上。 |
| `:pressed` | Row is being pressed. / 行被按下。 |
| `:selected` | Row is selected. / 行被选中。 |
| `:disabled` | Row is disabled. / 行被禁用。 |

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `TableViewCellBackground` | Cell background / 单元格背景 |
| `TableViewCellPadding` | Cell padding / 单元格内边距 |
| `TableViewCellMinHeight` | Minimum cell height / 最小单元格高度 |
| `TableViewColumnHeadersBackground` | Column headers area background / 列标题区域背景 |
| `TableViewColumnHeaderBackground` | Individual header background / 单个标题背景 |
| `TableViewColumnHeaderForeground` | Header text color / 标题文本颜色 |
| `TableViewColumnHeaderFontWeight` | Header font weight / 标题字体粗细 |
| `TableViewColumnHeaderMinHeight` | Minimum header height / 最小标题高度 |
| `TableViewColumnHeaderPadding` | Header padding / 标题内边距 |
| `TableViewColumnResizerWidth` | Resizer grip width / 调整手柄宽度 |
| `TableViewGridLineBrush` | Grid line color / 网格线颜色 |
| `TableViewRowBackground` | Default row background / 默认行背景 |
| `TableViewRowForeground` | Default row text color / 默认行文本颜色 |
| `TableViewRowMargin` | Row margin / 行外边距 |
| `TableViewRowPadding` | Row padding / 行内边距 |
| `TableViewRowCornerRadius` | Row corner radius / 行圆角 |
| `TableViewRowBackgroundPointerOver` | Hover row background / 悬停行背景 |
| `TableViewRowForegroundPointerOver` | Hover row text color / 悬停行文本颜色 |
| `TableViewRowBackgroundPressed` | Pressed row background / 按下行背景 |
| `TableViewRowForegroundPressed` | Pressed row text color / 按下行文本颜色 |
| `TableViewRowBackgroundSelected` | Selected row background / 选中行背景 |
| `TableViewRowForegroundSelected` | Selected row text color / 选中行文本颜色 |
| `TableViewRowBackgroundSelectedPointerOver` | Selected+hover background / 选中+悬停背景 |
| `TableViewRowForegroundSelectedPointerOver` | Selected+hover text color / 选中+悬停文本颜色 |
| `TableViewRowBackgroundSelectedPressed` | Selected+pressed background / 选中+按下背景 |
| `TableViewRowForegroundSelectedPressed` | Selected+pressed text color / 选中+按下文本颜色 |
| `TableViewRowBackgroundDisabled` | Disabled row background / 禁用行背景 |
| `TableViewRowForegroundDisabled` | Disabled row text color / 禁用行文本颜色 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_ItemsPresenter` | `ItemsPresenter` | Renders the row items inside the scroll viewer. / 在滚动查看器内渲染行项。 |
| `PART_ContentPresenter` (ScrollViewer) | `ScrollContentPresenter` | The scrollable content area. / 可滚动内容区域。 |
| `PART_HorizontalScrollBar` | `ScrollBar` | Horizontal scroll bar. / 水平滚动条。 |
| `PART_VerticalScrollBar` | `ScrollBar` | Vertical scroll bar. / 垂直滚动条。 |
| `PART_CellsPresenter` (TableViewRow) | `TableViewCellsPresenter` | Renders cells within a row. / 在行内渲染单元格。 |
| `PART_Resizer` (TableViewColumnHeader) | `Thumb` | Column resize drag handle. / 列调整大小的拖动手柄。 |
| `PART_ContentPresenter` (TableViewColumnHeader) | `ContentPresenter` | Renders the header content. / 渲染标题内容。 |

### Special ControlThemes / 特殊控件主题

Semi.Avalonia defines two additional resources in `TableView.axaml` beyond the standard `{x:Type TableView}` theme.

Semi.Avalonia 在 `TableView.axaml` 中定义了除标准 `{x:Type TableView}` 主题外的两个额外资源。

#### `TableViewScrollViewerTheme`

**TargetType:** `ScrollViewer`
**Resource Key:** `TableViewScrollViewerTheme`

The internal `ScrollViewer` theme used by the `TableView` control template. Pins column headers to the top via a `DockPanel`: a `Border` containing `TableViewColumnHeadersPresenter` is docked to `Top`, and `ScrollContentPresenter` fills the remaining space. Includes horizontal and vertical `ScrollBar` elements in a `Grid` layout with `*,Auto` rows/columns. Also wires `ScrollGestureRecognizer` for touch-based scrolling support.

`TableView` 控件模板内部使用的 `ScrollViewer` 主题。通过 `DockPanel` 将列标题固定在顶部：包含 `TableViewColumnHeadersPresenter` 的 `Border` 停靠到 `Top`，`ScrollContentPresenter` 填充剩余空间。在 `Grid` 布局中包含水平和垂直 `ScrollBar` 元素，行/列为 `*,Auto`。还连接了 `ScrollGestureRecognizer` 以支持触控滚动。

```xml
<!-- Used internally by TableView; can be referenced for custom scroll viewers -->
<ScrollViewer Theme="{StaticResource TableViewScrollViewerTheme}" />
```

**Key resources:** `TableViewColumnHeadersBackground`, `TableViewColumnHeaderPadding`, `TableViewGridLineBrush`

**Template parts:** `ContentPanel` (DockPanel), `PART_ContentPresenter` (ScrollContentPresenter), `PART_HorizontalScrollBar`, `PART_VerticalScrollBar`

#### `TableViewColumnHeaderResizerTemplate`

**Resource Type:** `ControlTemplate` (not a `ControlTheme`)
**Resource Key:** `TableViewColumnHeaderResizerTemplate`
**TargetType:** `Thumb`

A control template for the column resize drag handle (`PART_Resizer` thumb inside `TableViewColumnHeader`). Renders a transparent `Border` with a centered 1-pixel-wide `Rectangle` using `DataGridLineBrush`. The `Thumb` itself is wrapped in the column header template and uses `Cursor="SizeWestEast"`.

列调整大小拖动手柄（`TableViewColumnHeader` 内的 `PART_Resizer` 拇指控件）的控件模板。渲染一个透明 `Border`，内含使用 `DataGridLineBrush` 的居中 1 像素宽 `Rectangle`。`Thumb` 本身包裹在列标题模板中，使用 `Cursor="SizeWestEast"`。

```xml
<!-- Used internally; reference for custom column resizer styling -->
<Thumb Template="{StaticResource TableViewColumnHeaderResizerTemplate}"
       Cursor="SizeWestEast" />
```

**Key resource:** `DataGridLineBrush` — the color of the resize grip line

## FAQ / 常见问题

**Q: How is TableView different from DataGrid? / TableView 与 DataGrid 有何不同？**

A: `TableView` is read-only — it displays data in columns but does not support inline editing, sorting, or filtering. `DataGrid` provides full editing capabilities, column sorting, row/column auto-generation, and grouping. Use `TableView` when you need a lightweight, styled columnar view without the complexity and performance overhead of `DataGrid`.

`TableView` 是只读的 —— 以列形式展示数据但不支持内联编辑、排序或过滤。`DataGrid` 提供完整的编辑功能、列排序、行/列自动生成和分组。当你需要轻量级、带样式的列视图而不需要 `DataGrid` 的复杂性和性能开销时，使用 `TableView`。

**Q: Why are DisplayMemberBinding and ItemTemplate obsolete on TableView? / 为什么 TableView 上的 DisplayMemberBinding 和 ItemTemplate 被废弃？**

A: `TableView` uses per-column bindings and templates via `TableViewColumn.Binding` and `TableViewColumn.CellTemplate`. This provides more granular control — each column can have its own binding and template. The inherited `ItemsControl`-level properties are marked obsolete with compile-time warnings to prevent confusion.

`TableView` 通过 `TableViewColumn.Binding` 和 `TableViewColumn.CellTemplate` 使用每列的绑定和模板。这提供了更细粒度的控制 —— 每列都可以有自己的绑定和模板。继承的 `ItemsControl` 级别属性被标记为废弃并产生编译时警告，以避免混淆。

**Q: Can I change column widths at runtime? / 可以在运行时更改列宽吗？**

A: Yes. Set `CanUserResizeColumns="True"` to let users drag column separators. Programmatically, you can change `TableViewColumn.Width` at any time. After changing widths, `TableView` automatically recalculates column layouts and refreshes headers and cells.

可以。设置 `CanUserResizeColumns="True"` 允许用户拖动列分隔符。编程方面，你可以随时更改 `TableViewColumn.Width`。更改宽度后，`TableView` 会自动重新计算列布局并刷新标题和单元格。
