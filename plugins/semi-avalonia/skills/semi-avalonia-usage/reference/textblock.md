---
category: Components
title: TextBlock
subtitle: 文本块
description: 文本块用于显示只读文本内容，支持样式、换行和裁剪。
---

# TextBlock / 文本块

A lightweight control for displaying read-only, non-interactive text. Supports multiple paragraphs, text wrapping, trimming, alignment, and inline run styling. Inherits from `Control` (not `ContentControl`). When you need selectable text that users can copy, use `SelectableTextBlock` instead.

用于显示只读、非交互文本的轻量控件。支持多段落、文本换行、裁剪、对齐和内联样式。继承自 `Control`（而非 `ContentControl`）。需要用户可复制文本时，请使用 `SelectableTextBlock`。

## When to Use / 何时使用

Use `TextBlock` for displaying static or data-bound text content that users do not need to edit — labels, descriptions, status messages, and read-only data fields. It is the most common text display control in Avalonia. For editable text, use `TextBox`. For selectable/copyable read-only text, use `SelectableTextBlock`. For labeled form fields that pair with an input control, consider `Label`.

使用 `TextBlock` 显示用户无需编辑的静态或数据绑定文本内容 —— 标签、描述、状态消息和只读数据字段。它是 Avalonia 中最常用的文本显示控件。可编辑文本使用 `TextBox`。可选择/可复制的只读文本使用 `SelectableTextBlock`。与输入控件配对的标签表单字段，可考虑使用 `Label`。

## Basic Usage / 基本使用

```xml
<TextBlock Text="Hello, World!"
           FontSize="16"
           FontWeight="Bold" />
```

```csharp
// Programmatic creation
var textBlock = new TextBlock
{
    Text = "Hello, World!",
    FontSize = 16,
    FontWeight = FontWeight.Bold
};
```

## Common Scenarios / 常用场景

### Data Binding / 数据绑定

Display dynamic text from a ViewModel property. `TextBlock` is often used inside `DataTemplate` for list items.

```xml
<TextBlock Text="{Binding UserName}"
           FontSize="14"
           TextTrimming="CharacterEllipsis" />
```

### Inline Runs / 内联文本

Use `Run` elements for mixed-style text within a single `TextBlock`. Supports `Bold`, `Italic`, and `LineBreak`; underline and strike-through come from the `TextDecorations` property.

```xml
<TextBlock>
    <Run Text="Hello " />
    <Bold>World</Bold>
    <Run Text=" — " />
    <Italic>
        Semi.Avalonia
    </Italic>
</TextBlock>
```

### Text Wrapping & Trimming / 文本换行与裁剪

Control overflow behavior with `TextWrapping` and `TextTrimming` for responsive layouts.

```xml
<!-- Wraps to multiple lines -->
<TextBlock Text="{Binding LongDescription}"
           TextWrapping="Wrap"
           MaxLines="3" />

<!-- Truncates with ellipsis -->
<TextBlock Text="{Binding FileName}"
           TextTrimming="CharacterEllipsis"
           MaxWidth="200" />
```

### Styled Text Variants / 文本样式变体

Semi.Avalonia provides color resource keys for text hierarchy — the full list is in the `semi-avalonia` skill's token reference.

```xml
<StackPanel Spacing="4">
    <TextBlock Text="Primary Text" />
    <TextBlock Text="Secondary Text" />
    <TextBlock Text="Tertiary Text" />
</StackPanel>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Text` | `string?` | The text content to display. Supports `\n` for line breaks. Set directly or via `<Run>` inlines. / 要显示的文本内容。支持 `\n` 换行。可直接设置或通过 `<Run>` 内联元素设置。 |
| `FontSize` | `double` | The font size in device-independent pixels. / 字体大小，单位为设备无关像素。 |
| `FontWeight` | `FontWeight` | Text weight: `Normal`, `Bold`, `Light`, etc. / 文本粗细：`Normal`、`Bold`、`Light` 等。 |
| `FontFamily` | `FontFamily` | The font family name. / 字体系列名称。 |
| `FontStyle` | `FontStyle` | Text style: `Normal`, `Italic`, `Oblique`. / 文本样式：`Normal`、`Italic`、`Oblique`。 |
| `TextAlignment` | `TextAlignment` | Horizontal alignment: `Left`, `Center`, `Right`, `Justify`. / 水平对齐：`Left`、`Center`、`Right`、`Justify`。 |
| `TextWrapping` | `TextWrapping` | How text wraps: `NoWrap` (default), `Wrap`, `WrapWithOverflow`. / 文本换行方式：`NoWrap`（默认）、`Wrap`、`WrapWithOverflow`。 |
| `TextTrimming` | `TextTrimming` | Trimming behavior: `None` (default), `CharacterEllipsis`, `WordEllipsis`, `LeadingCharacterEllipsis`. / 裁剪行为：`None`（默认）、`CharacterEllipsis`、`WordEllipsis`、`LeadingCharacterEllipsis`。 |
| `MaxLines` | `int` | Maximum number of visible lines before trimming. Requires `TextTrimming` to be set. / 裁剪前可见的最大行数。需设置 `TextTrimming`。 |
| `Foreground` | `IBrush?` | Text color. / 文本颜色。 |
| `Inlines` | `InlineCollection` | Collection of inline elements (`Run`, `Bold`, `Italic`, etc.) for rich text. / 内联元素集合（`Run`、`Bold`、`Italic` 等），用于富文本。 |
| `LineHeight` | `double` | Line height multiplier or absolute value. / 行高倍数或绝对值。 |
| `LineSpacing` | `double` | Additional spacing between lines. / 行之间的额外间距。 |
| `LetterSpacing` | `double` | Additional spacing between characters. / 字符之间的额外间距。 |
| `BaselineOffset` | `double` | Vertical offset from the baseline. / 相对于基线的垂直偏移。 |
| `IsTextSelectionEnabled` | `bool` | (Inherited from `TextBlock` base) Whether text can be selected. Use `SelectableTextBlock` instead. / （继承自 TextBlock 基类）文本是否可选中。请改用 `SelectableTextBlock`。 |

### Events / 事件

TextBlock is a non-interactive control and does not define custom events. Use inherited events from `Control` for layout and input:

TextBlock 是非交互控件，不定义自定义事件。使用继承自 `Control` 的布局和输入事件：

| Event / 事件 | Description / 说明 |
| --- | --- |
| `PointerPressed` | Raised when a pointer is pressed over the TextBlock. / 指针在 TextBlock 上按下时触发。 |
| `Tapped` | Raised when a tap gesture completes. / 点击手势完成时触发。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: When should I use TextBlock vs. SelectableTextBlock? / 何时使用 TextBlock 而非 SelectableTextBlock？**

A: Use `TextBlock` for pure display text that users never need to copy or select — labels, headings, status text. Use `SelectableTextBlock` when users should be able to select and copy the text (Ctrl+C) — error messages, log output, code snippets, or any text where copying is a likely user action. `SelectableTextBlock` inherits from `TextBlock` and adds selection support with minimal overhead.

`TextBlock` 用于用户无需复制或选择的纯显示文本 —— 标签、标题、状态文本。`SelectableTextBlock` 用于用户应能够选择和复制文本的场景（Ctrl+C）—— 错误消息、日志输出、代码片段或任何可能需要复制的文本。`SelectableTextBlock` 继承自 `TextBlock`，以最小开销添加了选择支持。

**Q: How do I display multi-line text? / 如何显示多行文本？**

A: Set `TextWrapping="Wrap"` and optionally `MaxLines` to limit visible lines. Use `\n` in the `Text` string for explicit line breaks, or use `<LineBreak/>` inside Inlines. For scrollable multi-line content, wrap the `TextBlock` in a `ScrollViewer`.

设置 `TextWrapping="Wrap"`，并可选择 `MaxLines` 来限制可见行数。在 `Text` 字符串中使用 `\n` 进行显式换行，或在 Inlines 中使用 `<LineBreak/>`。需要可滚动的多行内容时，将 `TextBlock` 包裹在 `ScrollViewer` 中。

**Q: How do I use Semi.Avalonia text colors correctly? / 如何正确使用 Semi.Avalonia 文本颜色？**

A: Semi.Avalonia defines text hierarchy colors as `DynamicResource` brushes. Use the text tokens listed in the `semi-avalonia` skill's token reference (body, description and hint levels) instead of hardcoding colors, so the text automatically adapts to theme changes (light ↔ dark). If you assign `Foreground` on a parent container, child TextBlocks inherit it.

Semi.Avalonia 将文本层级颜色定义为 `DynamicResource` 笔刷。使用 `semi-avalonia` skill 的 token 参考中列出的文本层级令牌（正文/描述/提示），避免硬编码颜色，使文本自动适应主题变化（浅色 ↔ 深色）。如果在父容器上设置了 `Foreground`，子 TextBlock 将继承它。
