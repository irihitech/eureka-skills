---
category: Components
title: SelectableTextBlock
subtitle: 可选择文本块
description: 用于显示可选择、可复制的只读格式化文本的控件。
---

# SelectableTextBlock / 可选择文本块

A control that displays a block of read-only formatted text with text selection and copy-to-clipboard support. `SelectableTextBlock` inherits from `TextBlock` and implements `IInlineHost`, meaning it supports both plain text via `Text` and rich inlines via `Inlines`. Unlike `TextBox`, it is not editable — users can only select and copy text.

用于显示只读格式化文本并支持文本选择和复制到剪贴板的控件。`SelectableTextBlock` 继承自 `TextBlock` 并实现了 `IInlineHost`，这意味着既支持通过 `Text` 属性的纯文本，也支持通过 `Inlines` 的富文本行内元素。与 `TextBox` 不同，它不可编辑 —— 用户只能选择和复制文本。

## When to Use / 何时使用

Use `SelectableTextBlock` when you need to display read-only text that users can select and copy — log output, error messages, diagnostic information, code snippets, or formatted documentation. For editable text, use `TextBox`. For non-selectable read-only text, use `TextBlock`. For tabular read-only data, consider `TableView`.

当需要显示只读文本且希望用户能够选择和复制时使用 `SelectableTextBlock` —— 日志输出、错误消息、诊断信息、代码片段或格式化文档。可编辑文本使用 `TextBox`。不可选择的只读文本使用 `TextBlock`。表格式只读数据考虑使用 `TableView`。

## Basic Usage / 基本使用

```xml
<SelectableTextBlock Text="Select this text and press Ctrl+C to copy."
                     FontSize="14" />
```

```csharp
// Programmatic creation
var block = new SelectableTextBlock
{
    Text = "This text can be selected and copied.",
    FontSize = 14
};

// Select all text programmatically
block.SelectAll();

// Get selected text
string selected = block.SelectedText;
```

## Common Scenarios / 常用场景

### Displaying Log Output / 显示日志输出

Use `SelectableTextBlock` for scrollable, selectable log views.

```xml
<ScrollViewer Height="200">
    <SelectableTextBlock Text="{Binding LogOutput}"
                         FontFamily="Cascadia Code"
                         FontSize="12"
                         TextWrapping="Wrap" />
</ScrollViewer>
```

### Rich Inline Content with Selection / 可选择内容的富文本行内

Combine `Inlines` with `Run`, `Bold`, `Italic`, and `LineBreak` for formatted selectable text.

```xml
<SelectableTextBlock FontSize="14" TextWrapping="Wrap">
    <SelectableTextBlock.Inlines>
        <Run Text="This is " />
        <Bold>bold</Bold>
        <Run Text=", " />
        <Italic>italic</Italic>
        <Run Text=", and " />
        <Run Text="colored" />
        <Run Text=" text that users can select and copy." />
    </SelectableTextBlock.Inlines>
</SelectableTextBlock>
```

### Error/Status Display / 错误/状态显示

Display error details with Semi color classes for visual hierarchy.

```xml
<SelectableTextBlock
                     Text="{Binding ErrorMessage}"
                     TextWrapping="Wrap"
                     MaxLines="10"
                     TextTrimming="CharacterEllipsis" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Text` | `string?` | The plain text content to display. Inherited from `TextBlock`. / 要显示的纯文本内容。继承自 `TextBlock`。 |
| `Inlines` | `InlineCollection?` | Rich inline elements for formatted text. Inherited from `TextBlock`. / 用于格式化文本的富文本行内元素集合。继承自 `TextBlock`。 |
| `SelectionStart` | `int` | Character index of the selection start. / 选择起始字符索引。 |
| `SelectionEnd` | `int` | Character index of the selection end. / 选择结束字符索引。 |
| `SelectedText` | `string` | (Read-only) The currently selected text content. / （只读）当前选中的文本内容。 |
| `SelectionBrush` | `IBrush?` | Brush for the selection highlight background. / 选择高亮背景的画刷。 |
| `SelectionForegroundBrush` | `IBrush?` | Brush for the foreground color of selected text. / 选中文本前景色的画刷。 |
| `CanCopy` | `bool` | (Read-only) Whether text can currently be copied (has selection). / （只读）当前是否可以复制文本（有选择内容）。 |
| `FontSize` | `double` | The font size in device-independent pixels. Inherited from `TextBlock`. / 字体大小（设备无关像素）。继承自 `TextBlock`。 |
| `FontFamily` | `FontFamily` | The font family. Inherited from `TextBlock`. / 字体族。继承自 `TextBlock`。 |
| `FontWeight` | `FontWeight` | The font weight. Inherited from `TextBlock`. / 字体粗细。继承自 `TextBlock`。 |
| `FontStyle` | `FontStyle` | The font style (Normal, Italic, Oblique). Inherited from `TextBlock`. / 字体样式。继承自 `TextBlock`。 |
| `Foreground` | `IBrush?` | The text foreground color. Inherited from `TextBlock`. / 文本前景色。继承自 `TextBlock`。 |
| `TextWrapping` | `TextWrapping` | How text wraps: `NoWrap`, `Wrap`, `WrapWithOverflow`. Inherited from `TextBlock`. / 文本换行方式。继承自 `TextBlock`。 |
| `TextTrimming` | `TextTrimming` | How text is trimmed when overflowing. Inherited from `TextBlock`. / 文本溢出时的修剪方式。继承自 `TextBlock`。 |
| `TextAlignment` | `TextAlignment` | Horizontal text alignment. Inherited from `TextBlock`. / 水平文本对齐。继承自 `TextBlock`。 |
| `MaxLines` | `int` | Maximum number of visible lines. Inherited from `TextBlock`. / 最大可见行数。继承自 `TextBlock`。 |
| `LineHeight` | `double` | Line height multiplier. Inherited from `TextBlock`. / 行高倍数。继承自 `TextBlock`。 |
| `LineSpacing` | `double` | Additional spacing between lines. Inherited from `TextBlock`. / 行间额外间距。继承自 `TextBlock`。 |
| `LetterSpacing` | `double` | Spacing between characters. Inherited from `TextBlock`. / 字符间距。继承自 `TextBlock`。 |
| `TextDecorations` | `TextDecorationCollection?` | Text decorations (underline, strikethrough, etc.). Inherited from `TextBlock`. / 文本装饰（下划线、删除线等）。继承自 `TextBlock`。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `CopyingToClipboard` | Raised when text is being copied to the clipboard. Handle to modify or cancel the copy. / 文本被复制到剪贴板时触发。可处理以修改或取消复制。 |

### Methods / 方法

| Method / 方法 | Description / 说明 |
| --- | --- |
| `Copy()` | Copies the current selection to the clipboard. / 将当前选择复制到剪贴板。 |
| `SelectAll()` | Selects all text. / 选择所有文本。 |
| `ClearSelection()` | Clears the current text selection. / 清除当前文本选择。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How is SelectableTextBlock different from TextBlock and TextBox? / SelectableTextBlock 与 TextBlock 和 TextBox 有何不同？**

A: `TextBlock` is the lightest — display-only, no selection, no interaction. `SelectableTextBlock` adds text selection, Ctrl+C copy, keyboard navigation, and a context flyout with Copy. `TextBox` is the fully interactive control — editable, supports undo/redo, clipboard cut/paste, and password masking. Use `SelectableTextBlock` for the middle ground: read-only content that users may want to copy.

`TextBlock` 最轻量 —— 仅显示，无选择，无交互。`SelectableTextBlock` 增加了文本选择、Ctrl+C 复制、键盘导航以及带复制功能的上下文浮出菜单。`TextBox` 是完全交互式控件 —— 可编辑，支持撤销/重做、剪贴板剪切/粘贴以及密码掩码。`SelectableTextBlock` 适用于中间场景：只读但用户可能需要复制的内容。

**Q: Can I customize the context flyout? / 可以自定义上下文浮出菜单吗？**

A: Yes. Assign a custom `ContextFlyout` to override the default `SelectableTextBlockContextFlyout`. The default flyout is only attached when `IsEnabled` is `true`. Set `ContextFlyout="{x:Null}"` to disable it entirely.

可以。分配自定义 `ContextFlyout` 来覆盖默认的 `SelectableTextBlockContextFlyout`。默认浮出菜单仅在 `IsEnabled` 为 `true` 时附加。设置 `ContextFlyout="{x:Null}"` 可完全禁用。

**Q: Does SelectableTextBlock support hyperlinks? / SelectableTextBlock 支持超链接吗？**

A: `SelectableTextBlock` itself does not have built-in hyperlink support. However, you can use `TextBlock` with inline `Hyperlink` elements if you don't need text selection. For selectable text with clickable links, consider embedding a `TextBlock` with `Inlines` inside a custom control or using a `SelectableTextBlock` and handling `PointerPressed` with hit-testing.

`SelectableTextBlock` 本身没有内置超链接支持。但如果不需要文本选择，可以使用带行内 `Hyperlink` 元素的 `TextBlock`。对于带可点击链接的可选择文本，考虑在自定义控件中嵌入含 `Inlines` 的 `TextBlock`，或使用 `SelectableTextBlock` 并通过命中测试处理 `PointerPressed`。
