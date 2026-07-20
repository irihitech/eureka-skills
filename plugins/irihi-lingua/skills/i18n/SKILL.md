---
name: lingua-setup-guide
description: >
  Guide for integrating and using the Irihi.Lingua i18n library in Avalonia
  projects — from NuGet installation, resource file creation,
  LanguageManager declaration, ViewModel/XAML authoring, to adding new
  translation keys (compile-time + runtime).
  指导用户和 Agent 如何在 Avalonia 项目中集成和使用 Irihi.Lingua 国际化库——
  从零搭建 NuGet 包、创建资源文件、声明 LanguageManager、编写
  ViewModel/XAML，到添加新翻译键值对（编译期+运行时）。
---

# Irihi.Lingua — Avalonia i18n Setup & Usage Guide / 国际化搭建与使用指南

## Overview / 概述

Irihi.Lingua is a Roslyn incremental source generator that converts `.resx` /
`.json` resource files into strongly-typed `IObservable<string?>` properties at
compile time, enabling automatic UI refresh on culture switch with Avalonia UI.
This SKILL covers two parts: (A) setting up from scratch, and (B) adding new
translation keys.

Irihi.Lingua 是一个 Roslyn 增量源生成器，在编译时将 `.resx` / `.json` 资源文件
转换为强类型的 `IObservable<string?>` 属性，配合 Avalonia UI 实现文化切换时自动
刷新 UI。本 SKILL 涵盖两部分：(A) 从零搭建，(B) 添加新翻译键值对。

---

## Part 1: Setting Up Lingua from Scratch / 第一部分：从零搭建 Lingua

### Step 1 — Install the NuGet Package / 步骤 1 — 安装 NuGet 包

Add the following to your target Avalonia project's `.csproj`:

在目标 Avalonia 项目的 `.csproj` 中添加：

```xml
<PackageReference Include="Irihi.Lingua" />
```

Or via CLI / 或通过 CLI：

```bash
dotnet add package Irihi.Lingua
```

> **One PackageReference is enough / 一个 PackageReference 即可**：The package
> bundles both the runtime library (`Irihi.Lingua.Core`) and the source generator
> (`Irihi.Lingua.Generator`). The generator runs automatically during compilation
> — no extra configuration is needed.
> 该包同时包含运行时库（`Irihi.Lingua.Core`）和源生成器
> （`Irihi.Lingua.Generator`），生成器自动随编译运行，无需额外配置。

If your project lives in a source-tree environment (e.g. a demo project), use
ProjectReference instead:

如果项目处于源码环境中（demo 项目），请改用 ProjectReference：

```xml
<!-- Runtime library / 运行时库 -->
<ProjectReference Include="..\..\src\Irihi.Lingua.Core\Irihi.Lingua.Core.csproj" />

<!-- Source generator (key: OutputItemType + ReferenceOutputAssembly) -->
<!-- 源生成器（关键：OutputItemType + ReferenceOutputAssembly） -->
<ProjectReference Include="..\..\src\Irihi.Lingua.Generator\Irihi.Lingua.Generator.csproj"
                  OutputItemType="Analyzer"
                  ReferenceOutputAssembly="false" />
```

---

### Step 2 — Create Resource Files / 步骤 2 — 创建资源文件

Place resource files under a project directory (e.g. `Resources/`).
Naming convention:

资源文件放在项目目录下（如 `Resources/`），命名约定：

- **Default / invariant culture / 默认/不变文化**：`{BaseName}.resx` or `{BaseName}.json`
- **Culture-specific variants / 特定文化变体**：`{BaseName}.{culture}.resx` or `{BaseName}.{culture}.json`

#### RESX Format / RESX 格式

`Resources/Strings.resx` (default culture, usually English / 默认文化，通常是英文)：

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <data name="App_Title" xml:space="preserve">
    <value>My Application</value>
  </data>
  <data name="Greeting_Message" xml:space="preserve">
    <value>Hello!</value>
  </data>
  <data name="Switch_Language" xml:space="preserve">
    <value>Switch Language</value>
  </data>
</root>
```

`Resources/Strings.zh-Hans.resx` (Simplified Chinese / 简体中文)：

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <data name="App_Title" xml:space="preserve">
    <value>我的应用程序</value>
  </data>
  <data name="Greeting_Message" xml:space="preserve">
    <value>你好！</value>
  </data>
  <data name="Switch_Language" xml:space="preserve">
    <value>切换语言</value>
  </data>
</root>
```

#### JSON Format / JSON 格式

`Resources/Strings.json` (default culture / 默认文化)：

```json
{
  "app": {
    "title": "My Application",
    "greeting": "Hello from JSON!"
  }
}
```

`Resources/Strings.zh-Hans.json`：

```json
{
  "app": {
    "title": "我的应用程序",
    "greeting": "来自 JSON 的问候！"
  }
}
```

> **JSON flattening rule / JSON 扁平化规则**：Nested objects are joined with
> underscores, e.g. `app.title` → `app_title`. Only `string` leaf values are
> extracted as keys; arrays, numbers, and booleans are ignored.
> 嵌套对象用下划线连接，如 `app.title` → `app_title`。仅 `string` 类型的叶子值
> 会被提取为键；数组、数字、布尔值会被忽略。

---

### Step 3 — Register AdditionalFiles in .csproj / 步骤 3 — 在 .csproj 中注册 AdditionalFiles

The source generator discovers resource files through `AdditionalFiles` —
**they must be declared explicitly**:

源生成器通过 `AdditionalFiles` 发现资源文件，**必须显式声明**：

```xml
<ItemGroup>
  <!-- List individually / 逐一列出 -->
  <AdditionalFiles Include="Resources\Strings.resx" />
  <AdditionalFiles Include="Resources\Strings.zh-Hans.resx" />

  <!-- Or use a glob to include everything / 或用通配符一次性包含所有 -->
  <AdditionalFiles Include="Resources\**\*.resx" />
  <AdditionalFiles Include="Resources\**\*.json" />
</ItemGroup>
```

---

### Step 4 — Declare the Language Manager / 步骤 4 — 声明语言管理器（LanguageManager）

Create a `partial class` in your project and apply the `[LinguaManager]`
attribute pointing to the base resource file:

在项目中新建一个 `partial class`，添加 `[LinguaManager]` 特性，指向基础资源文件：

```csharp
using Irihi.Lingua;

namespace MyApp;

[LinguaManager("./Resources/Strings.resx")]
public partial class LanguageManager;
```

> - The path is relative to the project root (the `.csproj` directory).
> - Must be a `partial class` — the source generator completes the rest at
>   compile time.
> - A project can have multiple managers (e.g. one for RESX, one for JSON).
>
> - 路径相对于项目根目录（`.csproj` 所在目录）
> - 必须是 `partial class` — 源生成器在编译时补全剩余代码
> - 一个项目可以有多个管理器（如分别管理 RESX 和 JSON）

**JSON manager / JSON 管理器** (optional / 可选)：

```csharp
namespace MyApp;

[LinguaManager("./Resources/Strings.json")]
public partial class JsonLanguageManager;
```

---

### Step 5 — Write the View + ViewModel / 步骤 5 — 编写 View + ViewModel

#### ViewModel

```csharp
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    // Each resource key maps to an IObservable<string?> property
    // 每个资源键对应一个 IObservable<string?> 属性
    public IObservable<string?> AppTitle => LanguageManager.Instance.App_Title;
    public IObservable<string?> GreetingMessage => LanguageManager.Instance.Greeting_Message;
    public IObservable<string?> SwitchLanguageLabel => LanguageManager.Instance.Switch_Language;
}
```

> **For each key the generator creates / 生成器会为每个键创建**：
> ① a `LinguaKey` static field in the `Keys` nested class / `Keys` 嵌套类中的
> `LinguaKey` 静态字段、
> ② an `IObservable<string?>` readonly property / `IObservable<string?>` 只读属性、
> ③ the singleton `Instance` / 单例 `Instance`。

#### XAML (Stream-binding `^` approach / 流绑定 `^` 方式)

```xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:vm="using:MyApp.ViewModels"
        x:DataType="vm:MainViewModel"
        Title="{Binding AppTitle^}">

    <StackPanel Spacing="16" Margin="40">
        <TextBlock Text="{Binding AppTitle^}"
                   FontSize="18" FontWeight="Bold" />
        <TextBlock Text="{Binding GreetingMessage^}"
                   FontSize="14" />
        <Button Content="{Binding SwitchLanguageLabel^}" />
    </StackPanel>
</Window>
```

**The `^` operator / `^` 操作符** binds to `IObservable<T>` stream properties;
Avalonia automatically subscribes and updates the UI when values change.
用于绑定 `IObservable<T>` 流属性，Avalonia 自动订阅并在值变化时更新 UI。

#### XAML (TranslateExtension approach — no ViewModel wrapper needed / TranslateExtension 方式，无需 ViewModel 包装)

```xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:local="using:MyApp">

    <!-- Translate reads directly from the Keys nested class; no ViewModel required -->
    <!-- Translate 直接从 Keys 嵌套类取值，无需 ViewModel -->
    <TextBlock Text="{Translate {x:Static local:LanguageManager+Keys.Greeting_Message}}"
               FontSize="13" FontStyle="Italic" />
</Window>
```

> `TranslateExtension` is auto-registered via
> `[assembly: XmlnsDefinition("https://github.com/avaloniaui", "Irihi.Lingua.Extensions")]`
> — **no extra xmlns declaration is needed**.
> `TranslateExtension` 已通过
> `[assembly: XmlnsDefinition("https://github.com/avaloniaui", "Irihi.Lingua.Extensions")]`
> 自动注册，**无需声明额外 xmlns**。

#### XAML (FormatTranslateExtension — format strings + dynamic parameters / FormatTranslateExtension 方式，格式化字符串 + 动态参数)

```xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:local="using:MyApp">

    <StackPanel Spacing="8">
        <NumericUpDown Width="200" Name="page" Value="1" />

        <TextBlock>
            <TextBlock.Text>
                <FormatTranslate FormatKey="{x:Static local:LanguageManager+Keys.Page_Template}">
                    <!-- {0} = bound value from a control / 来自控件的绑定值 -->
                    <TranslateEntry Binding="{Binding #page.Value}" />
                    <!-- {1} = another localized key (nested translation) / 另一个本地化键（嵌套翻译） -->
                    <TranslateEntry Key="{x:Static local:LanguageManager+Keys.Greeting_Message}" />
                </FormatTranslate>
            </TextBlock.Text>
        </TextBlock>
    </StackPanel>
</Window>
```

Example resource template / 对应的资源模板示例：`"Page {0} {1}"` → Chinese / 中文
`"第{0}页 {1}"`。`TranslateEntry` supports two kinds of parameters /
`TranslateEntry` 支持两种参数：

- `Key="..."` — another `LinguaKey` (itself updates on culture switch) /
  另一个 `LinguaKey`（自身也会随文化切换更新）
- `Binding="..."` — standard Avalonia binding (supports `#controlName.Property`
  etc.) / 标准 Avalonia 绑定（支持 `#controlName.Property` 等）

---

## Part 2: Adding New Translation Keys / 第二部分：添加新的翻译键值对

### RESX

1. Add a `<data>` element to the base file:

   在基础文件中添加 `<data>` 元素：

   ```xml
   <!-- Resources/Strings.resx -->
   <data name="New_Welcome" xml:space="preserve">
     <value>Welcome back!</value>
   </data>
   ```

2. Add the corresponding translation in each culture variant file:

   在每个文化变体文件中添加对应翻译：

   ```xml
   <!-- Resources/Strings.zh-Hans.resx -->
   <data name="New_Welcome" xml:space="preserve">
     <value>欢迎回来！</value>
   </data>
   ```

3. **Rebuild / 重新编译** — the generator automatically extracts the new key
   and generates:
   生成器自动提取新键，生成：
   - `LanguageManager.Keys.New_Welcome` — static `LinguaKey` / 静态 `LinguaKey`
   - `LanguageManager.Instance.New_Welcome` — `IObservable<string?>` property /
     `IObservable<string?>` 属性

4. Expose it in the ViewModel:

   在 ViewModel 中暴露：

   ```csharp
   public IObservable<string?> NewWelcome => LanguageManager.Instance.New_Welcome;
   ```

5. Use it in XAML:

   在 XAML 中使用：

   ```xml
   <TextBlock Text="{Binding NewWelcome^}" />
   <!-- or / 或 -->
   <TextBlock Text="{Translate {x:Static local:LanguageManager+Keys.New_Welcome}}" />
   ```

### JSON

1. Add a new `string` property at any nesting level in the JSON:

   在 JSON 中任意层级添加新 `string` 属性：

   ```json
   // Resources/Strings.json
   { "app": { "footer": "Default Footer" } }
   ```

2. The key is flattened to `app_footer`. / 该键会被扁平化为 `app_footer`。
3. Add the corresponding translation in culture variant files. /
   文化变体文件中添加对应翻译。
4. **Rebuild / 重新编译** — subsequent steps are identical to RESX. /
   后续步骤与 RESX 相同。

---

## Part 3: Switching Culture at Runtime / 第三部分：运行时切换 Culture

### Core API / 核心 API

Every generated LanguageManager implements `ILinguaManager` and exposes the
following culture-related members:

每个生成的 LanguageManager 都实现了 `ILinguaManager`，提供以下与文化切换相关的成员：

| Member / 成员 | Kind / 类型 | Description / 说明 |
|------|------|------|
| `Instance.UpdateCulture(CultureInfo)` | Method / 方法 | Switches the current culture; all `IObservable<string?>` properties automatically push new values. / 切换当前文化，所有 `IObservable<string?>` 属性自动推送新值 |
| `Instance.CurrentCulture` | Property / 属性 | Gets the current culture (initial value is `CultureInfo.InvariantCulture`). / 获取当前文化（初始值为 `CultureInfo.InvariantCulture`） |
| `Instance.CultureChanges` | `IObservable<CultureInfo>` | Culture change stream; emits the current value on subscribe, then on every `UpdateCulture` call. / 文化变更流；订阅后立即收到当前值，之后每次 `UpdateCulture` 时推送 |

**Culture fallback chain / 文化回退链**：
`zh-Hans-CN` → `zh-Hans` → `zh` → `InvariantCulture`. Pass a specific culture
name and the system automatically finds the closest match.
传入精确文化名后，系统自动查找最近的匹配。

---

### Calling UpdateCulture Directly / 直接调用 UpdateCulture

```csharp
// Switch to Simplified Chinese / 切换到简体中文
LanguageManager.Instance.UpdateCulture(new CultureInfo("zh-Hans"));

// Switch to Japanese / 切换到日语
LanguageManager.Instance.UpdateCulture(new CultureInfo("ja-JP"));

// Switch back to default (invariant culture) / 切换回默认（不变文化）
LanguageManager.Instance.UpdateCulture(CultureInfo.InvariantCulture);
```

After `UpdateCulture` is called / `UpdateCulture` 调用后：

- **Stream binding `^` / 流绑定 `^`** — Avalonia automatically receives new
  values and the UI refreshes immediately. /
  Avalonia 自动收到新值，UI 立即刷新。
- **TranslateExtension** — also responds automatically; no extra handling
  required. / 同样自动响应，无需额外处理。
- **Current subscribers / 当前订阅者** — all observers subscribed via
  `.Subscribe()` to observable properties receive the new values. /
  所有通过 `.Subscribe()` 订阅 observable 属性的观察者都会收到新值。

> **Note / 注意**：If your project has multiple LanguageManagers (e.g. one for
> RESX and one for JSON), you must call `UpdateCulture` on **each** of them when
> switching cultures.
> 如果项目中有多个 LanguageManager（如 RESX + JSON 各一个），需要在切换文化时
> 对**每个**管理器都调用 `UpdateCulture`。

---

### Listening to CultureChanges (Non-UI Scenarios / 非 UI 场景)

Subscribe to `CultureChanges` when you need to respond to culture switches in
code (e.g. saving user preferences, logging, etc.):

当需要在代码中响应文化切换（如保存用户偏好、日志记录等）时，订阅 `CultureChanges`：

```csharp
// Subscribe to culture changes / 订阅文化变更
IDisposable sub = LanguageManager.Instance.CultureChanges.Subscribe(culture =>
{
    Console.WriteLine($"Culture switched to: {culture.Name}");

    // You can save the user's language preference here
    // 可以在此保存用户语言偏好
    // Preferences.Set("app_culture", culture.Name);
});

// Unsubscribe (usually in Dispose)
// 取消订阅（通常在 Dispose 中）
// sub.Dispose();
```

`CultureChanges` is a BehaviorSubject-style observable /
`CultureChanges` 是一个 BehaviorSubject 风格的 observable：

- Emits the **current** culture immediately on subscribe. /
  订阅时**立即**收到当前文化。
- Emits on every `UpdateCulture` call thereafter (even if the culture value is
  the same). /
  之后每次 `UpdateCulture` 时推送（即使文化值相同也会推送）。

---

## Appendix: Core Type Reference / 附录：核心类型速查

| Type / 类型 | Namespace / 命名空间 | Description / 说明 |
|------|----------|------|
| `LinguaManagerAttribute` | `Irihi.Lingua` | Marks a `partial class`; constructor accepts a resource file relative path. / 标记 `partial class`；构造函数接受资源文件相对路径 |
| `ILinguaManager` | `Irihi.Lingua` | Interface implemented by generated managers. / 生成的管理器实现的接口 |
| `LinguaKey` | `Irihi.Lingua` | Key + manager reference; `implicit operator string?` allows use as a string. / 键 + 管理器引用；`implicit operator string?` 可当字符串用 |
| `LinguaObservableString` | `Irihi.Lingua` | BehaviorSubject-style `IObservable<string?>` implementation. / BehaviorSubject 风格的 `IObservable<string?>` 实现 |
| `TranslateExtension` | `Irihi.Lingua.Extensions` | XAML markup extension; accepts a `LinguaKey`, returns a Binding. / XAML 标记扩展；接受 `LinguaKey`，返回 Binding |
| `FormatTranslateExtension` | `Irihi.Lingua.Extensions` | XAML markup extension; `FormatKey` + `TranslateEntry` child elements. / XAML 标记扩展；`FormatKey` + `TranslateEntry` 子元素 |
| `TranslateEntry` | `Irihi.Lingua.Extensions` | Format parameter entry; choose `Key` (nested translation) or `Binding` (dynamic bind). / 格式化参数条目；`Key`（嵌套翻译）或 `Binding`（动态绑定）二选一 |

## FAQ / 常见问题

**Q: Compilation error LINGUA001? / 编译后报 LINGUA001？**
A: Check that the path in `[LinguaManager]` is correct (relative to `.csproj`)
and that the file is included in `AdditionalFiles`.
检查 `[LinguaManager]` 中的路径是否正确（相对 `.csproj`），以及文件是否已添加到
`AdditionalFiles`。

**Q: Compilation error LINGUA002 / LINGUA003? / 编译后报 LINGUA002/LINGUA003？**
A: LINGUA002 = a culture is missing a key; LINGUA003 = a culture has an extra
key. Ensure all culture variant files have exactly the same set of keys.
LINGUA002 = 某个文化缺少某个键，LINGUA003 = 某个文化有多余键。确保所有文化变体
文件键名完全一致。

**Q: UI doesn't update after culture switch? / 切换文化后 UI 没有更新？**
A: Make sure ViewModel properties are exposed as `IObservable<string?>` and XAML
bindings use the `^` operator. `TranslateExtension` responds to culture switches
automatically.
确认 ViewModel 属性是通过 `IObservable<string?>` 暴露的，XAML 绑定使用了 `^`
操作符。如果使用 `TranslateExtension`，则自动响应文化切换。

**Q: How are nested JSON keys named? / JSON 的嵌套键如何命名？**
A: Hierarchy levels are joined with underscores:
`settings.display.theme` → `settings_display_theme`.
层级用下划线连接：`settings.display.theme` → `settings_display_theme`。
