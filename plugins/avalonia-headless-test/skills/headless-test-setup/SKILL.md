---
name: headless-test-setup
description: >
  Set up a headless UI test project (xUnit + Avalonia.Headless) for an Avalonia
  control library, modeled on the Ursa.Avalonia `tests/HeadlessTest.Ursa`
  project. Use when a user wants to add, scaffold, or fix headless tests for
  Avalonia controls (template parts, input simulation, property behavior, and
  optionally rendered-pixel tests through Skia). The skill asks whether the
  project needs rendering support and which default theme (Fluent or Semi)
  the test application should load.
  为 Avalonia 控件库搭建 Headless UI 测试项目（xUnit + Avalonia.Headless），
  参考 Ursa.Avalonia 的 tests 目录。会先询问用户是否需要渲染支持（Skia 截帧）
  以及默认主题（Fluent 或 Semi）。
license: MIT
---

# Avalonia Headless Test Setup / Avalonia Headless 测试搭建

Use this skill when a user wants to create a headless test project for an
Avalonia control library, or to fix an existing one. The layout and code follow
the reference implementation in
[Ursa.Avalonia/tests](https://github.com/irihitech/Ursa.Avalonia/tree/main/tests).

当用户需要为 Avalonia 控件库创建（或修复）Headless 测试项目时加载此 Skill。
项目结构与代码参考
[Ursa.Avalonia/tests](https://github.com/irihitech/Ursa.Avalonia/tree/main/tests)。

## Goals / 目标

- Produce a test project that builds and runs with `dotnet test` (or by
  executing the test assembly directly), with no display server required.
- Load a real theme so control templates are applied and template parts can be
  asserted.
- Enable Skia rendering only when the user needs pixel / screenshot tests.
- Ship one passing sample test per category so the user has a working pattern.

---

## Step 1 — Inspect the Repository / 步骤 1 — 检查仓库

Before asking anything, collect these facts (do not guess them):

在提问前先收集以下信息（不要猜测）：

| Fact / 信息 | Where to look / 查找位置 |
| --- | --- |
| Library project(s) to test | `src/**/*.csproj` referencing `Avalonia` |
| Avalonia version (11.x or 12.x) | `PackageReference Include="Avalonia"`, or `Directory.Packages.props` / `Directory.Build.props` |
| Target framework | `<TargetFramework(s)>` of the library — test TFM must be compatible (e.g. `net8.0`, `net10.0`) |
| Central Package Management | `Directory.Packages.props` with `ManagePackageVersionsCentrally=true` |
| Existing tests folder / solution | `tests/`, `*.sln` / `*.slnx` |
| Library-provided theme | A `Styles` / `ResourceDictionary` class or `.axaml` the library ships for its own controls (e.g. Ursa's `UrsaSemiTheme`) |

## Step 2 — Ask the User / 步骤 2 — 询问用户

**Always ask these two questions and wait for the answers before generating
files.** Present the default in brackets.

**生成文件前必须询问以下两个问题并等待回答。**

1. **Does the project need rendering support? / 是否需要渲染支持？** [No]
   - **No** — headless drawing (no Skia). Fast and lightweight. Layout,
     templates, bindings, input, focus, popups and text (via HarfBuzz) all
     work. `CaptureRenderedFrame()` returns `null`.
     不使用 Skia，速度快、依赖少；可测试布局、模板、绑定、输入、焦点、弹层等，
     但无法截帧。
   - **Yes** — real Skia rendering (`UseSkia()` +
     `UseHeadlessDrawing = false`). Required for tests that inspect pixels,
     compare screenshots, or verify a custom `Render(DrawingContext)` override.
     使用 Skia 真实渲染，可通过 `CaptureRenderedFrame()` 获取像素，用于截图对比或
     自定义 `Render` 的验证。
2. **Which theme should the test app load by default? / 测试应用默认加载哪个主题？**
   [Semi]
   - **Fluent** — `Avalonia.Themes.Fluent`, `<FluentTheme />`
   - **Semi** — `Semi.Avalonia`, `<semi:SemiTheme />`

Also confirm the values inferred in Step 1 (library project, test project name
`HeadlessTest.<LibName>`, and whether to include the library's own theme) in
the same message, so the user can correct them at once.

同时在同一条消息中确认步骤 1 推断出的信息（被测项目、测试项目名
`HeadlessTest.<LibName>`、是否包含库自带主题）。

---

## Step 3 — Project Layout / 步骤 3 — 项目结构

Replace `<LibName>` with the library name (e.g. `Ursa`) and `<LibProject>` with
the relative path to the library `.csproj`.

```text
tests/
└── HeadlessTest.<LibName>/
    ├── HeadlessTest.<LibName>.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── TestAppBuilder.cs
    ├── TestHelpers/
    │   └── ControlExtensions.cs
    ├── Controls/
    │   └── <Control>Tests/
    │       └── <Control>Tests.cs
    └── Rendering/                  # only when rendering support = Yes
        └── <Control>RenderTests.cs
```

Group tests per control in `Controls/<Control>Tests/` (one folder per control,
namespace `HeadlessTest.<LibName>.Controls.<Control>Tests`) as Ursa does.

---

## Step 4 — Test Project File / 步骤 4 — 测试项目文件

### Package matrix / 包矩阵

Pin every `Avalonia.*` package to **the same version the library uses**.

| Package | Avalonia 12.x | Avalonia 11.x | When |
| --- | --- | --- | --- |
| `Avalonia.Headless.XUnit` | `$(AvaloniaVersion)` | `$(AvaloniaVersion)` | always |
| `xunit.v3` | ≥ the `xunit.v3.extensibility.core` version required by `Avalonia.Headless.XUnit` (e.g. `3.2.2` for `12.0.2`) | — | Avalonia 12 |
| `xunit` + `xunit.runner.visualstudio` | — | `2.9.x` + `3.1.x` | Avalonia 11 |
| `Microsoft.NET.Test.Sdk` | yes | yes | always |
| `Avalonia.HarfBuzz` | `$(AvaloniaVersion)` | — (package does not exist for 11.x) | Avalonia 12 |
| `Avalonia.Skia` | `$(AvaloniaVersion)` | `$(AvaloniaVersion)` | rendering = Yes |
| `Avalonia.Themes.Fluent` | `$(AvaloniaVersion)` | `$(AvaloniaVersion)` | theme = Fluent |
| `Semi.Avalonia` | latest `12.x` | latest `11.x` | theme = Semi |

> `Avalonia.Headless.XUnit` 12.x is built on **xunit.v3**; 11.x is built on
> **xunit v2** — always use the matching xunit generation. A lower `xunit.v3` than the one
> `Avalonia.Headless.XUnit` depends on produces `NU1608` warnings.
> `Avalonia.Headless.XUnit` 12.x 基于 xunit.v3，11.x 基于 xunit v2，不能混用。

### Avalonia 12 (`HeadlessTest.<LibName>.csproj`)

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFramework>net10.0</TargetFramework>
        <ImplicitUsings>enable</ImplicitUsings>
        <LangVersion>latest</LangVersion>
        <Nullable>enable</Nullable>
        <IsPackable>false</IsPackable>
        <IsTestProject>true</IsTestProject>
        <OutputType>Exe</OutputType>
        <TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>
        <UseMicrosoftTestingPlatformRunner>true</UseMicrosoftTestingPlatformRunner>
        <AvaloniaVersion>12.0.2</AvaloniaVersion>
    </PropertyGroup>

    <ItemGroup>
        <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.14.1" />
        <PackageReference Include="xunit.v3" Version="3.2.2" />
        <PackageReference Include="Avalonia.Headless.XUnit" Version="$(AvaloniaVersion)" />
        <PackageReference Include="Avalonia.HarfBuzz" Version="$(AvaloniaVersion)" />
        <!-- Rendering = Yes only -->
        <PackageReference Include="Avalonia.Skia" Version="$(AvaloniaVersion)" />
        <!-- Theme: keep exactly one of the two -->
        <PackageReference Include="Avalonia.Themes.Fluent" Version="$(AvaloniaVersion)" />
        <PackageReference Include="Semi.Avalonia" Version="12.0.1" />
    </ItemGroup>

    <ItemGroup>
        <Using Include="Xunit" />
    </ItemGroup>

    <ItemGroup>
        <ProjectReference Include="<LibProject>" />
    </ItemGroup>
</Project>
```

Set `AvaloniaVersion` to the library's Avalonia version, or remove the property
if the repository already defines it (e.g. in `Directory.Build.props`).

### Avalonia 11 differences / Avalonia 11 差异

```xml
<ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.14.1" />
    <PackageReference Include="xunit" Version="2.9.3" />
    <PackageReference Include="xunit.runner.visualstudio" Version="3.1.4" />
    <PackageReference Include="Avalonia.Headless.XUnit" Version="$(AvaloniaVersion)" />
    <!-- no Avalonia.HarfBuzz on 11.x -->
    <!-- Avalonia.Skia / theme package exactly as above, with 11.x versions -->
</ItemGroup>
```

Drop `OutputType`, `TestingPlatformDotnetTestSupport` and
`UseMicrosoftTestingPlatformRunner` for xunit v2.

### Central Package Management / 中央包管理

If the repository has `Directory.Packages.props`, remove every `Version`
attribute from the test `.csproj` and add the versions there instead, e.g.:

若仓库使用中央包管理，从测试 `.csproj` 去掉 `Version`，改在
`Directory.Packages.props` 中声明：

```xml
<!--test-->
<PackageVersion Include="Avalonia.HarfBuzz" Version="$(AvaloniaVersion)" />
<PackageVersion Include="Avalonia.Headless.XUnit" Version="$(AvaloniaVersion)" />
<PackageVersion Include="Avalonia.Skia" Version="$(AvaloniaVersion)" />
<PackageVersion Include="Microsoft.NET.Test.Sdk" Version="17.14.1" />
<PackageVersion Include="xunit.v3" Version="3.2.2" />
```

Skip entries that already exist. Ursa additionally uses
`tests/Directory.Build.targets` with `VersionOverride` to run tests against a
different Avalonia version than `src/`; only add that if the user asks for it.

---

## Step 5 — Test Application / 步骤 5 — 测试应用

### `App.axaml` — Fluent

```xml
<Application xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             x:Class="HeadlessTest.<LibName>.App"
             RequestedThemeVariant="Light">
    <Application.Styles>
        <FluentTheme />
        <!-- library theme, if any, goes after the base theme -->
    </Application.Styles>
</Application>
```

### `App.axaml` — Semi

```xml
<Application xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:semi="https://irihi.tech/semi"
             x:Class="HeadlessTest.<LibName>.App"
             RequestedThemeVariant="Light">
    <Application.Styles>
        <semi:SemiTheme />
        <!-- library theme, if any, goes after the base theme -->
    </Application.Styles>
</Application>
```

Fix `RequestedThemeVariant` to `Light` so resource lookups and pixel colors
are deterministic. If the library ships its own theme, add it after the base
theme, e.g. `<semi:UrsaSemiTheme />` (Ursa) or
`<StyleInclude Source="avares://<LibName>/Themes/Generic.axaml" />`, and add a
`ProjectReference` to the theme project if it is separate.

固定 `RequestedThemeVariant="Light"` 以保证资源与像素颜色可复现；库自带主题放在基础
主题之后。

### `App.axaml.cs`

```csharp
using Avalonia;
using Avalonia.Markup.Xaml;

namespace HeadlessTest.<LibName>;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
```

### `TestAppBuilder.cs` — Rendering = No

```csharp
using Avalonia;
using Avalonia.Headless;
using HeadlessTest.<LibName>;

[assembly: AvaloniaTestApplication(typeof(TestAppBuilder))]

namespace HeadlessTest.<LibName>;

public class TestAppBuilder
{
    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder
            .Configure<App>()
            .UseHarfBuzz()                       // Avalonia 12 only — remove on 11.x
            .UseHeadless(new AvaloniaHeadlessPlatformOptions());
}
```

### `TestAppBuilder.cs` — Rendering = Yes

```csharp
using Avalonia;
using Avalonia.Headless;
using HeadlessTest.<LibName>;

[assembly: AvaloniaTestApplication(typeof(TestAppBuilder))]

namespace HeadlessTest.<LibName>;

public class TestAppBuilder
{
    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder
            .Configure<App>()
            .UseSkia()
            .UseHarfBuzz()                       // Avalonia 12 only — remove on 11.x
            .UseHeadless(new AvaloniaHeadlessPlatformOptions { UseHeadlessDrawing = false });
}
```

> Only **one** `[assembly: AvaloniaTestApplication]` is allowed per test
> assembly, so every test in the project shares this builder. If the user wants
> fast non-rendering tests *and* Skia tests, create a second project (e.g.
> `RenderTest.<LibName>`) with the Skia builder.
> 每个测试程序集只能有一个 `AvaloniaTestApplication`；如需同时拥有两种模式，请拆成两个项目。

### `TestHelpers/ControlExtensions.cs`

Works on both Avalonia 11 and 12:

```csharp
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.VisualTree;

namespace HeadlessTest.<LibName>.TestHelpers;

public static class ControlExtensions
{
    public static IEnumerable<T> GetTemplateChildrenOfType<T>(this TemplatedControl control) where T : Control
    {
        return control.GetVisualDescendants().OfType<T>().Where(a => a.TemplatedParent == control);
    }

    public static T? GetTemplateChildOfType<T>(this TemplatedControl control, string name) where T : Control
    {
        return control.GetTemplateChildrenOfType<T>().FirstOrDefault(a => a.Name == name);
    }
}
```

---

## Step 6 — Sample Tests / 步骤 6 — 示例测试

Generate tests against a real control from the library (pick one with template
parts, e.g. a `PART_*` constant). Use `[AvaloniaFact]` / `[AvaloniaTheory]` —
**never** plain `[Fact]`, which runs off the Avalonia UI thread.

针对库中真实控件生成测试；必须使用 `[AvaloniaFact]` / `[AvaloniaTheory]`，不要用 `[Fact]`。

### Template / property test

```csharp
using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using HeadlessTest.<LibName>.TestHelpers;
using <LibNamespace>;

namespace HeadlessTest.<LibName>.Controls.<Control>Tests;

public class <Control>Tests
{
    [AvaloniaFact]
    public void Template_Part_Should_Exist()
    {
        // Arrange — controls only get their template once attached to a shown TopLevel
        var window = new Window();
        var control = new <Control>();
        window.Content = control;
        window.Show();

        // Assert
        var part = control.GetTemplateChildOfType<Button>(<Control>.PART_CloseButton);
        Assert.NotNull(part);
    }
}
```

### Input test

```csharp
using Avalonia;
using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using Avalonia.Layout;

namespace HeadlessTest.<LibName>.Controls;

public class InputTests
{
    [AvaloniaFact]
    public void Click_And_Type()
    {
        var window = new Window { Width = 200, Height = 200 };
        var clicked = 0;
        var button = new Button
        {
            Content = "OK", Width = 100, Height = 40,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
        };
        button.Click += (_, _) => clicked++;
        window.Content = button;
        window.Show();

        // Mouse positions are relative to the window
        window.MouseDown(new Point(10, 10), MouseButton.Left);
        window.MouseUp(new Point(10, 10), MouseButton.Left);
        Assert.Equal(1, clicked);

        var textBox = new TextBox();
        window.Content = textBox;
        Avalonia.Threading.Dispatcher.UIThread.RunJobs();
        textBox.Focus();
        window.KeyTextInput("abc");                                     // text input
        window.KeyPressQwerty(PhysicalKey.A, RawInputModifiers.Control); // shortcuts
        Assert.Equal("abc", textBox.Text);
    }
}
```

### Render test — Rendering = Yes only

```csharp
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace HeadlessTest.<LibName>.Rendering;

public class <Control>RenderTests
{
    [AvaloniaFact]
    public void Control_Should_Render_Expected_Color()
    {
        var window = new Window { Width = 100, Height = 100, Background = Brushes.White };
        window.Content = new <Control>
        {
            Width = 50, Height = 50,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
        };
        window.Show();

        var frame = window.CaptureRenderedFrame();   // null unless Skia rendering is enabled
        Assert.NotNull(frame);
        // frame.Save("Control_Should_Render_Expected_Color.png"); // inspect output manually

        Assert.Equal(Colors.White, GetPixel(frame, 80, 80));
    }

    private static Color GetPixel(WriteableBitmap bitmap, int x, int y)
    {
        using var buffer = bitmap.Lock();
        var bytes = new byte[4];
        Marshal.Copy(buffer.Address + y * buffer.RowBytes + x * 4, bytes, 0, 4);
        // Pixel format depends on the platform (e.g. Rgba8888 on Linux), so check it
        return buffer.Format == PixelFormat.Rgba8888
            ? Color.FromArgb(bytes[3], bytes[0], bytes[1], bytes[2])
            : Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]);
    }
}
```

---

## Step 7 — Register and Run / 步骤 7 — 注册并运行

```bash
dotnet sln add tests/HeadlessTest.<LibName>/HeadlessTest.<LibName>.csproj
dotnet test tests/HeadlessTest.<LibName>
```

Like Ursa's CI, the xunit.v3 test assembly can also be executed directly, which
prints failure messages and stack traces straight to the console:

与 Ursa CI 一样，xunit.v3 测试程序集可直接执行，失败信息直接输出到控制台：

```bash
dotnet build tests/HeadlessTest.<LibName> --configuration Release
dotnet tests/HeadlessTest.<LibName>/bin/Release/net10.0/HeadlessTest.<LibName>.dll
```

Headless tests need no display server, so they run on `ubuntu-latest` and
`windows-latest` GitHub runners without `xvfb`.

Run the tests after generating the files and fix any failure before reporting
completion.

---

## Pitfalls / 常见问题

| Symptom / 现象 | Cause & fix / 原因与修复 |
| --- | --- |
| Template part is `null` | Theme missing in `App.axaml`, or `window.Show()` not called before querying |
| `InvalidOperationException: The calling thread cannot access this object because a different thread owns it` | Test uses `[Fact]` instead of `[AvaloniaFact]` |
| `CaptureRenderedFrame()` returns `null` | Builder lacks `.UseSkia()` + `UseHeadlessDrawing = false` |
| Wrong pixel channels (red read as blue) | Ignored `buffer.Format`; use the `GetPixel` helper above |
| `NU1608` on `xunit.v3.*` | `xunit.v3` older than the version required by `Avalonia.Headless.XUnit` |
| `Avalonia.HarfBuzz` not found | Library is on Avalonia 11; remove the package and `.UseHarfBuzz()` |
| Posted work / bindings not applied yet | Call `Dispatcher.UIThread.RunJobs()` (and `window.UpdateLayout()` for layout) before asserting |
| State leaks between tests | Create a new `Window` per test; do not cache controls in static fields |
