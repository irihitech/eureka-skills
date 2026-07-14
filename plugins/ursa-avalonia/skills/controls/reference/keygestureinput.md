---
category: Components
title: KeyGestureInput
subtitle: 快捷键输入
description: >
  A keyboard gesture capture control that records a key combination (with
  optional modifiers) when the user presses a key while focused. Supports
  filtering acceptable keys, ignoring modifiers, inner left/right content
  slots, and a clear button. Implements IClearControl for programmatic reset.
  一个键盘手势捕获控件，在聚焦时记录用户按键组合（含可选修饰键）。支持过滤
  可接受的按键、忽略修饰键、内部左/右内容插槽和清除按钮。实现 IClearControl
  以便编程重置。
---

# KeyGestureInput / 快捷键输入

## When to Use / 何时使用

Use `KeyGestureInput` when you need the user to define a keyboard shortcut — for
example in a settings page where users can customize hotkeys. The control
captures the next key press (with modifiers like Ctrl, Alt, Shift, Meta) and
stores it as a `KeyGesture`.

使用 `KeyGestureInput` 当您需要用户定义键盘快捷键时——例如在用户可自定义热键的
设置页面中。该控件捕获下一次按键（含 Ctrl、Alt、Shift、Meta 等修饰键）并将其
存储为 `KeyGesture`。

`KeyGestureInput` extends `TemplatedControl` and implements `IClearControl` and
`IInnerContentControl` for rich inner content support.

`KeyGestureInput` 继承自 `TemplatedControl`，并实现 `IClearControl` 和
`IInnerContentControl` 以支持丰富的内部内容。

## Basic Usage / 基本使用

### Capture Any Key / 捕获任意键

```xml
xmlns:u="https://irihi.tech/ursa"

<u:KeyGestureInput HorizontalAlignment="Left" />
```

Click to focus, then press any key combination. The captured `KeyGesture` is
displayed as text (e.g., "Ctrl+A").

点击聚焦，然后按下任意键组合。捕获的 `KeyGesture` 会显示为文字（如 "Ctrl+A"）。

### Read the Captured Gesture / 读取捕获的手势

```xml
<u:KeyGestureInput Name="gestureInput" Gesture="{Binding MyGesture}" />
```

```csharp
// In code-behind
KeyGesture? gesture = gestureInput.Gesture;
// gesture.Key = Key.A, gesture.KeyModifiers = KeyModifiers.Control
```

## Common Scenarios / 常用场景

### 1. Filter Acceptable Keys / 过滤可接受的键

```xml
<u:KeyGestureInput
    Width="300"
    AcceptableKeys="{Binding AcceptableKeys}"
    HorizontalAlignment="Left" />
```

```csharp
// ViewModel
public IList<Key> AcceptableKeys { get; } = new List<Key>
{
    Key.A, Key.B, Key.C, Key.D, Key.E, Key.F
};
```

When `AcceptableKeys` is set, only those keys are captured. Other key presses
are ignored.

当设置 `AcceptableKeys` 时，只有这些键会被捕获。其他按键将被忽略。

### 2. Ignore Modifiers / 忽略修饰键

```xml
<u:KeyGestureInput ConsiderKeyModifiers="False" />
```

When `ConsiderKeyModifiers="False"`, the control ignores Ctrl, Alt, Shift, and
Meta keys entirely. Only the base key is recorded.

当 `ConsiderKeyModifiers="False"` 时，控件完全忽略 Ctrl、Alt、Shift 和 Meta
键。仅记录基础键。

### 3. Inner Content Slots / 内部内容插槽

```xml
<u:KeyGestureInput
    InnerLeftContent="Attack"
    InnerRightContent="Default"
    Classes="ClearButton" />
```

`InnerLeftContent` and `InnerRightContent` place labels on either side of the
gesture display. The `ClearButton` style class shows a clear button on hover
when a gesture is set.

`InnerLeftContent` 和 `InnerRightContent` 在手势显示的两侧放置标签。
`ClearButton` 样式类在悬停时当已设置手势时显示清除按钮。

### 4. Clear the Gesture / 清除手势

```xml
<u:KeyGestureInput
    Width="300"
    HorizontalAlignment="Left"
    AcceptableKeys="{Binding AcceptableKeys}"
    Classes="ClearButton"
    InnerLeftContent="Attack"
    InnerRightContent="Default" />
```

When the `ClearButton` style class is active and a gesture is set, a clear (×)
button appears on the right. Clicking it calls `Clear()`, resetting `Gesture` to
`null`.

当 `ClearButton` 样式类处于活动状态且已设置手势时，右侧会出现清除 (×) 按钮。
点击它会调用 `Clear()`，将 `Gesture` 重置为 `null`。

### 5. Content Alignment / 内容对齐

```xml
<u:KeyGestureInput HorizontalAlignment="Stretch" HorizontalContentAlignment="Left" />
```

## Property Reference / 属性参考

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Gesture` | `KeyGesture?` | `null` | The captured key gesture. / 捕获的键盘手势。 |
| `AcceptableKeys` | `IList<Key>?` | `null` | If set, only these keys are captured. Null = all keys. / 如果设置，仅捕获这些键。null = 所有键。 |
| `ConsiderKeyModifiers` | `bool` | `true` | When false, modifier keys (Ctrl/Alt/Shift/Meta) are ignored; only base key matters. / 为 false 时忽略修饰键（Ctrl/Alt/Shift/Meta）；仅基础键有效。 |
| `HorizontalContentAlignment` | `HorizontalAlignment` | `Center` | Horizontal alignment of the gesture text. / 手势文字的水平对齐。 |
| `VerticalContentAlignment` | `VerticalAlignment` | `Center` | Vertical alignment of the gesture text. / 手势文字的垂直对齐。 |
| `InnerLeftContent` | `object?` | `null` | Content displayed to the left of the gesture text. / 显示在手势文字左侧的内容。 |
| `InnerRightContent` | `object?` | `null` | Content displayed to the right of the gesture text. / 显示在手势文字右侧的内容。 |

### Methods / 方法

| Method | Description / 说明 |
|---|---|
| `Clear()` | Resets `Gesture` to `null`. / 将 `Gesture` 重置为 `null`。 |

## Events / 事件

No custom routed events. Inherits standard `TemplatedControl` events. The
`Gesture` property uses two-way binding. Key capture is handled in `OnKeyDown`
override (the event is marked `e.Handled = true` to prevent bubbling).

无自定义路由事件。继承标准 `TemplatedControl` 事件。`Gesture` 属性使用双向绑定。
按键捕获在 `OnKeyDown` 覆写中处理（事件标记为 `e.Handled = true` 以防止冒泡）。

## Styling & Templating / 样式与模板

### ControlTheme Key

| Theme Key | Target Type | Description / 说明 |
|---|---|---|
| `{x:Type u:KeyGestureInput}` | `KeyGestureInput` | Main theme. Renders a `Border` with gesture text, inner content slots, and optional clear button. / 主主题。渲染带手势文字、内部内容插槽和可选清除按钮的 `Border`。 |

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_ClearButton` | `KeyGestureInput` | `Button` |

### Pseudo-classes / 伪类

| Pseudo-class | Description / 说明 |
|---|---|
| `:empty` | Set when `Gesture` is `null` (no gesture captured). / 当 `Gesture` 为 `null`（未捕获手势）时设置。 |
| `:focus` | Focus state border change. / 焦点状态边框变化。 |
| `:focus-within` | Focus-within state. / 聚焦内部状态。 |
| `:pointerover` | Hover state background change. / 悬停状态背景变化。 |
| `:pressed` | Pressed state background change. / 按下状态背景变化。 |

### Theme Style Classes / 主题样式类

| Class | Description / 说明 |
|---|---|
| `ClearButton` or `clearButton` | When combined with `:not(:empty):focus` or `:not(:empty):pointerover`, shows the `PART_ClearButton`. / 与 `:not(:empty):focus` 或 `:not(:empty):pointerover` 组合时，显示 `PART_ClearButton`。 |

### Theme Resources

Uses standard `TextBox*` theme resources for background, border, focus, and
hover states. The gesture text is displayed via a `PlatformKeyGestureConverter`.

使用标准 `TextBox*` 主题资源作为背景、边框、焦点和悬停状态。手势文字通过
`PlatformKeyGestureConverter` 显示。

## FAQ / 常见问题

**Q: How do I capture a gesture without modifiers? / 如何捕获无修饰键的手势？**
A: By default, modifier keys are included. Press just a letter key (A, B, etc.)
and the gesture will be recorded as that key alone — modifiers are only added
when actually held. Set `ConsiderKeyModifiers="False"` to actively strip them.

**Q: What happens when I press a disallowed key? / 按下不允许的键时会发生什么？**
A: If `AcceptableKeys` is set and the pressed key is not in the list, the
keypress is ignored — nothing is captured.

**Q: How do I clear the current gesture? / 如何清除当前手势？**
A: Call `Clear()` programmatically, or use the `ClearButton` style class to let
the user click an (×) button when hovering over the focused control.

**Q: Can I display the gesture as a platform-specific string? / 可以以平台特定字符串显示手势吗？**
A: Yes, the theme uses `PlatformKeyGestureConverter` which formats `KeyGesture`
into platform-appropriate text (e.g., "Ctrl+C" on Windows, "⌘C" on macOS).

**Q: Does the control support multi-key sequences? / 控件支持多键序列吗？**
A: No. `KeyGestureInput` captures a single key combination (one key plus
modifiers). For multi-key sequences, you would need a custom control.
