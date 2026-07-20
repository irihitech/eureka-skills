---
name: lingua-setup-guide
description: 指导用户和 Agent 如何在 Avalonia 项目中集成和使用 Irihi.Lingua 国际化库——从零搭建 NuGet 包、创建资源文件、声明 LanguageManager、编写 ViewModel/XAML，到添加新翻译键值对（编译期+运行时）
---

# Irihi.Lingua — Avalonia 国际化搭建与使用指南

## 概述

Irihi.Lingua 是一个 Roslyn 增量源生成器，在编译时将 `.resx` / `.json` 资源文件转换为强类型的 `IObservable<string?>` 属性，配合 Avalonia UI 实现文化切换时自动刷新 UI。本 SKILL 涵盖两部分：(A) 从零搭建，(B) 添加新翻译键值对。

---

## 第一部分：从零搭建 Lingua

### 步骤 1 — 安装 NuGet 包

在目标 Avalonia 项目的 `.csproj` 中添加：

```xml
<PackageReference Include="Irihi.Lingua" />
```

或通过 CLI：

```bash
dotnet add package Irihi.Lingua
```

> **一个 PackageReference 即可**：该包同时包含运行时库（`Irihi.Lingua.Core`）和源生成器（`Irihi.Lingua.Generator`），生成器自动随编译运行，无需额外配置。

如果项目处于源码环境中（demo 项目），请改用 ProjectReference：

```xml
<!-- 运行时库 -->
<ProjectReference Include="..\..\src\Irihi.Lingua.Core\Irihi.Lingua.Core.csproj" />

<!-- 源生成器（关键：OutputItemType + ReferenceOutputAssembly） -->
<ProjectReference Include="..\..\src\Irihi.Lingua.Generator\Irihi.Lingua.Generator.csproj"
                  OutputItemType="Analyzer"
                  ReferenceOutputAssembly="false" />
```

---

### 步骤 2 — 创建资源文件

资源文件放在项目目录下（如 `Resources/`），命名约定：

- **默认/不变文化**：`{BaseName}.resx` 或 `{BaseName}.json`
- **特定文化变体**：`{BaseName}.{culture}.resx` 或 `{BaseName}.{culture}.json`

#### RESX 格式

`Resources/Strings.resx`（默认文化，通常是英文）：

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

`Resources/Strings.zh-Hans.resx`（简体中文）：

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

#### JSON 格式

`Resources/Strings.json`（默认文化）：

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

> **JSON 扁平化规则**：嵌套对象用下划线连接，如 `app.title` → `app_title`。仅 `string` 类型的叶子值会被提取为键；数组、数字、布尔值会被忽略。

---

### 步骤 3 — 在 .csproj 中注册 AdditionalFiles

源生成器通过 `AdditionalFiles` 发现资源文件，**必须显式声明**：

```xml
<ItemGroup>
  <!-- 逐一列出 -->
  <AdditionalFiles Include="Resources\Strings.resx" />
  <AdditionalFiles Include="Resources\Strings.zh-Hans.resx" />

  <!-- 或用通配符一次性包含所有 -->
  <AdditionalFiles Include="Resources\**\*.resx" />
  <AdditionalFiles Include="Resources\**\*.json" />
</ItemGroup>
```

---

### 步骤 4 — 声明语言管理器（LanguageManager）

在项目中新建一个 `partial class`，添加 `[LinguaManager]` 特性，指向基础资源文件：

```csharp
using Irihi.Lingua;

namespace MyApp;

[LinguaManager("./Resources/Strings.resx")]
public partial class LanguageManager;
```

> - 路径相对于项目根目录（`.csproj` 所在目录）
> - 必须是 `partial class` — 源生成器在编译时补全剩余代码
> - 一个项目可以有多个管理器（如分别管理 RESX 和 JSON）

**JSON 管理器**（可选）：

```csharp
namespace MyApp;

[LinguaManager("./Resources/Strings.json")]
public partial class JsonLanguageManager;
```

---

### 步骤 5 — 编写 View + ViewModel

#### ViewModel

```csharp
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    // 每个资源键对应一个 IObservable<string?> 属性
    public IObservable<string?> AppTitle => LanguageManager.Instance.App_Title;
    public IObservable<string?> GreetingMessage => LanguageManager.Instance.Greeting_Message;
    public IObservable<string?> SwitchLanguageLabel => LanguageManager.Instance.Switch_Language;
}
```

> **生成器会为每个键创建**：① `Keys` 嵌套类中的 `LinguaKey` 静态字段、② `IObservable<string?>` 只读属性、③ 单例 `Instance`。

#### XAML（流绑定 `^` 方式）

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

**`^` 操作符** 用于绑定 `IObservable<T>` 流属性，Avalonia 自动订阅并在值变化时更新 UI。

#### XAML（TranslateExtension 方式，无需 ViewModel 包装）

```xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:local="using:MyApp">

    <!-- Translate 直接从 Keys 嵌套类取值，无需 ViewModel -->
    <TextBlock Text="{Translate {x:Static local:LanguageManager+Keys.Greeting_Message}}"
               FontSize="13" FontStyle="Italic" />
</Window>
```

> `TranslateExtension` 已通过 `[assembly: XmlnsDefinition("https://github.com/avaloniaui", "Irihi.Lingua.Extensions")]` 自动注册，**无需声明额外 xmlns**。

#### XAML（FormatTranslateExtension 方式，格式化字符串 + 动态参数）

```xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:local="using:MyApp">

    <StackPanel Spacing="8">
        <NumericUpDown Width="200" Name="page" Value="1" />

        <TextBlock>
            <TextBlock.Text>
                <FormatTranslate FormatKey="{x:Static local:LanguageManager+Keys.Page_Template}">
                    <!-- {0} = 来自控件的绑定值 -->
                    <TranslateEntry Binding="{Binding #page.Value}" />
                    <!-- {1} = 另一个本地化键（嵌套翻译） -->
                    <TranslateEntry Key="{x:Static local:LanguageManager+Keys.Greeting_Message}" />
                </FormatTranslate>
            </TextBlock.Text>
        </TextBlock>
    </StackPanel>
</Window>
```

对应的资源模板示例：`"Page {0} {1}"` → 中文 `"第{0}页 {1}"`。`TranslateEntry` 支持两种参数：

- `Key="..."` — 另一个 `LinguaKey`（自身也会随文化切换更新）
- `Binding="..."` — 标准 Avalonia 绑定（支持 `#controlName.Property` 等）

---

## 第二部分：添加新的翻译键值对

### RESX

1. 在基础文件中添加 `<data>` 元素：

   ```xml
   <!-- Resources/Strings.resx -->
   <data name="New_Welcome" xml:space="preserve">
     <value>Welcome back!</value>
   </data>
   ```

2. 在每个文化变体文件中添加对应翻译：

   ```xml
   <!-- Resources/Strings.zh-Hans.resx -->
   <data name="New_Welcome" xml:space="preserve">
     <value>欢迎回来！</value>
   </data>
   ```

3. **重新编译** — 生成器自动提取新键，生成：
   - `LanguageManager.Keys.New_Welcome` — 静态 `LinguaKey`
   - `LanguageManager.Instance.New_Welcome` — `IObservable<string?>` 属性

4. 在 ViewModel 中暴露：

   ```csharp
   public IObservable<string?> NewWelcome => LanguageManager.Instance.New_Welcome;
   ```

5. 在 XAML 中使用：

   ```xml
   <TextBlock Text="{Binding NewWelcome^}" />
   <!-- 或 -->
   <TextBlock Text="{Translate {x:Static local:LanguageManager+Keys.New_Welcome}}" />
   ```

### JSON

1. 在 JSON 中任意层级添加新 `string` 属性：

   ```json
   // Resources/Strings.json
   { "app": { "footer": "Default Footer" } }
   ```

2. 该键会被扁平化为 `app_footer`。
3. 文化变体文件中添加对应翻译。
4. **重新编译** — 后续步骤与 RESX 相同。

---

## 第三部分：运行时切换 Culture

### 核心 API

每个生成的 LanguageManager 都实现了 `ILinguaManager`，提供以下与文化切换相关的成员：

| 成员 | 类型 | 说明 |
|------|------|------|
| `Instance.UpdateCulture(CultureInfo)` | 方法 | 切换当前文化，所有 `IObservable<string?>` 属性自动推送新值 |
| `Instance.CurrentCulture` | 属性 | 获取当前文化（初始值为 `CultureInfo.InvariantCulture`） |
| `Instance.CultureChanges` | `IObservable<CultureInfo>` | 文化变更流；订阅后立即收到当前值，之后每次 `UpdateCulture` 时推送 |

**文化回退链**：`zh-Hans-CN` → `zh-Hans` → `zh` → `InvariantCulture`。传入精确文化名后，系统自动查找最近的匹配。

---

### 直接调用 UpdateCulture

```csharp
// 切换到简体中文
LanguageManager.Instance.UpdateCulture(new CultureInfo("zh-Hans"));

// 切换到日语
LanguageManager.Instance.UpdateCulture(new CultureInfo("ja-JP"));

// 切换回默认（不变文化）
LanguageManager.Instance.UpdateCulture(CultureInfo.InvariantCulture);
```

`UpdateCulture` 调用后：

- **流绑定 `^`** — Avalonia 自动收到新值，UI 立即刷新
- **TranslateExtension** — 同样自动响应，无需额外处理
- **当前订阅者** — 所有通过 `.Subscribe()` 订阅 observable 属性的观察者都会收到新值

> **注意**：如果项目中有多个 LanguageManager（如 RESX + JSON 各一个），需要在切换文化时对**每个**管理器都调用 `UpdateCulture`。


---

### 监听 CultureChanges（非 UI 场景）

当需要在代码中响应文化切换（如保存用户偏好、日志记录等）时，订阅 `CultureChanges`：

```csharp
// 订阅文化变更
IDisposable sub = LanguageManager.Instance.CultureChanges.Subscribe(culture =>
{
    Console.WriteLine($"Culture switched to: {culture.Name}");

    // 可以在此保存用户语言偏好
    // Preferences.Set("app_culture", culture.Name);
});

// 取消订阅（通常在 Dispose 中）
// sub.Dispose();
```

`CultureChanges` 是一个 BehaviorSubject 风格的 observable：

- 订阅时**立即**收到当前文化
- 之后每次 `UpdateCulture` 时推送（即使文化值相同也会推送）

---

## 附录：核心类型速查

| 类型 | 命名空间 | 说明 |
|------|----------|------|
| `LinguaManagerAttribute` | `Irihi.Lingua` | 标记 `partial class`；构造函数接受资源文件相对路径 |
| `ILinguaManager` | `Irihi.Lingua` | 生成的管理器实现的接口 |
| `LinguaKey` | `Irihi.Lingua` | 键 + 管理器引用；`implicit operator string?` 可当字符串用 |
| `LinguaObservableString` | `Irihi.Lingua` | BehaviorSubject 风格的 `IObservable<string?>` 实现 |
| `TranslateExtension` | `Irihi.Lingua.Extensions` | XAML 标记扩展；接受 `LinguaKey`，返回 Binding |
| `FormatTranslateExtension` | `Irihi.Lingua.Extensions` | XAML 标记扩展；`FormatKey` + `TranslateEntry` 子元素 |
| `TranslateEntry` | `Irihi.Lingua.Extensions` | 格式化参数条目；`Key`（嵌套翻译）或 `Binding`（动态绑定）二选一 |

## 常见问题

**Q: 编译后报 LINGUA001？**
A: 检查 `[LinguaManager]` 中的路径是否正确（相对 `.csproj`），以及文件是否已添加到 `AdditionalFiles`。

**Q: 编译后报 LINGUA002/LINGUA003？**
A: LINGUA002 = 某个文化缺少某个键，LINGUA003 = 某个文化有多余键。确保所有文化变体文件键名完全一致。

**Q: 切换文化后 UI 没有更新？**
A: 确认 ViewModel 属性是通过 `IObservable<string?>` 暴露的，XAML 绑定使用了 `^` 操作符。如果使用 `TranslateExtension`，则自动响应文化切换。

**Q: JSON 的嵌套键如何命名？**
A: 层级用下划线连接：`settings.display.theme` → `settings_display_theme`。
