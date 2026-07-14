---
category: Components
title: PathPicker
subtitle: 路径选择器
description: 用于选择文件或文件夹路径的输入控件。
---

# PathPicker / 路径选择器

A text input control with a browse button for selecting file or folder paths. Supports path validation, placeholder text, and read-only mode.

带浏览按钮的文本输入控件，用于选择文件或文件夹路径。支持路径验证、占位文本和只读模式。

## When to Use / 何时使用

Use `PathPicker` in settings or configuration forms where the user must provide a file system path — log file location, export directory, tool executable path. The browse button opens a system-native file/folder dialog.

在设置或配置表单中使用 `PathPicker`，用户需提供文件系统路径 —— 如日志文件位置、导出目录、工具可执行路径。浏览按钮打开系统原生文件/文件夹对话框。

## Basic Usage / 基本使用

```xml
<ursa:PathPicker Watermark="Select a file..."
                 Path="{Binding LogFilePath}"
                 Mode="File" />
```

## Common Scenarios / 常用场景

### Folder Selection / 文件夹选择

```xml
<ursa:PathPicker Mode="Folder"
                 Title="Select export directory"
                 Path="{Binding ExportPath}" />
```

## Property Reference / 属性参考

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Path` | `string` | The selected file or folder path. / 选中的文件或文件夹路径。 |
| `Mode` | `PathPickerMode` | Selection mode: `File` or `Folder`. / 选择模式：`File` 或 `Folder`。 |
| `Title` | `string` | Dialog title shown in the file browser. / 文件浏览器中显示的对话框标题。 |
| `Filter` | `string` | File type filter (e.g. "All Files|*.*"). / 文件类型过滤器。 |
| `Watermark` | `string` | Placeholder text when no path is selected. / 未选择路径时的占位文本。 |
| `IsReadOnly` | `bool` | Disable manual text editing. / 禁用手动文本编辑。 |

## Styling & Templating / 样式与模板

Template parts: `PART_TextBox`, `PART_BrowseButton`. Theme resources: `PathPickerBackground`, `PathPickerBorderBrush`, `PathPickerButtonBackground`.

## FAQ / 常见问题

**Q: Can I use Environment.SpecialFolder with PathPicker? / 能否使用 Environment.SpecialFolder？**

A: Resolve the special folder path in your ViewModel and bind it: `Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)`.

在 ViewModel 中解析特殊文件夹路径并绑定。
