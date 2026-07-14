---
category: Components
title: Button
subtitle: 按钮
description: 按钮用于开始一个即时操作。
---

## Button / 按钮

A standard button control that responds to user click, tap, or keyboard interactions to trigger an immediate action. Inherits from `ContentControl` and implements `ICommandSource` and `IClickableControl`.

标准按钮控件，响应用户的点击、触摸或键盘交互以触发即时操作。继承自 `ContentControl`，实现了 `ICommandSource` 和 `IClickableControl`。

## When to Use / 何时使用

Use `Button` when you need a clickable element that triggers a single, immediate action — such as submitting a form, opening a dialog, navigating to another view, or executing a command. `Button` is the primary control for user-initiated actions in dialogs, toolbars, and data-entry forms. For repeated actions while pressed (e.g. spin buttons, media controls), consider `RepeatButton` instead. For toggle-style on/off states, use `ToggleButton`.

当你需要一个可点击元素来触发单次即时操作时使用 `Button` —— 例如提交表单、打开对话框、导航到另一个视图或执行命令。`Button` 是对话框、工具栏和数据录入表单中用户发起操作的主要控件。对于按住时需要重复触发的操作（如微调按钮、媒体控件），请考虑使用 `RepeatButton`。对于开关式的开/关状态，请使用 `ToggleButton`。

## Basic Usage / 基本使用

```xml
<Button Content="Click Me"
        Click="OnButtonClick" />
```

```csharp
// Code-behind
private void OnButtonClick(object? sender, RoutedEventArgs e)
{
    // Handle the click
}
```

```csharp
// Programmatic creation
var button = new Button
{
    Content = "Click Me"
};
button.Click += (s, e) => { /* handle click */ };
```

## Common Scenarios / 常用场景

### Command Binding / 命令绑定

Bind `Button` to an `ICommand` in your ViewModel for MVVM patterns. `CanExecute` automatically controls `IsEnabled`.

```xml
<Button Content="Save"
        Command="{Binding SaveCommand}"
        CommandParameter="{Binding SelectedItem}" />
```

```csharp
public ICommand SaveCommand { get; }

public MyViewModel()
{
    SaveCommand = new RelayCommand<object>(OnSave, CanSave);
}

private bool CanSave(object? parameter) => /* validation */;
private void OnSave(object? parameter) { /* save logic */ }
```

### IsDefault & IsCancel / 默认按钮与取消按钮

Set `IsDefault` to respond to Enter key; `IsCancel` to respond to Escape key. Commonly used in dialogs with OK/Cancel patterns.

```xml
<StackPanel Spacing="8">
    <TextBox Watermark="Enter your name" />
    <StackPanel Orientation="Horizontal" HorizontalAlignment="Right" Spacing="8">
        <Button Content="OK"
                IsDefault="True"
                Command="{Binding OkCommand}" />
        <Button Content="Cancel"
                IsCancel="True"
                Command="{Binding CancelCommand}" />
    </StackPanel>
</StackPanel>
```

### Button with Flyout / 带浮层的按钮

Attach a `Flyout` to show contextual menus or additional options. Supports `:flyout-open` pseudo-class for styling.

```xml
<Button Content="Options">
    <Button.Flyout>
        <MenuFlyout>
            <MenuItem Header="Save" Command="{Binding SaveCommand}" />
            <MenuItem Header="Save As..." Command="{Binding SaveAsCommand}" />
            <Separator />
            <MenuItem Header="Close" Command="{Binding CloseCommand}" />
        </MenuFlyout>
    </Button.Flyout>
</Button>
```

### Keyboard Shortcut / 键盘快捷键

Use `HotKey` to assign a keyboard gesture that activates the button without focus.

```xml
<Button Content="Save (Ctrl+S)"
        HotKey="Ctrl+S"
        Command="{Binding SaveCommand}" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Content` | `object` | The content displayed inside the button. Supports text, controls, or layouts. Inherited from `ContentControl`. / 按钮内显示的内容。支持文本、控件或布局。继承自 `ContentControl`。 |
| `Command` | `ICommand?` | The command to invoke when the button is clicked. Supports `CanExecute` for automatic enabled/disabled state. / 点击按钮时调用的命令。支持 `CanExecute` 实现自动启用/禁用。 |
| `CommandParameter` | `object?` | Parameter passed to the command when invoked. / 调用命令时传递的参数。 |
| `ClickMode` | `ClickMode` | When the `Click` event fires: `Release` (default) or `Press`. / `Click` 事件触发时机：`Release`（默认）或 `Press`。 |
| `IsDefault` | `bool` | When `true`, the button responds to the Enter key. Only one per scope. / 设为 `true` 时按钮响应 Enter 键。每个范围内仅应设一个。 |
| `IsCancel` | `bool` | When `true`, the button responds to the Escape key. Only one per scope. / 设为 `true` 时按钮响应 Escape 键。每个范围内仅应设一个。 |
| `IsPressed` | `bool` | (Read-only) Whether the button is currently in a pressed state. Toggles the `:pressed` pseudo-class. / （只读）按钮当前是否处于按下状态。控制 `:pressed` 伪类。 |
| `HotKey` | `KeyGesture?` | A keyboard shortcut that activates the button without requiring focus. / 无需焦点即可激活按钮的键盘快捷键。 |
| `Flyout` | `FlyoutBase?` | A flyout attached to the button. Toggles the `:flyout-open` pseudo-class when opened. / 附加到按钮的浮层。打开时触发 `:flyout-open` 伪类。 |
| `IsEnabled` | `bool` | Whether the button can respond to interaction. Inherited from `InputElement`. / 按钮是否可以响应交互。继承自 `InputElement`。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Click` | Raised when the button is clicked, respecting `ClickMode`. / 按钮被点击时触发，遵循 `ClickMode` 设置。 |
| `IsPressedChanged` | Raised when the pressed state changes. / 按下状态改变时触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides a rich styling system for `Button` with four themes, six color classes, two size classes, and an AI-friendly `Colorful` variant. All themes use nested `Style` selectors targeting `ContentPresenter#PART_ContentPresenter`.

Semi.Avalonia 为 `Button` 提供了丰富的样式系统，包含四种主题、六种颜色类、两种尺寸类以及 AI 友好的 `Colorful` 变体。所有主题均使用嵌套 `Style` 选择器来定位 `ContentPresenter#PART_ContentPresenter`。

### Theme Variants / 主题变体

Choose a theme via the `Theme` attached property. The default theme (Light) requires no explicit `Theme` assignment.

通过 `Theme` 附加属性选择主题。默认主题（Light）无需显式指定。

| Theme / 主题 | Resource Key / 资源键 | Appearance / 外观 |
| --- | --- | --- |
| **Light** (default) | `{x:Type Button}` | Subtle background, visible on hover. / 微妙背景，悬停时可见。 |
| **Solid** | `SolidButton` | Fully filled background, prominent. / 完全填充背景，突出显示。 |
| **Outline** | `OutlineButton` | Transparent background with colored border. / 透明背景配彩色边框。 |
| **Borderless** | `BorderlessButton` | No border or background; minimal appearance. / 无边框无背景，极简外观。 |

```xml
<!-- Default Light theme: no Theme needed -->
<Button Content="Light" />

<!-- Explicit theme variants -->
<Button Content="Solid" Theme="{DynamicResource SolidButton}" />
<Button Content="Outline" Theme="{DynamicResource OutlineButton}" />
<Button Content="Borderless" Theme="{DynamicResource BorderlessButton}" />
```

### Color Classes / 颜色类

Apply via the `Classes` attached property. Defaults to `Primary` when no color class is specified.

通过 `Classes` 附加属性应用。未指定颜色类时默认为 `Primary`。

| Class / 类名 | Description / 说明 |
| --- | --- |
| `Primary` | (default) Blue accent. / （默认）蓝色强调。 |
| `Secondary` | Neutral gray tone. / 中性灰色调。 |
| `Tertiary` | Subtle variant, typically used for less important actions. / 微妙变体，通常用于次要操作。 |
| `Success` | Green tone for confirmatory actions. / 绿色调，用于确认性操作。 |
| `Warning` | Amber tone for cautionary actions. / 琥珀色调，用于警示性操作。 |
| `Danger` | Red tone for destructive actions. / 红色调，用于破坏性操作。 |

```xml
<Button Content="Primary" />                        <!-- default -->
<Button Content="Secondary" Classes="Secondary" />
<Button Content="Danger" Classes="Danger" Theme="{DynamicResource SolidButton}" />
```

### Size Classes / 尺寸类

| Class / 类名 | Description / 说明 |
| --- | --- |
| *(default)* | Standard size. / 标准尺寸。 |
| `Large` | Larger button with increased padding and font size. / 大号按钮，增加内边距和字体大小。 |
| `Small` | Compact button for dense UIs. / 紧凑按钮，适用于密集 UI。 |

```xml
<Button Content="Small" Classes="Small" />
<Button Content="Large" Classes="Large" Theme="{DynamicResource SolidButton}" />
```

### Colorful Variant / Colorful 变体

The `Colorful` class applies vibrant, saturated colors ideal for AI-generated interfaces or eye-catching call-to-action buttons. Works with all themes.

`Colorful` 类应用鲜艳饱和的色彩，适用于 AI 生成的界面或引人注目的行动号召按钮。可与所有主题配合使用。

```xml
<Button Content="Buy Now"
        Classes="Colorful Primary"
        Theme="{DynamicResource SolidButton}" />
```

### Pseudo-classes / 伪类

Semi.Avalonia styles the following pseudo-classes on `Button`:

Semi.Avalonia 为 `Button` 设置了以下伪类样式：

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:pointerover` | Mouse is hovering over the button. / 鼠标悬停在按钮上。 |
| `:pressed` | Button is in a pressed state. / 按钮处于按下状态。 |
| `:disabled` | Button is disabled (`IsEnabled = false`). / 按钮已禁用。 |

Additionally, the base Avalonia `Button` supports `:flyout-open`, which is toggled when an attached `Flyout` is open.

此外，Avalonia 基础 `Button` 还支持 `:flyout-open`，当附加的 `Flyout` 打开时触发。

### ControlTheme Structure / 控件主题结构

Each theme (`LightButton`, `SolidButton`, `OutlineButton`, `BorderlessButton`) follows the same internal pattern: nested `Style` selectors combine a color class (e.g. `.Primary`, `.Danger`) with a pseudo-class (`:pointerover`, `:pressed`) to target `ContentPresenter#PART_ContentPresenter` and set `Background`, `BorderBrush`, and `Foreground` from `DynamicResource` brushes.

每个主题（`LightButton`、`SolidButton`、`OutlineButton`、`BorderlessButton`）遵循相同的内部模式：嵌套 `Style` 选择器将颜色类（如 `.Primary`、`.Danger`）与伪类（`:pointerover`、`:pressed`）组合，定位 `ContentPresenter#PART_ContentPresenter`，并通过 `DynamicResource` 笔刷设置 `Background`、`BorderBrush` 和 `Foreground`。

### DynamicResource Keys / 动态资源键

Resource keys follow the naming convention `Button{Theme}{Color}{State}{Property}`:

资源键遵循命名约定 `Button{主题}{颜色}{状态}{属性}`：

```
ButtonSolidPrimaryBackground
ButtonSolidPrimaryPointeroverBackground
ButtonSolidPrimaryPressedBackground
ButtonSolidPrimaryBorderBrush
ButtonOutlineDangerBackground
ButtonBorderlessSecondaryForeground
...
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the `Content` property. All Semi.Avalonia button styles target this part for background, border, and foreground. / 渲染 `Content` 属性。所有 Semi.Avalonia 按钮样式均通过此部件设置背景、边框和前景色。 |

### Specialized Button Themes / 专用按钮主题

Semi.Avalonia also provides special-purpose button themes for input adornments and icon buttons:

Semi.Avalonia 还提供了用于输入装饰和图标按钮的专用按钮主题：

| Theme Key / 主题键 | Usage / 用途 |
| --- | --- |
| `InnerButton` | Small button nested inside input controls (e.g. password reveal, clear). / 嵌套在输入控件内部的小按钮（如密码显示/隐藏、清除）。 |
| `InnerInputButton` | Button inside input fields with input-specific styling. / 输入字段内的按钮，具有输入特定的样式。 |
| `InnerIconButton` | Icon-only button that renders a `PathIcon` from `Content` data. / 仅图标按钮，通过 `Content` 数据渲染 `PathIcon`。 |

## FAQ / 常见问题

**Q: When should I use Button vs. RepeatButton? / 何时使用 Button 而非 RepeatButton？**

A: Use `Button` for single-click actions (submit, navigate, open dialog). Use `RepeatButton` when you need repeated triggers while held down — scroll buttons, spin-box increment/decrement, or media controls. `Button` fires `Click` once per press-release cycle; `RepeatButton` fires `Click` repeatedly at an interval.

`Button` 用于单次点击操作（提交、导航、打开对话框）。`RepeatButton` 用于按住时需要重复触发的情况 —— 如滚动按钮、微调控件增减、媒体控件。`Button` 每次按下-释放循环触发一次 `Click`，`RepeatButton` 则以固定间隔重复触发。

**Q: How do Semi.Avalonia themes differ from stock Avalonia styles? / Semi.Avalonia 主题与标准 Avalonia 样式有何不同？**

A: Semi.Avalonia uses `Theme="{DynamicResource SolidButton}"` rather than `Classes="accent"` to switch visual variants. Color classes (`Primary`, `Secondary`, etc.) are separate from theme selection, giving a 4×6×2 matrix (theme × color × size) of combinations. All colors are resolved from `DynamicResource` brushes, enabling runtime theme switching. Stock Avalonia uses a single `Button` theme with flat pseudo-class selectors and relies on attached `Classes` for variants like `accent`.

Semi.Avalonia 使用 `Theme="{DynamicResource SolidButton}"` 而非 `Classes="accent"` 来切换视觉变体。颜色类（`Primary`、`Secondary` 等）与主题选择分离，形成了 4×6×2（主题 × 颜色 × 尺寸）的组合矩阵。所有颜色通过 `DynamicResource` 笔刷解析，支持运行时主题切换。标准 Avalonia 使用单一 `Button` 主题配合扁平伪类选择器，并依赖附加的 `Classes` 实现 `accent` 等变体。

**Q: Why doesn't ClickMode include a "Hover" option? / 为什么 ClickMode 没有 "Hover" 选项？**

A: Unlike some UI frameworks, Avalonia's `Button.ClickMode` only supports `Release` (default) and `Press`. There is no built-in `Hover` mode. If you need hover-triggered actions without a click, handle the `PointerEntered` / `PointerExited` events or use `:pointerover` pseudo-class in styles instead of relying on the `Click` event.

与某些 UI 框架不同，Avalonia 的 `Button.ClickMode` 仅支持 `Release`（默认）和 `Press`，没有内置的 `Hover` 模式。如需无点击的悬停触发操作，请处理 `PointerEntered` / `PointerExited` 事件，或在样式中使用 `:pointerover` 伪类，而非依赖 `Click` 事件。
