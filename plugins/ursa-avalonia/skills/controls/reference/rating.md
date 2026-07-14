---
category: Components
title: Rating
subtitle: 评分
description: 评分组件用于展示和收集用户评分，支持半星、自定义图标和多种尺寸。
---

# Rating / 评分

A star-based rating control that supports fractional values, custom characters, and configurable count. Inherits from `TemplatedControl`.

基于星形的评分控件，支持半星、自定义图标和可配置数量。继承自 `TemplatedControl`。

## When to Use / 何时使用

Use `Rating` when you need to collect or display a numeric rating (e.g., product reviews, satisfaction surveys). Supports half-star precision and clear-on-reclick. For binary like/dislike, use a `ToggleButton` instead.

当你需要收集或展示数值评分时使用（如产品评价、满意度调查）。支持半星精度和点击清除。二元赞/踩场景使用 `ToggleButton` 即可。

## Basic Usage / 基本使用

```xml
<u:Rating Value="{Binding Score}" Count="5" AllowHalf="True" />
```

```csharp
// In ViewModel
public double Score { get; set; } = 3.5;
```

## Common Scenarios / 常用场景

### Default Size Rating / 默认尺寸评分

```xml
<u:Rating Value="3" Count="5" AllowClear="True" />
```

### Small Rating / 小型评分

```xml
<u:Rating Classes="Small" Value="4" Count="5" />
```

### Custom Icon and Color / 自定义图标与颜色

```xml
<u:Rating
    Size="48"
    Value="3"
    Count="5"
    AllowHalf="True"
    Foreground="{StaticResource SemiRed5}"
    Character="{StaticResource SemiIconLikeHeart}" />
```

### Two-Way Binding with AllowClear / 双向绑定与清除

```xml
<u:Rating
    Value="{Binding Value}"
    Count="{Binding Count}"
    AllowClear="{Binding AllowClear}"
    AllowHalf="{Binding AllowHalf}" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Default / 默认值 | Description / 说明 |
| --- | --- | --- | --- |
| `Value` | `double` | `0` | Current rating value. TwoWay binding by default. / 当前评分值，默认双向绑定。 |
| `Count` | `int` | `5` | Total number of rating items. / 评分项总数。 |
| `AllowHalf` | `bool` | `false` | Whether fractional (half) selection is enabled. / 是否允许半选。 |
| `AllowClear` | `bool` | `true` | Whether clicking the same value again clears the rating. / 再次点击相同值是否清除评分。 |
| `Character` | `object` | `null` | Path data or content for each rating icon (defaults to star glyph). / 每个评分项的路径数据或内容。 |
| `Size` | `double` | — | Width/height of each rating character. Set via theme resource `RatingDefaultSize`. / 每个评分项的尺寸。 |
| `DefaultValue` | `double` | `0` | Initial value set when the control loads. / 控件加载时的初始值。 |
| `ItemTemplate` | `IDataTemplate?` | `null` | Template for each rating character item. / 每个评分项的数据模板。 |
| `Items` | `AvaloniaList<RatingCharacter>` | — | Read-only list of internal rating character objects. / 内部评分字符对象的只读列表。 |

### Pseudo-classes / 伪类

| Class / 类名 | Description / 说明 |
| --- | --- |
| `:selected` | Applied to each `RatingCharacter` when it is in the selected range. / 每个被选中的 `RatingCharacter` 会添加此伪类。 |

### Template Parts / 模板部件

| Part | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_ItemsControl` | `ItemsControl` | Hosts the rating character items in a horizontal StackPanel. / 水平排列评分项的容器。 |

## Styling & Templating / 样式与模板

Ursa defines two ControlThemes: one for `Rating` and one for `RatingCharacter`.

Ursa 定义了两个 ControlTheme：`Rating` 和 `RatingCharacter`。

### DynamicResource Keys / 动态资源键

| Key | Description / 说明 |
| --- | --- |
| `RatingStarIconGlyph` | Default star path data for each character. / 默认星形路径数据。 |
| `RatingCharacterBackground` | Unselected character fill color. / 未选中字符的填充色。 |
| `RatingCharacterForeground` | Selected character fill color. / 选中字符的填充色。 |
| `RatingCharacterMargin` | Margin between characters. / 字符间距。 |
| `RatingDefaultSize` | Default character width/height. / 默认字符尺寸。 |
| `RatingSmallSize` | Character size when `Classes="Small"` is applied. / 应用 `Small` 类名时的尺寸。 |

### Style Classes / 样式类

| Class | Description / 说明 |
| --- | --- |
| `Small` | Reduces the rating character size via `RatingSmallSize`. / 通过 `RatingSmallSize` 缩小评分字符。 |

### RatingCharacter Theme / RatingCharacter 主题

Each `RatingCharacter` renders a `Path` from `Character` data over a `Canvas`. A clip-to-bounds `Border` (`PART_IconBorder`) overlays with the foreground fill when `:selected`. On hover, a `scale(1.1)` render transform is applied.

每个 `RatingCharacter` 通过 `Canvas` 中的 `Path` 渲染。选中时 `PART_IconBorder` 叠加前景色。悬停时应用 `scale(1.1)` 渲染变换。

## FAQ / 常见问题

**Q: How do I use a heart or thumbs-up instead of stars? / 如何使用心形或点赞图标代替星形？**

A: Set the `Character` property to custom path geometry data (e.g., `{StaticResource SemiIconLikeHeart}`). / 将 `Character` 属性设置为自定义路径几何数据。

**Q: Does Rating support read-only display mode? / 评分是否支持只读展示模式？**

A: Set `IsEnabled="False"` to disable interaction. The selected value is still displayed. / 设置 `IsEnabled="False"` 可禁用交互，选中值仍会显示。

**Q: How does half-star mouse handling work? / 半星的鼠标处理是如何工作的？**

A: When `AllowHalf` is true, hovering the left half of a character sets it to half-selected. The right half sets it to fully selected. / `AllowHalf` 为 `true` 时，鼠标悬停在字符左半区域设置为半选，右半区域设置为全选。
