---
category: Components
title: ThemeVariantScope
subtitle: 主题变体作用域
description: 装饰器控件，用于将控件子树与局部定义的主题变体隔离开来。
---

# ThemeVariantScope / 主题变体作用域

A decorator control that isolates a subtree of controls with a locally defined `ThemeVariant` (Light or Dark). `ThemeVariantScope` inherits from `Decorator` and wraps a single child. When `RequestedThemeVariant` is set, all `DynamicResource` lookups in the subtree resolve against the specified theme variant instead of the application-level variant. This enables mixed Light/Dark sections within a single window.

将控件子树与局部定义的 `ThemeVariant`（浅色或深色）隔离开来的装饰器控件。`ThemeVariantScope` 继承自 `Decorator` 并包装单个子元素。当设置 `RequestedThemeVariant` 时，子树中的所有 `DynamicResource` 查找将根据指定的主题变体而非应用程序级别的变体进行解析。这使得在单个窗口中可以混合使用浅色/深色区域。

## When to Use / 何时使用

Use `ThemeVariantScope` when you need a portion of the UI to use a different theme variant than the rest of the application — a dark sidebar in a light-themed app, a light document preview in a dark-themed app, theme-aware embedded content, or any scenario requiring per-section theme overrides.

当你需要 UI 的一部分使用与应用程序其余部分不同的主题变体时使用 `ThemeVariantScope` —— 浅色主题应用中的深色侧边栏、深色主题应用中的浅色文档预览、主题感知的嵌入内容，或任何需要按区域覆盖主题的场景。

## Basic Usage / 基本使用

```xml
<!-- Force Dark variant for a specific section -->
<ThemeVariantScope RequestedThemeVariant="Dark">
    <Border Padding="16"
            Background="{DynamicResource WindowDefaultBackground}">
        <TextBlock Text="This section is always Dark."
                   Foreground="{DynamicResource WindowDefaultForeground}" />
    </Border>
</ThemeVariantScope>
```

```csharp
// Programmatic creation
var darkScope = new ThemeVariantScope
{
    RequestedThemeVariant = ThemeVariant.Dark,
    Child = new Border
    {
        Padding = new Thickness(16),
        Background = Brushes.Black, // or DynamicResource
        Child = new TextBlock
        {
            Text = "Always dark content",
            Foreground = Brushes.White
        }
    }
};
```

## Common Scenarios / 常用场景

### Dark Sidebar in Light App / 浅色应用中的深色侧边栏

```xml
<DockPanel>
    <!-- Dark-themed sidebar -->
    <ThemeVariantScope RequestedThemeVariant="Dark"
                       DockPanel.Dock="Left">
        <Border Width="240"
                Background="{DynamicResource WindowDefaultBackground}">
            <StackPanel Spacing="8" Margin="12">
                <TextBlock Text="Navigation"
                           Foreground="{DynamicResource WindowDefaultForeground}"
                           FontWeight="Bold" />
                <Button Content="Dashboard"
                        Theme="{DynamicResource BorderlessButton}" />
                <Button Content="Settings"
                        Theme="{DynamicResource BorderlessButton}" />
            </StackPanel>
        </Border>
    </ThemeVariantScope>

    <!-- Light-themed main content -->
    <Border Background="{DynamicResource WindowDefaultBackground}">
        <TextBlock Text="Main Content Area" Margin="16" />
    </Border>
</DockPanel>
```

### Document Preview with Opposite Theme / 使用相反主题的文档预览

```xml
<!-- Light app, dark document preview -->
<Border Padding="8"
        Background="{DynamicResource SecondaryLight}"
        CornerRadius="8">
    <TextBlock Text="Document Preview" FontWeight="Bold" Margin="0,0,0,8" />
    <ThemeVariantScope RequestedThemeVariant="Dark">
        <Border Padding="16"
                CornerRadius="4"
                Background="{DynamicResource WindowDefaultBackground}">
            <SelectableTextBlock Text="{Binding DocumentContent}"
                                 FontFamily="Cascadia Code"
                                 Foreground="{DynamicResource WindowDefaultForeground}" />
        </Border>
    </ThemeVariantScope>
</Border>
```

### Resetting to Parent Theme / 重置为父级主题

Set `RequestedThemeVariant="{x:Static ThemeVariant.Default}"` to apply the parent's actual theme variant on the current scope. This is useful for exiting a forced-variant context.

```xml
<ThemeVariantScope RequestedThemeVariant="Dark">
    <StackPanel Spacing="8">
        <TextBlock Text="Dark section" />

        <!-- This nested scope resets to the parent app theme -->
        <ThemeVariantScope RequestedThemeVariant="{x:Static ThemeVariant.Default}">
            <Border Padding="8"
                    Background="{DynamicResource WindowDefaultBackground}">
                <TextBlock Text="Follows parent theme (Light or Dark)" />
            </Border>
        </ThemeVariantScope>
    </StackPanel>
</ThemeVariantScope>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `RequestedThemeVariant` | `ThemeVariant?` | The theme variant to apply to the subtree. Set to `ThemeVariant.Dark`, `ThemeVariant.Light`, or `ThemeVariant.Default` (inherits parent). / 应用于子树的主题变体。设置为 `ThemeVariant.Dark`、`ThemeVariant.Light` 或 `ThemeVariant.Default`（继承父级）。 |
| `ActualThemeVariant` | `ThemeVariant` | (Read-only) The effective theme variant resolving for this scope. Inherited from `ThemeVariantScope`. / （只读）此作用域中有效的主题变体解析结果。 |
| `Child` | `Control?` | The single child control wrapped by this decorator. Inherited from `Decorator`. / 此装饰器包装的单个子控件。继承自 `Decorator`。 |
| `Padding` | `Thickness` | Padding applied between the decorator border and its child. Inherited from `Decorator`. / 装饰器边框与其子元素之间的内边距。继承自 `Decorator`。 |

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlTheme / Semi.Avalonia 控件主题

Semi.Avalonia provides a lightweight `{x:Type ThemeVariantScope}` ControlTheme that sets default text element properties:

Semi.Avalonia 提供了一个轻量的 `{x:Type ThemeVariantScope}` ControlTheme，设置默认文本元素属性：

| Property / 属性 | Resource Key / 资源键 |
| --- | --- |
| `TextElement.Foreground` | `DefaultForeground` |
| `TextElement.FontSize` | `DefaultFontSize` |
| `TextElement.FontWeight` | `DefaultFontWeight` |
| `TextElement.FontFamily` | `DefaultFontFamily` |

> **Note:** `ThemeVariantScope` itself has a minimal template. Its primary function is the theme variant propagation mechanism — it does not have a visual template with named parts. It is a `Decorator`, meaning it renders its `Child` directly.

> **注意：** `ThemeVariantScope` 本身具有最小模板。其主要功能是主题变体传播机制 —— 它没有带命名部件的可视化模板。它是一个 `Decorator`，意味着它直接渲染其 `Child`。

### How ThemeVariant Propagation Works / ThemeVariant 传播原理

When `RequestedThemeVariant` is set on a `ThemeVariantScope`, all `DynamicResource` lookups within the subtree use the requested variant to select resource values. The `ActualThemeVariant` property reflects the resolved variant. If `RequestedThemeVariant` is `Default`, the scope inherits the parent's actual variant.

当在 `ThemeVariantScope` 上设置 `RequestedThemeVariant` 时，子树中的所有 `DynamicResource` 查找使用请求的变体来选择资源值。`ActualThemeVariant` 属性反映解析后的变体。如果 `RequestedThemeVariant` 为 `Default`，则作用域继承父级的实际变体。

## FAQ / 常见问题

**Q: How is ThemeVariantScope different from setting Application.RequestedThemeVariant? / ThemeVariantScope 与设置 Application.RequestedThemeVariant 有何不同？**

A: `Application.RequestedThemeVariant` applies globally — it changes the theme for the entire application. `ThemeVariantScope` applies locally — only the controls inside its subtree are affected. Use `ThemeVariantScope` for mixed-theme UIs; use `Application.RequestedThemeVariant` for app-wide theme toggling.

`Application.RequestedThemeVariant` 全局生效 —— 更改整个应用程序的主题。`ThemeVariantScope` 本地生效 —— 仅影响其子树内的控件。使用 `ThemeVariantScope` 实现混合主题 UI；使用 `Application.RequestedThemeVariant` 实现应用程序范围的主题切换。

**Q: Can I nest ThemeVariantScopes? / 可以嵌套 ThemeVariantScope 吗？**

A: Yes. Nested scopes work as expected — each scope overrides the variant for its subtree. Use `RequestedThemeVariant="{x:Static ThemeVariant.Default}"` in a nested scope to "reset" to the parent theme, which could be the app-level variant or an outer `ThemeVariantScope`.

可以。嵌套作用域按预期工作 —— 每个作用域覆盖其子树的变体。在嵌套作用域中使用 `RequestedThemeVariant="{x:Static ThemeVariant.Default}"` 来"重置"为父级主题，这可以是应用程序级别的变体或外层的 `ThemeVariantScope`。

**Q: Does ThemeVariantScope affect Semi.Avalonia color classes? / ThemeVariantScope 会影响 Semi.Avalonia 颜色类吗？**

A: Yes. Semi.Avalonia color classes (`Primary`, `Secondary`, etc.) resolve their colors via `DynamicResource` brushes. When inside a `ThemeVariantScope` with a different variant, the resolved brush values reflect that variant's palette — so a `Primary` button in a `Dark` scope will use the dark-theme primary color.

会影响。Semi.Avalonia 颜色类（`Primary`、`Secondary` 等）通过 `DynamicResource` 笔刷解析颜色。当位于具有不同变体的 `ThemeVariantScope` 内部时，解析的笔刷值反映该变体的调色板 —— 因此在 `Dark` 作用域中的 `Primary` 按钮将使用深色主题的主色调。
