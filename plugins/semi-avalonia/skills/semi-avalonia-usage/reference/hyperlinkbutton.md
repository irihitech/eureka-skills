---
category: Components
title: HyperlinkButton
subtitle: 超链接按钮
description: 超链接按钮以超链接样式呈现，支持导航到 URI 或触发操作。
---

## HyperlinkButton / 超链接按钮

A button styled as a hyperlink — underlined text that responds to click and hover. Inherits from `Button` and adds `NavigateUri` for external or internal navigation. Ideal for inline links, "Learn more" actions, terms-of-service links, and help references within application UI.

以超链接样式呈现的按钮 —— 带下划线的文本，响应点击和悬停。继承自 `Button`，并增加了用于外部或内部导航的 `NavigateUri`。适用于内联链接、"了解更多"操作、服务条款链接和应用程序 UI 中的帮助引用。

## When to Use / 何时使用

Use `HyperlinkButton` for inline navigational actions within a UI — opening a web page, navigating to another view, or launching an external application via URI. It is styled to look like a text hyperlink rather than a button. For primary or secondary actions that should look like buttons (with background, border, padding), use a `Button` with one of Semi's button ControlThemes (see the `semi-avalonia` skill). For non-navigational actions that happen to need a link appearance, use `HyperlinkButton` without `NavigateUri` and handle `Click` directly.

对于 UI 中的内联导航操作使用 `HyperlinkButton` —— 打开网页、导航到另一个视图或通过 URI 启动外部应用程序。其样式为文本超链接而非按钮。对于应该看起来像按钮（带背景、边框和内边距）的主要或次要操作，请使用 Semi 按钮 ControlTheme 的 `Button`（见 `semi-avalonia` skill）。对于恰好需要链接外观的非导航操作，使用不带 `NavigateUri` 的 `HyperlinkButton` 并直接处理 `Click`。

## Basic Usage / 基本使用

```xml
<HyperlinkButton Content="Learn more"
                 NavigateUri="https://semi-design.com" />
```

```csharp
// Code-behind
private void OnHyperlinkClick(object? sender, RoutedEventArgs e)
{
    var link = (HyperlinkButton)sender!;
    if (link.NavigateUri != null)
    {
        // Handle navigation manually
        Launcher.LaunchUriAsync(link.NavigateUri);
    }
}
```

```csharp
// Programmatic creation
var hyperlink = new HyperlinkButton
{
    Content = "Terms of Service",
    NavigateUri = new Uri("https://example.com/terms")
};
hyperlink.Click += (s, e) =>
{
    var uri = ((HyperlinkButton)s!).NavigateUri;
    if (uri != null)
        Launcher.LaunchUriAsync(uri);
};
```

## Common Scenarios / 常用场景

### External Web Navigation / 外部网页导航

Open a URL in the system default browser.

```xml
<TextBlock>
    By continuing, you agree to our
    <HyperlinkButton Content="Terms of Service"
                     NavigateUri="https://example.com/terms" />
    and
    <HyperlinkButton Content="Privacy Policy"
                     NavigateUri="https://example.com/privacy" />
    .
</TextBlock>
```

### Inline Link in Text / 文本中的内联链接

Embed `HyperlinkButton` inside a `TextBlock` using `Inlines` for seamless text flow.

```xml
<TextBlock TextWrapping="Wrap">
    <Run Text="For more information, please visit our " />
    <HyperlinkButton Content="documentation site"
                     NavigateUri="https://docs.example.com" />
    <Run Text=" or contact " />
    <HyperlinkButton Content="support"
                     NavigateUri="mailto:support@example.com" />
    <Run Text="." />
</TextBlock>
```

### Internal View Navigation / 内部视图导航

Use `Click` for in-app navigation without setting `NavigateUri`.

```xml
<HyperlinkButton Content="Go to Settings"
                 Click="OnNavigateToSettings" />
```

```csharp
private void OnNavigateToSettings(object? sender, RoutedEventArgs e)
{
    // Navigate within the application
    NavigationService.NavigateTo("SettingsPage");
}
```

### Command Binding / 命令绑定

Bind to an `ICommand` for MVVM navigation patterns.

```xml
<HyperlinkButton Content="View Profile"
                 Command="{Binding NavigateCommand}"
                 CommandParameter="ProfilePage" />
```

```csharp
public ICommand NavigateCommand { get; }

public MyViewModel()
{
    NavigateCommand = new RelayCommand<string>(page =>
    {
        NavigationService.NavigateTo(page);
    });
}
```

### Accessible Help Link / 无障碍帮助链接

Provide a help link with an accessible label for screen readers.

```xml
<HyperlinkButton Content="?"
                 NavigateUri="https://help.example.com"
                 ToolTip.Tip="Open help documentation"
                 AutomationProperties.Name="Help"
                 AutomationProperties.HelpText="Opens help documentation in your browser" />
```

## Property Reference / 属性参考

HyperlinkButton inherits all properties from `Button`. Key properties:

HyperlinkButton 继承 `Button` 的所有属性。关键属性：

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `NavigateUri` | `Uri?` | The URI to navigate to when the hyperlink is clicked. When set, clicking automatically calls `Launcher.LaunchUriAsync`. Set to `null` to handle navigation manually via `Click`. / 点击超链接时要导航到的 URI。设置后，点击会自动调用 `Launcher.LaunchUriAsync`。设为 `null` 则通过 `Click` 手动处理导航。 |
| `Content` | `object` | Inherited from `ContentControl`. The hyperlink text. Typically a string, but can be any content. / 继承自 `ContentControl`。超链接文本。通常为字符串，但也可以是任何内容。 |
| `Command` | `ICommand?` | Inherited from `Button`. Invoked on click. Executes before `NavigateUri` navigation. / 继承自 `Button`。点击时调用。在 `NavigateUri` 导航之前执行。 |
| `CommandParameter` | `object?` | Inherited from `Button`. Parameter passed to the command. / 继承自 `Button`。传递给命令的参数。 |
| `ClickMode` | `ClickMode` | Inherited from `Button`. When to fire: `Release` (default) or `Press`. / 继承自 `Button`。触发时机：`Release`（默认）或 `Press`。 |
| `IsEnabled` | `bool` | Inherited from `InputElement`. Disabled hyperlinks typically render without underline and in gray. / 继承自 `InputElement`。禁用的超链接通常无下划线并以灰色渲染。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Click` | Inherited from `Button`. Raised when the hyperlink is clicked, before `NavigateUri` is launched. Handle this to override or augment navigation behavior. / 继承自 `Button`。点击超链接时触发，在启动 `NavigateUri` 之前。处理此事件以覆盖或增强导航行为。 |
| `IsPressedChanged` | Inherited from `Button`. Raised when the pressed state changes. / 继承自 `Button`。按下状态改变时触发。 |

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How is HyperlinkButton different from a styled Button? / HyperlinkButton 与样式化 Button 有何不同？**

A: `HyperlinkButton` is purpose-built for navigation: it has a `NavigateUri` property that auto-launches the system browser or protocol handler; its default template renders text with an underline and no background/border; and it uses link-specific resource keys for foreground colors. A regular `Button` with a borderless Semi theme can achieve a similar visual but lacks `NavigateUri` and link-specific pseudo-class support (like `:visited`).

A: `HyperlinkButton` 专为导航设计：它具有 `NavigateUri` 属性，可自动启动系统浏览器或协议处理器；其默认模板以带下划线、无背景/边框的方式渲染文本；并使用链接特定的资源键设置前景色。使用无边框 Semi 主题的普通 `Button` 可以实现类似的视觉效果，但缺少 `NavigateUri` 和链接特定的伪类支持（如 `:visited`）。

**Q: Does HyperlinkButton support mailto: and other protocols? / HyperlinkButton 支持 mailto: 和其他协议吗？**

A: Yes. `NavigateUri` supports any valid URI scheme including `https://`, `mailto:`, `ftp://`, `tel:`, and custom protocol handlers. The URI is passed to `Launcher.LaunchUriAsync`, which delegates to the operating system's protocol handler. Always validate externally-supplied URIs before setting `NavigateUri` to prevent unexpected protocol launches.

支持。`NavigateUri` 支持任何有效的 URI 方案，包括 `https://`、`mailto:`、`ftp://`、`tel:` 和自定义协议处理器。URI 传递给 `Launcher.LaunchUriAsync`，后者委托操作系统的协议处理器处理。在设置 `NavigateUri` 之前，始终验证外部提供的 URI，以防意外启动协议。

**Q: How do I prevent automatic navigation and handle Click manually? / 如何阻止自动导航并手动处理 Click？**

A: Omit `NavigateUri` (leave it `null`) and handle the `Click` event directly. In the `Click` handler, you can implement custom logic — in-app navigation, conditional URI launching, analytics tracking, or confirmation dialogs — before optionally calling `Launcher.LaunchUriAsync` yourself. If `NavigateUri` is set, the automatic navigation occurs after `Click` completes.

省略 `NavigateUri`（保持为 `null`）并直接处理 `Click` 事件。在 `Click` 处理程序中，你可以实现自定义逻辑 —— 应用内导航、条件 URI 启动、分析追踪或确认对话框 —— 然后可选地自行调用 `Launcher.LaunchUriAsync`。如果设置了 `NavigateUri`，自动导航将在 `Click` 完成后进行。

**Q: Can I use HyperlinkButton inside a SelectableTextBlock? / 可以在 SelectableTextBlock 中使用 HyperlinkButton 吗？**

A: `HyperlinkButton` is a `Button`-derived control, so it cannot be used directly inside `SelectableTextBlock.Inlines` (which expects `Inline` elements like `Run`, `Span`, and `LineBreak`). For clickable links within selectable text, use `TextBlock` with `Inlines` instead, or handle `PointerPressed` on a `Run` element. Another approach is placing `HyperlinkButton` outside the `SelectableTextBlock` below or above it.

`HyperlinkButton` 是派生自 `Button` 的控件，因此不能直接用于 `SelectableTextBlock.Inlines` 中（后者需要 `Inline` 元素，如 `Run`、`Span` 和 `LineBreak`）。要在可选择文本中使用可点击链接，请改用带 `Inlines` 的 `TextBlock`，或在 `Run` 元素上处理 `PointerPressed`。另一种方法是将 `HyperlinkButton` 放置在 `SelectableTextBlock` 外部（上方或下方）。
