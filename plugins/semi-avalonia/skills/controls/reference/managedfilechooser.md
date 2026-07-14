---
category: Components
title: ManagedFileChooser
subtitle: 托管文件选择器
description: 托管文件选择器提供跨平台的文件打开和保存对话框的 Avalonia 内置实现。
---

# ManagedFileChooser / 托管文件选择器

Avalonia's built-in cross-platform file picker dialog. Rendered in-app rather than using native OS dialogs. Used when native dialogs are unavailable or for consistent theming. Inherits from `UserControl`.

Avalonia 内置的跨平台文件选择对话框。在应用内渲染而非使用原生系统对话框。当原生对话框不可用或需要统一主题时使用。继承自 `UserControl`。

## When to Use / 何时使用

`ManagedFileChooser` is used internally by Avalonia's `IStorageProvider` on platforms without native dialog support. Application developers typically interact with `StorageProvider.OpenFilePickerAsync()` — the `ManagedFileChooser` is the fallback rendering engine.

由 Avalonia 的 `IStorageProvider` 在无原生对话框支持的平台上内部使用。应用开发者通常通过 `StorageProvider.OpenFilePickerAsync()` 交互——`ManagedFileChooser` 是后备渲染引擎。

## Basic Usage / 基本使用

```csharp
// Application code — uses ManagedFileChooser as fallback automatically
var files = await TopLevel.GetTopLevel(this)
    .StorageProvider
    .OpenFilePickerAsync(new FilePickerOpenOptions
    {
        Title = "Open File",
        AllowMultiple = true
    });
```

## Styling & Templating / 样式与模板

Semi.Avalonia themes the `ManagedFileChooser` with `ManagedFileChooserBackground`, `ManagedFileChooserItemBackground`. The control uses Semi's theme-aware colors for consistent appearance with the rest of the UI.

## FAQ / 常见问题

**Q: Do I need to use ManagedFileChooser directly? / 我需要直接使用它吗？**

A: No. Use `StorageProvider` API which automatically chooses native or managed dialog. `ManagedFileChooser` is internal infrastructure. / 不需要。使用 `StorageProvider` API 自动选择原生或托管对话框。