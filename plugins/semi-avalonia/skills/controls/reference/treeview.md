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

## Styling & Templating / 样式与模板

Semi.Avalonia themes `TreeView` with indentation, expand/collapse chevrons, hover/pressed states. Key resources: `TreeViewItemBackground`, `TreeViewItemForeground`. Pseudo-classes: `:expanded`, `:selected`, `:pointerover`.

### Special ControlThemes / 特殊控件主题

Semi.Avalonia defines the `ToggleButtonTreeViewItemIconButton` theme in `TreeView.axaml` for the expand/collapse chevron button inside each `TreeViewItem`.

Semi.Avalonia 在 `TreeView.axaml` 中定义了 `ToggleButtonTreeViewItemIconButton` 主题，用于每个 `TreeViewItem` 内部的展开/折叠箭头按钮。

#### `ToggleButtonTreeViewItemIconButton`

**TargetType:** `ToggleButton`
**Resource Key:** `ToggleButtonTreeViewItemIconButton`

The theme for `PART_ExpandCollapseChevron` — the `ToggleButton` inside every `TreeViewItem` template that toggles expansion. Renders a transparent `Border` containing a `PathIcon` (`PART_ExpandIconPath`) that displays the chevron/arrow glyph using `ExpanderIconData`. When `:checked` (expanded), the icon rotates 90 degrees clockwise. On `:pointerover`, the icon foreground changes to `TreeViewItemIconHoverForeground`. The transition uses a 0.1-second `TransformOperationsTransition` for smooth rotation.

`PART_ExpandCollapseChevron` 的主题 —— 每个 `TreeViewItem` 模板中用于切换展开的 `ToggleButton`。渲染一个透明 `Border`，内含显示箭头字形的 `PathIcon`（`PART_ExpandIconPath`），使用 `ExpanderIconData`。当 `:checked`（展开）时，图标顺时针旋转 90 度。`:pointerover` 时，图标前景变为 `TreeViewItemIconHoverForeground`。过渡使用 0.1 秒的 `TransformOperationsTransition` 实现平滑旋转。

```xml
<!-- Used internally by TreeViewItem; can be referenced for custom expand/collapse buttons -->
<ToggleButton Theme="{StaticResource ToggleButtonTreeViewItemIconButton}"
              IsChecked="{Binding IsExpanded}" />
```

**Key resources:** `ExpanderIconData`, `TreeViewItemIconDefaultForeground`, `TreeViewItemIconHoverForeground`, `TreeViewItemIconMargin`

**Pseudo-classes:** `:checked` (rotates icon 90°), `:pointerover` (changes icon foreground)

## FAQ / 常见问题

**Q: How to bind hierarchical data? / 如何绑定层级数据？**

A: Use `TreeDataTemplate` with `ItemsSource="{Binding Children}"`. The model must expose a children collection. / 使用 `TreeDataTemplate`，设置 `ItemsSource="{Binding Children}"`。模型需暴露子节点集合。