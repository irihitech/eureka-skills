---
name: semi-avalonia-theme
description: >
  Semi.Avalonia theming guide covering theme setup, ControlTheme variants,
  style classes, and DynamicResource override patterns for light/dark themes.
license: MIT
---

# Semi.Avalonia Theme / Semi.Avalonia 主题

Use this skill when working with Semi.Avalonia's theming system — setting up themes,
applying ControlTheme variants, using style classes, and overriding DynamicResource
values for customization.

在使用 Semi.Avalonia 主题系统时加载此 Skill —— 包括设置主题、应用 ControlTheme 变体、
使用样式类和通过覆写 DynamicResource 值进行自定义。

## Theme Setup / 主题设置

### RequestedThemeVariant / 请求主题变体

Semi.Avalonia provides Light and Dark themes. Set via `Application.RequestedThemeVariant`:

Semi.Avalonia 提供亮色（Light）和暗色（Dark）两种主题。通过 `Application.RequestedThemeVariant` 设置：

```xml
<Application xmlns:semi="https://irihi.tech/semi"
             RequestedThemeVariant="Light">  <!-- Light, Dark, or Default -->
    <Application.Styles>
        <semi:SemiTheme />
    </Application.Styles>
</Application>
```

| Value / 值 | Behavior / 行为 |
|---|---|
| `Light` | Always light theme. / 始终亮色。 |
| `Dark` | Always dark theme. / 始终暗色。 |
| `Default` | Follows system color preference. / 跟随系统颜色偏好。 |

### Locale / 语言设置

Avalonia built-in controls contain text (e.g., TextBox context menu). Set locale on `SemiTheme`:

Avalonia 内置控件包含文本（如 TextBox 右键菜单）。在 `SemiTheme` 上设置语言：

```xml
<Application.Styles>
    <semi:SemiTheme Locale="en" />  <!-- "zh" for Chinese (default), "en" for English -->
</Application.Styles>
```

## ControlTheme Variants / 控件主题变体

Semi.Avalonia provides default ControlThemes for all built-in Avalonia controls.
Additional special ControlThemes are available for some controls — applied via
the `Theme` attached property. They change the visual appearance while preserving
functionality.

Semi.Avalonia 为所有内置 Avalonia 控件提供了默认 ControlTheme。部分控件还提供了
额外的特殊 ControlTheme —— 通过 `Theme` 附加属性应用。它们改变视觉外观但保持功能不变。

### ProgressRing Example / ProgressRing 示例

Avalonia has a progress bar but no built-in progress ring. Semi.Avalonia provides one:

Avalonia 有进度条但无内置进度环。Semi.Avalonia 提供了进度环：

```xml
<ProgressBar Width="60" Height="60"
             Value="50"
             Theme="{DynamicResource ProgressRing}" />
```

### How to Apply / 使用方式

```xml
<!-- Apply a special ControlTheme -->
<ProgressBar Theme="{DynamicResource ProgressRing}" />

<!-- Button theme variants -->
<Button Theme="{DynamicResource SolidButton}" Content="Solid" />
<Button Theme="{DynamicResource OutlineButton}" Content="Outline" />
```

For a complete list of special ControlThemes per control, see the individual
[control references](../controls/reference/).

各控件完整的特殊 ControlTheme 列表参见独立的[控件参考](../controls/reference/)。

## Style Classes / 样式类

Style classes modify a control's appearance within its current theme. They are
applied via the `Classes` attached property. Multiple classes can be combined.

样式类在控件当前主题内修改其外观。通过 `Classes` 附加属性应用，可组合多个类。

### Color Classes / 颜色类

```xml
<!-- Warning (amber) button -->
<Button Classes="Warning" Content="Warning" />

<!-- Danger (red) button -->
<Button Classes="Danger" Content="Delete" />

<!-- Success (green) button -->
<Button Classes="Success" Content="Save" />
```

### Size Classes / 尺寸类

```xml
<Button Classes="Large" Content="Large Button" />
<Button Classes="Small" Content="Small Button" />
```

### Behavioral Classes / 行为类

```xml
<!-- Shows a clear (×) button on hover/focus in TextBox -->
<TextBox Classes="clearButton" />

<!-- TreeComboBox with clear button -->
<u:TreeComboBox Classes="clearButton" />
```

## Resource Customization / 资源自定义

### Basic Override / 基本覆写

Semi.Avalonia references most styling values (brushes, sizes, corner radii) as
`DynamicResource` keys. To customize globally, override the key in `App.axaml`.

Semi.Avalonia 中大多数样式值（笔刷、尺寸、圆角）以 `DynamicResource` 键引用。
要全局自定义，在 `App.axaml` 中覆写该键。

**Example: Change all Button corner radii from 3 to 6:**

**示例：将所有 Button 圆角从 3 改为 6：**

Source shows the key (`/src/Semi.Avalonia/Themes/Shared/Button.axaml`):

源码中可以看到该键的定义：

```xml
<CornerRadius x:Key="ButtonCornerRadius">3</CornerRadius>
```

Override in `App.axaml`:

在 `App.axaml` 中覆写：

```xml
<Application.Resources>
    <CornerRadius x:Key="ButtonCornerRadius">6</CornerRadius>
</Application.Resources>
```

### How to Find Resource Keys / 如何查找资源键

1. Check the control's AXAML theme file: `/src/Semi.Avalonia/Controls/{Control}.axaml`
   to see which `DynamicResource` keys the control uses.

   查看控件的 AXAML 主题文件，了解控件使用了哪些 `DynamicResource` 键。

2. Check `/src/Semi.Avalonia/Themes/Shared/{Control}.axaml` for the key **definition**.

   在 shared 主题文件中查看键的**定义**。

3. For control-specific keys, see the `DynamicResource Keys` section in each
   [control reference](../controls/reference/).

   控件专属键参见各[控件参考](../controls/reference/)的 `DynamicResource Keys` 部分。

### Theme-Aware Color Overrides / 主题感知颜色覆写

Color resources (brushes) may differ between Light and Dark themes. Override
per-theme using theme-specific resource dictionaries.

色彩资源（笔刷）在亮色和暗色主题下可能不同。使用主题特定的资源字典按主题覆写。

**Example: Change Button foreground to purple with Light/Dark variants:**

**示例：将 Button 前景色改为紫色，亮色/暗色各不同：**

Source shows the key in Light/Dark themes:

源码在亮色/暗色主题中分别定义：

```xml
<!-- Light: /src/Semi.Avalonia/Themes/Light/Button.axaml -->
<SolidColorBrush x:Key="ButtonDefaultPrimaryForeground" Color="#0077FA" />

<!-- Dark: /src/Semi.Avalonia/Themes/Dark/Button.axaml -->
<SolidColorBrush x:Key="ButtonDefaultPrimaryForeground" Color="#54A9FF" />
```

Override in `App.axaml`:

```xml
<Application>
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.ThemeDictionaries>
                <!-- Light theme -->
                <ResourceDictionary x:Key="Light">
                    <SolidColorBrush x:Key="ButtonDefaultPrimaryForeground"
                                     Color="#9E28B3" />
                </ResourceDictionary>
                <!-- Dark theme -->
                <ResourceDictionary x:Key="Dark">
                    <SolidColorBrush x:Key="ButtonDefaultPrimaryForeground"
                                     Color="#B553C2" />
                </ResourceDictionary>
            </ResourceDictionary.ThemeDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

## Common Patterns / 常用模式

### Quick color tweak / 快速颜色调整

Override a single brush in `Application.Resources` without theme dictionaries
(applies to both Light and Dark):

```xml
<Application.Resources>
    <SolidColorBrush x:Key="ButtonSolidPrimaryBackground" Color="#0050B3" />
</Application.Resources>
```

### Apply ControlTheme + Style Class Together / 同时应用 ControlTheme 和样式类

```xml
<Button Theme="{DynamicResource SolidButton}"
        Classes="Danger Large"
        Content="Delete" />
```

### Theme Variant Scope / 主题变体作用域

Use `ThemeVariantScope` to apply a different theme to a specific subtree:

```xml
<Panel>
    <!-- Default (Light) themed section -->
    <Button Content="Light Button" />
    
    <ThemeVariantScope RequestedThemeVariant="Dark">
        <!-- Dark themed section -->
        <Button Content="Dark Button" />
    </ThemeVariantScope>
</Panel>
```
