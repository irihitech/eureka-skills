---
category: Components
title: EmbeddableControlRoot
subtitle: 可嵌入控件根
description: 用于将 Avalonia 视图嵌入原生应用程序（如 WinForms、WPF）的根控件。
---

# EmbeddableControlRoot / 可嵌入控件根

A root control for embedding Avalonia views inside native applications such as WinForms, WPF, or other non-Avalonia hosts. `EmbeddableControlRoot` inherits from `TopLevel` (like `Window`) but does not create a separate operating-system window. Instead, it renders its content into a region managed by the native host.

用于将 Avalonia 视图嵌入原生应用程序（如 WinForms、WPF 或其他非 Avalonia 宿主）的根控件。`EmbeddableControlRoot` 继承自 `TopLevel`（与 `Window` 类似），但不会创建独立的操作系统窗口。它将其内容渲染到由原生宿主管理的区域中。

## When to Use / 何时使用

Use `EmbeddableControlRoot` when you need to host an Avalonia UI inside an existing native application — migrating a WinForms or WPF application incrementally to Avalonia, embedding an Avalonia control in a native container, or creating a plugin UI for a native host. For standalone Avalonia windows, use `Window`. For within-Avalonia content sections, use `UserControl` or `ContentControl`.

当你需要在现有原生应用程序中托管 Avalonia UI 时使用 `EmbeddableControlRoot` —— 逐步将 WinForms 或 WPF 应用程序迁移到 Avalonia、将 Avalonia 控件嵌入原生容器，或为原生宿主创建插件 UI。独立的 Avalonia 窗口使用 `Window`。Avalonia 内部的内容区域使用 `UserControl` 或 `ContentControl`。

## Basic Usage / 基本使用

```xml
<EmbeddableControlRoot xmlns="https://github.com/avaloniaui"
                       xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Border Padding="20">
        <StackPanel Spacing="10">
            <TextBlock Text="Embedded Avalonia View"
                       FontSize="18"
                       FontWeight="Bold" />
            <Button Content="Click Me"
                    Theme="{DynamicResource SolidButton}" />
        </StackPanel>
    </Border>
</EmbeddableControlRoot>
```

```csharp
// Programmatic creation for embedding in WinForms
var root = new EmbeddableControlRoot
{
    Content = new TextBlock { Text = "Hello from Avalonia!" }
};

// Prepare for embedding in a native host
root.Prepare();

// In WinForms host: pass the native handle
var nativeHost = new AvaloniaHost(); // hypothetical wrapper
nativeHost.Content = root;
```

## Common Scenarios / 常用场景

### WinForms Embedding with AvaloniaHost / 使用 AvaloniaHost 嵌入 WinForms

```csharp
// In a WinForms Form
public partial class MainForm : Form
{
    private EmbeddableControlRoot _avaloniaRoot;

    public MainForm()
    {
        InitializeComponent();

        _avaloniaRoot = new EmbeddableControlRoot
        {
            Content = new Border
            {
                Padding = new Thickness(16),
                Child = new StackPanel
                {
                    Spacing = 8,
                    Children =
                    {
                        new TextBlock { Text = "Avalonia inside WinForms", FontSize = 16 },
                        new Button { Content = "Avalonia Button" }
                    }
                }
            }
        };

        _avaloniaRoot.Prepare();

        // Embed in a container panel
        var host = new AvaloniaHost(_avaloniaRoot);
        host.Dock = DockStyle.Fill;
        this.Controls.Add(host);
    }
}
```

### Styling the Embedded View / 为嵌入视图设置样式

`EmbeddableControlRoot` uses the same Semi.Avalonia theme system as `Window`. Apply Semi themes just as you would in a standalone window.

```xml
<EmbeddableControlRoot>
    <EmbeddableControlRoot.Styles>
        <StyleInclude Source="avares://Semi.Avalonia/Themes/Index.axaml" />
    </EmbeddableControlRoot.Styles>
    <Border Padding="20" Background="{DynamicResource WindowDefaultBackground}">
        <StackPanel Spacing="10">
            <TextBlock Text="Styled Embedded View" />
            <Button Content="Primary"
                    Theme="{DynamicResource SolidButton}" />
        </StackPanel>
    </Border>
</EmbeddableControlRoot>
```

### Dialog Content Inside EmbeddableControlRoot / EmbeddableControlRoot 内的对话框内容

Since `EmbeddableControlRoot` doesn't support `ShowDialog` (no OS window), use in-view overlays or `ContentControl` swapping for modal-like behavior.

```csharp
// Simulate modal: swap content
var originalContent = root.Content;
root.Content = new Border
{
    Background = Brush.Parse("#80000000"), // semi-transparent overlay
    Child = new Border
    {
        MaxWidth = 400,
        Padding = new Thickness(20),
        Background = Brushes.White,
        Child = new StackPanel
        {
            Spacing = 10,
            Children =
            {
                new TextBlock { Text = "Are you sure?" },
                new Button
                {
                    Content = "OK",
                    Theme = ...,
                    // On click: root.Content = originalContent;
                }
            }
        }
    }
};
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Content` | `object?` | The root content of the embedded Avalonia view. / 嵌入式 Avalonia 视图的根内容。 |
| `ContentTemplate` | `IDataTemplate?` | Template applied to `Content`. / 应用于 `Content` 的模板。 |
| `Padding` | `Thickness` | Padding around the content. / 内容周围的内边距。 |
| `Background` | `IBrush?` | Background of the embedded root area. / 嵌入根区域的背景。 |
| `Foreground` | `IBrush?` | Default text foreground. / 默认文本前景色。 |
| `FontSize` | `double` | Default font size. / 默认字体大小。 |
| `FontFamily` | `FontFamily` | Default font family. / 默认字体族。 |
| `Width` | `double` | The rendered width of the control. / 控件的渲染宽度。 |
| `Height` | `double` | The rendered height of the control. / 控件的渲染高度。 |
| `Styles` | `Styles` | The style collection applied to this root. Add Semi theme includes here. / 应用于此根的样式集合。在此添加 Semi 主题引用。 |
| `Resources` | `ResourceDictionary` | Local resources for this embedded view. / 此嵌入视图的本地资源。 |

### Key Methods / 关键方法

| Method / 方法 | Description / 说明 |
| --- | --- |
| `Prepare()` | Prepares the `EmbeddableControlRoot` for embedding in a native host. Must be called before the native host takes ownership. / 准备 `EmbeddableControlRoot` 以嵌入原生宿主。必须在原生宿主接管之前调用。 |

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlTheme / Semi.Avalonia 控件主题

Semi.Avalonia provides a `{x:Type EmbeddableControlRoot}` ControlTheme that mirrors the `Window` theme: same default background, foreground, and font settings. The template consists of a `Panel` with transparency fallback, background border, and a `VisualLayerManager`-hosted `ContentPresenter`.

Semi.Avalonia 提供 `{x:Type EmbeddableControlRoot}` 的 ControlTheme，与 `Window` 主题一致：相同的默认背景、前景和字体设置。模板由一个带透明回退的 `Panel`、背景边框和 `VisualLayerManager` 托管的 `ContentPresenter` 组成。

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `WindowDefaultBackground` | Embedded view background / 嵌入视图背景 |
| `WindowDefaultForeground` | Embedded view default text color / 嵌入视图默认文本颜色 |
| `DefaultFontSize` | Default font size / 默认字体大小 |
| `DefaultFontWeight` | Default font weight / 默认字体粗细 |
| `DefaultFontFamily` | Default font family / 默认字体族 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_TransparencyFallback` | `Border` | Fallback background for transparency support. / 透明度支持的备用背景。 |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the `Content` with padding and template. / 使用内边距和模板渲染 `Content`。 |
| `PART_VisualLayerManager` | `VisualLayerManager` | Manages visual layers (adorners, overlays) within the embedded root. / 管理嵌入根内的视觉层（装饰器、覆盖层）。 |

## FAQ / 常见问题

**Q: When should I use EmbeddableControlRoot vs. Window? / 何时使用 EmbeddableControlRoot 而非 Window？**

A: Use `Window` for standalone, top-level windows with their own OS window handle, title bar, and taskbar entry. Use `EmbeddableControlRoot` when Avalonia content lives inside a native container — e.g., a WinForms `UserControl`, a WPF `HwndHost`, or an Electron/MAUI embedded view. `EmbeddableControlRoot` has no OS window, no `Show()`/`ShowDialog()`, and no native chrome.

独立顶级窗口（有自己的 OS 窗口句柄、标题栏和任务栏条目）使用 `Window`。当 Avalonia 内容位于原生容器内时使用 `EmbeddableControlRoot` —— 例如 WinForms `UserControl`、WPF `HwndHost` 或 Electron/MAUI 嵌入视图。`EmbeddableControlRoot` 没有 OS 窗口、没有 `Show()`/`ShowDialog()`，也没有原生窗口边框。

**Q: Can I use Semi.Avalonia themes in an embedded view? / 可以在嵌入视图中使用 Semi.Avalonia 主题吗？**

A: Yes. Include the Semi theme styles in the `EmbeddableControlRoot.Styles` collection just as you would in `Application.Styles`. All Semi `ControlTheme`, `DynamicResource` brushes, and color/size class systems work identically in embedded views.

可以。将 Semi 主题样式包含到 `EmbeddableControlRoot.Styles` 集合中，就像在 `Application.Styles` 中一样。所有 Semi `ControlTheme`、`DynamicResource` 笔刷以及颜色/尺寸类系统在嵌入视图中完全一致地工作。

**Q: How do I handle focus between native and Avalonia controls? / 如何处理原生控件和 Avalonia 控件之间的焦点？**

A: Focus management between native and Avalonia controls depends on the embedding platform. In WinForms, the `AvaloniaHost` wrapper typically handles focus transitions. Keyboard input (Tab, arrows) may need manual routing via `KeyboardDevice` and focus scopes. Test thoroughly on your target native platform — focus behavior varies across WinForms, WPF, and other hosts.

原生控件和 Avalonia 控件之间的焦点管理取决于嵌入平台。在 WinForms 中，`AvaloniaHost` 包装器通常处理焦点转换。键盘输入（Tab、方向键）可能需要通过 `KeyboardDevice` 和焦点范围进行手动路由。在目标原生平台上彻底测试 —— 焦点行为在 WinForms、WPF 和其他宿主之间有所不同。
