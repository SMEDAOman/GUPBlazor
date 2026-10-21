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
