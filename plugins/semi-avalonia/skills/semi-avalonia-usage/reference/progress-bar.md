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

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How do I report progress from a background thread? / 如何从后台线程报告进度？**

A: Use `IProgress<T>` with `Progress<T>` in your ViewModel. `Progress<T>` automatically marshals callbacks to the synchronization context. In code-behind, use `Dispatcher.UIThread.Post` to update `Value`. Direct cross-thread property mutation will throw or be silently lost.

在 ViewModel 中使用 `IProgress<T>` 配合 `Progress<T>`。`Progress<T>` 自动将回调 marshaling 到同步上下文。在代码后置中，使用 `Dispatcher.UIThread.Post` 更新 `Value`。直接跨线程属性变更将抛出异常或被静默丢失。

**Q: When should I use IsIndeterminate vs. a determinate progress bar? / 何时使用不确定模式而非确定进度条？**

A: Use indeterminate when you don't know the total duration — connecting, waiting, loading. Use determinate when you have a measurable total — file size, item count, step count. A common pattern is to start indeterminate, then switch to determinate once the total is known (e.g., after receiving Content-Length from an HTTP response).

当你不清楚总时长时使用不确定模式 —— 连接、等待、加载。当你拥有可衡量的总量时使用确定模式 —— 文件大小、项数量、步骤数量。常见模式是先以不确定模式开始，得知总量后切换为确定模式（例如，收到 HTTP 响应的 Content-Length 后）。

**Q: How does Semi.Avalonia's ProgressBar styling differ from stock Avalonia? / Semi.Avalonia 的 ProgressBar 样式与标准 Avalonia 有何不同？**

A: Semi.Avalonia themes `ProgressBar` with additional style classes (colors and sizes), ControlTheme variants and per-control `DynamicResource` keys — the exact names change between releases, so treat the generated `semi-avalonia` skill as the catalog and use only what it lists. Stock Avalonia uses a single `ProgressBar` theme with flat pseudo-class selectors and relies on a single accent color.

A: Semi.Avalonia 为 `ProgressBar` 提供了额外的样式类（颜色与尺寸）、ControlTheme 变体和控件级 `DynamicResource` 键 —— 具体名称随版本变化，请以生成的 `semi-avalonia` skill 为目录，只使用其中列出的名称。标准 Avalonia 使用单一 `ProgressBar` 主题搭配扁平伪类选择器，并依赖单一强调色。
