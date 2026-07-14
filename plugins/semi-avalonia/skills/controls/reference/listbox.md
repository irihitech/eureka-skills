---
category: Components
title: ListBox
subtitle: 列表框
description: 列表框用于显示可选择项的列表，支持单选、多选和 RadioButton 组模式。
---

# ListBox / 列表框

An `ItemsControl` in which individual items can be selected. Each item is a `ListBoxItem` container. Uses `VirtualizingStackPanel` as the default items panel for performance with large datasets. Inherits from `SelectingItemsControl`.

一个可选择单个项的 `ItemsControl`。每个项是 `ListBoxItem` 容器。默认使用 `VirtualizingStackPanel` 作为项布局面板，在处理大数据集时具备虚拟化性能。继承自 `SelectingItemsControl`。

## When to Use / 何时使用

Use `ListBox` for selection lists — file browsers, settings lists, item pickers. For simple display without selection, use `ItemsControl`. For auto-complete with text input, use `AutoCompleteBox`. For hierarchical data, use `TreeView`. Semi.Avalonia also provides `RadioGroupListBox` — a `ListBox` variant that renders items as radio buttons for single-selection group UIs.

用于选择列表 —— 文件浏览器、设置列表、项目选择器。无选择需求的简单展示用 `ItemsControl`。带文本输入的自动补全用 `AutoCompleteBox`。层级数据用 `TreeView`。Semi.Avalonia 还提供了 `RadioGroupListBox` —— 一个将项目渲染为单选按钮的变体，用于单选组界面。

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

```csharp
// Select all (Multiple mode)
listBox.SelectAll();

// Clear selection
listBox.UnselectAll();
```

## Common Scenarios / 常用场景

### Multi-select / 多选

Use `SelectionMode="Multiple"` with Ctrl+click and Shift+click range selection. Ctrl+A selects all.

```xml
<ListBox ItemsSource="{Binding Items}"
         SelectionMode="Multiple"
         SelectedItems="{Binding SelectedItems}" />
```

### Radio Group ListBox / 单选组模式

Semi.Avalonia provides `RadioGroupListBox` theme — renders items as radio buttons in a horizontal row. The selection visual matches `RadioButton` styling.

```xml
<ListBox Theme="{DynamicResource RadioGroupListBox}"
         ItemsSource="{Binding Options}"
         SelectedItem="{Binding SelectedOption}"
         SelectionMode="Single" />
```

### Custom Item Template / 自定义项模板

```xml
<ListBox ItemsSource="{Binding Contacts}">
    <ListBox.ItemTemplate>
        <DataTemplate>
            <StackPanel Orientation="Horizontal" Spacing="8">
                <Border CornerRadius="20" Width="40" Height="40"
                        Background="{DynamicResource SemiColorFill0}">
                    <TextBlock Text="{Binding Initials}"
                               HorizontalAlignment="Center"
                               VerticalAlignment="Center" />
                </Border>
                <StackPanel>
                    <TextBlock Text="{Binding Name}" FontWeight="Bold" />
                    <TextBlock Text="{Binding Email}"
                               Foreground="{DynamicResource SemiColorTextSecondary}" />
                </StackPanel>
            </StackPanel>
        </DataTemplate>
    </ListBox.ItemTemplate>
</ListBox>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `ItemsSource` | `IEnumerable?` | Data source. Inherited from `ItemsControl`. / 数据源。继承自 `ItemsControl`。 |
| `SelectedItem` | `object?` | The currently selected item. Inherited from `SelectingItemsControl`. / 当前选中的项。 |
| `SelectedItems` | `IList?` | Selected items collection (for `Multiple` / `Toggle` modes). / 选中项集合。 |
| `Selection` | `ISelectionModel` | The underlying selection model — supports `SelectAll()`, `Clear()`, range selection. / 底层选择模型。 |
| `SelectionMode` | `SelectionMode` | `Single`, `Multiple`, `Toggle`, `AlwaysSelected`. Note: only affects user interaction; multiple programmatic selections always work. / 选择模式。仅影响用户交互，编程多选始终可用。 |
| `Scroll` | `IScrollable?` | (Read-only) The internal `ScrollViewer` for programmatic scroll control. / 内部 `ScrollViewer`，用于编程控制滚动。 |
| `ItemsPanel` | `ITemplate<Panel>?` | The panel hosting items. Default: `VirtualizingStackPanel`. / 承载项的布局面板。 |

### Methods / 方法

| Method / 方法 | Description / 说明 |
| --- | --- |
| `SelectAll()` | Selects all items. / 全选所有项。 |
| `UnselectAll()` | Clears the selection. / 清除选择。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `SelectionChanged` | Raised when `SelectedItem` or `SelectedItems` changes. / 选择改变时触发。 |

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlTheme / Semi.Avalonia 控件主题

Semi.Avalonia defines three `ListBox`-related themes:

Semi.Avalonia 定义了三个与 `ListBox` 相关的主题：

| Theme / 主题 | Resource Key / 资源键 | Description / 说明 |
| --- | --- | --- |
| Default ListBox | `{x:Type ListBox}` | Standard list with `Border`-wrapped `ScrollViewer` and `ItemsPresenter`. / 标准列表，带 `Border` 包裹的 `ScrollViewer` 和 `ItemsPresenter`。 |
| Default ListBoxItem | `{x:Type ListBoxItem}` | Item container with `ContentPresenter` and styled selection states. / 带 `ContentPresenter` 和样式化选择状态的项容器。 |
| Radio Group | `RadioGroupListBox` | Horizontal radio-button-style list. Uses `RadioGroupListBoxItem` for item containers. / 水平单选按钮样式的列表。 |
| Radio Group Item | `RadioGroupListBoxItem` | Item with radio button `Ellipse` glyph, matching `RadioButton` styling. / 带单选按钮 `Ellipse` 标记的项，匹配 `RadioButton` 样式。 |

### Pseudo-classes on ListBoxItem / ListBoxItem 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:disabled` | Item is disabled (`IsEnabled = false`). / 项已禁用。 |
| `:pointerover` | Mouse is hovering over the item. / 鼠标悬停。 |
| `:pressed` | Item is being pressed. / 项被按下。 |
| `:selected` | Item is selected. Combines with `:pointerover` and `:disabled`. / 项已选中。可与 `:pointerover` 和 `:disabled` 组合。 |

### Key DynamicResource Keys / 关键动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `ListBoxItemDefaultBackground` | Unselected item background / 未选中项背景 |
| `ListBoxItemDefaultPadding` | Item padding / 项内边距 |
| `ListBoxItemCornerRadius` | Item corner rounding / 项圆角 |
| `ListBoxItemPointeroverBackground` | Background on hover / 悬停背景 |
| `ListBoxItemPointeroverForeground` | Foreground on hover / 悬停前景色 |
| `ListBoxItemPressedBackground` | Background when pressed / 按下背景 |
| `ListBoxItemSelectedBackground` | Selected item background / 选中项背景 |
| `ListBoxItemSelectedForeground` | Selected item foreground / 选中项前景色 |
| `ListBoxItemSelectedPointeroverBackground` | Selected + hover background / 选中且悬停背景 |
| `ListBoxItemDisabledForeground` | Disabled item text color / 禁用项文本色 |
| `ListBoxItemDisabledBackground` | Disabled item background / 禁用项背景 |
| `ListBoxItemSelectedDisabledBackground` | Selected + disabled background / 选中且禁用背景 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Located in / 所在主题 | Description / 说明 |
| --- | --- | --- | --- |
| `PART_ScrollViewer` | `ScrollViewer` | `ListBox` | Scrollable viewport wrapping the items. / 包裹项的可滚动视口。 |
| `PART_ItemsPresenter` | `ItemsPresenter` | `ListBox` | Renders the items using the configured `ItemsPanel`. / 使用配置的 `ItemsPanel` 渲染项。 |
| `PART_ContentPresenter` | `ContentPresenter` | `ListBoxItem` | Renders the item's `Content`. / 渲染项的 `Content`。 |
| `PART_GlyphPanel` | `Panel` | `RadioGroupListBoxItem` | Contains the radio button glyph elements. / 包含单选按钮标记元素。 |

## FAQ / 常见问题

**Q: ListBox vs ItemsControl? / ListBox 和 ItemsControl 的区别？**

A: `ListBox` adds item selection, keyboard navigation (arrow keys, Shift/Ctrl+click, Ctrl+A), `VirtualizingStackPanel` by default, and a built-in `ScrollViewer`. Use `ItemsControl` when you don't need selection or keyboard navigation. `ListBox` creates `ListBoxItem` containers automatically.

`ListBox` 增加了项选择、键盘导航（方向键、Shift/Ctrl+点击、Ctrl+A）、默认 `VirtualizingStackPanel` 和内置 `ScrollViewer`。不需要选择或键盘导航时用 `ItemsControl`。`ListBox` 自动创建 `ListBoxItem` 容器。

**Q: How does SelectionMode work? / SelectionMode 如何工作？**

A: `SelectionMode` controls user interaction only — programmatic multi-selection always works. `Single`: one item at a time. `Multiple`: Ctrl+click adds, Shift+click ranges. `Toggle`: click toggles individual items. `AlwaysSelected`: exactly one item is always selected, clicking deselects only when another is selected. The underlying `ISelectionModel` (`Selection` property) provides full programmatic control.

`SelectionMode` 仅控制用户交互——编程多选始终有效。`Single`：一次一个。`Multiple`：Ctrl+点击添加，Shift+点击范围选择。`Toggle`：点击切换单个项。`AlwaysSelected`：始终有一个选中项。底层 `ISelectionModel`（`Selection` 属性）提供完整编程控制。

**Q: How to use RadioGroupListBox for a settings page? / 如何用 RadioGroupListBox 做设置页面？**

A: Apply `Theme="{DynamicResource RadioGroupListBox}"` to a `ListBox` with `SelectionMode="Single"`. It renders items horizontally as radio buttons. Each item's `Content` becomes the radio button label. The selected state uses `RadioButton` resources (`RadioButtonForeground`, `RadioButtonCheckGlyphFill`). For vertical radio groups, override `ItemsPanel` back to `StackPanel`.

给 `ListBox` 设置 `Theme="{DynamicResource RadioGroupListBox}"` 和 `SelectionMode="Single"`。它会水平渲染单选按钮。每项的 `Content` 成为标签。选中状态使用 `RadioButton` 资源。如需垂直布局，覆盖 `ItemsPanel` 回 `StackPanel`。
