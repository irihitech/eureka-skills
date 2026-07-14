---
category: Components
title: AutoCompleteBox
subtitle: 自动完成框
description: >
  Ursa-enhanced single-value auto-complete text input with clear button,
  open-on-click behavior, and Semi theme styling.
  Ursa 增强的单值自动完成文本输入，带清除按钮、点击打开行为和 Semi 主题样式。
---

# AutoCompleteBox / 自动完成框

Ursa's enhanced single-value auto-complete input. Extends Avalonia's `AutoCompleteBox`
with a clear button, open-on-click/focus behavior, `MinimumPrefixLength = 0` default,
and Semi theme styling.

Ursa 增强的单值自动完成输入控件。扩展 Avalonia `AutoCompleteBox`，带清除按钮、
点击/聚焦时打开下拉框的行为、`MinimumPrefixLength = 0` 默认值和 Semi 主题样式。

## When to Use / 何时使用

Use `AutoCompleteBox` for single-selection text-based lookup — search boxes,
type-ahead selectors, or any input where the user types to filter and selects
one result. For multi-selection with chip display, use `MultiAutoCompleteBox`.

当需要基于文本的单选查找时使用 —— 搜索框、即输即搜选择器，或任何用户输入以
过滤并选择单个结果的场景。多选芯片显示使用 `MultiAutoCompleteBox`。

## Basic Usage / 基本使用

```xml
<u:AutoCompleteBox Watermark="Search..."
                   ItemsSource="{Binding Suggestions}"
                   FilterMode="StartsWith"
                   SelectedItem="{Binding SelectedItem}" />
```

```csharp
// Clear the current selection
myAutoCompleteBox.Clear();
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Text` | `string` | The current text in the input box. / 输入框中的当前文本。 |
| `SelectedItem` | `object?` | The currently selected item. / 当前选中的项。 |
| `ItemsSource` | `IEnumerable?` | The collection of suggestion items. / 建议项的集合。 |
| `FilterMode` | `AutoCompleteFilterMode` | Filter strategy: `StartsWith`, `Contains`, `Custom`. / 过滤策略。 |
| `MinimumPrefixLength` | `int` | Min chars before showing suggestions (default 0). / 显示建议前的最小字符数（默认 0）。 |
| `Watermark` | `string?` | Placeholder text. / 占位文本。 |

## Styling & Templating / 样式与模板

Style classes: `Large`, `Small`, `Bordered`, `Disabled`, `clearButton`. Theme resources: `AutoCompleteBoxBackground`, `AutoCompleteBoxBorderBrush`, `AutoCompleteBoxPopupBackground`.

## FAQ / 常见问题

**Q: AutoCompleteBox vs MultiAutoCompleteBox? / AutoCompleteBox 与 MultiAutoCompleteBox 的区别？**

A: `AutoCompleteBox` selects a single value. See [MultiAutoCompleteBox](multi-auto-complete-box.md) for multi-selection with chip display and async population.

`AutoCompleteBox` 选择单个值。多选芯片显示和异步填充参见 [MultiAutoCompleteBox](multi-auto-complete-box.md)。
