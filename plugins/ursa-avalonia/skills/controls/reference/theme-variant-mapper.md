---
category: Components
title: ThemeVariantMapper
subtitle: 主题变体映射器
description: 根据父级实际主题变体，通过映射表为子控件应用不同的目标主题。
---

# ThemeVariantMapper / 主题变体映射器

A `ThemeVariantScope` subclass that watches the parent's `ActualThemeVariant` and applies a mapped target theme variant to its descendants. Inherits from `ThemeVariantScope`.

监听父级 `ActualThemeVariant` 并为子控件应用映射目标主题变体的 `ThemeVariantScope` 子类。继承自 `ThemeVariantScope`。

## When to Use / 何时使用

Use `ThemeVariantMapper` when you need to remap one theme variant to another for a visual subtree — e.g., force a dark-mode sidebar inside a light-mode window, or apply a custom brand theme (`SemiTheme`) when the system is in dark mode. It works by defining `Mappings` entries that map `Source` (parent's actual theme) → `Target` (theme to apply to children).

当你需要为某个视觉子树将一种主题变体重新映射为另一种时使用 —— 如在浅色主题窗口中强制深色侧边栏，或在系统深色模式下应用自定义品牌主题（`SemiTheme`）。通过定义 `Mappings` 条目，将 `Source`（父级实际主题）映射到 `Target`（应用于子的主题）。

## Basic Usage / 基本使用

When parent is `Light`, apply `Dark` to children. Default fallback inherits parent:

```xml
<ursa:ThemeVariantMapper>
    <ursa:ThemeVariantMapper.Mappings>
        <ursa:ThemeVariantMapping Source="Light" Target="Dark" />
    </ursa:ThemeVariantMapper.Mappings>
    <!-- Children here see Dark theme when parent is Light -->
    <Button Content="Dark inside Light" />
</ursa:ThemeVariantMapper>
```

When parent is `Dark`, apply a custom `SemiTheme`:

```xml
<ursa:ThemeVariantMapper>
    <ursa:ThemeVariantMapper.Mappings>
        <ursa:ThemeVariantMapping Source="Dark"
                                  Target="{StaticResource SemiTheme}" />
    </ursa:ThemeVariantMapper.Mappings>
    <StackPanel>
        <Button Content="Semi inside Dark" />
    </StackPanel>
</ursa:ThemeVariantMapper>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Mappings` | `AvaloniaList<ThemeVariantMapping>` | Collection of source→target pairing rules. Evaluated in order; first match wins. / source→target 配对规则集合。按顺序评估，首个匹配胜出。 |

### ThemeVariantMapping / 主题变体映射条目

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Source` | `ThemeVariant?` | The parent theme variant to match against. Use `ThemeVariant.Light` / `ThemeVariant.Dark` / `ThemeVariant.Default`. / 需要匹配的父级主题变体。 |
| `Target` | `ThemeVariant?` | The theme variant to apply to descendants when `Source` matches. A `null` or `Default` Target inherits the parent theme unchanged. / 当 `Source` 匹配时应用于后代控件的主题变体。 |

## Styling & Templating / 样式与模板

`StyleKeyOverride` returns `typeof(ThemeVariantScope)`, so it reuses the standard `ThemeVariantScope` style. No custom template — acts purely as a logical behavior layer. Inherits styling from parent `ThemeVariantScope`.

`StyleKeyOverride` 返回 `typeof(ThemeVariantScope)`，复用标准 `ThemeVariantScope` 样式。无自定义模板 —— 仅作为逻辑行为层。样式继承父级 `ThemeVariantScope`。

## FAQ / 常见问题

**Q: ThemeVariantMapper vs. ThemeVariantScope? / ThemeVariantMapper 与 ThemeVariantScope 的区别？**

A: `ThemeVariantScope` applies a single fixed theme to all descendants via `RequestedThemeVariant`. `ThemeVariantMapper` is *reactive* — it watches the parent's `ActualThemeVariant` and dynamically applies the first matching `Target` from `Mappings`. Use `ThemeVariantScope` for static theme overrides; use `ThemeVariantMapper` when the applied theme depends on the parent's current theme.

`ThemeVariantScope` 通过 `RequestedThemeVariant` 对所有后代应用单一固定主题。`ThemeVariantMapper` 是*响应式*的 —— 监视父级 `ActualThemeVariant` 并动态应用 `Mappings` 中首个匹配的 `Target`。静态覆盖使用 `ThemeVariantScope`；应用的主题取决于父级主题时使用 `ThemeVariantMapper`。

**Q: What happens when no mapping matches? / 没有映射匹配时会发生什么？**

A: The mapper resets to `ThemeVariant.Default`, which causes it to transparently inherit the parent's theme. No override is applied.

映射器重置为 `ThemeVariant.Default`，透明继承父级主题，不应用任何覆盖。
