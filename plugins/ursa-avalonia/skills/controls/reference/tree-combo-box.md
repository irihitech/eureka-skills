---
category: Components
title: TreeComboBox
subtitle: 树形组合框
description: 用于从层次树结构中单选一个项目的下拉选择控件。
---

# TreeComboBox / 树形组合框

A dropdown selector for picking a single item from a hierarchical tree. Inherits from `ItemsControl`. Supports placeholder text, inner content slots, clear button, and keyboard navigation.

从层次树中单选一个项目的下拉选择器。继承自 `ItemsControl`。支持占位文本、内部内容槽、清除按钮和键盘导航。

## When to Use / 何时使用

Use `TreeComboBox` when users must select one item from a nested hierarchy — category pickers, organizational unit selectors, file-browser-style dropdowns. For flat single selection, use a standard `ComboBox`. For multi-selection with chip display, use `MultiComboBox`.

当用户需从嵌套层次中选择一个项目时使用 —— 类别选择器、组织单位选择器、文件浏览器风格下拉。平面单选使用标准 `ComboBox`，多选标签显示使用 `MultiComboBox`。

## Basic Usage / 基本使用

```xml
<u:TreeComboBox Width="300" PlaceholderText="Please select">
    <u:TreeComboBoxItem Header="Asia">
        <u:TreeComboBoxItem Header="China" />
        <u:TreeComboBoxItem Header="Japan" />
    </u:TreeComboBoxItem>
    <u:TreeComboBoxItem Header="Europe">
        <u:TreeComboBoxItem Header="Germany" />
        <u:TreeComboBoxItem Header="France" />
    </u:TreeComboBoxItem>
</u:TreeComboBox>
```

```xml
<!-- MVVM binding -->
<u:TreeComboBox ItemsSource="{Binding Items}"
                SelectedItem="{Binding SelectedItem}">
    <u:TreeComboBox.ItemTemplate>
        <TreeDataTemplate ItemsSource="{Binding Children}">
            <TextBlock Text="{Binding Name}" />
        </TreeDataTemplate>
    </u:TreeComboBox.ItemTemplate>
</u:TreeComboBox>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `SelectedItem` | `object?` | The currently selected item. / 当前选中的项。 |
| `IsDropDownOpen` | `bool` | Whether the dropdown is open. / 下拉框是否打开。 |
| `MaxDropDownHeight` | `double` | Maximum height of the dropdown popup. / 下拉弹出框最大高度。 |
| `PlaceholderText` | `string?` | Text shown when no item is selected. / 未选中项时显示的文本。 |
| `PlaceholderForeground` | `IBrush?` | Brush for placeholder text. / 占位文本画刷。 |
| `InnerLeftContent` | `object?` | Content placed in the left slot of the selector area. / 选择器区域左侧槽位内容。 |
| `InnerRightContent` | `object?` | Content placed in the right slot. / 右侧槽位内容。 |
| `PopupInnerTopContent` | `object?` | Content at the top of the dropdown. / 下拉框顶部内容。 |
| `PopupInnerBottomContent` | `object?` | Content at the bottom of the dropdown. / 下拉框底部内容。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectionChanged` | Raised when the selected item changes. / 选中项改变时触发。 |

## Styling & Templating / 样式与模板

Style classes: `Large`, `Small`, `clearButton`. Pseudo-class `:dropdownopen`. Template part: `PART_Popup`. Theme resources: `TreeComboBoxBackground`, `TreeComboBoxBorderBrush`, `TreeComboBoxPopupBackground`.

## FAQ / 常见问题

**Q: TreeComboBox vs ComboBox? / TreeComboBox 与 ComboBox 的区别？**

A: `TreeComboBox` supports hierarchical `TreeDataTemplate` with nested `TreeComboBoxItem` containers. Standard `ComboBox` only supports flat lists.

`TreeComboBox` 支持层次化 `TreeDataTemplate` 和嵌套 `TreeComboBoxItem` 容器。标准 `ComboBox` 仅支持平面列表。
