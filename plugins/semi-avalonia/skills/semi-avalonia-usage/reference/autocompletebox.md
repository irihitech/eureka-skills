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
                 PlaceholderText="Search country..."
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
| `PlaceholderText` | `string?` | Placeholder text. / 占位符文本。 |
| `IsTextCompletionEnabled` | `bool` | Auto-complete the text field with the first match. / 自动用首个匹配项补全文本。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: AutoCompleteBox vs ComboBox? / AutoCompleteBox 和 ComboBox 的区别？**

A: `AutoCompleteBox` allows free text entry with filtering — type to search. `ComboBox` selects from a fixed list — click to choose. / `AutoCompleteBox` 允许自由文本输入并过滤——输入即搜索。`ComboBox` 从固定列表选择——点击选择。