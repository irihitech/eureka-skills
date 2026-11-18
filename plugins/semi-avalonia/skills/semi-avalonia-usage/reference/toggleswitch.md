---
category: Components
title: ToggleSwitch
subtitle: 开关
description: 开关用于在开启和关闭状态之间即时切换。
---

# ToggleSwitch / 开关

A switch control that toggles between on and off states with an immediate visual transition. It represents an **action** that takes effect instantly rather than a **state** that needs confirmation. Inherits from `ToggleButton`. Use for settings where the change should be applied immediately — dark mode, Wi-Fi, notifications.

在开启和关闭状态之间切换的开关控件，具有即时的视觉过渡效果。它表示一个立即生效的**操作**，而非需要确认的**状态**。继承自 `ToggleButton`。用于更改应立即生效的设置场景 —— 深色模式、Wi-Fi、通知等。

## When to Use / 何时使用

Use `ToggleSwitch` for binary settings that take effect immediately — the user expects the change to happen the moment they flip the switch. Common in settings panels, toolbars, and control centers. For settings that are part of a form and require explicit submission (e.g., "I agree to terms"), use `CheckBox`. For mutually exclusive selection from a group, use `RadioButton`.

使用 `ToggleSwitch` 处理立即生效的二元设置 —— 用户期望在拨动开关的瞬间更改即生效。常见于设置面板、工具栏和控制中心。对于作为表单一部分且需要明确提交的设置（如"我同意条款"），请使用 `CheckBox`。对于从组中进行互斥选择，请使用 `RadioButton`。

## Basic Usage / 基本使用

```xml
<ToggleSwitch Content="Dark Mode"
              IsChecked="{Binding IsDarkMode}"
              OffContent="Light"
              OnContent="Dark" />
```

```csharp
// React to toggle
myToggle.IsCheckedChanged += (s, e) =>
{
    bool isOn = myToggle.IsChecked == true;
    ApplyTheme(isOn ? ThemeVariant.Dark : ThemeVariant.Light);
};
```

```csharp
// Programmatic creation
var toggle = new ToggleSwitch
{
    Content = "Wi-Fi",
    OnContent = "On",
    OffContent = "Off",
    IsChecked = true
};
```

## Common Scenarios / 常用场景

### Settings Panel / 设置面板

ToggleSwitch is the primary control for settings panels where each item is an independent on/off switch.

```xml
<StackPanel Spacing="12">
    <ToggleSwitch Content="Notifications"
                  IsChecked="{Binding NotificationsEnabled}" />
    <ToggleSwitch Content="Auto-update"
                  IsChecked="{Binding AutoUpdateEnabled}" />
    <ToggleSwitch Content="Analytics"
                  IsChecked="{Binding AnalyticsEnabled}" />
</StackPanel>
```

### Custom On/Off Content / 自定义开关内容

Use `OnContent` and `OffContent` to display descriptive text for each state. These properties are separate from `Content` (the label).

```xml
<ToggleSwitch Content="Airplane Mode"
              OnContent="On"
              OffContent="Off" />
```

### Disabled State / 禁用状态

ToggleSwitch supports the inherited `IsEnabled` property for non-interactive display.

```xml
<ToggleSwitch Content="VPN"
              IsEnabled="False"
              IsChecked="True" />
```

### Command Binding / 命令绑定

Bind `Command` to execute logic when the toggle state changes, supporting MVVM patterns.

```xml
<ToggleSwitch Content="Enable Feature"
              Command="{Binding ToggleFeatureCommand}"
              CommandParameter="{Binding RelativeSource={RelativeSource Self}, Path=IsChecked}" />
```

## Property Reference / 属性参考

ToggleSwitch inherits all properties from `ToggleButton`. Key properties:

ToggleSwitch 继承 `ToggleButton` 的所有属性。关键属性：

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `IsChecked` | `bool?` | Current toggle state: `true` = on, `false` = off. / 当前开关状态：`true` = 开，`false` = 关。 |
| `OnContent` | `object?` | Content displayed when the switch is in the on (checked) state. Typically "On" or an icon. / 开关处于开启（选中）状态时显示的内容。通常为 "On" 或图标。 |
| `OffContent` | `object?` | Content displayed when the switch is in the off (unchecked) state. Typically "Off" or an icon. / 开关处于关闭（未选中）状态时显示的内容。通常为 "Off" 或图标。 |
| `Content` | `object` | Label text displayed beside the switch. Inherited from `ContentControl`. / 开关旁边显示的标签文本。继承自 `ContentControl`。 |
| `Command` | `ICommand?` | Command invoked when the toggle state changes. / 开关状态改变时调用的命令。 |
| `CommandParameter` | `object?` | Parameter passed to the command. / 传递给命令的参数。 |
| `IsThreeState` | `bool` | Inherited from `ToggleButton`. Rarely used for ToggleSwitch (prefer two-state). / 继承自 `ToggleButton`。很少用于 ToggleSwitch（推荐使用两态）。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `IsCheckedChanged` | Raised when `IsChecked` changes. / `IsChecked` 改变时触发。 |
| `Checked` | Raised when the switch is turned on (`IsChecked` → `true`). / 开关打开时触发（`IsChecked` → `true`）。 |
| `Unchecked` | Raised when the switch is turned off (`IsChecked` → `false`). / 开关关闭时触发（`IsChecked` → `false`）。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: When should I use ToggleSwitch vs. CheckBox? / 何时使用 ToggleSwitch 而非 CheckBox？**

A: Use `ToggleSwitch` for settings that take effect **immediately** — the user expects an instant response (e.g., toggling dark mode, Wi-Fi, Bluetooth). Use `CheckBox` for settings that are part of a **form** and may need explicit submission (e.g., "I agree to terms", "Subscribe to newsletter"). Mentally, ToggleSwitch = action (instant), CheckBox = state (confirmable).

`ToggleSwitch` 用于**立即**生效的设置 —— 用户期望即时响应（如切换深色模式、Wi-Fi、蓝牙）。`CheckBox` 用于作为**表单**一部分且可能需要明确提交的设置（如"我同意条款"、"订阅新闻通讯"）。记住：ToggleSwitch = 操作（即时），CheckBox = 状态（可确认）。

**Q: Can I customize the On/Off labels? / 我可以自定义开/关标签吗？**

A: Yes, set `OnContent` and `OffContent` to any `object` — strings, icons, or even small layouts. These are rendered inside the track area by `PART_OnContentPresenter` and `PART_OffContentPresenter`. The `Content` property is separate and renders as a label beside the switch via `PART_ContentPresenter`.

是的，将 `OnContent` 和 `OffContent` 设置为任何 `object` —— 字符串、图标甚至小型布局。它们由 `PART_OnContentPresenter` 和 `PART_OffContentPresenter` 在滑轨区域内渲染。`Content` 属性是独立的，通过 `PART_ContentPresenter` 在开关旁边渲染为标签。

**Q: Why doesn't my ToggleSwitch animate smoothly? / 为什么我的 ToggleSwitch 动画不平滑？**

A: Semi.Avalonia ToggleSwitch animates the knob via `RenderTransform` animations in its ControlTheme. If animations are not playing, check that: (1) the ControlTheme you apply defines the expected `Transitions` or visual-state animations; (2) the knob element has a `RenderTransform` set; (3) you haven't overridden the default ControlTheme without including animations.

A: Semi.Avalonia 的 ToggleSwitch 通过其 ControlTheme 中的 `RenderTransform` 动画驱动滑块。如果动画未播放，请检查：(1) 应用的 ControlTheme 是否定义了所需的 `Transitions` 或视觉状态动画；(2) 滑块元素是否设置了 `RenderTransform`；(3) 是否覆盖了默认 ControlTheme 但未包含动画。