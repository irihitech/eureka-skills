---
category: Components
title: Anchor
subtitle: 锚点导航
description: 基于滚动位置的自动高亮导航控件，通过监听目标 ScrollViewer 的滚动位置自动追踪并高亮对应的锚点项。
---

## Anchor / 锚点导航

An `ItemsControl`-based navigation component that automatically tracks scroll position in a target `ScrollViewer` and highlights the corresponding `AnchorItem`. Items represent sections in the target scrollable content, identified by the attached `Anchor.Id` property. When the user scrolls or clicks an item, the control smoothly animates to the target.

基于 `ItemsControl` 的导航组件，自动追踪目标 `ScrollViewer` 的滚动位置并高亮对应的 `AnchorItem`。每个项目代表目标可滚动内容中的一个区域，通过附加属性 `Anchor.Id` 关联。用户滚动或点击项目时，控件会平滑动画滚动到目标位置。

## When to Use / 何时使用

Use `Anchor` when you need a table-of-contents style sidebar that stays in sync with scroll position — for example, documentation pages, long-form article navigation, or settings pages with sections. It works best when paired with a `ScrollViewer` containing elements tagged with `Anchor.Id`.

当需要随滚动位置同步的目录式侧边栏时使用 `Anchor` —— 例如文档页面、长文章导航或带分区的设置页面。最佳实践是搭配包含 `Anchor.Id` 标记元素的 `ScrollViewer` 使用。

## Basic Usage / 基本使用

```xml
<!-- Scrollable content with anchor IDs -->
<ScrollViewer Name="contentScroller">
    <StackPanel>
        <Border u:Anchor.Id="section1" Height="300" Background="Red">
            <TextBlock Text="Section 1" />
        </Border>
        <Border u:Anchor.Id="section2" Height="300" Background="Green">
            <TextBlock Text="Section 2" />
        </Border>
        <Border u:Anchor.Id="section3" Height="300" Background="Blue">
            <TextBlock Text="Section 3" />
        </Border>
    </StackPanel>
</ScrollViewer>

<!-- Anchor navigation sidebar -->
<u:Anchor TargetContainer="{Binding #contentScroller}">
    <u:AnchorItem AnchorId="section1" Header="Section 1" />
    <u:AnchorItem AnchorId="section2" Header="Section 2" />
    <u:AnchorItem AnchorId="section3" Header="Section 3" />
</u:Anchor>
```

## Common Scenarios / 常用场景

### Hierarchical Navigation / 层级导航

`AnchorItem` supports nesting for multi-level navigation. Indentation is automatic:

```xml
<u:Anchor TargetContainer="{Binding #scroller}">
    <u:AnchorItem AnchorId="overview" Header="Overview" />
    <u:AnchorItem AnchorId="chapter1" Header="Chapter 1">
        <u:AnchorItem AnchorId="chapter1-1" Header="1.1 Getting Started" />
        <u:AnchorItem AnchorId="chapter1-2" Header="1.2 Configuration" />
    </u:AnchorItem>
    <u:AnchorItem AnchorId="chapter2" Header="Chapter 2" />
</u:Anchor>
```

### Top Offset / 顶部偏移

Add an offset so the scrolled-to position accounts for a fixed header:

```xml
<u:Anchor
    TargetContainer="{Binding #scroller}"
    TopOffset="60">
    <!-- Items -->
</u:Anchor>
```

### XAML Inline with Attached IDs on Target / 目标元素上内联 ID

Apply `u:Anchor.Id` directly on elements within the scrolled content:

```xml
<ScrollViewer Name="scroller">
    <StackPanel>
        <Border u:Anchor.Id="intro" Height="400" />
        <Border u:Anchor.Id="features" Height="400" />
        <TextBlock u:Anchor.Id="pricing" Text="Pricing" />
    </StackPanel>
</ScrollViewer>
```

### Style Variants / 样式变体

Apply class-based styling for different visual treatments:

```xml
<u:Anchor Classes="Muted" TargetContainer="{Binding #scroller}">
    <!-- Muted: hides the vertical pipe line -->
</u:Anchor>

<u:AnchorItem Classes="Primary" AnchorId="hero" Header="Hero" />
<u:AnchorItem Classes="Tertiary" AnchorId="footer" Header="Footer" />
```

## Property Reference / 属性参考

### Anchor Properties / Anchor 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `TargetContainer` | `ScrollViewer?` | The ScrollViewer to track for scroll position. / 要追踪滚动位置的 ScrollViewer。 |
| `TopOffset` | `double` | Vertical offset applied when scrolling to an anchor target. / 滚动到锚点目标时的垂直偏移量。 |

### Anchor Attached Properties / Anchor 附加属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `Anchor.Id` | `string?` | Attached to any `Visual` in the target container to identify it as an anchor target. / 附加到目标容器中的任意 `Visual`，将其标记为锚点目标。 |

### AnchorItem Properties / AnchorItem 属性

| Property / 属性 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `AnchorId` | `string?` | Identifier matching an `Anchor.Id` value in the target container. / 与目标容器中 `Anchor.Id` 值匹配的标识符。 |
| `IsSelected` | `bool` | Whether this item is currently selected (auto-set by scroll position or click). / 此项当前是否被选中（由滚动位置或点击自动设置）。 |
| `Level` | `int` | Read-only nesting level, calculated from logical tree distance to the parent `Anchor`. / 只读嵌套级别，根据与父级 `Anchor` 的逻辑树距离计算。 |
| `Header` | `object?` | Header content (inherited from `HeaderedItemsControl`). / 标题内容（继承自 `HeaderedItemsControl`）。 |
| `HeaderTemplate` | `IDataTemplate?` | Template for the header. / 标题模板。 |

## Styling & Templating / 样式与模板

### Anchor Template Parts / Anchor 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Pipe` | `Rectangle` | Vertical indicator line on the left. / 左侧垂直指示线。 |
| `PART_ItemsPresenter` | `ItemsPresenter` | Items host. / 项目容器。 |

### AnchorItem Template Parts / AnchorItem 模板部件

| Part / 部件 | Type / 类型 | Description / 说明 |
| --- | --- | --- |
| `PART_Pipe` | `Border` | Per-item pipe indicator. / 每个项目的管道指示器。 |
| `PART_HeaderPresenter` | `ContentPresenter` | Header content host. / 标题内容宿主。 |

### Pseudo-classes / 伪类

| Pseudo-class / 伪类 | Description / 说明 |
| --- | --- |
| `:selected` | Applied to `AnchorItem` when active. / 激活时应用于 `AnchorItem`。 |

### Class-based Variants / 基于类的变体

| Class / 类 | Target / 目标 | Effect / 效果 |
| --- | --- | --- |
| `Muted` | `Anchor` | Hides the root pipe background. / 隐藏根管道背景。 |
| `Primary` | `AnchorItem` | Uses primary color for selected pipe. / 选中管道使用主色。 |
| `Tertiary` | `AnchorItem` | Uses tertiary color for selected pipe. / 选中管道使用第三色。 |
| `Muted` | `AnchorItem` | Transparent selected pipe (no indicator). / 透明选中管道（无指示器）。 |
| `Small` | `AnchorItem` | Smaller header height and font size. / 较小的标题高度和字体大小。 |

### DynamicResource Keys / 动态资源键

| Resource Key / 资源键 | Purpose / 用途 |
| --- | --- |
| `AnchorPipeWidth` | Width of the pipe indicator. / 管道指示器宽度。 |
| `AnchorPipeCornerRadius` | Corner radius of the pipe. / 管道圆角。 |
| `AnchorPipeBackground` | Default pipe fill. / 默认管道填充。 |
| `AnchorPipeSelectedBackground` | Pipe fill when selected. / 选中时的管道填充。 |
| `AnchorPipeSelectedPrimaryBackground` | Primary variant selected pipe fill. / Primary 变体的选中管道填充。 |
| `AnchorPipeSelectedTertiaryBackground` | Tertiary variant selected pipe fill. / Tertiary 变体的选中管道填充。 |
| `AnchorForeground` | Default header foreground. / 默认标题前景色。 |
| `AnchorSelectedForeground` | Header foreground when selected. / 选中时的标题前景色。 |
| `AnchorDefaultHeight` | Default header min height. / 默认标题最小高度。 |
| `AnchorSmallHeight` | Small variant header min height. / Small 变体标题最小高度。 |
| `AnchorSmallFontSize` | Small variant header font size. / Small 变体标题字体大小。 |
| `AnchorIndent` | Per-level indentation amount. / 每级缩进量。 |

## FAQ / 常见问题

**Q: How do I make the Anchor track scrolling automatically? / 如何让 Anchor 自动追踪滚动？**

A: Once `TargetContainer` is bound and both the `Anchor` and `ScrollViewer` are loaded, the control automatically subscribes to `ScrollChangedEvent` and updates the selected item based on scroll position. Call `InvalidatePositions()` if the target content changes dynamically. / 一旦 `TargetContainer` 已绑定且 `Anchor` 和 `ScrollViewer` 均已加载，控件会自动订阅 `ScrollChangedEvent` 并根据滚动位置更新选中项。如果目标内容动态变化，请调用 `InvalidatePositions()`。

**Q: Can I use Anchor without a ScrollViewer? / 可以不使用 ScrollViewer 吗？**

A: No, `Anchor` requires a `ScrollViewer` as its `TargetContainer`. The control reads scroll offset and uses `Anchor.Id` attached properties on visual descendants of the `ScrollViewer` to determine positions. / 不可以，`Anchor` 需要一个 `ScrollViewer` 作为其 `TargetContainer`。控件读取滚动偏移量，并使用 `ScrollViewer` 视觉后代上的 `Anchor.Id` 附加属性来确定位置。

**Q: How does nested AnchorItem indentation work? / 嵌套 AnchorItem 的缩进如何工作？**

A: Indentation is automatic. The `Level` property is calculated based on the logical tree distance from the `Anchor` parent, and the AXAML theme uses `TreeLevelToPaddingConverter` with the `AnchorIndent` resource to compute padding. / 缩进是自动的。`Level` 属性根据与 `Anchor` 父级的逻辑树距离计算，AXAML 主题使用 `TreeLevelToPaddingConverter` 和 `AnchorIndent` 资源计算内边距。
