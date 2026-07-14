---
category: Components
title: IPv4Box
subtitle: IPv4 地址输入框
description: 用于输入和显示 IPv4 地址的专用控件，四个分段文本输入框用点分隔，支持普通和快速输入模式及复制粘贴。
---

## IPv4Box / IPv4 地址输入框

A `TemplatedControl` specialized for IPv4 address input. Displays four segmented `TextPresenter` fields separated by dot characters (`.`). Each segment accepts 0–3 digits (validated as 0–255). Supports two input modes (`Normal` and `Fast`), copy/paste/cut/clear context menu, leading-zero display toggle, two-way binding to `System.Net.IPAddress`, and keyboard navigation between segments.

专用于 IPv4 地址输入的 `TemplatedControl`。显示四个分段 `TextPresenter` 字段，以点号（`.`）分隔。每个分段接受 0–3 位数字（验证为 0–255）。支持两种输入模式（`Normal` 和 `Fast`）、复制/粘贴/剪切/清除上下文菜单、前导零显示切换、与 `System.Net.IPAddress` 的双向绑定以及键盘在分段间导航。

## When to Use / 何时使用

Use `IPv4Box` when you need IP address input — for example, network configuration forms, device management UIs, or server settings. It provides a better UX than a plain `TextBox` by enforcing the IPv4 format and segment-focused navigation. For general numeric input, use `NumericUpDown`. For free-form text, use `TextBox`.

当你需要 IP 地址输入时使用 `IPv4Box` —— 例如网络配置表单、设备管理界面或服务器设置。它通过强制 IPv4 格式和分段导航，提供比普通 `TextBox` 更好的用户体验。对于通用数字输入，请使用 `NumericUpDown`。对于自由格式文本，请使用 `TextBox`。

## Basic Usage / 基本使用

```xml
<u:IPv4Box Width="200"
           IPAddress="{Binding ServerAddress}" />
```

```csharp
// Code-behind
var box = new IPv4Box
{
    IPAddress = IPAddress.Parse("192.168.1.1"),
    ShowLeadingZero = true
};
```

## Common Scenarios / 常用场景

### Two-Way Binding / 双向绑定

```xml
<u:IPv4Box Width="200" IPAddress="{Binding Address}" />
<TextBlock Text="{Binding #box.IPAddress}" />
```

### Fast Input Mode / 快速输入模式

In `Fast` mode, typing three digits automatically moves to the next segment:

```xml
<u:IPv4Box Width="200" InputMode="Fast" />
```

| Mode / 模式 | Behavior / 行为 |
| --- | --- |
| `Normal` | User manually navigates (Tab, dot, arrow keys). / 用户手动导航（Tab、点号、方向键）。 |
| `Fast` | After 3 digits, auto-advance to next segment with text selected. / 输入 3 位数字后自动前进到下一个分段并选中文本。 |

### Leading Zero Display / 前导零显示

```xml
<ToggleButton Name="format" Content="Show Leading Zeroes" />

<!-- With leading zeros: 192.168.001.001 -->
<u:IPv4Box Width="200"
           ShowLeadingZero="{Binding #format.IsChecked}" />

<!-- Without: 192.168.1.1 -->
<u:IPv4Box Width="200"
           ShowLeadingZero="False" />
```

### Disabled State / 禁用状态

```xml
<u:IPv4Box Width="200" IsEnabled="False"
           IPAddress="192.168.1.100" />
```

### Random IP from Source / 从数据源随机 IP

```xml
<RepeatButton Command="{Binding ChangeAddress}" Content="Random" />
<u:IPv4Box Width="200"
           IPAddress="{Binding Address}"
           ShowLeadingZero="True" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `IPAddress` | `IPAddress?` | The IPv4 address. Two-way binding. Parsed from / formatted to four byte segments. / IPv4 地址。双向绑定。从四个字节分段解析/格式化。 |
| `ShowLeadingZero` | `bool` | Whether to pad segments with leading zeros (e.g., `001`). Default `true`. / 是否用前导零填充分段（如 `001`）。默认 `true`。 |
| `InputMode` | `IPv4BoxInputMode` | Input behavior: `Normal` or `Fast`. / 输入行为：`Normal` 或 `Fast`。 |
| `TextAlignment` | `TextAlignment` | Text alignment within each segment. Default `Center`. / 每个分段内的文本对齐。默认 `Center`。 |
| `SelectionBrush` | `IBrush?` | Brush for text selection highlight. / 文本选择高亮笔刷。 |
| `SelectionForegroundBrush` | `IBrush?` | Brush for selected text foreground. / 选中文本前景笔刷。 |
| `CaretBrush` | `IBrush?` | Brush for the caret. / 光标笔刷。 |

### IPv4BoxInputMode Enum / IPv4BoxInputMode 枚举

| Value / 值 | Description / 说明 |
| --- | --- |
| `Normal` | Standard input. Navigation via Tab, dot, or arrow keys. / 标准输入。通过 Tab、点号或方向键导航。 |
| `Fast` | After 3 digits, auto-advance to next segment with all text selected. / 输入 3 位数字后自动前进至下一个分段并全选文本。 |

### Keyboard Navigation / 键盘导航

| Key / 按键 | Action / 动作 |
| --- | --- |
| `Tab` | Move to next segment. / 移动到下一个分段。 |
| `Right Arrow` | Move caret right; at end, move to next segment. / 光标右移；在末尾时移动到下一个分段。 |
| `Left Arrow` | Move caret left; at start, move to previous segment. / 光标左移；在开头时移动到上一个分段。 |
| `Backspace` | Delete character; if segment empty, move to previous segment. / 删除字符；分段为空时移动到上一个分段。 |
| `Delete` | Delete character or move to next segment. / 删除字符或移动到下一个分段。 |
| `Enter` | Commit: parse bytes and update `IPAddress`. / 提交：解析字节并更新 `IPAddress`。 |
| `.` (period) | Move to next segment without selecting. / 移动到下一个分段而不选中。 |
| `Ctrl+A` | Select all text in current segment. / 全选当前分段文本。 |
| `Ctrl+C` | Copy current segment text or full IP. / 复制当前分段文本或完整 IP。 |
| `Ctrl+V` | Paste into current segment (parsed as byte 0–255). / 粘贴到当前分段（解析为 0–255 字节）。 |
| `Ctrl+X` | Cut current segment text. / 剪切当前分段文本。 |

### Context Menu / 上下文菜单

The built-in `IPv4BoxMenuFlyout` provides Cut, Copy, Paste, and Clear commands with standard keyboard shortcuts.

## Styling & Templating / 样式与模板

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_FirstTextPresenter` | `TextPresenter` | First octet (0–255). / 第一个字节（0–255）。 |
| `PART_SecondTextPresenter` | `TextPresenter` | Second octet. / 第二个字节。 |
| `PART_ThirdTextPresenter` | `TextPresenter` | Third octet. / 第三个字节。 |
| `PART_FourthTextPresenter` | `TextPresenter` | Fourth octet. / 第四个字节。 |
| `PART_Border` | `Border` | Root border element for state styling. / 用于状态样式的根边框元素。 |

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:pointerover` | Mouse hover over the control. / 鼠标悬停在控件上。 |
| `:pressed` | Control is pressed. / 控件被按下。 |
| `:focus-within` | Any segment has focus. / 任意分段获得焦点。 |
| `:disabled` | Control is disabled (`IsEnabled = false`). / 控件已禁用。 |

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `TextBoxDefaultBackground` | Default background. / 默认背景。 |
| `TextBoxDefaultBorderBrush` | Default border brush. / 默认边框笔刷。 |
| `TextBoxDefaultCornerRadius` | Corner radius. / 圆角半径。 |
| `TextBoxDefaultHeight` | Default minimum height. / 默认最小高度。 |
| `TextBoxBorderThickness` | Border thickness. / 边框粗细。 |
| `TextBoxSelectionBackground` | Selection highlight brush. / 选择高亮笔刷。 |
| `TextBoxSelectionForeground` | Selected text foreground brush. / 选中文本前景笔刷。 |
| `TextBoxTextCaretBrush` | Caret brush. / 光标笔刷。 |
| `TextBoxPointeroverBackground` | Background on hover. / 悬停时背景。 |
| `TextBoxPointeroverBorderBrush` | Border brush on hover. / 悬停时边框笔刷。 |
| `TextBoxFocusBorderBrush` | Border brush when focused. / 聚焦时边框笔刷。 |
| `TextBoxDisabledBackground` / `TextBoxDisabledForeground` / `TextBoxDisabledBorderBrush` | Disabled state styling. / 禁用状态样式。 |
| `IPv4BoxPressedBackground` | Background when pressed. / 按下时背景。 |
| `IPv4BoxMenuFlyout` | The context menu flyout resource. / 上下文菜单弹出资源。 |

## FAQ / 常见问题

**Q: What happens when I type more than 3 digits? / 输入超过 3 位数字会发生什么？**

A: Each segment is capped at 3 characters. In `Fast` mode, typing the third digit auto-advances to the next segment. In `Normal` mode, further input is rejected once the segment has 3 characters. / 每个分段限制为 3 个字符。在 `Fast` 模式下，输入第三位数字会自动前进到下一个分段。在 `Normal` 模式下，分段达到 3 个字符后拒绝进一步输入。

**Q: How are invalid octet values handled? / 无效的字节值如何处理？**

A: On focus loss or Enter, each segment is parsed as a `byte` (0–255). If parsing fails, the default value `0` is used. The `IPAddress` property is then updated to reflect the parsed bytes. / 失去焦点或按 Enter 时，每个分段被解析为 `byte`（0–255）。如果解析失败，使用默认值 `0`。然后更新 `IPAddress` 属性以反映解析后的字节。

**Q: Can IPv4Box be used with a NumPad? / IPv4Box 可以与数字小键盘一起使用吗？**

A: Yes. The `IsTargetByNumPad` internal property tracks whether input comes from a numeric keypad, preventing premature focus loss. / 可以。`IsTargetByNumPad` 内部属性跟踪输入是否来自数字小键盘，防止过早失去焦点。

**Q: How does copy/paste work with IPv4Box? / IPv4Box 的复制粘贴如何工作？**

A: The context menu provides `Cut`, `Copy`, `Paste`, and `Clear` commands that operate on the current active segment. Copy copies the current segment's text. Paste attempts to parse the clipboard text as byte(s) and distributes across segments. The full clipboard API is also supported via `Ctrl+C`/`Ctrl+V` keyboard shortcuts. / 上下文菜单提供在当前活动分段上操作的 `Cut`、`Copy`、`Paste` 和 `Clear` 命令。复制会复制当前分段的文本。粘贴尝试将剪贴板文本解析为字节并分布到各个分段。还通过 `Ctrl+C`/`Ctrl+V` 键盘快捷键支持完整的剪贴板 API。
