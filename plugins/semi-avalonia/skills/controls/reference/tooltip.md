---
category: Components
title: Tooltip
subtitle: 工具提示
description: 鼠标悬停时显示的信息提示框，用于提供控件的简短说明或辅助文本。
---

# Tooltip / 工具提示

A small informational popup that appears when the user hovers over or focuses a control. `ToolTip` is an attached property on `Control` that displays a text string or custom content in a lightweight overlay. It inherits from `ContentControl` and integrates with Avalonia's tooltip service (`ToolTipService`) for timing, positioning, and dismissal.

当用户悬停或聚焦控件时出现的小型信息弹出窗口。`ToolTip` 是 `Control` 上的附加属性，在轻量覆盖层中显示文本字符串或自定义内容。它继承自 `ContentControl`，与 Avalonia 的工具提示服务（`ToolTipService`）集成，用于控制时机、定位和关闭。

## When to Use / 何时使用

Use `ToolTip` for brief, supplemental descriptions of controls — clarifying icon-only buttons, explaining disabled states, showing keyboard shortcuts, or providing context for data points in charts. Keep tooltip content concise (1-2 lines). For rich, interactive popups with actions, use `Flyout` or `Popup` instead. For context-sensitive command menus, use `ContextMenu`.

使用 `ToolTip` 提供对控件的简短补充说明 —— 解释仅图标按钮、说明禁用状态、显示键盘快捷键，或为图表中的数据点提供上下文。保持工具提示内容简洁（1-2 行）。对于带操作的丰富交互式弹出窗口，请改用 `Flyout` 或 `Popup`。对于上下文敏感的命令菜单，使用 `ContextMenu`。

## Basic Usage / 基本使用

```xml
<!-- Simple text tooltip -->
<Button Content="Save"
        ToolTip.Tip="Save the current document (Ctrl+S)" />

<!-- Tooltip with custom content -->
<Button Content="Delete">
    <ToolTip.Tip>
        <ToolTip>
            <StackPanel Spacing="4">
                <TextBlock Text="Delete Item" FontWeight="Bold" />
                <TextBlock Text="This action cannot be undone." 
                           Foreground="{DynamicResource SemiDangerBrush}" />
            </StackPanel>
        </ToolTip>
    </ToolTip.Tip>
</Button>
```

```csharp
// Programmatic creation
var button = new Button { Content = "Save" };
ToolTip.SetTip(button, "Save the current document (Ctrl+S)");

// Custom tooltip content
var tooltip = new ToolTip
{
    Content = new StackPanel
    {
        Children =
        {
            new TextBlock { Text = "Delete Item", FontWeight = FontWeight.Bold },
            new TextBlock { Text = "This action cannot be undone." },
        }
    }
};
ToolTip.SetTip(deleteButton, tooltip);
```

## Common Scenarios / 常用场景

### Tooltip on Icon Buttons / 图标按钮的工具提示

Essential for toolbar buttons that lack text labels:

```xml
<Button ToolTip.Tip="Bold (Ctrl+B)">
    <PathIcon Data="{StaticResource BoldIconGeometry}" />
</Button>

<Button ToolTip.Tip="Italic (Ctrl+I)">
    <PathIcon Data="{StaticResource ItalicIconGeometry}" />
</Button>
```

### Tooltip for Truncated Text / 截断文本的工具提示

Show full text on hover when content is clipped:

```xml
<TextBlock Text="{Binding LongDescription}"
           TextTrimming="CharacterEllipsis"
           ToolTip.Tip="{Binding LongDescription}" />
```

### Data Point Tooltip / 数据点工具提示

Provide detailed information for chart or grid data points:

```xml
<Border ToolTip.Tip="{Binding DataPointTooltip}">
    <Ellipse Width="12" Height="12" 
             Fill="{DynamicResource SemiPrimaryBrush}" />
</Border>
```

```csharp
// Tooltip binding in ViewModel
public string DataPointTooltip => 
    $"Value: {Value:N2}\nDate: {Date:d}\nCategory: {Category}";
```

### Tooltip with Placement Control / 带位置控制的工具提示

```xml
<Button Content="Help"
        ToolTip.Tip="Click for more information"
        ToolTip.Placement="Top"
        ToolTip.HorizontalOffset="4"
        ToolTip.ShowDelay="500" />
```

## Property Reference / 属性参考

### ToolTip Control Properties / ToolTip 控件属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Content` | `object?` | The tooltip content (text, control, or layout). Inherited from `ContentControl`. / 工具提示内容（文本、控件或布局）。继承自 `ContentControl`。 |
| `ContentTemplate` | `IDataTemplate?` | Template for rendering Content. / 渲染内容的模板。 |
| `IsOpen` | `bool` | Whether the tooltip is currently visible (read-only). / 工具提示当前是否可见（只读）。 |
| `Padding` | `Thickness` | Inner padding of the tooltip. / 工具提示的内边距。 |
| `MaxWidth` | `double` | Maximum width before wrapping. / 换行前的最大宽度。 |

### ToolTipService Attached Properties / ToolTipService 附加属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `ToolTip.Tip` | `object?` | The tooltip content attached to any Control. / 附加到任意控件的工具提示内容。 |
| `ToolTip.Placement` | `PlacementMode` | Where the tooltip appears relative to the control. Default: `Pointer`. / 工具提示相对于控件出现的位置。默认：`Pointer`。 |
| `ToolTip.HorizontalOffset` | `double` | Horizontal pixel offset. / 水平像素偏移。 |
| `ToolTip.VerticalOffset` | `double` | Vertical pixel offset. / 垂直像素偏移。 |
| `ToolTip.ShowDelay` | `int` | Milliseconds before the tooltip appears. Default: 400ms. / 工具提示出现前的毫秒数。默认：400ms。 |
| `ToolTip.BetweenShowDelay` | `int` | Milliseconds between showing tooltips when moving between controls. / 在控件间移动时显示工具提示之间的毫秒间隔。 |
| `ToolTip.IsOpen` | `bool` | Read/write whether the tooltip is open. / 工具提示是否打开（可读写）。 |

## Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `ToolTip.Opened` | Raised when the tooltip opens on a control. / 工具提示在控件上打开时触发。 |
| `ToolTip.Closed` | Raised when the tooltip closes on a control. / 工具提示在控件上关闭时触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia provides a styled `ToolTip` theme (`SemiToolTip`) with rounded corners, Semi color palette, subtle shadow, and compact padding suitable for brief informational overlays.

Semi.Avalonia 提供了带样式的 `ToolTip` 主题（`SemiToolTip`），具有圆角、Semi 调色板、微妙阴影和适合简短信息覆盖层的紧凑内边距。

```xml
<Button Content="Save">
    <ToolTip.Tip>
        <ToolTip Theme="{DynamicResource SemiToolTip}">
            Save the current document
        </ToolTip>
    </ToolTip.Tip>
</Button>
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:open` | The tooltip is currently visible. / 工具提示当前可见。 |
| `:pointer` | The tooltip follows the pointer position (default placement mode). / 工具提示跟随指针位置（默认定位模式）。 |

### DynamicResource Keys / 动态资源键

```
SemiToolTipBackground
SemiToolTipBorderBrush
SemiToolTipForeground
SemiToolTipBorderThickness
SemiToolTipCornerRadius
SemiToolTipPadding
SemiToolTipShadowElevation
SemiToolTipMaxWidth
```

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Popup` | `Popup` | The popup host that manages overlay and positioning. / 管理覆盖层和定位的弹出主机。 |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the tooltip's content. / 渲染工具提示内容。 |

## FAQ / 常见问题

**Q: How do I enable rich content (buttons, images) in a ToolTip? / 如何在 ToolTip 中启用富内容（按钮、图像）？**

A: Instead of setting `ToolTip.Tip="text"`, set it to a `ToolTip` element containing your layout. Rich tooltips support any control tree, but interactions are limited — buttons won't receive clicks in standard tooltip popups. For interactive overlays, use `Flyout` or `Popup` instead.

不要设置 `ToolTip.Tip="text"`，而是将其设置为包含布局的 `ToolTip` 元素。富工具提示支持任何控件树，但交互受限 —— 按钮在标准工具提示弹出窗口中无法接收点击。对于交互式覆盖层，请改用 `Flyout` 或 `Popup`。

**Q: How do I globally style all tooltips in my application? / 如何全局设置应用程序中所有工具提示的样式？**

A: Add a global style targeting `ToolTip` in your `Application.Styles` or `App.axaml`:

在 `Application.Styles` 或 `App.axaml` 中添加针对 `ToolTip` 的全局样式：

```xml
<Style Selector="ToolTip">
    <Setter Property="Background" 
            Value="{DynamicResource SemiToolTipBackground}" />
    <Setter Property="CornerRadius" Value="6" />
    <Setter Property="Padding" Value="8 4" />
</Style>
```

**Q: Why does my tooltip flash or appear and disappear quickly? / 为什么我的工具提示闪烁或快速出现和消失？**

A: Adjust `ToolTip.ShowDelay` (default 400ms) to prevent premature display, or increase `ToolTip.BetweenShowDelay` to avoid rapid-fire tooltips when moving between controls. The default values work for most scenarios but may need tuning for dense UIs or touch-first interfaces.

调整 `ToolTip.ShowDelay`（默认 400ms）以防止过早显示，或增加 `ToolTip.BetweenShowDelay` 以避免在控件间移动时快速连续显示工具提示。默认值适用于大多数场景，但对于密集 UI 或触屏优先界面可能需要调整。
