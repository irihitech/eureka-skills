---
category: Components
title: TextBox
subtitle: 文本框
description: 文本框用于显示和编辑无格式文本。
---

# TextBox / 文本框

A control for displaying and editing unformatted text. Supports single-line and multi-line input, text selection, clipboard operations, undo/redo, placeholder text, and password masking. Inherits from `TemplatedControl`.

用于显示和编辑无格式文本的控件。支持单行和多行输入、文本选择、剪贴板操作、撤销/重做、占位符文本和密码掩码。继承自 `TemplatedControl`。

## When to Use / 何时使用

Use `TextBox` for free-form text input — form fields, search boxes, code editors, chat inputs, and any scenario where users need to type or paste text. For auto-complete with suggestions, use `AutoCompleteBox`. For formatted/rich text, use `SelectableTextBlock` (read-only) or a third-party editor. For pure numeric input, consider `NumericUpDown`.

使用 `TextBox` 进行自由文本输入 —— 表单字段、搜索框、代码编辑器、聊天输入以及任何需要用户键入或粘贴文本的场景。需要带建议的自动补全时使用 `AutoCompleteBox`。需要格式化/富文本时使用 `SelectableTextBlock`（只读）或第三方编辑器。纯数字输入场景考虑使用 `NumericUpDown`。

## Basic Usage / 基本使用

```xml
<TextBox Watermark="Enter your name"
         Text="{Binding UserName}"
         Width="200" />
```

```csharp
// Read text
string input = myTextBox.Text;

// React to text changes
myTextBox.TextChanged += (s, e) => { /* handle change */ };
```

## Common Scenarios / 常用场景

### Multi-line Input / 多行输入

Enable `AcceptsReturn` and `TextWrapping` for multi-line text areas.

```xml
<TextBox Watermark="Type your message..."
         AcceptsReturn="True"
         TextWrapping="Wrap"
         MinLines="3"
         MaxLines="10"
         Height="120" />
```

### Password Input / 密码输入

Use `PasswordChar` to mask input. Semi.Avalonia provides a built-in reveal button theme.

```xml
<TextBox PasswordChar="●"
         Watermark="Enter password"
         MaxLength="32" />
```

### Data Validation / 数据验证

Bind `Text` with data validation for real-time feedback. Semi.Avalonia integrates with `DataValidationErrors` theming.

```xml
<TextBox Text="{Binding Email, Mode=TwoWay}"
         Watermark="Enter email"
         Classes.error="{Binding Email.HasError}" />
```

### Read-only Display / 只读展示

Set `IsReadOnly` for display-only fields that still support selection and copy.

```xml
<TextBox Text="{Binding GeneratedCode}"
         IsReadOnly="True"
         AcceptsReturn="True"
         TextWrapping="Wrap"
         FontFamily="Cascadia Code" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Text` | `string?` | The current text content. Bind with `Mode=TwoWay` for editable fields. / 当前文本内容。可编辑字段使用 `Mode=TwoWay` 绑定。 |
| `Watermark` | `string?` | Placeholder text shown when `Text` is empty. / `Text` 为空时显示的占位符文本。 |
| `AcceptsReturn` | `bool` | When `true`, pressing Enter inserts a newline instead of moving focus. / 设为 `true` 时，按 Enter 插入换行而非移动焦点。 |
| `AcceptsTab` | `bool` | When `true`, pressing Tab inserts a tab character. / 设为 `true` 时，按 Tab 插入制表符。 |
| `IsReadOnly` | `bool` | Prevents editing but still allows selection and copy. / 阻止编辑但仍允许选择和复制。 |
| `MaxLength` | `int` | Maximum number of characters allowed. / 允许的最大字符数。 |
| `MaxLines` | `int` | Visible line limit for multi-line mode. / 多行模式下的可见行限制。 |
| `MinLines` | `int` | Minimum visible lines for multi-line mode. / 多行模式下的最小可见行数。 |
| `PasswordChar` | `char` | Masking character for password entry (default `\0` = no masking). / 密码输入的掩码字符（默认 `\0` = 无掩码）。 |
| `TextWrapping` | `TextWrapping` | How text wraps: `NoWrap`, `Wrap`, `WrapWithOverflow`. / 文本换行方式：`NoWrap`、`Wrap`、`WrapWithOverflow`。 |
| `TextAlignment` | `TextAlignment` | Horizontal text alignment: `Left`, `Center`, `Right`. / 水平文本对齐：`Left`、`Center`、`Right`。 |
| `SelectionStart` | `int` | Caret position or selection start index. / 光标位置或选择起始索引。 |
| `SelectionEnd` | `int` | Selection end index. / 选择结束索引。 |
| `SelectedText` | `string` | The currently selected text (read-only from binding). / 当前选中的文本（从绑定读取，只读）。 |
| `CaretIndex` | `int` | Current caret position. / 当前光标位置。 |
| `CaretBrush` | `IBrush?` | Brush for the text caret. / 文本光标的画刷。 |
| `SelectionBrush` | `IBrush?` | Brush for the selection highlight background. / 选择高亮背景的画刷。 |
| `IsUndoEnabled` | `bool` | Whether undo/redo is available (default `true`). / 是否启用撤销/重做（默认 `true`）。 |
| `CanUndo` | `bool` | (Read-only) Whether undo is currently possible. / （只读）当前是否可以撤销。 |
| `CanRedo` | `bool` | (Read-only) Whether redo is currently possible. / （只读）当前是否可以重做。 |
| `CanCut` | `bool` | (Read-only) Whether cut is currently possible. / （只读）当前是否可以剪切。 |
| `CanCopy` | `bool` | (Read-only) Whether copy is currently possible. / （只读）当前是否可以复制。 |
| `CanPaste` | `bool` | (Read-only) Whether paste is currently possible. / （只读）当前是否可以粘贴。 |
| `IsInactiveSelectionHighlightEnabled` | `bool` | Whether selection highlight persists when losing focus. / 失焦时选择高亮是否保持。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `TextChanged` | Raised when the `Text` property changes. / `Text` 属性改变时触发。 |
| `TextChanging` | Raised before `Text` is updated, allowing cancellation. / `Text` 更新前触发，可取消。 |
| `CopyingToClipboard` | Raised when text is being copied. / 文本被复制时触发。 |
| `CuttingToClipboard` | Raised when text is being cut. / 文本被剪切时触发。 |
| `PastingFromClipboard` | Raised when text is being pasted. / 文本被粘贴时触发。 |
| `SelectionChanged` | Raised when the selection range changes. / 选择范围改变时触发。 |

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlTheme / Semi.Avalonia 控件主题

Semi.Avalonia defines `{x:Type TextBox}` as the default ControlTheme with these key resource brushes:

Semi.Avalonia 将 `{x:Type TextBox}` 定义为默认 ControlTheme，使用以下关键资源笔刷：

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `TextBoxForeground` | Text color / 文本颜色 |
| `TextBoxPlaceholderForeground` | Watermark text color / 占位符文本颜色 |
| `TextBoxDefaultBackground` | Default background / 默认背景 |
| `TextBoxDefaultBorderBrush` | Default border / 默认边框 |
| `TextBoxSelectionBrush` | Selection background / 选择背景色 |

### Context Flyout / 上下文浮出菜单

Semi.Avalonia provides two built-in context flyouts with Cut/Copy/Paste菜单项：

Semi.Avalonia 提供两个内置上下文浮出菜单，包含剪切/复制/粘贴菜单项：

- `DefaultTextBoxContextFlyout` — Standard vertical flyout / 标准纵向浮出菜单
- `HorizontalTextBoxContextFlyout` — Horizontal toolbar-style flyout / 横向工具栏样式的浮出菜单

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:empty` | Toggled when `Text` is empty (used for watermark visibility). / `Text` 为空时触发（用于占位符可见性）。 |
| `:touch-mode` | Toggled on touch devices. Semi styles may adjust hit targets. / 在触摸设备上触发。Semi 样式可能调整点击目标大小。 |
| `:focus` | TextBox has keyboard focus. / TextBox 拥有键盘焦点。 |
| `:disabled` | TextBox is disabled (`IsEnabled = false`). / TextBox 已禁用。 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Required / 必须 | Description / 说明 |
| --- | --- | --- | --- |
| `PART_TextPresenter` | `TextPresenter` | Yes / 是 | Renders and edits the text content. / 渲染和编辑文本内容。 |
| `PART_ScrollViewer` | `ScrollViewer` | No / 否 | Provides scrolling for multi-line content. / 为多行内容提供滚动。 |

## FAQ / 常见问题

**Q: How do I distinguish TextBox from AutoCompleteBox? / 如何区分 TextBox 和 AutoCompleteBox？**

A: Use `TextBox` for plain text input where users type freely. Use `AutoCompleteBox` when you need a dropdown suggestion list based on typed input (e.g., search with autocomplete, country selector). `AutoCompleteBox` wraps a `TextBox` internally and adds the suggestion popup logic.

`TextBox` 用于用户自由输入的纯文本场景。`AutoCompleteBox` 用于需要根据输入显示下拉建议列表的场景（如带自动补全的搜索、国家选择器）。`AutoCompleteBox` 内部封装了 `TextBox` 并添加了建议弹出逻辑。

**Q: How do I handle numeric-only input? / 如何处理纯数字输入？**

A: Avalonia `TextBox` does not have a built-in numeric input mode. Options: (1) Use `NumericUpDown` for integer/decimal values with spinner buttons; (2) Handle `TextChanging` event to filter non-numeric characters; (3) Bind to a numeric property with a value converter that handles parsing and validation.

Avalonia 的 `TextBox` 没有内置的数字输入模式。可选方案：(1) 使用 `NumericUpDown` 处理带微调按钮的整数/小数值；(2) 处理 `TextChanging` 事件过滤非数字字符；(3) 绑定到数值属性，使用值转换器处理解析和验证。

**Q: Why doesn't my TextBox show a context menu on right-click? / 为什么我的 TextBox 右键不显示上下文菜单？**

A: Semi.Avalonia provides `DefaultTextBoxContextFlyout` but does not auto-attach it. Assign it explicitly: `<TextBox ContextFlyout="{StaticResource DefaultTextBoxContextFlyout}" />`. On desktop, Avalonia may also use native context menus depending on the platform.

Semi.Avalonia 提供了 `DefaultTextBoxContextFlyout` 但不会自动附加。需要显式指定：`<TextBox ContextFlyout="{StaticResource DefaultTextBoxContextFlyout}" />`。在桌面端，Avalonia 也可能根据平台使用原生上下文菜单。
