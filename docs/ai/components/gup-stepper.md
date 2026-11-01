# GupStepper

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupStepper.razor`
> Live demo: /demo/stepper

The wizard progress indicator, with stepper items in complete, current and upcoming states.

## Upstream mapping

```text
Equivalent of <gup-stepper static-mode wizard-mode continued toggle-all-displayed> Container for gup-stepper-item elements.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `ToggleAllDisplayed` | `bool` | — | — | Show a button that toggles all steps open/closed. Ignored in wizard or static mode. |
| `ShowAllLabel` | `string` | `"Show all steps"` | — | Label for the "show all" toggle button. |
| `HideAllLabel` | `string` | `"Hide all steps"` | — | Label for the "hide all" toggle button. |
| `WizardMode` | `bool` | — | — | Wizard mode — all steps open and toggle buttons hidden. |
| `StaticMode` | `bool` | — | — | Static (read-only) mode — toggle functionality is unavailable. |
| `Continued` | `bool` | — | — | Whether the stepper appears as continuing from a non-first item. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Wizard mode

<!-- from GUPBlazorDemo/Components/Pages/.../StepperDemo.razor -->
```razor
<GupStepper WizardMode="true">
  <GupStepperItem StepNumber="1" Label="Business details" StepType="complete" WizardMode="true" />
  <GupStepperItem StepNumber="2" Label="Premises" StepType="current" WizardMode="true" Open="true" />
  <GupStepperItem StepNumber="3" Label="Documents" WizardMode="true" />
  <GupStepperItem StepNumber="4" Label="Review and submit" WizardMode="true" />
</GupStepper>
```

### Static mode

<!-- from GUPBlazorDemo/Components/Pages/.../StepperDemo.razor -->
```razor
<GupStepper StaticMode="true">
  <GupStepperItem StepNumber="1" Label="Submitted" StepType="complete" StaticMode="true" />
  <GupStepperItem StepNumber="2" Label="Under review" StepType="current" StaticMode="true" />
  <GupStepperItem StepNumber="3" Label="Decision" StaticMode="true" />
</GupStepper>
```

### Static mode all step types

<!-- from GUPBlazorDemo/Components/Pages/.../Feedback.razor -->
```razor
<GupStepper StaticMode="true">
  <GupStepperItem StepNumber="1" StepType="done">
    <LabelContent>Personal details</LabelContent>
  </GupStepperItem>
  <GupStepperItem StepNumber="2" StepType="done">
    <LabelContent>Contact information</LabelContent>
  </GupStepperItem>
  <GupStepperItem StepNumber="3" StepType="selected">
    <LabelContent>Document upload</LabelContent>
  </GupStepperItem>
  <GupStepperItem StepNumber="4" StepType="default">
    <LabelContent>Review &amp; submit</LabelContent>
  </GupStepperItem>
  <GupStepperItem StepNumber="5" StepType="default">
    <LabelContent>Confirmation</LabelContent>
  </GupStepperItem>
</GupStepper>
```

### Step types close up

<!-- from GUPBlazorDemo/Components/Pages/.../Feedback.razor -->
```razor
<GupTrack Direction="vertical" Gap="5">
  <div>
    <div class="demo-card-label" style="margin-bottom:8px;">done</div>
    <GupStepper StaticMode="true">
      <GupStepperItem StepNumber="1" StepType="done">
        <LabelContent>Completed step</LabelContent>
      </GupStepperItem>
    </GupStepper>
  </div>
  <div>
    <div class="demo-card-label" style="margin-bottom:8px;">selected</div>
    <GupStepper StaticMode="true">
      <GupStepperItem StepNumber="2" StepType="selected">
        <LabelContent>Current step</LabelContent>
      </GupStepperItem>
    </GupStepper>
  </div>
  <div>
    <div class="demo-card-label" style="margin-bottom:8px;">default</div>
    <GupStepper StaticMode="true">
      <GupStepperItem StepNumber="3" StepType="default">
        <LabelContent>Upcoming step</LabelContent>
      </GupStepperItem>
    </GupStepper>
  </div>
</GupTrack>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-stepper.md`
