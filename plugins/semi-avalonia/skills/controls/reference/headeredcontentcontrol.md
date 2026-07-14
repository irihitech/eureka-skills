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

## Styling & Templating / 样式与模板

### Special ControlThemes / 特殊控件主题

Semi.Avalonia defines the `GroupBox` theme in `HeaderedContentControl.axaml` as an alternative visual style for `HeaderedContentControl`.

Semi.Avalonia 在 `HeaderedContentControl.axaml` 中定义了 `GroupBox` 主题，作为 `HeaderedContentControl` 的替代视觉样式。

#### `GroupBox`

**TargetType:** `HeaderedContentControl`
**Resource Key:** `GroupBox`

A `GroupBox`-style theme that provides a titled border container. Unlike the default `HeaderedContentControl` theme (which uses a simple two-row grid), this theme adds a decorative border around both header and content with a separator line between them. The header is styled with `HeaderedContentControlHeaderPadding` and bold `FontWeight`. A separator `Border` appears between header and content only when both are present. Content area uses `HeaderedContentControlContentPadding` and supports `TextWrapping="Wrap"`. This theme is also re-registered as `{x:Type GroupBox}` in `GroupBox.axaml`, making `GroupBox` work as an alias.

分组框样式主题，提供带标题的边框容器。与默认的 `HeaderedContentControl` 主题（使用简单的两行网格）不同，此主题在标题和内容周围添加装饰性边框，并在两者之间加入分隔线。标题使用 `HeaderedContentControlHeaderPadding` 和粗体 `FontWeight` 进行样式设置。仅当标题和内容都存在时，分隔 `Border` 才会出现。内容区域使用 `HeaderedContentControlContentPadding` 并支持 `TextWrapping="Wrap"`。该主题也在 `GroupBox.axaml` 中重新注册为 `{x:Type GroupBox}`，使 `GroupBox` 可作为别名使用。

```xml
<HeaderedContentControl Theme="{StaticResource GroupBox}"
                        Header="Settings"
                        Content="Group content here" />
```

**Key resources:** `HeaderedContentControlBackground`, `HeaderedContentControlBorderBrush`, `HeaderedContentControlBorderThickness`, `HeaderedContentControlCornerRadius`, `HeaderedContentControlHeaderPadding`, `HeaderedContentControlHeaderFontWeight`, `HeaderedContentControlContentPadding`

**Template parts:** `PART_HeaderPresenter`, `SeparatorBorder` (visibility bound to both Header and Content being non-null), `PART_ContentPresenter`

## FAQ / 常见问题

**Q: Should I use HeaderedContentControl directly? / 应该直接使用它吗？**

A: No. Use `Expander`, `GroupBox`, or `TabItem` which provide meaningful UI. Only use as a base class for custom controls. Alternatively, apply the `GroupBox` theme to `HeaderedContentControl` for a titled-border container. / 不。使用提供有意义 UI 的 `Expander`、`GroupBox` 或 `TabItem`。仅作为自定义控件基类使用。或者，将 `GroupBox` 主题应用于 `HeaderedContentControl` 以获得带标题的边框容器。