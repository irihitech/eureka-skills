---
category: Components
title: FlyoutPresenter
subtitle: 浮层呈现器
description: 用于呈现 Flyout 内容的容器控件，提供了浮层的基础样式和行为模板。
---

# FlyoutPresenter / 浮层呈现器

A content presenter that hosts and renders the content of a `Flyout`. `FlyoutPresenter` is the visual container that manages layout, positioning, and styling of flyout content. It inherits from `ContentControl` and is typically created automatically by the `Flyout` infrastructure — you rarely create it directly.

用于承载和呈现 `Flyout` 内容的容器控件。`FlyoutPresenter` 是管理浮层内容的布局、定位和样式的可视化容器。它继承自 `ContentControl`，通常由 `Flyout` 基础设施自动创建 —— 很少直接创建它。

## When to Use / 何时使用

`FlyoutPresenter` is an internal infrastructure control. You should not create it directly. Instead, use `Button.Flyout`, `FlyoutBase.ShowAttachedFlyout()`, or attach a `Flyout` to any control. The `FlyoutPresenter` is the templated control that the framework creates to host your flyout content. Customize its appearance through `FlyoutTemplate` on the `Flyout` itself or through global styles targeting `FlyoutPresenter`.

`FlyoutPresenter` 是一个内部基础设施控件。不应直接创建它。而应使用 `Button.Flyout`、`FlyoutBase.ShowAttachedFlyout()` 或将 `Flyout` 附加到任意控件。`FlyoutPresenter` 是框架创建用于承载浮层内容的模板化控件。通过 `Flyout` 上的 `FlyoutTemplate` 或目标为 `FlyoutPresenter` 的全局样式来自定义其外观。

## Basic Usage / 基本使用

`FlyoutPresenter` is created implicitly by the flyout system:

```xml
<!-- FlyoutPresenter is created automatically when this flyout opens -->
<Button Content="Options">
    <Button.Flyout>
        <Flyout>
            <StackPanel Spacing="8" Width="200">
                <TextBlock Text="Flyout Content" FontWeight="Bold" />
                <Button Content="Action 1" />
                <Button Content="Action 2" />
            </StackPanel>
        </Flyout>
    </Button.Flyout>
</Button>
```

```csharp
// Internally, Avalonia creates a FlyoutPresenter to host this content
var button = new Button { Content = "Options" };
button.Flyout = new Flyout
{
    Content = new StackPanel
    {
        Children =
        {
            new TextBlock { Text = "Flyout Content" },
            new Button { Content = "Action 1" },
        }
    }
};
```

## Common Scenarios / 常用场景

### Custom FlyoutPresenter Style / 自定义浮层呈现器样式

Override the global `FlyoutPresenter` style to apply consistent theming across all flyouts:

```xml
<Style Selector="FlyoutPresenter">
    <Setter Property="CornerRadius" Value="8" />
    <Setter Property="Background" 
            Value="{DynamicResource SemiFlyoutPresenterBackground}" />
    <Setter Property="Padding" Value="12" />
</Style>
```

### Using FlyoutPresenterClasses / 使用浮层呈现器类

Set classes on the `Flyout` to forward them to the `FlyoutPresenter`:

```xml
<Flyout FlyoutPresenterClasses="Popup Large">
    <StackPanel>
        <TextBlock Text="Styled flyout content" />
    </StackPanel>
</Flyout>
```

### Flyout with Placement / 带定位的浮层

Control where the flyout appears relative to its target:

```xml
<Button Content="Show Flyout">
    <Button.Flyout>
        <Flyout Placement="BottomEdgeAlignedLeft">
            <StackPanel Spacing="4" Width="180">
                <TextBlock Text="Positioned at bottom-left" />
            </StackPanel>
        </Flyout>
    </Button.Flyout>
</Button>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Content` | `object?` | The content hosted inside the flyout. Inherited from `ContentControl`. / 浮层内承载的内容。继承自 `ContentControl`。 |
| `ContentTemplate` | `IDataTemplate?` | Template applied to the Content. Inherited from `ContentControl`. / 应用于内容的模板。继承自 `ContentControl`。 |
| `CornerRadius` | `CornerRadius` | Rounded corner radius for the flyout border. / 浮层边框的圆角半径。 |
| `Padding` | `Thickness` | Inner padding of the flyout content area. / 浮层内容区域的内边距。 |
| `HorizontalContentAlignment` | `HorizontalAlignment` | Horizontal alignment of content. / 内容的水平对齐方式。 |
| `VerticalContentAlignment` | `VerticalAlignment` | Vertical alignment of content. / 内容的垂直对齐方式。 |
| `MaxWidth` | `double` | Maximum width of the flyout presenter. / 浮层呈现器的最大宽度。 |
| `MaxHeight` | `double` | Maximum height of the flyout presenter. / 浮层呈现器的最大高度。 |
| `IsOpen` | `bool` | Whether the flyout is currently open. / 浮层当前是否打开。 |

## Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Opened` | Raised when the flyout presenter opens. / 浮层呈现器打开时触发。 |
| `Closed` | Raised when the flyout presenter closes. / 浮层呈现器关闭时触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides a styled `FlyoutPresenter` theme with rounded corners, Semi color palette, drop shadows, and consistent padding that matches the Semi design language.

Semi.Avalonia 提供了带样式的 `FlyoutPresenter` 主题，具有圆角、Semi 调色板、投影以及与 Semi 设计语言一致的内边距。

### Pseudo-classes / 伪类

Semi.Avalonia styles the following pseudo-classes on `FlyoutPresenter`:

Semi.Avalonia 为 `FlyoutPresenter` 设置了以下伪类样式：

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:open` | The flyout is currently visible. / 浮层当前可见。 |
| `:empty` | The flyout has no content. / 浮层没有内容。 |

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `FlyoutPresenterBackground` | Flyout background color / 浮层背景色 |
| `FlyoutPresenterBorderBrush` | Flyout border color / 浮层边框颜色 |
| `FlyoutPresenterBorderThickness` | Flyout border thickness / 浮层边框粗细 |
| `FlyoutPresenterCornerRadius` | Flyout corner radius / 浮层圆角半径 |
| `FlyoutPresenterBoxShadow` | Flyout box shadow / 浮层阴影 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Popup` | `Popup` | The popup host that manages overlay and positioning. / 管理覆盖层和定位的弹出主机。 |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the flyout's content. / 渲染浮层内容。 |

### Semi.Avalonia ControlThemes / Semi.Avalonia 控件主题

Semi.Avalonia provides the `LightFlyout` ControlTheme as a lighter alternative to the default `FlyoutPresenter`. It uses a transparent background, no border, and no box shadow, making it ideal for hosting content that provides its own chrome (e.g. custom popups, tooltip-like panels, or content with built-in backgrounds).

Semi.Avalonia 提供了 `LightFlyout` ControlTheme 作为默认 `FlyoutPresenter` 的轻量替代。它使用透明背景、无边框、无投影，非常适合承载自带装饰的内容（如自定义弹出框、类工具提示面板或带有内置背景的内容）。

| Theme / 主题 | Resource Key / 资源键 | Description / 说明 |
| --- | --- | --- |
| **LightFlyout** | `LightFlyout` | Transparent flyout with no border, no box shadow. / 透明浮层，无边框、无投影。 |

```xml
<!-- Default FlyoutPresenter: visible border and shadow -->
<Flyout>
    <StackPanel Spacing="8">
        <TextBlock Text="Standard flyout" />
    </StackPanel>
</Flyout>

<!-- LightFlyout: transparent, no border or shadow -->
<Flyout FlyoutPresenterTheme="{StaticResource LightFlyout}">
    <StackPanel Spacing="8">
        <TextBlock Text="Lightweight flyout" />
    </StackPanel>
</Flyout>
```

## FAQ / 常见问题

**Q: When should I use FlyoutPresenter vs. Popup? / 何时使用 FlyoutPresenter 而非 Popup？**

A: `FlyoutPresenter` is the internal host for `Flyout` controls and is managed automatically by the flyout infrastructure. Use `Popup` only when you need standalone popup behavior outside the flyout system. `FlyoutPresenter` integrates with `FlyoutBase.ShowAttachedFlyout()` and handles focus, dismissal, and placement automatically.

`FlyoutPresenter` 是 `Flyout` 控件的内部宿主，由浮层基础设施自动管理。仅在需要浮层系统之外的独立弹出行为时才使用 `Popup`。`FlyoutPresenter` 与 `FlyoutBase.ShowAttachedFlyout()` 集成，自动处理焦点、关闭和定位。

**Q: How do I customize the animation of a FlyoutPresenter? / 如何自定义 FlyoutPresenter 的动画？**

A: Set `Flyout.OverlayDismissEventPassThrough` and use `TransitioningContentControl`-style transitions in your custom `FlyoutPresenter` template. You can override the global style for `FlyoutPresenter` and add `Transitions` to the template.

在自定义 `FlyoutPresenter` 模板中设置 `Flyout.OverlayDismissEventPassThrough` 并使用 `TransitioningContentControl` 风格的过渡效果。你可以覆盖 `FlyoutPresenter` 的全局样式并在模板中添加 `Transitions`。

**Q: Can FlyoutPresenter content overflow the screen? / FlyoutPresenter 的内容可以超出屏幕吗？**

A: The flyout system constrains the `FlyoutPresenter` to the available screen area. If content exceeds the screen, the flyout repositions itself or clips as appropriate. Use `MaxWidth`/`MaxHeight` to control overflow explicitly.

浮层系统会将 `FlyoutPresenter` 约束在可用屏幕区域内。如果内容超出屏幕，浮层会重新定位或适当裁剪。使用 `MaxWidth`/`MaxHeight` 显式控制溢出。
