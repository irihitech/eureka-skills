---
category: Components
title: AutoCompleteBox (Ursa)
subtitle: 自动完成框（Ursa）
description: >
  Ursa-enhanced AutoCompleteBox with a clear button, open-on-click/focus behavior,
  and a MultiAutoCompleteBox variant for multi-selection with chip display.
  Supports async population, custom filter predicates, ValueMemberBinding,
  InnerLeft/InnerRight content, size variants, and PlaceholderText.
  Ursa 增强的 AutoCompleteBox，带清除按钮、点击/聚焦时打开下拉框的行为，以及支持
  标签显示多选的 MultiAutoCompleteBox 变体。支持异步填充、自定义过滤谓词、
  ValueMemberBinding、InnerLeft/InnerRight 内容、尺寸变体和 PlaceholderText。
---

# AutoCompleteBox (Ursa) / 自动完成框（Ursa）

## When to Use / 何时使用

Use `AutoCompleteBox` for single-selection text-based lookup — search boxes, type-ahead
selectors, or any input where the user types to filter and selects one result.
Use `MultiAutoCompleteBox` when the user needs to select multiple items from a
searchable list, displayed as removable chips in the input area.

当需要基于文本的单选查找时使用 `AutoCompleteBox`——搜索框、即输即搜选择器，或
任何用户输入以过滤并选择单个结果的输入场景。当用户需要从可搜索列表中选择多个
项目并以可移除标签显示在输入区域时，使用 `MultiAutoCompleteBox`。

Do NOT use `AutoCompleteBox` for simple single-selection from a fixed small list —
a standard `ComboBox` is lighter. Do NOT use `MultiAutoCompleteBox` when items
have a hierarchical relationship — use `TreeComboBox` instead.

不要将 `AutoCompleteBox` 用于从固定小列表中进行简单单选——标准 `ComboBox` 更轻量。
不要将 `MultiAutoCompleteBox` 用于项目具有层次关系时——应使用 `TreeComboBox`。

## Basic Usage / 基本使用

### Single AutoCompleteBox / 单选自动完成框

```xml
xmlns:u="https://irihi.tech/ursa"

<u:AutoCompleteBox Width="300"
                   PlaceholderText="Please select a Control"
                   Classes="ClearButton"
                   ItemsSource="{Binding Controls}"
                   ValueMemberBinding="{ReflectionBinding MenuHeader}"
                   SelectedItem="{Binding SelectedControl}">
    <u:AutoCompleteBox.ItemTemplate>
        <DataTemplate>
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="{Binding MenuHeader}" VerticalAlignment="Center" />
                <TextBlock Text="{Binding Chinese}" Classes="Secondary"
                           FontSize="12" Margin="8 0 0 0"
                           VerticalAlignment="Center" />
            </StackPanel>
        </DataTemplate>
    </u:AutoCompleteBox.ItemTemplate>
</u:AutoCompleteBox>
```

`ValueMemberBinding` specifies which property to display as text in the input
field. Use `Classes="ClearButton"` to show a clear (×) button on focus/hover.

`ValueMemberBinding` 指定在输入字段中显示哪个属性作为文本。使用
`Classes="ClearButton"` 在聚焦/悬停时显示清除（×）按钮。

### MultiAutoCompleteBox / 多选自动完成框

```xml
<u:MultiAutoCompleteBox ItemsSource="{Binding Items}"
                         HorizontalAlignment="Left"
                         MaxWidth="400"
                         SelectedItems="{Binding SelectedItems}"
                         FilterMode="Custom"
                         ItemFilter="{Binding FilterPredicate}">
    <u:MultiAutoCompleteBox.ItemTemplate>
        <DataTemplate>
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="{Binding MenuHeader}" />
                <TextBlock Text="{Binding Chinese}" Classes="Secondary"
                           FontSize="12" Margin="8 0 0 0" />
            </StackPanel>
        </DataTemplate>
    </u:MultiAutoCompleteBox.ItemTemplate>
    <u:MultiAutoCompleteBox.SelectedItemTemplate>
        <DataTemplate>
            <TextBlock Text="{Binding MenuHeader}" />
        </DataTemplate>
    </u:MultiAutoCompleteBox.SelectedItemTemplate>
</u:MultiAutoCompleteBox>
```

## Common Scenarios / 常用场景

### 1. Size variants / 尺寸变体

```xml
<u:AutoCompleteBox Classes="Large"
                   ValueMemberBinding="{ReflectionBinding MenuHeader}" />
<u:AutoCompleteBox Classes="Small"
                   ValueMemberBinding="{ReflectionBinding MenuHeader}" />
<u:AutoCompleteBox Classes="Bordered"
                   ValueMemberBinding="{ReflectionBinding MenuHeader}" />
```

### 2. Inner content / 内部内容

```xml
<u:AutoCompleteBox InnerLeftContent="https://"
                   InnerRightContent=".com"
                   ValueMemberBinding="{ReflectionBinding MenuHeader}" />
```

### 3. Async population (MultiAutoCompleteBox) / 异步填充

```xml
<u:MultiAutoCompleteBox AsyncPopulator="{Binding SearchAsync}"
                         MinimumPrefixLength="2"
                         MinimumPopulateDelay="00:00:00.300"
                         ItemsSource="{Binding Items}"
                         SelectedItems="{Binding SelectedItems}" />
```

The `AsyncPopulator` delegate receives the search text and a `CancellationToken`.
The `MinimumPopulateDelay` prevents firing on every keystroke. Results replace
the `ItemsSource` dynamically.

`AsyncPopulator` 委托接收搜索文本和 `CancellationToken`。`MinimumPopulateDelay`
防止每次按键都触发。结果动态替换 `ItemsSource`。

### 4. Custom filter predicate / 自定义过滤谓词

```xml
<u:MultiAutoCompleteBox ItemsSource="{Binding Items}"
                         FilterMode="Custom"
                         ItemFilter="{Binding FilterPredicate}"
                         SelectedItems="{Binding SelectedItems}" />
```

When `FilterMode` is `Custom`, the `ItemFilter` predicate is called for each item.
Built-in modes: `StartsWith`, `Contains`, `Equals`, `StartsWithCaseSensitive`,
`ContainsCaseSensitive`, `EqualsCaseSensitive`, `StartsWithOrdinal`,
`ContainsOrdinal`, `EqualsOrdinal`.

当 `FilterMode` 为 `Custom` 时，对每个项目调用 `ItemFilter` 谓词。内置模式：
`StartsWith`、`Contains`、`Equals`、`StartsWithCaseSensitive`、
`ContainsCaseSensitive`、`EqualsCaseSensitive`、`StartsWithOrdinal`、
`ContainsOrdinal`、`EqualsOrdinal`。

### 5. Disabled state / 禁用状态

```xml
<u:AutoCompleteBox IsEnabled="False"
                   PlaceholderText="Disabled"
                   ValueMemberBinding="{ReflectionBinding MenuHeader}" />
```

## Property Reference / 属性参考

### AutoCompleteBox Properties / AutoCompleteBox 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Text` | `string?` | `null` | Current text in the input field (two-way) / 输入字段中的当前文本（双向绑定） |
| `SelectedItem` | `object?` | `null` | Currently selected item / 当前选中项 |
| `IsDropDownOpen` | `bool` | `false` | Whether the dropdown is open / 下拉框是否打开 |
| `MinimumPrefixLength` | `int` | `0` | Min chars before filtering / 过滤前最少字符数 |
| `PlaceholderText` | `string?` | `null` | Hint text when empty / 空白时的提示文本 |
| `PlaceholderForeground` | `IBrush?` | (theme) | Foreground for placeholder / 占位文本前景色 |
| `InnerLeftContent` | `object?` | `null` | Content on the left inside the input / 输入框内左侧内容 |
| `InnerRightContent` | `object?` | `null` | Content on the right inside the input / 输入框内右侧内容 |
| `ItemTemplate` | `IDataTemplate` | (shared) | Template for dropdown items / 下拉项目模板 |
| `ValueMemberBinding` | `BindingBase?` | `null` | Binding for display text / 显示文本的绑定 |
| `FilterMode` | `AutoCompleteFilterMode` | `StartsWith` | How to filter items / 过滤项目的方式 |
| `ItemFilter` | `AutoCompleteFilterPredicate?` | `null` | Custom item filter / 自定义项目过滤器 |
| `AsyncPopulator` | `Func<...>?` | `null` | Async delegate to populate items / 异步填充项目的委托 |
| `MinimumPopulateDelay` | `TimeSpan` | `Zero` | Delay before populate after typing / 输入后填充前的延迟 |
| `MaxDropDownHeight` | `double` | `Infinity` | Max height of dropdown / 下拉框最大高度 |
| `MaxLength` | `int` | (unlimited) | Max input length / 最大输入长度 |
| `IsTextCompletionEnabled` | `bool` | `false` | Auto-complete the first match in text / 在文本中自动补全第一个匹配项 |

### MultiAutoCompleteBox Additional Properties / MultiAutoCompleteBox 额外属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedItems` | `IList?` | (new list) | Collection of selected items / 已选项集合 |
| `SelectedItemTemplate` | `IDataTemplate?` | `null` | Template for chip display / 标签显示模板 |
| `CaretIndex` | `int` | `0` | Caret position in the text box / 文本框中的光标位置 |
| `SearchText` | `string?` | (read-only) | Filter text used for population / 用于填充的过滤文本 |
| `TextFilter` | `AutoCompleteFilterPredicate?` | `StartsWith` | Text-level filter / 文本级过滤器 |
| `TextSelector` | `AutoCompleteSelector?` | `null` | Custom text selector / 自定义文本选择器 |
| `ItemSelector` | `AutoCompleteSelector?` | `null` | Custom item selector / 自定义项目选择器 |

## Styling & Templating / 样式与模板

### Style Classes / 样式类

| Class | Description / 说明 |
|---|---|
| `Large` | Larger height variant / 大号高度变体 |
| `Small` | Smaller height variant / 小号高度变体 |
| `Bordered` | Bordered variant / 边框变体 |
| `clearButton` / `ClearButton` | Show clear (×) button on focus/hover / 聚焦/悬停时显示清除按钮 |

### Pseudo Classes / 伪类

| Pseudo Class | Applies To | Description |
|---|---|---|
| `:dropdownopen` | Both controls | Dropdown popup is open / 下拉弹出框已打开 |
| `:empty` | AutoCompleteBox | Text is empty / 文本为空 |

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `AutoCompleteBoxDefaultHeight` | Both controls | Default min height / 默认最小高度 |
| `AutoCompleteMaxDropdownHeight` | Both controls | Max dropdown height / 最大下拉高度 |
| `AutoCompleteBoxPopupMargin` | Dropdown popup border | Outer margin of popup border / 弹出边框外边距 |
| `AutoCompleteBoxPopupPadding` | Dropdown popup border | Inner padding of popup border / 弹出边框内边距 |
| `AutoCompleteBoxPopupBackground` | Dropdown popup border | Popup background / 弹出背景 |
| `AutoCompleteBoxPopupBorderBrush` | Dropdown popup border | Popup border color / 弹出边框颜色 |
| `AutoCompleteBoxPopupBorderThickness` | Dropdown popup border | Popup border thickness / 弹出边框粗细 |
| `AutoCompleteBoxPopupBoxShadow` | Dropdown popup border | Popup box shadow / 弹出框阴影 |
| `AutoCompleteBoxPopupCornerRadius` | Dropdown popup border | Popup corner radius / 弹出圆角 |
| `TextBoxDefaultBackground` | MultiAutoCompleteBox border | Input area background / 输入区背景 |
| `TextBoxDefaultBorderBrush` | MultiAutoCompleteBox border | Input area border / 输入区边框 |
| `TextBoxDefaultCornerRadius` | MultiAutoCompleteBox border | Input area corner radius / 输入区圆角 |
| `TextBoxPlaceholderForeground` | Both controls | Placeholder foreground / 占位符前景色 |

### Template Parts / 模板部件

| Part Name | Control | Type | Description |
|---|---|---|---|
| `PART_TextBox` | Both | `TextBox` | The text input field / 文本输入字段 |
| `PART_Popup` | Both | `Popup` | The dropdown popup / 下拉弹出框 |
| `PART_SelectingItemsControl` | Both | `ListBox` | The items list in the dropdown / 下拉框中的项目列表 |
| `PART_ClearButton` | AutoCompleteBox | `Button` | Clear button / 清除按钮 |
| `PART_SelectionAdapter` | MultiAutoCompleteBox | `ISelectionAdapter` | Selection adapter / 选择适配器 |
| `PART_SelectedItemsControl` | MultiAutoCompleteBox | `MultiComboBoxSelectedItemList` | Chip list for selected items / 已选项标签列表 |

## API Reference / API 参考

### AutoCompleteBox Class / AutoCompleteBox 类

- **Namespace**: `Ursa.Controls`
- **Base class**: `Avalonia.Controls.AutoCompleteBox`
- **Interfaces**: `IClearControl`
- **Methods**: `Clear()` — sets Text to null, defaults MinimumPrefixLength to 0

The Ursa `AutoCompleteBox` overrides the base class behavior:
- Clicking the text box when the dropdown is closed opens it.
- Keyboard focus opens the dropdown (unless focus came from a pointer selection).
- Losing focus closes the dropdown (unless focus moved inside the popup).

Ursa `AutoCompleteBox` 覆盖了基类行为：
- 下拉框关闭时点击文本框会打开它。
- 键盘聚焦会打开下拉框（除非聚焦来自指针选择）。
- 失去焦点会关闭下拉框（除非焦点移到弹出框内部）。

### MultiAutoCompleteBox Class / MultiAutoCompleteBox 类

- **Namespace**: `Ursa.Controls`
- **Base class**: `TemplatedControl`
- **Interfaces**: `IInnerContentControl`, `IPopupInnerContent`
- **Methods**: `Remove(object?)` — removes an item from SelectedItems
- **Events**: `SelectionChanged`, `TextChanged`

### MultiAutoCompleteSelectionAdapter Class / MultiAutoCompleteSelectionAdapter 类

- **Namespace**: `Ursa.Controls`
- **Implements**: `ISelectionAdapter`
- **Role**: Bridges keyboard/mouse selection to the items list.
