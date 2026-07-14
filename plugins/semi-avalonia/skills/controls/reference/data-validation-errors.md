---
category: Components
title: DataValidationErrors
subtitle: 数据验证错误
description: 用于显示数据绑定验证错误信息的控件，通过附加属性跟踪控件的验证状态。
---

# DataValidationErrors / 数据验证错误

A control that displays error notifiers when data validation errors occur. `DataValidationErrors` inherits from `ContentControl` and provides attached properties (`Errors`, `HasErrors`, `ErrorConverter`) to track and display validation errors on any `Control`. It is typically used inside control templates to wrap input controls and shows inline error messages.

当数据验证错误发生时显示错误提示的控件。`DataValidationErrors` 继承自 `ContentControl`，通过附加属性（`Errors`、`HasErrors`、`ErrorConverter`）来跟踪和显示任意控件上的验证错误。通常用于控件模板内部包装输入控件并显示内联错误消息。

## When to Use / 何时使用

Use `DataValidationErrors` inside custom control templates to automatically surface data binding validation errors. It is most commonly used in `TextBox` templates — whenever a bound property fails `INotifyDataErrorInfo` validation, the `DataValidationErrors` control displays the error message. Use the `:error` pseudo-class to style the owning control when errors are present.

在自定义控件模板中使用 `DataValidationErrors` 来自动显示数据绑定验证错误。最常用于 `TextBox` 模板 —— 每当绑定属性未通过 `INotifyDataErrorInfo` 验证时，`DataValidationErrors` 控件会显示错误消息。使用 `:error` 伪类在存在错误时对所属控件进行样式设置。

## Basic Usage / 基本使用

```xml
<TextBox Text="{Binding Email, Mode=TwoWay}">
    <TextBox.Template>
        <ControlTemplate>
            <DataValidationErrors>
                <TextBox Text="{Binding Email, Mode=TwoWay}"
                         Watermark="Enter email" />
            </DataValidationErrors>
        </ControlTemplate>
    </TextBox.Template>
</TextBox>
```

```csharp
// Programmatically set errors on a control
DataValidationErrors.SetErrors(myTextBox, new[]
{
    "Email format is invalid",
    "Email domain not allowed"
});

// Check if a control has errors
bool hasErrors = DataValidationErrors.GetHasErrors(myTextBox);

// Clear all errors
DataValidationErrors.ClearErrors(myTextBox);
```

## Common Scenarios / 常用场景

### INotifyDataErrorInfo Integration / 与 INotifyDataErrorInfo 集成

When your ViewModel implements `INotifyDataErrorInfo`, Avalonia's binding system automatically routes validation errors to `DataValidationErrors` via the control template.

```csharp
public class SignUpViewModel : INotifyDataErrorInfo
{
    private string _email = "";

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            ValidateEmail();
        }
    }

    private void ValidateEmail()
    {
        ClearErrors(nameof(Email));
        if (string.IsNullOrWhiteSpace(Email) || !Email.Contains('@'))
            AddError(nameof(Email), "A valid email address is required.");
    }
}
```

### Styling Input Controls on Error / 错误时对输入控件进行样式设置

Use the `:error` pseudo-class (auto-toggled by `HasErrors` attached property) to change the border or background of an input when validation fails.

```xml
<Style Selector="TextBox:error">
    <Setter Property="BorderBrush" Value="{DynamicResource DangerDefault}" />
</Style>

<Style Selector="TextBox:error /template/ Border#PART_BorderElement">
    <Setter Property="BorderBrush" Value="{DynamicResource DangerDefault}" />
</Style>
```

### Custom Error Template / 自定义错误模板

Override the `ErrorTemplate` property to customize how errors are displayed.

```xml
<DataValidationErrors>
    <DataValidationErrors.ErrorTemplate>
        <DataTemplate>
            <Border Background="{DynamicResource DangerLight}"
                    CornerRadius="4" Padding="6,4" Margin="0,4,0,0">
                <ItemsControl ItemsSource="{Binding}"
                              Foreground="{DynamicResource DangerDefault}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal" Spacing="4">
                                <PathIcon Data="{StaticResource SemiIconIssueStroked}" />
                                <TextBlock Text="{Binding}" TextWrapping="Wrap" />
                            </StackPanel>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </Border>
        </DataTemplate>
    </DataValidationErrors.ErrorTemplate>
    <ContentPresenter Name="PART_ContentPresenter"
                      Content="{TemplateBinding Content}" />
</DataValidationErrors>
```

## Attached Property Reference / 附加属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Errors` | `IEnumerable<object>?` | Gets or sets the collection of validation errors for the target control. / 获取或设置目标控件的验证错误集合。 |
| `HasErrors` | `bool` | (Read-only) Whether the target control currently has validation errors. Toggles the `:error` pseudo-class. / （只读）目标控件当前是否有验证错误。控制 `:error` 伪类。 |
| `ErrorConverter` | `Func<object, object>?` | Optional converter function to transform raw error objects before display. / 可选的转换器函数，在显示前转换原始错误对象。 |

### Static Methods / 静态方法

| Method / 方法 | Description / 说明 |
| --- | --- |
| `GetErrors(Control)` | Gets the current errors for a control. / 获取控件的当前错误。 |
| `SetErrors(Control, IEnumerable<object>?)` | Sets the error collection for a control. / 设置控件的错误集合。 |
| `SetError(Control, Exception?)` | Sets a single exception-based error. / 设置单个基于异常的错误。 |
| `ClearErrors(Control)` | Clears all errors from a control. / 清除控件的所有错误。 |
| `GetHasErrors(Control)` | Returns whether a control has errors. / 返回控件是否有错误。 |
| `GetErrorConverter(Control)` | Gets the error converter for a control. / 获取控件的错误转换器。 |
| `SetErrorConverter(Control, Func<object, object>?)` | Sets an error converter for a control. / 设置控件的错误转换器。 |

### Properties on DataValidationErrors Instance / DataValidationErrors 实例属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `ErrorTemplate` | `IDataTemplate` | The template used to render error items. Default shows errors in a vertical list. / 用于渲染错误项的模板。默认以垂直列表显示错误。 |
| `Owner` | `Control?` | The control this DataValidationErrors is attached to (auto-set via TemplatedParent). / 此 DataValidationErrors 所附加的控件（通过 TemplatedParent 自动设置）。 |

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlThemes / Semi.Avalonia 控件主题

Semi.Avalonia provides three `DataValidationErrors` ControlThemes:

Semi.Avalonia 提供三种 `DataValidationErrors` ControlTheme：

| Theme / 主题 | Description / 说明 |
| --- | --- |
| `{x:Type DataValidationErrors}` (default) | Inline error messages below the content. / 内容下方的内联错误消息。 |
| `SilentDataValidationErrors` | Hides all error messages; only the `:error` pseudo-class remains usable for styling. / 隐藏所有错误消息；仅 `:error` 伪类可用于样式设置。 |
| `TooltipDataValidationErrors` | Shows an error icon beside the content; error details appear in a tooltip. / 在内容旁显示错误图标；错误详情显示在工具提示中。 |

```xml
<!-- Default: inline errors below content -->
<DataValidationErrors>
    <TextBox Text="{Binding Name}" />
</DataValidationErrors>

<!-- Silent: only :error pseudo-class, no messages shown -->
<DataValidationErrors Theme="{StaticResource SilentDataValidationErrors}">
    <TextBox Text="{Binding Name}" />
</DataValidationErrors>

<!-- Tooltip: error icon with tooltip -->
<DataValidationErrors Theme="{StaticResource TooltipDataValidationErrors}">
    <TextBox Text="{Binding Name}" />
</DataValidationErrors>
```

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `DataValidationErrorsForeground` | Color for error text and icons / 错误文本和图标的颜色 |
| `DataValidationErrorsErrorBackground` | Background for error messages / 错误消息的背景 |
| `DataValidationErrorsErrorBorderBrush` | Border brush for error messages / 错误消息的边框画刷 |
| `DataValidationErrorsErrorForeground` | Foreground color for error messages / 错误消息的前景色 |
| `DataValidationErrorsErrorIconData` | Geometry data for the error icon / 错误图标的几何数据 |
| `DataValidationErrorsWarningBackground` | Background for warning messages / 警告消息的背景 |
| `DataValidationErrorsWarningBorderBrush` | Border brush for warning messages / 警告消息的边框画刷 |
| `DataValidationErrorsWarningForeground` | Foreground color for warning messages / 警告消息的前景色 |
| `DataValidationErrorsWarningIconData` | Geometry data for the warning icon / 警告图标的几何数据 |

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:error` | Toggled on the owning control when `HasErrors` is `true`. / 当 `HasErrors` 为 `true` 时在所属控件上触发。 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the wrapped content (e.g., the input control). / 渲染包装的内容（如输入控件）。 |

## FAQ / 常见问题

**Q: How does DataValidationErrors differ from using the `:error` pseudo-class directly? / DataValidationErrors 与直接使用 `:error` 伪类有何不同？**

A: `DataValidationErrors` is the infrastructure that *provides* the `:error` pseudo-class. When the binding system encounters a validation error, it calls `DataValidationErrors.SetErrors()` on the bound control, which internally sets `HasErrors` and toggles `:error`. You don't need to manually use `DataValidationErrors` unless you want custom error display or use the `SilentDataValidationErrors` theme.

`DataValidationErrors` 是*提供* `:error` 伪类的基础设施。当绑定系统遇到验证错误时，会在绑定控件上调用 `DataValidationErrors.SetErrors()`，内部设置 `HasErrors` 并切换 `:error`。除非需要自定义错误显示或使用 `SilentDataValidationErrors` 主题，否则无需手动使用 `DataValidationErrors`。

**Q: Can I use DataValidationErrors outside of control templates? / 可以在控件模板之外使用 DataValidationErrors 吗？**

A: Yes, but it is uncommon. You can wrap any control in a `DataValidationErrors` to get inline error display. The `Owner` property is auto-set from `TemplatedParent`, and attached properties work on any `Control`. This is useful for custom form layouts where you want consistent error display without modifying control templates.

可以，但不常见。你可以将任何控件包装在 `DataValidationErrors` 中以获得内联错误显示。`Owner` 属性会从 `TemplatedParent` 自动设置，附加属性可用于任何 `Control`。这对于需要一致错误显示但不希望修改控件模板的自定义表单布局非常有用。

**Q: When should I use SilentDataValidationErrors vs TooltipDataValidationErrors? / 何时使用 SilentDataValidationErrors 与 TooltipDataValidationErrors？**

A: Use `SilentDataValidationErrors` when you only want the `:error` pseudo-class for visual feedback (e.g., red border) without any text messages. Use `TooltipDataValidationErrors` for compact forms where inline messages would disrupt layout — the error icon indicates a problem and hovering reveals the details.

当只需要 `:error` 伪类进行视觉反馈（如红色边框）而不需要文本消息时使用 `SilentDataValidationErrors`。对于内联消息会破坏布局的紧凑表单使用 `TooltipDataValidationErrors` —— 错误图标指示存在问题，悬停时显示详细信息。
