# GUPWizardStack

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GUPWizardStack.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/wizard

Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes.

## Upstream mapping

```text
High-level wizard layout: wires GupHeader, GupContentHeader, GupWizardMain (with stepper) and GupWizardFooter. Steps are declared as <GUPWizardStackStep> children and shown one at a time based on CurrentStepIndex.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `ShowHeader` | `bool` | `true` | — |  |
| `NavAriaLabel` | `string` | `"Wizard Navigation Header"` | — |  |
| `ShowContentHeader` | `bool` | `true` | — |  |
| `PageTitle` | `string` | `"" (empty)` | — |  |
| `PageSubtitle` | `string?` | — | — |  |
| `ShowStepper` | `bool` | `true` | — |  |
| `StepperOpen` | `bool` | `false` | — | Initial expanded state of the collapsible stepper header. Applied once on first render; the user's own toggling wins from then on. |
| `ShowAllSteps` | `bool` | `false` | — | Read-only mode: render ALL steps' content stacked (no navigation) and wrap it in a disabled <fieldset> so every form control inside is non-editable. Pair with ShowStepper=false and ShowFooter=false for a flat, view-only form. Default off. |
| `StepLabelFormat` | `string` | `"Step {0} of {1}"` | — | Format string for the "Step N of M" progress label shown on the collapsible stepper header. `{0}` is the current step number (1-based), `{1}` is the total number of steps. Pass a translated template (e.g. an Arabic "الخطوة {0} من {1}") to localize it. |
| `StepperAppearance` | `GupDetailsContentAppearance` | `GupDetailsContentAppearance.Sink` | — |  |
| `StepperClosedIcon` | `string` | `"add-circle"` | — |  |
| `StepperOpenIcon` | `string` | `"remove-circle"` | — |  |
| `ShowFooter` | `bool` | `true` | — |  |
| `BackButtonText` | `string` | `"Back"` | — |  |
| `ContinueButtonText` | `string` | `"Continue"` | — |  |
| `CompleteButtonText` | `string` | `"Submit"` | — |  |
| `ShowBackIcon` | `bool` | `true` | — | Show the leading arrow icon on the Back button. Default: true. |
| `ShowContinueIcon` | `bool` | `true` | — | Show the trailing arrow icon on the Continue (non-final) button. Default: true. |
| `ShowCompleteIcon` | `bool` | `true` | — | Show the trailing check icon on the final Submit/Complete button. Default: true. Set false for steps like "Accept and Send" where no arrow/tick is wanted. |
| `ContinueIconName` | `string` | `"arrow-forward"` | — | Icon name for the Continue (non-final) button. Default: "arrow-forward". |
| `CompleteIconName` | `string` | `"check"` | — | Icon name for the final Submit/Complete button. Default: "check". |
| `IsLoading` | `bool` | `false` | — | When true, all footer buttons are disabled (e.g. while an async operation is in flight). Reset to false to re-enable navigation. |
| `CurrentStepIndex` | `int` | `0` | `@bind-CurrentStepIndex` |  |
| `IsRTL` | `bool` | `false` | — |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |
| `<HeaderStart>` |  |
| `<HeaderEnd>` |  |
| `<PageSummary>` |  |
| `<ErrorSummary>` | Rendered at the very top of the wizard body, above the stepper, so a validation summary stays in one place regardless of which step is active. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `CurrentStepIndexChanged` | `EventCallback<int>` |  |
| `OnStepChanged` | `EventCallback<int>` |  |
| `OnNext` | `EventCallback<GupWizardNavArgs>` |  |
| `OnBack` | `EventCallback<GupWizardNavArgs>` |  |
| `OnComplete` | `EventCallback<int>` |  |

> Members of `GupWizardNavArgs` are documented in [support types](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/types.md).

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### From the ServiceStart page template

<!-- from GUPBlazorDemo/Components/Pages/.../ServiceStart.razor -->
```razor
<GUPWizardStack @ref="_wizard"
                PageTitle="Service name"
                @bind-CurrentStepIndex="_currentStep"
                IsLoading="@_isLoading"
                OnStepChanged="HandleStepChanged"
                PageSubtitle="A brief description of the service, its requirements, or instructions for the user can go here. It can be a couple of sentences long."

               >
    <PageSummary>
        <p>Summary content goes here. It can be a few sentences long and include <strong>formatted text</strong>, links, or other elements.</p>
    </PageSummary>

    <HeaderStart>
        
        <GupTrack Direction="horizontal" Gap="2">
            <GupButton Appearance="@GupButtonAppearance.Text" Kind="@GupButtonKind.Button" Type="@GupButtonType.Button"
                       OnClick="@(() => Nav.NavigateTo("/"))">
                <IconStart><GupIcon IconName="close" Width="24" Height="24" /></IconStart>
                <ChildContent>Save &amp; exit</ChildContent>
            </GupButton>
        </GupTrack>
    </HeaderStart>

    <HeaderEnd>
        <GupTrack Direction="horizontal" HorizontalAlignment="right" Gap="2">
            <GupButton Appearance="@GupButtonAppearance.Text" Kind="@GupButtonKind.Button" Type="@GupButtonType.Button"
                       OnClick="@(() => Nav.NavigateTo("/help"))">
                <IconStart><GupIcon IconName="live-help" Width="24" Height="24" /></IconStart>
                <ChildContent><span class="header-action-label">Do you need help?</span></ChildContent>
            </GupButton>
        </GupTrack>
    </HeaderEnd>

    <ChildContent>

        <GUPWizardStackStep Title="Applicant details"
                            Description="Tell us who is applying."
                            NextButtonText="Continue to service details">
            <form>
                <GupFormSection>
                    <Title>Personal information</Title>
                    <ChildContent>
                        <GupFormList>
                            <GupInputField Name="full-name" Type="text">Full name</GupInputField>
                            <GupInputField Name="civil-id" Type="text">Civil ID</GupInputField>
                            <GupInputField Name="email" Type="email">Email</GupInputField>
                        </GupFormList>
                    </ChildContent>
                </GupFormSection>
            </form>
        </GUPWizardStackStep>

        <GUPWizardStackStep Title="Service details"
                            Description="Lock this step to disable Continue."
                            Locked="@_lockServiceDetails"
                            BackButtonText="Edit applicant"
                            OnNext="Handle1"
                            >
            <GupFormSection>
                <Title>Request</Title>
                <ChildContent>
                    <label style="display: inline-flex; align-items: center; gap: 8px; font-size: 18px; color: var(--gup-color-content-primary); margin-bottom: 16px;">
                        <input type="checkbox" @bind="_lockServiceDetails" />
                        <span>Lock this step (disables the Continue button)</span>
                    </label>
                    <GupFormList>
                        <GupInputField Name="subject" Type="text">Subject</GupInputField>
                        <GupInputField Name="reference" Type="text">Reference number</GupInputField>
                        <GupInputField Name="notes" Type="text">Additional notes</GupInputField>
                    </GupFormList>
                </ChildContent>
            </GupFormSection>
        </GUPWizardStackStep>

        <GUPWizardStackStep Title="Review"
                            Description="Toggle the option below to demo the per-step OnNext cancel flow."
                            NextButtonText="Submit"
                            OnNext="HandleReviewNext">
            <GupFormSection>
                <Title>Confirm</Title>
                <ChildContent>
                    <label style="display: inline-flex; align-items: center; gap: 8px; font-size: 18px; color: var(--gup-color-content-primary);">
                        <input type="checkbox" @bind="_blockSubmit" />
                        <span>Block the next click (step's <code>OnNext</code> will set <code>args.Cancel = true</code>)</span>
                    </label>
                </ChildContent>
            </GupFormSection>
        </GUPWizardStackStep>

        <GUPWizardStackStep Title="Done"
                            Description="Your request has been submitted."
                            NextButtonText="Finish"
                            BackButtonText="Back to review"
                            OnNext="HandleComplete">
            <GupFormSection>
                <Title>Thank you</Title>
                <ChildContent>
                    <p style="font-size: 18px; color: var(--gup-color-content-primary);">
                        Reference <strong>@_submittedReference</strong> — keep this number for your records.
                    </p>
                </ChildContent>
            </GupFormSection>
        </GUPWizardStackStep>

    </ChildContent>

</GUPWizardStack>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
