---
category: Components
title: Avatar
subtitle: 头像
description: >
  Displays a user avatar with text initials, image, or custom content. Supports
  color classes, size classes, square shape, and an optional hover mask overlay.
  Inherits from Button for click interactions.
  显示用户头像，支持文字缩写、图片或自定义内容。支持颜色类、尺寸类、方形形状和
  可选的悬停遮罩叠加层。继承自 Button 以支持点击交互。
---

# Avatar / 头像

## When to Use / 何时使用

Use `Avatar` to represent a user, entity, or object with a visual identifier —
typically a profile picture, initials, or icon. It supports 16 preset color
classes, 8 size classes, and an optional square shape.

使用 `Avatar` 以视觉标识符表示用户、实体或对象——通常是头像图片、缩写或图标。
支持 16 种预设颜色类、8 种尺寸类和可选的方形形状。

Do NOT use Avatar as a general-purpose image container — use `Image` instead.
Avatar is specifically designed for circular/rounded identity representation.

不要将 Avatar 用作通用图片容器——应使用 `Image`。Avatar 专为圆形/圆角的身份
标识而设计。

## Basic Usage / 基本使用

### Default (text initials) / 默认（文字缩写）

```xml
xmlns:u="https://irihi.tech/ursa"

<u:Avatar Content="AS" Classes="Blue" />
```

### With image source / 带图片源

```xml
<u:Avatar Source="avares://MyApp/Assets/avatar.png" />
```

### With hover mask / 带悬停遮罩

```xml
<u:Avatar Content="Ursa">
    <u:Avatar.HoverMask>
        <TextBlock Text="Edit" VerticalAlignment="Center"
                   HorizontalAlignment="Center" />
    </u:Avatar.HoverMask>
</u:Avatar>
```

When the mouse hovers over the avatar, the `HoverMask` content is shown as an
overlay. The `PART_HoverMask` `ContentPresenter` is only visible on
`:pointerover` and only when `HoverMask` is not null.

鼠标悬停在头像上时，`HoverMask` 内容作为叠加层显示。`PART_HoverMask`
`ContentPresenter` 仅在 `:pointerover` 且 `HoverMask` 非空时可见。

## Common Scenarios / 常用场景

### 1. Colored avatar with size / 带颜色和大小的头像

```xml
<StackPanel Orientation="Horizontal" Spacing="8">
    <u:Avatar Content="JD" Classes="Red ExtraSmall" />
    <u:Avatar Content="AS" Classes="Blue Default" />
    <u:Avatar Content="MK" Classes="Green Large" />
</StackPanel>
```

### 2. Square avatar / 方形头像

```xml
<u:Avatar Content="U" Classes="Purple Square Large" />
```

### 3. Avatar as clickable button / 可点击头像

```xml
<u:Avatar Content="Me" Classes="Orange" Command="{Binding OpenProfileCommand}" />
```

`Avatar` inherits from `Button`, so it supports `Command`, `CommandParameter`,
and `Click` event.

`Avatar` 继承自 `Button`，支持 `Command`、`CommandParameter` 和 `Click` 事件。

## Property Reference / 属性参考

### Avatar Properties / Avatar 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Source` | `IImage?` | `null` | Image source; when set, hides text content / 图片源；设置后隐藏文字内容 |
| `HoverMask` | `object?` | `null` | Overlay content shown on pointer hover / 指针悬停时显示的叠加内容 |

### Inherited from Button / 继承自 Button

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Content` | `object?` | `null` | Displayed text (typically initials) / 显示的文本（通常是缩写） |
| `Command` | `ICommand?` | `null` | Command executed on click / 点击时执行的命令 |
| `CommandParameter` | `object?` | `null` | Parameter passed to command / 传递给命令的参数 |
| `IsEnabled` | `bool` | `true` | Whether the avatar is interactive / 头像是否可交互 |
| `ClickMode` | `ClickMode` | `Release` | When the click event fires / 点击事件触发时机 |

## Events / 事件

Avatar inherits all `Button` events including `Click`, `PointerEntered`,
`PointerExited`, etc.

Avatar 继承自 `Button` 的所有事件，包括 `Click`、`PointerEntered`、
`PointerExited` 等。

## Styling & Templating / 样式与模板

### Style Classes / 样式类

#### Color Classes / 颜色类

| Class | Resource Key | Description / 说明 |
|---|---|---|
| `Red` | `AvatarRedBackground` | Red background / 红色背景 |
| `Pink` | `AvatarPinkBackground` | Pink background / 粉色背景 |
| `Purple` | `AvatarPurpleBackground` | Purple background / 紫色背景 |
| `Violet` | `AvatarVioletBackground` | Violet background / 紫罗兰背景 |
| `Indigo` | `AvatarIndigoBackground` | Indigo background / 靛蓝背景 |
| `Blue` | `AvatarBlueBackground` | Blue background / 蓝色背景 |
| `LightBlue` | `AvatarLightBlueBackground` | Light blue background / 浅蓝背景 |
| `Cyan` | `AvatarCyanBackground` | Cyan background / 青色背景 |
| `Teal` | `AvatarTealBackground` | Teal background / 青绿背景 |
| `Green` | `AvatarGreenBackground` | Green background / 绿色背景 |
| `LightGreen` | `AvatarLightGreenBackground` | Light green background / 浅绿背景 |
| `Lime` | `AvatarLimeBackground` | Lime background / 黄绿背景 |
| `Yellow` | `AvatarYellowBackground` | Yellow background / 黄色背景 |
| `Amber` | `AvatarAmberBackground` | Amber background / 琥珀背景 |
| `Orange` | `AvatarOrangeBackground` | Orange background / 橙色背景 |
| `Grey` | `AvatarGreyBackground` | Grey background (default) / 灰色背景（默认） |

#### Shape Class / 形状类

| Class | Effect |
|---|---|
| `Square` | Sets `CornerRadius` to `AvatarSquareCornerRadius` (rounded square) / 设置为方形圆角 |

#### Size Classes / 尺寸类

| Class | Width Resource Key | Font Size Resource Key |
|---|---|---|
| `ExtraExtraSmall` | `AvatarExtraExtraSmallWidth` | `AvatarExtraExtraSmallFontSize` |
| `ExtraSmall` | `AvatarExtraSmallWidth` | `AvatarExtraSmallFontSize` |
| `Small` | `AvatarSmallWidth` | `AvatarSmallFontSize` |
| `Default` | `AvatarDefaultWidth` | `AvatarDefaultFontSize` |
| `Medium` | `AvatarMediumWidth` (default) | `AvatarMediumFontSize` |
| `Large` | `AvatarLargeWidth` | `AvatarLargeFontSize` |
| `ExtraLarge` | `AvatarExtraLargeWidth` | `AvatarExtraLargeFontSize` |

> For `Large` and `ExtraLarge` combined with `Square`, the corner radius uses
> `AvatarLargeSquareCornerRadius` and `AvatarExtraLargeSquareCornerRadius`
> respectively.
>
> `Large` 和 `ExtraLarge` 与 `Square` 组合时，角半径分别使用
> `AvatarLargeSquareCornerRadius` 和 `AvatarExtraLargeSquareCornerRadius`。

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `AvatarForeground` | All | Text/icon foreground color / 文字/图标前景色 |
| `AvatarFontWeight` | All | Text font weight / 文字字重 |
| `AvatarCircleCornerRadius` | Default | Circular corner radius (> width/2) / 圆形角半径 |
| `AvatarSquareCornerRadius` | Square class | Rounded-square corner radius / 方圆形角半径 |
| `Avatar{Grey}Background` | Per-color class | Background brush for each color / 各颜色的背景画刷 |
| `Avatar{Size}Width` | Per-size class | Fixed width/height for each size / 各尺寸的固定宽高 |
| `Avatar{Size}FontSize` | Per-size class | Font size for each size / 各尺寸的字号 |

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_ContentPresenter` | `Avatar` | `ContentPresenter` |

## FAQ / 常见问题

**Q: How do I use an image instead of text?**
A: Set the `Source` property to an `IImage`. When `Source` is set, the text
content is automatically hidden and the image is displayed instead.

**Q: How do I change the avatar size?**
A: Add a size class (e.g., `Classes="Large"`) or set `Width`/`Height` directly.
The 8 built-in sizes range from `ExtraExtraSmall` to `ExtraLarge`.

**Q: How do I make the avatar square instead of round?**
A: Add the `Square` class: `Classes="Blue Square"`.

**Q: Can I combine multiple classes?**
A: Yes. Combine color, size, and shape classes: `Classes="Green Large Square"`.

**Q: How do I handle click events?**
A: Avatar inherits from `Button`. Subscribe to `Click` or bind `Command`.
