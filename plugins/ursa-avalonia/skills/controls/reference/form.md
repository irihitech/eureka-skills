---
category: Components
title: Form
subtitle: 表单
description: 用于创建带标签、必填标记和字段分组的输入表单布局控件，支持横向和纵向标签位置、自动标签对齐以及 MVVM 动态表单生成。
---

## Form / 表单

An `ItemsControl`-based form layout component. Each child becomes a `FormItem` (or `FormGroup` for section headers), which renders a label, optional required asterisk, and content slot. Supports horizontal (label-left) and vertical (label-top) label positioning, fixed or auto label width via `GridLength`, and MVVM-driven dynamic form generation through `ItemsSource` binding.

基于 `ItemsControl` 的表单布局组件。每个子项变为 `FormItem`（或用于分区标题的 `FormGroup`），渲染标签、可选必填星号标记和内容槽。支持横向（标签在左）和纵向（标签在顶）标签定位、通过 `GridLength` 的固定或自动标签宽度，以及通过 `ItemsSource` 绑定的 MVVM 驱动动态表单生成。

## When to Use / 何时使用

Use `Form` when you need a labeled input layout — for example, settings pages, data entry forms, or configuration panels. It handles label alignment, required-field markers, and accessibility (label-target association). For read-only key-value display, use `Descriptions`. For simple single-field input, use `Label` + control directly.

当你需要带标签的输入布局时使用 `Form` —— 例如设置页面、数据录入表单或配置面板。它处理标签对齐、必填字段标记和无障碍访问（标签-目标关联）。对于只读键值展示，请使用 `Descriptions`。对于简单单字段输入，请直接使用 `Label` + 控件。

## Basic Usage / 基本使用

```xml
<u:Form LabelPosition="Left" LabelWidth="*">
    <TextBox Width="300" u:FormItem.Label="Name" u:FormItem.IsRequired="True" />
    <TextBox Width="300" u:FormItem.Label="Email" />
    <TextBox Width="300" u:FormItem.Label="Message" Classes="TextArea" />
</u:Form>
```

```csharp
// Attached properties allow any control to carry form metadata
FormItem.SetLabel(myTextBox, "Username");
FormItem.SetIsRequired(myTextBox, true);
```

## Common Scenarios / 常用场景

### Label Positioning / 标签定位

```xml
<!-- Label on top (default) -->
<u:Form LabelPosition="Top" LabelWidth="*">
    <TextBox Width="300" u:FormItem.Label="Name" />
    <TextBox Width="300" u:FormItem.Label="Email" />
</u:Form>

<!-- Label on the left with fixed width -->
<u:Form LabelPosition="Left" LabelWidth="100">
    <TextBox Width="300" u:FormItem.Label="Name" />
    <TextBox Width="300" u:FormItem.Label="Email" />
</u:Form>

<!-- Label on the left with auto (star) width — all labels align to widest -->
<u:Form LabelPosition="Left" LabelWidth="*">
    <TextBox Width="300" u:FormItem.Label="Name" />
    <TextBox Width="300" u:FormItem.Label="Email Address" />
</u:Form>
```

### Required Fields / 必填字段

```xml
<u:Form LabelPosition="Left" LabelWidth="*">
    <TextBox Width="300" u:FormItem.Label="Name" u:FormItem.IsRequired="True" />
    <TextBox Width="300" u:FormItem.Label="Email" u:FormItem.IsRequired="True" />
    <TextBox Width="300" u:FormItem.Label="Notes" />
</u:Form>
```

Required fields display a red asterisk (`*`) next to the label.

### Form Groups / 表单分组

Use `FormGroup` to section the form with headers:

```xml
<u:Form LabelPosition="Left" LabelWidth="*">
    <u:FormGroup Header="Basic Information">
        <TextBox Width="300" u:FormItem.Label="Name" />
        <TextBox Width="300" u:FormItem.Label="Email" />
    </u:FormGroup>
    <u:FormGroup Header="Education">
        <TextBox Width="300" u:FormItem.Label="College" />
        <u:FormItem Label="Study Time">
            <u:DateRangePicker Width="300" />
        </u:FormItem>
    </u:FormGroup>
    <Button Content="Submit" u:FormItem.NoLabel="True"
            HorizontalAlignment="Stretch" />
</u:Form>
```

### No-Label Items / 无标签项目

Use `u:FormItem.NoLabel="True"` to hide the label column for items like submit buttons:

```xml
<Button Content="Submit" u:FormItem.NoLabel="True"
        HorizontalAlignment="Stretch" />
```

### MVVM Dynamic Forms / MVVM 动态表单

```xml
<u:Form ItemsSource="{Binding FormGroups}"
        LabelPosition="Left" LabelWidth="*"
        HorizontalAlignment="Stretch">
    <u:Form.Styles>
        <Style Selector="u|FormGroup" x:DataType="vm:IFormGroupViewModel">
            <Setter Property="Header" Value="{Binding Title}" />
            <Setter Property="ItemsSource" Value="{Binding Items}" />
        </Style>
        <Style Selector="u|FormItem" x:DataType="vm:IFromItemViewModel">
            <Setter Property="Label" Value="{Binding Label}" />
        </Style>
    </u:Form.Styles>
    <u:Form.ItemTemplate>
        <!-- DataTemplateSelector mapping item types to controls -->
        <dataTemplates:FormDataTemplateSelector>
            <DataTemplate x:Key="{x:Type vm:FormTextViewModel}">
                <TextBox Text="{Binding Value}" />
            </DataTemplate>
            <DataTemplate x:Key="{x:Type vm:FormAgeViewModel}">
                <u:NumericUIntUpDown Value="{Binding Age}" />
            </DataTemplate>
        </dataTemplates:FormDataTemplateSelector>
    </u:Form.ItemTemplate>
</u:Form>
```

### Accessibility / 无障碍

Labels support access keys with underscore prefix:

```xml
<u:Form LabelPosition="Left" LabelWidth="*">
    <TextBox Width="300" u:FormItem.Label="_Name" />
    <TextBox Width="300" u:FormItem.Label="_Email" />
    <TextBox Width="300" u:FormItem.Label="_Message" Classes="TextArea" />
</u:Form>
```

The `FormItem` automatically sets `Label.Target` to the first focusable `InputElement` in its content, enabling Alt+key navigation.

## Property Reference / 属性参考

### Form Properties / Form 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `LabelWidth` | `GridLength` | Width of the label column. `Absolute` = fixed pixels; `Star` / `Auto` = aligned to max width; `Auto` = no alignment. / 标签列宽度。`Absolute` = 固定像素；`Star` / `Auto` = 对齐至最大宽度；`Auto` = 不对齐。 |
| `LabelPosition` | `Position` | Label position: `Top` (default), `Left`, `Right`, `Bottom`. / 标签位置：`Top`（默认）、`Left`、`Right`、`Bottom`。 |
| `LabelAlignment` | `HorizontalAlignment` | Horizontal alignment of the label within its column. Default `Left`. / 标签在其列内的水平对齐。默认 `Left`。 |
| `ItemsSource` | `IEnumerable?` | Data source for dynamic forms (inherited). / 动态表单的数据源（继承）。 |
| `ItemTemplate` | `IDataTemplate?` | Template for the content of each item (inherited). / 每个项目内容的模板（继承）。 |

### FormItem Properties / FormItem 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `FormItem.Label` (attached) | `object?` | Label text for a child control. / 子控件的标签文本。 |
| `FormItem.IsRequired` (attached) | `bool` | Whether the field is required (shows red asterisk). / 字段是否必填（显示红色星号）。 |
| `FormItem.NoLabel` (attached) | `bool` | When true, hides the label column for this item. / 设为 true 时隐藏此项目的标签列。 |
| `LabelWidth` | `double` | Per-item label width override (received from `Form.LabelWidth`). / 每项标签宽度覆盖（从 `Form.LabelWidth` 接收）。 |
| `LabelAlignment` | `HorizontalAlignment` | Per-item label alignment (received from `Form`). / 每项标签对齐（从 `Form` 接收）。 |

### FormGroup Properties / FormGroup 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Header` | `object?` | Section header text. / 分区标题文本。 |
| `ItemsSource` | `IEnumerable?` | Data source for items in this group (inherited). / 此组项目的数据源（继承）。 |
| `ItemTemplate` | `IDataTemplate?` | Item content template (inherited). / 项目内容模板（继承）。 |

## Styling & Templating / 样式与模板

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Class / 类 | Description / 说明 |
| --- | --- | --- |
| `:fixed-width` | `Form` | Enabled when `LabelWidth` is `Star` or `Absolute`. Enables `Grid.IsSharedSizeScope`. / 当 `LabelWidth` 为 `Star` 或 `Absolute` 时启用。 |
| `:horizontal` | `FormItem` | Enabled when parent `Form.LabelPosition` is `Left`. Uses 2-column grid template. / 当父级 `Form.LabelPosition` 为 `Left` 时启用。使用两列 Grid 模板。 |
| `:no-label` | `FormItem` | Enabled when `NoLabel="True"`. Renders content only. / 当 `NoLabel="True"` 时启用。仅渲染内容。 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Label` | `Label` | The label element, with `Target` bound to the content's first focusable element. / 标签元素，其 `Target` 绑定到内容的第一个可聚焦元素。 |
| `PART_LabelPanel` | `StackPanel` | Horizontal panel containing label + required asterisk. / 包含标签和必填星号的横向面板。 |
| `PART_ContentPresenter` | `ContentPresenter` | Content host. / 内容宿主。 |

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `FormAsteriskForeground` | Color of the required-field asterisk. / 必填字段星号颜色。 |
| `FormGroupForeground` | Color of the FormGroup header separator line. / FormGroup 标题分隔线颜色。 |
| `TextBlockTitleFontWeight` | Font weight for labels and group headers. / 标签和分组标题的字体粗细。 |

## FAQ / 常见问题

**Q: How does LabelWidth="*" work? / LabelWidth="*" 如何工作？**

A: When `LabelWidth` is `Star` or `Absolute`, the `Form` sets `:fixed-width`, enabling `Grid.IsSharedSizeScope = True`. The `FormItem` horizontal template uses `SharedSizeGroup="Label"` on the label column, so all labels align to the widest label. `/`FontWeight` 当 `LabelWidth` 为 `Star` 或 `Absolute` 时，`Form` 设置 `:fixed-width`，启用 `Grid.IsSharedSizeScope = True`。`FormItem` 横向模板在标签列上使用 `SharedSizeGroup="Label"`，因此所有标签对齐到最宽的标签。

**Q: What's the difference between FormItem and FormGroup? / FormItem 与 FormGroup 有何区别？**

A: `FormItem` wraps a single labeled field (label + content). `FormGroup` is a `HeaderedItemsControl` that groups multiple `FormItem` children under a section header with a separator line. / `FormItem` 包装单个带标签字段（标签+内容）。`FormGroup` 是一个 `HeaderedItemsControl`，将多个 `FormItem` 子项分组到带分隔线的分区标题下。

**Q: Can I use custom controls inside a Form? / 可以在 Form 中使用自定义控件吗？**

A: Yes. Any `Control` with `u:FormItem.Label` attached property becomes a `FormItem`. The `Form` automatically detects `IFormGroup` implementations and wraps non-`FormItem`/non-`FormGroup` items in `FormItem` containers. / 可以。任何带有 `u:FormItem.Label` 附加属性的 `Control` 都会成为 `FormItem`。`Form` 会自动检测 `IFormGroup` 实现，并将非 `FormItem`/非 `FormGroup` 项目包装在 `FormItem` 容器中。
