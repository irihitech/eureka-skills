---
category: Components
title: MultiAutoCompleteBox
subtitle: 多选自动完成
description: 带多选芯片显示和异步搜索的自动完成输入控件。
---

# MultiAutoCompleteBox / 多选自动完成

A multi-selection auto-complete input that displays selected items as chips with a search text box and async suggestion loading. Inherits from `TemplatedControl`. Supports custom filtering, async population, and selection events.

将已选项显示为芯片/标签的多选自动完成输入控件，带搜索文本框和异步建议加载。继承自 `TemplatedControl`。支持自定义过滤、异步填充和选择事件。

## When to Use / 何时使用

Use `MultiAutoCompleteBox` for multi-value text input with suggestion-based completion — email recipients, tag editors, skill pickers. For single-value auto-complete, use `AutoCompleteBox`.

在基于建议完成的多值文本输入中使用 —— 邮件收件人、标签编辑、技能选择器。单值自动完成使用 `AutoCompleteBox`。

## Basic Usage / 基本使用

```xml
<u:MultiAutoCompleteBox Width="300"
                        SelectedItems="{Binding Recipients}"
                        ItemsSource="{Binding Suggestions}"
                        Watermark="Add recipients..." />
```

```xml
<!-- With async population -->
<u:MultiAutoCompleteBox Width="300"
                        AsyncPopulator="{Binding SearchAsync}"
                        FilterMode="Contains" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `SelectedItems` | `IList?` | The currently selected items (chips). / 当前选中的项（标签）。 |
| `Text` | `string` | The current search/input text. / 当前搜索/输入文本。 |
| `FilterMode` | `AutoCompleteFilterMode` | Filter strategy: `StartsWith`, `Contains`, `Custom`. / 过滤策略。 |
| `AsyncPopulator` | `Func<string?, Task<IEnumerable>>?` | Async function for loading suggestions. / 异步加载建议的函数。 |
| `ItemFilter` | `AutoCompleteFilterPredicate<object?>?` | Custom filter predicate for `Custom` mode. / 自定义过滤谓词。 |
| `IsDropDownOpen` | `bool` | Whether the suggestions dropdown is open. / 建议下拉是否打开。 |
| `MinimumPrefixLength` | `int` | Min chars before showing suggestions. / 显示建议前的最小字符数。 |
| `Watermark` | `string?` | Placeholder text in the input area. / 输入区占位文本。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectionChanged` | Raised when selected items change. / 选中项改变时触发。 |
| `TextChanged` | Raised when search text changes. / 搜索文本改变时触发。 |

## Styling & Templating / 样式与模板

Pseudo-class `:dropdownopen`. Template parts: `PART_TextBox`, `PART_Popup`, `PART_SelectingItemsControl`, `PART_SelectionAdapter`. Theme resources: `MultiAutoCompleteBoxBackground`, `MultiAutoCompleteBoxBorderBrush`, `MultiAutoCompleteBoxChipBackground`.

## FAQ / 常见问题

**Q: MultiAutoCompleteBox vs AutoCompleteBox? / MultiAutoCompleteBox 与 AutoCompleteBox 的区别？**

A: `MultiAutoCompleteBox` supports multiple chip-style selections and async population. `AutoCompleteBox` (Ursa's, extends Avalonia's) is for single-value selection. `MultiAutoCompleteBox` inherits from `TemplatedControl` (not `AutoCompleteBox`) — it's a ground-up multi-value implementation.

`MultiAutoCompleteBox` 支持多个芯片式选择和异步填充。`AutoCompleteBox`（Ursa 版，继承自 Avalonia 版）用于单值选择。`MultiAutoCompleteBox` 继承自 `TemplatedControl`（非 `AutoCompleteBox`）—— 是从底层构建的多值实现。
