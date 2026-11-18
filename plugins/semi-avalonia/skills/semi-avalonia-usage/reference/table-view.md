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
           CanUserResizeColumns="True">
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
                            Classes.warning="{Binding IsWarning}">
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

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


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
