---
category: Layout
title: DefaultDialogLayout
subtitle: 默认对话框布局
description: >
  A minimal TemplatedControl that provides the default visual layout for
  OverlayDialog content. Used internally by the dialog system as a layout
  host. Has no custom properties or template parts.
  为 OverlayDialog 内容提供默认视觉布局的最小 TemplatedControl。由对话框系统
  内部使用作为布局宿主。没有自定义属性或模板部件。
---

# DefaultDialogLayout / 默认对话框布局

## When to Use / 何时使用

`DefaultDialogLayout` is an internal layout container used by the Ursa dialog
system. It is a `TemplatedControl` with no custom properties, serving as a
styled layout host for dialog content. You typically do not instantiate it
directly — the dialog system creates and manages it.

`DefaultDialogLayout` 是 Ursa 对话框系统使用的内部布局容器。它是一个没有
自定义属性的 `TemplatedControl`，作为对话框内容的样式化布局宿主。通常不直接
实例化——对话框系统会创建和管理它。

If you are customizing dialog appearance, you may interact with this control
through dialog templates or themes. For most use cases, work with the
`OverlayDialog` or `Dialog` APIs directly.

如果要自定义对话框外观，可以通过对话框模板或主题与此控件交互。大多数情况下，
直接使用 `OverlayDialog` 或 `Dialog` API。

## Basic Usage / 基本使用

`DefaultDialogLayout` is not typically used in user XAML. It is referenced
internally by the dialog system. If you need to customize the dialog layout,
override the dialog's `ContentTemplate` or dialog theme instead.

`DefaultDialogLayout` 通常不在用户 XAML 中使用。它由对话框系统内部引用。
如果需要自定义对话框布局，应覆盖对话框的 `ContentTemplate` 或对话框主题。

## Property Reference / 属性参考

No custom properties. Inherits all properties from `TemplatedControl`:
`Background`, `BorderBrush`, `BorderThickness`, `CornerRadius`, `Padding`,
`Template`, etc.

没有自定义属性。继承 `TemplatedControl` 的全部属性。

## Styling & Templating / 样式与模板

| Theme Key | Description / 说明 |
|---|---|
| `{x:Type u:DefaultDialogLayout}` | Default theme (if defined in Semi theme) / 默认主题（如果在 Semi 主题中定义） |

`DefaultDialogLayout` is defined in the `Ursa.Controls.Layout` namespace,
separate from the main `Ursa.Controls` namespace. Use the following XAML
namespace if you need to reference it directly:

`DefaultDialogLayout` 定义在 `Ursa.Controls.Layout` 命名空间中，与主
`Ursa.Controls` 命名空间分离。如需直接引用，使用以下 XAML 命名空间：

```xml
xmlns:layout="https://irihi.tech/ursa.layout"
<layout:DefaultDialogLayout />
```

## FAQ / 常见问题

**Q: Should I use DefaultDialogLayout directly? / 我应该直接使用 DefaultDialogLayout 吗？**
A: Generally no. It is an internal implementation detail of the dialog system.
Use `OverlayDialog`, `Dialog`, or `MessageBox` APIs instead.

**Q: How do I customize dialog appearance? / 如何自定义对话框外观？**
A: Override the dialog's theme or `ContentTemplate`. `DefaultDialogLayout` is
just a host — the visual appearance comes from the dialog's own template and
theme resources.
