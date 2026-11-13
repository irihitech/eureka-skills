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

`PrimaryCommands` and `SecondaryCommands` only accept `ICommandBarElement` items. The available types are:

- `CommandBarButton` — a pressable button with optional icon and label
- `CommandBarToggleButton` — a toggle button with optional icon and label
- `CommandBarSeparator` — a visual divider between groups of commands

`PrimaryCommands` 和 `SecondaryCommands` 只接受 `ICommandBarElement` 元素。可用类型为：

- `CommandBarButton` — 可按下的按钮，支持图标和标签
- `CommandBarToggleButton` — 切换按钮，支持图标和标签
- `CommandBarSeparator` — 命令组之间的视觉分隔符

```xml
<CommandBar>
    <CommandBar.PrimaryCommands>
        <CommandBarButton Label="Save" Command="{Binding SaveCommand}">
            <CommandBarButton.Icon>
                <SymbolIcon Symbol="Save" />
            </CommandBarButton.Icon>
        </CommandBarButton>
        <CommandBarSeparator />
        <CommandBarToggleButton Label="Bold" IsChecked="{Binding IsBold}">
            <CommandBarToggleButton.Icon>
                <SymbolIcon Symbol="Bold" />
            </CommandBarToggleButton.Icon>
        </CommandBarToggleButton>
    </CommandBar.PrimaryCommands>
    <CommandBar.SecondaryCommands>
        <CommandBarButton Label="Settings" />
    </CommandBar.SecondaryCommands>
</CommandBar>
```

## Styling with Semi.Avalonia / Semi.Avalonia 样式

Style classes, ControlTheme variants, pseudo-classes and overridable
DynamicResource keys for this control are not duplicated here. Load the
`semi-avalonia` skill (bundled with this plugin) and check its
`reference/classes.md` and `reference/tokens.md`, or the control's page under
https://irihitech.github.io/Semi.Avalonia/llms.txt — use only the classes,
variants and keys listed there.

此控件的样式类、ControlTheme 变体、伪类和可覆写的 DynamicResource 键不在本页重复。请加载 `semi-avalonia` skill（本插件自带），查阅其 `reference/classes.md` 与 `reference/tokens.md`，或 https://irihitech.github.io/Semi.Avalonia/llms.txt 下的控件页面 —— 只使用其中列出的类、变体与键。


## FAQ / 常见问题

**Q: CommandBar vs ToolBar? / CommandBar 和 ToolBar 的区别？**

A: `CommandBar` separates primary and secondary commands with an overflow menu. Avalonia's `ToolBar` is a simpler button strip. / `CommandBar` 通过溢出菜单分离主要和次要命令。Avalonia 的 `ToolBar` 是更简单的按钮条。