using System.Text;

namespace AiDocsGen;

/// The guide pages. Hand-written because they carry conventions that cannot be
/// derived from signatures — and they are what an agent reads before its first edit.
public static class StaticPages
{
    public static void Write(string outDir, string baseUrl, string version, int componentCount)
    {
        Directory.CreateDirectory(outDir);
        var utf8 = new UTF8Encoding(false);

        File.WriteAllText(Path.Combine(outDir, "getting-started.md"),
            GettingStarted(baseUrl, version, componentCount), utf8);

        File.WriteAllText(Path.Combine(outDir, "conventions.md"),
            Conventions(baseUrl), utf8);
    }

    private static string GettingStarted(string baseUrl, string version, int count) =>
        $$"""
        # GUPBlazor — getting started

        > GUPBlazor {{version}}: {{count}} Blazor components implementing the gov.om (Government Unified
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

        - [Conventions]({{baseUrl}}/ai/conventions.md) — slots vs attributes, binding, RTL, icons.
        - [Component index]({{baseUrl}}/ai/index.md) — all {{count}} components.
        - [Everything in one file]({{baseUrl}}/llms-full.txt) — single fetch, full reference.
        """;

    private static string Conventions(string baseUrl) =>
        ConventionsBody(baseUrl)
            .Replace("BRACE_OPEN", "{")
            .Replace("BRACE_CLOSE", "}");

    private static string ConventionsBody(string baseUrl) =>
        $"""
        # GUPBlazor — conventions

        The rules that are not visible from a parameter list. Read this before writing markup.

        ## Named slots are elements, not attributes

        Most components take their content through `RenderFragment` slots. A slot is a child
        **element**, never an attribute:

        ```razor
        @* correct *@
        <GupInputField Name="email" Type="email" @bind-Value="_email">
            <ChildContent>Email address</ChildContent>
            <Hint>We will only use this to contact you about your application.</Hint>
        </GupInputField>

        @* wrong — Hint is a slot, not a string attribute *@
        <GupInputField Name="email" Hint="We will only use this..." />
        ```

        **The rule that catches everyone:** as soon as you use *any* named slot, the default content
        must also be wrapped in `<ChildContent>` explicitly. Bare text alongside a named slot will
        not compile.

        ```razor
        @* fine — only default content, no wrapper needed *@
        <GupButton Appearance="@GupButtonAppearance.Primary">Submit</GupButton>

        @* needs the wrapper, because IconStart is present *@
        <GupButton Appearance="@GupButtonAppearance.Primary">
            <IconStart><GupIcon IconName="arrow-back" Width="20" Height="20" /></IconStart>
            <ChildContent>Back</ChildContent>
        </GupButton>
        ```

        ## Enums, not strings

        Variants are enums. Pass them with `@`:

        ```razor
        <GupButton Appearance="@GupButtonAppearance.Primary" />
        <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Link" Href="/next" />
        ```

        Each component's page lists its enums and every member.

        ## Two-way binding

        Where a component exposes `Value` plus `ValueChanged`, use `@bind-Value`. The component docs
        mark every bindable parameter.

        ```razor
        <GupInputField Name="company" @bind-Value="_company" />
        <GupToggle @bind-Checked="_optedIn" />
        ```

        ## Text fields are required by default

        `GupInputField`, `GupTextarea` and `GupDropdownField` default `Required` to **true** — the
        opposite of plain HTML. Opt a field out explicitly:

        ```razor
        <GupInputField Name="middle-name" Required="false" @bind-Value="_middleName" />
        ```

        `GupCheckbox` and `GupFileUpload` default `Required` to **false**. Check the component's
        parameter table rather than assuming.

        ## Icons

        `GupIcon` renders Material Symbols Outlined by ligature name. Always give an explicit size;
        the font ligature will otherwise inherit surrounding type and look wrong.

        ```razor
        <GupIcon IconName="arrow-forward" Width="20" Height="20" />
        ```

        `Width` and `Height` default to 16, which is small for body text — 20 or 24 is the usual
        choice inside a button. Icon names accept either `snake_case` or `kebab-case` (`live_help`
        and `live-help` both resolve).

        ## RTL and Arabic

        Styling uses CSS logical properties throughout (`margin-inline`, `inset-inline-start`), so
        setting direction is all that is required — no mirrored stylesheet, no per-component flag:

        ```razor
        <html dir="rtl" lang="ar">
        ```

        `dir="rtl"` works on any container, not just `<html>`, which is how the demo previews a
        single component in RTL.

        ## Read-only cascade

        To lock a whole form, cascade one flag rather than setting `Readonly` on each field. Field
        components read the cascading value named `GupReadOnly`:

        ```razor
        <CascadingValue Name="GupReadOnly" Value="true">
            <GupFormSection>
                @* every field inside renders read-only *@
            </GupFormSection>
        </CascadingValue>
        ```

        `GupReadOnlyRegion` wraps this for a subtree.

        ## Render modes

        The components are plain Blazor and do not set a render mode themselves. Anything
        interactive — clicks, binding, dialogs, toasts — needs one from the host:

        ```razor
        @rendermode InteractiveServer
        ```

        Static server rendering is fine for display-only pages (tables, labelled items, prose).

        ## Toasts

        Place a single `GupToastContainer` in the layout, then raise toasts through the injected
        `ToastService`. Severity is a **string**, not an enum — one of `neutral` (default),
        `positive`, `warning` or `negative`:

        ```razor
        @inject ToastService Toasts
        <GupButton OnClick="ShowSaved">Save</GupButton>

        @code BRACE_OPEN
            private void ShowSaved() => Toasts.Show("Application saved", "positive");
        BRACE_CLOSE
        ```

        `Show` returns a `Guid` you can pass to `Remove(id)`; `Clear()` dismisses all of them.
        It also takes `delayMs` (default 5000) and `closeLabel`.

        ## Naming

        Components are prefixed `Gup`. Four legacy ones use an uppercase `GUP` — `GUPHTMLHeader`,
        `GUPHTMLFooter`, `GUPWizardStack`, `GUPWizardStackStep`. The casing is significant in Razor.

        ---

        Full index: {baseUrl}/ai/index.md
        """;
}
