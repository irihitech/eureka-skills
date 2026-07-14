---
category: Components
title: ComboBox
subtitle: 下拉框
description: 下拉框用于从预定义选项列表中选择一项。
---

# ComboBox / 下拉框

A drop-down selection control that presents a list of items and allows the user to pick one. The selected value is displayed in a text area, and the list expands on click or keyboard interaction. Inherits from `SelectingItemsControl`.

下拉选择控件，展示一个选项列表并允许用户选择一项。选中值显示在文本区域中，列表在点击或键盘交互时展开。继承自 `SelectingItemsControl`。

## When to Use / 何时使用

Use `ComboBox` when you need to present a list of mutually exclusive options in a compact, one-line control that only shows the selected value — ideal for constrained layouts, forms, filters, and settings pages. For a list where all items remain visible, use `ListBox`. For text-entry with suggestion-based completion, use `AutoCompleteBox`. For a small number of boolean-style options, consider `RadioButton` groups.

当你需要以紧凑的单行控件展示互斥选项列表且仅显示选中值时使用 `ComboBox` —— 适用于布局受限的场景、表单、筛选器和设置页面。需要所有项保持可见的列表时使用 `ListBox`。需要基于建议完成功能的文本输入时使用 `AutoCompleteBox`。少量布尔型选项时考虑使用 `RadioButton` 组。

## Basic Usage / 基本使用

```xml
<ComboBox SelectedIndex="0"
          Width="200">
    <ComboBoxItem Content="Option A" />
    <ComboBoxItem Content="Option B" />
    <ComboBoxItem Content="Option C" />
</ComboBox>
```

```xml
<!-- ItemsSource binding with SelectedValue for key/value patterns -->
<ComboBox ItemsSource="{Binding Countries}"
          SelectedValue="{Binding SelectedCountryCode}"
          SelectedValuePath="Code"
          DisplayMemberBinding="{Binding Name}"
          Width="200" />
```

```csharp
// Programmatic creation
var comboBox = new ComboBox
{
    ItemsSource = new List<string> { "Small", "Medium", "Large" },
    SelectedIndex = 0
};
comboBox.SelectionChanged += (s, e) =>
{
    var selected = comboBox.SelectedItem;
};
```

## Common Scenarios / 常用场景

### Editable ComboBox / 可编辑下拉框

Set `IsEditable="True"` to let users type a custom value not in the list. The typed text is accessible via `Text` property.

```xml
<ComboBox IsEditable="True"
          Text="{Binding CustomValue}"
          ItemsSource="{Binding Presets}"
          Watermark="Select or type..."
          Width="200" />
```

### Data Binding with DisplayMemberBinding / 数据绑定

Use `DisplayMemberBinding` (or `DisplayMemberPath` for simple property paths) to control how items appear in the selection box without a full `ItemTemplate`.

```xml
<ComboBox ItemsSource="{Binding Users}"
          DisplayMemberBinding="{Binding FullName}"
          SelectedValue="{Binding SelectedUserId}"
          SelectedValuePath="Id"
          Width="200" />
```

### Custom ItemTemplate / 自定义项模板

Provide a full `ItemTemplate` for complex item rendering with icons, multi-line text, or custom layouts.

```xml
<ComboBox ItemsSource="{Binding Products}"
          SelectedItem="{Binding SelectedProduct}">
    <ComboBox.ItemTemplate>
        <DataTemplate>
            <StackPanel Orientation="Horizontal" Spacing="8">
                <Image Source="{Binding Icon}" Width="24" Height="24" />
                <StackPanel>
                    <TextBlock Text="{Binding Name}" FontWeight="Bold" />
                    <TextBlock Text="{Binding Price}" Foreground="Gray" />
                </StackPanel>
            </StackPanel>
        </DataTemplate>
    </ComboBox.ItemTemplate>
</ComboBox>
```

### Placeholder Text / 占位符文本

Use `Watermark` (Semi.Avalonia) or `PlaceholderText` (Avalonia) to show hint text when no item is selected. Both properties serve the same purpose; `Watermark` is the Semi convention.

```xml
<ComboBox Watermark="Select a country..."
          ItemsSource="{Binding Countries}"
          Width="200" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Items` | `IList` | Collection of items in the drop-down list. Inherited from `ItemsControl`. / 下拉列表中的项集合。继承自 `ItemsControl`。 |
| `ItemsSource` | `IEnumerable?` | Bound data source for the items. Set this instead of populating `Items` manually. / 绑定的数据源。设置此项以替代手动填充 `Items`。 |
| `SelectedItem` | `object?` | The currently selected item. Two-way bindable. / 当前选中的项。支持双向绑定。 |
| `SelectedIndex` | `int` | Zero-based index of the selected item. -1 when no selection. / 选中项的从零开始的索引。无选中时为 -1。 |
| `SelectedValue` | `object?` | The value of the `SelectedValuePath` property on the selected item. / 选中项上 `SelectedValuePath` 属性的值。 |
| `SelectedValuePath` | `string?` | Property path used to extract `SelectedValue` from `SelectedItem`. / 用于从 `SelectedItem` 提取 `SelectedValue` 的属性路径。 |
| `IsEditable` | `bool` | When `true`, the user can type custom text not in the list. / 设为 `true` 时用户可以输入列表中不存在的自定义文本。 |
| `Text` | `string?` | The text displayed in the editable area. Read-write when `IsEditable`; read-only otherwise. / 可编辑区域显示的文本。`IsEditable` 时读写；否则只读。 |
| `IsDropDownOpen` | `bool` | Whether the drop-down popup is currently open. / 下拉弹出层当前是否打开。 |
| `MaxDropDownHeight` | `double` | Maximum height of the drop-down popup before scrolling. / 下拉弹出层出现滚动前的最大高度。 |
| `PlaceholderText` | `string?` | Text shown when no item is selected. Avalonia built-in. / 未选中项时显示的文本。Avalonia 内置属性。 |
| `Watermark` | `string?` | Placeholder hint text. Semi.Avalonia convention — same effect as `PlaceholderText`. / 占位符提示文本。Semi.Avalonia 约定 —— 与 `PlaceholderText` 效果相同。 |
| `PlaceholderForeground` | `IBrush?` | Brush for the placeholder/watermark text. / 占位符文本的画刷。 |
| `ItemTemplate` | `IDataTemplate?` | Template for rendering each item in the drop-down. Inherited from `ItemsControl`. / 用于渲染下拉列表中每项的模板。继承自 `ItemsControl`。 |
| `DisplayMemberBinding` | `IBinding?` | Binding used to extract the display text from each item. Semi.Avalonia extended property. Takes precedence over `DisplayMemberPath`. / 用于从每项提取显示文本的绑定。Semi.Avalonia 扩展属性。优先级高于 `DisplayMemberPath`。 |
| `DisplayMemberPath` | `string?` | Simple property path for item display text. Avalonia built-in. / 项显示文本的简单属性路径。Avalonia 内置。 |
| `IsEnabled` | `bool` | Whether the control can respond to interaction. / 控件是否可以响应交互。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectionChanged` | Raised when the selected item changes. Access removed/added items via `e.RemovedItems` and `e.AddedItems`. / 选中项更改时触发。通过 `e.RemovedItems` 和 `e.AddedItems` 获取移除/添加的项。 |
| `DropDownOpened` | Raised when the drop-down popup opens. / 下拉弹出层打开时触发。 |
| `DropDownClosed` | Raised when the drop-down popup closes. / 下拉弹出层关闭时触发。 |
| `TextChanged` | Raised when the editable text changes (`IsEditable="True"` only). / 可编辑文本更改时触发（仅 `IsEditable="True"` 时）。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides a rich styling system for `ComboBox` with theme variants, color classes, and pseudo-class support. The drop-down button, selection area, and popup are all styled through nested `Style` selectors.

Semi.Avalonia 为 `ComboBox` 提供了丰富的样式系统，包含主题变体、颜色类和伪类支持。下拉按钮、选择区域和弹出层均通过嵌套 `Style` 选择器进行样式化。

### Theme Variants / 主题变体

Choose a theme via the `Theme` attached property. Defaults to Light when not specified.

通过 `Theme` 附加属性选择主题。未指定时默认为 Light。

| Theme / 主题 | Resource Key / 资源键 | Appearance / 外观 |
| --- | --- | --- |
| **Light** (default) | `{x:Type ComboBox}` | Subtle background, visible on hover. / 微妙背景，悬停时可见。 |
| **Outline** | `OutlineComboBox` | Transparent background with colored border. / 透明背景配彩色边框。 |

```xml
<!-- Default Light theme -->
<ComboBox Width="200" />

<!-- Outline theme -->
<ComboBox Theme="{DynamicResource OutlineComboBox}"
          Width="200" />
```

### Color Classes / 颜色类

Apply via the `Classes` attached property. Defaults to `Primary` when no color class is specified. The selected item highlight and focus border use the specified color.

通过 `Classes` 附加属性应用。未指定颜色类时默认为 `Primary`。选中项高亮和焦点边框使用指定颜色。

| Class / 类名 | Description / 说明 |
| --- | --- |
| `Primary` | (default) Blue accent. / （默认）蓝色强调。 |
| `Secondary` | Neutral gray tone. / 中性灰色调。 |
| `Tertiary` | Subtle variant for less prominent controls. / 微妙变体，用于不太突出的控件。 |
| `Success` | Green tone. / 绿色调。 |
| `Warning` | Amber tone. / 琥珀色调。 |
| `Danger` | Red tone. / 红色调。 |

```xml
<ComboBox Classes="Secondary" Width="200" />
<ComboBox Classes="Success" Theme="{DynamicResource OutlineComboBox}" Width="200" />
```

### Size Classes / 尺寸类

| Class / 类名 | Description / 说明 |
| --- | --- |
| *(default)* | Standard size. / 标准尺寸。 |
| `Large` | Larger control with increased padding and font size. / 大号控件，增加内边距和字体大小。 |
| `Small` | Compact control for dense UIs. / 紧凑控件，适用于密集 UI。 |

```xml
<ComboBox Classes="Small" Width="160" />
<ComboBox Classes="Large" Width="240" />
```

### Pseudo-classes / 伪类

Semi.Avalonia styles the following pseudo-classes on `ComboBox`:

Semi.Avalonia 为 `ComboBox` 设置了以下伪类样式：

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:pointerover` | Mouse is hovering over the control. / 鼠标悬停在控件上。 |
| `:pressed` | Drop-down button is pressed. / 下拉按钮被按下。 |
| `:focus` | Control has keyboard focus. / 控件拥有键盘焦点。 |
| `:disabled` | Control is disabled (`IsEnabled = false`). / 控件已禁用。 |
| `:dropdownopen` / `:drop-down-open` | Drop-down popup is open. / 下拉弹出层已打开。 |

### DynamicResource Keys / 动态资源键

Resource keys follow the naming convention `ComboBox{Theme}{Color}{State}{Property}` and resolve via `DynamicResource`:

资源键遵循命名约定 `ComboBox{主题}{颜色}{状态}{属性}`，通过 `DynamicResource` 解析：

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `ComboBoxDefaultHeight` | Default control height / 默认控件高度 |
| `ComboBoxLargeHeight` | Control height in large size / 大尺寸下控件高度 |
| `ComboBoxSmallHeight` | Control height in small size / 小尺寸下控件高度 |
| `ComboBoxDefaultPadding` | Default content padding / 默认内容内边距 |
| `ComboBoxLargePadding` | Content padding in large size / 大尺寸下内容内边距 |
| `ComboBoxSmallPadding` | Content padding in small size / 小尺寸下内容内边距 |
| `ComboBoxDefaultFontSize` | Default font size / 默认字体大小 |
| `ComboBoxForeground` | Text foreground color / 文本前景色 |
| `ComboBoxPlaceholderForeground` | Placeholder/watermark text color / 占位符文本颜色 |
| `ComboBoxDefaultBackground` | Default background brush / 默认背景画刷 |
| `ComboBoxDefaultBorderBrush` | Default border brush / 默认边框画刷 |
| `ComboBoxSelectionBrush` | Selected item highlight brush / 选中项高亮画刷 |
| `ComboBoxDisabledForeground` | Text foreground when disabled / 禁用时文本前景色 |
| `ComboBoxDisabledBackground` | Background when disabled / 禁用时背景 |
| `ComboBoxDisabledBorderBrush` | Border brush when disabled / 禁用时边框画刷 |
| `ComboBoxErrorBorderBrush` | Border brush in error state / 错误状态下边框画刷 |
| `ComboBoxFocusBackground` | Background when focused / 聚焦时背景 |
| `ComboBoxFocusBorderBrush` | Border brush when focused / 聚焦时边框画刷 |
| `ComboBoxPointeroverBackground` | Background on pointerover / 指针悬停时背景 |
| `ComboBoxPointeroverBorderBrush` | Border brush on pointerover / 指针悬停时边框画刷 |
| `ComboBoxPopupBackground` | Drop-down popup background / 下拉弹出层背景 |
| `ComboBoxPopupBorderBrush` | Drop-down popup border brush / 下拉弹出层边框画刷 |
| `ComboBoxPopupBorderThickness` | Drop-down popup border thickness / 下拉弹出层边框粗细 |
| `ComboBoxPopupCornerRadius` | Drop-down popup corner radius / 下拉弹出层圆角 |
| `ComboBoxPopupMargin` | Drop-down popup margin / 下拉弹出层外边距 |
| `ComboBoxPopupPadding` | Drop-down popup padding / 下拉弹出层内边距 |
| `ComboBoxItemBackground` | Item background in default state / 默认状态下项背景 |
| `ComboBoxItemForeground` | Item text foreground / 项文本前景色 |
| `ComboBoxItemPointeroverBackground` | Item background on pointerover / 指针悬停时项背景 |
| `ComboBoxItemPointeroverForeground` | Item text foreground on pointerover / 指针悬停时项文本前景色 |
| `ComboBoxItemSelectedBackground` | Item background when selected / 选中时项背景 |
| `ComboBoxItemSelectedForeground` | Item text foreground when selected / 选中时项文本前景色 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Popup` | `Popup` | The popup that hosts the drop-down items list. / 承载下拉列表的弹出层。 |
| `PART_EditableTextBox` | `TextBox` | The editable text area when `IsEditable="True"`. / `IsEditable="True"` 时的可编辑文本区域。 |

## FAQ / 常见问题

**Q: When should I use ComboBox vs. ListBox? / 何时使用 ComboBox 而非 ListBox？**

A: Use `ComboBox` when you need a compact control that saves screen space by collapsing the list until the user interacts. `ComboBox` shows only the selected item; `ListBox` keeps all (or many) items visible. Use `ComboBox` for forms and toolbars with limited space; use `ListBox` when users need to scan and compare multiple options at once.

当需要节省屏幕空间的紧凑控件时使用 `ComboBox`，列表在用户交互前保持折叠。`ComboBox` 仅显示选中项；`ListBox` 使所有（或许多）项保持可见。空间有限的表单和工具栏使用 `ComboBox`；用户需要同时浏览和比较多选项时使用 `ListBox`。

**Q: How do I set a default/placeholder prompt? / 如何设置默认/占位符提示？**

A: Use the `Watermark` property (Semi.Avalonia convention) or `PlaceholderText` (Avalonia built-in). Both display a hint when `SelectedItem` is `null`. Note: the watermark disappears automatically when an item is selected. Do not add a dummy "Select..." item as the first element — use `Watermark` instead.

使用 `Watermark` 属性（Semi.Avalonia 约定）或 `PlaceholderText`（Avalonia 内置）。两者在 `SelectedItem` 为 `null` 时显示提示。注意：选中项后占位符会自动消失。不要将"请选择…"项作为第一个元素添加到列表中 —— 应使用 `Watermark`。

**Q: How does DisplayMemberBinding differ from DisplayMemberPath? / DisplayMemberBinding 与 DisplayMemberPath 有何不同？**

A: `DisplayMemberPath` accepts a simple string property path (e.g. `"Name"`). `DisplayMemberBinding` (Semi.Avalonia extension) accepts a full `IBinding` expression, allowing converters, string formats, and multi-binding scenarios. When both are set, `DisplayMemberBinding` takes precedence.

`DisplayMemberPath` 接受简单的字符串属性路径（如 `"Name"`）。`DisplayMemberBinding`（Semi.Avalonia 扩展）接受完整的 `IBinding` 表达式，支持转换器、字符串格式化和多重绑定场景。两者同时设置时，`DisplayMemberBinding` 优先。
