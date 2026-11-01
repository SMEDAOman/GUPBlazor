using System.Text.RegularExpressions;
using System.Text;

namespace AiDocsGen;

public sealed class MarkdownWriter(string baseUrl, string version)
{
    /// Absolute, link-free fallback: GitHub raw serves the same files, so an assistant
    /// whose fetcher refuses relative or constructed URLs can still reach them.
    private const string RawBase = "https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs";

    public string Component(ComponentDoc c)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"# {c.Name}");
        sb.AppendLine();
        sb.AppendLine($"> GUPBlazor {version} — Blazor implementation of the gov.om (Government Unified Platform) design system.");
        sb.AppendLine($"> Source: `GUPBlazor/Components/{c.File}`");
        if (c.DemoPage is not null)
        {
            sb.AppendLine($"> Live demo: {baseUrl}{c.DemoPage.Route}");
        }

        sb.AppendLine();

        var summary = c.Summary ?? c.DemoPage?.Description;
        if (!string.IsNullOrWhiteSpace(summary))
        {
            sb.AppendLine(summary);
            sb.AppendLine();
        }

        if (!string.IsNullOrWhiteSpace(c.HeaderComment))
        {
            sb.AppendLine("## Upstream mapping");
            sb.AppendLine();
            sb.AppendLine($"```text");
            sb.AppendLine(c.HeaderComment);
            sb.AppendLine("```");
            sb.AppendLine();
        }

        sb.AppendLine("## Import");
        sb.AppendLine();
        sb.AppendLine("```razor");
        sb.AppendLine("@using GUPBlazor.Components");
        sb.AppendLine("```");
        sb.AppendLine();

        WriteParameters(sb, c);
        WriteSlots(sb, c);
        WriteEvents(sb, c, baseUrl);
        WriteEnums(sb, c);
        WriteCascading(sb, c);
        WriteExamples(sb, c);

        sb.AppendLine("---");
        sb.AppendLine();
        sb.AppendLine($"Full component index: {baseUrl}/ai/index.md · Start here: {baseUrl}/docs");
        sb.AppendLine();
        sb.AppendLine($"Absolute mirror, if relative links do not resolve for you: `{RawBase}/ai/components/{Slug(c.Name)}.md`");

        return sb.ToString();
    }

    private static void WriteParameters(StringBuilder sb, ComponentDoc c)
    {
        var plain = c.Parameters.Where(p => !p.IsSlot && !p.IsEventCallback).ToList();
        if (plain.Count == 0)
        {
            return;
        }

        sb.AppendLine("## Parameters");
        sb.AppendLine();
        sb.AppendLine("| Parameter | Type | Default | Bindable | Description |");
        sb.AppendLine("|---|---|---|---|---|");

        foreach (var p in plain)
        {
            var bind = p.IsBindable ? $"`@bind-{p.Name}`" : "—";
            sb.AppendLine($"| `{p.Name}` | `{Escape(p.Type)}` | {(p.Default is null ? "—" : $"`{Escape(p.Default)}`")} | {bind} | {Escape(p.Summary ?? "")} |");
        }

        sb.AppendLine();
    }

    private static void WriteSlots(StringBuilder sb, ComponentDoc c)
    {
        var slots = c.Parameters.Where(p => p.IsSlot).ToList();
        if (slots.Count == 0)
        {
            return;
        }

        sb.AppendLine("## Slots (RenderFragment)");
        sb.AppendLine();
        sb.AppendLine("| Slot | Description |");
        sb.AppendLine("|---|---|");

        foreach (var s in slots)
        {
            var note = s.Summary ?? (s.Name == "ChildContent" ? "Default content." : "");
            sb.AppendLine($"| `<{s.Name}>` | {Escape(note)} |");
        }

        sb.AppendLine();
        sb.AppendLine("> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.");
        sb.AppendLine();
    }

    private static void WriteEvents(StringBuilder sb, ComponentDoc c, string baseUrl)
    {
        var events = c.Parameters.Where(p => p.IsEventCallback).ToList();
        if (events.Count == 0)
        {
            return;
        }

        sb.AppendLine("## Events");
        sb.AppendLine();
        sb.AppendLine("| Event | Type | Description |");
        sb.AppendLine("|---|---|---|");

        foreach (var e in events)
        {
            sb.AppendLine($"| `{e.Name}` | `{Escape(e.Type)}` | {Escape(e.Summary ?? "")} |");
        }

        sb.AppendLine();

        // A payload type's members live on the types page, not here. Enums are already
        // expanded in full below, so they must not trigger this.
        var payloads = events
            .Select(e => e.Type)
            .SelectMany(t => Regex.Matches(t, @"Gup\w+").Select(m => m.Value))
            .Where(n => !c.Enums.Any(e => e.Name == n))
            .Distinct(StringComparer.Ordinal)
            .ToList();

        if (payloads.Count > 0)
        {
            var names = string.Join(", ", payloads.Select(p => $"`{p}`"));
            sb.AppendLine($"> Members of {names} are documented in [support types]({baseUrl}/ai/types.md).");
            sb.AppendLine();
        }
    }

    private static void WriteEnums(StringBuilder sb, ComponentDoc c)
    {
        if (c.Enums.Count == 0)
        {
            return;
        }

        sb.AppendLine("## Enums");
        sb.AppendLine();

        foreach (var e in c.Enums)
        {
            sb.AppendLine($"### `{e.Name}`");
            sb.AppendLine();
            if (!string.IsNullOrWhiteSpace(e.Summary))
            {
                sb.AppendLine(e.Summary);
                sb.AppendLine();
            }

            foreach (var (member, memberSummary) in e.Members)
            {
                var tail = string.IsNullOrWhiteSpace(memberSummary) ? "" : $" — {memberSummary}";
                sb.AppendLine($"- `{e.Name}.{member}`{tail}");
            }

            sb.AppendLine();
        }
    }

    private static void WriteCascading(StringBuilder sb, ComponentDoc c)
    {
        if (c.CascadingParameters.Count == 0)
        {
            return;
        }

        sb.AppendLine("## Cascading values consumed");
        sb.AppendLine();
        foreach (var cp in c.CascadingParameters)
        {
            sb.AppendLine($"- {cp}");
        }

        sb.AppendLine();
    }

    private static void WriteExamples(StringBuilder sb, ComponentDoc c)
    {
        if (c.Examples.Count == 0)
        {
            return;
        }

        sb.AppendLine("## Examples");
        sb.AppendLine();
        sb.AppendLine("Verbatim from the demo pages — this is the markup that renders in the live demo.");
        sb.AppendLine();

        foreach (var ex in c.Examples)
        {
            sb.AppendLine($"### {ex.Label}");
            sb.AppendLine();
            sb.AppendLine($"<!-- from GUPBlazorDemo/Components/Pages/.../{ex.SourcePage} -->");
            sb.AppendLine("```razor");
            sb.AppendLine(ex.Code);
            sb.AppendLine("```");
            sb.AppendLine();
        }
    }

    public string Index(List<ComponentDoc> components, List<SectionDoc> sections)
    {
        var sb = new StringBuilder();

        sb.AppendLine("# GUPBlazor — AI reference index");
        sb.AppendLine();
        sb.AppendLine($"GUPBlazor {version}: {components.Count} documented Blazor components implementing the gov.om");
        sb.AppendLine("(Government Unified Platform) design system, by the SMEs Development Authority (Oman).");
        sb.AppendLine("WCAG 2.2 AA, full RTL, Arabic localization. Targets `net10.0`.");
        sb.AppendLine();
        sb.AppendLine($"- Start here: {baseUrl}/docs (conventions and a worked example inline)");
        sb.AppendLine($"- Everything in one file: {baseUrl}/llms-full.txt");
        sb.AppendLine($"- Getting started: {baseUrl}/ai/getting-started.md");
        sb.AppendLine($"- Types, services and helpers: {baseUrl}/ai/types.md");
        sb.AppendLine($"- Patterns: {baseUrl}/ai/patterns.md");
        sb.AppendLine("- NuGet: https://www.nuget.org/packages/GUPBlazor");
        sb.AppendLine("- Repository: https://github.com/SMEDAOman/GUPBlazor");
        sb.AppendLine();

        if (baseUrl.Length == 0)
        {
            sb.AppendLine("Links below are relative to wherever this file is served from — resolve them");
            sb.AppendLine("against this document's own URL.");
            sb.AppendLine();
        }


        sb.AppendLine("## Components");
        sb.AppendLine();
        sb.AppendLine("| Component | Docs | Live demo | Summary |");
        sb.AppendLine("|---|---|---|---|");

        foreach (var c in components.OrderBy(c => c.Name, StringComparer.Ordinal))
        {
            var demo = c.DemoPage is null ? "—" : $"[demo]({baseUrl}{c.DemoPage.Route})";
            var summary = Truncate(c.Summary ?? c.DemoPage?.Description ?? "", 110);
            sb.AppendLine($"| `{c.Name}` | [md]({baseUrl}/ai/components/{Slug(c.Name)}.md) | {demo} | {Escape(summary)} |");
        }

        sb.AppendLine();

        if (sections.Count > 0)
        {
            sb.AppendLine("## Demo catalogue");
            sb.AppendLine();
            foreach (var s in sections)
            {
                sb.AppendLine($"### {s.Title}");
                sb.AppendLine();
                if (!string.IsNullOrWhiteSpace(s.Intro))
                {
                    sb.AppendLine(s.Intro);
                    sb.AppendLine();
                }

                foreach (var p in s.Pages)
                {
                    sb.AppendLine($"- [{p.Title}]({baseUrl}{p.Route}) — {p.Description}");
                }

                sb.AppendLine();
            }
        }

        return sb.ToString();
    }

    public string LlmsTxt(List<ComponentDoc> components)
    {
        var sb = new StringBuilder();

        sb.AppendLine("# GUPBlazor");
        sb.AppendLine();
        sb.AppendLine($"> Blazor component library implementing the gov.om (Government Unified Platform) design system for Oman government services. Version {version}, targets net10.0. {components.Count} components with WCAG 2.2 AA accessibility, full RTL support and Arabic localization. Maintained by the SMEs Development Authority (Oman).");
        sb.AppendLine();
        sb.AppendLine("Install with `dotnet add package GUPBlazor`. Register with `builder.Services.AddGUPBlazor()`, then put `<GUPHTMLHeader />` in `<head>` and `<GUPHTMLFooter />` before `</body>` in App.razor.");
        sb.AppendLine();
        sb.AppendLine("All component names are prefixed `Gup` (a few legacy ones use `GUP`). Component docs below are plain markdown and contain the full parameter list, slots, enums and real examples.");
        sb.AppendLine();

        // Inlined, not just linked: a fetcher that cannot follow links, or that truncates
        // this file, must still get the rules that otherwise cause invented parameters.
        sb.AppendLine("## Rules that prevent invented parameters");
        sb.AppendLine();
        sb.AppendLine("Read these even if you fetch nothing else. Each one is a mistake AI assistants make repeatedly.");
        sb.AppendLine();
        sb.AppendLine("> **Do not guess a parameter, slot or enum name.** Everything you need is either in");
        sb.AppendLine("> the rules below or in the table further down. If something genuinely is not here,");
        sb.AppendLine("> fetch the component's own page (absolute URLs below). If you still cannot confirm");
        sb.AppendLine("> it, leave that part out and say so — a page that omits a feature compiles; a page");
        sb.AppendLine("> with an invented parameter name does not.");
        sb.AppendLine();
        sb.AppendLine("**Before writing any component, check its row in *Every component at a glance* below.**");
        sb.AppendLine("That table lists the slots and bindable properties of all components in this file, so you");
        sb.AppendLine("never need to guess them — and never need to fetch another page to find them.");
        sb.AppendLine();
        sb.AppendLine("**If your fetcher cannot open the relative links in this file**, every page here is also");
        sb.AppendLine("served from GitHub at absolute URLs, which need no link-following:");
        sb.AppendLine();
        sb.AppendLine($"- `{RawBase}/llms.txt` — this file");
        sb.AppendLine($"- `{RawBase}/ai/components/<name>.md` — one per component, e.g. `gup-input-field.md`");
        sb.AppendLine($"- `{RawBase}/ai/conventions.md`, `/ai/types.md`, `/ai/patterns.md`");
        sb.AppendLine();
        sb.AppendLine("Component file names are the component name in kebab-case: `GupInputField` →");
        sb.AppendLine("`gup-input-field.md`, `GUPWizardStack` → `gup-wizard-stack.md`. **Never guess a");
        sb.AppendLine("parameter name — fetch the component's page instead.**");
        sb.AppendLine();
        sb.AppendLine("1. **There is no `Label` parameter on fields.** The label is a slot, and which slot");
        sb.AppendLine("   it is depends on the component: if the table below shows a `<Label>` slot, use it");
        sb.AppendLine("   (`GupDropdownField` does); otherwise the label goes in `<ChildContent>`");
        sb.AppendLine("   (`GupInputField`, `GupTextarea`, `GupCheckbox`, `GupFileUpload` and the rest).");
        sb.AppendLine("   Check the component's row — do not assume one field behaves like another.");
        sb.AppendLine("2. **Hints and errors are slots, not attributes.** `<Hint>…</Hint>` on most fields, but");
        sb.AppendLine("   `<HintContent>` on `GupTextarea`. `Hint=\"...\"` as an attribute does not compile.");
        sb.AppendLine("3. **Using any named slot forces an explicit `<ChildContent>`** around the default");
        sb.AppendLine("   content. Bare text beside a named slot does not compile.");
        sb.AppendLine("4. **`Required` defaults to `true`** on `GupInputField`, `GupTextarea` and");
        sb.AppendLine("   `GupDropdownField` — the opposite of HTML. It defaults to `false` on `GupFileUpload`.");
        sb.AppendLine("5. **Variants are enums, passed with `@`**: `Appearance=\"@GupButtonAppearance.Primary\"`.");
        sb.AppendLine("   But `GupDialog.Size` and `ToastService` severity are **strings**, not enums.");
        sb.AppendLine("6. **There is no `GupErrorSummary`.** The error summary is a pattern: a `GupBanner`");
        sb.AppendLine("   with `Type=\"GupBannerType.Error\"` wrapping a list of link buttons.");
        sb.AppendLine("7. **`GupFileUpload.OnChange`** receives `IReadOnlyList<GupFileUploadFile>`, whose");
        sb.AppendLine("   members are `Name` (string), `Size` (long), `Type` (string), `LastModified` (long).");
        sb.AppendLine("   It carries metadata only — no stream or `IBrowserFile`.");
        sb.AppendLine("8. **Interactive components need a render mode**: put `@rendermode InteractiveServer`");
        sb.AppendLine("   on the page for clicks, binding, dialogs and toasts to work.");
        sb.AppendLine("9. **`GupCheckbox` and `GupToggle` bind `@bind-Checked`, not `@bind-Value`.**");
        sb.AppendLine("   Text fields, textareas and dropdowns use `@bind-Value`.");
        sb.AppendLine("10. **`GupContentHeader` has no `Title` slot.** The title is the `PageTitle`");
        sb.AppendLine("    *attribute*; its slots are `<PageSummary>`, `<Breadcrumbs>`,");
        sb.AppendLine("    `<PageTitleContent>`, `<PageSubtitleContent>` and `<ChildContent>`.");
        sb.AppendLine("11. **`IsInvalid` and `ErrorMessage` work the same on every field component**");
        sb.AppendLine("    — `GupInputField`, `GupTextarea`, `GupDropdownField`, `GupFileUpload`.");
        sb.AppendLine("12. **`GupBannerType` is `Neutral`, `Success`, `Warning`, `Error`.**");
        sb.AppendLine("    Appearance is a separate enum: `GupBannerAppearance.Outline` or `.Filled`.");
        sb.AppendLine("13. **Where a name appears both as an attribute and as a `…Content` slot**");
        sb.AppendLine("    (e.g. `ErrorMessage` and `<ErrorMessageContent>`), the attribute takes plain");
        sb.AppendLine("    text and the slot takes markup. Use one; the slot wins if both are set.");
        sb.AppendLine();
        sb.AppendLine("### A correct field, end to end");
        sb.AppendLine();
        sb.AppendLine("```razor");
        sb.AppendLine("@rendermode InteractiveServer");
        sb.AppendLine("@using GUPBlazor.Components");
        sb.AppendLine();
        sb.AppendLine("<GupFormSection>");
        sb.AppendLine("    <Title>Business details</Title>");
        sb.AppendLine("    <ChildContent>");
        sb.AppendLine("        <GupFormList>");
        sb.AppendLine("            <GupInputField Name=\"company\" Type=\"text\" @bind-Value=\"_company\"");
        sb.AppendLine("                           IsInvalid=\"_companyInvalid\"");
        sb.AppendLine("                           ErrorMessage=\"Enter your company name\">");
        sb.AppendLine("                <ChildContent>Company name</ChildContent>");
        sb.AppendLine("                <Hint>As registered on your commercial registration.</Hint>");
        sb.AppendLine("            </GupInputField>");
        sb.AppendLine();
        sb.AppendLine("            <GupDropdownField Name=\"sector\" Placeholder=\"Select a sector\"");
        sb.AppendLine("                              @bind-Value=\"_sector\">");
        sb.AppendLine("                <Label>Sector</Label>");
        sb.AppendLine("                <ChildContent>");
        sb.AppendLine("                    <GupDropdownMenu>");
        sb.AppendLine("                        <GupDropdownMenuItem Label=\"Manufacturing\" Value=\"mfg\" />");
        sb.AppendLine("                        <GupDropdownMenuItem Label=\"Logistics\" Value=\"log\" />");
        sb.AppendLine("                    </GupDropdownMenu>");
        sb.AppendLine("                </ChildContent>");
        sb.AppendLine("            </GupDropdownField>");
        sb.AppendLine("        </GupFormList>");
        sb.AppendLine("    </ChildContent>");
        sb.AppendLine("    <FooterContent>");
        sb.AppendLine("        <GupButton Appearance=\"@GupButtonAppearance.Primary\" OnClick=\"Submit\">");
        sb.AppendLine("            <ChildContent>Submit</ChildContent>");
        sb.AppendLine("        </GupButton>");
        sb.AppendLine("    </FooterContent>");
        sb.AppendLine("</GupFormSection>");
        sb.AppendLine("```");
        sb.AppendLine();

        sb.AppendLine("## Docs");
        sb.AppendLine();
        sb.AppendLine($"- [Getting started]({baseUrl}/ai/getting-started.md): install, register services, wire up styles and scripts, first page.");
        sb.AppendLine($"- [Component index]({baseUrl}/ai/index.md): every component with its summary and demo link.");
        sb.AppendLine($"- [Conventions]({baseUrl}/ai/conventions.md): slots vs attributes, binding, RTL, icons, read-only cascade.");
        sb.AppendLine($"- [Design tokens]({baseUrl}/ai/design-tokens.md): the CSS custom properties the library exports.");
        sb.AppendLine($"- [Types, services and helpers]({baseUrl}/ai/types.md): injectable services called from C# (`ToastService`), event payloads and config objects (`GupFileUploadFile`, `GupDataTableColumn`), and static lookups (`GupFlagCountries`).");
        sb.AppendLine($"- [Patterns]({baseUrl}/ai/patterns.md): compositions with no component of their own, e.g. the error summary.");
        sb.AppendLine();

        // Signatures inline, not just links: an assistant whose fetcher cannot follow
        // links gets names and nothing buildable from a link list, and starts inventing
        // parameter names. Slots and bindables are what it actually guesses wrong.
        sb.AppendLine("## Every component at a glance");
        sb.AppendLine();
        sb.AppendLine("Slots are **child elements**, never attributes. A `@bind-` column entry means that");
        sb.AppendLine("property is two-way bindable. Follow the per-component link for parameters, enums");
        sb.AppendLine("and examples — but if you cannot, this table plus the rules above is enough to");
        sb.AppendLine("write correct markup without guessing.");
        sb.AppendLine();
        sb.AppendLine("Every name below is complete and exact. If an attribute you want is not listed for a");
        sb.AppendLine("component, that component does not have it — do not invent one.");
        sb.AppendLine();
        sb.AppendLine("| Component | Slots (child elements) | Attributes | Two-way bind |");
        sb.AppendLine("|---|---|---|---|");

        foreach (var c in components.OrderBy(c => c.Name, StringComparer.Ordinal))
        {
            var slots = c.Parameters.Where(p => p.IsSlot).Select(p => $"`<{p.Name}>`").ToList();
            var binds = c.Parameters.Where(p => p.IsBindable).Select(p => $"`@bind-{p.Name}`").ToList();

            // Plain attributes: not slots, not the Changed half of a bindable pair.
            var attrs = c.Parameters
                .Where(p => !p.IsSlot && !p.IsEventCallback)
                .Select(p => $"`{p.Name}`")
                .ToList();

            var events = c.Parameters
                .Where(p => p.IsEventCallback && !p.Name.EndsWith("Changed", StringComparison.Ordinal))
                .Select(p => $"`{p.Name}`")
                .ToList();

            attrs.AddRange(events);

            sb.AppendLine($"| `{c.Name}` | {(slots.Count > 0 ? string.Join(" ", slots) : "—")} "
                        + $"| {(attrs.Count > 0 ? string.Join(" ", attrs) : "—")} "
                        + $"| {(binds.Count > 0 ? string.Join(" ", binds) : "—")} |");
        }

        sb.AppendLine();
        sb.AppendLine("## Components, with summaries");
        sb.AppendLine();
        foreach (var c in components.OrderBy(c => c.Name, StringComparer.Ordinal))
        {
            var summary = Truncate(c.Summary ?? c.DemoPage?.Description ?? $"The {c.Name} component.", 150);
            sb.AppendLine($"- [{c.Name}]({baseUrl}/ai/components/{Slug(c.Name)}.md): {summary}");
        }

        sb.AppendLine();
        sb.AppendLine("## Optional");
        sb.AppendLine();
        sb.AppendLine($"- [Everything in one file]({baseUrl}/llms-full.txt): all component docs concatenated. **~350 KB** — many fetchers truncate or refuse it; prefer the per-component pages.");
        sb.AppendLine("- [Repository](https://github.com/SMEDAOman/GUPBlazor): source, issues, pull requests.");
        sb.AppendLine("- [NuGet package](https://www.nuget.org/packages/GUPBlazor): release history.");

        return sb.ToString();
    }

    public static string Slug(string name)
    {
        // Normalise the legacy all-caps prefix so GUPHTMLHeader slugs as gup-html-header.
        if (name.StartsWith("GUP", StringComparison.Ordinal) && name.Length > 3 && char.IsUpper(name[3]))
        {
            name = "Gup" + name[3..];
        }

        name = name.Replace("HTML", "Html", StringComparison.Ordinal);

        var sb = new StringBuilder();
        for (var i = 0; i < name.Length; i++)
        {
            var ch = name[i];
            if (char.IsUpper(ch) && i > 0 && (!char.IsUpper(name[i - 1]) || (i + 1 < name.Length && char.IsLower(name[i + 1]))))
            {
                sb.Append('-');
            }

            sb.Append(char.ToLowerInvariant(ch));
        }

        return sb.ToString().Trim('-');
    }

    private static string Escape(string s) =>
        s.Replace("|", "\\|").Replace("\r", " ").Replace("\n", " ");

    private static string Truncate(string s, int max) =>
        s.Length <= max ? s : s[..max].TrimEnd() + "…";
}
