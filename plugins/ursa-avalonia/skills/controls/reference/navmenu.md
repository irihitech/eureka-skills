---
category: Navigation
title: NavMenu
subtitle: 导航菜单
description: >
  Vertical navigation menu with data-binding support, collapsible items,
  horizontal-collapse mode, and built-in keyboard navigation. Suitable for
  sidebar menus in dashboard-style applications.
  垂直导航菜单，支持数据绑定、可折叠子菜单、水平折叠模式和内置键盘导航。适用于
  仪表盘风格应用的侧边栏菜单。
---

# NavMenu / 导航菜单

## When to Use / 何时使用

Use `NavMenu` for sidebar navigation with hierarchical items. It supports
data-driven item generation via `ItemsSource` + binding properties, or
declarative `NavMenuItem` children in XAML.

使用 `NavMenu` 构建带层级结构的侧边栏导航。支持通过 `ItemsSource` + 绑定属性
进行数据驱动生成，也支持在 XAML 中直接声明 `NavMenuItem`。

Do NOT use NavMenu for horizontal top-bar navigation — use `TabControl` or a
custom `ItemsControl` instead.

不要用 NavMenu 做顶栏水平导航——使用 `TabControl` 或自定义 `ItemsControl`。

## Basic Usage / 基本使用

### Declarative (static items) / 声明式（静态菜单项）

```xml
xmlns:u="https://irihi.tech/ursa"

<u:NavMenu ExpandWidth="240" CollapseWidth="60">
    <u:NavMenuItem Header="Dashboard">
        <u:NavMenuItem.Icon>
            <PathIcon Data="{StaticResource DashboardIcon}" />
        </u:NavMenuItem.Icon>
    </u:NavMenuItem>
    <u:NavMenuItem Header="Settings">
        <u:NavMenuItem.Icon>
            <PathIcon Data="{StaticResource SettingsIcon}" />
        </u:NavMenuItem.Icon>
        <u:NavMenuItem Header="Profile" />
        <u:NavMenuItem Header="Security" />
    </u:NavMenuItem>
</u:NavMenu>
```

### Data-driven (MVVM) / 数据驱动

```xml
<u:NavMenu ItemsSource="{Binding MenuItems}"
           SelectedItem="{Binding SelectedItem, Mode=TwoWay}"
           HeaderBinding="{Binding Header}"
           IconBinding="{Binding IconIndex}"
           SubMenuBinding="{Binding Children}"
           CommandBinding="{Binding NavCommand}"
           ExpandWidth="240">
    <u:NavMenu.IconTemplate>
        <DataTemplate>
            <PathIcon Data="{Binding Converter={StaticResource IconConverter}}" />
        </DataTemplate>
    </u:NavMenu.IconTemplate>
</u:NavMenu>
```

C# view-model:

```csharp
public class MenuItem
{
    public string Header { get; set; }
    public int IconIndex { get; set; }
    public ICommand NavCommand { get; set; }
    public ObservableCollection<MenuItem> Children { get; set; }
}
```

### Horizontal Collapse / 水平折叠

```xml
<ToggleSwitch Name="collapse" OnContent="Collapse" OffContent="Expand" />

<u:NavMenu IsHorizontalCollapsed="{Binding #collapse.IsChecked}"
           ExpandWidth="240"
           CollapseWidth="60"
           Classes="enable_animation">
    <!-- items -->
</u:NavMenu>
```

When collapsed, only icons are shown. Add `Classes="enable_animation"` for a
smooth width transition.

折叠后仅显示图标。添加 `Classes="enable_animation"` 可获得平滑宽度过渡动画。

## Common Scenarios / 常用场景

### 1. Navigation with header and footer / 带页眉和页脚的导航

```xml
<u:NavMenu ItemsSource="{Binding MenuItems}"
           HeaderBinding="{Binding Header}"
           SubMenuBinding="{Binding Children}">
    <u:NavMenu.Header>
        <Image Source="logo.png" Width="32" Height="32" />
    </u:NavMenu.Header>
    <u:NavMenu.Footer>
        <u:NavMenuItem Header="Logout" Command="{Binding LogoutCommand}" />
    </u:NavMenu.Footer>
</u:NavMenu>
```

### 2. Collapsible toggle button in header / 页眉中的折叠切换按钮

```xml
<u:NavMenu.Header>
    <Panel u:NavMenu.CanToggle="True" Background="Transparent">
        <PathIcon Data="{StaticResource MenuIcon}" />
    </Panel>
</u:NavMenu.Header>
```

`u:NavMenu.CanToggle` clicks on this panel flip `IsHorizontalCollapsed`.

### 3. Separator between menu items / 菜单项分隔线

```xml
<u:NavMenuItem IsSeparator="True" />
```

In data-driven mode, set `NavMenuItem.IsSeparator` from your view-model.

## Property Reference / 属性参考

### NavMenu Properties / NavMenu 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `SelectedItem` | `object?` | `null` | Currently selected item (TwoWay) / 当前选中项 |
| `ItemsSource` | `IEnumerable?` | `null` | Data source / 数据源 |
| `HeaderBinding` | `BindingBase?` | `null` | Binding for item header text / 菜单项标题的绑定 |
| `IconBinding` | `BindingBase?` | `null` | Binding for item icon / 菜单项图标的绑定 |
| `SubMenuBinding` | `BindingBase?` | `null` | Binding for child items / 子菜单项的绑定 |
| `CommandBinding` | `BindingBase?` | `null` | Binding for item command / 菜单项命令的绑定 |
| `HeaderTemplate` | `IDataTemplate?` | `null` | Template for menu item headers / 菜单项标题模板 |
| `IconTemplate` | `IDataTemplate?` | `null` | Template for menu item icons / 菜单项图标模板 |
| `Header` | `object?` | `null` | Menu-level header content / 菜单级页眉内容 |
| `Footer` | `object?` | `null` | Menu-level footer content / 菜单级页脚内容 |
| `ExpandWidth` | `double` | `NaN` | Width when expanded / 展开时宽度 |
| `CollapseWidth` | `double` | `NaN` | Width when collapsed / 折叠时宽度 |
| `IsHorizontalCollapsed` | `bool` | `false` | Collapse state (also `CanToggle`) |
| `SubMenuIndent` | `double` | `24` | Indentation per nesting level / 每级缩进 |

### NavMenuItem Properties / NavMenuItem 属性

| Property | Type | Default | Description / 说明 |
|---|---|---|---|
| `Header` | `object?` | `null` | Item display text / 菜单项显示文字 |
| `Icon` | `object?` | `null` | Item icon / 菜单项图标 |
| `IconTemplate` | `IDataTemplate?` | `null` | Icon data template / 图标数据模板 |
| `Command` | `ICommand?` | `null` | Command executed on click / 点击执行的命令 |
| `CommandParameter` | `object?` | `null` | Command parameter / 命令参数 |
| `IsSelected` | `bool` | `false` | Selection state / 选中状态 |
| `IsHighlighted` | `bool` | `false` | (Read only) Keyboard highlight / 键盘高亮 |
| `IsSeparator` | `bool` | `false` | Render as separator line / 渲染为分隔线 |
| `IsHorizontalCollapsed` | `bool` | `false` | Inherited collapse state / 继承的折叠状态 |
| `IsVerticalCollapsed` | `bool` | `false` | Sub-menu expanded/collapsed / 子菜单展开/折叠 |
| `SubMenuIndent` | `double` | (inherited) | Indentation / 缩进 |
| `Level` | `int` | (auto) | Nesting depth (read only) / 嵌套层级（只读） |

### Attached Properties / 附加属性

| Property | Type | Description / 说明 |
|---|---|---|
| `NavMenu.CanToggle` | `bool` | Clicking this element toggles `IsHorizontalCollapsed` / 点击该元素切换折叠状态 |

## Events / 事件

| Event | Args | Description / 说明 |
|---|---|---|
| `SelectionChanged` | `SelectionChangedEventArgs` | Fires when selected item changes / 选中项变化时触发 |
| `SelectionChanging` | `SelectionChangingEventArgs` | Fires before selection changes; set `CanSelect=false` to cancel / 选中变化前触发；设置 `CanSelect=false` 可取消 |

## Styling & Templating / 样式与模板

### Pseudo-classes / 伪类

#### NavMenu

| Pseudo-class | Condition |
|---|---|
| `:horizontal-collapsed` | `IsHorizontalCollapsed` is `true` |

#### NavMenuItem

| Pseudo-class | Condition |
|---|---|
| `:selected` | `IsSelected` is `true` |
| `:highlighted` | Keyboard focus highlight / 键盘焦点高亮 |
| `:horizontal-collapsed` | Inherited collapse state |
| `:vertical-collapsed` | Sub-menu is collapsed |
| `:first-level` | Top-level item (level 0) |
| `:selector` | Item has children (sub-menu indicator visible) |
| `:empty` | Item has no children (hide expander icon) |

### Theme Resources / 主题资源

| Resource Key | Applies To | Description |
|---|---|---|
| `ListBoxItemSelectedForeground` | Selected item | Selected text color |
| `ListBoxItemSelectedBackground` | Selected item | Selected background |
| `ListBoxItemSelectedPointeroverBackground` | Selected+hover | Selected hover background |
| `ListBoxItemPointeroverBackground` | Hovered item | Hover background |
| `ListBoxItemPointeroverForeground` | Hovered item | Hover text color |
| `NavMenuWidthAnimationGenerator` | Animation | Width transition animation |

### Template Parts / 模板部件

| Part Name | Control | Type |
|---|---|---|
| `PART_ItemsPresenter` | `NavMenu` | `ItemsPresenter` |
| `PART_Border` | `NavMenuItem` | `Border` |
| `PART_HeaderPresenter` | `NavMenuItem` | `ContentPresenter` |
| `PART_ExpanderIcon` | `NavMenuItem` | `PathIcon` |
| `PART_Popup` | `NavMenuItem` | `Popup` |
| `PART_OverflowPanel` | `NavMenuItem` | `Panel` |

### Animation Class / 动画类

Add `Classes="enable_animation"` to `NavMenu` to enable smooth width animation
when toggling `IsHorizontalCollapsed`.

为 `NavMenu` 添加 `Classes="enable_animation"` 可在切换折叠时启用平滑宽度动画。

## FAQ / 常见问题

**Q: How do I handle navigation when a menu item is clicked?**
A: Use `CommandBinding` (MVVM) or set `Command` directly on `NavMenuItem`.
The `SelectedItem` two-way binding also reflects the selection.

**Q: How do I get the selected item's data?**
A: Bind `SelectedItem` (TwoWay) on `NavMenu` and read it in your view-model.

**Q: Can I use NavMenu horizontally?**
A: No. NavMenu is designed for vertical layouts. For horizontal navigation use
other controls.

**Q: Why don't my sub-menu bindings work?**
A: Ensure `SubMenuBinding` is set on `NavMenu` (not on items) and the bound
property returns a collection. NavMenuItem auto-generates children from this
binding.

**Q: How do I cancel selection changes? / 如何取消选中变化？**
A: Handle `SelectionChanging` and set `e.CanSelect = false`.
