---
category: Components
title: TagInput
subtitle: 标签输入
description: 标签输入组件用于输入和管理多个文本标签，支持分隔符拆分、重复过滤和回车/失焦提交。
---

# TagInput / 标签输入

A tag input control that allows users to type and manage multiple text tags. Supports separator-based splitting, duplicate filtering, lost-focus behavior, and keyboard-driven tag removal. Inherits from `TemplatedControl`.

允许用户输入和管理多个文本标签的控件。支持分隔符拆分、重复过滤、失焦行为以及键盘驱动的标签删除。继承自 `TemplatedControl`。

## When to Use / 何时使用

Use `TagInput` when users need to enter multiple short text values (e.g., email recipients, search keywords, categories). For single text input, use `TextBox`. For a fixed set of choices, use `MultiComboBox`.

用户需要输入多个简短文本值时使用（如邮件收件人、搜索关键词、分类标签）。单文本输入使用 `TextBox`，固定选项集使用 `MultiComboBox`。

## Basic Usage / 基本使用

```xml
<u:TagInput PlaceholderText="Add tags..." Tags="{Binding Tags}" />
```

```csharp
// In ViewModel
public ObservableCollection<string> Tags { get; } = new();
```

## Common Scenarios / 常用场景

### Separator-based Splitting / 基于分隔符的拆分

```xml
<u:TagInput Separator="-" PlaceholderText="Type and press Enter"
    Tags="{Binding Tags}" />
```

Typing `alpha-beta-gamma` and pressing Enter adds three tags: `alpha`, `beta`, `gamma`.

输入 `alpha-beta-gamma` 并按回车会添加三个标签。

### Duplicate Prevention / 防止重复

```xml
<u:TagInput AllowDuplicates="False" PlaceholderText="No duplicates allowed"
    Tags="{Binding DistinctTags}" />
```

### Lost Focus Behavior / 失焦行为

```xml
<!-- Add on lost focus -->
<u:TagInput LostFocusBehavior="Add" Tags="{Binding Tags}" />

<!-- Clear input on lost focus -->
<u:TagInput LostFocusBehavior="Clear" Tags="{Binding Tags}" />

<!-- Do nothing on lost focus (default) -->
<u:TagInput LostFocusBehavior="None" Tags="{Binding Tags}" />
```

### Multi-line Input with AcceptsReturn / 多行输入

```xml
<u:TagInput AcceptsReturn="True" LostFocusBehavior="Clear"
    Separator="-" Tags="{Binding Tags}" />
```

Each line is split and added as separate tags on Enter.

每行按回车后拆分并添加为独立标签。

### Max Tag Limit / 标签数量限制

```xml
<u:TagInput MaxCount="10" Tags="{Binding Tags}" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default / 默认值 | Description / 说明 |
| --- | --- | --- | --- |
| `Tags` | `IList<string>?` | `ObservableCollection<string>` | The collection of tags. / 标签集合。 |
| `PlaceholderText` | `string?` | `null` | Placeholder text shown when empty. / 空状态下的占位文本。 |
| `PlaceholderForeground` | `IBrush?` | — | Brush for the placeholder text. / 占位文本的画刷。 |
| `Separator` | `string` | `null` | String delimiter used to split input into multiple tags. / 用于将输入拆分为多个标签的分隔符。 |
| `MaxCount` | `int` | `int.MaxValue` | Maximum number of tags allowed. / 允许的最大标签数量。 |
| `AllowDuplicates` | `bool` | `true` | Whether duplicate tag values are permitted. / 是否允许重复标签值。 |
| `AcceptsReturn` | `bool` | `false` | Whether Enter creates multi-line input (splits each line as a tag). / 是否允许回车多行输入。 |
| `LostFocusBehavior` | `LostFocusBehavior` | `None` | Action when the internal TextBox loses focus: `None`, `Add`, or `Clear`. / 内部 TextBox 失焦时的行为。 |
| `ItemTemplate` | `IDataTemplate?` | `null` | Template for rendering each tag chip. / 每个标签芯片的渲染模板。 |
| `InnerLeftContent` | `object?` | `null` | Content slotted to the left inside the control. / 控件内部左侧内容。 |
| `InnerRightContent` | `object?` | `null` | Content slotted to the right inside the control. / 控件内部右侧内容。 |

> **Obsolete:** `Watermark` is deprecated — use `PlaceholderText` instead. / `Watermark` 已废弃，请使用 `PlaceholderText`。

### Pseudo-classes / 伪类

| Class / 类名 | Description / 说明 |
| --- | --- |
| `:empty` | Applied when the text input is empty and there are no tags. / 输入框为空且无标签时应用。 |

### Template Parts / 模板部件

| Part | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_ItemsControl` | `ItemsControl` | Hosts the tag chips. Wrapped in a `WrapPanelWithTrailingItem` with a trailing `TextBox`. / 承载标签芯片的容器。 |
| `PART_Placeholder` | `Visual` | Placeholder text block visible when `:empty`. / 空状态时可见的占位文本。 |

### Keyboard Shortcuts / 键盘快捷键

| Key / 按键 | Behavior / 行为 |
| --- | --- |
| `Enter` (AcceptsReturn=false) | Splits current text and adds tag(s). / 拆分当前文本并添加标签。 |
| `Enter` (AcceptsReturn=true) | Splits by lines and adds each line as a tag. / 按行拆分，每行添加为一个标签。 |
| `Delete` / `Backspace` (empty input) | Removes the last tag. / 删除最后一个标签。 |

## Styling & Templating / 样式与模板

### ControlTheme: TagInput

The default theme renders a bordered container with a `WrapPanelWithTrailingItem` that holds the tag chips and a trailing `TextBox`. The `:empty` pseudo-class controls placeholder visibility.

默认主题渲染带边框的容器，内部使用 `WrapPanelWithTrailingItem` 承载标签芯片和尾随 `TextBox`。`:empty` 伪类控制占位文本可见性。

### ControlTheme: TagInputTextBoxTheme

A custom `TextBox` theme (`TagInputTextBoxTheme`) is applied to the internal input `TextBox`, giving it a borderless appearance without background.

内部输入 `TextBox` 应用自定义主题 `TagInputTextBoxTheme`，实现无边框无背景的外观。

### ControlTheme: ClosableTag

Each tag chip is a `ClosableTag` control with a close button (`PART_CloseButton`). Style classes for hover/pressed states on the close button.

每个标签芯片是 `ClosableTag` 控件，带有关闭按钮 `PART_CloseButton`。悬停/按下状态有相应样式。

### DynamicResource Keys / 动态资源键

| Key | Description / 说明 |
| --- | --- |
| `ClosableTagForeground` | Tag text color. / 标签文字颜色。 |
| `ClosableTagBackground` | Tag background color. / 标签背景色。 |
| `ClosableTagBorder` | Tag border color. / 标签边框颜色。 |
| `ClosableTagCloseButtonForeground` | Close button default color. / 关闭按钮默认颜色。 |
| `ClosableTagCloseButtonPointeroverForeground` | Close button hover color. / 关闭按钮悬停颜色。 |
| `ClosableTagCloseButtonPressedForeground` | Close button pressed color. / 关闭按钮按下颜色。 |
| `ClosableTagCloseIconGlyph` | Close icon path data. / 关闭图标路径数据。 |

## FAQ / 常见问题

**Q: How do I remove a specific tag? / 如何删除特定标签？**

A: Each tag chip has a close button. Clicking it calls the `Close(object)` method on `TagInput`, which removes the tag from the `Tags` collection. / 每个标签芯片有关闭按钮，点击后调用 `Close(object)` 方法从 `Tags` 集合中移除。

**Q: What's the difference between LostFocusBehavior.Add and LostFocusBehavior.Clear? / LostFocusBehavior.Add 和 Clear 的区别？**

A: `Add` converts the current input text to a tag on focus loss. `Clear` empties the input text. `None` does nothing. / `Add` 在失焦时将当前输入转为标签。`Clear` 清空输入文本。`None` 不做任何操作。
