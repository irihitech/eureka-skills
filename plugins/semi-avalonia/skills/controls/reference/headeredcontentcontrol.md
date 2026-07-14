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

## FAQ / 常见问题

**Q: Should I use HeaderedContentControl directly? / 应该直接使用它吗？**

A: No. Use `Expander`, `GroupBox`, or `TabItem` which provide meaningful UI. Only use as a base class for custom controls. / 不。使用提供有意义 UI 的 `Expander`、`GroupBox` 或 `TabItem`。仅作为自定义控件基类使用。