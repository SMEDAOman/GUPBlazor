# GUPWizardStackStep

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GUPWizardStackStep.razor`
> Live demo: /demo/wizard

Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes.

## Upstream mapping

```text
A single step inside a <GUPWizardStack>. Registers itself with the parent so the stepper and navigation know about it, and renders its ChildContent only when it is the active step.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Title` | `string` | `"" (empty)` | — |  |
| `Description` | `string?` | — | — |  |
| `StepLabel` | `string?` | — | — |  |
| `HideDefaultTitle` | `bool` | `false` | — |  |
| `Locked` | `bool` | `false` | — | When true, the wizard's default Continue/Submit button is disabled and `NextAsync` is blocked while this is the active step. |
| `SoftLockNext` | `bool` | `false` | — | When true, the wizard's default Continue/Submit button renders with the disabled *appearance* (greyed) but stays fully clickable, and navigation is NOT blocked — so pressing it still runs this step's `OnNext` validation, which can surface errors and cancel via `args.Cancel`. Use this instead of `Locked` for "looks disabled until the form is complete, but the user can press it to see what's missing". Ignored when `Locked` is true (a hard lock wins). |
| `NextButtonText` | `string?` | — | — | Overrides the wizard's default text for the forward (Continue/Submit) button while this step is active. |
| `HideNextIcon` | `bool` | `false` | — | When true, the forward (Continue/Submit) button renders no trailing icon while this step is active (e.g. an "Accept and Send" step that should have no arrow or tick). |
| `NextIconName` | `string?` | — | — | Overrides the forward (Continue/Submit) button's icon name while this step is active. Takes precedence over the wizard-level icon. Ignored when `HideNextIcon` is true. |
| `BackButtonText` | `string?` | — | — | Overrides the wizard's default text for the Back button while this step is active. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `OnNext` | `EventCallback<GupWizardNavArgs>` | Step-level Next handler. Fires before the wizard-level `OnNext`; set `args.Cancel = true` to abort navigation. |

> Members of `GupWizardNavArgs` are documented in [support types](/ai/types.md).

## Cascading values consumed

- Parent

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### From the ServiceStart page template

<!-- from GUPBlazorDemo/Components/Pages/.../ServiceStart.razor -->
```razor
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
```

### From the ServiceStart page template

<!-- from GUPBlazorDemo/Components/Pages/.../ServiceStart.razor -->
```razor
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
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-wizard-stack-step.md`
