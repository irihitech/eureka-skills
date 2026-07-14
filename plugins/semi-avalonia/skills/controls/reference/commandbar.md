---
category: Components
title: CommandBar
subtitle: 命令栏
description: 命令栏用于在应用顶部或底部显示主要操作按钮和更多选项菜单。
---

# CommandBar / 命令栏

A toolbar-like control for displaying primary and secondary action buttons with an overflow menu. Inherits from `ContentControl`.

类似工具栏的控件，用于显示主要和次要操作按钮，带溢出菜单。继承自 `ContentControl`。

## When to Use / 何时使用

Use `CommandBar` for app-level action bars — top toolbar with Save/Delete/Share actions. For simple button rows, use `StackPanel` with `Button`. For context-specific actions, use `ContextMenu`.

用于应用级操作栏。简单按钮行用 `StackPanel`。上下文操作用 `ContextMenu`。

## Basic Usage / 基本使用

```xml
<CommandBar>
    <CommandBar.PrimaryCommands>
        <Button Content="Save" Command="{Binding SaveCommand}" />
        <Button Content="Delete" Classes="Danger" />
    </CommandBar.PrimaryCommands>
    <CommandBar.SecondaryCommands>
        <Button Content="Settings" />
    </CommandBar.SecondaryCommands>
</CommandBar>
```

## Styling & Templating / 样式与模板

Semi themes `CommandBar` with `CommandBarBackground`, `CommandBarForeground`. The overflow button uses `MenuFlyout` for secondary commands.

### Special ControlThemes / 特殊控件主题

Semi.Avalonia defines the `CommandBarButtonBaseTheme` in `CommandBar.axaml` as the base theme for all command bar button variants.

Semi.Avalonia 在 `CommandBar.axaml` 中定义了 `CommandBarButtonBaseTheme` 作为所有命令栏按钮变体的基础主题。

#### `CommandBarButtonBaseTheme`

**TargetType:** `Button`
**Resource Key:** `CommandBarButtonBaseTheme`

The foundational theme used by `{x:Type CommandBarButton}` and `{x:Type CommandBarToggleButton}`. Renders a `Border` (`PART_Border`) wrapping a `StackPanel` (`PART_LayoutRoot`) with icon and label presenters. Supports three label positions via the `LabelPosition` attached property: `Bottom` (default, vertical stack, icon above label), `Right` (horizontal layout), and `Collapsed` (icon only). Also supports `IsInOverflow=True` for full-width horizontal layout inside the overflow popup. Includes `:pointerover`, `:pressed`, and `:disabled` pseudo-classes.

`{x:Type CommandBarButton}` 和 `{x:Type CommandBarToggleButton}` 使用的基础主题。渲染一个包裹 `StackPanel`（`PART_LayoutRoot`）的 `Border`（`PART_Border`），内含图标和标签呈示器。通过 `LabelPosition` 附加属性支持三种标签位置：`Bottom`（默认，垂直堆叠，图标在上标签在下）、`Right`（水平布局）和 `Collapsed`（仅图标）。还支持 `IsInOverflow=True` 在溢出弹窗中实现全宽水平布局。包含 `:pointerover`、`:pressed` 和 `:disabled` 伪类。

```xml
<!-- Used as BasedOn; can be applied directly to Button for command-bar-style buttons -->
<Button Theme="{StaticResource CommandBarButtonBaseTheme}"
        Content="Save" />
```

**Template parts:** `PART_Border` (Border), `PART_LayoutRoot` (StackPanel), `PART_IconPresenter` (ContentPresenter), `PART_Label` (TextBlock)

**LabelPosition selectors:**
- `Bottom` (default): `Width="{DynamicResource CommandBarButtonCompactWidth}"`, vertical stack
- `Collapsed`: `Width="{DynamicResource CommandBarButtonCompactWidth}"`, label hidden
- `Right`: `Width="Auto"`, `MinWidth="{DynamicResource CommandBarButtonCompactWidth}"`, horizontal layout
- `IsInOverflow=True`: full-width, `HorizontalContentAlignment="Left"`, `MinHeight="{DynamicResource CommandBarButtonOverflowMinHeight}"`

**Key resources:** `CommandBarButtonCompactWidth`, `CommandBarButtonOverflowMinHeight`, `CommandBarButtonOverflowPadding`, `CommandBarButtonDefaultBackground`, `CommandBarButtonDefaultForeground`, `CommandBarButtonPointeroverBackground`, `CommandBarButtonPressedBackground`, `CommandBarButtonDisabledForeground`

## FAQ / 常见问题

**Q: CommandBar vs ToolBar? / CommandBar 和 ToolBar 的区别？**

A: `CommandBar` separates primary and secondary commands with an overflow menu. Avalonia's `ToolBar` is a simpler button strip. / `CommandBar` 通过溢出菜单分离主要和次要命令。Avalonia 的 `ToolBar` 是更简单的按钮条。