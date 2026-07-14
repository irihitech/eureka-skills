---
category: Components
title: Descriptions
subtitle: 描述列表
description: 用于展示键值对数据的列表控件，支持横向/纵向布局、多种对齐方式和项目模板自定义。
---

## Descriptions / 描述列表

An `ItemsControl`-based component for displaying key-value pairs in a structured list. Each item is a `DescriptionsItem` (which extends `LabeledContentControl`) with a label and content. Supports horizontal (`ColumnWrapPanel`) and vertical (`StackPanel`) orientations, four alignment modes (`Center`, `Left`, `Justify`, `Plain`), and bindable label/content templates.

基于 `ItemsControl` 的键值对结构化展示组件。每个项目是一个 `DescriptionsItem`（继承自 `LabeledContentControl`），包含标签和内容。支持横向（`ColumnWrapPanel`）和纵向（`StackPanel`）布局、四种对齐模式（`Center`、`Left`、`Justify`、`Plain`）以及可绑定的标签/内容模板。

## When to Use / 何时使用

Use `Descriptions` when you need to display a set of labeled data fields — for example, user profile summaries, product specifications, or metadata panels. It is similar to HTML `<dl>` lists. For form input layout, use `Form` instead. For simple read-only labels, use `Label` + `TextBlock`.

当你需要展示一组带标签的数据字段时使用 `Descriptions` —— 例如用户资料摘要、产品规格或元数据面板。类似 HTML 的 `<dl>` 列表。对于表单输入布局，请使用 `Form`。对于简单只读标签，请使用 `Label` + `TextBlock`。

## Basic Usage / 基本使用

```xml
<!-- XAML Inline -->
<u:Descriptions>
    <u:DescriptionsItem Label="Username" Content="Alice" />
    <u:DescriptionsItem Label="Email" Content="alice@example.com" />
    <u:DescriptionsItem Label="Role" Content="Administrator" />
</u:Descriptions>
```

```xml
<!-- MVVM binding -->
<u:Descriptions
    ItemsSource="{Binding Items}"
    LabelMemberBinding="{Binding Label}"
    DisplayMemberBinding="{Binding Value}" />
```

## Common Scenarios / 常用场景

### Horizontal Layout with Top Labels / 横向布局顶部标签

```xml
<u:Descriptions Orientation="Horizontal" LabelPosition="Top" ItemAlignment="Center">
    <u:DescriptionsItem Label="Active Users" Content="1,480,000" />
    <u:DescriptionsItem Label="7-Day Retention" Content="98%" />
    <u:DescriptionsItem Label="Security Level" Content="Level 3" />
</u:Descriptions>
```

### Vertical Layout with Left Labels / 纵向布局左侧标签

```xml
<u:Descriptions Orientation="Vertical" LabelPosition="Left" ItemAlignment="Center"
                LabelWidth="120">
    <u:DescriptionsItem Label="Name" Content="Alice" />
    <u:DescriptionsItem Label="Department" Content="Engineering" />
    <u:DescriptionsItem Label="Location" Content="Shanghai" />
</u:Descriptions>
```

### Rich Content in Values / 值中的富内容

Items can contain any content, not just text:

```xml
<u:Descriptions>
    <u:DescriptionsItem Label="7-Day Retention">
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="98%" />
            <PathIcon Classes="Small" Data="{DynamicResource SemiIconArrowUp}"
                      Foreground="{DynamicResource SemiGreen5}" />
        </StackPanel>
    </u:DescriptionsItem>
    <u:DescriptionsItem Label="Tags">
        <Label Theme="{DynamicResource TagLabel}" Content="E-Commerce" />
    </u:DescriptionsItem>
</u:Descriptions>
```

### Multi-column with ColumnWrapPanel / 多列布局

Use a custom `ItemsPanel` for multi-column display:

```xml
<u:Descriptions ItemAlignment="Plain">
    <u:Descriptions.ItemsPanel>
        <ItemsPanelTemplate>
            <u:ColumnWrapPanel Column="5" />
        </ItemsPanelTemplate>
    </u:Descriptions.ItemsPanel>
    <u:Descriptions.ItemsSource>
        <!-- items -->
    </u:Descriptions.ItemsSource>
</u:Descriptions>
```

### Size Variants / 尺寸变体

```xml
<!-- Small: compact labels and values -->
<u:Descriptions Classes="Small" Orientation="Horizontal" LabelPosition="Top">
    <u:DescriptionsItem Label="Users" Content="100" />
</u:Descriptions>

<!-- Default -->
<u:Descriptions Orientation="Horizontal" LabelPosition="Top">
    <u:DescriptionsItem Label="Users" Content="100" />
</u:Descriptions>

<!-- Large: prominent labels and values -->
<u:Descriptions Classes="Large" Orientation="Horizontal" LabelPosition="Top">
    <u:DescriptionsItem Label="Users" Content="100" />
</u:Descriptions>
```

## Property Reference / 属性参考

### Descriptions Properties / Descriptions 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `ItemsSource` | `IEnumerable?` | Data source (inherited from `ItemsControl`). / 数据源（继承自 `ItemsControl`）。 |
| `LabelTemplate` | `IDataTemplate?` | Template for the label column. Cannot be used together with `LabelMemberBinding`. / 标签列模板。不能与 `LabelMemberBinding` 同时使用。 |
| `LabelMemberBinding` | `BindingBase?` | Binding for the label, extracted from each data item. Cannot be used together with `LabelTemplate`. / 标签绑定，从每个数据项中提取。不能与 `LabelTemplate` 同时使用。 |
| `DisplayMemberBinding` | `BindingBase?` | Binding for the value, extracted from each data item (inherited). / 值绑定，从每个数据项中提取（继承自基类）。 |
| `LabelPosition` | `Position` | Label position relative to content: `Top`, `Left`, `Right`, `Bottom`. / 标签相对于内容的位置。 |
| `LabelWidth` | `GridLength` | Width of the label column. When absolute, sets a fixed pixel width. / 标签列宽度。当为绝对像素值时，设置固定宽度。 |
| `ItemAlignment` | `ItemAlignment` | Alignment mode: `Center`, `Left`, `Justify`, `Plain`. / 对齐模式。 |
| `Orientation` | `Orientation` | Layout direction: `Vertical` (default) or `Horizontal`. / 布局方向：`Vertical`（默认）或 `Horizontal`。 |

### DescriptionsItem Properties / DescriptionsItem 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Label` | `object?` | The label content (inherited from `LabeledContentControl`). / 标签内容（继承自 `LabeledContentControl`）。 |
| `Content` | `object?` | The value content (inherited from `ContentControl`). / 值内容（继承自 `ContentControl`）。 |
| `LabelPosition` | `Position` | Per-item override for label position. / 每项标签位置覆盖。 |
| `ItemAlignment` | `ItemAlignment` | Per-item override for alignment. / 每项对齐覆盖。 |
| `LabelWidth` | `double` | Per-item label width in pixels. / 每项标签像素宽度。 |

### ItemAlignment Enum / ItemAlignment 枚举

| Value / 值 | Label alignment / 标签对齐 | Content alignment / 内容对齐 | Colon / 冒号 |
| --- | --- | --- | --- |
| `Center` | Right | Left | Hidden |
| `Left` | Left | Left | Hidden |
| `Justify` | Left | Right | Hidden |
| `Plain` | Default flow | Default flow | Visible (when label is not empty) |

## Styling & Templating / 样式与模板

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:fixed-width` | On `Descriptions` when `ItemAlignment != Plain`. Enables `Grid.IsSharedSizeScope`. / 在 `Descriptions` 上当 `ItemAlignment != Plain` 时启用。 |
| `:horizontal` | On `DescriptionsItem` when `LabelPosition` is `Left` or `Right`. / 当 `LabelPosition` 为 `Left` 或 `Right` 时在 `DescriptionsItem` 上启用。 |
| `:vertical` | On `DescriptionsItem` when `LabelPosition` is `Top` or `Bottom`. / 当 `LabelPosition` 为 `Top` 或 `Bottom` 时在 `DescriptionsItem` 上启用。 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Label` | `Label` | Label element. / 标签元素。 |
| `PART_Colon` | `TextBlock` | Colon separator (":"), visible in `Plain` mode when label is not empty. / 冒号分隔符（":"），在 `Plain` 模式下标签非空时可见。 |
| `PART_ContentPresenter` | `ContentPresenter` | Content host. / 内容宿主。 |

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `DescriptionsKeyTextForeground` | Label text color. / 标签文本颜色。 |
| `DescriptionsValueTextForeground` | Value text color. / 值文本颜色。 |
| `DescriptionsValueFontWeight` | Value font weight (vertical mode). / 值字体粗细（纵向模式）。 |
| `DescriptionsLineHeight` | Shared line height. / 共享行高。 |
| `DescriptionsItemMargin` | Margin around each item. / 每个项目的边距。 |
| `DescriptionsKeyPadding` | Label padding in aligned modes. / 对齐模式下的标签内边距。 |
| `DescriptionsKeyPlainMargin` | Colon margin in Plain mode. / Plain 模式下的冒号边距。 |
| `DescriptionsKeyMediumMargin` / `DescriptionsKeyMediumFontSize` | Medium (default) label styling. / 中等（默认）标签样式。 |
| `DescriptionsValueMediumMargin` / `DescriptionsValueMediumFontSize` | Medium (default) value styling. / 中等（默认）值样式。 |
| `DescriptionsKeySmallMargin` / `DescriptionsKeySmallFontSize` | Small variant label styling. / Small 变体标签样式。 |
| `DescriptionsValueSmallMargin` / `DescriptionsValueSmallFontSize` | Small variant value styling. / Small 变体值样式。 |
| `DescriptionsKeyLargeMargin` / `DescriptionsKeyLargeFontSize` | Large variant label styling. / Large 变体标签样式。 |
| `DescriptionsValueLargeMargin` / `DescriptionsValueLargeFontSize` | Large variant value styling. / Large 变体值样式。 |

## FAQ / 常见问题

**Q: What is the difference between Descriptions and Form? / Descriptions 与 Form 有何区别？**

A: `Descriptions` is for read-only key-value display. `Form` is for editable input layout with labels, validation, and field grouping. Use `Descriptions` for detail views; use `Form` for data entry. / `Descriptions` 用于只读键值展示。`Form` 用于带标签、验证和字段分组的可编辑输入布局。详情视图使用 `Descriptions`；数据录入使用 `Form`。

**Q: Why can't I set both LabelTemplate and LabelMemberBinding? / 为什么不能同时设置 LabelTemplate 和 LabelMemberBinding？**

A: They are mutually exclusive. If both are set, an `InvalidOperationException` is thrown. Use `LabelMemberBinding` for simple property-based labels; use `LabelTemplate` when you need custom label rendering. / 它们是互斥的。如果同时设置会抛出 `InvalidOperationException`。简单的基于属性的标签使用 `LabelMemberBinding`；需要自定义标签渲染时使用 `LabelTemplate`。

**Q: How does shared size scoping work in Descriptions? / Descriptions 中的共享尺寸范围如何工作？**

A: When `ItemAlignment` is `Center`, `Left`, or `Justify` (not `Plain`), the `Descriptions` control sets the `:fixed-width` pseudo-class, which enables `Grid.IsSharedSizeScope = True`. A shared size group named `"Label"` is used on the label column, so all items' labels have the same width. / 当 `ItemAlignment` 为 `Center`、`Left` 或 `Justify`（非 `Plain`）时，`Descriptions` 控件设置 `:fixed-width` 伪类，启用 `Grid.IsSharedSizeScope = True`。标签列使用名为 `"Label"` 的共享尺寸组，因此所有项目的标签宽度一致。
