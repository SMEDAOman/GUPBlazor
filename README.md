# Blazor GUP Components

An initiative by the **SMEs Development Authority (Oman)** to develop and maintain a **Blazor-native implementation of GUP (Government Unified Platform) components**, matching the official [gov.om design system](https://github.com/Gov-om/design-system).

Includes **66 native Blazor components** with WCAG 2.2 AA accessibility, full RTL support, and Arabic localization.

---

## 📦 Installation

Install the package via NuGet:

**Package Manager Console**
```powershell
Install-Package GUPBlazor
```

**.NET CLI**
```bash
dotnet add package GUPBlazor
```

**PackageReference** (add to your `.csproj`)
```xml
<PackageReference Include="GUPBlazor" Version="0.3.3" />
```

Or browse the package directly at:  
[nuget.org/packages/GUPBlazor](https://www.nuget.org/packages/GUPBlazor)

---

## 🚀 Quick Setup

### 1. Register Services
In your `Program.cs`, register GUPBlazor services:

```csharp
builder.Services.AddGUPBlazor();
```

### 2. Add Required Styles & Scripts
In your `App.razor` (or `_Host.cshtml` for Blazor Server), add `<GUPHTMLHeader />` inside `<head>` and `<GUPHTMLFooter />` before the closing `</body>`:

```razor
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <title>Gov.om App</title>

    @* GUPBlazor styles, design tokens, and fonts *@
    <GUPHTMLHeader />

    <HeadOutlet />
</head>
<body>
    <Routes />
    <script src="_framework/blazor.web.js"></script>

    @* GUPBlazor scripts *@
    <GUPHTMLFooter />
</body>
</html>
```

### 3. Import Namespaces
In your `_Imports.razor`:

```razor
@using GUPBlazor.Components
@using GUPBlazor.Services
```

---

## 💡 Usage Example

```razor
<GupContentHeader PageTitle="Apply for an SME Licence">
    <PageSummary>Complete the form below to submit your application.</PageSummary>
</GupContentHeader>

<GupFormSection>
    <GupInputField Name="company" Type="text" Required="true" @bind-Value="_company">
        <ChildContent>Company name</ChildContent>
        <Hint>As registered with the Ministry of Commerce, Industry and Investment Promotion.</Hint>
    </GupInputField>

    <GupDropdownField Name="sector" Required="true" @bind-Value="_sector">
        <Label>Sector</Label>
        <ChildContent>
            <GupDropdownMenu AriaLabel="Sector">
                <GupDropdownMenuItem Label="Manufacturing" Value="mfg" />
                <GupDropdownMenuItem Label="Logistics" Value="logistics" />
                <GupDropdownMenuItem Label="Information Technology" Value="it" />
            </GupDropdownMenu>
        </ChildContent>
    </GupDropdownField>
</GupFormSection>

<GupButton Appearance="@GupButtonAppearance.Primary" OnClick="Submit">
    <ChildContent>Submit Application</ChildContent>
</GupButton>

@code {
    private string? _company;
    private string? _sector;

    private void Submit()
    {
        // Handle submission logic
    }
}
```

---

## 🖥️ Live Demo & Documentation

You can run the interactive documentation and component catalog locally or via Docker:

### Run with Docker
```bash
docker run -d -p 8085:8080 smeitoman/riyada-design-system:latest
```
Then navigate to [http://localhost:8085](http://localhost:8085).

### Run Locally with .NET CLI
```bash
dotnet run --project GUPBlazorDemo/GUPBlazorDemo.csproj
```

---

## 🤖 AI / LLM-friendly reference

The demo is a Blazor **interactive server** app, so a plain web fetch of a demo page returns
the prerender — sidebar chrome and rendered components, but **no code**, because "Show code"
only appears once the SignalR circuit connects. Agents never get that far.

So the same sources are also published as plain markdown, which any AI can fetch directly:

| URL | What it is |
|---|---|
| `/docs` | **The entry point.** What the library is, the rules that stop an AI inventing parameter names, a worked example, and a link per component. `/reference` and `/llms.txt` serve the same file; `/llms.txt` exists because crawlers look for it by [convention](https://llmstxt.org). |
| `/llms-full.txt` | Every component in one file — one fetch for the whole API surface. |
| `/ai/index.md` | Component index with summaries and demo links. |
| `/ai/components/<name>.md` | Per component: parameters, defaults, bindable props, slots, events, enums, cascading values, and real examples. |
| `/ai/getting-started.md` | Install, register, wire up, first page. |
| `/ai/conventions.md` | The rules a signature doesn't show — slots vs attributes, binding, RTL, read-only cascade. |
| `/ai/design-tokens.md` | Every CSS custom property, read from `gup.css`. |

The same files are committed under [`docs/`](docs/), so they are fetchable from GitHub
without anything running:

```
https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/llms.txt
https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-button.md
```

### Point an AI at it

Name `/docs` explicitly. Discovery hints exist — a `<link rel="alternate">` in every
page's `<head>`, a `Link` response header naming that page's own component doc, and
`robots.txt` — but fetchers are not obliged to follow them, and in testing most did not.
One word in the prompt is what works reliably:

> Read gupdesign.sme.gov.om/docs and use GUPBlazor to build an SME licence application
> form: company name, sector, contact email and a file upload for the trade licence.

> Read gupdesign.sme.gov.om/docs, then build a three-step wizard for a grant application
> using GUPBlazor.

A single fetch of `/docs` is enough: it carries the conventions and a worked form inline,
so an assistant that cannot follow links still gets the rules rather than guessing.

Working in a repo that already references the package, no URL needed:

> This project uses GUPBlazor. Add a review step to the application form, matching how the
> other pages compose their fields.

If an AI starts guessing parameter names or writing `Hint="..."` as an attribute, it has not
read the reference — tell it to fetch `/docs` from the site and try again.

### Running it locally

The endpoints work against a local run with no extra setup:

```bash
dotnet run --project GUPBlazorDemo
# then: http://localhost:5043/docs
#       http://localhost:5043/ai/index.md
#       http://localhost:5043/ai/components/gup-button.md
```

Internal links are **root-relative** (`/ai/index.md`), so the same committed files resolve
correctly on `localhost`, in a container, and on `raw.githubusercontent.com` — no host is
baked in. Point an AI at your local run the same way you would at production:

> Use the GUPBlazor design system at http://localhost:5043 to build an SME licence form.

This only works for an AI running on your machine (Claude Code, Copilot, an IDE agent).
Browser chats fetch from their own servers and cannot reach `localhost`.

### Regenerating

The docs are generated from the component sources, the compiler's XML docs, `DemoNav.cs` and
the demo pages' own `<DemoExample>` markup — so the examples are the markup that really
renders, and nothing is hand-maintained:

```bash
dotnet build GUPBlazor -c Release    # generates GUPBlazor.xml
dotnet run --project tools/AiDocsGen
```

Build the library first: the generator reads its XML docs for the enum and type summaries,
and warns if they are missing rather than quietly dropping them.

Run it after adding a component or changing a parameter. The Docker build runs it
automatically, so a container image always serves a matching reference.

Pass `--base-url https://your-host` only if you need absolute links (for a published site
where something will rewrite or syndicate the markdown). Don't commit the result — absolute
URLs pin the files to one host, which is what the relative default avoids.

---

## 🧩 Available Components (66)

- **Layout & Structure** — `GupHeader`, `GupContentHeader`, `GupFormSection`, `GupTrack`, `GupDivider`, `GupSkipLink`
- **Forms & Inputs** — `GupInputField`, `GupTextarea`, `GupDropdownField`, `GupDropdownMenu`, `GupDropdownMenuItem`, `GupCheckbox`, `GupRadioButton`, `GupRadioButtonGroup`, `GupToggle`, `GupFileUpload`, `GupFileItem`, `GupSearch`, `GupFormList`
- **Navigation** — `GupBreadcrumbs`, `GupBreadcrumbsItem`, `GupTabs`, `GupTab`, `GupTabPanel`, `GupTabsNavigation`, `GupPagination`, `GupLink`, `GupStepper`, `GupStepperItem`
- **Wizards & Steppers** — `GUPWizardStack`, `GUPWizardStackStep`, `GupWizard`, `GupWizardMain`, `GupWizardFooter`
- **Data Display** — `GupTable`, `GupTableRow`, `GupTableCell`, `GupDataTable`, `GupDataSheet`, `GupLabelledItem`, `GupRichText`, `GupImage`, `GupAvatar`, `GupFlag`, `GupLogo`, `GupIcon`
- **Feedback & Overlays** — `GupCallout`, `GupBanner`, `GupToast`, `GupToastContainer`, `GupDialog`, `GupFlyout`, `GupTooltip`, `GupSpinner`, `GupPageStatus`, `GupBadge`, `GupBadgeChip`, `GupFilterChip`, `GupFilterChipWrapper`
- **Disclosure** — `GupAccordion`, `GupAccordionItem`, `GupAccordionItemAction`, `GupDetails`
- **Actions & Accessibility** — `GupButton`, `GupButtonGroup`, `GupScreenReaderText`

---

## ♿ Accessibility & RTL

- **WCAG 2.2 AA Compliance**: Semantic HTML, ARIA attributes, keyboard navigation, and screen-reader utilities (`GupScreenReaderText`, `GupSkipLink`).
- **Right-to-Left (RTL) & Arabic**: All styles utilize CSS logical properties (`margin-inline`, `padding-inline`, `inset-inline-start`, etc.), rendering right-to-left automatically when `dir="rtl"` is set on `<html>` or any container.

---

## 🛠️ Project Initiation & Maintenance

This project was **initiated and is actively maintained by Caesar Moussalli** as part of the SMEs Development Authority efforts to modernize and standardize UI development using Blazor.

Developed and maintained by the **SMEDA IT Development Team**, SMEs Development Authority (Oman).

---

## 🤝 Contributing

Contributions are welcome! You can contribute by:
- Reporting bugs and requesting features in GitHub Issues
- Submitting pull requests adhering to the gov.om design guidelines
- Enhancing documentation and accessibility test coverage

---

## 📌 Acknowledgments & Credits

- Inspired by the official Angular [Gov-om Design System](https://github.com/Gov-om/design-system) and [ekateriinal/gup-components-angular](https://github.com/ekateriinal/gup-components-angular)
- Flag artwork provided by [flag-icons](https://github.com/lipis/flag-icons) (MIT)
