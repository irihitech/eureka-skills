---
category: Components
title: Label
subtitle: 标签
description: 标签控件用于显示文本标签，可关联焦点目标控件。
---

# Label / 标签

A text label that can be associated with a target control via the `Target` property. Pressing the access key (Alt+key) moves focus to the target. Inherits from `ContentControl`.

可通过 `Target` 属性关联目标控件的文本标签。按下访问键（Alt+键）将焦点移到目标。继承自 `ContentControl`。

## When to Use / 何时使用

Use `Label` when you need a form field label with keyboard accessibility. For plain display text without target association, use `TextBlock`.

需要带键盘可访问性的表单字段标签时使用。无需目标关联的纯显示文本用 `TextBlock`。

## Basic Usage / 基本使用

```xml
<Label Target="nameBox" Content="_Name" />
<TextBox Name="nameBox" />
<!-- Alt+N focuses the TextBox -->
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Target` | `IInputElement?` | The control to focus. / 要聚焦的控件。 |
| `Content` | `object?` | Label text (use `_` for access key). / 标签文本（`_` 表示访问键）。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: Label vs TextBlock? / Label 和 TextBlock 的区别？**

A: `Label` supports `Target` and access keys for form accessibility. `TextBlock` supports inline formatting (`Run`, `Bold`) and text wrapping. / `Label` 支持 `Target` 和访问键用于表单可访问性。`TextBlock` 支持内联格式化（`Run`、`Bold`）和文本换行。