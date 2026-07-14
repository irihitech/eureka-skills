---
category: Components
title: MultiComboBox
subtitle: 多选组合框
description: 用于多选项目并以芯片/标签形式显示已选项的下拉控件。
---

# MultiComboBox / 多选组合框

A dropdown selector for multi-selection with selected items displayed as removable chips (tags) in the selector area. Inherits from `SelectingItemsControl`. Supports MVVM binding, inner content slots, and keyboard navigation.

支持多选并将已选项显示为可移除标签的多选下拉选择器。继承自 `SelectingItemsControl`。支持 MVVM 绑定、内部内容槽和键盘导航。

## When to Use / 何时使用

Use `MultiComboBox` for compact multi-selection — tag/category filters, user pickers, label selectors. Selected items appear as chips with remove buttons. For single selection from a tree, use `TreeComboBox`. For a simple flat single-select, use a standard `ComboBox`.

使用 `MultiComboBox` 进行紧凑多选 —— 标签/类别筛选、用户选择器、标签选择器。已选项以可移除标签形式显示。树形单选使用 `TreeComboBox`，简单平面单选使用标准 `ComboBox`。

## Basic Usage / 基本使用

```xml
<u:MultiComboBox Width="300"
                 PlaceholderText="Please Select"
                 SelectedItems="{Binding SelectedItems}"
                 ItemsSource="{Binding Items}" />
```

```xml
<!-- Declarative items -->
<u:MultiComboBox Width="300" PlaceholderText="Please Select">
    <u:MultiComboBoxItem>Option 1</u:MultiComboBoxItem>
    <u:MultiComboBoxItem>Option 2</u:MultiComboBoxItem>
    <u:MultiComboBoxItem>Option 3</u:MultiComboBoxItem>
</u:MultiComboBox>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `SelectedItems` | `IList?` | The currently selected items (bind to `ObservableCollection`). / 当前选中的项（绑定到 `ObservableCollection`）。 |
| `IsDropDownOpen` | `bool` | Whether the dropdown is open. / 下拉框是否打开。 |
| `MaxDropDownHeight` | `double` | Maximum height of the dropdown. / 下拉框最大高度。 |
| `MaxSelectionBoxHeight` | `double` | Maximum height of the chip display area before scrolling. / 标签显示区最大高度（超出后滚动）。 |
| `SelectedItemTemplate` | `IDataTemplate?` | Template for rendering selected chips. / 渲染已选标签的模板。 |
| `InnerLeftContent` | `object?` | Content in the left slot of the selector. / 选择器左侧槽位内容。 |
| `InnerRightContent` | `object?` | Content in the right slot. / 右侧槽位内容。 |

## Styling & Templating / 样式与模板

Style classes: `Large`, `Small`, `clearButton`. Pseudo-classes: `:dropdownopen`, `:selection-empty`. Template part: `PART_BackgroundBorder`. Theme resources: `MultiComboBoxBackground`, `MultiComboBoxBorderBrush`, `MultiComboBoxChipBackground`, `MultiComboBoxPopupBackground`.

## FAQ / 常见问题

**Q: How does MultiComboBox differ from standard multi-select patterns? / MultiComboBox 与标准多选模式有何不同？**

A: `MultiComboBox` renders selected items as chips **inside** the selector area (not just in the dropdown). It inherits from `SelectingItemsControl` with a custom `SelectedItems` API optimized for MVVM. Internally uses `MultiComboBoxItem` containers and `ClosableTag` for chip rendering.

`MultiComboBox` 将已选项渲染为选择区域**内部**的标签（而非仅在下拉列表中）。继承自 `SelectingItemsControl`，使用针对 MVVM 优化的自定义 `SelectedItems` API。内部使用 `MultiComboBoxItem` 容器和 `ClosableTag` 渲染标签。
