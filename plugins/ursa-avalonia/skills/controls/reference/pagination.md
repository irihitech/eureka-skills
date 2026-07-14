---
category: Navigation
title: Pagination
subtitle: 分页
description: >
  Data paging control with page buttons, quick-jump input, page-size selector,
  and customisable button theme. Supports ICommand-based navigation, compact
  "tiny" variant, and configurable visible page count (up to 7). CurrentPage
  is 1-based and two-way bindable.
  数据分页控件，支持页码按钮、快速跳转输入、每页条数选择和自定义按钮主题。支持
  ICommand 导航、紧凑 "tiny" 变体，以及可见页码数量上限 7。CurrentPage 从 1 开始，
  支持双向绑定。
---

# Pagination / 分页

## When to Use / 何时使用

Use `Pagination` when you need to split a large dataset across multiple pages
and give the user numbered navigation buttons, a quick-jump input, and
optional page-size switching.

当需要将大数据集拆分到多个页面，并为用户提供编号导航按钮、快速跳转输入和可选的
每页条数切换时使用 `Pagination`。

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<u:Pagination TotalCount="200"
               PageSize="20"
               CurrentPage="{Binding Page, Mode=TwoWay}"
               Command="{Binding NavigateCommand}" />
```

### With page-size selector / 含每页条数选择器

```xml
<u:Pagination TotalCount="200"
               PageSize="20"
               CurrentPage="{Binding Page, Mode=TwoWay}"
               ShowPageSizeSelector="True">
    <u:Pagination.PageSizeOptions>
        <AvaloniaList x:TypeArguments="sys:Int32">
            <sys:Int32>10</sys:Int32>
            <sys:Int32>20</sys:Int32>
            <sys:Int32>50</sys:Int32>
        </AvaloniaList>
    </u:Pagination.PageSizeOptions>
</u:Pagination>
```

### Quick-jump input / 快速跳转

```xml
<u:Pagination TotalCount="200"
               PageSize="20"
               ShowQuickJump="True" />
```

When `ShowQuickJump` is `true`, a `NumericIntUpDown` and localised label appear
after the page buttons. Press Enter or lose focus to navigate.

当 `ShowQuickJump` 为 `true` 时，页码按钮后会出现一个 `NumericIntUpDown`
和本地化文本标签。按回车键或失去焦点即可跳转。

## Common Scenarios / 常用场景

### 1. Tiny (compact) variant / 紧凑变体

```xml
<u:Pagination Theme="{StaticResource TinyPagination}"
               TotalCount="200"
               PageSize="20"
               ShowQuickJump="True"
               DisplayCurrentPageInQuickJumper="True" />
```

The `TinyPagination` theme hides the numbered button panel and shows only
prev/next arrows, a current-page input, and total page count. Set
`DisplayCurrentPageInQuickJumper` to keep the jumper synced.

`TinyPagination` 主题隐藏编号按钮面板，仅显示上/下一页箭头、当前页输入和总页数。
设置 `DisplayCurrentPageInQuickJumper` 使跳转输入保持同步。

### 2. Two-way binding with MVVM / MVVM 双向绑定

```xml
<u:Pagination TotalCount="{Binding TotalItems}"
               PageSize="{Binding PageSize, Mode=TwoWay}"
               CurrentPage="{Binding CurrentPage, Mode=TwoWay}"
               Command="{Binding LoadPageCommand}" />
```

The `Command` fires on every page change (prev/next, number click, fast-forward,
or quick-jump). `CurrentPage` is coerced to the valid range `[1, PageCount]`.

每次翻页时都会触发 `Command`。`CurrentPage` 被强制限制在 `[1, PageCount]` 范围内。

### 3. Read-only tiny mode / 只读紧凑模式

```xml
<u:Pagination Theme="{StaticResource TinyPagination}"
               Classes="ReadOnly"
               TotalCount="200"
               PageSize="20"
               CurrentPage="3" />
```

The `ReadOnly` style class on the `TinyPagination` theme swaps the
`NumericIntUpDown` for a `TextBlock`, preventing user edits.

`TinyPagination` 主题上的 `ReadOnly` 样式类会将 `NumericIntUpDown` 替换为
`TextBlock`，阻止用户编辑。

## Property Reference / 属性参考

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `CurrentPage` | `int?` | `null` | Current page (1-based). Two-way bindable. / 当前页（从1开始） |
| `TotalCount` | `int` | `0` | Total number of items. / 数据总条数 |
| `PageSize` | `int` | `10` | Items per page. / 每页条数 |
| `PageCount` | `int` | (derived) | Read-only computed page count. / 只读，计算所得的总页数 |
| `PageSizeOptions` | `AvaloniaList<int>` | `null` | Options for the page-size ComboBox. / 每页条数下拉选项 |
| `ShowPageSizeSelector` | `bool` | `false` | Show the page-size ComboBox. / 显示每页条数选择器 |
| `ShowQuickJump` | `bool` | `false` | Show the quick-jump input. / 显示快速跳转输入 |
| `DisplayCurrentPageInQuickJumper` | `bool` | `false` | Sync current page into the jumper text. / 将当前页同步到跳转输入框 |
| `PageButtonTheme` | `ControlTheme` | `null` | Theme applied to each `PaginationButton`. / 应用于每个页码按钮的主题 |
| `Command` | `ICommand?` | `null` | Command invoked on every page change. / 每次翻页时执行的命令 |
| `CommandParameter` | `object?` | `null` | Parameter passed to `Command`. / 传递给命令的参数 |

**Style Classes:** `ReadOnly` (on `TinyPagination` theme).

**Themes:** Default, `TinyPagination`.

## Events / 事件

| Event | Args | Description / 说明 |
|---|---|---|
| `CurrentPageChanged` | `ValueChangedEventArgs<int>` | Fires after `CurrentPage` changes. `OldValue`/`NewValue` are `int?` values. / 在 `CurrentPage` 变化后触发 |

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `PaginationButtonDefaultBackground` | Button | Default button background |
| `PaginationButtonDefaultForeground` | Button | Default button foreground |
| `PaginationButtonPointeroverBackground` | Button | Hover background |
| `PaginationButtonPressedBackground` | Button | Pressed background |
| `PaginationButtonSelectedBackground` | Button | Selected-page background |
| `PaginationButtonSelectedForeground` | Button | Selected-page foreground |
| `PaginationButtonIconForeground` | Icon | Arrow/ellipsis icon colour |
| `PaginationBackwardGlyph` | Prev icon | Backward arrow path data |
| `PaginationForwardGlyph` | Next icon | Forward arrow path data |
| `PaginationFastBackwardGlyph` | Fast-back icon | Fast-backward arrow path data |
| `PaginationFastForwardGlyph` | Fast-forward icon | Fast-forward arrow path data |
| `PaginationMoreGlyph` | Ellipsis icon | "..." path data |
| `STRING_PAGINATION_JUMP_TO` | Label | Localised "Jump to" text |
| `STRING_PAGINATION_PAGE` | Label | Localised "Page" text |

### Template Parts / 模板部件

| Part Name | Type | Description |
|---|---|---|
| `PART_PreviousButton` | `PaginationButton` | Previous-page button |
| `PART_NextButton` | `PaginationButton` | Next-page button |
| `PART_ButtonPanel` | `StackPanel` | Hosts the 7 `PaginationButton` instances |
| `PART_QuickJumpInput` | `NumericIntUpDown` | Quick-jump numeric input |

### Class Selectors / 类选择器

| Class | Effect |
|---|---|
| `ReadOnly` | On `TinyPagination` theme: shows `TextBlock` instead of `NumericIntUpDown` |

### PaginationButton Pseudo-classes / PaginationButton 伪类

| Pseudo-class | Meaning |
|---|---|
| `:selected` | This button is the current page |
| `:left` | This button is a fast-backward placeholder (click jumps back 5) |
| `:right` | This button is a fast-forward placeholder (click jumps forward 5) |

## FAQ / 常见问题

**Q: Why does CurrentPage start at 1 instead of 0? / 为什么 CurrentPage 从 1 而不是 0 开始？**
A: The control is designed for user-facing page numbering, where "Page 1" is
the natural first page. The internal logic clamps to `[1, PageCount]`.

该控件面向用户显示页码，"第 1 页" 是自然的第一页。内部逻辑强制限制在 `[1, PageCount]`。

**Q: How do I handle the case where TotalCount is 0? / 如何处理 TotalCount 为 0 的情况？**
A: When `TotalCount` is 0, `PageCount` becomes 0. The previous/next buttons
are disabled, and the button panel is empty. Bind `PageCount` to your VM to
show a "no results" message.

当 `TotalCount` 为 0 时，`PageCount` 为 0，前进/后退按钮被禁用，按钮面板为空。
可将 `PageCount` 绑定到视图模型以显示 "无结果" 消息。

**Q: Can I customise individual page buttons? / 可以自定义单个页码按钮吗？**
A: Use `PageButtonTheme` to provide a custom `ControlTheme` for
`PaginationButton`. It applies to all seven buttons uniformly.

使用 `PageButtonTheme` 为 `PaginationButton` 提供自定义 `ControlTheme`，统一
应用于所有七个按钮。

**Q: How does fast-forward/backward work? / 快进/快退如何工作？**
A: When page count exceeds 7, buttons at positions 2 and 6 show "…" by default.
On hover they change to double-arrow icons; clicking jumps ±5 pages.

当总页数超过 7 时，位置 2 和 6 的按钮默认显示 "…"。悬停时变为双箭头图标；点击
跳转 ±5 页。
