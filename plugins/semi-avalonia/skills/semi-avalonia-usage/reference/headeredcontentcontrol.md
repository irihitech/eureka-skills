---
category: Components
title: HeaderedContentControl
subtitle: 带标题的内容控件
description: 带标题的内容控件是 Expander 和 GroupBox 等控件的基类，提供 Header 和 Content 属性。
---

# HeaderedContentControl / 带标题的内容控件

The base class for controls that pair a `Header` with `Content` — used by `Expander`, `GroupBox`, `TabItem`, and `TabbedPage`. Do not use directly unless building a custom headered control.

带有 `Header` 和 `Content` 配对的控件基类——被 `Expander`、`GroupBox`、`TabItem` 和 `TabbedPage` 使用。除非构建自定义标题控件，否则不要直接使用。

## When to Use / 何时使用

Use this as a base class when building custom controls that need a header-content pattern. For application code, use `Expander` or `GroupBox` instead.

构建需要标题-内容模式的自定义控件时用作基类。应用代码中请使用 `Expander` 或 `GroupBox`。

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Header` | `object?` | The header object. / 标题对象。 |
| `HeaderTemplate` | `IDataTemplate?` | Template for the header. / 标题模板。 |
| `Content` | `object?` | The body content. / 主体内容。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: Should I use HeaderedContentControl directly? / 应该直接使用它吗？**

A: No. Use `Expander`, `GroupBox`, or `TabItem` which provide meaningful UI. Only use as a base class for custom controls. Alternatively, apply the `GroupBox` theme to `HeaderedContentControl` for a titled-border container. / 不。使用提供有意义 UI 的 `Expander`、`GroupBox` 或 `TabItem`。仅作为自定义控件基类使用。或者，将 `GroupBox` 主题应用于 `HeaderedContentControl` 以获得带标题的边框容器。