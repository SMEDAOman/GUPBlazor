# GUPBlazor — getting started

> GUPBlazor 0.3.4: 69 Blazor components implementing the gov.om (Government Unified
> Platform) design system. Targets `net10.0`. WCAG 2.2 AA, full RTL, Arabic localization.
> Maintained by the SMEs Development Authority (Oman).

## 1. Install

```bash
dotnet add package GUPBlazor
```

## 2. Register services

In `Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddGUPBlazor();
```

`AddGUPBlazor()` registers the services the components depend on, including the toast host.

## 3. Wire up styles and scripts

In `App.razor`, put `<GUPHTMLHeader />` inside `<head>` and `<GUPHTMLFooter />` just before
`</body>`:

```razor
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />

    <GUPHTMLHeader />

    <HeadOutlet />
</head>
<body>
    <Routes />
    <script src="_framework/blazor.web.js"></script>

    <GUPHTMLFooter />
</body>
</html>
```

`GUPHTMLHeader` emits the gov.om stylesheet (`gup.css`), the design tokens, Material Symbols
Outlined, and the Readex Pro font. Without it the components render unstyled.

## 4. Import the namespaces

In `_Imports.razor`:

```razor
@using GUPBlazor.Components
@using GUPBlazor.Services
```

## 5. A first page

```razor
@page "/apply"
@rendermode InteractiveServer

<GupContentHeader PageTitle="Apply for an SME Licence">
    <PageSummary>Complete the form below to submit your application.</PageSummary>
</GupContentHeader>

<GupFormSection>
    <GupInputField Name="company" Type="text" @bind-Value="_company">
        <ChildContent>Company name</ChildContent>
        <Hint>As registered with the Ministry of Commerce.</Hint>
    </GupInputField>
</GupFormSection>

<GupButton Appearance="@GupButtonAppearance.Primary" OnClick="Submit">
    <ChildContent>Submit</ChildContent>
</GupButton>

@code {
    private string? _company;
    private void Submit() { }
}
```

Interactive components (anything with `OnClick`, `@bind-`, or open/close state) need a render
mode. Use `@rendermode InteractiveServer` on the page, or set it per component.

## Where to look next

- [Conventions](/ai/conventions.md) — slots vs attributes, binding, RTL, icons.
- [Component index](/ai/index.md) — all 69 components.
- [Everything in one file](/llms-full.txt) — single fetch, full reference.