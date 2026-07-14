---
category: Components
title: ButtonSpinner
subtitle: 微调按钮
description: 微调按钮包含两个重复按钮，用于增减数值或循环选项。
---

## ButtonSpinner / 微调按钮

A composite control that combines a content area with two `RepeatButton` controls for incrementing and decrementing values. Serves as the base for `NumericUpDown` and can be used standalone for custom spinner scenarios. Content is placed between the increase and decrease buttons, which can be positioned on the left or right.

一个包含内容区域和两个用于增减值的 `RepeatButton` 控件的复合控件。作为 `NumericUpDown` 的基础，也可独立用于自定义微调场景。内容位于增减按钮之间，按钮可放置在左侧或右侧。

## When to Use / 何时使用

Use `ButtonSpinner` when you need a spinner-like UI for cycling through values that isn't limited to numbers — for example, cycling through string options, zoom levels, or custom states. For strictly numeric spinners, use `NumericUpDown` which extends `ButtonSpinner` with value parsing, min/max validation, and format strings. Use `ButtonSpinner` directly when you need custom content between the repeat buttons or custom spin logic.

当你需要一个类似微调控件的 UI 来循环切换非纯数字值时使用 `ButtonSpinner` —— 例如切换字符串选项、缩放级别或自定义状态。对于严格数值的微调器，请使用 `NumericUpDown`，它继承 `ButtonSpinner` 并附加了值解析、最小/最大验证和格式字符串。当你需要在重复按钮之间放置自定义内容或实现自定义微调逻辑时，直接使用 `ButtonSpinner`。

## Basic Usage / 基本使用

```xml
<ButtonSpinner Spin="OnSpin">
    <TextBlock Text="Option 1" />
</ButtonSpinner>
```

```csharp
// Code-behind
private string[] _options = { "Option 1", "Option 2", "Option 3" };
private int _index = 0;

private void OnSpin(object? sender, SpinEventArgs e)
{
    if (e.Direction == SpinDirection.Increase)
        _index = (_index + 1) % _options.Length;
    else
        _index = (_index - 1 + _options.Length) % _options.Length;

    // Update content
    if (sender is ButtonSpinner spinner)
        spinner.Content = _options[_index];
}
```

```csharp
// Programmatic creation
var spinner = new ButtonSpinner
{
    Content = new TextBlock { Text = "Medium" },
    ButtonSpinnerLocation = Location.Right
};
spinner.Spin += (s, e) =>
{
    // Handle spin direction
};
```

## Common Scenarios / 常用场景

### String Option Switcher / 字符串选项切换

Cycle through text options like font sizes, zoom levels, or theme names.

```xml
<ButtonSpinner x:Name="FontSizeSpinner"
               Spin="OnFontSizeSpin"
               Width="120">
    <TextBlock x:Name="FontSizeDisplay"
               Text="Small"
               TextAlignment="Center" />
</ButtonSpinner>
```

```csharp
private readonly string[] _fontSizes = { "Small", "Medium", "Large", "Extra Large" };
private int _fontIndex = 1;

private void OnFontSizeSpin(object? sender, SpinEventArgs e)
{
    _fontIndex = e.Direction == SpinDirection.Increase
        ? Math.Min(_fontIndex + 1, _fontSizes.Length - 1)
        : Math.Max(_fontIndex - 1, 0);
    FontSizeDisplay.Text = _fontSizes[_fontIndex];
}
```

### Left-Positioned Buttons / 左侧按钮布局

Set `ButtonSpinnerLocation="Left"` to place repeat buttons on the left side of the content.

```xml
<ButtonSpinner ButtonSpinnerLocation="Left"
               Spin="OnSpin">
    <TextBlock Text="Level 5" />
</ButtonSpinner>
```

### Custom Spin Validation / 自定义微调验证

Use `SpinEventArgs` to cancel a spin based on custom logic.

```csharp
private void OnValidatedSpin(object? sender, SpinEventArgs e)
{
    if (e.Direction == SpinDirection.Increase && _value >= _maxValue)
    {
        // Prevent spinning past the maximum
        return;
    }
    if (e.Direction == SpinDirection.Decrease && _value <= _minValue)
    {
        return;
    }

    _value += e.Direction == SpinDirection.Increase ? 1 : -1;
}
```

### Disable Spinning / 禁用微调

Set `AllowSpin="False"` to prevent both repeat buttons from responding.

```xml
<ButtonSpinner AllowSpin="False"
               Spin="OnSpin">
    <TextBlock Text="Locked" />
</ButtonSpinner>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `AllowSpin` | `bool` | Whether the spinner responds to increment/decrement. When `false`, repeat buttons are disabled. / 微调器是否响应增减。设为 `false` 时重复按钮禁用。 |
| `ButtonSpinnerLocation` | `Location` | Position of the repeat buttons: `Left` or `Right` (default). / 重复按钮位置：`Left` 或 `Right`（默认）。 |
| `ValidSpinDirection` | `ValidSpinDirections` | Restricts allowed spin directions: `None`, `Increase`, `Decrease`, or `Increase | Decrease` (default). / 限制允许的微调方向：`None`、`Increase`、`Decrease` 或 `Increase | Decrease`（默认）。 |
| `Content` | `object` | Inherited from `ContentControl`. The content between the repeat buttons. / 继承自 `ContentControl`。重复按钮之间的内容。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Spin` | Raised when either repeat button is clicked. `SpinEventArgs.Direction` indicates `Increase` or `Decrease`. The event is raised repeatedly while the repeat button is held. / 任一重复按钮被点击时触发。`SpinEventArgs.Direction` 指示 `Increase` 或 `Decrease`。按住重复按钮时事件会重复触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides a `ButtonSpinner` theme that arranges two `RepeatButton` instances with `InnerButton` styling on either side of a content area. The internal repeat buttons inherit the `Button` pseudo-class system.

Semi.Avalonia 提供 `ButtonSpinner` 主题，在内容区域两侧各放置一个带 `InnerButton` 样式的 `RepeatButton`。内部重复按钮继承 `Button` 伪类系统。

### ControlTheme Structure / 控件主题结构

```xml
<!-- Conceptual structure; not actual XAML -->
<Grid ColumnDefinitions="Auto,*,Auto">
    <RepeatButton x:Name="PART_DecreaseButton"    Grid.Column="0"
                  Theme="{DynamicResource InnerButton}" />
    <ContentPresenter x:Name="PART_ContentPresenter" Grid.Column="1" />
    <RepeatButton x:Name="PART_IncreaseButton"    Grid.Column="2"
                  Theme="{DynamicResource InnerButton}" />
</Grid>
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_IncreaseButton` | `RepeatButton` | The button that triggers `Spin` with `SpinDirection.Increase`. / 触发 `Spin` 且方向为 `SpinDirection.Increase` 的按钮。 |
| `PART_DecreaseButton` | `RepeatButton` | The button that triggers `Spin` with `SpinDirection.Decrease`. / 触发 `Spin` 且方向为 `SpinDirection.Decrease` 的按钮。 |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the `Content` property between the buttons. / 在按钮之间渲染 `Content` 属性。 |

### Pseudo-classes / 伪类

The `ButtonSpinner` itself does not define additional pseudo-classes. The internal `RepeatButton` instances respond to the standard Button pseudo-classes (`:pointerover`, `:pressed`, `:disabled`).

`ButtonSpinner` 本身不定义额外的伪类。内部 `RepeatButton` 实例响应标准 Button 伪类（`:pointerover`、`:pressed`、`:disabled`）。

### Special ControlThemes / 特殊控件主题

Semi.Avalonia defines two additional `ControlTheme` resources within `ButtonSpinner.axaml` beyond the default `{x:Type ButtonSpinner}` theme.

Semi.Avalonia 在 `ButtonSpinner.axaml` 中定义了除默认 `{x:Type ButtonSpinner}` 主题外的两个额外 `ControlTheme` 资源。

#### `ButtonSpinnerRepeatButton`

**TargetType:** `RepeatButton`
**Resource Key:** `ButtonSpinnerRepeatButton`

A minimalist repeat-button theme used internally by both `ButtonSpinner` and `SplitButtonSpinner`. It renders a bare `ContentPresenter` without chrome — the parent `ButtonSpinner` template supplies the border and background. This theme adds `:pointerover`, `:pressed`, and `:disabled` background color changes via `ButtonSpinnerRepeatButton*` dynamic resources.

一个极简的重复按钮主题，由 `ButtonSpinner` 和 `SplitButtonSpinner` 内部使用。它渲染一个无装饰的 `ContentPresenter` —— 父级 `ButtonSpinner` 模板提供边框和背景。该主题通过 `ButtonSpinnerRepeatButton*` 动态资源添加 `:pointerover`、`:pressed` 和 `:disabled` 背景色变化。

```xml
<!-- Used internally, but you can reference it for custom RepeatButtons -->
<RepeatButton Theme="{StaticResource ButtonSpinnerRepeatButton}"
              Content="+" />
```

**Key resources:** `ButtonSpinnerRepeatButtonBackground`, `ButtonSpinnerRepeatButtonPointeroverBackground`, `ButtonSpinnerRepeatButtonPressedBackground`, `ButtonSpinnerRepeatButtonDisabledBackground`, `ButtonSpinnerRepeatButtonForeground`, `ButtonSpinnerRepeatButtonBorderBrush`

#### `SplitButtonSpinner`

**TargetType:** `ButtonSpinner`
**Resource Key:** `SplitButtonSpinner`

An alternative `ButtonSpinner` layout where the decrease and increase buttons are placed on the left and right sides of the content respectively (horizontal split). This is used by `NumericUpDown` when a split-button appearance is desired. Supports `:left` pseudo-class to swap button positions for RTL or left-aligned layouts.

一种替代的 `ButtonSpinner` 布局，减小和增大按钮分别位于内容的左侧和右侧（水平分割）。当需要分割按钮外观时由 `NumericUpDown` 使用。支持 `:left` 伪类以交换按钮位置，适用于 RTL 或左对齐布局。

```xml
<ButtonSpinner Theme="{StaticResource SplitButtonSpinner}"
               Spin="OnSpin">
    <TextBlock Text="{Binding Value}" />
</ButtonSpinner>
```

**Key resources:** `SplitButtonSpinnerButtonPadding`, `SplitButtonSpinnerLeftButtonCornerRadius`, `SplitButtonSpinnerRightButtonCornerRadius`, `SplitButtonSpinnerDecreaseButtonGlyph`, `SplitButtonSpinnerIncreaseButtonGlyph`

## FAQ / 常见问题

**Q: How is ButtonSpinner different from NumericUpDown? / ButtonSpinner 与 NumericUpDown 有何不同？**

A: `ButtonSpinner` is the base class and only provides the spinner shell — two repeat buttons with content in between. It has no built-in notion of minimum, maximum, numeric parsing, or format strings. `NumericUpDown` extends `ButtonSpinner` and adds `Value` (double?), `Minimum`, `Maximum`, `Increment`, `FormatString`, `ParsingStyle`, and `CultureInfo`. Use `ButtonSpinner` for non-numeric cycling; use `NumericUpDown` for numeric input with validation.

`ButtonSpinner` 是基类，仅提供微调器外壳 —— 两个重复按钮和中间的内容。它没有内置的最小值、最大值、数值解析或格式字符串概念。`NumericUpDown` 继承 `ButtonSpinner` 并添加了 `Value`（double?）、`Minimum`、`Maximum`、`Increment`、`FormatString`、`ParsingStyle` 和 `CultureInfo`。非数值循环使用 `ButtonSpinner`；带验证的数值输入使用 `NumericUpDown`。

**Q: Can I customize the repeat button icons? / 可以自定义重复按钮的图标吗？**

A: Yes. Override the `ButtonSpinner` control template and replace the `Content` of `PART_IncreaseButton` and `PART_DecreaseButton` with custom `PathIcon` or text. The default template uses "+" and "−" characters. Alternatively, use the `Theme` attached property on `ButtonSpinner` to select a Semi.Avalonia variant that renders different glyphs.

可以。重写 `ButtonSpinner` 控件模板，将 `PART_IncreaseButton` 和 `PART_DecreaseButton` 的 `Content` 替换为自定义的 `PathIcon` 或文本。默认模板使用 "+" 和 "−" 字符。或者，在 `ButtonSpinner` 上使用 `Theme` 附加属性选择渲染不同字形的 Semi.Avalonia 变体。

**Q: Does ButtonSpinner support keyboard arrow keys? / ButtonSpinner 支持键盘方向键吗？**

A: The base `ButtonSpinner` does not natively handle keyboard input. `NumericUpDown` adds Up/Down arrow key handling in its `OnKeyDown` override. If you need keyboard support in a custom `ButtonSpinner`, handle `KeyDown` on the content element or the spinner itself, and programmatically invoke the spin logic.

基础的 `ButtonSpinner` 本身不处理键盘输入。`NumericUpDown` 在其 `OnKeyDown` 重写中添加了上下方向键处理。如果自定义 `ButtonSpinner` 需要键盘支持，请在内容元素或微调控件本身上处理 `KeyDown` 事件，并通过代码调用微调逻辑。
