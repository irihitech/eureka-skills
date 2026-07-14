---
category: Components
title: AutoCompleteBox
subtitle: 自动补全框
description: 自动补全框在用户输入时显示匹配建议的下拉列表。
---

# AutoCompleteBox / 自动补全框

A text input control that shows a dropdown list of suggestions as the user types. Wraps a `TextBox` internally. Supports custom filtering logic. Inherits from `TemplatedControl`.

在用户输入时显示下拉建议列表的文本输入控件。内部封装 `TextBox`。支持自定义过滤逻辑。继承自 `TemplatedControl`。

## When to Use / 何时使用

Use `AutoCompleteBox` when the user needs to pick from a known set of values — search with suggestions, country selector, email autocomplete. For free-form text input, use `TextBox`. For a dropdown without free text entry, use `ComboBox`.

用户需要从已知值集合中选择时使用——带建议的搜索、国家选择器、邮件自动补全。自由文本输入用 `TextBox`。无需自由文本输入的下拉用 `ComboBox`。

## Basic Usage / 基本使用

```xml
<AutoCompleteBox ItemsSource="{Binding Countries}"
                 FilterMode="StartsWith"
                 Watermark="Search country..."
                 SelectedItem="{Binding SelectedCountry}" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `ItemsSource` | `IEnumerable?` | Suggestion data source. / 建议数据源。 |
| `Text` | `string?` | The input text. / 输入文本。 |
| `SelectedItem` | `object?` | Selected suggestion. / 选中的建议项。 |
| `FilterMode` | `AutoCompleteFilterMode` | `StartsWith`, `Contains`, `Equals`, `Custom`. |
| `MinimumPrefixLength` | `int` | Chars before suggestions appear (default 1). / 显示建议前的最小字符数。 |
| `Watermark` | `string?` | Placeholder text. / 占位符文本。 |
| `IsTextCompletionEnabled` | `bool` | Auto-complete the text field with the first match. / 自动用首个匹配项补全文本。 |

## Styling & Templating / 样式与模板

Semi.Avalonia themes the internal `TextBox` and dropdown `Popup`. Template part: `PART_TextBox`.

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `AutoCompleteBoxDefaultHeight` | Default control height / 默认控件高度 |
| `AutoCompleteBoxLargeHeight` | Large control height / 大号控件高度 |
| `AutoCompleteBoxSmallHeight` | Small control height / 小号控件高度 |
| `AutoCompleteBoxPopupBackground` | Dropdown popup background / 下拉弹窗背景 |
| `AutoCompleteBoxPopupBorderBrush` | Dropdown popup border color / 下拉弹窗边框颜色 |
| `AutoCompleteBoxPopupBorderThickness` | Dropdown popup border thickness / 下拉弹窗边框粗细 |
| `AutoCompleteBoxPopupBoxShadow` | Dropdown popup box shadow / 下拉弹窗阴影 |
| `AutoCompleteBoxPopupCornerRadius` | Dropdown popup corner radius / 下拉弹窗圆角半径 |
| `AutoCompleteBoxPopupMargin` | Dropdown popup margin / 下拉弹窗外边距 |
| `AutoCompleteBoxPopupPadding` | Dropdown popup padding / 下拉弹窗内边距 |
| `AutoCompleteMaxDropdownHeight` | Maximum dropdown height / 下拉列表最大高度 |

## FAQ / 常见问题

**Q: AutoCompleteBox vs ComboBox? / AutoCompleteBox 和 ComboBox 的区别？**

A: `AutoCompleteBox` allows free text entry with filtering — type to search. `ComboBox` selects from a fixed list — click to choose. / `AutoCompleteBox` 允许自由文本输入并过滤——输入即搜索。`ComboBox` 从固定列表选择——点击选择。