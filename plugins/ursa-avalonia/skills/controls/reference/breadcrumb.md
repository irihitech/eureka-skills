---
category: Navigation
title: Breadcrumb
subtitle: 面包屑
description: >
  Horizontal breadcrumb navigation trail built on ItemsControl. Supports
  data-binding to icon, command, and separator properties, customizable
  separator between items, and read-only mode. The last item is automatically
  styled as the current location.
  基于 ItemsControl 的水平面包屑导航路径。支持数据绑定图标、命令和分隔符属性，
  可自定义项目间的分隔符，以及只读模式。最后一项自动样式化为当前位置。
---

# Breadcrumb / 面包屑

## When to Use / 何时使用

Use `Breadcrumb` to show the user's current location within a hierarchical
navigation structure and allow quick navigation to ancestor levels — file
explorers, settings drill-downs, multi-step wizards, or category browsers.

使用 `Breadcrumb` 显示用户在层级导航结构中的当前位置，并允许快速导航回上级
层级——文件浏览器、设置下钻、多步骤向导或分类浏览器。

Do NOT use Breadcrumb for primary navigation (use `NavMenu`) or for sequential
step indicators (use a `Steps`/`Stepper` pattern).

不要将 Breadcrumb 用于主导航（应使用 `NavMenu`）或顺序步骤指示器（应使用
步骤条模式）。

## Basic Usage / 基本使用

### Declarative items / 声明式项目

```xml
xmlns:u="https://irihi.tech/ursa"

<u:Breadcrumb Separator="/">
    <TextBlock Text="Home" />
    <u:BreadcrumbItem Content="World" Icon="♥" />
    <TextBlock Text="Avalonia" />
    <TextBlock Text="Ursa" />
</u:Breadcrumb>
```

Non-`BreadcrumbItem` children are automatically wrapped in `BreadcrumbItem`
containers. The default separator is `/`.

非 `BreadcrumbItem` 子元素会自动包装在 `BreadcrumbItem` 容器中。默认分隔符
为 `/`。

### Data-driven (MVVM) / 数据驱动

```xml
<u:Breadcrumb ItemsSource="{Binding PathItems}"
              DisplayMemberBinding="{Binding Name}"
              IconBinding="{Binding IconData}"
              CommandBinding="{Binding NavigateCommand}"
              Separator="/" />
```

```csharp
public class BreadcrumbPathItem
{
    public string Name { get; set; }
    public IImage? IconData { get; set; }
    public ICommand NavigateCommand { get; set; }
}
```

### Custom separator / 自定义分隔符

```xml
<u:Breadcrumb>
    <u:Breadcrumb.Separator>
        <PathIcon Data="{StaticResource ChevronRightIcon}" />
    </u:Breadcrumb.Separator>
    <!-- items -->
</u:Breadcrumb>
```

The `Separator` property accepts a raw string (rendered as text) or an
`ITemplate<Control?>` (rendered as a control instance). Any other object is
rendered via `ToString()`.

`Separator` 属性接受原始字符串（渲染为文本）或 `ITemplate<Control?>`（渲染
为控件实例）。其他对象通过 `ToString()` 渲染。

## Common Scenarios / 常用场景

### 1. Read-only last item / 只读最后一项

```xml
<u:Breadcrumb ItemsSource="{Binding PathItems}">
    <u:Breadcrumb.ItemTemplate>
        <DataTemplate>
            <u:BreadcrumbItem Content="{Binding Name}"
                              IsReadOnly="{Binding IsLast}" />
        </DataTemplate>
    </u:Breadcrumb.ItemTemplate>
</u:Breadcrumb>
```

When `IsReadOnly="True"`, the item is not clickable and cursor remains default.
Set this on the last item to indicate it's the current page.

当 `IsReadOnly="True"` 时，项目不可点击，光标保持默认。在最后一项上设置此属性
以表示当前页面。

### 2. Icon-only items / 仅图标的项目

```xml
<u:Breadcrumb ItemsSource="{Binding PathItems}"
              IconBinding="{Binding Icon}"
              DisplayMemberBinding="{Binding Name}">
    <u:Breadcrumb.IconTemplate>
        <DataTemplate>
            <PathIcon Data="{Binding}" />
        </DataTemplate>
    </u:Breadcrumb.IconTemplate>
</u:Breadcrumb>
```

### 3. Navigate on click with command / 点击导航带命令

```xml
<u:Breadcrumb ItemsSource="{Binding PathItems}"
              DisplayMemberBinding="{Binding Name}"
              CommandBinding="{Binding GoToCommand}"
              CommandParameterBinding="{Binding NodeId}" />
```

Each `BreadcrumbItem` executes its `Command` (with `CommandParameter`) on
pointer press, unless `IsReadOnly` is true.

每个 `BreadcrumbItem` 在指针按下时执行其 `Command`（带 `CommandParameter`），
除非 `IsReadOnly` 为 true。

## Property Reference / 属性参考

### Breadcrumb Properties / Breadcrumb 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `ItemsSource` | `IEnumerable?` | `null` | Data source (inherited) / 数据源（继承） |
| `DisplayMemberBinding` | `BindingBase?` | `null` | Binding for item display text (inherited) / 项目显示文本的绑定（继承） |
| `ItemTemplate` | `IDataTemplate?` | `null` | Template for items (inherited) / 项目模板（继承） |
| `ItemsPanel` | `ITemplate<Panel?>` | Horizontal StackPanel | Layout panel (inherited, default: horizontal) / 布局面板（继承，默认：水平） |
| `IconBinding` | `BindingBase?` | `null` | Binding for item icon / 项目图标的绑定 |
| `IconTemplate` | `IDataTemplate?` | `null` | Shared template for icons / 图标共享模板 |
| `CommandBinding` | `BindingBase?` | `null` | Binding for item command / 项目命令的绑定 |
| `CommandParameterBinding` | `BindingBase?` | `null` | Binding for command parameter / 命令参数的绑定 |
| `Separator` | `object?` | `/` | Separator between items (string or ITemplate) / 项目间的分隔符（字符串或 ITemplate） |

### BreadcrumbItem Properties / BreadcrumbItem 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Content` | `object?` | `null` | Display text (inherited from ContentControl) / 显示文本（继承自 ContentControl） |
| `ContentTemplate` | `IDataTemplate?` | `null` | Content template / 内容模板 |
| `Icon` | `object?` | `null` | Icon content / 图标内容 |
| `IconTemplate` | `IDataTemplate?` | `null` | Icon template; inherited from Breadcrumb.IconTemplate if unset / 图标模板；未设置时继承自 Breadcrumb.IconTemplate |
| `Command` | `ICommand?` | `null` | Command executed on click / 点击时执行的命令 |
| `CommandParameter` | `object?` | `null` | Parameter passed to command / 传递给命令的参数 |
| `Separator` | `object?` | (inherited) | Per-item separator override / 单项分隔符覆盖 |
| `IsReadOnly` | `bool` | `false` | When true, item is not clickable / 为 true 时项目不可点击 |

## Events / 事件

Breadcrumb and BreadcrumbItem do not define custom events. Use `Command` on
`BreadcrumbItem` (via `CommandBinding` on `Breadcrumb`) to handle navigation
clicks. The command is executed on `PointerPressed`.

Breadcrumb 和 BreadcrumbItem 未定义自定义事件。使用 `BreadcrumbItem` 上的
`Command`（通过 `Breadcrumb` 上的 `CommandBinding`）处理导航点击。命令在
`PointerPressed` 时执行。

## Styling & Templating / 样式与模板

### Pseudo-classes / 伪类

| Pseudo-class | Control | Condition |
|---|---|---|
| `:last` | `BreadcrumbItem` | Item is the last in the collection / 该项是集合中的最后一项 |

### Last-item Styling / 最后一项样式

When `:last` is active:

- `PART_IconPresenter` foreground → `BreadcrumbItemLastForeground`
- `PART_ContentPresenter` foreground → `BreadcrumbItemLastForeground` and
  `FontWeight` → `TextBlockTitleFontWeight`
- Separator `ContentPresenter` is hidden (`IsVisible="False"`)

当 `:last` 激活时：

- `PART_IconPresenter` 前景色 → `BreadcrumbItemLastForeground`
- `PART_ContentPresenter` 前景色 → `BreadcrumbItemLastForeground` 且
  `FontWeight` → `TextBlockTitleFontWeight`
- 分隔符 `ContentPresenter` 隐藏 (`IsVisible="False"`)

### Hover Styling / 悬停样式

When `IsReadOnly="False"` and `:pointerover` is active:

- Both `PART_IconPresenter` and `PART_ContentPresenter` use
  `BreadcrumbItemPointeroverForeground`
- Cursor is set to `Hand`

当 `IsReadOnly="False"` 且 `:pointerover` 激活时：

- `PART_IconPresenter` 和 `PART_ContentPresenter` 均使用
  `BreadcrumbItemPointeroverForeground`
- 光标设为 `Hand`

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `BreadcrumbItemForeground` | Normal item | Default text/icon color / 默认文字/图标颜色 |
| `BreadcrumbItemLastForeground` | Last item | Current-location text/icon color / 当前位置文字/图标颜色 |
| `BreadcrumbItemSeparatorForeground` | Separator | Separator text color / 分隔符文字颜色 |
| `BreadcrumbItemPointeroverForeground` | Hovered item | Hover text/icon color / 悬停文字/图标颜色 |

### Template Parts / 模板部件

#### Breadcrumb

| Part Name | Control | Type |
|---|---|---|
| (none) | `Breadcrumb` | Uses `ItemsPresenter` only |

#### BreadcrumbItem

| Part Name | Control | Type |
|---|---|---|
| `PART_IconPresenter` | `BreadcrumbItem` | `ContentPresenter` |
| `PART_ContentPresenter` | `BreadcrumbItem` | `ContentPresenter` |
| `Separator` | `BreadcrumbItem` | `ContentPresenter` |

## FAQ / 常见问题

**Q: How do I handle navigation when an item is clicked?**
A: Set `CommandBinding` on `Breadcrumb` (or `Command` on individual
`BreadcrumbItem`). The command fires on `PointerPressed` unless
`IsReadOnly="True"`.

**Q: How do I make the last item non-clickable?**
A: Set `IsReadOnly="True"` on the last `BreadcrumbItem`. In data-driven mode,
bind `IsReadOnly` to a property that is true for the last item.

**Q: How do I change the separator?**
A: Set `Separator` on `Breadcrumb`. Use a string for text separators (e.g.,
`"/"` or `">"`), or a `ControlTemplate`/`ITemplate<Control?>` for icon
separators.

**Q: How do I bind icons from a data source?**
A: Use `IconBinding` on `Breadcrumb` to bind each item's icon property.
Optionally provide `IconTemplate` for a shared icon rendering template.

**Q: Why doesn't my CommandBinding fire? / 为什么 CommandBinding 不触发？**
A: Check that `IsReadOnly` is not `true` on the item. Also ensure the
`CommandBinding` is set on `Breadcrumb`, not on individual items, unless
you are setting `Command` directly on `BreadcrumbItem`.

**Q: Can I use BreadcrumbItem directly without Breadcrumb?**
A: Yes, `BreadcrumbItem` can be used standalone, but you lose auto-container
generation and inherited binding propagation provided by `Breadcrumb`.
