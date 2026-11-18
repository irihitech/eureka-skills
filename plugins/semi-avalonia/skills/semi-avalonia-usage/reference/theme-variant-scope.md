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
    <Border Padding="16">
        <TextBlock Text="This section is always Dark." />
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
        // colors come from theme resources, so each variant renders correctly —
        // pick the brushes from the generated semi-avalonia skill's token reference
        Child = new TextBlock
        {
            Text = "Always dark content"
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
        <Border Width="240">
            <StackPanel Spacing="8" Margin="12">
                <TextBlock Text="Navigation"
                           FontWeight="Bold" />
                <Button Content="Dashboard" />
                <Button Content="Settings" />
            </StackPanel>
        </Border>
    </ThemeVariantScope>

    <!-- Light-themed main content -->
    <Border Padding="16">
        <TextBlock Text="Main Content Area" />
    </Border>
</DockPanel>
```

### Document Preview with Opposite Theme / 使用相反主题的文档预览

```xml
<!-- Light app, dark document preview -->
<Border Padding="8"
        CornerRadius="8">
    <TextBlock Text="Document Preview" FontWeight="Bold" Margin="0,0,0,8" />
    <ThemeVariantScope RequestedThemeVariant="Dark">
        <Border Padding="16"
                CornerRadius="4">
            <SelectableTextBlock Text="{Binding DocumentContent}"
                                 FontFamily="Cascadia Code" />
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
            <Border Padding="8">
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

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How is ThemeVariantScope different from setting Application.RequestedThemeVariant? / ThemeVariantScope 与设置 Application.RequestedThemeVariant 有何不同？**

A: `Application.RequestedThemeVariant` applies globally — it changes the theme for the entire application. `ThemeVariantScope` applies locally — only the controls inside its subtree are affected. Use `ThemeVariantScope` for mixed-theme UIs; use `Application.RequestedThemeVariant` for app-wide theme toggling.

`Application.RequestedThemeVariant` 全局生效 —— 更改整个应用程序的主题。`ThemeVariantScope` 本地生效 —— 仅影响其子树内的控件。使用 `ThemeVariantScope` 实现混合主题 UI；使用 `Application.RequestedThemeVariant` 实现应用程序范围的主题切换。

**Q: Can I nest ThemeVariantScopes? / 可以嵌套 ThemeVariantScope 吗？**

A: Yes. Nested scopes work as expected — each scope overrides the variant for its subtree. Use `RequestedThemeVariant="{x:Static ThemeVariant.Default}"` in a nested scope to "reset" to the parent theme, which could be the app-level variant or an outer `ThemeVariantScope`.

可以。嵌套作用域按预期工作 —— 每个作用域覆盖其子树的变体。在嵌套作用域中使用 `RequestedThemeVariant="{x:Static ThemeVariant.Default}"` 来"重置"为父级主题，这可以是应用程序级别的变体或外层的 `ThemeVariantScope`。

**Q: Does ThemeVariantScope affect Semi.Avalonia color classes? / ThemeVariantScope 会影响 Semi.Avalonia 颜色类吗？**

A: Yes. Semi.Avalonia's color classes and brushes resolve through `DynamicResource`, so inside a `ThemeVariantScope` with a different variant every themed control picks up that variant's palette — a themed button in a `Dark` scope renders with the dark palette. The concrete class and brush names live in the generated `semi-avalonia` skill.

会影响。Semi.Avalonia 的颜色类与笔刷都通过 `DynamicResource` 解析，因此位于具有不同变体的 `ThemeVariantScope` 内部时，所有主题化控件都会采用该变体的调色板 —— `Dark` 作用域中的主题化按钮会以深色调色板渲染。具体的类名与笔刷名以生成的 `semi-avalonia` skill 为准。
