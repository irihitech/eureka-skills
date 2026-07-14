---
category: Components
title: SelectionList
subtitle: 选择列表
description: 选择列表提供单选导航控件，带有平滑的选中指示器动画。
---

# SelectionList / 选择列表

A single-selection list control with an animated selection indicator that smoothly moves between items. Inherits from `SelectingItemsControl`. Selection mode is forcibly coerced to `Single`.

带平滑动画指示器的单选列表控件。继承自 `SelectingItemsControl`，选择模式强制为 `Single`。

## When to Use / 何时使用

Use `SelectionList` for navigation menus, tab-like selectors, or any UI where exactly one item is selected and a moving indicator is desired. For multi-select, use `ListBox` with `SelectionMode="Multiple"`.

用于导航菜单、标签式选择器或任何需要单选并带有移动指示器的界面。多选场景使用 `ListBox` 并设置 `SelectionMode="Multiple"`。

## Basic Usage / 基本使用

```xml
<u:SelectionList ItemsSource="{Binding Items}" SelectedItem="{Binding SelectedItem}" />
```

```csharp
// In ViewModel
public ObservableCollection<string> Items { get; } = new() { "Option A", "Option B", "Option C" };
public string? SelectedItem { get; set; }
```

## Common Scenarios / 常用场景

### Horizontal Navigation / 横向导航

```xml
<u:SelectionList ItemsSource="{Binding Items}" SelectedItem="{Binding SelectedItem}">
    <u:SelectionList.ItemsPanel>
        <ItemsPanelTemplate>
            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" />
        </ItemsPanelTemplate>
    </u:SelectionList.ItemsPanel>
</u:SelectionList>
```

### Custom Indicator / 自定义指示器

```xml
<u:SelectionList ItemsSource="{Binding Items}" SelectedItem="{Binding SelectedItem}">
    <u:SelectionList.Indicator>
        <Border Background="Transparent" CornerRadius="4">
            <Border
                Width="4" Margin="0,8"
                HorizontalAlignment="Left" VerticalAlignment="Stretch"
                Background="{DynamicResource SemiBlue6}" CornerRadius="4" />
        </Border>
    </u:SelectionList.Indicator>
</u:SelectionList>
```

### Inside Flyout / 在弹出菜单中使用

```xml
<SplitButton Content="Button With Selection">
    <SplitButton.Flyout>
        <Flyout>
            <u:SelectionList ItemsSource="{Binding Items}" SelectedItem="{Binding SelectedItem}" />
        </Flyout>
    </SplitButton.Flyout>
</SplitButton>
```

### Custom Item Template with Conditional Styling / 自定义项模板与条件样式

```xml
<u:SelectionList ItemsSource="{Binding Items}" SelectedItem="{Binding SelectedItem}">
    <u:SelectionList.ItemTemplate>
        <DataTemplate>
            <Panel Height="40">
                <TextBlock VerticalAlignment="Center" Text="{Binding}"
                    Classes.Active="{Binding $parent[u:SelectionListItem].IsSelected, Mode=OneWay}">
                    <TextBlock.Styles>
                        <Style Selector="TextBlock.Active">
                            <Setter Property="Foreground" Value="{DynamicResource SemiOrange6}" />
                        </Style>
                    </TextBlock.Styles>
                </TextBlock>
            </Panel>
        </DataTemplate>
    </u:SelectionList.ItemTemplate>
</u:SelectionList>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Indicator` | `Control?` | Custom control rendered as the selection indicator. Animated via implicit composition animations. / 自定义选择指示器控件，通过隐式合成动画驱动。 |
| `SelectedItem` | `object?` | The currently selected item (inherited from `SelectingItemsControl`). / 当前选中项。 |
| `SelectionMode` | `SelectionMode` | Forced to `Single`. Cannot be changed. / 强制为 `Single`，不可修改。 |

### Template Parts / 模板部件

| Part | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Indicator` | `ContentPresenter` | Hosts the indicator control and animates its position/size. / 承载指示器控件并驱动其位置和尺寸动画。 |

## Styling & Templating / 样式与模板

### DynamicResource Keys / 动态资源键

| Key | Description / 说明 |
| --- | --- |
| `SelectionListIndicatorBackground` | Background of the default indicator border. / 默认指示器边框的背景。 |

### SelectionListItem / 列表项

Each item is wrapped in a `SelectionListItem` (inherits `ContentControl`). When selected, the item receives `:selected` pseudo-class and bold font weight from the theme. Items are focusable and respond to pointer press for selection.

每个列表项封装在 `SelectionListItem`（继承 `ContentControl`）中。选中时应用 `:selected` 伪类和粗体字重。项可聚焦并响应点击选择。

### Animations / 动画

The indicator uses Avalonia implicit composition animations on `Offset`, `Size`, and `Opacity` with 0.3s duration. The animation is created once on load via `ElementComposition.GetElementVisual`.

指示器使用 Avalonia 隐式合成动画，对 `Offset`、`Size` 和 `Opacity` 属性进行 0.3 秒的过渡。动画在加载时通过 `ElementComposition.GetElementVisual` 创建。

## FAQ / 常见问题

**Q: Can I use SelectionList for multi-select? / SelectionList 可以多选吗？**

A: No. `SelectionMode` is coerced to `Single`. Use `ListBox` for multi-select scenarios. / 不可以。`SelectionMode` 被强制为 `Single`。多选场景使用 `ListBox`。

**Q: How do I customize the indicator animation duration? / 如何自定义指示器动画时长？**

A: The animation duration is hardcoded at 0.3s. To change it, create a custom control that inherits from `SelectionList` and override `EnsureIndicatorAnimation`. / 动画时长硬编码为 0.3 秒。如需修改，创建继承 `SelectionList` 的自定义控件并重写 `EnsureIndicatorAnimation`。
