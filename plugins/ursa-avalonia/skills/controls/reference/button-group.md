---
category: Buttons
title: ButtonGroup
subtitle: 按钮组
description: >
  An ItemsControl that renders a horizontal group of Buttons with shared styling,
  data-driven binding, and automatic item-theming for seamless button clusters.
  将一组按钮渲染为水平排列的按钮组的 ItemsControl，支持数据驱动绑定和自动子按钮主题，
  实现无缝的按钮集群效果。
---

# ButtonGroup / 按钮组

## When to Use / 何时使用

Use `ButtonGroup` to display a row of related action buttons that share common
styling and optionally a unified command binding. Each item is automatically
wrapped in a `Button` container with the group's theme applied. This is ideal
for toolbars, filter bars, tab-like button bars, and any clustered action set.

当需要展示一行相关操作按钮且它们共享统一样式和（可选的）统一命令绑定时，使用
`ButtonGroup`。每个子项会自动包裹在应用了组主题的 `Button` 容器中。适用于
工具栏、筛选栏、类选项卡按钮条及任何集群操作场景。

Avoid `ButtonGroup` for radio-like single selection — use `RadioButton` or a
`ListBox` with single-selection mode instead.

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<!-- Static buttons -->
<u:ButtonGroup Classes="Primary">
    <Button Content="One" />
    <Button Content="Two" />
    <Button Content="Three" />
</u:ButtonGroup>
```

Each child `Button` receives the `ButtonGroupItemTheme` automatically, which adds
a separator between items and applies shared spacing.

## Common Scenarios / 常用场景

### 1. Data-driven with ContentBinding / 数据驱动绑定内容

```xml
<u:ButtonGroup Classes="Primary"
               ContentBinding="{Binding Name}"
               CommandBinding="{Binding InvokeCommand}"
               ItemsSource="{Binding Items}" />
```

```csharp
// ViewModel
public ObservableCollection<ButtonItem> Items { get; } = new()
{
    new("Save"),
    new("Delete"),
    new("Archive"),
};

public ICommand InvokeCommand { get; }

public record ButtonItem(string Name);
```

### 2. Data-driven with ItemTemplate / 带模板的数据驱动

```xml
<u:ButtonGroup Classes="Primary Solid"
               CommandBinding="{Binding InvokeCommand}"
               ItemsSource="{Binding Items}">
    <u:ButtonGroup.ItemTemplate>
        <DataTemplate>
            <TextBlock>
                <Run Text="🐼" />
                <Run Text="{Binding Name}" />
            </TextBlock>
        </DataTemplate>
    </u:ButtonGroup.ItemTemplate>
</u:ButtonGroup>
```

### 3. Semantic color classes / 语义颜色

```xml
<u:ButtonGroup Classes="Success" ContentBinding="{Binding Name}"
               CommandBinding="{Binding InvokeCommand}"
               ItemsSource="{Binding Items}" />

<u:ButtonGroup Classes="Warning" ContentBinding="{Binding Name}"
               CommandBinding="{Binding InvokeCommand}"
               ItemsSource="{Binding Items}" />

<u:ButtonGroup Classes="Danger" ContentBinding="{Binding Name}"
               CommandBinding="{Binding InvokeCommand}"
               ItemsSource="{Binding Items}" />
```

### 4. Size variants / 尺寸变体

```xml
<u:ButtonGroup Classes="Primary Small"
               ContentBinding="{Binding Name}"
               CommandBinding="{Binding InvokeCommand}"
               ItemsSource="{Binding Items}" />

<u:ButtonGroup Classes="Primary Large"
               ContentBinding="{Binding Name}"
               CommandBinding="{Binding InvokeCommand}"
               ItemsSource="{Binding Items}" />
```

### 5. Static buttons with individual commands / 各自独立命令的静态按钮

```xml
<u:ButtonGroup Classes="Primary">
    <Button Content="Cut" Command="{Binding CutCommand}" />
    <Button Content="Copy" Command="{Binding CopyCommand}" />
    <Button Content="Paste" Command="{Binding PasteCommand}" />
</u:ButtonGroup>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `CommandBinding` | `BindingBase?` | `null` | Shared command binding applied to every child button / 应用到每个子按钮的共享命令绑定 |
| `CommandParameterBinding` | `BindingBase?` | `null` | Shared command-parameter binding applied to every child button / 应用到每个子按钮的命令参数绑定 |
| `ContentBinding` | `BindingBase?` | `null` | Binding for each child button's `Content` from the data item / 每个子按钮 Content 的数据绑定 |
| `ItemsSource` | `IEnumerable?` | `null` | Inherited from `ItemsControl`. Data source for button items / 继承自 ItemsControl，按钮项的数据源 |
| `ItemTemplate` | `IDataTemplate?` | `null` | Inherited from `ItemsControl`. Template for individual button content / 继承自 ItemsControl，单个按钮内容的模板 |
| `ItemContainerTheme` | `ControlTheme?` | `ButtonGroupItemTheme` | Theme applied to each generated `Button` container / 应用到每个生成 Button 容器的主题 |

Inherits all properties from `ItemsControl` (`Items`, `ItemsPanel`, etc.).

继承 `ItemsControl` 的全部属性。

Note: `CommandBinding` and `CommandParameterBinding` support
`[InheritDataTypeFromItems(nameof(ItemsSource))]`, so compiled bindings will
resolve relative to the item data type.

## Events / 事件

No custom events. The child `Button` instances fire inherited `Click` events.
There is no `SelectedItem` or selection tracking — `ButtonGroup` is not a
selector.

没有自定义事件。子 Button 实例触发继承的 Click 事件。ButtonGroup 不是选择器，
没有 SelectedItem 或选中状态跟踪。

## Styling & Templating / 样式与模板

### Theme Key / 主题 Key

| Theme Key | Description / 说明 |
|---|---|
| `{x:Type u:ButtonGroup}` | Default theme for the group container / 组容器的默认主题 |

### Style Classes / 样式类

| Class | Description / 说明 |
|---|---|
| `Primary` | Primary semantic color for child buttons / 子按钮主要语义色 |
| `Secondary` | Secondary semantic color / 次要语义色 |
| `Tertiary` | Tertiary semantic color / 三级语义色 |
| `Success` | Success (green) color / 成功颜色 |
| `Warning` | Warning (orange) color / 警告颜色 |
| `Danger` | Danger (red) color / 危险颜色 |
| `Solid` | Solid fill style for child buttons / 子按钮 Solid 填充样式 |
| `Large` | Large size / 大尺寸 |
| `Small` | Small size / 小尺寸 |

Style classes propagate to child buttons via the `ButtonGroupItemTheme`.

### Template Parts / 模板部件

| Part Name | Type | Description / 说明 |
|---|---|---|
| `PART_ItemsPresenter` | `ItemsPresenter` | Hosts the child button items / 承载子按钮项 |

### Child Button Theme (ButtonGroupItemTheme) / 子按钮主题

Each generated `Button` gets `ButtonGroupItemTheme`, which:
- Sets transparent background, center alignment
- Adds a vertical separator rectangle (`PART_Separator`) between items
- Applies `ButtonGroupDefaultPadding`, `ButtonGroupDefaultMinHeight`,
  `ButtonGroupDefaultFontWeight` from theme resources

### Theme Resources / 主题资源

| Resource Key | Description / 说明 |
|---|---|
| `ButtonGroupDefaultBackground` | Container background / 容器背景 |
| `ButtonGroupCornerRadius` | Container corner radius / 容器圆角 |
| `ButtonGroupDefaultPadding` | Child button padding / 子按钮内边距 |
| `ButtonGroupDefaultMinHeight` | Child button minimum height / 子按钮最小高度 |
| `ButtonGroupDefaultFontWeight` | Child button font weight / 子按钮字重 |
| `ButtonGroupSeparatorHeight` | Separator line height / 分隔线高度 |
| `ButtonGroupSeparatorForeground` | Separator line color / 分隔线颜色 |

### Default ItemsPanel / 默认项目面板

```xml
<ItemsPanelTemplate>
    <StackPanel Orientation="Horizontal" />
</ItemsPanelTemplate>
```

## FAQ / 常见问题

**Q: How is ButtonGroup different from a StackPanel with Buttons? / ButtonGroup 和 StackPanel 放 Buttons 有什么区别？**
A: `ButtonGroup` automatically applies a shared theme to child buttons, adds
separators, and supports data-binding via `ContentBinding` and `CommandBinding`.
A plain `StackPanel` requires manual styling of each button.

**Q: Can I mix static and data-bound items?**
A: No. `ButtonGroup` is an `ItemsControl` — use either `Items`/`ItemsSource` or
add children directly, not both. For mixed content, create a composite
`ItemsSource` in your ViewModel.

**Q: Can I make ButtonGroup vertical instead of horizontal?**
A: Override the `ItemsPanel`:

```xml
<u:ButtonGroup Classes="Primary" ContentBinding="{Binding Name}"
               ItemsSource="{Binding Items}">
    <u:ButtonGroup.ItemsPanel>
        <ItemsPanelTemplate>
            <StackPanel Orientation="Vertical" />
        </ItemsPanelTemplate>
    </u:ButtonGroup.ItemsPanel>
</u:ButtonGroup>
```

**Q: Does ButtonGroup support selection / single-select?**
A: No. `ButtonGroup` renders action buttons, not a radio group. For single-select
button groups, use `RadioButton` items in a layout panel or consider a custom
selector.
