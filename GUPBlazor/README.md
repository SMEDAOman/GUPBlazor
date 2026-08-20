# GUPBlazor

A Blazor implementation of the **GUP (Government Unified Platform)** design system, by the SMEs Development Authority (Oman).

66 native Blazor components matching the [gov.om design system](https://github.com/Gov-om/design-system), with accessibility, RTL and Arabic localization support built in.

## Installation

```
dotnet add package GUPBlazor
```

### 1. Register services

In `Program.cs`:

```csharp
builder.Services.AddGUPBlazor();
```

### 2. Add styles and scripts

In `App.razor` (or `_Host.cshtml` for Blazor Server), add `<GUPHTMLHeader />` inside `<head>` and `<GUPHTMLFooter />` before the closing `</body>`:

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

### 3. Import the namespace

In `_Imports.razor`:

```razor
@using GUPBlazor.Components
@using GUPBlazor.Services
```

## Usage

```razor
<GupContentHeader PageTitle="Apply for a licence">
    <PageSummary>Complete the form below to submit your application.</PageSummary>
</GupContentHeader>

<GupFormSection>
    <GupInputField Name="company" Type="text" Required="true" @bind-Value="_company">
        <ChildContent>Company name</ChildContent>
        <Hint>As registered with the Ministry of Commerce.</Hint>
    </GupInputField>

    <GupDropdownField Name="sector" Required="true" @bind-Value="_sector">
        <Label>Sector</Label>
        <ChildContent>
            <GupDropdownMenu AriaLabel="Sector">
                <GupDropdownMenuItem Label="Manufacturing" Value="mfg" />
                <GupDropdownMenuItem Label="Services" Value="svc" />
            </GupDropdownMenu>
        </ChildContent>
    </GupDropdownField>
</GupFormSection>

<GupButton Appearance="@GupButtonAppearance.Primary" OnClick="Submit">
    <ChildContent>Submit application</ChildContent>
</GupButton>
```

## Components

**Layout & structure** — `GupHeader`, `GupContentHeader`, `GupFormSection`, `GupTrack`, `GupDivider`, `GupSkipLink`

**Forms** — `GupInputField`, `GupTextarea`, `GupDropdownField`, `GupDropdownMenu`, `GupDropdownMenuItem`, `GupCheckbox`, `GupRadioButton`, `GupRadioButtonGroup`, `GupToggle`, `GupFileUpload`, `GupFileItem`, `GupSearch`, `GupFormList`

**Navigation** — `GupBreadcrumbs`, `GupBreadcrumbsItem`, `GupTabs`, `GupTab`, `GupTabPanel`, `GupTabsNavigation`, `GupPagination`, `GupLink`, `GupStepper`, `GupStepperItem`

**Wizards** — `GUPWizardStack`, `GUPWizardStackStep`, `GupWizard`, `GupWizardMain`, `GupWizardFooter`

**Data display** — `GupTable`, `GupTableRow`, `GupTableCell`, `GupDataTable`, `GupDataSheet`, `GupLabelledItem`, `GupRichText`, `GupImage`, `GupAvatar`, `GupFlag`, `GupLogo`, `GupIcon`

**Feedback & status** — `GupCallout`, `GupBanner`, `GupToast`, `GupToastContainer`, `GupDialog`, `GupFlyout`, `GupTooltip`, `GupSpinner`, `GupPageStatus`, `GupBadge`, `GupBadgeChip`, `GupFilterChip`, `GupFilterChipWrapper`

**Disclosure** — `GupAccordion`, `GupAccordionItem`, `GupAccordionItemAction`, `GupDetails`

**Buttons & accessibility** — `GupButton`, `GupButtonGroup`, `GupScreenReaderText`

## Accessibility

Components follow the gov.om accessibility guidance: semantic markup, ARIA attributes, keyboard support, and screen-reader-only text via `GupScreenReaderText`. `GupSkipLink` provides the WCAG 2.4.1 (Bypass Blocks) skip-to-content link.

## Localization & RTL

Styles use CSS logical properties throughout, so components lay out correctly in right-to-left locales. Set `dir="rtl"` on the document for Arabic.

## Requirements

- .NET 10.0 or later
- Blazor Server or Blazor Web App

## Credits

Flag artwork is from [flag-icons](https://github.com/lipis/flag-icons) (MIT). The bundled licence ships at `_content/GUPBlazor/flags/LICENSE.txt`.

Developed and maintained by the SMEDA IT Development Team, SMEs Development Authority (Oman).

## Links

- [Source & issues](https://github.com/SMEDAOman/GUPBlazor)
- [Angular design system](https://github.com/Gov-om/design-system)
