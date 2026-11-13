---
category: Components
title: ItemsControl
subtitle: 项目控件
description: 项目控件用于显示数据集合，是最基础的列表类控件基类。
---

# ItemsControl / 项目控件

The base class for controls that display a collection of items. Supports data binding, `ItemTemplate`, and `ItemsPanel`. Does not include selection or scrolling by default.

显示数据集合的控件基类。支持数据绑定、`ItemTemplate` 和 `ItemsPanel`。默认不包含选择或滚动功能。

## When to Use / 何时使用

Use `ItemsControl` for simple repeating layouts without selection — tag clouds, icon grids, status indicators. For selectable lists, use `ListBox`. For hierarchical data, use `TreeView`.

用于无选择需求的简单重复布局——标签云、图标网格、状态指示器。可选择的列表用 `ListBox`。层级数据用 `TreeView`。

## Basic Usage / 基本使用

```xml
<ItemsControl ItemsSource="{Binding Tags}">
    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <Border CornerRadius="4" Padding="8,4">
                <TextBlock Text="{Binding}" />
            </Border>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
</ItemsControl>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `ItemsSource` | `IEnumerable?` | The collection to display. / 要显示的集合。 |
| `ItemTemplate` | `IDataTemplate?` | Template for each item. / 每个项的模板。 |
| `ItemsPanel` | `ITemplate<Panel>?` | The panel that hosts items (default: `StackPanel`). / 承载项的布局面板。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How to display items horizontally? / 如何水平显示项目？**

A: Set `ItemsPanel` to a `WrapPanel` or horizontal `StackPanel`. / 设置 `ItemsPanel` 为 `WrapPanel` 或水平 `StackPanel`。