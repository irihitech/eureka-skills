---
category: Components
title: ControlClassesInput
subtitle: 控件样式类输入
description: >
  A tag-based editor for modifying CSS-style classes on target controls at
  runtime. Wraps TagInput for the editing UI and applies the class list to a
  Target control or controls attached via ControlClassesInput.Source. Supports
  undo, redo, and clear operations with configurable history depth.
  一个基于标签的编辑器，用于在运行时修改目标控件的 CSS 样式类。封装 TagInput
  作为编辑界面，并将类列表应用到 Target 控件或通过 ControlClassesInput.Source
  附加的控件。支持撤销、重做和清除操作，具有可配置的历史记录深度。
---

# ControlClassesInput / 控件样式类输入

## When to Use / 何时使用

Use `ControlClassesInput` to provide a runtime CSS-class editor — useful in
design tools, theme editors, debugging panels, or any scenario where users need
to add/remove Avalonia style classes on target controls interactively.

使用 `ControlClassesInput` 提供运行时 CSS 类编辑器——适用于设计工具、主题编辑
器、调试面板或任何需要用户交互式添加/移除目标控件上 Avalonia 样式类的场景。

Do NOT use `ControlClassesInput` for static class configuration — set `Classes`
directly in XAML or code-behind instead.

不要将 `ControlClassesInput` 用于静态类配置——应直接在 XAML 或代码隐藏中
设置 `Classes`。

## Basic Usage / 基本使用

### Single target / 单个目标

```xml
xmlns:u="https://irihi.tech/ursa"

<StackPanel>
    <u:ControlClassesInput Name="editor" Target="{Binding #target}" Separator=" " />
    <Button Name="target" Content="Styled Button" />
</StackPanel>
```

Type class names (space-separated) into the input; they are applied to the
target `Button`'s `Classes` collection.

在输入框中输入类名（空格分隔）；它们会被应用到目标 `Button` 的 `Classes`
集合中。

### Multiple targets via attached Source / 通过附加 Source 指定多个目标

```xml
<u:ControlClassesInput Name="editor" Separator=" " />

<Button u:ControlClassesInput.Source="{Binding #editor}" Content="Button A" />
<Button u:ControlClassesInput.Source="{Binding #editor}" Content="Button B" />
<TextBox u:ControlClassesInput.Source="{Binding #editor}" Width="100" />
<ProgressBar u:ControlClassesInput.Source="{Binding #editor}" Value="20" />
```

All controls with `u:ControlClassesInput.Source` pointing to the same
`ControlClassesInput` receive the same class list simultaneously.

所有通过 `u:ControlClassesInput.Source` 指向同一个 `ControlClassesInput`
的控件会同时收到相同的类列表。

## Common Scenarios / 常用场景

### 1. Theme class editor / 主题类编辑器

```xml
<DockPanel>
    <u:ControlClassesInput
        DockPanel.Dock="Top"
        Target="{Binding #preview}"
        Separator=" " />
    <Border Name="preview" Theme="{DynamicResource CardBorder}">
        <TextBlock Text="Preview with editable classes" />
    </Border>
</DockPanel>
```

### 2. Undo/Redo support / 撤销/重做支持

```xml
<StackPanel>
    <u:ControlClassesInput Name="editor" Target="{Binding #target}" />
    <StackPanel Orientation="Horizontal" Spacing="4">
        <Button Content="Undo" Click="OnUndo" />
        <Button Content="Redo" Click="OnRedo" />
        <Button Content="Clear" Click="OnClear" />
    </StackPanel>
</StackPanel>
```

```csharp
private void OnUndo(object? sender, RoutedEventArgs e) => editor.UnDo();
private void OnRedo(object? sender, RoutedEventArgs e) => editor.Redo();
private void OnClear(object? sender, RoutedEventArgs e) => editor.Clear();
```

The control maintains an internal undo/redo linked list with configurable depth
(`CountOfHistoricalRecord`, default 10).

控件内部维护撤销/重做的链表，深度可配置（`CountOfHistoricalRecord`，默认 10）。

### 3. Class reuse across controls / 跨控件类复用

```xml
<u:ControlClassesInput Name="shared" Target="{Binding #button1}" />

<Button Name="button1" Content="Primary Target" />
<TextBlock u:ControlClassesInput.Source="{Binding #shared}" Text="Also styled" />
```

## Property Reference / 属性参考

### ControlClassesInput Properties / ControlClassesInput 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Target` | `Control?` | `null` | The primary target control whose `Classes` are edited / 编辑其 `Classes` 的主目标控件 |
| `Separator` | `string` | `" "` | Character(s) used to split class tokens in the input / 用于分割输入中类标记的字符 |
| `TargetClasses` | `ObservableCollection<string>?` | `[]` | The current class list (drives both UI and target) / 当前类列表（驱动界面和目标） |
| `CountOfHistoricalRecord` | `int` | `10` | Maximum undo/redo history depth / 撤销/重做历史记录的最大深度 |

### Attached Properties / 附加属性

| Property | Type | Description / 说明 |
|---|---|---|
| `ControlClassesInput.Source` | `ControlClassesInput?` | Attach a styled element to receive classes from the specified input / 将样式元素附加到指定输入以接收类 |

### Methods / 方法

| Method | Description / 说明 |
|---|---|
| `UnDo()` | Revert to the previous class state / 恢复到上一个类状态 |
| `Redo()` | Reapply a previously undone class state / 重新应用之前撤销的类状态 |
| `Clear()` | Remove all classes from the target(s) / 从目标中移除所有类 |

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

No custom resource keys. The template delegates to `TagInput`, forwarding
`Separator` and two-way binding `Tags` ↔ `TargetClasses`.

没有自定义资源键。模板委托给 `TagInput`，转发 `Separator` 并通过双向绑定
连接 `Tags` ↔ `TargetClasses`。

### Template Parts / 模板部件

The template renders a single `TagInput`:

模板渲染单个 `TagInput`：

| Property | Binding / 绑定 |
|---|---|
| `Tags` | `{Binding TargetClasses, Mode=TwoWay}` |
| `Separator` | `{TemplateBinding Separator}` |
| `AllowDuplicates` | `False` |
| Default width | `200` |

### Internal Behavior / 内部行为

- History is stored as `LinkedList<List<string>>` with undo/redo behavior.
- 历史记录以 `LinkedList<List<string>>` 存储，支持撤销/重做。
- Class changes trigger `Control.Classes.Replace(strings)` on the `Target`
  and all controls attached via `ControlClassesInput.Source`.
- 类更改会在 `Target` 和所有通过 `ControlClassesInput.Source` 附加的控件上
  触发 `Control.Classes.Replace(strings)`。
- Duplicates are filtered out (via `Distinct()`).
- 重复项会被过滤掉（通过 `Distinct()`）。
- Context flyout with Undo/Redo/Clear is defined but commented out in the
  default theme.
- 带撤销/重做/清除的上下文弹出菜单已在默认主题中定义但被注释掉。

## FAQ / 常见问题

**Q: How do I persist class changes? / 如何持久化类更改？**
A: `ControlClassesInput` only modifies runtime `Classes`. For persistence, save
the `TargetClasses` collection state to your settings/configuration store and
replay on load.

`ControlClassesInput` 仅修改运行时的 `Classes`。要持久化，请将
`TargetClasses` 集合状态保存到设置/配置存储中，并在加载时重放。

**Q: What happens if Target is null? / 如果 Target 为 null 会怎样？**
A: The input still functions but classes are only applied to controls with
`ControlClassesInput.Source` attached. No exceptions are thrown.

输入仍然正常工作，但类仅应用于附加了 `ControlClassesInput.Source` 的控件。
不会抛出异常。

**Q: Can I change the separator? / 可以更改分隔符吗？**
A: Yes. Set `Separator` to any character(s). The default space works for most
CSS-class conventions.

可以。将 `Separator` 设为任意字符。默认空格适用于大多数 CSS 类约定。

**Q: Are duplicate class names allowed? / 允许重复的类名吗？**
A: No. Duplicates are filtered via `Distinct()`. The internal `TagInput` also
has `AllowDuplicates="False"`.

不允许。重复项通过 `Distinct()` 过滤。内部的 `TagInput` 也设置了
`AllowDuplicates="False"`。
