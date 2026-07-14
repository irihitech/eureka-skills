---
name: semi-avalonia-controls
description: >
  Semi.Avalonia control references with usage patterns, styling conventions,
  and DynamicResource keys. Load individual control references from
  `reference/<control-name>.md` when generating or reviewing code involving
  specific Semi.Avalonia controls.
license: MIT
---

# Semi.Avalonia Controls / Semi.Avalonia 控件

Use this skill when working with Semi.Avalonia controls in XAML or C#. Each
control has a dedicated reference page under `reference/` with property tables,
Semi-specific styling, DynamicResource keys, and bilingual usage guidance.

在 XAML 或 C# 中使用 Semi.Avalonia 控件时加载此 Skill。每个控件在 `reference/`
下都有专属参考页面，包含属性表格、Semi 专属样式、DynamicResource 键和双语使用指南。

## How to Use / 如何使用

When the user asks about a specific control (e.g., "use a Button", "style a
TextBox", "add a DataGrid"), load the corresponding reference:

当用户询问某个特定控件时（如"使用 Button"、"给 TextBox 添加样式"），加载对应的参考文件：

```
reference/<control-name>.md
```

When the user asks about **Semi.Avalonia-specific themes** or **control-specific
DynamicResource keys** (e.g., "what themes does Button support", "how to
use a CardCheckBox", "what resources does Slider define"), load the
corresponding control reference — the `Styling & Templating` and
`DynamicResource Keys` sections document every special ControlTheme and
resource key defined by Semi.Avalonia.

当用户询问 **Semi.Avalonia 特殊主题**或**控件专属 DynamicResource 键**（如"Button 支持哪些主题"、"如何使用 CardCheckBox"、"Slider 定义了哪些资源"）时，加载对应的控件参考文件 —— `Styling & Templating` 和 `DynamicResource Keys` 部分记录了 Semi.Avalonia 定义的每个特殊 ControlTheme 和资源键。

Each reference contains / 每个参考页面包含：
- **When to Use / 何时使用** — criteria to decide whether this control is appropriate. / 判断是否应使用该控件的条件。
- **Basic Usage / 基本使用** — minimal XAML + C# snippet. / 最简 XAML + C# 示例。
- **Common Scenarios / 常用场景** — 2-4 realistic patterns with code. / 2-4 个真实场景及代码。
- **Property Reference / 属性参考** — key properties and events in a table. / 表格形式的属性和事件。
- **Styling & Templating / 样式与模板** — Semi.Avalonia themes, pseudo-classes, template
  parts, and special ControlThemes. / Semi.Avalonia 主题、伪类、模板部件和特殊 ControlTheme。
- **DynamicResource Keys / 动态资源键** — every theme resource key used by the control. / 该控件使用的每个主题资源键。
- **FAQ / 常见问题** — common pitfalls and cross-control comparisons. / 常见陷阱和跨控件对比。

## Controls Index / 控件索引

### Basic Input / 基础输入

| Control | File | Description |
| --- | --- | --- |
| **Button** | [button](reference/button.md) | Clickable action trigger with 4 themes × 6 colors × 2 sizes. / 可点击的操作触发器。 |
| **TextBox** | [textbox](reference/textbox.md) | Single/multi-line text input with validation. / 单行/多行文本输入。 |
| **CheckBox** | [checkbox](reference/checkbox.md) | Toggle for boolean options, supports indeterminate. / 布尔选项切换。 |
| **RadioButton** | [radiobutton](reference/radiobutton.md) | Mutually exclusive single selection. / 互斥单选。 |
| **ToggleSwitch** | [toggleswitch](reference/toggleswitch.md) | On/off switch with immediate effect. / 即时生效的开关。 |
| **Slider** | [slider](reference/slider.md) | Range value selection with track and thumb. / 范围值选择。 |
| **ComboBox** | [combobox](reference/combobox.md) | Dropdown selection with optional editing. / 下拉选择框。 |
| **AutoCompleteBox** | [autocompletebox](reference/autocompletebox.md) | Text input with suggestion dropdown. / 带建议下拉的文本输入。 |
| **NumericUpDown** | [numeric-up-down](reference/numeric-up-down.md) | Numeric value spinner. / 数值微调控件。 |

### Button Variants / 按钮变体

| Control | File | Description |
| --- | --- | --- |
| **RepeatButton** | [repeatbutton](reference/repeatbutton.md) | Button that fires repeatedly while pressed. / 按住时重复触发的按钮。 |
| **ToggleButton** | [togglebutton](reference/togglebutton.md) | Button with checked/unchecked state. / 带选中状态的按钮。 |
| **DropDownButton** | [dropdownbutton](reference/dropdownbutton.md) | Button with an attached flyout. / 带浮出层的按钮。 |
| **SplitButton** | [splitbutton](reference/splitbutton.md) | Button with primary action + dropdown part. / 主操作+下拉部分的按钮。 |
| **HyperlinkButton** | [hyperlinkbutton](reference/hyperlinkbutton.md) | Link-styled button with URI navigation. / 链接样式的按钮。 |
| **ButtonSpinner** | [buttonspinner](reference/buttonspinner.md) | Button pair for increment/decrement. / 增减按钮对。 |

### Display & Text / 显示和文本

| Control | File | Description |
| --- | --- | --- |
| **TextBlock** | [textblock](reference/textblock.md) | Read-only text with inline formatting. / 只读文本，支持内联格式。 |
| **Label** | [label](reference/label.md) | Text label with target/access-key support. / 带目标控件关联的文本标签。 |
| **SelectableTextBlock** | [selectable-text-block](reference/selectable-text-block.md) | Selectable, copyable read-only text. / 可选择可复制的只读文本。 |
| **PathIcon** | [path-icon](reference/path-icon.md) | Vector icon from path data. / 路径数据的矢量图标。 |
| **ProgressBar** | [progress-bar](reference/progress-bar.md) | Linear or ring progress indicator. / 线性或环形进度指示器。 |

### Lists & Selection / 列表和选择

| Control | File | Description |
| --- | --- | --- |
| **ListBox** | [listbox](reference/listbox.md) | Selectable item list with virtualization. / 可选择项列表。 |
| **ItemsControl** | [itemscontrol](reference/itemscontrol.md) | Base repeating items control. / 基础重复项控件。 |
| **TreeView** | [treeview](reference/treeview.md) | Hierarchical tree with expandable nodes. / 层级树控件。 |
| **TableView** | [table-view](reference/table-view.md) | Column-based data table. / 基于列的数据表格。 |
| **TabControl** | [tabcontrol](reference/tabcontrol.md) | Tabbed content switching. / 选项卡内容切换。 |
| **TabStrip** | [tabstrip](reference/tabstrip.md) | Tab header row (pair with Carousel). / 选项卡标题行。 |
| **TabItem** | [tabitem](reference/tabitem.md) | Single tab within TabControl. / TabControl 中的单独选项卡。 |

### Containers & Layout / 容器和布局

| Control | File | Description |
| --- | --- | --- |
| **Border** | [border](reference/border.md) | Single-child decorator with border/radius/shadow. / 单子元素装饰器。 |
| **Expander** | [expander](reference/expander.md) | Collapsible content with header. / 可折叠内容区域。 |
| **GroupBox** | [groupbox](reference/groupbox.md) | Titled border around grouped controls. / 带标题边框的分组容器。 |
| **ScrollViewer** | [scrollviewer](reference/scrollviewer.md) | Scrollable viewport for overflowing content. / 可滚动视口。 |
| **SplitView** | [splitview](reference/splitview.md) | Master-detail with collapsible pane. / 主从布局，可折叠面板。 |
| **GridSplitter** | [gridsplitter](reference/gridsplitter.md) | Draggable splitter for Grid rows/columns. / Grid 行列拖动分割器。 |
| **HeaderedContentControl** | [headeredcontentcontrol](reference/headeredcontentcontrol.md) | Base class for headered controls. / 带标题控件的基类。 |

### Date & Time / 日期和时间

| Control | File | Description |
| --- | --- | --- |
| **Calendar** | [calendar](reference/calendar.md) | Month-view date grid with selection. / 月份视图日期网格。 |
| **CalendarDatePicker** | [calendar-date-picker](reference/calendar-date-picker.md) | Date picker with calendar dropdown. / 带日历下拉的日期选择。 |
| **DatePicker** | [date-picker](reference/date-picker.md) | Date selection with year/month/day spinners. / 年/月/日选择器。 |
| **TimePicker** | [time-picker](reference/time-picker.md) | Time selection with hour/minute/second. / 时间选择器。 |

### Navigation & Pages / 导航和页面

| Control | File | Description |
| --- | --- | --- |
| **Carousel** | [carousel](reference/carousel.md) | Page switcher with transition animations. / 带过渡动画的页面切换器。 |
| **CarouselPage** | [carouselpage](reference/carouselpage.md) | Carousel page with indicator support. / 带指示器的 Carousel 页面。 |
| **ContentPage** | [contentpage](reference/contentpage.md) | Simple content page for navigation. / 简单导航内容页。 |
| **DrawerPage** | [drawerpage](reference/drawerpage.md) | Page with slide-out drawer panel. / 带滑出抽屉面板的页面。 |
| **NavigationPage** | [navigationpage](reference/navigationpage.md) | Stack-based page navigation. / 基于栈的页面导航。 |
| **TabbedPage** | [tabbedpage](reference/tabbedpage.md) | Bottom-tabbed page container. / 底部选项卡页面容器。 |

### Menus & Flyouts / 菜单和浮出层

| Control | File | Description |
| --- | --- | --- |
| **ContextMenu** | [contextmenu](reference/contextmenu.md) | Right-click context menu. / 右键上下文菜单。 |
| **Menu** | [menu](reference/menu.md) | Horizontal/vertical menu bar. / 水平/垂直菜单栏。 |
| **MenuFlyoutPresenter** | [menuflyoutpresenter](reference/menuflyoutpresenter.md) | Flyout presenter for menu flyouts. / 菜单浮出层的呈现器。 |
| **FlyoutPresenter** | [flyoutpresenter](reference/flyoutpresenter.md) | Base flyout content host. / 浮出层内容宿主。 |
| **Popup** | [popup](reference/popup.md) | Floating popup content. / 浮动弹出内容。 |
| **Tooltip** | [tooltip](reference/tooltip.md) | Hover tooltip popup. / 悬停提示弹出框。 |

### Feedback & Progress / 反馈和进度

| Control | File | Description |
| --- | --- | --- |
| **ProgressBar** | [progress-bar](reference/progress-bar.md) | Linear/ring progress indicator. / 线性/环形进度。 |
| **RefreshContainer** | [refresh-container](reference/refresh-container.md) | Pull-to-refresh container. / 下拉刷新容器。 |
| **PipsPager** | [pips-pager](reference/pips-pager.md) | Page indicator dots. / 页面指示器点。 |
| **NotificationCard** | [notificationcard](reference/notificationcard.md) | In-app notification banner. / 应用内通知横幅。 |
| **DataValidationErrors** | [data-validation-errors](reference/data-validation-errors.md) | Validation error display. / 验证错误显示。 |

### Window & Infrastructure / 窗口和基础设施

| Control | File | Description |
| --- | --- | --- |
| **Window** | [window](reference/window.md) | Top-level application window. / 顶级应用窗口。 |
| **EmbeddableControlRoot** | [embeddable-control-root](reference/embeddable-control-root.md) | Root for embedded Avalonia views. / 嵌入式 Avalonia 视图的根。 |
| **ManagedFileChooser** | [managedfilechooser](reference/managedfilechooser.md) | In-app file picker dialog. / 应用内文件选择对话框。 |
| **ThemeVariantScope** | [themevariantscope](reference/themevariantscope.md) | Local theme variant override. / 局部主题变体覆盖。 |
| **WindowNotificationManager** | [windownotificationmanager](reference/windownotificationmanager.md) | Window-level notification manager. / 窗口级通知管理器。 |
| **CommandBar** | [commandbar](reference/commandbar.md) | App bar with primary/secondary commands. / 主要/次要命令栏。 |
| **TransitioningContentControl** | [transitioningcontentcontrol](reference/transitioningcontentcontrol.md) | Content control with transition animations. / 带过渡动画的内容控件。 |
| **AdornerLayer** | [adorner-layer](reference/adorner-layer.md) | Overlay layer for visual adorners. / 视觉装饰器覆盖层。 |
