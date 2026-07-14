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

Semi.Avalonia defines three TextBox themes plus one companion ToggleButton theme:

Semi.Avalonia 定义了三种 TextBox 主题和一个配套 ToggleButton 主题：

| Theme / 主题 | Resource Key / 资源键 | Target / 目标 | Description / 说明 |
| --- | --- | --- | --- |
| Default | `{x:Type TextBox}` | `TextBox` | Standard text box with border, background, focus visuals, clear button, and reveal-password button. Supports `Small`, `Large`, `Bordered`, `clearButton`, and `revealPasswordButton` style classes. / 标准文本框，带边框、背景、焦点视觉、清除按钮和密码显示按钮。支持 `Small`、`Large`、`Bordered`、`clearButton` 和 `revealPasswordButton` 样式类。 |
| Non-error | `NonErrorTextBox` | `TextBox` | Like default but wraps content with `SilentDataValidationErrors` — suppresses error visuals. Use when data validation feedback is handled externally. / 类似默认主题但用 `SilentDataValidationErrors` 包裹内容 —— 抑制错误视觉。当数据验证反馈由外部处理时使用。 |
| Lookless | `LooklessTextBox` | `TextBox` | Borderless text box with no background, border, or error visuals. Only text, placeholder, caret, and inner content are visible. Use for inline editing or seamless text entry. / 无边框文本框，无背景、边框或错误视觉。仅文本、占位符、光标和内部内容可见。用于内联编辑或无缝文本输入。 |
| Input Toggle Button | `InputToggleButton` | `ToggleButton` | A 16×16 icon toggle button used internally for the password reveal button (`PART_RevealButton`). Toggles between an eye icon (hidden) and an eye-slash icon (visible). Can be reused for custom input adornments. / 一个 16×16 图标切换按钮，内部用于密码显示按钮（`PART_RevealButton`）。在眼睛图标（隐藏）和眼睛斜线图标（可见）之间切换。可复用于自定义输入装饰。 |

### Default Theme / 默认主题

The default theme provides a full-featured text box with border, background, focus, error states, inner left/right content, and optional clear/reveal buttons.

默认主题提供功能齐全的文本框，带边框、背景、焦点、错误状态、内部左右内容以及可选清除/显示按钮。

```xml
<!-- Default TextBox -->
<TextBox Watermark="Enter text"
         Text="{Binding Name}"
         Width="200" />

<!-- Bordered variant -->
<TextBox Watermark="Search..."
         Classes="Bordered" />

<!-- With clear button -->
<TextBox Watermark="Type to search..."
         Classes="clearButton" />

<!-- With password reveal button -->
<TextBox PasswordChar="●"
         Watermark="Enter password"
         Classes="revealPasswordButton" />

<!-- Size variants -->
<TextBox Watermark="Small input" Classes="Small" />
<TextBox Watermark="Large input" Classes="Large" />
```

**Key resource brushes / 关键资源笔刷：**

The following table lists all `DynamicResource` keys consumed by Semi.Avalonia `TextBox` themes.

下表列出了 Semi.Avalonia `TextBox` 主题使用的所有 `DynamicResource` 键。

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `TextBoxDefaultFontSize` | Default font size / 默认字体大小 |
| `TextBoxDefaultHeight` | Default height / 默认高度 |
| `TextBoxDefaultPadding` | Default padding / 默认内边距 |
| `TextBoxDefaultCornerRadius` | Default corner radius / 默认圆角半径 |
| `TextBoxForeground` | Text color / 文本颜色 |
| `TextBoxPlaceholderForeground` | Watermark text color / 占位符文本颜色 |
| `TextBoxDefaultBackground` | Default background / 默认背景 |
| `TextBoxDefaultBorderBrush` | Default border / 默认边框 |
| `TextBoxSelectionBrush` | Selection background / 选择背景色 |
| `TextBoxSelectionForeground` | Selection foreground / 选择前景色 |
| `TextBoxDisabledBackground` | `:disabled` background / 禁用背景 |
| `TextBoxDisabledBorderBrush` | `:disabled` border / 禁用边框 |
| `TextBoxDisabledForeground` | `:disabled` foreground / 禁用前景色 |
| `TextBoxErrorBackground` | Error state background / 错误状态背景 |
| `TextBoxErrorBorderBrush` | Error state border / 错误状态边框 |
| `TextBoxErrorForeground` | Error state foreground / 错误状态前景色 |
| `TextBoxFocusBackground` | `:focus` background / 焦点背景 |
| `TextBoxFocusBorderBrush` | `:focus` border / 焦点边框 |
| `TextBoxFocusForeground` | `:focus` foreground / 焦点前景色 |
| `TextBoxPointeroverBackground` | `:pointerover` background / 悬停背景 |
| `TextBoxPointeroverBorderBrush` | `:pointerover` border / 悬停边框 |
| `TextBoxHoverBackground` | Hover background (alternative to pointerover) / 悬停背景（指针悬停的备选） |
| `TextBoxLargeHeight` | Height for Large size class / Large 尺寸类的高度 |
| `TextBoxLargePadding` | Padding for Large size class / Large 尺寸类的内边距 |
| `TextBoxSmallHeight` | Height for Small size class / Small 尺寸类的高度 |
| `TextBoxSmallPadding` | Padding for Small size class / Small 尺寸类的内边距 |
| `TextBoxGlyphData` | Path geometry data for the clear-button glyph / 清除按钮标记的路径几何数据 |
| `PasswordBoxRevealButtonData` | Path geometry data for the password reveal (eye) icon / 密码显示（眼睛）图标的路径几何数据 |
| `PasswordBoxHideButtonData` | Path geometry data for the password hide (eye-slash) icon / 密码隐藏（眼睛斜线）图标的路径几何数据 |
| `NonErrorTextBox` | Theme key for the no-error-validation TextBox variant / 无错误验证 TextBox 变体的主题键 |
| `ButtonInputInnerForeground` | Inner input button foreground (shared with Button) / 输入内部按钮前景色（与 Button 共享） |
| `ButtonInputInnerPointeroverForeground` | Inner input button `:pointerover` foreground (shared with Button) / 输入内部按钮悬停前景色（与 Button 共享） |
| `ButtonInputInnerPressedForeground` | Inner input button `:pressed` foreground (shared with Button) / 输入内部按钮按下前景色（与 Button 共享） |

### NonErrorTextBox / 无错误文本框

Identical to the default TextBox in appearance and behavior, but wraps its content in `SilentDataValidationErrors` instead of the standard `DataValidationErrors`. This suppresses the error visual (red background/border) that normally appears when `DataValidationErrors` detects an error. Use when you want to handle validation feedback through a separate mechanism (e.g., a dedicated error label outside the TextBox).

外观和行为与默认 TextBox 相同，但将内容包裹在 `SilentDataValidationErrors` 而非标准 `DataValidationErrors` 中。这会抑制 `DataValidationErrors` 检测到错误时通常显示的错误视觉（红色背景/边框）。当你想通过单独机制处理验证反馈时使用（例如 TextBox 外的专用错误标签）。

```xml
<StackPanel Spacing="4">
    <TextBox Theme="{DynamicResource NonErrorTextBox}"
             Watermark="Username"
             Text="{Binding Username, Mode=TwoWay}" />
    <TextBlock Text="{Binding UsernameError}"
               Foreground="{DynamicResource TextBoxErrorForeground}"
               IsVisible="{Binding HasUsernameError}" />
</StackPanel>
```

### LooklessTextBox / 无外观文本框

A completely borderless and background-less text box. It omits the outer border, background, clear button, reveal button, and error visuals entirely — only the core text editing surface, placeholder, and inner content are rendered. Ideal for inline editing scenarios where the text box should blend seamlessly into surrounding content (e.g., renaming an item in a tree, editing a table cell, or building a custom composite input).

完全无边框、无背景的文本框。它完全省略了外部边框、背景、清除按钮、显示按钮和错误视觉 —— 仅渲染核心文本编辑区域、占位符和内部内容。适用于文本框应与周围内容无缝融合的内联编辑场景（例如在树中重命名项目、编辑表格单元格或构建自定义复合输入）。

```xml
<!-- Inline rename in a label -->
<StackPanel Orientation="Horizontal">
    <TextBlock Text="File name: " VerticalAlignment="Center" />
    <TextBox Theme="{DynamicResource LooklessTextBox}"
             Text="{Binding FileName, Mode=TwoWay}"
             Watermark="Enter file name"
             Width="200" />
    <TextBlock Text=".txt" VerticalAlignment="Center" />
</StackPanel>
```

### InputToggleButton / 输入切换按钮

A 16×16 icon toggle button used internally as the password reveal toggle. It alternates between two `PathIcon` elements — a reveal icon (eye) when unchecked and a hide icon (eye-slash) when checked. It also provides `:pointerover` and `:pressed` pseudoclass styling. Although designed for `PART_RevealButton`, it can be reused independently for any compact icon toggle inside an input.

一个 16×16 图标切换按钮，内部用作密码显示切换。它在两个 `PathIcon` 元素之间交替 —— 未选中时显示眼睛图标，选中时显示眼睛斜线图标。它还提供 `:pointerover` 和 `:pressed` 伪类样式。虽然设计用于 `PART_RevealButton`，但可独立复用于输入内的任何紧凑图标切换。

```xml
<!-- Standalone usage -->
<ToggleButton Theme="{DynamicResource InputToggleButton}"
              IsChecked="{Binding IsPasswordRevealed}" />
```

### Context Flyout / 上下文浮出菜单

Semi.Avalonia provides two built-in context flyouts with Cut/Copy/Paste menu items:

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
