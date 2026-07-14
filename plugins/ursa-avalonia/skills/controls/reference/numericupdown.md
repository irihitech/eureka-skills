---
category: Input
title: NumericUpDown
subtitle: 数值输入
description: >
  Numeric input control with spinner buttons, drag-to-adjust, and text-based
  editing. Generic typed variants for int, uint, double, byte, sbyte, short,
  ushort, decimal, float, long, and ulong. Supports format strings, hex input,
  and placeholder text.
  带微调按钮、拖拽调节和文本编辑的数值输入控件。提供 int、uint、double、byte、
  sbyte、short、ushort、decimal、float、long、ulong 等泛型类型变体。支持格式字符串、
  十六进制输入和占位符文本。
---

# NumericUpDown / 数值输入

## When to Use / 何时使用

Use `NumericUpDown` for bounded numeric input where the user benefits from
increment/decrement controls. Prefer it over a plain `TextBox` when you need
validation, clamping, and a spinner UI.

使用 `NumericUpDown` 进行有界的数值输入，用户可通过增减按钮调节。需要校验、钳制和
微调 UI 时优先选择它而非普通 `TextBox`。

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<!-- Integer input -->
<u:NumericIntUpDown Value="42"
                     Minimum="0"
                     Maximum="100"
                     Step="1" />

<!-- Double with fractional steps -->
<u:NumericDoubleUpDown Value="3.14"
                        Minimum="0"
                        Maximum="10"
                        Step="0.5" />

<!-- Unsigned integer -->
<u:NumericUIntUpDown Value="255"
                      Minimum="0"
                      Maximum="255" />
```

### Two-way binding / 双向绑定

```xml
<u:NumericIntUpDown Value="{Binding Age, Mode=TwoWay}"
                     Minimum="0"
                     Maximum="150" />
```

### Available typed variants / 可用的类型变体

| Control | C# type | Default Range |
|---|---|---|
| `NumericIntUpDown` | `int` | `int.MinValue` – `int.MaxValue` |
| `NumericUIntUpDown` | `uint` | `0` – `uint.MaxValue` |
| `NumericDoubleUpDown` | `double` | `double.MinValue` – `double.MaxValue` |
| `NumericByteUpDown` | `byte` | `0` – `255` |
| `NumericSByteUpDown` | `sbyte` | `-128` – `127` |
| `NumericShortUpDown` | `short` | `short.MinValue` – `short.MaxValue` |
| `NumericUShortUpDown` | `ushort` | `0` – `ushort.MaxValue` |
| `NumericDecimalUpDown` | `decimal` | `decimal.MinValue` – `decimal.MaxValue` |
| `NumericFloatUpDown` | `float` | `float.MinValue` – `float.MaxValue` |
| `NumericLongUpDown` | `long` | `long.MinValue` – `long.MaxValue` |
| `NumericULongUpDown` | `ulong` | `0` – `ulong.MaxValue` |

All variants share the same base properties and template (`StyleKeyOverride =
typeof(NumericUpDown)`).

所有变体共享相同的基础属性和模板。

## Common Scenarios / 常用场景

### 1. Drag-to-adjust / 拖拽调节

```xml
<u:NumericIntUpDown AllowDrag="True"
                     InnerLeftContent="Drag"
                     Value="2" />
```

When `AllowDrag` is `true`, a drag panel appears over the input. Click and drag
up/down to adjust the value.

当 `AllowDrag` 为 `true` 时，输入框上方会出现拖拽面板。点击并上下拖动即可调节数值。

### 2. Hex input / 十六进制输入

```xml
<u:NumericUIntUpDown Value="255"
                      FormatString="X8"
                      ParsingNumberStyle="AllowHexSpecifier"
                      InnerLeftContent="0x"
                      FontFamily="Consolas" />
```

### 3. Custom format / 自定义格式

```xml
<u:NumericDoubleUpDown Value="3.14"
                        FormatString="F2"
                        InnerRightContent="px" />
```

### 4. Size variants / 尺寸变体

```xml
<u:NumericIntUpDown Classes="Small" PlaceholderText="Small" />
<u:NumericIntUpDown Classes="Large" PlaceholderText="Large" />
```

### 5. With inner content / 带内嵌内容

```xml
<u:NumericIntUpDown InnerLeftContent="Age"
                     InnerRightContent="years"
                     Value="25" />
```

### 6. Read-only mode / 只读模式

```xml
<u:NumericIntUpDown IsReadOnly="True" Value="42" />
```

## Property Reference / 属性参考

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Value` | `T?` | (type default) | Current numeric value / 当前数值 |
| `Minimum` | `T` | (type max) | Minimum allowed value / 允许的最小值 |
| `Maximum` | `T` | (type min) | Maximum allowed value / 允许的最大值 |
| `Step` | `T` | `1` | Increment/decrement step / 增减步长 |
| `AllowSpin` | `bool` | `true` | Enable spinner buttons / 启用微调按钮 |
| `ShowButtonSpinner` | `bool` | `false` | Always show spinner (vs on hover) / 始终显示微调按钮 |
| `AllowDrag` | `bool` | `false` | Enable drag-to-adjust / 启用拖拽调节 |
| `IsReadOnly` | `bool` | `false` | Prevent text editing / 禁止文本编辑 |
| `FormatString` | `string` | `""` | .NET format string (e.g. "F2", "X8") / .NET 格式字符串 |
| `ParsingNumberStyle` | `NumberStyles` | `Any` | Number parsing style / 数字解析样式 |
| `NumberFormat` | `NumberFormatInfo?` | `CurrentInfo` | Culture-specific number format / 区域数字格式 |
| `PlaceholderText` | `string?` | `null` | Placeholder when empty / 空白时占位文本 |
| `PlaceholderForeground` | `IBrush?` | theme | Placeholder text color / 占位文本颜色 |
| `InnerLeftContent` | `object?` | `null` | Content inside the input, left side / 输入框内左侧内容 |
| `InnerRightContent` | `object?` | `null` | Content inside the input, right side / 输入框内右侧内容 |
| `HorizontalContentAlignment` | `HorizontalAlignment` | `Left` | Text alignment / 文本对齐 |
| `TextConverter` | `IValueConverter?` | `null` | Custom text ↔ value converter / 自定义文本转换器 |
| `EmptyInputValue` | `T?` | `null` | Value used when input is cleared / 清空输入时使用的值 |

**Style Classes:** `Small`, `Large`, `ClearButton`/`clearButton`, `Split`.

## Events / 事件

| Event | Args | Description / 说明 |
|---|---|---|
| `Spinned` | `SpinEventArgs` | Fires on spinner button click / 微调按钮点击时触发 |
| `ValueChanged` | `ValueChangedEventArgs<T>` | Fires when `Value` changes / 值变化时触发 |

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `NumericUpDownCornerRadius` | Control | Border corner radius |
| `NumericUpDownDefaultHeight` | Control | Default minimum height |
| `NumericUpDownLargeHeight` | `.Large` class | Large variant height |
| `NumericUpDownSmallHeight` | `.Small` class | Small variant height |
| `TextBoxPlaceholderForeground` | Placeholder | Placeholder text color |
| `NonErrorTextBox` | TextBox | TextBox theme (error-free) |
| `SplitButtonSpinner` | `.Split` class | Split-style spinner theme |
| `InnerIconButton` | Clear button | Clear button theme |

### Template Parts / 模板部件

| Part Name | Type | Description |
|---|---|---|
| `PART_Spinner` | `ButtonSpinner` | Spinner host |
| `PART_TextBox` | `TextBox` | Text input area |
| `PART_DragPanel` | `Panel` | Drag-to-adjust hit area |
| `PART_ClearButton` | `Button` | Clear (×) button |

### Class Selectors / 类选择器

| Class | Effect |
|---|---|
| `Small` | Reduced height |
| `Large` | Increased height |
| `ClearButton` / `clearButton` | Show clear button on focus/hover |
| `Split` | Split spinner style with separate buttons |

## FAQ / 常见问题

**Q: What's the difference between step and drag sensitivity?**
A: `Step` controls both spinner increment and drag sensitivity. There is no
separate drag sensitivity — both use the same `Step` value.

**Q: How do I allow empty input? / 如何允许空输入？**
A: Use `EmptyInputValue` to set the value when the text box is cleared. The
base type `T?` is nullable by default.

**Q: Why does my hex input parse incorrectly? / 为什么十六进制输入解析不正确？**
A: Set `ParsingNumberStyle="AllowHexSpecifier"` and use a format string like
`"X8"`. Also set `FontFamily="Consolas"` for monospace display.

**Q: Can I use the "old" Avalonia NumericUpDown?**
A: Ursa's `NumericUpDown` is a completely different control. The base type
`NumericUpDown` is abstract — always use a typed variant like
`NumericIntUpDown`.

**Q: How do I validate the value? / 如何验证值？**
A: Attach `DataValidationErrors.Error` to the control, or use
`ExceptionValidationRule` in your binding. The control supports standard
Avalonia data validation.
