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

## FAQ / 常见问题

**Q: CommandBar vs ToolBar? / CommandBar 和 ToolBar 的区别？**

A: `CommandBar` separates primary and secondary commands with an overflow menu. Avalonia's `ToolBar` is a simpler button strip. / `CommandBar` 通过溢出菜单分离主要和次要命令。Avalonia 的 `ToolBar` 是更简单的按钮条。