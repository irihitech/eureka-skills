---
category: Components
title: Window
subtitle: 窗口
description: 窗口是 Avalonia 中的顶级容器，代表操作系统级别的窗口。
---

# Window / 窗口

A top-level window that represents an operating-system window. `Window` inherits from `WindowBase` and implements `IFocusScope`. It is the primary container for application views — supports title, icon, position, size, window state (normal/minimized/maximized/fullscreen), startup location, dialog modality, and owner/child window relationships.

代表操作系统级别窗口的顶级容器。`Window` 继承自 `WindowBase` 并实现了 `IFocusScope`。它是应用程序视图的主要容器 —— 支持标题、图标、位置、尺寸、窗口状态（正常/最小化/最大化/全屏）、启动位置、对话框模态以及所有者/子窗口关系。

## When to Use / 何时使用

Use `Window` as the root visual for every independent, top-level window in your application. Create a `Window` for the main application shell, for modal dialogs (via `ShowDialog`), and for tool windows or floating panels. For embedded/native-hosted scenarios, consider `EmbeddableControlRoot` instead. For notifications that overlay within a single window, use `WindowNotificationManager`.

使用 `Window` 作为应用程序中每个独立顶级窗口的根容器。为应用程序主外壳、模态对话框（通过 `ShowDialog`）以及工具窗口或浮动面板创建 `Window`。对于嵌入式/原生托管场景，请考虑 `EmbeddableControlRoot`。对于在单个窗口内叠加的通知，使用 `WindowNotificationManager`。

## Basic Usage / 基本使用

```xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        x:Class="MyApp.MainWindow"
        Title="My Application"
        Width="800"
        Height="600"
        CanResize="True"
        WindowStartupLocation="CenterScreen">
    <TextBlock Text="Hello, World!"
               HorizontalAlignment="Center"
               VerticalAlignment="Center" />
</Window>
```

```csharp
// Programmatic creation
var window = new Window
{
    Title = "My Dialog",
    Width = 400,
    Height = 300,
    WindowStartupLocation = WindowStartupLocation.CenterOwner,
    CanResize = false
};

// Show as modal dialog
var result = await window.ShowDialog<bool>(ownerWindow);

// Close with result
window.Close(true);
```

## Common Scenarios / 常用场景

### Modal Dialog / 模态对话框

Create a dialog window that blocks interaction with the owner until dismissed.

```xml
<Window xmlns="https://github.com/avaloniaui"
        x:Class="MyApp.Dialogs.SettingsDialog"
        Title="Settings"
        Width="500"
        Height="400"
        WindowStartupLocation="CenterOwner"
        CanResize="False"
        ShowInTaskbar="False">
    <StackPanel Spacing="10" Margin="16">
        <TextBox Watermark="User Name" />
        <StackPanel Orientation="Horizontal"
                    HorizontalAlignment="Right" Spacing="8">
            <Button Content="OK"
                    IsDefault="True"
                    Click="OnOkClick" />
            <Button Content="Cancel"
                    IsCancel="True"
                    Click="OnCancelClick" />
        </StackPanel>
    </StackPanel>
</Window>
```

```csharp
var dialog = new SettingsDialog();
var result = await dialog.ShowDialog<bool>(this);
```

### Custom Window Chrome / 自定义窗口边框

Extend client area into the title bar for a custom-drawn title bar.

```xml
<Window ExtendClientAreaToDecorationsHint="True"
        ExtendClientAreaTitleBarHeightHint="48"
        WindowDecorations="Full">
    <DockPanel>
        <!-- Custom title bar -->
        <Border Height="48"
                Background="Transparent"
                DockPanel.Dock="Top">
            <DockPanel Margin="12,0">
                <TextBlock Text="{Binding Title, RelativeSource={RelativeSource FindAncestor, AncestorType=Window}}"
                           VerticalAlignment="Center" />
                <Button Content="X"
                        DockPanel.Dock="Right"
                        Click="OnCloseClick"
                        Classes="Borderless" />
            </DockPanel>
        </Border>
        <!-- Main content -->
        <Border Background="{DynamicResource WindowDefaultBackground}">
            <TextBlock Text="Content area" />
        </Border>
    </DockPanel>
</Window>
```

### Size-to-Content Window / 自适应尺寸窗口

Let the window automatically size to fit its content.

```xml
<Window SizeToContent="WidthAndHeight"
        CanResize="False"
        WindowStartupLocation="CenterOwner">
    <StackPanel Spacing="8" Margin="16">
        <TextBlock Text="This window sizes to its content." />
        <Button Content="Close" Click="OnCloseClick" />
    </StackPanel>
</Window>
```

### Window State Management / 窗口状态管理

Control minimize, maximize, and fullscreen states programmatically.

```csharp
// Minimize
window.WindowState = WindowState.Minimized;

// Maximize
window.WindowState = WindowState.Maximized;

// Fullscreen
window.WindowState = WindowState.FullScreen;

// Restore
window.WindowState = WindowState.Normal;
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Title` | `string?` | The window title displayed in the title bar. / 标题栏中显示的窗口标题。 |
| `Icon` | `WindowIcon?` | The window icon shown in the title bar and taskbar. / 标题栏和任务栏中显示的窗口图标。 |
| `Width` | `double` | Width of the window (device-independent pixels). / 窗口宽度（设备无关像素）。 |
| `Height` | `double` | Height of the window (device-independent pixels). / 窗口高度（设备无关像素）。 |
| `MinWidth` | `double` | Minimum allowed width. / 允许的最小宽度。 |
| `MaxWidth` | `double` | Maximum allowed width. / 允许的最大宽度。 |
| `MinHeight` | `double` | Minimum allowed height. / 允许的最小高度。 |
| `MaxHeight` | `double` | Maximum allowed height. / 允许的最大高度。 |
| `Position` | `PixelPoint` | Window position in screen coordinates. / 窗口在屏幕坐标中的位置。 |
| `WindowState` | `WindowState` | Current window state: `Normal`, `Minimized`, `Maximized`, or `FullScreen`. / 当前窗口状态。 |
| `WindowStartupLocation` | `WindowStartupLocation` | Where the window appears on first show: `Manual`, `CenterScreen`, or `CenterOwner`. / 窗口首次显示时的位置。 |
| `SizeToContent` | `SizeToContent` | Auto-size behavior: `Manual`, `Width`, `Height`, or `WidthAndHeight`. / 自动调整尺寸行为。 |
| `CanResize` | `bool` | Whether the user can resize the window (default `true`). / 用户是否可以调整窗口大小（默认 `true`）。 |
| `CanMinimize` | `bool` | Whether the window can be minimized (default `true`). / 窗口是否可以最小化（默认 `true`）。 |
| `CanMaximize` | `bool` | Whether the window can be maximized. Coerced to `false` when `CanResize` is `false`. / 窗口是否可以最大化。当 `CanResize` 为 `false` 时强制为 `false`。 |
| `ShowActivated` | `bool` | Whether the window is activated (focused) when first shown (default `true`). / 窗口首次显示时是否激活（获得焦点），默认 `true`。 |
| `ShowInTaskbar` | `bool` | Whether the window appears in the taskbar (default `true`). / 窗口是否在任务栏中显示（默认 `true`）。 |
| `WindowDecorations` | `WindowDecorations` | Window chrome style: `None`, `BorderOnly`, or `Full`. / 窗口边框样式。 |
| `WindowDecorationsTheme` | `ControlTheme?` | Theme used for client-side drawn decorations. / 用于客户端绘制边框的主题。 |
| `ExtendClientAreaToDecorationsHint` | `bool` | Extend the client area into the title bar and borders. / 将客户区扩展到标题栏和边框区域。 |
| `ExtendClientAreaTitleBarHeightHint` | `double` | Custom title bar height when client area is extended (-1 = OS default). / 客户区扩展时的自定义标题栏高度（-1 = 操作系统默认值）。 |
| `IsExtendedIntoWindowDecorations` | `bool` | (Read-only) Whether the client area is actually extended into decorations. / （只读）客户区是否实际扩展到窗口边框。 |
| `WindowDecorationMargin` | `Thickness` | (Read-only) Margin thickness around the window occupied by decorations. / （只读）窗口边框占用的边缘厚度。 |
| `OffScreenMargin` | `Thickness` | (Read-only) Window margin hidden off the screen (typically when maximized). / （只读）隐藏在屏幕外的窗口边缘（最大化时常见）。 |
| `IsDialog` | `bool` | (Read-only) Whether the window was opened as a modal dialog. / （只读）窗口是否作为模态对话框打开。 |
| `ClosingBehavior` | `WindowClosingBehavior` | How child window closing events interact: `OwnerAndChildWindows` or `OwnerWindowOnly`. / 子窗口关闭事件的交互方式。 |
| `OwnedWindows` | `IReadOnlyList<Window>` | (Read-only) Collection of child windows owned by this window. / （只读）此窗口拥有的子窗口集合。 |
| `Content` | `object?` | The content displayed inside the window. Inherited from `ContentControl`. / 窗口内显示的内容。继承自 `ContentControl`。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Opened` | Raised after the window is shown. / 窗口显示后触发。 |
| `Closing` | Raised before the window closes; `Cancel` prevents closing. / 窗口关闭前触发；设置 `Cancel` 可阻止关闭。 |
| `Closed` | Raised after the window has closed. / 窗口关闭后触发。 |
| `WindowOpened` | Static routed event for global tracking of window openings. / 用于全局跟踪窗口打开的静态路由事件。 |
| `WindowClosed` | Static routed event for global tracking of window closures. / 用于全局跟踪窗口关闭的静态路由事件。 |
| `Resized` | Raised when the window client size changes. / 窗口客户区尺寸变化时触发。 |
| `PositionChanged` | Raised when the window's screen position changes (inherited from `WindowBase`). / 窗口屏幕位置变化时触发（继承自 `WindowBase`）。 |

### Key Methods / 关键方法

| Method / 方法 | Description / 说明 |
| --- | --- |
| `Show()` | Shows the window as a non-modal top-level window. / 以非模态顶级窗口显示窗口。 |
| `Show(Window owner)` | Shows the window as a child of the specified owner. / 将窗口显示为指定所有者的子窗口。 |
| `ShowDialog(Window owner)` | Shows the window as a modal dialog. / 以模态对话框显示窗口。 |
| `ShowDialog<TResult>(Window owner)` | Shows a modal dialog that returns a typed result. / 显示返回类型化结果的模态对话框。 |
| `Hide()` | Hides the window without closing it. / 隐藏窗口但不关闭。 |
| `Close()` | Closes the window. / 关闭窗口。 |
| `Close(object? dialogResult)` | Closes a dialog window with the specified result. / 以指定结果关闭对话框窗口。 |
| `Activate()` | Activates the window (brings to front, gives focus). / 激活窗口（置前、获取焦点）。 |
| `BeginMoveDrag(PointerPressedEventArgs)` | Starts a window move operation from a pointer event. / 从指针事件开始窗口移动操作。 |
| `BeginResizeDrag(WindowEdge, PointerPressedEventArgs)` | Starts a window resize operation from a pointer event. / 从指针事件开始窗口调整大小操作。 |

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlTheme / Semi.Avalonia 控件主题

Semi.Avalonia provides a `{x:Type Window}` ControlTheme with default background, foreground, and font-family settings. The template consists of a `Panel` with transparency fallback, background border, and a `VisualLayerManager`-hosted `ContentPresenter`.

Semi.Avalonia 提供 `{x:Type Window}` 的 ControlTheme，包含默认背景、前景和字体族设置。模板由一个带透明回退的 `Panel`、背景边框以及 `VisualLayerManager` 托管的 `ContentPresenter` 组成。

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `WindowDefaultBackground` | Window client area background / 窗口客户区背景 |
| `WindowDefaultForeground` | Window default text color / 窗口默认文本颜色 |
| `DefaultFontSize` | Default font size / 默认字体大小 |
| `DefaultFontWeight` | Default font weight / 默认字体粗细 |
| `DefaultFontFamily` | Default font family / 默认字体族 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_TransparencyFallback` | `Border` | Fallback background for transparency support. / 透明度支持的备用背景。 |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the `Content` with padding, alignment, and template. / 使用内边距、对齐和模板渲染 `Content`。 |
| `PART_VisualLayerManager` | `VisualLayerManager` | Manages visual layers (adorners, overlays) within the window. / 管理窗口内的视觉层（装饰器、覆盖层）。 |

## FAQ / 常见问题

**Q: How do I prevent the user from closing a window? / 如何阻止用户关闭窗口？**

A: Handle the `Closing` event and set `e.Cancel = true`. This works for both programmatic `Close()` calls and system-level close actions (Alt+F4, close button). You can inspect `e.CloseReason` to distinguish between user-initiated and programmatic closes.

处理 `Closing` 事件并设置 `e.Cancel = true`。这对编程式的 `Close()` 调用和系统级关闭操作（Alt+F4、关闭按钮）均有效。可以通过 `e.CloseReason` 来区分用户发起的关闭和程序化的关闭。

**Q: How do I set a minimum window size? / 如何设置最小窗口尺寸？**

A: Use `MinWidth` and `MinHeight` properties. When `SizeToContent` is enabled and `CanResize` is `false`, the window will automatically fit its content within these bounds. For resizable windows, these values act as hard minimums the user cannot shrink below.

使用 `MinWidth` 和 `MinHeight` 属性。当启用 `SizeToContent` 且 `CanResize` 为 `false` 时，窗口会自动适应内容并遵守这些边界。对于可调整大小的窗口，这些值作为用户无法缩到以下的最小尺寸。

**Q: When should I use Window vs. EmbeddableControlRoot? / 何时使用 Window 而非 EmbeddableControlRoot？**

A: Use `Window` for standalone top-level windows that have their own OS window handle. Use `EmbeddableControlRoot` when the Avalonia view is hosted inside a native application (e.g., embedded in a WinForms or WPF host). `EmbeddableControlRoot` does not create a separate OS window.

独立顶级窗口使用 `Window`（有自己的操作系统窗口句柄）。当 Avalonia 视图嵌入原生应用程序时（如嵌入 WinForms 或 WPF 宿主），使用 `EmbeddableControlRoot`。`EmbeddableControlRoot` 不会创建独立的操作系统窗口。

**Q: How do I access the Window from a child control's code-behind? / 如何从子控件的代码后置中访问 Window？**

A: Use `TopLevel.GetTopLevel(this) as Window` from any control. This walks the visual tree upward to find the nearest `TopLevel`, which for a window-based application is the `Window` itself.

从任何控件使用 `TopLevel.GetTopLevel(this) as Window`。这会沿视觉树向上查找最近的 `TopLevel`，对于基于窗口的应用程序来说就是 `Window` 本身。
