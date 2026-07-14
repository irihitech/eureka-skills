---
category: Feedback
title: Loading
subtitle: 加载
description: >
  Displays a loading indicator with optional message overlay. Use Loading for
  inline spinners, LoadingContainer to mask content during async operations.
  显示加载指示器，可选叠加提示信息。Loading 用于内联旋转动画，LoadingContainer 用于异步操作时遮罩内容。
---

# Loading / 加载

## When to Use / 何时使用

Use `Loading` to show an indeterminate progress indicator when the duration of
an operation is unknown. Use `LoadingContainer` to overlay a loading mask on
top of existing content — ideal for page-level or section-level async loads.

当操作耗时不确定时，使用 `Loading` 显示不确定进度指示器。使用
`LoadingContainer` 在现有内容上叠加加载遮罩——适用于页面级或区块级异步加载。

Avoid Loading for deterministic progress (use a `ProgressBar` instead).

避免将 Loading 用于确定性进度（应使用 `ProgressBar`）。

## Basic Usage / 基本使用

```xml
xmlns:u="https://irihi.tech/ursa"

<!-- Inline spinner, always animating -->
<u:LoadingIcon />

<!-- Size variants via style classes -->
<u:LoadingIcon Classes="Small" />
<u:LoadingIcon />                   <!-- default (20×20) -->
<u:LoadingIcon Classes="Large" />
```

`LoadingIcon` animates automatically — `IsLoading` defaults to `true` in the
theme.

`LoadingIcon` 默认自动播放动画，主题中 `IsLoading` 默认为 `true`。

### LoadingContainer — Mask Content / 遮罩内容

```xml
<ToggleSwitch Name="s" Content="Loading" />

<u:LoadingContainer
    IsLoading="{Binding #s.IsChecked}"
    LoadingMessage="Loading...">
    <!-- Your content here / 你的内容 -->
    <Calendar />
</u:LoadingContainer>
```

When `IsLoading` is `true`, the content is blurred and a spinner + message
appear on top. When `false`, content renders normally.

当 `IsLoading` 为 `true` 时，内容会模糊并叠加旋转动画和提示文字；为 `false`
时正常渲染。

## Common Scenarios / 常用场景

### 1. Full-page loading with custom indicator / 整页加载，自定义指示器

```xml
<u:LoadingContainer IsLoading="{Binding IsBusy}">
    <u:LoadingContainer.Indicator>
        <Template>
            <PathIcon Data="{StaticResource YourCustomIcon}" />
        </Template>
    </u:LoadingContainer.Indicator>
    <DataGrid ItemsSource="{Binding Items}" />
</u:LoadingContainer>
```

### 2. Inline spinner next to a button / 按钮旁的行内加载动画

```xml
<StackPanel Orientation="Horizontal">
    <Button Content="Submit" Command="{Binding SubmitCommand}" />
    <u:LoadingIcon IsVisible="{Binding IsSubmitting}" Classes="Small" />
</StackPanel>
```

### 3. Custom loading message template / 自定义加载消息模板

```xml
<u:LoadingContainer IsLoading="{Binding IsBusy}"
                    LoadingMessage="{Binding StatusText}"
                    MessageForeground="White">
    <u:LoadingContainer.LoadingMessageTemplate>
        <DataTemplate>
            <TextBlock Text="{Binding}" FontSize="16" FontWeight="Bold" />
        </DataTemplate>
    </u:LoadingContainer.LoadingMessageTemplate>
    <!-- content -->
</u:LoadingContainer>
```

## Property Reference / 属性参考

### Loading / Loading 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `IsLoading` | `bool` | `false` | Whether the overlay is visible / 是否显示遮罩 |
| `Indicator` | `object?` | (spinner template) | Custom indicator content / 自定义指示器内容 |
| `Background` | `IBrush?` | theme | Mask background brush / 遮罩背景画刷 |
| `Content` | `object?` | `null` | Text/visual shown below the spinner / 旋转动画下方的文字/视觉元素 |

### LoadingContainer / LoadingContainer 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `IsLoading` | `bool` | `false` | Toggles loading overlay and blurs content / 切换加载遮罩并模糊内容 |
| `Indicator` | `object?` | (spinner template) | Custom indicator / 自定义指示器 |
| `LoadingMessage` | `object?` | `null` | Message displayed below the indicator / 指示器下方显示的消息 |
| `LoadingMessageTemplate` | `IDataTemplate` | `null` | Data template for the loading message / 加载消息的数据模板 |
| `MessageForeground` | `IBrush?` | theme | Foreground brush for the message text / 消息文字的前景画刷 |

### LoadingIcon / LoadingIcon 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `IsLoading` | `bool` | `true` | Controls animation playback / 控制动画播放 |
| `Foreground` | `IBrush?` | theme | Color of the arc / 圆弧颜色 |

**Style Classes:** `Small` (14×14, stroke 2), (default 20×20, stroke 3), `Large`
(32×32, stroke 5).

## Events / 事件

No custom events. `Loading` and `LoadingContainer` are `ContentControl`
subclasses and support the standard `PointerPressed`, etc.

没有自定义事件。`Loading` 和 `LoadingContainer` 继承自 `ContentControl`，支持标准
指针事件。

## Styling & Templating / 样式与模板

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `LoadingIconForeground` | `LoadingIcon` | Arc color / 圆弧颜色 |
| `LoadingMaskBackground` | `Loading`, `LoadingContainer` | Overlay background / 遮罩背景 |

### Pseudo-classes / 伪类

| Pseudo-class | Control | Condition |
|---|---|---|
| `:loading` | `LoadingContainer` | Set when `IsLoading` is `true` |

When `:loading` is active, the content presenter gets `Effect="blur(5)"`.

当 `:loading` 激活时，内容呈现器应用 `Effect="blur(5)"` 模糊效果。

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_Arc` | `LoadingIcon` | `Arc` |
| `PART_ContentPresenter` | `Loading`, `LoadingContainer` | `ContentPresenter` |

## FAQ / 常见问题

**Q: How do I stop the spinner animation? / 如何停止旋转动画？**
A: Set `IsLoading="False"`. On `LoadingIcon` the animation is driven by
`[IsLoading=True]` selector. On `LoadingContainer` it passes through to the
inner `Loading` control.

**Q: Can I use LoadingIcon standalone without LoadingContainer?**
A: Yes. `LoadingIcon` is a standalone `ContentControl` that can be placed
anywhere — next to buttons, inside status bars, etc.

**Q: How do I change the spinner color? / 如何改变旋转动画颜色？**
A: Set `Foreground` on `LoadingIcon`, or override `LoadingIconForeground` in
your theme resources.

```xml
<u:LoadingIcon Foreground="{DynamicResource SemiBlue5}" />
```

**Q: Can I use a completely custom loading animation?**
A: Yes, provide your own `Indicator` template:

```xml
<u:Loading IsLoading="True">
    <u:Loading.Indicator>
        <ProgressBar IsIndeterminate="True" Width="100" />
    </u:Loading.Indicator>
</u:Loading>
```
