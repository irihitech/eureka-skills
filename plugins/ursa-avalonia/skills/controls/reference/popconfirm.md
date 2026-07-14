---
category: Components
title: PopConfirm
subtitle: 气泡确认框
description: >
  A popup confirmation dialog that anchors to a child element. Shows a header,
  body content, built-in icon (with Warning/Info/Success/Error modes), and
  Confirm/Cancel buttons with command binding. Supports Click and Focus trigger
  modes, async command handling, customizable placement, and optional custom icon.
  锚定到子元素的气泡确认对话框。显示标题、正文内容、内置图标（支持
  Warning/Info/Success/Error 模式），以及带命令绑定的确认/取消按钮。支持 Click
  和 Focus 触发模式、异步命令处理、可自定义位置和可选自定义图标。
---

# PopConfirm / 气泡确认框

## When to Use / 何时使用

Use `PopConfirm` to wrap a trigger element (typically a button or text) with a
popup confirmation step — delete confirmations, save-before-close warnings, or
any action that requires explicit user approval before execution.

使用 `PopConfirm` 包裹触发元素（通常是按钮或文本），为其添加弹出确认步骤——
删除确认、关闭前保存警告，或任何需要用户明确批准才能执行的操作。

Do NOT use `PopConfirm` for informational tooltips — use `ToolTip` or `Popup`
directly. Do NOT nest `PopConfirm` inside another `PopConfirm` — the focus-based
trigger mode can produce unpredictable behavior.

不要将 `PopConfirm` 用于信息提示——应直接使用 `ToolTip` 或 `Popup`。不要将
`PopConfirm` 嵌套在另一个 `PopConfirm` 中——基于焦点的触发模式可能产生不可预测
的行为。

## Basic Usage / 基本使用

### Wrapping a Button / 包裹按钮

```xml
xmlns:u="https://irihi.tech/ursa"

<u:PopConfirm PopupHeader="Are you sure you want to save?"
              PopupContent="This change is irreversible."
              ConfirmCommand="{Binding ConfirmCommand}"
              CancelCommand="{Binding CancelCommand}">
    <Button Content="Save" />
</u:PopConfirm>
```

### Wrapping a non-Button element / 包裹非按钮元素

```xml
<u:PopConfirm PopupHeader="Confirm deletion?"
              PopupContent="This item will be permanently removed."
              ConfirmCommand="{Binding DeleteCommand}"
              CancelCommand="{Binding CancelCommand}">
    <TextBlock Text="Delete" />
</u:PopConfirm>
```

When the child is a `Button`, the popup toggles on `Button.Click`. When the child
is any other control, the popup toggles on `PointerPressed`.

当子元素是 `Button` 时，弹出框在 `Button.Click` 时切换。当子元素是其他控件时，
弹出框在 `PointerPressed` 时切换。

## Common Scenarios / 常用场景

### 1. Focus-triggered PopConfirm / 聚焦触发的 PopConfirm

```xml
<u:PopConfirm PopupHeader="Confirm changes?"
              PopupContent="Unsaved changes will be lost."
              TriggerMode="Focus, Click"
              ConfirmCommand="{Binding ConfirmCommand}"
              CancelCommand="{Binding CancelCommand}">
    <Button Content="Close" />
</u:PopConfirm>
```

`TriggerMode="Focus, Click"` opens the popup both on focus (e.g., Tab key) and
click. When both flags are set, the click handler is suppressed after a focus
event to avoid double-toggle. The popup closes on `LostFocus` (unless focus
moves inside the popup).

`TriggerMode="Focus, Click"` 在聚焦（如 Tab 键）和点击时都会打开弹出框。当
两个标志都设置时，点击处理器在聚焦事件后被抑制以避免重复切换。弹出框在
`LostFocus` 时关闭（除非焦点移到弹出框内部）。

### 2. Async command support / 异步命令支持

```xml
<u:PopConfirm PopupHeader="Processing..."
              PopupContent="This may take a moment."
              HandleAsyncCommand="True"
              ConfirmCommand="{Binding AsyncConfirmCommand}"
              CancelCommand="{Binding AsyncCancelCommand}">
    <Button Content="Process" />
</u:PopConfirm>
```

When `HandleAsyncCommand="True"` (default), the popup stays open while the async
command is executing and closes automatically when the command completes. This
works with MVVM toolkit and Prism async commands that implement
`INotifyPropertyChanged` with `IsRunning`.

当 `HandleAsyncCommand="True"`（默认）时，弹出框在异步命令执行期间保持打开，
并在命令完成时自动关闭。这适用于实现 `INotifyPropertyChanged` 和 `IsRunning`
的 MVVM toolkit 和 Prism 异步命令。

### 3. Custom placement / 自定义位置

```xml
<u:PopConfirm PopupHeader="Confirm"
              PopupContent="Are you sure?"
              Placement="TopEdgeAlignedLeft"
              ConfirmCommand="{Binding ConfirmCommand}">
    <Button Content="Click me" />
</u:PopConfirm>
```

`Placement` accepts any `PlacementMode` value (e.g., `BottomEdgeAlignedLeft`,
`TopEdgeAlignedLeft`, `RightEdgeAlignedTop`, `Custom`, `AnchorAndGravity`, etc.).
Default is `BottomEdgeAlignedLeft`.

`Placement` 接受任何 `PlacementMode` 值（如 `BottomEdgeAlignedLeft`、
`TopEdgeAlignedLeft`、`RightEdgeAlignedTop`、`Custom`、`AnchorAndGravity` 等）。
默认为 `BottomEdgeAlignedLeft`。

### 4. Built-in icon modes / 内置图标模式

The template includes a built-in warning icon that changes based on style classes:

模板包含一个内置警告图标，根据样式类变化：

```xml
<!-- Default (Warning icon) / 默认（警告图标） -->
<u:PopConfirm PopupHeader="Warning" PopupContent="..." ConfirmCommand="{Binding Cmd}">
    <Button Content="Delete" />
</u:PopConfirm>

<!-- Info icon / 信息图标 -->
<u:PopConfirm Classes="Information" PopupHeader="Info" PopupContent="..." ConfirmCommand="{Binding Cmd}">
    <Button Content="Info" />
</u:PopConfirm>

<!-- Success icon / 成功图标 -->
<u:PopConfirm Classes="Success" PopupHeader="Success" PopupContent="..." ConfirmCommand="{Binding Cmd}">
    <Button Content="Done" />
</u:PopConfirm>

<!-- Error icon / 错误图标 -->
<u:PopConfirm Classes="Error" PopupHeader="Error" PopupContent="..." ConfirmCommand="{Binding Cmd}">
    <Button Content="Delete" />
</u:PopConfirm>
```

### 5. Custom icon (hide built-in) / 自定义图标（隐藏内置图标）

```xml
<u:PopConfirm PopupHeader="Custom action"
              PopupContent="Proceed with custom action?"
              ConfirmCommand="{Binding Cmd}">
    <u:PopConfirm.Icon>
        <PathIcon Data="{StaticResource MyCustomIcon}" />
    </u:PopConfirm.Icon>
    <Button Content="Custom" />
</u:PopConfirm>
```

When `Icon` is set, the built-in icon (`PART_BuildInIcon`) is hidden. When
`Icon` is `null`, the built-in warning icon is shown (customizable via style
classes).

当设置 `Icon` 时，内置图标（`PART_BuildInIcon`）隐藏。当 `Icon` 为 `null` 时，
显示内置警告图标（可通过样式类自定义）。

## Property Reference / 属性参考

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `PopupHeader` | `object?` | `null` | Title content of the popup / 弹出框标题内容 |
| `PopupHeaderTemplate` | `IDataTemplate?` | `null` | Template for the popup header / 弹出框标题模板 |
| `PopupContent` | `object?` | `null` | Body content of the popup / 弹出框正文内容 |
| `PopupContentTemplate` | `IDataTemplate?` | `null` | Template for the popup content / 弹出框内容模板 |
| `ConfirmCommand` | `ICommand?` | `null` | Command executed on confirm / 确认时执行的命令 |
| `ConfirmCommandParameter` | `object?` | `null` | Parameter for the confirm command / 确认命令参数 |
| `CancelCommand` | `ICommand?` | `null` | Command executed on cancel / 取消时执行的命令 |
| `CancelCommandParameter` | `object?` | `null` | Parameter for the cancel command / 取消命令参数 |
| `TriggerMode` | `PopConfirmTriggerMode` | `Click` | What triggers the popup / 触发弹出框的方式 |
| `HandleAsyncCommand` | `bool` | `true` | Keep popup open during async command execution / 异步命令执行期间保持弹出框打开 |
| `IsDropdownOpen` | `bool` | `false` | Whether the popup is open / 弹出框是否打开 |
| `Placement` | `PlacementMode` | `BottomEdgeAlignedLeft` | Where the popup appears relative to the child / 弹出框相对于子元素的位置 |
| `Icon` | `object?` | `null` | Custom icon (hides built-in icon) / 自定义图标（隐藏内置图标） |

### PopConfirmTriggerMode Enum / PopConfirmTriggerMode 枚举

| Value | Description / 说明 |
|---|---|
| `Click` | Open on click/press / 点击/按下时打开 |
| `Focus` | Open on focus (e.g., Tab) / 聚焦时（如 Tab）打开 |

Values are `[Flags]` — combine with comma: `TriggerMode="Focus, Click"`.

值为 `[Flags]`——用逗号组合：`TriggerMode="Focus, Click"`。

## Styling & Templating / 样式与模板

### Style Classes / 样式类

| Class | Description / 说明 |
|---|---|
| `Information` | Built-in icon shows information icon (blue) / 内置图标显示信息图标（蓝色） |
| `Success` | Built-in icon shows success icon (green) / 内置图标显示成功图标（绿色） |
| `Warning` | Built-in icon shows warning icon (orange, default) / 内置图标显示警告图标（橙色，默认） |
| `Error` | Built-in icon shows error icon (red) / 内置图标显示错误图标（红色） |

### Pseudo Classes / 伪类

| Pseudo Class | Description |
|---|---|
| `:dropdownopen` | Popup is open / 弹出框已打开 |
| `:icon` | Custom icon is set / 设置了自定义图标 |

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `PopConfirmBackground` | Popup border | Popup background / 弹出背景 |
| `PopConfirmBorderBrush` | Popup border | Popup border color / 弹出边框颜色 |
| `PopConfirmBorderThickness` | Popup border | Popup border thickness / 弹出边框粗细 |
| `PopConfirmBorderCornerRadius` | Popup border | Popup corner radius / 弹出圆角 |
| `PopConfirmBorderBoxShadows` | Popup border | Popup box shadows / 弹出框阴影 |
| `PopConfirmBorderMaxWidth` | Popup border | Maximum popup width / 最大弹出宽度 |
| `PopConfirmBorderPadding` | Popup border | Popup inner padding / 弹出内边距 |
| `PopConfirmBorderMargin` | Popup border | Popup outer margin / 弹出外边距 |
| `PopConfirmIconMargin` | Icon area | Icon margin / 图标间距 |
| `PopConfirmTitleFontSize` | Popup header | Header font size / 标题字号 |
| `PopConfirmTitleFontWeight` | Popup header | Header font weight / 标题字重 |
| `PopConfirmContentForeground` | Popup content | Content text color / 内容文字颜色 |
| `BannerWarningIconGeometry` | Default built-in icon | Warning icon path data / 警告图标路径数据 |
| `BannerWarningBorderBrush` | Default built-in icon | Warning icon color / 警告图标颜色 |
| `BannerInformationIconGeometry` | Info mode icon | Info icon path data / 信息图标路径数据 |
| `BannerInformationBorderBrush` | Info mode icon | Info icon color / 信息图标颜色 |
| `BannerSuccessIconGeometry` | Success mode icon | Success icon path data / 成功图标路径数据 |
| `BannerSuccessBorderBrush` | Success mode icon | Success icon color / 成功图标颜色 |
| `BannerErrorIconGeometry` | Error mode icon | Error icon path data / 错误图标路径数据 |
| `BannerErrorBorderBrush` | Error mode icon | Error icon color / 错误图标颜色 |
| `STRING_MENU_DIALOG_OK` | Confirm button | Confirm button text / 确认按钮文本 |
| `STRING_MENU_DIALOG_CANCEL` | Cancel button | Cancel button text / 取消按钮文本 |

### Template Parts / 模板部件

| Part Name | Type | Description |
|---|---|---|
| `PART_Popup` | `Popup` | The popup that appears on trigger / 触发时出现的弹出框 |
| `PART_CloseButton` | `Button` | Close (×) button in the header / 标题栏中的关闭（×）按钮 |
| `PART_ConfirmButton` | `Button` | Confirm action button / 确认操作按钮 |
| `PART_CancelButton` | `Button` | Cancel action button / 取消操作按钮 |
| `PART_ContentPresenter` | `ContentPresenter` | The wrapped child element / 被包裹的子元素 |

### How It Works / 工作原理

`PopConfirm` is a `ContentControl` that registers event handlers on its child
element based on `TriggerMode`:

- **Click mode**: If child is a `Button`, subscribes to `Button.Click`; otherwise
  subscribes to `PointerPressed`.
- **Focus mode**: Subscribes to `GotFocus` / `LostFocus` events.

The popup is light-dismiss enabled — clicking outside closes it. The close (×)
button and Cancel button both invoke `CancelCommand` with `CancelCommandParameter`.
The Confirm button invokes `ConfirmCommand` with `ConfirmCommandParameter`.

When `HandleAsyncCommand` is `true` and the command implements
`INotifyPropertyChanged`, the popup monitors `CanExecuteChanged` to detect
completion (counts to 2 events — MVVM toolkit/Prism pattern).

`PopConfirm` 是一个 `ContentControl`，根据 `TriggerMode` 在其子元素上注册事件
处理器：

- **Click 模式**：如果子元素是 `Button`，订阅 `Button.Click`；否则订阅
  `PointerPressed`。
- **Focus 模式**：订阅 `GotFocus` / `LostFocus` 事件。

弹出框启用了轻触关闭——点击外部会关闭。关闭（×）按钮和取消按钮都会调用带
`CancelCommandParameter` 的 `CancelCommand`。确认按钮调用带
`ConfirmCommandParameter` 的 `ConfirmCommand`。

当 `HandleAsyncCommand` 为 `true` 且命令实现 `INotifyPropertyChanged` 时，弹出框
监控 `CanExecuteChanged` 以检测完成（计数到 2 个事件——MVVM toolkit/Prism 模式）。

## API Reference / API 参考

### PopConfirm Class / PopConfirm 类

- **Namespace**: `Ursa.Controls`
- **Base class**: `ContentControl`
- **Child wrapping**: Registers event handlers on the `ContentPresenter.Child`
  dynamically; re-subscribes when the child changes.

### PopConfirmTriggerMode Enum / PopConfirmTriggerMode 枚举

- **Namespace**: `Ursa.Controls`
- **Values**: `Click = 1`, `Focus = 2`
- **Flags**: Combine with `TriggerMode="Click, Focus"`.
