---
category: Components
title: ProgressBar
subtitle: 进度条
description: 进度条用于展示操作的当前进度。
---

# ProgressBar / 进度条

A control that indicates the progress of a long-running operation. Inherits from `RangeBase` (extends `Control`). Supports determinate (value-based) and indeterminate (marquee-style) modes, horizontal and vertical orientations, and optional progress text display.

一个指示长时间运行操作进度的控件。继承自 `RangeBase`（扩展 `Control`）。支持确定（基于数值）和不确定（跑马灯式）模式、水平和垂直方向以及可选的进度文本显示。

## When to Use / 何时使用

Use `ProgressBar` when an operation takes more than 0.5–1.0 seconds and the user would benefit from knowing progress. Use **determinate** mode (`IsIndeterminate="False"`) when you can measure completion percentage — file downloads, installation progress, form submission steps. Use **indeterminate** mode (`IsIndeterminate="True"`) when the duration is unknown — connecting to a server, waiting for a remote response, loading a complex view. For task-specific progress reporting, bind `Value` and `Maximum` to a ViewModel property updated from an `IProgress<T>` callback.

当操作耗时超过 0.5–1.0 秒且用户需要了解进度时使用 `ProgressBar`。当你能够测量完成百分比时使用**确定**模式（`IsIndeterminate="False"`）—— 文件下载、安装进度、表单提交步骤。当持续时间未知时使用**不确定**模式（`IsIndeterminate="True"`）—— 连接服务器、等待远程响应、加载复杂视图。对于任务特定的进度报告，将 `Value` 和 `Maximum` 绑定到通过 `IProgress<T>` 回调更新的 ViewModel 属性。

## Basic Usage / 基本使用

```xml
<!-- Determinate progress bar -->
<ProgressBar Value="45"
             Minimum="0"
             Maximum="100" />

<!-- Indeterminate progress bar -->
<ProgressBar IsIndeterminate="True" />
```

```csharp
// Code-behind
var progressBar = new ProgressBar
{
    Minimum = 0,
    Maximum = 100,
    Value = 45
};

// Switch to indeterminate during unknown-duration operations
progressBar.IsIndeterminate = true;
```

## Common Scenarios / 常用场景

### Data Binding with IProgress<T> / 与 IProgress<T> 数据绑定

Bind `Value` to a ViewModel property updated via `IProgress<T>` for thread-safe progress updates from background tasks.

```xml
<ProgressBar Value="{Binding DownloadProgress}"
             Maximum="100" />
<TextBlock Text="{Binding DownloadProgress, StringFormat={}{0:F0}%}" />
```

```csharp
public class DownloadViewModel : ObservableObject
{
    private double _downloadProgress;
    public double DownloadProgress
    {
        get => _downloadProgress;
        set => SetProperty(ref _downloadProgress, value);
    }

    public async Task DownloadAsync(CancellationToken ct)
    {
        var progress = new Progress<double>(p => DownloadProgress = p);
        await DownloadFileAsync(progress, ct);
    }
}
```

### IsIndeterminate / 不确定模式

Show indeterminate animation when the operation duration is unknown. Switch back to determinate once a total byte count or item count is known.

```xml
<ProgressBar IsIndeterminate="{Binding IsConnecting}" />
<!-- Once connected and downloading: -->
<ProgressBar IsIndeterminate="False"
             Value="{Binding BytesDownloaded}"
             Maximum="{Binding TotalBytes}" />
```

### Progress Text / 进度文本

Use `ShowProgressText` and `ProgressTextFormat` to overlay a percentage or custom label on the bar.

```xml
<ProgressBar Value="75"
             Maximum="100"
             ShowProgressText="True"
             ProgressTextFormat="{}{0:F1}% Complete" />
```

### Vertical Orientation / 垂直方向

Set `Orientation="Vertical"` for a vertical fill, useful for gauges, volume meters, or side panels.

```xml
<ProgressBar Value="60"
             Maximum="100"
             Orientation="Vertical"
             Height="200"
             Width="20" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Value` | `double` | Current progress value. Must be between `Minimum` and `Maximum`. Defaults to `0`. / 当前进度值。必须在 `Minimum` 和 `Maximum` 之间。默认为 `0`。 |
| `Minimum` | `double` | Lower bound of the progress range. Defaults to `0`. / 进度范围的下限。默认为 `0`。 |
| `Maximum` | `double` | Upper bound of the progress range. Defaults to `100`. / 进度范围的上限。默认为 `100`。 |
| `IsIndeterminate` | `bool` | When `true`, displays a repeating animation instead of a filled bar. Defaults to `false`. / 为 `true` 时显示重复动画而非填充条。默认为 `false`。 |
| `ShowProgressText` | `bool` | When `true`, overlays a text label showing the current progress. Defaults to `true`. / 为 `true` 时覆盖显示当前进度的文本标签。默认为 `true`。 |
| `ProgressTextFormat` | `string?` | Format string for the progress text. `{0}` is the percentage. When `null`, defaults to `"{0:P0}"`. / 进度文本的格式字符串。`{0}` 为百分比。为 `null` 时默认为 `"{0:P0}"`。 |
| `Orientation` | `Orientation` | `Horizontal` (default) or `Vertical` — the fill direction. / `Horizontal`（默认）或 `Vertical` — 填充方向。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `ValueChanged` | Raised after `Value` changes. Inherited from `RangeBase`. `RangeBaseValueChangedEventArgs` provides `OldValue` and `NewValue`. / `Value` 更改后触发。继承自 `RangeBase`。`RangeBaseValueChangedEventArgs` 提供 `OldValue` 和 `NewValue`。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides a rich styling system for `ProgressBar` with color classes, size classes, and visual state management for determinate and indeterminate modes.

Semi.Avalonia 为 `ProgressBar` 提供了丰富的样式系统，包含颜色类、尺寸类以及确定和不确定模式的视觉状态管理。

### Theme Variants / 主题变体

| Theme / 主题 | Resource Key / 资源键 | Appearance / 外观 |
| --- | --- | --- |
| **Default** | `{x:Type ProgressBar}` | Standard progress bar with rounded fill. / 标准进度条，带圆角填充。 |

```xml
<!-- Default theme -->
<ProgressBar Value="60" />
```

### Color Classes / 颜色类

Apply via the `Classes` attached property. Defaults to `Primary` when no color class is specified.

| Class / 类名 | Description / 说明 |
| --- | --- |
| `Primary` | (default) Blue accent fill. / （默认）蓝色强调填充。 |
| `Secondary` | Neutral gray fill. / 中性灰色填充。 |
| `Tertiary` | Subtle fill for background operations. / 微妙填充，用于后台操作。 |
| `Success` | Green fill for completion indication. / 绿色填充，用于完成指示。 |
| `Warning` | Amber fill for cautionary progress. / 琥珀色填充，用于警示性进度。 |
| `Danger` | Red fill for critical or over-limit progress. / 红色填充，用于关键或超限进度。 |

```xml
<ProgressBar Value="80" Classes="Success" />
<ProgressBar Value="95" Classes="Danger" />
<ProgressBar IsIndeterminate="True" Classes="Secondary" />
```

### Size Classes / 尺寸类

| Class / 类名 | Description / 说明 |
| --- | --- |
| *(default)* | Standard height (typically 4–6px). / 标准高度（通常 4–6px）。 |
| `Large` | Taller bar for prominent displays. / 更高的进度条，用于突出显示。 |
| `Small` | Thinner bar for dense layouts. / 更细的进度条，用于紧凑布局。 |

```xml
<ProgressBar Value="50" Classes="Small" />
<ProgressBar Value="50" Classes="Large" />
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:disabled` | Control is disabled (`IsEnabled = false`). / 控件已禁用。 |
| `:indeterminate` | Applied when `IsIndeterminate` is `true`. Triggers marquee animation. / 当 `IsIndeterminate` 为 `true` 时应用。触发跑马灯动画。 |
| `:horizontal` | Applied when `Orientation` is `Horizontal` (default). / 当 `Orientation` 为 `Horizontal`（默认）时应用。 |
| `:vertical` | Applied when `Orientation` is `Vertical`. / 当 `Orientation` 为 `Vertical` 时应用。 |

### ControlTheme Structure / 控件主题结构

The `ProgressBar` theme contains a `Border` layout root with an inner `Border#PART_Indicator` representing the filled portion, and optionally a `TextBlock#PART_ProgressText` overlay. The indeterminate animation uses a repeating `Animation` on the indicator's `RenderTransform` or `Width`/`Height`.

`ProgressBar` 主题包含一个 `Border` 布局根，内有一个代表填充部分的 `Border#PART_Indicator`，以及可选的 `TextBlock#PART_ProgressText` 覆盖层。不确定动画使用对指示器的 `RenderTransform` 或 `Width`/`Height` 的重复 `Animation`。

### DynamicResource Keys / 动态资源键

```
ProgressBarPrimaryBackground
ProgressBarPrimaryIndicatorBackground
ProgressBarPrimaryProgressTextForeground
ProgressBarSuccessIndicatorBackground
ProgressBarDangerIndicatorBackground
ProgressBarLargeHeight
ProgressBarSmallHeight
...
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Indicator` | `Border` | The filled portion of the progress bar. Width/Height is animated based on `Value` ratio. / 进度条的填充部分。宽度/高度基于 `Value` 比例进行动画。 |
| `PART_ProgressText` | `TextBlock` | Optional overlay showing formatted progress text. Visible when `ShowProgressText` is `true`. / 显示格式化进度文本的可选覆盖层。当 `ShowProgressText` 为 `true` 时可见。 |

## FAQ / 常见问题

**Q: How do I report progress from a background thread? / 如何从后台线程报告进度？**

A: Use `IProgress<T>` with `Progress<T>` in your ViewModel. `Progress<T>` automatically marshals callbacks to the synchronization context. In code-behind, use `Dispatcher.UIThread.Post` to update `Value`. Direct cross-thread property mutation will throw or be silently lost.

在 ViewModel 中使用 `IProgress<T>` 配合 `Progress<T>`。`Progress<T>` 自动将回调 marshaling 到同步上下文。在代码后置中，使用 `Dispatcher.UIThread.Post` 更新 `Value`。直接跨线程属性变更将抛出异常或被静默丢失。

**Q: When should I use IsIndeterminate vs. a determinate progress bar? / 何时使用不确定模式而非确定进度条？**

A: Use indeterminate when you don't know the total duration — connecting, waiting, loading. Use determinate when you have a measurable total — file size, item count, step count. A common pattern is to start indeterminate, then switch to determinate once the total is known (e.g., after receiving Content-Length from an HTTP response).

当你不清楚总时长时使用不确定模式 —— 连接、等待、加载。当你拥有可衡量的总量时使用确定模式 —— 文件大小、项数量、步骤数量。常见模式是先以不确定模式开始，得知总量后切换为确定模式（例如，收到 HTTP 响应的 Content-Length 后）。

**Q: How does Semi.Avalonia's ProgressBar styling differ from stock Avalonia? / Semi.Avalonia 的 ProgressBar 样式与标准 Avalonia 有何不同？**

A: Semi.Avalonia adds the 6-color class system (`Primary`, `Secondary`, `Tertiary`, `Success`, `Warning`, `Danger`), `Large`/`Small` size classes, and themed `DynamicResource` keys following the `ProgressBar{Color}{State}{Property}` naming convention. Stock Avalonia uses a single `ProgressBar` theme with flat pseudo-class selectors and relies on a single accent color. Semi's indeterminate animation also uses themed brush colors matching the selected color class.

Semi.Avalonia 增加了 6 色类系统（`Primary`、`Secondary`、`Tertiary`、`Success`、`Warning`、`Danger`）、`Large`/`Small` 尺寸类以及遵循 `ProgressBar{Color}{State}{Property}` 命名约定的主题化 `DynamicResource` 键。标准 Avalonia 使用单一 `ProgressBar` 主题搭配扁平伪类选择器，并依赖单一强调色。Semi 的不确定动画还使用与所选颜色类匹配的主题笔刷颜色。
