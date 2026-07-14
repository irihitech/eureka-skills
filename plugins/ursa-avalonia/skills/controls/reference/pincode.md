---
category: Components
title: PinCode
subtitle: 密码输入
description: 用于输入固定位数密码的控件。
---

# PinCode / 密码输入

A control for entering a fixed-length numeric PIN or passcode. Displays each digit in a separate box with masked input. Supports validation and auto-submission when complete.

用于输入固定位数数字 PIN 或密码的控件。每个数字显示在独立框中，输入已掩码。支持验证和输入完成自动提交。

## When to Use / 何时使用

Use `PinCode` for authentication screens, 2FA code entry, or any scenario requiring fixed-length numeric input with visual digit separation. For general text passwords, use a `TextBox` with `PasswordChar`.

使用 `PinCode` 处理身份验证界面、二次验证码输入或任何需要固定位数数字输入且各数字视觉分离的场景。一般文本密码使用带 `PasswordChar` 的 `TextBox`。

## Basic Usage / 基本使用

```xml
<ursa:PinCode Length="6"
              Completed="{Binding OnPinCompletedCommand}"
              PasswordChar="*" />
```

## Common Scenarios / 常用场景

### PIN Verification / 密码验证

```xml
<StackPanel Spacing="8">
    <TextBlock Text="Enter your 4-digit PIN" />
    <ursa:PinCode Length="4"
                  PasswordChar="●"
                  Completed="OnPinEntered" />
</StackPanel>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Length` | `int` | Number of digits (default 6). / 位数（默认 6）。 |
| `PasswordChar` | `char` | Character used to mask input (default '*'). / 掩码字符（默认 '*'）。 |
| `Value` | `string` | The current PIN value. / 当前的 PIN 值。 |
| `IsReadOnly` | `bool` | Disable input. / 禁用输入。 |
| `IsError` | `bool` | Show error state (e.g., red border). / 显示错误状态（如红色边框）。 |

## Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Completed` | Raised when all digits are entered. / 输入所有数字时触发。 |

## Styling & Templating / 样式与模板

Theme resources: `PinCodeBackground`, `PinCodeBorderBrush`, `PinCodeForeground`, `PinCodeErrorBorderBrush`, `PinCodeBoxCornerRadius`.

## FAQ / 常见问题

**Q: How do I auto-focus the PinCode? / 如何自动聚焦 PinCode？**

A: Set `Focusable="True"` and call `Focus()` in the `Loaded` event or attach behavior to auto-focus on page load.

设置 `Focusable="True"` 并在 `Loaded` 事件中调用 `Focus()` 或附加页面加载自动聚焦行为。
