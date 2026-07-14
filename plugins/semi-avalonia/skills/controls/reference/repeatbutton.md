---
category: Components
title: RepeatButton
subtitle: 重复按钮
description: 重复按钮在按住时以固定间隔重复触发 Click 事件。
---

## RepeatButton / 重复按钮

A button that fires `Click` events repeatedly while pressed. Inherits from `Button` and adds `Delay` and `Interval` properties to control repetition timing. Ideal for spin buttons, scroll arrows, media transport controls, and numeric up/down repeaters.

按住时重复触发 `Click` 事件的按钮。继承自 `Button`，并增加 `Delay` 和 `Interval` 属性来控制重复时机。适用于微调按钮、滚动箭头、媒体播放控件和数值增减重复器。

## When to Use / 何时使用

Use `RepeatButton` when you need an action to repeat automatically while the user holds the button down — incrementing/decrementing values, scrolling content, or scrubbing media. For single-click actions (submit, navigate, toggle), use `Button` or `ToggleButton`. `RepeatButton` is commonly used inside composite controls like `ButtonSpinner`, `NumericUpDown`, and `ScrollBar` rather than as a standalone control.

当你需要用户按住按钮时自动重复执行某个操作时使用 `RepeatButton` —— 增减数值、滚动内容或快进媒体。对于单次点击操作（提交、导航、切换），请使用 `Button` 或 `ToggleButton`。`RepeatButton` 通常内嵌在 `ButtonSpinner`、`NumericUpDown` 和 `ScrollBar` 等复合控件中使用，而非独立使用。

## Basic Usage / 基本使用

```xml
<RepeatButton Content="+"
              Delay="500"
              Interval="100"
              Click="OnIncrementClick" />
```

```csharp
// Code-behind
private int _value = 0;

private void OnIncrementClick(object? sender, RoutedEventArgs e)
{
    _value++;
    ValueDisplay.Text = _value.ToString();
}
```

```csharp
// Programmatic creation
var repeatBtn = new RepeatButton
{
    Content = "+",
    Delay = 500,     // Wait 500ms before first repeat
    Interval = 100    // Then repeat every 100ms
};
repeatBtn.Click += (s, e) => { _value++; };
```

## Common Scenarios / 常用场景

### Numeric Up/Down / 数值增减

Use `RepeatButton` inside a horizontal layout with a value display for simple numeric steppers.

```xml
<StackPanel Orientation="Horizontal" Spacing="4">
    <RepeatButton Content="−"
                  Width="32" Height="32"
                  Delay="400" Interval="80"
                  Click="OnDecrementClick" />
    <TextBlock x:Name="ValueDisplay"
               Text="0"
               VerticalAlignment="Center"
               Width="40"
               TextAlignment="Center" />
    <RepeatButton Content="+"
                  Width="32" Height="32"
                  Delay="400" Interval="80"
                  Click="OnIncrementClick" />
</StackPanel>
```

### Scroll Arrows / 滚动箭头

Embed `RepeatButton` arrows inside a custom scroll viewer for fine-grained scrolling.

```xml
<RepeatButton Content="▲"
              Delay="300" Interval="50"
              Command="{Binding ScrollUpCommand}" />
<RepeatButton Content="▼"
              Delay="300" Interval="50"
              Command="{Binding ScrollDownCommand}" />
```

### Media Transport / 媒体播放控制

Fast-forward or rewind with `RepeatButton` for seek controls.

```xml
<RepeatButton Content="⏪"
              Delay="600" Interval="200"
              Command="{Binding RewindCommand}" />
<RepeatButton Content="⏩"
              Delay="600" Interval="200"
              Command="{Binding FastForwardCommand}" />
```

### Inside ButtonSpinner / 在 ButtonSpinner 内部

`ButtonSpinner` uses `RepeatButton` internally for its increment/decrement actions. When customizing `ButtonSpinner` templates, the repeat buttons are named template parts.

`ButtonSpinner` 内部使用 `RepeatButton` 实现增减操作。自定义 `ButtonSpinner` 模板时，重复按钮是命名的模板部件。

## Property Reference / 属性参考

RepeatButton inherits all properties from `Button`. Key additional properties:

RepeatButton 继承 `Button` 的所有属性。关键附加属性：

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Delay` | `int` | Milliseconds to wait after the button is pressed before the first repeat. Default: 500 for `KeyMode`, 300 for `MouseMode`. / 按钮按下后等待首次重复的毫秒数。默认：`KeyMode` 为 500，`MouseMode` 为 300。 |
| `Interval` | `int` | Milliseconds between subsequent repeats while the button remains pressed. Default: 33 for `KeyMode`, 80 for `MouseMode`. / 按钮保持按下时后续重复之间的毫秒数。默认：`KeyMode` 为 33，`MouseMode` 为 80。 |
| `Content` | `object` | Inherited from `ContentControl`. Displayed content (text, icon, or layout). / 继承自 `ContentControl`。显示的内容（文本、图标或布局）。 |
| `Command` | `ICommand?` | Inherited from `Button`. Invoked on each repeat. Note: `CanExecute` is evaluated per-repeat. / 继承自 `Button`。每次重复时调用。注意：每次重复都会评估 `CanExecute`。 |
| `CommandParameter` | `object?` | Inherited from `Button`. Parameter passed to the command on each repeat. / 继承自 `Button`。每次重复时传递给命令的参数。 |
| `ClickMode` | `ClickMode` | Inherited from `Button`. For `RepeatButton`, `Press` starts repeats immediately; `Release` (default) starts on click. / 继承自 `Button`。对于 `RepeatButton`，`Press` 立即开始重复；`Release`（默认）在点击时开始。 |
| `IsPressed` | `bool` | Inherited from `Button`. (Read-only) Whether the button is currently pressed. Stays `true` during repeat sequence. / 继承自 `Button`。（只读）按钮当前是否被按下。重复期间保持 `true`。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Click` | Raised repeatedly while pressed, after `Delay` then every `Interval` ms. / 按住时重复触发，先等待 `Delay`，然后每 `Interval` 毫秒触发一次。 |
| `IsPressedChanged` | Inherited from `Button`. Raised at press start and release. / 继承自 `Button`。按下开始和释放时触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia `RepeatButton` uses the same styling system as `Button`. All `Button` themes, color classes, and size classes apply to `RepeatButton`. When embedded in composite controls, `RepeatButton` typically uses `BorderlessButton` or `InnerButton` themes.

Semi.Avalonia 的 `RepeatButton` 使用与 `Button` 相同的样式系统。所有 `Button` 主题、颜色类和尺寸类均适用于 `RepeatButton`。内嵌在复合控件中时，`RepeatButton` 通常使用 `BorderlessButton` 或 `InnerButton` 主题。

### Theme Variants / 主题变体

```xml
<!-- Standalone uses standard Button themes -->
<RepeatButton Content="+" Theme="{DynamicResource SolidButton}" />

<!-- Embedded in spinners uses Borderless or InnerButton -->
<RepeatButton Content="▲" Theme="{DynamicResource BorderlessButton}" />
<RepeatButton Content="▲" Theme="{DynamicResource InnerButton}" />
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:pointerover` | Mouse is hovering over the control. / 鼠标悬停。 |
| `:pressed` | Button is pressed and repeating. / 按钮被按下且正在重复。 |
| `:disabled` | Button is disabled (`IsEnabled = false`). / 已禁用。 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the `Content` property. All Semi.Avalonia styles target this part. / 渲染 `Content` 属性。所有 Semi.Avalonia 样式均通过此部件设置。 |

## FAQ / 常见问题

**Q: How do Delay and Interval interact? / Delay 和 Interval 如何配合？**

A: When pressed, `RepeatButton` waits `Delay` milliseconds before firing the first `Click`, then fires `Click` every `Interval` milliseconds until released. For example, with `Delay="500"` and `Interval="100"`: first click at 500ms, then clicks at 600ms, 700ms, 800ms, etc. Shorter `Interval` values produce smoother, faster repetition.

按下时，`RepeatButton` 在触发第一次 `Click` 之前等待 `Delay` 毫秒，然后每 `Interval` 毫秒触发一次 `Click`，直到释放。例如 `Delay="500"` 和 `Interval="100"`：首次点击在 500ms，之后在 600ms、700ms、800ms 等处点击。较短的 `Interval` 值产生更平滑、更快的重复。

**Q: Why aren't repeat timers configurable per-platform? / 为什么重复计时器不按平台配置？**

A: Avalonia's `RepeatButton` uses a single `Delay`/`Interval` pair regardless of platform. Unlike WPF/UWP (which sometimes use system key-repeat settings), Avalonia gives you explicit control. This means the same `Delay`/`Interval` values work identically on Windows, macOS, and Linux. Set values appropriate for your scenario: ~300-500ms `Delay` and ~50-100ms `Interval` for UI controls; shorter for game-like input.

Avalonia 的 `RepeatButton` 在所有平台上使用相同的 `Delay`/`Interval`，与 WPF/UWP 不同（后者有时使用系统按键重复设置）。Avalonia 赋予你显式控制权，使得相同的值在 Windows、macOS 和 Linux 上表现一致。为你的场景设置合适的值：UI 控件约 300-500ms `Delay` 和 50-100ms `Interval`；游戏类输入可更短。

**Q: Should I use RepeatButton as a standalone control? / 应该将 RepeatButton 作为独立控件使用吗？**

A: `RepeatButton` is designed primarily as a building block for composite controls like `ButtonSpinner`, `NumericUpDown`, `ScrollBar`, and slider thumbs. While you can use it standalone (e.g., media transport buttons), be aware that the repeated `Click` pattern may confuse users expecting a single-action button. If the action is not inherently repeatable, use `Button` and handle long-press manually with pointer events.

`RepeatButton` 主要设计为复合控件的构建块，如 `ButtonSpinner`、`NumericUpDown`、`ScrollBar` 和滑块拖动块。虽然可以独立使用（如媒体播放控件），但重复的 `Click` 模式可能会让期望单次操作按钮的用户感到困惑。如果操作本身不可重复，请使用 `Button` 并通过指针事件手动处理长按。
