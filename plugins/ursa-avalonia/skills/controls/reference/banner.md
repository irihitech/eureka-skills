---
category: Feedback
title: Banner
subtitle: 横幅通知
description: >
  Displays a non-modal notification banner with icon, title, description, and
  optional close button. Supports four semantic types (Information, Success,
  Warning, Error) with auto-colored icons and bordered/standard variants.
  显示非模态通知横幅，包含图标、标题、描述和可选关闭按钮。支持四种语义类型
  （Information、Success、Warning、Error），自带彩色图标和边框/标准变体。
---

# Banner / 横幅通知

## When to Use / 何时使用

Use `Banner` to display persistent, non-blocking status messages at the top of
a page or section — system alerts, form validation summaries, feature
announcements, or operation results. The banner remains visible until the user
closes it (when `CanClose` is true).

使用 `Banner` 在页面或区块顶部显示持久性、非阻塞的状态消息——系统警报、表单验证
摘要、功能公告或操作结果。横幅保持可见，直到用户关闭它（当 `CanClose` 为 true
时）。

Do NOT use Banner for transient toasts/popups — use `Notification` or `Toast`
instead. Do NOT use Banner for modal confirmations — use `MessageBox` or
`Dialog`.

不要将 Banner 用于短暂的 toast/弹出通知——应使用 `Notification` 或 `Toast`。
不要将 Banner 用于模态确认——应使用 `MessageBox` 或 `Dialog`。

## Basic Usage / 基本使用

### Default (plain) / 默认（纯文本）

```xml
xmlns:u="https://irihi.tech/ursa"

<u:Banner Header="Title"
          Content="This is a banner message."
          Type="Information" />
```

### With close button / 带关闭按钮

```xml
<u:Banner Header="Notice"
          Content="You have new updates available."
          Type="Warning"
          CanClose="True" />
```

When `CanClose="True"`, a close button appears. Clicking it sets
`IsVisible="False"` on the banner. The close button uses the
`OverlayCloseButton` theme.

当 `CanClose="True"` 时，出现关闭按钮。点击它会将 `IsVisible` 设为 `False`。
关闭按钮使用 `OverlayCloseButton` 主题。

### Custom icon / 自定义图标

```xml
<u:Banner Header="Custom" Type="Information">
    <u:Banner.Icon>
        <PathIcon Data="{StaticResource MyCustomIcon}" />
    </u:Banner.Icon>
</u:Banner>
```

When `Icon` is null and `ShowIcon="True"`, the built-in `PART_BuildInIcon`
`PathIcon` renders a type-specific icon. When `Icon` is set, the built-in icon
is hidden and your custom icon is shown.

当 `Icon` 为 null 且 `ShowIcon="True"` 时，内置 `PART_BuildInIcon` `PathIcon`
渲染类型特定的图标。设置 `Icon` 后，内置图标隐藏，显示您的自定义图标。

## Common Scenarios / 常用场景

### 1. Bordered variant / 边框变体

```xml
<u:Banner Classes="Bordered"
          Header="Information"
          Content="This banner has a visible border and rounded corners."
          Type="Information"
          CanClose="True" />
```

The `Bordered` class adds `CornerRadius` and type-colored `BorderBrush` to the
outer container.

`Bordered` 类为外部容器添加 `CornerRadius` 和类型着色的 `BorderBrush`。

### 2. Error banner with custom icon hidden / 隐藏图标但保留类型的错误横幅

```xml
<u:Banner Header="Error"
          Content="Something went wrong."
          Type="Error"
          ShowIcon="True"
          CanClose="True" />
```

Set `ShowIcon="False"` to hide the icon area entirely.

设置 `ShowIcon="False"` 完全隐藏图标区域。

### 3. All four types / 全部四种类型

```xml
<StackPanel Spacing="8">
    <u:Banner Header="Info" Content="For your information."
              Type="Information" Classes="Bordered" />
    <u:Banner Header="Success" Content="Operation completed."
              Type="Success" Classes="Bordered" />
    <u:Banner Header="Warning" Content="Proceed with caution."
              Type="Warning" Classes="Bordered" />
    <u:Banner Header="Error" Content="An error occurred."
              Type="Error" Classes="Bordered" />
</StackPanel>
```

## Property Reference / 属性参考

### Banner Properties / Banner 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Header` | `object?` | `null` | Banner title (inherited) / 横幅标题（继承） |
| `HeaderTemplate` | `IDataTemplate?` | `null` | Template for the header / 标题模板 |
| `Content` | `object?` | `null` | Banner body text (inherited) / 横幅正文（继承） |
| `ContentTemplate` | `IDataTemplate?` | `null` | Template for the content / 正文模板 |
| `Type` | `NotificationType` | — | Semantic type: Information, Success, Warning, Error / 语义类型 |
| `CanClose` | `bool` | `false` | Show close button; clicking hides the banner / 显示关闭按钮；点击隐藏横幅 |
| `ShowIcon` | `bool` | `true` | Show the icon area / 显示图标区域 |
| `Icon` | `object?` | `null` | Custom icon (hides built-in icon when set) / 自定义图标（设置后隐藏内置图标） |

### NotificationType Values / NotificationType 值

| Value | Built-in Icon | Description / 说明 |
|---|---|---|
| `Information` | Info circle | General information / 一般信息 |
| `Success` | Checkmark circle | Success confirmation / 成功确认 |
| `Warning` | Warning triangle | Caution or warning / 注意或警告 |
| `Error` | Error circle | Error or failure / 错误或失败 |

## Styling & Templating / 样式与模板

### Pseudo-classes / 伪类

| Pseudo-class | Condition |
|---|---|
| `:icon` | `ShowIcon` is `true` |

### Style Classes / 样式类

| Class | Effect |
|---|---|
| `Bordered` | Adds `CornerRadius` and type-colored border via attribute selector `[Type=...]` / 添加圆角和类型着色边框 |

### Type-based Styles / 基于类型的样式

Each `NotificationType` value triggers selector `^[Type=...]` which sets:

- **Background**: `Banner{Type}Background` on the outer border
- **BorderBrush** (Bordered only): `Banner{Type}BorderBrush`
- **Built-in Icon Data**: `Banner{Type}IconGeometry`
- **Built-in Icon Foreground**: `Banner{Type}BorderBrush`

每种 `NotificationType` 值触发选择器 `^[Type=...]`，设置：

- **Background**: 外部 Border 上的 `Banner{Type}Background`
- **BorderBrush**（仅 Bordered）：`Banner{Type}BorderBrush`
- **内置图标数据**：`Banner{Type}IconGeometry`
- **内置图标前景**：`Banner{Type}BorderBrush`

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `BannerBorderPadding` | Outer border | Padding inside the banner / 横幅内边距 |
| `BannerBorderThickness` | Outer border | Default border thickness / 默认边框粗细 |
| `BannerBorderBrush` | Outer border | Default border brush / 默认边框画刷 |
| `BannerCornerRadius` | Bordered | Corner radius when bordered / 边框变体的圆角 |
| `BannerIconMargin` | Icon area | Margin around the icon / 图标周围边距 |
| `BannerCloseButtonMargin` | Close button | Margin around the close button / 关闭按钮周围边距 |
| `BannerTitleFontSize` | Header text | Title font size / 标题字号 |
| `BannerInformationBackground` | Information type | Info background / 信息背景 |
| `BannerInformationBorderBrush` | Information type | Info border / 信息边框 |
| `BannerInformationIconGeometry` | Information type | Info icon data / 信息图标数据 |
| `BannerSuccessBackground` | Success type | Success background / 成功背景 |
| `BannerSuccessBorderBrush` | Success type | Success border / 成功边框 |
| `BannerSuccessIconGeometry` | Success type | Success icon data / 成功图标数据 |
| `BannerWarningBackground` | Warning type | Warning background / 警告背景 |
| `BannerWarningBorderBrush` | Warning type | Warning border / 警告边框 |
| `BannerWarningIconGeometry` | Warning type | Warning icon data / 警告图标数据 |
| `BannerErrorBackground` | Error type | Error background / 错误背景 |
| `BannerErrorBorderBrush` | Error type | Error border / 错误边框 |
| `BannerErrorIconGeometry` | Error type | Error icon data / 错误图标数据 |

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_Container` | `Banner` | `Border` |
| `PART_CloseButton` | `Banner` | `Button` |
| `PART_BuildInIcon` | `Banner` | `PathIcon` |

## FAQ / 常见问题

**Q: How do I programmatically close a banner? / 如何以编程方式关闭横幅？**
A: Set `IsVisible = false` on the banner instance. The close button does this
automatically when clicked. There is no built-in `Close()` method.

**Q: Can I use my own close button? / 可以使用自定义关闭按钮吗？**
A: The close button is part of the control template. To customize it, redefine
the `ControlTheme` and replace `PART_CloseButton`, or keep the built-in button
and style the `OverlayCloseButton` theme resource.

**Q: How do I hide the icon? / 如何隐藏图标？**
A: Set `ShowIcon="False"`. The entire icon panel is removed from layout.

**Q: What's the difference between Banner and Notification?**
A: Banner is a persistent inline element that stays in the document flow.
Notification is a transient popup/toast that auto-dismisses. Use Banner for
inline page-level messages, Notification for corner popups.

**Q: How does the close button hide the banner? / 关闭按钮如何隐藏横幅？**
A: The `OnCloseClick` handler calls `SetCurrentValue(IsVisibleProperty, false)`.
It does not remove the banner from the visual tree — just hides it.
