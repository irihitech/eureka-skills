---
category: Components
title: TreeView
subtitle: 树视图
description: 树视图用于显示具有父子关系的层级数据。
---

# TreeView / 树视图

A control for displaying hierarchical data with expandable parent-child nodes. Inherits from `ItemsControl`. Each node is a `TreeViewItem`.

显示带有可展开父子节点的层级数据的控件。继承自 `ItemsControl`。每个节点是 `TreeViewItem`。

## When to Use / 何时使用

Use `TreeView` for file browsers, organizational charts, nested categories, or any hierarchical data. For flat lists, use `ListBox`. For single-level grouping, use `ItemsControl` with `GroupStyle`.

用于文件浏览器、组织结构图、嵌套分类等层级数据。平面列表用 `ListBox`。

## Basic Usage / 基本使用

```xml
<TreeView ItemsSource="{Binding RootNodes}">
    <TreeView.ItemTemplate>
        <TreeDataTemplate ItemsSource="{Binding Children}">
            <TextBlock Text="{Binding Name}" />
        </TreeDataTemplate>
    </TreeView.ItemTemplate>
</TreeView>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `ItemsSource` | `IEnumerable?` | Root nodes collection. / 根节点集合。 |
| `SelectedItem` | `object?` | The selected tree node. / 选中的树节点。 |
| `SelectionMode` | `SelectionMode` | `Single`, `Multiple`, `Toggle`. |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectionChanged` | Raised when selection changes. / 选择改变。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How to bind hierarchical data? / 如何绑定层级数据？**

A: Use `TreeDataTemplate` with `ItemsSource="{Binding Children}"`. The model must expose a children collection. / 使用 `TreeDataTemplate`，设置 `ItemsSource="{Binding Children}"`。模型需暴露子节点集合。