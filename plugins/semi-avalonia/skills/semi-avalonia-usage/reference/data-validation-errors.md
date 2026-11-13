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
                         PlaceholderText="Enter email" />
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
    <!-- set any visual setter you need here; for the theme's own brushes,
         load the bundled semi-avalonia skill and use only its generated catalog -->
</Style>
```

### Custom Error Template / 自定义错误模板

Override the `ErrorTemplate` property to customize how errors are displayed.

```xml
<DataValidationErrors>
    <DataValidationErrors.ErrorTemplate>
        <DataTemplate>
            <Border
                    CornerRadius="4" Padding="6,4" Margin="0,4,0,0">
                <ItemsControl ItemsSource="{Binding}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal" Spacing="4">
                                <PathIcon Data="{StaticResource ErrorIconGeometry}" />
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

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: How does DataValidationErrors differ from using the `:error` pseudo-class directly? / DataValidationErrors 与直接使用 `:error` 伪类有何不同？**

A: `DataValidationErrors` is the infrastructure that *provides* the `:error` pseudo-class. When the binding system encounters a validation error, it calls `DataValidationErrors.SetErrors()` on the bound control, which internally sets `HasErrors` and toggles `:error`. You don't need to manually use `DataValidationErrors` unless you want custom error display or one of Semi's alternative validation display themes (see the generated `semi-avalonia` skill).

`DataValidationErrors` 是*提供* `:error` 伪类的基础设施。当绑定系统遇到验证错误时，会在绑定控件上调用 `DataValidationErrors.SetErrors()`，内部设置 `HasErrors` 并切换 `:error`。除非需要自定义错误显示或使用 Semi 的替代验证显示主题（见生成的 `semi-avalonia` skill），否则无需手动使用 `DataValidationErrors`。

**Q: Can I use DataValidationErrors outside of control templates? / 可以在控件模板之外使用 DataValidationErrors 吗？**

A: Yes, but it is uncommon. You can wrap any control in a `DataValidationErrors` to get inline error display. The `Owner` property is auto-set from `TemplatedParent`, and attached properties work on any `Control`. This is useful for custom form layouts where you want consistent error display without modifying control templates.

可以，但不常见。你可以将任何控件包装在 `DataValidationErrors` 中以获得内联错误显示。`Owner` 属性会从 `TemplatedParent` 自动设置，附加属性可用于任何 `Control`。这对于需要一致错误显示但不希望修改控件模板的自定义表单布局非常有用。

**Q: Semi.Avalonia offers alternative validation display themes — which should I pick? / Semi.Avalonia 提供替代的验证显示主题 —— 该怎么选？**

A: Semi.Avalonia defines ControlTheme variants for `DataValidationErrors` beyond the default inline display (a silent variant that only toggles `:error` without messages, and a tooltip variant whose error icon reveals details on hover — the exact theme keys are listed in the generated `semi-avalonia` skill). Pick the silent one when you draw your own feedback, and the tooltip one for compact forms where inline messages would disrupt the layout.

A: Semi.Avalonia 为 `DataValidationErrors` 定义了默认内联显示之外的 ControlTheme 变体（仅切换 `:error` 不显示消息的静默变体，以及通过错误图标悬停显示详情的提示变体 —— 具体主题键见生成的 `semi-avalonia` skill）。自己绘制反馈时选静默变体；内联消息会破坏布局的紧凑表单选提示变体。
