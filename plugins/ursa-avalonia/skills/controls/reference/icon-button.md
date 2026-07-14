---
category: Buttons
title: IconButton
subtitle: 图标按钮
description: >
  A Button with an icon, supporting four icon placements, loading state, and
  Light/Solid/Outline/Borderless themes plus Colorful AI style.
  带图标的按钮，支持四种图标位置、加载状态，以及 Light/Solid/Outline/Borderless 主题和 Colorful AI 风格。
---

# IconButton / 图标按钮

## When to Use / 何时使用

Use `IconButton` when you need a standard button with an attached icon (emoji,
`PathIcon`, or any `object`). It extends `Button` and adds `Icon`,
`IconPlacement` (Left/Top/Right/Bottom), and `IsLoading` properties. Choose
`IconButton` over a plain `Button` whenever an icon is needed — it handles icon
placement, loading spinners, and theme variants like Solid, Outline, and
Borderless out of the box.

当标准按钮需要附带图标（表情、`PathIcon` 或任意对象）时使用 `IconButton`。
它继承自 `Button`，并增加了 `Icon`、`IconPlacement`（Left/Top/Right/Bottom）
和 `IsLoading` 属性。任何需要图标的场景都应优先选择 `IconButton`——它内置
处理图标位置、加载动画，以及 Solid、Outline、Borderless 等主题变体。

Avoid `IconButton` when you need a split button or dropdown — use the sibling
controls `IconDropDownButton`, `IconSplitButton`, `IconToggleButton`, etc.

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<!-- Icon-only (no content) -->
<u:IconButton Icon="🐼" />

<!-- Icon with text (default: icon left) -->
<u:IconButton Icon="🐼" Content="Click me" />

<!-- Using a PathIcon resource -->
<u:IconButton Icon="{StaticResource SemiIconCamera}" Content="Camera" />

<!-- Loading state -->
<u:IconButton Icon="{StaticResource SemiIconCamera}" Content="Uploading" IsLoading="True" />
```

## Common Scenarios / 常用场景

### 1. Icon placement variants / 图标位置变体

```xml
<u:IconButton Icon="🐼" Content="Left (default)"
              IconPlacement="Left" />
<u:IconButton Icon="🐼" Content="Right"
              IconPlacement="Right" />
<u:IconButton Icon="🐼" Content="Top"
              IconPlacement="Top" />
<u:IconButton Icon="🐼" Content="Bottom"
              IconPlacement="Bottom" />
```

### 2. Semantic color classes / 语义颜色类

```xml
<u:IconButton Icon="{StaticResource SemiIconCamera}" Content="Default" />
<u:IconButton Icon="{StaticResource SemiIconCamera}" Content="Primary" Classes="Primary" />
<u:IconButton Icon="{StaticResource SemiIconCamera}" Content="Secondary" Classes="Secondary" />
<u:IconButton Icon="{StaticResource SemiIconCamera}" Content="Tertiary" Classes="Tertiary" />
<u:IconButton Icon="{StaticResource SemiIconCamera}" Content="Success" Classes="Success" />
<u:IconButton Icon="{StaticResource SemiIconCamera}" Content="Warning" Classes="Warning" />
<u:IconButton Icon="{StaticResource SemiIconCamera}" Content="Danger" Classes="Danger" />
```

### 3. Theme variants (Solid / Outline / Borderless) / 主题变体

```xml
<!-- Solid fill -->
<u:IconButton Icon="{StaticResource SemiIconCamera}" Content="Solid Primary"
              Classes="Primary" Theme="{DynamicResource SolidIconButton}" />

<!-- Outline -->
<u:IconButton Icon="{StaticResource SemiIconCamera}" Content="Outline Primary"
              Classes="Primary" Theme="{DynamicResource OutlineIconButton}" />

<!-- Borderless (minimal chrome, e.g. title bar controls) -->
<u:IconButton Icon="{StaticResource SemiIconCamera}" Content="Borderless Tertiary"
              Classes="Tertiary" Theme="{DynamicResource BorderlessIconButton}" />
```

### 4. Colorful AI style / Colorful AI 风格

```xml
<u:IconButton Icon="{StaticResource SemiIconAIFilled}"
              Content="Colorful Primary"
              Classes="Colorful Primary" />

<u:IconButton Icon="{StaticResource SemiIconAIFilled}"
              Content="Colorful Solid"
              Classes="Colorful Primary"
              Theme="{DynamicResource SolidIconButton}" />
```

### 5. Size variants / 尺寸变体

```xml
<u:IconButton Icon="🐼" Content="Large" Classes="Large" />
<u:IconButton Icon="🐼" Content="Default" />
<u:IconButton Icon="🐼" Content="Small" Classes="Small" />
```

### 6. Loading state with async command / 异步加载状态

```xml
<u:IconButton Icon="{StaticResource SemiIconUpload}"
              Content="{Binding ButtonText}"
              Command="{Binding UploadCommand}"
              IsLoading="{Binding IsUploading}" />
```

```csharp
// In ViewModel
public bool IsUploading { get; set; }
public string ButtonText => IsUploading ? "Uploading…" : "Upload";
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default | Description / 说明 |
|---|---|---|---|
| `Icon` | `object?` | `null` | The icon content displayed alongside the button text / 按钮文字旁的图标内容 |
| `IconTemplate` | `IDataTemplate?` | `null` | Data template for rendering the icon / 图标的 DataTemplate |
| `IconPlacement` | `Position` | `Left` | Icon position: `Left`, `Top`, `Right`, or `Bottom` / 图标位置 |
| `IsLoading` | `bool` | `false` | When `true`, shows a `LoadingIcon` spinner instead of the icon / 为 `true` 时显示 LoadingIcon 旋转动画替代图标 |

Inherits all properties from `Button` (`Command`, `CommandParameter`, `Content`, `IsEnabled`, `Click`, etc.).

继承 `Button` 的全部属性。

### Position enum / Position 枚举

| Value | Description / 说明 |
|---|---|
| `Left` | Icon appears left of text (default) / 图标在文字左侧（默认） |
| `Top` | Icon appears above text / 图标在文字上方 |
| `Right` | Icon appears right of text / 图标在文字右侧 |
| `Bottom` | Icon appears below text / 图标在文字下方 |

## Events / 事件

| Event / 事件 | Description / 说明 |
|---|---|
| `Click` | Inherited from `Button`. Fires when the button is clicked / 继承自 Button，点击时触发 |

No custom events beyond `Button`.

## Styling & Templating / 样式与模板

### Theme Keys / 主题 Key

| Theme Key | Description / 说明 |
|---|---|
| `{x:Type u:IconButton}` | Default theme (Light, subtle background) / 默认 Light 主题 |
| `SolidIconButton` | Solid fill variant — filled background per semantic class / Solid 填充变体 |
| `OutlineIconButton` | Outline variant — transparent background, colored border / 描边变体 |
| `BorderlessIconButton` | Borderless variant — no background or border (minimal) / 无边框变体 |

### Style Classes / 样式类

| Class | Description / 说明 |
|---|---|
| `Primary` | Primary semantic color / 主要语义色 |
| `Secondary` | Secondary semantic color / 次要语义色 |
| `Tertiary` | Tertiary semantic color / 三级语义色 |
| `Success` | Success (green) semantic color / 成功颜色 |
| `Warning` | Warning (orange) semantic color / 警告颜色 |
| `Danger` | Danger (red) semantic color / 危险颜色 |
| `Colorful` | Enables Colorful AI gradient style (use with `Primary` or `Tertiary`) / 启用 AI 渐变风格 |
| `Large` | Large size (`ButtonLargeHeight` + `ButtonLargePadding`) / 大尺寸 |
| `Small` | Small size (`ButtonSmallHeight` + `ButtonSmallPadding`) / 小尺寸 |

### Pseudo-classes / 伪类

| Pseudo-class | Condition / 条件 |
|---|---|
| `:left` | `IconPlacement == Left` and icon is not null |
| `:right` | `IconPlacement == Right` and icon is not null |
| `:top` | `IconPlacement == Top` and icon is not null |
| `:bottom` | `IconPlacement == Bottom` and icon is not null |
| `:empty` | Icon is null |
| `:empty-content` | `Content` is null |
| `:pointerover` | Mouse hover (inherited from Button) |
| `:pressed` | Button pressed (inherited from Button) |
| `:disabled` | Button disabled (inherited from Button) |

### Template Parts / 模板部件

| Part Name | Type | Description / 说明 |
|---|---|---|
| `PART_RootPanel` | `Panel` | Root layout panel (a `ReversibleStackPanel` in the default template) / 根布局面板 |

### Theme Resources / 主题资源

IconButton uses the standard `Button*` resource keys (e.g. `ButtonDefaultBackground`,
`ButtonDefaultPrimaryForeground`, `ButtonCornerRadius`, etc.). See the Ursa theme
resource reference for the full list.

## FAQ / 常见问题

**Q: How do I use an emoji as icon? / 如何使用表情作为图标？**
A: Set `Icon="🐼"` or any Unicode emoji directly. The icon content presenter
inherits `ContentPresenter` behavior — strings, `PathIcon`, and arbitrary
`Control` instances all work.

**Q: What's the difference between IconButton and IconRepeatButton?**
A: `IconRepeatButton` fires `Click` repeatedly while pressed (like a spin button
arrow). `IconButton` fires once per click. Both share the same icon placement
and theme infrastructure.

**Q: How do I change the loading spinner color? / 如何改变加载动画颜色？**
A: The `LoadingIcon` inside the template inherits `Foreground` from
`PART_ContentPresenter`. Set `Foreground` on the `IconButton`:

```xml
<u:IconButton Icon="🐼" Content="Loading" IsLoading="True"
              Foreground="{DynamicResource SemiBlue5}" />
```

**Q: Can I use IconButton without any text?**
A: Yes. Omit `Content` entirely. When `Content` is null, the `:empty-content`
pseudo-class is set, and the button renders as a square icon-only button with
`MinWidth` matching `MinHeight`.
