---
category: Input
title: NumPad
subtitle: 数字键盘
description: >
  On-screen numeric keypad with dual Num/Function modes. Attaches to input
  controls via an attached property and opens as an overlay popup. Supports
  direct key injection into TextBox, NumericUpDown, and IPv4Box targets.
  屏幕数字键盘，具有数字/功能双模式。通过附加属性附加到输入控件，以浮层弹出窗口
  形式打开。支持将按键直接注入 TextBox、NumericUpDown 和 IPv4Box 等目标控件。
---

# NumPad / 数字键盘

## When to Use / 何时使用

Use `NumPad` for touch-friendly or keyboard-optional numeric input. It appears
as an overlay popup when the attached target gains focus. Ideal for kiosk apps,
tablet input, and scenarios where a physical numpad is unavailable.

使用 `NumPad` 进行触控友好或无需物理键盘的数值输入。当附加的目标获得焦点时，
它以浮层弹出窗口形式出现。适用于自助终端、平板输入和无物理数字键盘的场景。

## Basic Usage / 基本使用

### Attach to a TextBox / 附加到 TextBox

```xml
xmlns:u="https://irihi.tech/ursa"

<TextBox u:NumPad.Attach="True"
         PlaceholderText="Click to open NumPad" />
```

When the TextBox gains focus, the NumPad overlay appears near the input field.

当 TextBox 获得焦点时，NumPad 浮层会出现在输入框附近。

### Attach to NumericUpDown / 附加到 NumericUpDown

```xml
<u:NumericIntUpDown u:NumPad.Attach="True"
                     PlaceholderText="Invoke NumPad" />
```

### Inline NumPad with explicit target / 内联 NumPad 指定目标

```xml
<TextBox Name="text" Width="200" />
<u:NumPad Target="{Binding #text}" />
```

### Attach to IPv4Box / 附加到 IPv4Box

```xml
<u:IPv4Box u:NumPad.Attach="True"
            InputMode="Fast"
            ShowLeadingZero="False" />
```

## Common Scenarios / 常用场景

### 1. Multiple inputs sharing one NumPad / 多输入共享一个 NumPad

```xml
<TextBox u:NumPad.Attach="True" PlaceholderText="Input 1" />
<TextBox u:NumPad.Attach="True" PlaceholderText="Input 2" />
<TextBox u:NumPad.Attach="True" PlaceholderText="Input 3" />
```

Only one NumPad appears — focusing a different input re-targets it.

只显示一个 NumPad——聚焦不同输入框会重新定位它。

### 2. Switch between Num and Function modes / 切换数字和功能模式

The NumPad has a "Num Lock" toggle button in the top-left corner:
- **Num mode** (`NumMode="True"`): digits 0-9, `.`, `+`, `-`, `*`, `/`, Enter
- **Function mode** (`NumMode="False"`): Home, Up, PgUp, Left, Right, End,
  Down, PgDn, Insert, Delete, Back, Enter

NumPad 左上角有"Num Lock"切换按钮：
- **数字模式**：0-9、`.`、`+`、`-`、`*`、`/`、Enter
- **功能模式**：Home、↑、PgUp、←、→、End、↓、PgDn、Insert、Delete、Back、Enter

Programmatically:

```csharp
numPad.NumMode = false; // switch to function mode
```

### 3. Custom positioning / 自定义位置

The NumPad auto-positions near the target input, preferring below and aligning
left. It repositions to avoid overflowing the window bounds.

NumPad 自动定位在目标输入框附近，优先在下方左对齐，并避让窗口边界溢出。

## Property Reference / 属性参考

### NumPad Properties / NumPad 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Target` | `InputElement?` | `null` | The input control receiving keystrokes / 接收按键的输入控件 |
| `NumMode` | `bool` | `true` | `true` = digits mode; `false` = function keys / `true` = 数字模式；`false` = 功能键模式 |

### Attached Properties / 附加属性

| Property | Type | Description / 说明 |
|---|---|---|
| `NumPad.Attach` | `bool` | Set to `true` on an `InputElement` to auto-open NumPad on focus / 设置为 `true` 时，控件获得焦点会自动弹出 NumPad |

### NumPadButton Properties / NumPadButton 属性

| Property | Type | Description / 说明 |
|---|---|---|
| `NumMode` | `bool` | Inherited from parent NumPad / 继承自父级 NumPad |
| `NumKey` | `Key?` | Key sent in Num mode / 数字模式下发送的键 |
| `NumContent` | `object?` | Display content in Num mode / 数字模式下显示的内容 |
| `FunctionKey` | `Key?` | Key sent in Function mode / 功能模式下发送的键 |
| `FunctionContent` | `object?` | Display content in Function mode / 功能模式下显示的内容 |
| `Command` | `ICommand?` | Bound to `NumPad.ProcessClick` / 绑定到 `NumPad.ProcessClick` |

## Events / 事件

No custom routed events. NumPad injects standard `TextInputEvent` and
`KeyDownEvent` into the target element.

无自定义路由事件。NumPad 向目标元素注入标准 `TextInputEvent` 和 `KeyDownEvent`。

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `ButtonDefaultBackground` | `NumPadButton` | Button background / 按钮背景 |

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| (none) | `NumPad` | Template is self-contained / 模板自包含 |
| `PART_Background` | `NumPadButton` | `Border` |

### NumPadButton Styles

`NumPadButton` responds to standard `:pointerover` and `:pressed`
pseudo-classes.

## FAQ / 常见问题

**Q: Can I use NumPad without the attached property? / 能否不用附加属性？**
A: Yes. Instantiate `NumPad` directly and set `Target` to your input control.

```xml
<u:NumPad Target="{Binding #myTextBox}" />
```

**Q: How does NumPad find the inner TextBox? / NumPad 如何找到内部 TextBox？**
A: It searches `GetTemplateDescendants()` and `GetLogicalDescendants()` for the
first `TextBox`, then uses it as the real input target.

**Q: Does NumPad work with custom input controls? / NumPad 支持自定义输入控件吗？**
A: Yes, as long as the control contains a `TextBox` descendant or handles
`TextInputEvent` and `KeyDownEvent` itself.

**Q: How do I dismiss the NumPad overlay? / 如何关闭 NumPad 浮层？**
A: Click outside the overlay or focus another control. On close, focus returns
to the target element.

**Q: Can I keep NumPad always visible? / 能让 NumPad 一直可见吗？**
A: Use the inline mode with `Target` — it renders directly in the visual tree
instead of as an overlay:

```xml
<StackPanel>
    <TextBox Name="text" />
    <u:NumPad Target="{Binding #text}" />
</StackPanel>
```
