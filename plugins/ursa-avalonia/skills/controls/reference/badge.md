---
category: Components
title: Badge
subtitle: 徽标
description: >
  Displays a notification badge (count, text, or dot) on top of wrapped content.
  Supports corner positioning, overflow count, color themes, dot mode, and
  Light/Inverted style variants. Wraps any control with a positioned indicator.
  在包裹内容上显示通知徽标（数字、文字或圆点）。支持角定位、溢出数量、颜色主题、
  圆点模式和 Light/Inverted 样式变体。可包裹任意控件并附加定位指示器。
---

# Badge / 徽标

## When to Use / 何时使用

Use `Badge` to overlay a notification count, status dot, or short text label
on top of another control — typically an avatar, icon button, or tab. The badge
is positioned at a configurable corner and auto-centers based on its own size.

使用 `Badge` 在另一个控件（通常是头像、图标按钮或标签）上叠加通知数量、状态
圆点或短文本标签。徽标定位在可配置的角落，并根据自身尺寸自动居中。

Do NOT use Badge for standalone inline labels — use `Tag` or a styled `Border`
instead. Badge is designed to be anchored to parent content.

不要将 Badge 用于独立的内联标签——应使用 `Tag` 或带样式的 `Border`。Badge 设计
为锚定在父级内容上。

## Basic Usage / 基本使用

### With count / 带数字

```xml
xmlns:u="https://irihi.tech/ursa"

<u:Badge Header="5">
    <u:Avatar Classes="Square Blue" Content="BM" />
</u:Badge>
```

### Dot mode / 圆点模式

```xml
<u:Badge Dot="True">
    <u:Avatar Classes="Square Blue" Content="YL" />
</u:Badge>
```

### Text label / 文字标签

```xml
<u:Badge Header="NEW">
    <u:Avatar Classes="Square LightBlue" Content="WF" />
</u:Badge>
```

### Custom Header (icon) / 自定义标头（图标）

```xml
<u:Badge>
    <u:Badge.Header>
        <PathIcon Theme="{StaticResource InnerPathIcon}"
                  Data="{StaticResource SemiIconLock}" />
    </u:Badge.Header>
    <u:Avatar Classes="Square Blue" Content="YL" />
</u:Badge>
```

The `Header` property (inherited from `HeaderedContentControl`) is used as the
badge label. It supports both plain text and complex content.

`Header` 属性（继承自 `HeaderedContentControl`）用作徽标标签。支持纯文本和
复杂内容。

## Common Scenarios / 常用场景

### 1. Positioned badge with color theme / 带位置和颜色主题的徽标

```xml
<u:Badge Header="99+" CornerPosition="BottomRight" Classes="Danger">
    <Button Content="Messages" />
</u:Badge>
```

### 2. Overflow count / 溢出数量

```xml
<u:Badge Header="150" OverflowCount="99">
    <u:Avatar Classes="Green" Content="PM" />
</u:Badge>
<!-- Displays "99+" instead of "150" -->
```

When `Header` is a numeric string and exceeds `OverflowCount`, the badge
displays `{OverflowCount}+` via `BadgeContentOverflowConverter`.

当 `Header` 是数字字符串且超过 `OverflowCount` 时，徽标显示
`{OverflowCount}+`，由 `BadgeContentOverflowConverter` 处理。

### 3. Light variant / 浅色变体

```xml
<u:Badge Classes="Light Primary" Header="5">
    <u:Avatar Classes="Blue" Content="AB" />
</u:Badge>
```

The `Light` class swaps to lighter background/foreground variants. Combine with
semantic classes like `Primary`, `Success`, `Warning`, `Danger`.

`Light` 类切换到更浅的背景/前景变体。可与 `Primary`、`Success`、`Warning`、
`Danger` 等语义类组合使用。

### 4. Inverted variant / 反色变体

```xml
<u:Badge Classes="Inverted" Header="3">
    <u:Avatar Classes="Dark" Content="CD" />
</u:Badge>
```

## Property Reference / 属性参考

### Badge Properties / Badge 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Header` | `object?` | `null` | Badge text/label (inherited) / 徽标文字/标签（继承） |
| `HeaderTemplate` | `IDataTemplate?` | `null` | Template for the badge header / 徽标标题模板 |
| `Dot` | `bool` | `false` | Display as a small dot (hides header text) / 显示为小圆点（隐藏标题文字） |
| `CornerPosition` | `CornerPosition` | (theme) | Which corner the badge anchors to / 徽标锚定的角落 |
| `OverflowCount` | `int` | `0` | Max count before showing "N+" / 显示 "N+" 前的最大数量 |
| `BadgeFontSize` | `double` | (theme) | Font size of the badge text / 徽标文字字号 |
| `BadgeTheme` | `ControlTheme` | `null` | Optional custom theme for the badge container / 徽标容器的可选自定义主题 |

### CornerPosition Enum / CornerPosition 枚举

| Value | Position / 位置 |
|---|---|
| `TopLeft` | Top-left corner / 左上角 |
| `TopRight` | Top-right corner / 右上角 |
| `BottomLeft` | Bottom-left corner / 左下角 |
| `BottomRight` | Bottom-right corner / 右下角 |

## Styling & Templating / 样式与模板

### Style Classes / 样式类

#### Semantic Theme Classes / 语义主题类

| Class | Description / 说明 |
|---|---|
| `Primary` | Primary color theme / 主色主题 |
| `Secondary` | Secondary color theme / 次色主题 |
| `Tertiary` | Tertiary color theme / 第三色主题 |
| `Success` | Success/green theme / 成功/绿色主题 |
| `Warning` | Warning/orange theme / 警告/橙色主题 |
| `Danger` | Danger/red theme / 危险/红色主题 |

#### Variant Classes / 变体类

| Class | Effect |
|---|---|
| `Light` | Uses lighter foreground/background variants for all semantic classes / 为所有语义类使用更浅的前景/背景变体 |
| `Inverted` | Uses inverted foreground/background variants / 使用反色前景/背景变体 |

Semantic classes set `Background` on `PART_BadgeContainer`. `Light` and
`Inverted` override foreground/background via dedicated resource keys.

语义类在 `PART_BadgeContainer` 上设置 `Background`。`Light` 和 `Inverted`
通过专用资源键覆盖前景/背景。

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `BadgeForeground` | Header text | Default text color / 默认文字颜色 |
| `BadgeFontSize` | Header text | Default font size / 默认字号 |
| `BadgeCornerRadius` | Badge border | Pill-shaped corner radius / 胶囊形圆角 |
| `BadgeBorderThickness` | Badge border | Border thickness / 边框粗细 |
| `BadgeBorderBrush` | Badge border | Border brush / 边框画刷 |
| `BadgeMinWidth` | Dot badge | Minimum width for dot mode / 圆点模式最小宽度 |
| `BadgeMinHeight` | Dot badge | Minimum height for dot mode / 圆点模式最小高度 |
| `BadgeDotWidth` | Dot badge | Width when `Dot=True` / `Dot=True` 时的宽度 |
| `BadgeDotHeight` | Dot badge | Height when `Dot=True` / `Dot=True` 时的高度 |
| `BadgePadding` | Badge container | Inner padding / 内边距 |
| `BadgePrimaryBadgeBackground` | Primary | Primary background / 主色背景 |
| `BadgeSecondaryBadgeBackground` | Secondary | Secondary background / 次色背景 |
| `BadgeTertiaryBadgeBackground` | Tertiary | Tertiary background / 第三色背景 |
| `BadgeSuccessBadgeBackground` | Success | Success background / 成功背景 |
| `BadgeWarningBadgeBackground` | Warning | Warning background / 警告背景 |
| `BadgeDangerBadgeBackground` | Danger | Danger background / 危险背景 |
| `BadgeLight{*}BadgeForeground` | Light + semantic | Light variant foregrounds / 浅色变体前景 |
| `BadgeLight{*}BadgeBackground` | Light + semantic | Light variant backgrounds / 浅色变体背景 |
| `BadgeInvertedBadgeBackground` | Inverted | Inverted background / 反色背景 |
| `BadgeInverted{*}BadgeForeground` | Inverted + semantic | Inverted variant foregrounds / 反色变体前景 |
| `BadgeContentForeground` | Content area | Foreground for wrapped content / 包裹内容的前景色 |

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_ContentPresenter` | `Badge` | `ContentPresenter` |
| `PART_BadgeContainer` | `Badge` | `Border` |
| `PART_HeaderPresenter` | `Badge` | `ContentPresenter` |

## FAQ / 常见问题

**Q: How do I show just a red dot without a number?**
A: Set `Dot="True"`. This hides the header text and sizes the badge to a
fixed small circle.

**Q: How do I change the badge position? / 如何更改徽标位置？**
A: Set `CornerPosition` to one of `TopLeft`, `TopRight`, `BottomLeft`, or
`BottomRight`. The badge auto-centers at the chosen corner.

**Q: How does overflow count work? / 溢出数量如何工作？**
A: When `Header` is a numeric value greater than `OverflowCount`, the display
shows `{OverflowCount}+`. For example, `Header="150" OverflowCount="99"`
renders "99+".

**Q: Can the content be any control? / 内容可以是任意控件吗？**
A: Yes. The `Content` property accepts any `Control` — avatars, buttons, icons,
images, etc. The badge overlays on top regardless of content type.

**Q: How do I customize badge colors? / 如何自定义徽标颜色？**
A: Use semantic classes (`Primary`, `Success`, etc.) for preset colors, or
override theme resource keys. For full control, set `BadgeTheme` to a custom
`ControlTheme`.
