---
category: Components
title: ListBox
subtitle: 列表框
description: 列表框用于显示可选择项的列表，支持单选和多选模式。
---

# ListBox / 列表框

An items control that displays a selectable list with built-in scrolling and virtualization. Inherits from `SelectingItemsControl`.

显示可选择项列表的控件，内置滚动和虚拟化。继承自 `SelectingItemsControl`。

## When to Use / 何时使用

Use `ListBox` for selection lists — file browsers, settings lists, item pickers. For simple display without selection, use `ItemsControl`. For auto-complete, use `AutoCompleteBox`. For hierarchical data, use `TreeView`.

用于选择列表。无选择需求的简单展示用 `ItemsControl`。自动补全用 `AutoCompleteBox`。层级数据用 `TreeView`。

## Basic Usage / 基本使用

```xml
<ListBox ItemsSource="{Binding Files}"
         SelectedItem="{Binding SelectedFile}"
         SelectionMode="Single">
    <ListBox.ItemTemplate>
        <DataTemplate>
            <TextBlock Text="{Binding Name}" />
        </DataTemplate>
    </ListBox.ItemTemplate>
</ListBox>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `ItemsSource` | `IEnumerable?` | Data source. / 数据源。 |
| `SelectedItem` | `object?` | Currently selected item. / 当前选中项。 |
| `SelectedItems` | `IList?` | Selected items (multi-select). / 选中项列表。 |
| `SelectionMode` | `SelectionMode` | `Single`, `Multiple`, `Toggle`, `AlwaysSelected`. |
| `VirtualizationMode` | `ItemVirtualizationMode` | `None`, `Simple`. / 虚拟化模式。 |

## Styling & Templating / 样式与模板

Semi themes `ListBox` with `ListBoxItemBackground`, `ListBoxItemSelectedBackground`. Pseudo-classes on `ListBoxItem`: `:selected`, `:pointerover`, `:pressed`.

## FAQ / 常见问题

**Q: ListBox vs ItemsControl? / ListBox 和 ItemsControl 的区别？**

A: `ListBox` adds selection, keyboard navigation, and built-in `ScrollViewer`. Use `ItemsControl` when you don't need item selection. / `ListBox` 增加了选择、键盘导航和内置滚动。不需要选择时用 `ItemsControl`。