---
category: Components
title: SplitButton
subtitle: 分割按钮
description: 分割按钮将主要操作与下拉菜单结合，提供"一键执行 + 更多选项"模式。
---

## SplitButton / 分割按钮

A composite button that splits into two clickable regions: a primary action area that executes the main `Command`, and a dropdown arrow that opens a `Flyout` with related secondary actions. Inherits from `Button` and implements `ICommandSource`. Common in toolbars for actions like "Save / Save As…", "Paste / Paste Special…", or "Undo / Undo History".

一个分为两个可点击区域的复合按钮：一个执行主要 `Command` 的操作区域，以及一个打开包含相关次要操作的 `Flyout` 的下拉箭头。继承自 `Button` 并实现 `ICommandSource`。常见于工具栏，用于"保存 / 另存为…"、"粘贴 / 选择性粘贴…"或"撤销 / 撤销历史"等操作。

## When to Use / 何时使用

Use `SplitButton` when a primary action is the most common use case, but related secondary actions should also be accessible from the same button. Examples: "Save" (primary) with "Save As…" / "Save All" (secondary); "Paste" (primary) with "Paste Special" / "Paste and Match Style" (secondary). For buttons where clicking anywhere should always open the menu, use `DropDownButton`. For a single action with no secondary options, use a plain `Button`.

当主要操作是最常用的场景，但相关的次要操作也应从同一按钮访问时使用 `SplitButton`。例如："保存"（主要）配合"另存为…"/"全部保存"（次要）；"粘贴"（主要）配合"选择性粘贴"/"粘贴并匹配样式"（次要）。对于点击任意位置始终打开菜单的按钮，使用 `DropDownButton`。对于没有次要选项的单一操作，使用普通的 `Button`。

## Basic Usage / 基本使用

```xml
<SplitButton Content="Save"
             Command="{Binding SaveCommand}">
    <SplitButton.Flyout>
        <MenuFlyout>
            <MenuItem Header="Save"
                      Command="{Binding SaveCommand}"
                      InputGesture="Ctrl+S" />
            <MenuItem Header="Save As…"
                      Command="{Binding SaveAsCommand}"
                      InputGesture="Ctrl+Shift+S" />
            <MenuItem Header="Save All"
                      Command="{Binding SaveAllCommand}"
                      InputGesture="Ctrl+K, S" />
        </MenuFlyout>
    </SplitButton.Flyout>
</SplitButton>
```

```csharp
// Programmatic creation
var splitBtn = new SplitButton
{
    Content = "Save",
    Command = new RelayCommand(OnSave)
};
splitBtn.Flyout = new MenuFlyout
{
    Items =
    {
        new MenuItem { Header = "Save",        Command = SaveCommand },
        new MenuItem { Header = "Save As…",    Command = SaveAsCommand },
        new MenuItem { Header = "Save All",    Command = SaveAllCommand }
    }
};
splitBtn.Click += (s, e) => { /* primary action */ };
```

## Common Scenarios / 常用场景

### Save with Variants / 保存及其变体

The canonical `SplitButton` use case: primary area saves immediately, dropdown offers alternative save options.

```xml
<SplitButton Content="Save"
             Classes="Primary"
             Theme="{DynamicResource SolidButton}"
             Command="{Binding QuickSaveCommand}">
    <SplitButton.Flyout>
        <MenuFlyout>
            <MenuItem Header="Save" InputGesture="Ctrl+S"
                      Command="{Binding QuickSaveCommand}" />
            <MenuItem Header="Save As…" InputGesture="Ctrl+Shift+S"
                      Command="{Binding SaveAsCommand}" />
            <MenuItem Header="Save a Copy…"
                      Command="{Binding SaveCopyCommand}" />
            <Separator />
            <MenuItem Header="Save All" InputGesture="Ctrl+K, S"
                      Command="{Binding SaveAllCommand}" />
        </MenuFlyout>
    </SplitButton.Flyout>
</SplitButton>
```

### Paste Special / 选择性粘贴

Primary area performs a standard paste; dropdown offers paste variants.

```xml
<SplitButton Content="Paste"
             Command="{Binding PasteCommand}">
    <SplitButton.Flyout>
        <MenuFlyout>
            <MenuItem Header="Paste" InputGesture="Ctrl+V"
                      Command="{Binding PasteCommand}" />
            <MenuItem Header="Paste Special…"
                      Command="{Binding PasteSpecialCommand}" />
            <MenuItem Header="Paste and Match Style"
                      Command="{Binding PasteMatchStyleCommand}" />
        </MenuFlyout>
    </SplitButton.Flyout>
</SplitButton>
```

### Programmatic Flyout Open / 编程打开浮层

Open the flyout programmatically without clicking the dropdown arrow.

```csharp
// Open the flyout from code
splitButton.Flyout?.ShowAt(splitButton);

// Or set IsOpen programmatically (if supported by the flyout)
if (splitButton.Flyout is MenuFlyout menuFlyout)
{
    menuFlyout.ShowAt(splitButton);
}
```

### Disabled with Tooltip / 禁用状态与提示

Show a tooltip explaining why the primary action is unavailable.

```xml
<SplitButton Content="Undo"
             Command="{Binding UndoCommand}"
             ToolTip.Tip="{Binding UndoTooltip}">
    <SplitButton.Flyout>
        <MenuFlyout>
            <MenuItem Header="Undo History…"
                      Command="{Binding UndoHistoryCommand}" />
            <MenuItem Header="Redo"
                      Command="{Binding RedoCommand}" />
        </MenuFlyout>
    </SplitButton.Flyout>
</SplitButton>
```

## Property Reference / 属性参考

SplitButton inherits all properties from `Button`. Key properties:

SplitButton 继承 `Button` 的所有属性。关键属性：

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Content` | `object` | Inherited from `ContentControl`. The label displayed on the primary action area. / 继承自 `ContentControl`。显示在主要操作区域上的标签。 |
| `Command` | `ICommand?` | Inherited from `Button`. The command invoked when the primary action area is clicked. / 继承自 `Button`。点击主要操作区域时调用的命令。 |
| `CommandParameter` | `object?` | Inherited from `Button`. Parameter passed to the primary command. / 继承自 `Button`。传递给主要命令的参数。 |
| `Flyout` | `FlyoutBase?` | Inherited from `Button`. The flyout opened when the dropdown arrow is clicked. / 继承自 `Button`。点击下拉箭头时打开的浮层。 |
| `ClickMode` | `ClickMode` | Inherited from `Button`. Affects only the primary action area. / 继承自 `Button`。仅影响主要操作区域。 |
| `IsPressed` | `bool` | Inherited from `Button`. (Read-only) Whether the primary action area is pressed. / 继承自 `Button`。（只读）主要操作区域是否被按下。 |
| `HotKey` | `KeyGesture?` | Inherited from `Button`. Keyboard shortcut for the primary action. / 继承自 `Button`。主要操作的键盘快捷键。 |

### Events / 事件

| Event / 事件 | Description / 说明 |
| --- | --- |
| `Click` | Inherited from `Button`. Raised when the primary action area is clicked. Does NOT fire when the dropdown arrow is clicked. / 继承自 `Button`。点击主要操作区域时触发。点击下拉箭头时**不会**触发。 |
| `IsPressedChanged` | Inherited from `Button`. Raised when the pressed state of the primary area changes. / 继承自 `Button`。主要区域按下状态改变时触发。 |

## Styling & Templating / 样式与模板

Semi.Avalonia styles `SplitButton` with a visible divider between the primary action area and the dropdown arrow. The two regions share the same theme but respond independently to hover/press. All `Button` themes and color/size classes apply.

Semi.Avalonia 为 `SplitButton` 在主要操作区域和下拉箭头之间设置了可见的分隔线。两个区域共享相同主题，但独立响应悬停/按下。所有 `Button` 主题和颜色/尺寸类均适用。

### ControlTheme Structure / 控件主题结构

```xml
<!-- Conceptual structure; not actual XAML -->
<Grid ColumnDefinitions="*,Auto">
    <!-- Primary action area (Grid.Column="0") -->
    <Button x:Name="PART_PrimaryButton"
            Command="{TemplateBinding Command}"
            Content="{TemplateBinding Content}" />

    <!-- Vertical divider -->
    <Border x:Name="PART_Divider" Grid.Column="1" Width="1" />

    <!-- Dropdown arrow area (Grid.Column="2") -->
    <Button x:Name="PART_DropDownButton"
            Flyout="{TemplateBinding Flyout}">
        <PathIcon Data="..." />
    </Button>
</Grid>
```

### Theme Variants / 主题变体

```xml
<SplitButton Content="Save"
             Theme="{DynamicResource SolidButton}"
             Command="{Binding SaveCommand}">
    <SplitButton.Flyout>...</SplitButton.Flyout>
</SplitButton>
```

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:pointerover` | Mouse is hovering over the primary action area or the dropdown arrow. / 鼠标悬停在主要操作区域或下拉箭头上。 |
| `:pressed` | Primary action area is being pressed. / 主要操作区域正在被按下。 |
| `:flyout-open` | The flyout is currently open. / 浮层已打开。 |
| `:disabled` | Button is disabled (`IsEnabled = false`). Both regions are disabled. / 已禁用。两个区域均禁用。 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_PrimaryButton` | `Button` | The primary action area. Fires `Click` and executes `Command`. / 主要操作区域。触发 `Click` 并执行 `Command`。 |
| `PART_DropDownButton` | `Button` | The dropdown arrow area. Opens `Flyout` on click. / 下拉箭头区域。点击时打开 `Flyout`。 |
| `PART_Divider` | `Border` | The vertical divider line between the primary and dropdown areas. / 主要区域和下拉区域之间的垂直分隔线。 |
| `PART_ContentPresenter` | `ContentPresenter` | Renders the `Content` inside the primary action area. / 在主要操作区域内部渲染 `Content`。 |

### Special ControlThemes / 特殊控件主题

Semi.Avalonia defines the `SemiSplitButtonElement` theme in `SplitButton.axaml` as the internal button theme for both the primary and dropdown regions of a `SplitButton`.

Semi.Avalonia 在 `SplitButton.axaml` 中定义了 `SemiSplitButtonElement` 主题，作为 `SplitButton` 主要和下拉区域内部按钮的主题。

#### `SemiSplitButtonElement`

**TargetType:** `Button`
**Resource Key:** `SemiSplitButtonElement`

The internal button theme used by `PART_PrimaryButton` and `PART_DropDownButton` inside the `SplitButton` control template. It renders a bare `ContentPresenter` so that all backgrounds, borders, and corner radii are supplied by the parent `SplitButton` template rather than the inner buttons themselves. This ensures the two button regions blend seamlessly into a single visual unit with a shared border and divider.

`SplitButton` 控件模板内部 `PART_PrimaryButton` 和 `PART_DropDownButton` 使用的内部按钮主题。它渲染一个裸 `ContentPresenter`，因此所有背景、边框和圆角均由父级 `SplitButton` 模板而非内部按钮自身提供。这确保了两个按钮区域无缝融合成一个具有共享边框和分割线的单一视觉单元。

```xml
<!-- Used internally; reference for custom split-button patterns -->
<Button Theme="{StaticResource SemiSplitButtonElement}"
        Content="Click me" />
```

**Key inherited properties:** `ButtonDefaultPadding`, `ButtonDefaultPrimaryForeground`, `ButtonBorderThickness`, `ButtonCornerRadius`, `ButtonDefaultFontSize`, `ButtonDefaultFontWeight`, `BackgroundSizing="OuterBorderEdge"`, `Cursor="Hand"`

## FAQ / 常见问题

**Q: How does SplitButton differ from DropDownButton? / SplitButton 与 DropDownButton 有何不同？**

A: `SplitButton` has **two** click targets: the primary action area executes `Command` and fires `Click`; the dropdown arrow opens the `Flyout`. `DropDownButton` has **one** click target: clicking anywhere on the button opens the `Flyout`. Use `SplitButton` when a single-click default action is the most frequent use case (e.g., "Save"), and the dropdown provides less common alternatives (e.g., "Save As…"). Use `DropDownButton` when the default behavior is to choose from a menu.

`SplitButton` 有**两个**点击目标：主要操作区域执行 `Command` 并触发 `Click`；下拉箭头打开 `Flyout`。`DropDownButton` 有**一个**点击目标：点击按钮任意位置都会打开 `Flyout`。当单击默认操作是最常见的用例时（如"保存"），下拉菜单提供不太常用的替代项时（如"另存为…"），使用 `SplitButton`。当默认行为是从菜单中选择时，使用 `DropDownButton`。

**Q: Can I disable just the dropdown arrow while keeping the primary action enabled? / 可以只禁用下拉箭头而保持主要操作可用吗？**

A: Not through a public property on `SplitButton`. `IsEnabled` affects both regions simultaneously. To disable only the dropdown, customize the control template and bind the `PART_DropDownButton.IsEnabled` to a separate property, or remove the `Flyout` to hide the dropdown. An alternative is to populate the flyout with disabled `MenuItem` entries when secondary actions aren't available.

`SplitButton` 上没有对应的公开属性。`IsEnabled` 会同时影响两个区域。要仅禁用下拉菜单，请自定义控件模板并将 `PART_DropDownButton.IsEnabled` 绑定到单独的属性，或移除 `Flyout` 以隐藏下拉菜单。另一种方法是在次要操作不可用时在下拉菜单中填充禁用的 `MenuItem` 项。

**Q: How do I handle the Click vs. Flyout interaction? / 如何处理 Click 和 Flyout 的交互？**

A: `Click` fires only for the primary action area and runs **before** any flyout interaction. The flyout opens only when the dropdown arrow is clicked. If you need to intercept whether the flyout is about to open (e.g., to refresh dynamic items), handle `Flyout.Opened`. To prevent the primary action from executing and instead open the flyout programmatically, check conditions in `Click` and call `flyout.ShowAt(this)`.

`Click` 仅在主要操作区域触发，并在任何浮层交互**之前**运行。浮层仅在下拉箭头被点击时打开。如果需要拦截浮层即将打开的事件（例如刷新动态项），请处理 `Flyout.Opened`。要阻止主要操作执行并改为以编程方式打开浮层，在 `Click` 中检查条件并调用 `flyout.ShowAt(this)`。
