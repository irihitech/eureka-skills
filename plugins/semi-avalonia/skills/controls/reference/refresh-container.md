---
category: Components
title: RefreshContainer
subtitle: 下拉刷新容器
description: 下拉刷新容器用于通过下拉手势触发内容刷新。
---

# RefreshContainer / 下拉刷新容器

A container control that enables pull-to-refresh interaction for scrollable content. Inherits from `ContentControl`. When the user pulls down (or in a configurable direction) past a threshold, a `RefreshRequested` event fires so the app can refresh data. Supports customizable pull direction, refresh threshold, and integration with `ScrollViewer` and list controls.

一个容器控件，为可滚动内容启用下拉刷新交互。继承自 `ContentControl`。当用户下拉（或按可配置的方向）超过阈值时，触发 `RefreshRequested` 事件，使应用可以刷新数据。支持可自定义的拉动方向、刷新阈值，以及与 `ScrollViewer` 和列表控件的集成。

## When to Use / 何时使用

Use `RefreshContainer` when you have scrollable content that benefits from a pull-to-refresh pattern — news feeds, social media timelines, email inboxes, data dashboards, or any list that fetches live data. The user pulls the content area past its top edge, a refresh indicator appears, and upon release the app reloads data. For non-scrollable surfaces that still need a refresh gesture, consider `RefreshVisualizer` directly. For button-triggered refresh, use a standard `Button` or `RefreshButton` instead.

当你拥有可从下拉刷新模式中受益的可滚动内容时使用 `RefreshContainer` —— 新闻资讯流、社交媒体时间线、电子邮件收件箱、数据仪表板或任何获取实时数据的列表。用户将内容区域拉过其顶部边缘，刷新指示器出现，释放后应用重新加载数据。对于仍需要刷新手势但不可滚动的表面，请考虑直接使用 `RefreshVisualizer`。对于按钮触发的刷新，请使用标准 `Button` 或 `RefreshButton`。

## Basic Usage / 基本使用

```xml
<RefreshContainer RefreshRequested="OnRefreshRequested">
    <ScrollViewer>
        <ListBox x:Name="MyListBox"
                 ItemsSource="{Binding Items}" />
    </ScrollViewer>
</RefreshContainer>
```

```csharp
// Code-behind
private async void OnRefreshRequested(
    object? sender, RefreshRequestedEventArgs e)
{
    // Start refresh operation
    var deferral = e.GetDeferral();

    try
    {
        await LoadDataAsync();
    }
    finally
    {
        deferral.Complete(); // Dismiss refresh indicator
    }
}
```

## Common Scenarios / 常用场景

### With ListBox or ItemsControl / 与 ListBox 或 ItemsControl 配合

Wrap any items control inside a `ScrollViewer` then wrap that in `RefreshContainer`. The `ScrollViewer` provides the scroll gesture detection.

```xml
<RefreshContainer RefreshRequested="OnRefresh">
    <ScrollViewer>
        <ListBox ItemsSource="{Binding Messages}">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Subject}" />
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </ScrollViewer>
</RefreshContainer>
```

### Custom PullDirection / 自定义拉动方向

Set `PullDirection` to enable top-to-bottom (default), bottom-to-top, left-to-right, or right-to-left refresh.

```xml
<!-- Bottom pull for chat-like interfaces where newest messages appear at bottom -->
<RefreshContainer PullDirection="BottomToTop"
                  RefreshRequested="OnRefresh">
    <ScrollViewer>
        <ListBox ItemsSource="{Binding ChatMessages}" />
    </ScrollViewer>
</RefreshContainer>
```

### MVVM Command Binding / MVVM 命令绑定

Bind to an `ICommand` in your ViewModel for clean MVVM separation. Use `IsRefreshing` to control the indicator visibility.

```xml
<RefreshContainer Command="{Binding RefreshCommand}"
                  IsRefreshing="{Binding IsRefreshing}">
    <ScrollViewer>
        <ListBox ItemsSource="{Binding Items}" />
    </ScrollViewer>
</RefreshContainer>
```

```csharp
public class FeedViewModel : ObservableObject
{
    private bool _isRefreshing;
    public bool IsRefreshing
    {
        get => _isRefreshing;
        set => SetProperty(ref _isRefreshing, value);
    }

    public ICommand RefreshCommand { get; }

    public FeedViewModel()
    {
        RefreshCommand = new AsyncRelayCommand(OnRefreshAsync);
    }

    private async Task OnRefreshAsync()
    {
        IsRefreshing = true;
        try
        {
            await LoadFeedAsync();
        }
        finally
        {
            IsRefreshing = false;
        }
    }
}
```

### Adjusting RefreshThreshold / 调整刷新阈值

Set `RefreshThreshold` to control how far the user must pull before the refresh triggers.

```xml
<RefreshContainer RefreshRequested="OnRefresh"
                  RefreshThreshold="0.7">
    <ScrollViewer>
        <ListBox ItemsSource="{Binding Items}" />
    </ScrollViewer>
</RefreshContainer>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PullDirection` | `PullDirection` | Direction to pull for refresh: `TopToBottom` (default), `BottomToTop`, `LeftToRight`, or `RightToLeft`. / 刷新拉动的方向：`TopToBottom`（默认）、`BottomToTop`、`LeftToRight` 或 `RightToLeft`。 |
| `RefreshThreshold` | `double` | Normalized threshold (0.0–1.0) the user must pull past to trigger refresh. Defaults to `0.5`. / 用户必须拉过才能触发刷新的归一化阈值（0.0–1.0）。默认为 `0.5`。 |
| `IsRefreshing` | `bool` | Whether a refresh is currently in progress. Setting to `false` dismisses the indicator. / 刷新当前是否正在进行。设为 `false` 可关闭指示器。 |
| `Visualizer` | `RefreshVisualizer?` | The `RefreshVisualizer` instance used to render the refresh indicator. Auto-created if not set. / 用于渲染刷新指示器的 `RefreshVisualizer` 实例。未设置时自动创建。 |
| `Content` | `object?` | The scrollable content wrapped by the container. Inherited from `ContentControl`. / 容器包裹的可滚动内容。继承自 `ContentControl`。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `RefreshRequested` | Raised when the user pulls past the threshold and releases. `RefreshRequestedEventArgs` provides a `GetDeferral()` method for async refresh operations. / 当用户拉过阈值并释放时触发。`RefreshRequestedEventArgs` 提供 `GetDeferral()` 方法用于异步刷新操作。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides styling for `RefreshContainer` with color classes and visual state management for the refresh indicator. The indicator appears during the pull gesture and while refreshing.

Semi.Avalonia 通过颜色类和刷新指示器的视觉状态管理为 `RefreshContainer` 提供样式。指示器在拉动过程中和刷新期间出现。

### Theme Variants / 主题变体

| Theme / 主题 | Resource Key / 资源键 | Appearance / 外观 |
| --- | --- | --- |
| **Default** | `{x:Type RefreshContainer}` | Standard pull-to-refresh container with circular progress indicator. / 标准下拉刷新容器，带圆形进度指示器。 |

```xml
<!-- Default theme -->
<RefreshContainer RefreshRequested="OnRefresh">
    <ScrollViewer>...</ScrollViewer>
</RefreshContainer>
```

### Color Classes / 颜色类

Apply via the `Classes` attached property. The color class flows through to the internal `RefreshVisualizer`.

| Class / 类名 | Description / 说明 |
| --- | --- |
| `Primary` | (default) Blue accent refresh indicator. / （默认）蓝色强调刷新指示器。 |
| `Secondary` | Neutral gray indicator. / 中性灰色指示器。 |

```xml
<RefreshContainer Classes="Secondary" RefreshRequested="OnRefresh">
    <ScrollViewer>...</ScrollViewer>
</RefreshContainer>
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:disabled` | Control is disabled (`IsEnabled = false`). Pull-to-refresh does not respond. / 控件已禁用。下拉刷新不响应。 |
| `:refreshing` | Applied when `IsRefreshing` is `true` or a deferred refresh is in progress. / 当 `IsRefreshing` 为 `true` 或延迟刷新正在进行时应用。 |

The internal `RefreshVisualizer` supports additional visual states:
内部 `RefreshVisualizer` 支持额外的视觉状态：

| Visualizer State | Description / 说明 |
| --- | --- |
| `Idle` | No interaction; indicator hidden. / 无交互；指示器隐藏。 |
| `Pulling` | User is pulling but hasn't reached threshold. / 用户正在拉动但尚未达到阈值。 |
| `ReachedThreshold` | User has pulled past the threshold. Indicator prompts release. / 用户已拉过阈值。指示器提示释放。 |
| `Refreshing` | Refresh operation is in progress. / 刷新操作正在进行。 |
| `Peeking` | Brief indicator appearance while content is loading. / 内容加载时指示器短暂出现。 |

### ControlTheme Structure / 控件主题结构

The `RefreshContainer` theme wraps content in a layout that detects pull gestures and overlays a `RefreshVisualizer` at the pull origin. The visualizer shows a circular progress ring with an animated arc during the refresh operation. The container manages the interaction between the scroll gesture, threshold detection, and visualizer state transitions.

`RefreshContainer` 主题将内容包装在检测拉动操作的布局中，并在拉动起点覆盖 `RefreshVisualizer`。视觉器在刷新操作期间显示带动画弧的圆形进度环。容器管理滚动操作、阈值检测和视觉状态转换之间的交互。

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `RefreshContainerBackground` | Refresh container background / 刷新容器背景 |
| `RefreshContainerForeground` | Refresh container foreground / 刷新容器前景 |
| `RefreshContainerVisualizerBackground` | Refresh visualizer background / 刷新可视化器背景 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_RefreshVisualizer` | `RefreshVisualizer` | The visual indicator rendered during pull and refresh. Manages the animated progress ring. / 拉动和刷新期间渲染的视觉指示器。管理动画进度环。 |

## FAQ / 常见问题

**Q: Why doesn't pull-to-refresh work when my list is short? / 为什么列表很短时下拉刷新不起作用？**

A: `RefreshContainer` requires scrollable content. If your items control has too few items to overflow, the `ScrollViewer` cannot scroll and the pull gesture won't be detected. Ensure your `ScrollViewer` has enough content to trigger scrolling, or set a minimum height on the content area.

`RefreshContainer` 需要可滚动内容。如果你的项控件项太少无法溢出，`ScrollViewer` 无法滚动，拉动操作将不会被检测到。确保你的 `ScrollViewer` 有足够的内容触发滚动，或在内容区域设置最小高度。

**Q: How do I keep the refresh indicator visible during async data loading? / 如何在异步数据加载期间保持刷新指示器可见？**

A: Use `e.GetDeferral()` in the `RefreshRequested` handler. The deferral keeps the indicator visible until you call `deferral.Complete()`. Alternatively, bind `IsRefreshing` to a ViewModel property and set it to `true` during the async operation, then `false` when complete.

在 `RefreshRequested` 处理器中使用 `e.GetDeferral()`。延迟保持指示器可见，直到你调用 `deferral.Complete()`。或者，将 `IsRefreshing` 绑定到 ViewModel 属性，在异步操作期间设为 `true`，完成后设为 `false`。

**Q: Can I customize the refresh indicator appearance? / 我可以自定义刷新指示器的外观吗？**

A: Yes. You can set a custom `RefreshVisualizer` via the `Visualizer` property with your own template. This allows replacing the circular progress ring with a custom animation, icon, or text. The visualizer's `Content` property can host any custom UI.

可以。你可以通过 `Visualizer` 属性设置自定义 `RefreshVisualizer` 及其自己的模板。这允许用自定义动画、图标或文本替换圆形进度环。视觉器的 `Content` 属性可以托管任何自定义 UI。
