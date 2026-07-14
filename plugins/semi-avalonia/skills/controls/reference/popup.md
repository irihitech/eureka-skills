---
category: Components
title: Popup
subtitle: 弹出层
description: 在独立顶层窗口中显示任意内容的弹出控件，支持定位、动画和焦点管理。
---

# Popup / 弹出层

A control that displays arbitrary content in its own top-level window, overlaying the main application. `Popup` inherits from `Control` and manages its own `PopupRoot` and `TopLevel` infrastructure. It supports configurable placement, horizontal/vertical offsets, animation transitions, and focus/dismissal behavior through overlay input handling.

在独立的顶层窗口中显示任意内容的控件，覆盖在主应用程序之上。`Popup` 继承自 `Control`，管理自己的 `PopupRoot` 和 `TopLevel` 基础设施。它支持可配置的定位、水平和垂直偏移、动画过渡以及通过覆盖输入处理实现的焦点/关闭行为。

## When to Use / 何时使用

Use `Popup` for custom overlay content that needs independent positioning — tooltips, dropdowns, context-sensitive pickers, or custom dialog overlays. For standard dropdown menus attached to buttons, prefer `Flyout` or `MenuFlyout`. For informational tooltips tied to hover, use `ToolTip`. `Popup` is the lowest-level overlay primitive; use it when the higher-level flyout/tooltip infrastructure doesn't meet your needs.

当你需要独立定位的自定义覆盖内容时使用 `Popup` —— 工具提示、下拉菜单、上下文选择器或自定义对话框覆盖层。对于附加到按钮的标准下拉菜单，建议使用 `Flyout` 或 `MenuFlyout`。对于与悬停相关的信息提示，使用 `ToolTip`。`Popup` 是最底层的覆盖原语；当更高级别的浮层/工具提示基础设施不满足需求时才使用它。

## Basic Usage / 基本使用

```xml
<ToggleButton x:Name="PopupToggle" Content="Show Popup" />
<Popup IsOpen="{Binding IsChecked, ElementName=PopupToggle}"
       Placement="Bottom"
       PlacementTarget="{Binding ElementName=PopupToggle}">
    <Border Background="{DynamicResource SemiPopupBackground}"
            CornerRadius="8" Padding="12"
            BoxShadow="0 4 12 rgba(0,0,0,0.15)">
        <StackPanel Spacing="8" Width="200">
            <TextBlock Text="Custom Popup Content" FontWeight="Bold" />
            <Button Content="Action 1" />
            <Button Content="Action 2" />
        </StackPanel>
    </Border>
</Popup>
```

```csharp
// Programmatic creation
var popup = new Popup
{
    Placement = PlacementMode.Bottom,
    PlacementTarget = targetButton,
    IsOpen = true,
    Child = new Border
    {
        Background = Brushes.White,
        CornerRadius = new CornerRadius(8),
        Padding = new Thickness(12),
        Child = new TextBlock { Text = "Popup content" },
    }
};
```

## Common Scenarios / 常用场景

### Popup as Custom Dropdown / 作为自定义下拉菜单

Create a searchable dropdown or color picker:

```xml
<ToggleButton x:Name="DropdownToggle" Content="Select..." />
<Popup IsOpen="{Binding IsChecked, ElementName=DropdownToggle}"
       Placement="BottomEdgeAlignedLeft"
       PlacementTarget="{Binding ElementName=DropdownToggle}"
       StaysOpen="False">
    <Border Background="{DynamicResource SemiPopupBackground}"
            CornerRadius="8" Padding="4" MinWidth="200">
        <ListBox ItemsSource="{Binding Options}" 
                 SelectedItem="{Binding SelectedOption}">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding}" Padding="8 4" />
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Border>
</Popup>
```

### Popup with Overlay Dismissal / 带覆盖关闭的弹出层

```xml
<Popup IsOpen="{Binding IsPopupOpen}"
       IsLightDismissEnabled="True"
       Placement="Center">
    <Border Background="{DynamicResource SemiPopupBackground}"
            CornerRadius="12" Padding="24">
        <StackPanel Spacing="16">
            <TextBlock Text="Click outside to dismiss" />
            <Button Content="Close" Command="{Binding ClosePopupCommand}" />
        </StackPanel>
    </Border>
</Popup>
```

### Popup with Animation / 带动画的弹出层

```xml
<Popup IsOpen="{Binding IsPopupOpen}"
       Placement="Bottom"
       PlacementTarget="{Binding ElementName=Anchor}">
    <Popup.Transitions>
        <Transitions>
            <DoubleTransition Property="Opacity" 
                              Duration="0:0:0.2" />
        </Transitions>
    </Popup.Transitions>
    <Border Background="{DynamicResource SemiPopupBackground}"
            CornerRadius="8" Padding="16">
        <TextBlock Text="Animated popup" />
    </Border>
</Popup>
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Child` | `Control?` | The content displayed inside the popup. / 弹出窗口中显示的内容。 |
| `IsOpen` | `bool` | Whether the popup is currently visible. / 弹出窗口当前是否可见。 |
| `Placement` | `PlacementMode` | Where to position the popup: `Pointer`, `Bottom`, `Top`, `Right`, `Left`, `Center`, `AnchorAndGravity`, `Custom`. / 弹出窗口的定位方式。 |
| `PlacementTarget` | `Control?` | The control the popup positions relative to. / 弹出窗口定位所相对的控件。 |
| `PlacementAnchor` | `PopupAnchor` | Anchor point within the popup for `AnchorAndGravity` mode. / `AnchorAndGravity` 模式下弹出窗口内的锚点。 |
| `PlacementGravity` | `PopupGravity` | Gravity point within the target for `AnchorAndGravity` mode. / `AnchorAndGravity` 模式下目标内的重力点。 |
| `HorizontalOffset` | `double` | Horizontal pixel offset from placement. / 相对于定位的水平像素偏移。 |
| `VerticalOffset` | `double` | Vertical pixel offset from placement. / 相对于定位的垂直像素偏移。 |
| `IsLightDismissEnabled` | `bool` | When `true`, clicking outside the popup dismisses it. / 设为 `true` 时，点击弹出窗口外部会关闭它。 |
| `StaysOpen` | `bool` | When `true`, popup stays open when clicking outside. Overridden by `IsLightDismissEnabled`. / 设为 `true` 时，点击外部时弹出窗口保持打开。被 `IsLightDismissEnabled` 覆盖。 |
| `OverlayDismissEventPassThrough` | `bool` | When `true`, dismiss clicks also pass through to the underlying content. / 设为 `true` 时，关闭点击也会传递到底层内容。 |
| `OverlayInputPassThroughElement` | `IInputElement?` | Element that receives input events that pass through the popup overlay. / 接收通过弹出覆盖层的输入事件的元素。 |
| `WindowManagerAddShadowHint` | `bool` | Hints the window manager to add a shadow (platform-dependent). / 提示窗口管理器添加投影（取决于平台）。 |
| `Topmost` | `bool` | When `true`, popup appears above all other windows. / 设为 `true` 时，弹出窗口出现在所有其他窗口之上。 |
| `InheritsTransform` | `bool` | Whether the popup inherits render transforms from its logical parent. / 弹出窗口是否继承其逻辑父级的渲染变换。 |

## Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Opened` | Raised when the popup opens. / 弹出窗口打开时触发。 |
| `Closed` | Raised when the popup closes. / 弹出窗口关闭时触发。 |
| `PopupHostChanged` | Raised when the underlying host window changes. / 底层宿主窗口改变时触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides a styled `Popup` root theme with background color, border, and shadow settings that match the Semi overlay design language. The popup's `Child` content is responsible for its own styling; the `Popup` control itself only manages the host window.

Semi.Avalonia 提供了带样式的 `Popup` 根主题，具有与 Semi 覆盖设计语言匹配的背景颜色、边框和阴影设置。弹出窗口的 `Child` 内容负责自身样式；`Popup` 控件本身仅管理宿主窗口。

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:open` | The popup is currently visible. / 弹出窗口当前可见。 |
| `:topmost` | The popup is topmost above other windows. / 弹出窗口在其他窗口之上。 |

### DynamicResource Keys / 动态资源键

```
SemiPopupRootBackground
SemiPopupBackground
SemiPopupBorderBrush
SemiPopupForeground
SemiPopupBorderThickness
SemiPopupCornerRadius
SemiPopupShadowElevation
SemiPopupOverlayMaskBrush
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_PopupRoot` | `PopupRoot` | The top-level window that hosts the popup content. / 承载弹出内容的顶层窗口。 |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the `Child` property content. / 渲染 `Child` 属性内容。 |

## FAQ / 常见问题

**Q: When should I use Popup vs. Flyout? / 何时使用 Popup 而非 Flyout？**

A: Use `Flyout` (or `MenuFlyout`) when attaching a popup to a specific control via `Button.Flyout` or `FlyoutBase.ShowAttachedFlyout()`. The flyout system handles focus, dismissal, and placement automatically. Use `Popup` directly when you need low-level control — custom positioning logic, integration with non-standard triggers, or when the flyout infrastructure is too restrictive.

当通过 `Button.Flyout` 或 `FlyoutBase.ShowAttachedFlyout()` 将弹出窗口附加到特定控件时，使用 `Flyout`（或 `MenuFlyout`）。浮层系统会自动处理焦点、关闭和定位。当你需要底层控制时直接使用 `Popup` —— 自定义定位逻辑、与非标准触发器集成，或浮层基础设施过于限制时。

**Q: Why doesn't my Popup close when I click outside? / 为什么我的 Popup 在点击外部时不关闭？**

A: Set `IsLightDismissEnabled="True"`. Without this, the popup stays open until you programmatically set `IsOpen = false`. Also check that `StaysOpen` is `false` (it's ignored when `IsLightDismissEnabled` is `true`).

设置 `IsLightDismissEnabled="True"`。没有此设置时，弹出窗口会保持打开，直到你通过代码设置 `IsOpen = false`。同时检查 `StaysOpen` 是否为 `false`（当 `IsLightDismissEnabled` 为 `true` 时它会被忽略）。

**Q: How do I handle input outside the Popup? / 如何处理 Popup 外部的输入？**

A: Use `OverlayInputPassThroughElement` to designate a specific element that receives input events passing through the popup overlay. This is useful when you want clicks on the background to both dismiss the popup and interact with underlying controls.

使用 `OverlayInputPassThroughElement` 指定一个接收通过弹出覆盖层传递的输入事件的特定元素。当你希望背景上的点击既能关闭弹出窗口又能与底层控件交互时，这很有用。
