---
category: Components
title: ThemeVariantMapper
subtitle: 主题变体映射器
description: >
  A ThemeVariantScope subclass that remaps its parent's ActualThemeVariant to
  a different target theme variant for its descendants. Configured via a
  collection of ThemeVariantMapping entries evaluated in order; the first
  matching Source wins. When no mapping matches, the parent theme is inherited
  unchanged. Ideal for inverting themes in sub-regions or swapping theme families.
  一个 ThemeVariantScope 子类，将其父级的 ActualThemeVariant 重映射为不同的目标
  主题变体并应用于其后代。通过按顺序评估的 ThemeVariantMapping 条目集合进行
  配置；第一个匹配的 Source 生效。无匹配时，父级主题不变地继承。适用于在子区域
  反色主题或交换主题系列。
---

# ThemeVariantMapper / 主题变体映射器

## When to Use / 何时使用

Use `ThemeVariantMapper` when you need a sub-tree of the visual tree to render
in a different theme variant than its parent — without changing the parent's
theme. Common cases:

当需要可视树的子树以与父级不同的主题变体渲染而不更改父级主题时使用
`ThemeVariantMapper`。常见情况：

- **Invert Light ↔ Dark** in a specific panel (e.g., a preview pane).
- 在特定面板（如预览窗格）中**反转 Light ↔ Dark**。
- **Map to a custom theme** like `SemiTheme.NightSky` or `SemiTheme.Desert`
  when the parent is Light or Dark.
- 当父级为 Light 或 Dark 时**映射到自定义主题**，如 `SemiTheme.NightSky`
  或 `SemiTheme.Desert`。
- **Send one theme downstream** regardless of the parent.
- **向下传递一个固定主题**，无论父级主题如何。

Do NOT use `ThemeVariantMapper` to globally change the application theme — use
`ThemeToggleButton` or set `Application.RequestedThemeVariant` directly.

不要使用 `ThemeVariantMapper` 全局更改应用程序主题——应使用 `ThemeToggleButton`
或直接设置 `Application.RequestedThemeVariant`。

## Basic Usage / 基本使用

### Invert Light ↔ Dark / 反转 Light ↔ Dark

```xml
xmlns:u="https://irihi.tech/ursa"

<ThemeVariantScope RequestedThemeVariant="Light">
    <Border Theme="{DynamicResource CardBorder}">
        <TextBlock Text="Parent: Light" />

        <u:ThemeVariantMapper>
            <u:ThemeVariantMapper.Mappings>
                <u:ThemeVariantMapping Source="Light" Target="Dark" />
                <u:ThemeVariantMapping Source="Dark" Target="Light" />
            </u:ThemeVariantMapper.Mappings>

            <Border Theme="{DynamicResource CardBorder}">
                <TextBlock Text="This renders in Dark" />
                <Button Content="Dark-mode Button" />
            </Border>
        </u:ThemeVariantMapper>
    </Border>
</ThemeVariantScope>
```

The `ThemeVariantMapper` listens to its visual parent's `ActualThemeVariant`.
When the parent is `Light`, the mapper applies `Dark` to its descendants.

`ThemeVariantMapper` 监听其可视父级的 `ActualThemeVariant`。当父级为 `Light`
时，映射器对其后代应用 `Dark`。

### Map to custom SemiTheme / 映射到自定义 SemiTheme

```xml
xmlns:semi="https://irihi.tech/semi"

<u:ThemeVariantMapper>
    <u:ThemeVariantMapper.Mappings>
        <u:ThemeVariantMapping
            Source="Light"
            Target="{x:Static semi:SemiTheme.NightSky}" />
        <u:ThemeVariantMapping
            Source="Dark"
            Target="{x:Static semi:SemiTheme.Desert}" />
    </u:ThemeVariantMapper.Mappings>

    <Button Content="Themed Button" />
</u:ThemeVariantMapper>
```

### Single mapping (no fallthrough) / 单映射（无穿透）

```xml
<u:ThemeVariantMapper>
    <u:ThemeVariantMapper.Mappings>
        <u:ThemeVariantMapping Source="Dark" Target="Light" />
    </u:ThemeVariantMapper.Mappings>

    <TextBlock Text="Only maps Dark → Light" />
</u:ThemeVariantMapper>
```

When the parent is `Light`, no mapping matches, so `Light` passes through
unchanged. When the parent is `Dark`, it maps to `Light`.

当父级为 `Light` 时，无匹配的映射，因此 `Light` 不变地传递。当父级为 `Dark`
时，映射为 `Light`。

## Common Scenarios / 常用场景

### 1. Preview pane with inverted theme / 带反色主题的预览窗格

```xml
<DockPanel>
    <Border Theme="{DynamicResource CardBorder}" DockPanel.Dock="Top">
        <TextBlock Text="Editor (Dark mode)" />
    </Border>

    <u:ThemeVariantMapper>
        <u:ThemeVariantMapper.Mappings>
            <u:ThemeVariantMapping Source="Dark" Target="Light" />
        </u:ThemeVariantMapper.Mappings>

        <Border Theme="{DynamicResource CardBorder}">
            <TextBlock Text="Preview (Light mode)" />
            <Button Content="Preview Button" />
        </Border>
    </u:ThemeVariantMapper>
</DockPanel>
```

### 2. Dynamic parent switching with mapper / 动态父级切换 + 映射器

```xml
<StackPanel>
    <Button Content="Set Light" Click="OnSetLight" />
    <Button Content="Set Dark" Click="OnSetDark" />

    <ThemeVariantScope Name="parentScope">
        <u:ThemeVariantMapper Name="mapper">
            <u:ThemeVariantMapper.Mappings>
                <u:ThemeVariantMapping
                    Source="Light"
                    Target="{x:Static semi:SemiTheme.NightSky}" />
                <u:ThemeVariantMapping
                    Source="Dark"
                    Target="{x:Static semi:SemiTheme.Desert}" />
            </u:ThemeVariantMapper.Mappings>

            <Button Content="Mapped Button" />
        </u:ThemeVariantMapper>
    </ThemeVariantScope>
</StackPanel>
```

```csharp
private void OnSetLight(object? s, RoutedEventArgs e)
    => parentScope.RequestedThemeVariant = ThemeVariant.Light;
private void OnSetDark(object? s, RoutedEventArgs e)
    => parentScope.RequestedThemeVariant = ThemeVariant.Dark;
```

The mapper reacts immediately to parent theme changes.

映射器立即响应父级主题更改。

## Property Reference / 属性参考

### ThemeVariantMapper Properties / ThemeVariantMapper 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Mappings` | `AvaloniaList<ThemeVariantMapping>` | `[]` | Ordered list of mapping rules. First match wins. / 有序的映射规则列表。第一个匹配的生效。 |

### ThemeVariantMapping Properties / ThemeVariantMapping 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Source` | `ThemeVariant?` | `null` | The parent theme variant to match / 要匹配的父级主题变体 |
| `Target` | `ThemeVariant?` | `null` | The theme variant to apply when Source matches. Set to `ThemeVariant.Default` to inherit parent theme. / Source 匹配时应用的主题变体。设为 `ThemeVariant.Default` 则继承父级主题。 |

### Behavior / 行为

| Condition / 条件 | Result / 结果 |
|---|---|
| A `Source` matches the parent's `ActualThemeVariant` | `RequestedThemeVariant` is set to the matching entry's `Target` |
| No `Source` matches | `RequestedThemeVariant` is reset to `ThemeVariant.Default` (inherit parent) / 重置为 `ThemeVariant.Default`（继承父级） |
| Parent's `ActualThemeVariant` changes | `ApplyMapping()` is called immediately via `PropertyChanged` subscription / 通过 `PropertyChanged` 订阅立即调用 `ApplyMapping()` |
| `Mappings` collection changes | `ApplyMapping()` is called immediately / 立即调用 `ApplyMapping()` |

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

`ThemeVariantMapper` inherits from `ThemeVariantScope` with
`StyleKeyOverride = typeof(ThemeVariantScope)`. It uses the standard
`ThemeVariantScope` theme. No custom resources are defined.

`ThemeVariantMapper` 继承自 `ThemeVariantScope`，设置
`StyleKeyOverride = typeof(ThemeVariantScope)`。使用标准 `ThemeVariantScope`
主题。未定义自定义资源。

### Template / 模板

As a `ThemeVariantScope` subclass, `ThemeVariantMapper` has no visual template
of its own — it is a layout-invisible scope element. It affects theme resolution
for its descendants but renders no chrome.

作为 `ThemeVariantScope` 的子类，`ThemeVariantMapper` 没有自己的可视模板——
它是一个布局不可见的作用域元素。它影响其后代的主题解析，但不渲染任何边框
装饰。

## FAQ / 常见问题

**Q: How is this different from ThemeVariantScope? / 这与 ThemeVariantScope 有何不同？**
A: `ThemeVariantScope` sets a fixed `RequestedThemeVariant` for its descendants.
`ThemeVariantMapper` dynamically computes the `RequestedThemeVariant` based on
the parent's `ActualThemeVariant` and the configured `Mappings`. It reacts to
parent theme changes automatically.

`ThemeVariantScope` 为其后代设置固定的 `RequestedThemeVariant`。
`ThemeVariantMapper` 根据父级的 `ActualThemeVariant` 和配置的 `Mappings`
动态计算 `RequestedThemeVariant`。它会自动响应父级主题变化。

**Q: Can I map to custom ThemeVariant values? / 可以映射到自定义 ThemeVariant 值吗？**
A: Yes. Any `ThemeVariant` can be used as `Source` or `Target`, including
`ThemeVariant.Light`, `ThemeVariant.Dark`, `ThemeVariant.Default`, or custom
variants like `SemiTheme.NightSky`.

可以。任何 `ThemeVariant` 都可以用作 `Source` 或 `Target`，包括
`ThemeVariant.Light`、`ThemeVariant.Dark`、`ThemeVariant.Default`，或自定义
变体如 `SemiTheme.NightSky`。

**Q: What happens if I set Target to ThemeVariant.Default? / 如果将 Target 设为 ThemeVariant.Default 会怎样？**
A: `ThemeVariant.Default` means "inherit the parent's theme unchanged." The
descendants will render in whatever theme the parent provides, as if the
`ThemeVariantMapper` were not present.

`ThemeVariant.Default` 表示"不变地继承父级主题"。后代将以父级提供的主题
渲染，就像 `ThemeVariantMapper` 不存在一样。

**Q: Can I have multiple mappers nested? / 可以嵌套多个映射器吗？**
A: Yes. Each `ThemeVariantMapper` evaluates against its own visual parent.
Nested mappers form a chain of remappings.

可以。每个 `ThemeVariantMapper` 根据其自身的可视父级进行评估。嵌套的映射器
形成重映射链。

**Q: Does the mapper affect the parent's theme? / 映射器会影响父级主题吗？**
A: No. `ThemeVariantMapper` only sets its own `RequestedThemeVariant`, which
affects its descendants. The parent scope is untouched.

不会。`ThemeVariantMapper` 仅设置自身的 `RequestedThemeVariant`，这会影响
其后代。父级作用域不受影响。
