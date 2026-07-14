---
category: Components
title: DisableContainer
subtitle: 禁用容器
description: 包裹任意可输入控件并在禁用时显示半透明遮罩和提示文本的容器控件，同时提供 DisabledAdorner 附加属性用于单个控件的禁用装饰。
---

## DisableContainer / 禁用容器

A `TemplatedControl` that wraps an `InputElement` and overlays a transparent blocking rectangle when the inner content is disabled. The overlay captures all input (cursor changes to `No`) and optionally shows a `ToolTip` with the `DisabledTip` text. Also provides the `DisabledAdorner` class with attached properties to apply the same disabled overlay behavior to any single `InputElement` without a wrapper.

一个 `TemplatedControl`，包裹 `InputElement` 并在内部内容被禁用时显示透明阻挡矩形。遮罩捕获所有输入（光标变为 `No`），并可选择通过 `ToolTip` 显示 `DisabledTip` 文本。同时提供 `DisabledAdorner` 类及其附加属性，无需包装器即可对任意单个 `InputElement` 应用相同的禁用遮罩行为。

## When to Use / 何时使用

Use `DisableContainer` when you need to disable a group of controls and show a reason tooltip — for example, when a feature requires a subscription or a prerequisite step. For a single control, use `DisabledAdorner.IsEnabled` / `DisabledAdorner.DisabledTip` directly on the control to avoid extra nesting.

当你需要禁用一组控件并显示原因提示时使用 `DisableContainer` —— 例如某项功能需要订阅或前置步骤。对于单个控件，直接在控件上使用 `DisabledAdorner.IsEnabled` / `DisabledAdorner.DisabledTip`，避免额外嵌套。

## Basic Usage / 基本使用

```xml
<u:DisableContainer DisabledTip="This feature requires a Pro subscription.">
    <Button IsEnabled="{Binding IsPro}">Export Data</Button>
</u:DisableContainer>
```

```csharp
// Attached property variant for a single control
Button myButton = new();
DisabledAdorner.SetIsEnabled(myButton, true);
DisabledAdorner.SetDisabledTip(myButton, "Not available in trial mode.");
```

## Common Scenarios / 常用场景

### Group Disable with Tip / 分组禁用带提示

```xml
<ToggleSwitch Name="enableToggle" IsChecked="True" />
<u:DisableContainer DisabledTip="Controls are locked.">
    <StackPanel Spacing="8">
        <Button IsEnabled="{Binding #enableToggle.IsChecked}">Save</Button>
        <Calendar IsEnabled="{Binding #enableToggle.IsChecked}" />
    </StackPanel>
</u:DisableContainer>
```

### Single Control with Adorner / 单个控件使用装饰器

```xml
<Button
    u:DisabledAdorner.IsEnabled="True"
    u:DisabledAdorner.DisabledTip="Please complete step 1 first."
    IsEnabled="{Binding Step1Complete}">
    Next Step
</Button>
```

When `IsEnabled` is `false`, a transparent `PureRectangle` adorner is placed on top of the control, blocking interaction and showing the `DisabledTip` as a tooltip on hover.

### No Tip Variant / 无提示变体

```xml
<!-- DisableContainer without explicit tip -->
<u:DisableContainer>
    <Button IsEnabled="{Binding CanProceed}">Proceed</Button>
</u:DisableContainer>
```

## Property Reference / 属性参考

### DisableContainer Properties / DisableContainer 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Content` | `InputElement?` | The wrapped control or layout. / 被包裹的控件或布局。 |
| `DisabledTip` | `object?` | Tooltip content shown when disabled. / 禁用时显示的工具提示内容。 |

### DisabledAdorner Attached Properties / DisabledAdorner 附加属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `DisabledAdorner.IsEnabled` | `bool` | When true, a blocking adorner is added when the target `InputElement` is disabled. / 设为 true 时，当目标 `InputElement` 禁用时添加阻挡装饰器。 |
| `DisabledAdorner.DisabledTip` | `object?` | Tooltip content shown on the adorner. / 装饰器上显示的工具提示内容。 |

## Styling & Templating / 样式与模板

### DisableContainer Template / DisableContainer 模板

The default theme template is minimal:

```xml
<ControlTemplate TargetType="u:DisableContainer">
    <Panel>
        <ContentPresenter Content="{TemplateBinding Content}" />
        <iri:PureRectangle
            Background="Transparent"
            IsVisible="{Binding RelativeSource={RelativeSource TemplatedParent},
                        Path=Content.IsEnabled, Converter={x:Static BoolConverters.Not}}"
            Cursor="No"
            ToolTip.Tip="{TemplateBinding DisabledTip}" />
    </Panel>
</ControlTemplate>
```

### DisabledAdorner Mechanism / DisabledAdorner 机制

When `DisabledAdorner.IsEnabled` changes to `true`, the static class handler:
1. Creates a transparent `PureRectangle` with `IsHitTestVisible="True"`, `Cursor="No"`, and binds `ToolTip.Tip` to `DisabledAdorner.DisabledTip`.
2. Binds the rectangle's `IsVisible` to the negated `IsEnabled` of the target.
3. Sets it as an adorner via `AdornerLayer.SetAdorner`.

When `IsEnabled` changes to `false`, the adorner is removed.

## FAQ / 常见问题

**Q: Does DisableContainer work with any control? / DisableContainer 适用于所有控件吗？**

A: `DisableContainer.Content` is typed as `InputElement?`, which covers most interactive controls (`Button`, `TextBox`, `Calendar`, etc.). The overlay only blocks pointer input; it does not disable keyboard focus. Use `Focusable="False"` on the inner content if you need to prevent tab navigation. / `DisableContainer.Content` 类型为 `InputElement?`，涵盖大多数交互控件（`Button`、`TextBox`、`Calendar` 等）。遮罩仅阻止指针输入，不会禁用键盘焦点。如需阻止 Tab 导航，请在内部内容上设置 `Focusable="False"`。

**Q: When should I use DisableContainer vs DisabledAdorner? / 何时使用 DisableContainer 和 DisabledAdorner？**

A: Use `DisableContainer` to wrap a group of controls with a single disabled tip. Use `DisabledAdorner` attached properties on individual controls when you don't want the extra nesting or need per-control tips. / 使用 `DisableContainer` 包裹一组控件并显示统一禁用提示。当不需要额外嵌套或需要每个控件独立提示时，使用 `DisabledAdorner` 附加属性。

**Q: Can the DisableContainer tip be interactive? / 禁用提示可以是交互式的吗？**

A: The tip is shown via `ToolTip`, which is read-only. For interactive overlays, consider a custom `AdornerLayer` approach or a different UX pattern. / 提示通过 `ToolTip` 显示，为只读。如需交互式遮罩，请考虑自定义 `AdornerLayer` 或不同的 UX 模式。
