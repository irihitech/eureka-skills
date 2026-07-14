---
category: Components
title: ManagedFileChooser
subtitle: 托管文件选择器
description: Avalonia 内置的跨平台文件选择对话框控件，提供完整的文件浏览和选择功能。
---

# ManagedFileChooser / 托管文件选择器

A cross-platform, in-process file chooser dialog that provides full file-system browsing and file selection capabilities. `ManagedFileChooser` is part of `Avalonia.Dialogs` and renders entirely within the Avalonia visual tree — no native OS dialog dependency. It supports quick links (Home, Desktop, Drives), file listing with metadata (name, modified date, type, size), file type filters, and save/overwrite prompts.

跨平台进程内文件选择对话框，提供完整的文件系统浏览和文件选择功能。`ManagedFileChooser` 是 `Avalonia.Dialogs` 的一部分，完全在 Avalonia 视觉树中渲染 —— 不依赖原生操作系统对话框。它支持快速链接（主目录、桌面、驱动器）、带元数据的文件列表（名称、修改日期、类型、大小）、文件类型过滤以及保存/覆盖提示。

## When to Use / 何时使用

Use `ManagedFileChooser` when you need a file open/save dialog that works consistently across all platforms with the Semi.Avalonia look and feel. It is ideal for applications that want a fully themed, in-process file dialog without platform-specific quirks. For native OS file dialogs, use `IStorageProvider` with `FilePickerOpenOptions` / `FilePickerSaveOptions` — these may use native dialogs on supported platforms.

当你需要一个在所有平台上具有一致外观和 Semi.Avalonia 风格的文件打开/保存对话框时使用 `ManagedFileChooser`。它非常适用于希望拥有完全主题化、进程内文件对话框而无需处理平台特定问题的应用程序。需要原生操作系统文件对话框时，使用 `IStorageProvider` 配合 `FilePickerOpenOptions` / `FilePickerSaveOptions` —— 这些在支持的平台上可能使用原生对话框。

## Basic Usage / 基本使用

```xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:dialogs="using:Avalonia.Dialogs">
    <dialogs:ManagedFileChooser />
</Window>
```

```csharp
// Use via IStorageProvider — the framework selects ManagedFileChooser
// when native dialogs are unavailable
var storage = GetStorageProvider();
var options = new FilePickerOpenOptions
{
    Title = "Open Document",
    AllowMultiple = false,
    FileTypeFilters = new[]
    {
        new FilePickerFileType("Documents")
        {
            Patterns = new[] { "*.txt", "*.md", "*.pdf" }
        }
    }
};
var files = await storage.OpenFilePickerAsync(options);
```

## Common Scenarios / 常用场景

### Open File Dialog / 打开文件对话框

Launch a file open dialog with type filters.

```csharp
var options = new FilePickerOpenOptions
{
    Title = "Open Image",
    FileTypeFilters = new[]
    {
        new FilePickerFileType("Images")
        {
            Patterns = new[] { "*.png", "*.jpg", "*.jpeg", "*.gif", "*.bmp" }
        },
        new FilePickerFileType("All Files")
        {
            Patterns = new[] { "*.*" }
        }
    }
};

var files = await storage.OpenFilePickerAsync(options);
if (files.Count > 0)
{
    var path = files[0].Path.LocalPath;
    // Load the file
}
```

### Save File Dialog / 保存文件对话框

Launch a save dialog that prompts on overwrite.

```csharp
var options = new FilePickerSaveOptions
{
    Title = "Save Document",
    DefaultExtension = "txt",
    FileTypeChoices = new[]
    {
        new FilePickerFileType("Text Files") { Patterns = new[] { "*.txt" } }
    }
};

var file = await storage.SaveFilePickerAsync(options);
if (file != null)
{
    await using var stream = await file.OpenWriteAsync();
    // Write content
}
```

## Semi.Avalonia ManagedFileChooser Structure / Semi.Avalonia ManagedFileChooser 结构

The Semi.Avalonia `ManagedFileChooser` theme provides a rich, styled file dialog with distinct zones:

Semi.Avalonia 的 `ManagedFileChooser` 主题提供了丰富、带样式的文件对话框，具有不同区域：

| Zone / 区域 | Description / 说明 |
| --- | --- |
| **Quick Links** (left sidebar) | Directory shortcuts (Home, Desktop, Documents, Downloads, Drives). / 目录快捷方式（主目录、桌面、文档、下载、驱动器）。 |
| **Navigation Bar** (top) | Path breadcrumb with Up/Refresh buttons and file type filter dropdown. / 路径面包屑，带有向上/刷新按钮和文件类型过滤下拉菜单。 |
| **File List** (main area) | Grid view with Name, Modified, Type, and Size columns. Sorted by name. / 带名称、修改日期、类型和大小列的网格视图。按名称排序。 |
| **File Name Input** (bottom, save mode) | Text input for the target file name. / 目标文件名的文本输入。 |
| **Action Buttons** (bottom-right) | Open/Save and Cancel buttons. / 打开/保存和取消按钮。 |

## Styling & Templating / 样式与模板

### Semi.Avalonia ControlThemes / Semi.Avalonia 控件主题

Semi.Avalonia provides ControlThemes for all `ManagedFileChooser` components:

Semi.Avalonia 为所有 `ManagedFileChooser` 组件提供 ControlTheme：

| Theme / 主题 | TargetType / 目标类型 | Description / 说明 |
| --- | --- | --- |
| `{x:Type ManagedFileChooser}` | `ManagedFileChooser` | Main dialog theme with sidebar, nav bar, and file list. / 带侧边栏、导航栏和文件列表的主对话框主题。 |
| `{x:Type ManagedFileChooserOverwritePrompt}` | `ManagedFileChooserOverwritePrompt` | Overwrite confirmation prompt with OK/Cancel. / 带确定/取消的覆盖确认提示。 |

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `ManagedFileChooserIconForeground` | Icon color in sidebar and file list / 侧边栏和文件列表中的图标颜色 |
| `ManagedFileChooserTextForeground` | Text color throughout the dialog / 对话框中的文本颜色 |

### Template Parts / 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_QuickLinks` | `ListBox` | The quick-links sidebar list. / 快速链接侧边栏列表。 |

### Icons / 图标

The Semi theme defines built-in icons for the file chooser using `StreamGeometry`:

Semi 主题使用 `StreamGeometry` 为文件选择器定义了内置图标：

| Icon / 图标 | Description / 说明 |
| --- | --- |
| `Icon_Folder` | Folder icon / 文件夹图标 |
| `Icon_File` | File icon / 文件图标 |
| `Icon_Volume` | Drive/volume icon / 驱动器/卷图标 |

## FAQ / 常见问题

**Q: When does Avalonia use ManagedFileChooser vs. a native dialog? / Avalonia 何时使用 ManagedFileChooser 而非原生对话框？**

A: Avalonia prefers native file dialogs when the platform supports them. `ManagedFileChooser` is used as a fallback when native dialogs are unavailable (e.g., Linux without a portal, embedded/browser scenarios) or when explicitly requested. It guarantees a consistent Semi-themed experience across all platforms.

当平台支持时，Avalonia 优先使用原生文件对话框。`ManagedFileChooser` 在原生对话框不可用时作为回退方案（例如没有 portal 的 Linux、嵌入式/浏览器场景），或在显式请求时使用。它保证在所有平台上提供一致的 Semi 主题体验。

**Q: Can I customize the ManagedFileChooser appearance? / 可以自定义 ManagedFileChooser 的外观吗？**

A: Yes, the `ManagedFileChooser` ControlTheme is defined in Semi.Avalonia and can be overridden. Override the `{x:Type ManagedFileChooser}` ControlTheme or customize the `DynamicResource` brushes (`ManagedFileChooserIconForeground`, `ManagedFileChooserTextForeground`) to match your application's styling.

可以，`ManagedFileChooser` 的 ControlTheme 在 Semi.Avalonia 中定义，可以被覆盖。覆盖 `{x:Type ManagedFileChooser}` ControlTheme 或自定义 `DynamicResource` 笔刷（`ManagedFileChooserIconForeground`、`ManagedFileChooserTextForeground`）以匹配应用程序的样式。

**Q: Does ManagedFileChooser support multiple file selection? / ManagedFileChooser 支持多文件选择吗？**

A: Yes. Set `AllowMultiple = true` in `FilePickerOpenOptions`. The dialog's file list supports multi-select via Ctrl+Click and Shift+Click. The result returns a collection of `IStorageFile` objects.

支持。在 `FilePickerOpenOptions` 中设置 `AllowMultiple = true`。对话框的文件列表支持通过 Ctrl+点击和 Shift+点击进行多选。结果返回 `IStorageFile` 对象的集合。
