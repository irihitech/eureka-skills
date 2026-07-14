---
category: Components
title: EnumSelector
subtitle: 枚举选择器
description: 将任意枚举类型自动转换为下拉选择框，支持 Description 特性显示名、自定义枚举值列表和完全自定义的选项。
---

## EnumSelector / 枚举选择器

A `TemplatedControl` that wraps a `ComboBox` and automatically populates it with values from a .NET `Enum` type. Each enum member becomes an `EnumItemTuple` with a `DisplayName` (from `[Description]` attribute or enum name) and `Value`. Supports filtering which enum values are shown via `EnumValues`, custom display names via `DisplayDescription`, and manual `EnumItemTuple` lists for full control.

一个 `TemplatedControl`，包裹 `ComboBox` 并自动填充来自 .NET `Enum` 类型的值。每个枚举成员成为一个 `EnumItemTuple`，包含 `DisplayName`（来自 `[Description]` 特性或枚举名称）和 `Value`。支持通过 `EnumValues` 过滤显示哪些枚举值、通过 `DisplayDescription` 自定义显示名称以及手动 `EnumItemTuple` 列表的完全控制。

## When to Use / 何时使用

Use `EnumSelector` when you need a dropdown bound to an enum type — for example, status selectors, sort order pickers, or theme togglers. It is simpler than binding a `ComboBox` manually. For general-purpose item selection not tied to an enum, use a standard `ComboBox` or `SelectionList`.

当你需要绑定枚举类型的下拉框时使用 `EnumSelector` —— 例如状态选择器、排序方式选择器或主题切换器。它比手动绑定 `ComboBox` 更简单。对于不绑定枚举的通用项目选择，请使用标准 `ComboBox` 或 `SelectionList`。

## Basic Usage / 基本使用

```xml
<u:EnumSelector
    EnumType="{x:Type system:DayOfWeek}"
    Value="{Binding SelectedDay}" />
```

```csharp
// Code-behind
var selector = new EnumSelector
{
    EnumType = typeof(DayOfWeek),
    Value = DayOfWeek.Monday
};
```

## Common Scenarios / 常用场景

### Using Description Attributes / 使用 Description 特性

When `DisplayDescription="True"`, the control reads `[Description]` attributes:

```csharp
public enum Status
{
    [Description("Pending Review")]
    Pending,
    [Description("Approved")]
    Approved,
    [Description("Rejected")]
    Rejected
}
```

```xml
<u:EnumSelector
    EnumType="{x:Type local:Status}"
    DisplayDescription="True"
    Value="{Binding CurrentStatus}" />
```

Without `DisplayDescription`, the raw enum name is shown (e.g., "Pending", "Approved").

### Custom Enum Values Subset / 自定义枚举值子集

Filter which enum members appear:

```xml
<u:EnumSelector
    EnumType="{x:Type system:DayOfWeek}"
    Value="{Binding WorkDay}">
    <u:EnumSelector.EnumValues>
        <generic:List x:TypeArguments="system:DayOfWeek">
            <system:DayOfWeek>Monday</system:DayOfWeek>
            <system:DayOfWeek>Tuesday</system:DayOfWeek>
            <system:DayOfWeek>Wednesday</system:DayOfWeek>
            <system:DayOfWeek>Thursday</system:DayOfWeek>
            <system:DayOfWeek>Friday</system:DayOfWeek>
        </generic:List>
    </u:EnumSelector.EnumValues>
</u:EnumSelector>
```

### Custom Display Names / 自定义显示名称

Provide `EnumItemTuple` instances for complete control over display names:

```xml
<u:EnumSelector
    EnumType="{x:Type system:DayOfWeek}"
    DisplayDescription="True"
    Value="{Binding SelectedDay}">
    <u:EnumSelector.EnumValues>
        <generic:List x:TypeArguments="u:EnumItemTuple">
            <u:EnumItemTuple Value="{x:Static system:DayOfWeek.Saturday}" DisplayName="星期六" />
            <u:EnumItemTuple Value="{x:Static system:DayOfWeek.Sunday}" DisplayName="星期日" />
            <u:EnumItemTuple Value="{x:Static system:DayOfWeek.Monday}" DisplayName="星期一" />
        </generic:List>
    </u:EnumSelector.EnumValues>
</u:EnumSelector>
```

### Dynamic Enum Type / 动态枚举类型

Bind `EnumType` to a Type property for runtime type switching:

```xml
<ComboBox Name="typeSelector" ItemsSource="{Binding Types}"
          DisplayMemberBinding="{Binding Name}"
          SelectedItem="{Binding SelectedType}" />
<u:EnumSelector
    EnumType="{Binding SelectedType}"
    Value="{Binding Value}" />
```

## Property Reference / 属性参考

### EnumSelector Properties / EnumSelector 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `EnumType` | `Type?` | The enum type to populate. Only actual enum types pass validation. / 要填充的枚举类型。只有真正的枚举类型才能通过验证。 |
| `Value` | `object?` | The currently selected enum value. Two-way binding. Must match `EnumType`. / 当前选中的枚举值。双向绑定。必须与 `EnumType` 匹配。 |
| `SelectedValue` | `EnumItemTuple?` | Read-only direct property. The selected tuple (wraps display name + value). / 只读直接属性。选中的元组（包装显示名称和值）。 |
| `Values` | `IList<EnumItemTuple>?` | Read-only. The generated list of tuples. / 只读。生成的元组列表。 |
| `DisplayDescription` | `bool` | When true, uses `[Description]` attribute text for display names. / 设为 true 时，使用 `[Description]` 特性文本作为显示名称。 |
| `EnumValues` | `IList?` | Optional filter. If set, only these enum values are shown. Can be `IList<EnumType>` or `IList<EnumItemTuple>`. / 可选过滤器。设置后仅显示这些枚举值。可以是 `IList<EnumType>` 或 `IList<EnumItemTuple>`。 |

### EnumItemTuple Properties / EnumItemTuple 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `DisplayName` | `string?` | The display text shown in the dropdown. / 下拉框中显示的文本。 |
| `Value` | `object?` | The actual enum value. / 实际枚举值。 |

## Styling & Templating / 样式与模板

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_ComboBox` | `ComboBox` | The internal ComboBox. Class source is forwarded from `EnumSelector`. / 内部 ComboBox。类源从 `EnumSelector` 转发。 |

### Item Templates / 项目模板

When `DisplayDescription="True"`, the ComboBox's `ItemTemplate` is set to display `EnumItemTuple.DisplayName`. When `False`, it displays `EnumItemTuple.Value` (the enum member name). In both cases, the `ItemsSource` is bound to `Values`.

### DynamicResource Keys / 动态资源键

The internal `ComboBox` inherits standard Semi.Avalonia ComboBox styling. Class forwarding (`iri:ClassHelper.ClassSource`) ensures CSS-style classes on `EnumSelector` propagate to the internal `ComboBox`, enabling `Classes="Small"` etc.

## FAQ / 常见问题

**Q: What happens if I set EnumType to a non-enum type? / 如果设置 EnumType 为非枚举类型会怎样？**

A: The property validation (`OnTypeValidate`) returns `false`, and the value is rejected. The control will show an empty dropdown. / 属性验证（`OnTypeValidate`）返回 `false`，值被拒绝。控件将显示空下拉框。

**Q: Can I use EnumSelector without setting EnumType? / 可以不设置 EnumType 使用 EnumSelector 吗？**

A: Yes, if you provide `EnumValues` as `IList<EnumItemTuple>`, the control uses those tuples directly. However, `EnumType` is still recommended for proper value type coercion. / 可以，如果你提供 `EnumValues` 为 `IList<EnumItemTuple>`，控件会直接使用这些元组。但仍然推荐设置 `EnumType` 以确保正确的值类型强制转换。

**Q: How does Value coercion work? / Value 强制转换如何工作？**

A: The `Value` property has a coerce callback that ensures the value is a valid member of `EnumType` and exists in `Values`. If not, it coerces to `null`. This prevents invalid states when switching `EnumType` dynamically. / `Value` 属性具有强制转换回调，确保值是 `EnumType` 的有效成员并存在于 `Values` 中。如果不是，则强制转换为 `null`。这可以防止动态切换 `EnumType` 时出现无效状态。
