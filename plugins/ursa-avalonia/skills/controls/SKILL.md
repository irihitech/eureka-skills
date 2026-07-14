---
name: ursa-avalonia-controls
description: >
  Ursa.Avalonia control references with usage patterns, styling conventions,
  and theme resources. Load individual control references from
  `reference/<control-name>.md` when generating or reviewing code involving
  specific Ursa.Avalonia controls.
license: MIT
---

# Ursa.Avalonia Controls / Ursa.Avalonia 控件

Use this skill when working with Ursa.Avalonia controls in XAML or C#. Each
control has a dedicated reference page under `reference/` with property tables,
Ursa-specific styling, theme resources, and bilingual usage guidance.

在 XAML 或 C# 中使用 Ursa.Avalonia 控件时加载此 Skill。每个控件在 `reference/`
下都有专属参考页面，包含属性表格、Ursa 专属样式、主题资源和双语使用指南。

## How to Use / 如何使用

When the user asks about a specific control, load the corresponding reference:

当用户询问某个特定控件时，加载对应的参考文件：

```
reference/<control-name>.md
```

When the user asks about **Ursa.Avalonia-specific themes** or **control-specific
resources**, load the corresponding control reference — the `Styling & Templating`
section documents every special theme and resource key defined by Ursa.Avalonia.

当用户询问 **Ursa.Avalonia 特殊主题**或**控件专属资源**时，加载对应的控件参考文件。

Each reference contains / 每个参考页面包含：
- **When to Use / 何时使用** — criteria to decide whether this control is appropriate. / 判断是否应使用该控件的条件。
- **Basic Usage / 基本使用** — minimal XAML + C# snippet. / 最简 XAML + C# 示例。
- **Common Scenarios / 常用场景** — 2-4 realistic patterns with code. / 2-4 个真实场景及代码。
- **Property Reference / 属性参考** — key properties and events in a table. / 表格形式的属性和事件。
- **Styling & Templating / 样式与模板** — Ursa.Avalonia themes, pseudo-classes, template parts. / Ursa.Avalonia 主题、伪类、模板部件。
- **FAQ / 常见问题** — common pitfalls and cross-control comparisons. / 常见陷阱和跨控件对比。

## Controls Index / 控件索引

### Display & Feedback / 显示与反馈

| Control | File | Description |
| --- | --- | --- |
| **Avatar** | [avatar](reference/avatar.md) | User avatar with initials, image, or custom content. / 用户头像。 |
| **Badge** | [badge](reference/badge.md) | Notification badge with count, dot, overflow support. / 通知徽标。 |
| **Banner** | [banner](reference/banner.md) | Inline notification banner with icon and close. / 内联通知横幅。 |
| **DualBadge** | [dualbadge](reference/dualbadge.md) | Double-layered badge with icon, header, and content. / 双层徽标。 |
| **Loading** | [loading](reference/loading.md) | Loading indicator and loading container. / 加载指示器和加载容器。 |
| **Marquee** | [marquee](reference/marquee.md) | Scrolling text/content ticker. / 滚动文字/内容跑马灯。 |
| **NumberDisplayer** | [numberdisplayer](reference/numberdisplayer.md) | Animated number display with typed variants. / 动画数字显示器。 |
| **Notification** | [notification](reference/notification.md) | Toast-style notification with position control. / Toast 样式通知。 |
| **QRCode** | [qrcode](reference/qrcode.md) | Vector QR code renderer. / 矢量二维码渲染器。 |
| **Rating** | [rating](reference/rating.md) | Star-based rating control. / 星级评分控件。 |
| **Skeleton** | [skeleton](reference/skeleton.md) | Loading skeleton placeholder. / 加载骨架占位符。 |
| **TagInput** | [tag-input](reference/tag-input.md) | Multi-value tag/chip input. / 多值标签/碎片输入。 |
| **Timeline** | [timeline](reference/timeline.md) | Vertical timeline with nodes and content. / 垂直时间线。 |
| **Toast** | [toast](reference/toast.md) | Ephemeral toast notification. / 短暂 Toast 通知。 |

### Date & Time / 日期与时间

| Control | File | Description |
| --- | --- | --- |
| **DatePicker** | [date-picker](reference/date-picker.md) | Single date selection with calendar dropdown. / 单日期选择。 |
| **DateOnlyPicker** | [date-only-picker](reference/date-only-picker.md) | DateOnly (.NET 6+) single date picker. / DateOnly 单日期选择。 |
| **DateOffsetPicker** | [date-offset-picker](reference/date-offset-picker.md) | DateTimeOffset date picker with UTC offset. / 带 UTC 偏移的日期选择。 |
| **DateRangePicker** | [date-range-picker](reference/date-range-picker.md) | Start/end date range with dual calendars. / 起止日期范围选择。 |
| **DateOnlyRangePicker** | [date-only-range-picker](reference/date-only-range-picker.md) | DateOnly range picker. / DateOnly 范围选择。 |
| **DateOffsetRangePicker** | [date-offset-range-picker](reference/date-offset-range-picker.md) | DateTimeOffset range picker. / 带偏移的日期范围选择。 |
| **TimePicker** | [time-picker](reference/time-picker.md) | Single time selection with panel. / 单时间选择。 |
| **TimeOnlyPicker** | [time-only-picker](reference/time-only-picker.md) | TimeOnly (.NET 6+) single time picker. / TimeOnly 单时间选择。 |
| **TimeRangePicker** | [time-range-picker](reference/time-range-picker.md) | Start/end time range with dual panels. / 起止时间范围选择。 |
| **TimeOnlyRangePicker** | [time-only-range-picker](reference/time-only-range-picker.md) | TimeOnly range picker. / TimeOnly 范围选择。 |
| **DateTimePicker** | [datetimepicker](reference/datetimepicker.md) | Combined date + time single picker. / 日期+时间组合选择。 |
| **Clock** | [clock](reference/clock.md) | Analog or digital clock display. / 模拟或数字时钟显示。 |
| **TimeBox** | [timebox](reference/timebox.md) | Editable time box with drag support. / 可编辑时间输入框。 |

### Navigation & Menus / 导航与菜单

| Control | File | Description |
| --- | --- | --- |
| **Anchor** | [anchor](reference/anchor.md) | Anchor navigation with scroll-to-target. / 锚点导航。 |
| **Breadcrumb** | [breadcrumb](reference/breadcrumb.md) | Breadcrumb navigation trail. / 面包屑导航。 |
| **NavMenu** | [navmenu](reference/navmenu.md) | Side navigation menu with selection. / 侧边导航菜单。 |
| **Pagination** | [pagination](reference/pagination.md) | Page navigation with page numbers. / 分页导航。 |
| **ScrollTo** | [scrollto](reference/scrollto.md) | Scroll-to-direction buttons. / 滚动到方向按钮。 |

### Overlays & Dialogs / 浮层与对话框

> ℹ `OverlayDialog`, `MessageBox`, and `Drawer` open through an `OverlayDialogHost`. `UrsaWindow` includes one by default.
> See [OverlayDialogHost](reference/overlay-dialog-host.md) for multi-host setups and HostId rules.
>
> ℹ `OverlayDialog`、`MessageBox`、`Drawer` 通过 `OverlayDialogHost` 打开。`UrsaWindow` 默认包含一个。
> 多宿主配置和 HostId 规则参见 [OverlayDialogHost](reference/overlay-dialog-host.md)。

| Control | File | Description |
| --- | --- | --- |
| **Dialog** | [dialog](reference/dialog.md) | Modal dialog with standard/custom variants. / 模态对话框。 |
| **Drawer** | [drawer](reference/drawer.md) | Slide-out drawer panel. / 滑出抽屉面板。 |
| **MessageBox** | [messagebox](reference/messagebox.md) | Simple message dialog with buttons. / 简单消息对话框。 |
| **PopConfirm** | [popconfirm](reference/popconfirm.md) | Popover confirmation before action. / 气泡确认框。 |
| **OverlayDialogHost** | [overlay-dialog-host](reference/overlay-dialog-host.md) | Canvas host for Dialog/Drawer/MessageBox overlays. / Dialog/Drawer/MessageBox 浮层宿主。 |

### Input / 输入控件

| Control | File | Description |
| --- | --- | --- |
| **AutoCompleteBox** | [autocompletebox](reference/autocompletebox.md) | Auto-complete text + MultiAutoCompleteBox. / 自动完成输入。 |
| **ComboBox** | [combobox](reference/combobox.md) | TreeComboBox + MultiComboBox dropdowns. / 树形+多选下拉。 |
| **ControlClassesInput** | [controlclassesinput](reference/controlclassesinput.md) | Visual style-class chip editor. / 样式类标签编辑器。 |
| **EnumSelector** | [enumselector](reference/enumselector.md) | Enum value dropdown selector. / 枚举值下拉选择。 |
| **IPv4Box** | [ipv4box](reference/ipv4box.md) | IPv4 address segmented input. / IPv4 地址分段输入。 |
| **KeyGestureInput** | [keygestureinput](reference/keygestureinput.md) | Keyboard gesture capture input. / 键盘手势捕获输入。 |
| **NumPad** | [numpad](reference/numpad.md) | On-screen numeric keypad. / 屏幕数字键盘。 |
| **NumericUpDown** | [numericupdown](reference/numericupdown.md) | Numeric spinner with 11 typed variants. / 数值微调控件。 |
| **PathPicker** | [pathpicker](reference/pathpicker.md) | File/folder path picker with browse. / 文件/文件夹路径选择。 |
| **PinCode** | [pincode](reference/pincode.md) | Fixed-length PIN/password input. / 固定长度密码输入。 |
| **RangeSlider** | [rangeslider](reference/rangeslider.md) | Dual-thumb range slider. / 双滑块范围选择。 |
| **SelectionList** | [selection-list](reference/selection-list.md) | Selectable item list. / 可选择项目列表。 |
| **ThemeSelector** | [themeselector](reference/themeselector.md) | Theme toggle button with auto-detection. / 主题切换按钮。 |

### Layout & Containers / 布局与容器

| Control | File | Description |
| --- | --- | --- |
| **AspectRatioLayout** | [aspectratiolayout](reference/aspectratiolayout.md) | Aspect-ratio-constrained layout. / 宽高比约束布局。 |
| **ButtonGroup** | [button-group](reference/button-group.md) | Grouped button container. / 按钮组容器。 |
| **ColumnWrapPanel** | [column-wrap-panel](reference/column-wrap-panel.md) | Column-based wrapping panel. / 基于列的换行面板。 |
| **DefaultDialogLayout** | [default-dialog-layout](reference/default-dialog-layout.md) | Default dialog content layout. / 默认对话框内容布局。 |
| **Descriptions** | [descriptions](reference/descriptions.md) | Key-value description list. / 键值描述列表。 |
| **DisableContainer** | [disablecontainer](reference/disablecontainer.md) | Disable overlay container. / 禁用覆盖容器。 |
| **Divider** | [divider](reference/divider.md) | Horizontal/vertical divider line. / 水平/垂直分割线。 |
| **ElasticWrapPanel** | [elastic-wrap-panel](reference/elastic-wrap-panel.md) | Elastic-fill wrapping panel. / 弹性填充换行面板。 |
| **Form** | [form](reference/form.md) | Form layout with labels and validation. / 带标签和验证的表单布局。 |
| **GroupBox** | [groupbox](reference/groupbox.md) | Bordered group container with header. / 带标题边框分组容器。 |
| **ImageViewer** | [imageviewer](reference/imageviewer.md) | Zoomable/pannable image viewer. / 可缩放/平移图片查看器。 |
| **ProportionalCanvas** | [proportional-canvas](reference/proportional-canvas.md) | Proportional coordinate canvas. / 比例坐标画布。 |
| **Resizers** | [resizers](reference/resizers.md) | Window/dialog resize thumbs. / 窗口/对话框调整大小手柄。 |
| **ThemeVariantMapper** | [themevariantmapper](reference/themevariantmapper.md) | Parent-theme-to-child-theme mapper. / 父→子主题映射器。 |
| **VirtualizingUniformGrid** | [virtualizing-uniform-grid](reference/virtualizing-uniform-grid.md) | Virtualized uniform grid panel. / 虚拟化均匀网格面板。 |
| **WrapPanelWithTrailingItem** | [wrap-panel-with-trailing-item](reference/wrap-panel-with-trailing-item.md) | Wrap panel with a trailing overflow item. / 带尾部溢出项的换行面板。 |

### Toolbars & Title / 工具栏与标题

| Control | File | Description |
| --- | --- | --- |
| **IconButton** | [icon-button](reference/icon-button.md) | Icon-only button with 4 theme variants. / 纯图标按钮。 |
| **TitleBar** | [title-bar](reference/title-bar.md) | Custom window title bar. / 自定义窗口标题栏。 |
| **ToolBar** | [tool-bar](reference/tool-bar.md) | Toolbar with overflow support. / 带溢出支持的工具栏。 |
