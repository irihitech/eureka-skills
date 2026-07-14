---
category: Components
title: Timeline
subtitle: 时间线
description: 时间线组件以垂直时间轴形式展示事件序列，支持左对齐、右对齐、居中交错和自定义图标。
---

# Timeline / 时间线

A vertical timeline control for displaying sequences of events with configurable display modes, custom icons, time formatting, and positioning. Inherits from `ItemsControl` with a custom `TimelinePanel`.

以垂直时间轴形式展示事件序列的控件。支持多种显示模式、自定义图标、时间格式和位置布局。继承自 `ItemsControl`，使用自定义 `TimelinePanel`。

## When to Use / 何时使用

Use `Timeline` for event logs, order histories, project milestones, or any sequential data with time metadata. For simple vertical lists without connecting lines, use `ListBox`.

用于事件日志、订单历史、项目里程碑或任何带时间元数据的序列数据。不需要连接线的简单垂直列表使用 `ListBox`。

## Basic Usage / 基本使用

```xml
<u:Timeline Mode="Left"
    ItemsSource="{Binding Items}"
    HeaderMemberBinding="{Binding Header}"
    ContentMemberBinding="{Binding Description}"
    TimeMemberBinding="{Binding Time}" />
```

```csharp
public class TimelineEntry
{
    public string Header { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Time { get; set; }
}
```

## Common Scenarios / 常用场景

### Display Modes / 显示模式

```xml
<!-- Left-aligned (content right of axis) -->
<u:Timeline Mode="Left" ItemsSource="{Binding Items}" ... />

<!-- Right-aligned (content left of axis) -->
<u:Timeline Mode="Right" ItemsSource="{Binding Items}" ... />

<!-- Center (time left, content right, axis middle) -->
<u:Timeline Mode="Center" ItemsSource="{Binding Items}" ... />

<!-- Alternate (items alternate left/right) -->
<u:Timeline Mode="Alternate" ItemsSource="{Binding Items}" ... />
```

### Manual Items (No Data Binding) / 手动声明项目

```xml
<u:Timeline Mode="Alternate">
    <u:TimelineItem Content="Step 1" Header="第一步" Type="Default" />
    <u:TimelineItem Content="Step 2" Header="第二步" Type="Success" />
    <u:TimelineItem Content="Step 3" Header="第三步" Type="Warning" />
    <u:TimelineItem Content="Step 4" Header="第四步" Type="Ongoing" />
    <u:TimelineItem Content="Step 5" Header="第五步" Type="Error"
        TimeFormat="yyyy-MM-dd" />
</u:Timeline>
```

### Custom Icon Template with Type-based Selection / 基于类型的图标选择

```xml
<u:Timeline
    ItemsSource="{Binding Items}"
    IconMemberBinding="{Binding ItemType}"
    IconTemplate="{StaticResource IconSelector}" ... />
```

Icon template selector maps `TimelineItemType` (`Default`, `Ongoing`, `Success`, `Warning`, `Error`) to different colored icons.

图标模板选择器将 `TimelineItemType` 映射到不同颜色的图标。

### Custom Time Format / 自定义时间格式

```xml
<u:Timeline TimeFormat="yyyy-MM-dd" ItemsSource="{Binding Items}" ... />
```

## Property Reference / 属性参考

### Timeline Properties / Timeline 属性

| Property / 属性 | Type / 类型 | Default / 默认值 | Description / 说明 |
| --- | --- | --- | --- |
| `Mode` | `TimelineDisplayMode` | `Left` | Layout mode: `Left`, `Center`, `Right`, `Alternate`. / 布局模式。 |
| `TimeFormat` | `string?` | `"yyyy-MM-dd HH:mm:ss"` | Format string applied to `DateTime` values via `TimelineFormatConverter`. / 应用于日期时间的格式化字符串。 |
| `IconMemberBinding` | `BindingBase?` | `null` | Binding for the `Icon` property on each `TimelineItem`. / 每个 `TimelineItem` 的 `Icon` 绑定。 |
| `HeaderMemberBinding` | `BindingBase?` | `null` | Binding for the `Header` property on each `TimelineItem`. / 每个 `TimelineItem` 的 `Header` 绑定。 |
| `ContentMemberBinding` | `BindingBase?` | `null` | Binding for the `Content` property on each `TimelineItem`. / 每个 `TimelineItem` 的 `Content` 绑定。 |
| `TimeMemberBinding` | `BindingBase?` | `null` | Binding for the `Time` property on each `TimelineItem`. / 每个 `TimelineItem` 的 `Time` 绑定。 |
| `IconTemplate` | `IDataTemplate?` | `null` | Data template for rendering the icon of each item. / 每个项图标的渲染模板。 |
| `DescriptionTemplate` | `IDataTemplate?` | `null` | Data template for the content area (aliased as `ContentTemplate` on `TimelineItem`). / 内容区域的数据模板。 |

### TimelineItem Properties / TimelineItem 属性

| Property / 属性 | Type / 类型 | Default / 默认值 | Description / 说明 |
| --- | --- | --- | --- |
| `Icon` | `object?` | `null` | Custom icon content. When null, a default colored dot appears. / 自定义图标内容。为空时显示默认圆点。 |
| `IconTemplate` | `IDataTemplate?` | `null` | Template for the icon. / 图标的渲染模板。 |
| `Type` | `TimelineItemType` | `Default` | Dot color preset: `Default`, `Ongoing`, `Success`, `Warning`, `Error`. / 圆点颜色预设。 |
| `Position` | `TimelineItemPosition` | `Right` | Override for item position: `Left`, `Right`, `Separate`. / 单项位置覆盖。 |
| `Time` | `DateTime` | — | Timestamp for this item. / 该项的时间戳。 |
| `TimeFormat` | `string?` | `null` | Per-item time format override. / 单项时间格式覆盖。 |
| `Header` | `object?` | `null` | Header content (inherited from `HeaderedContentControl`). / 标题内容。 |
| `Content` | `object?` | `null` | Description content (inherited from `ContentControl`). / 描述内容。 |
| `LeftWidth` | `double` | — | Calculated left column width (read-only). / 计算得出的左列宽度。 |
| `IconWidth` | `double` | — | Calculated icon column width (read-only). / 计算得出的图标列宽度。 |
| `RightWidth` | `double` | — | Calculated right column width (read-only). / 计算得出的右列宽度。 |

### Enums / 枚举

| Enum | Values / 值 | Description / 说明 |
| --- | --- | --- |
| `TimelineDisplayMode` | `Left`, `Center`, `Right`, `Alternate` | Controls overall layout. / 控制整体布局。 |
| `TimelineItemPosition` | `Left`, `Right`, `Separate` | Per-item position override. / 单项位置覆盖。 |
| `TimelineItemType` | `Default`, `Ongoing`, `Success`, `Warning`, `Error` | Preset dot color. / 圆点颜色预设。 |

### Pseudo-classes / 伪类

| Class / 类名 | Description / 说明 |
| --- | --- |
| `:first` | First item in the timeline. / 第一项。 |
| `:last` | Last item in the timeline. Last item's axis line is transparent. / 最后一项，其轴线为透明。 |
| `:empty-icon` | No custom icon set; shows the default dot. / 未设置图标时显示默认圆点。 |
| `:all-left` | Item position is `Left`. / 项位置为 `Left`。 |
| `:all-right` | Item position is `Right`. / 项位置为 `Right`。 |
| `:separate` | Item position is `Separate`. / 项位置为 `Separate`。 |

### Template Parts / 模板部件

| Part | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Header` | `ContentPresenter` | Header area. / 标题区域。 |
| `PART_Icon` | `Panel` | Icon area with dot or custom content. / 图标区域。 |
| `PART_Content` | `ContentPresenter` | Content/description area. / 内容/描述区域。 |
| `PART_Time` | `TextBlock` | Time display area. / 时间显示区域。 |
| `PART_RootGrid` | `Grid` | Root 3-column layout grid. / 根三列布局网格。 |
| `PART_DefaultIcon` | `Ellipse` | Default dot shown when no icon is set. / 无自定义图标时的默认圆点。 |

## Styling & Templating / 样式与模板

### Layout

The `TimelinePanel` arranges items vertically with a connecting line drawn through the icon column. Column widths are auto-calculated from actual content sizes via `TimelineItem.GetWidth()`.

`TimelinePanel` 垂直排列项目，轴线穿过图标列绘制。列宽根据实际内容大小自动计算。

### DynamicResource Keys / 动态资源键

| Key | Description / 说明 |
| --- | --- |
| `TimelineLineBrush` | Color of the vertical axis line. / 垂直轴线颜色。 |
| `TimelineHeaderForeground` | Header text color. / 标题文字颜色。 |
| `TimelineDefaultDotFill` | Fill for `Default` type dot. / 默认类型圆点填充。 |
| `TimelineOngoingDotFill` | Fill for `Ongoing` type dot. / 进行中类型圆点填充。 |
| `TimelineSuccessDotFill` | Fill for `Success` type dot. / 成功类型圆点填充。 |
| `TimelineWarningDotFill` | Fill for `Warning` type dot. / 警告类型圆点填充。 |
| `TimelineErrorDotFill` | Fill for `Error` type dot. / 错误类型圆点填充。 |

## FAQ / 常见问题

**Q: How do I set different icons per item type? / 如何为不同类型设置不同图标？**

A: Use `IconMemberBinding` to bind to a property on your data item, then provide an `IconTemplate` that uses a `TemplateSelector` based on `TimelineItemType`. / 使用 `IconMemberBinding` 绑定数据项属性，然后通过 `IconTemplate` 配合基于 `TimelineItemType` 的 `TemplateSelector` 实现。

**Q: Can I have an item without a time label? / 可以不显示时间标签吗？**

A: Yes. The time `TextBlock` is always rendered, but if `Time` is not set and `TimeMemberBinding` is null, it will be empty. / 可以。时间栏始终渲染，但如果未设置 `Time` 和 `TimeMemberBinding`，它将为空。

**Q: What happens for items at start/end of the timeline? / 时间线第一项和最后一项有何特殊处理？**

A: The first item has the `:first` pseudo-class. The last item has `:last`, which makes the axis line transparent below it. / 第一项带有 `:first` 伪类。最后一项带有 `:last` 伪类，其下方的轴线变为透明。
