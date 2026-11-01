# GupStepperItem

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupStepperItem.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/stepper

Part of the Stepper component set — see the Stepper page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-stepper-item step-number="1" step-type="default|done|selected|and" open wizard-mode static-mode> Named slot: LabelContent (or the plain-text Label attribute) Default slot: ChildContent (collapsible content of the step)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Label` | `string` | `"" (empty)` | — | The label of the step (used when the Label slot is not provided). |
| `StepNumber` | `string` | `"" (empty)` | — | The number of the step. |
| `StepType` | `string` | `"default"` | — | Type of the step marker: `default`, `done`, `selected`, or `and`. |
| `LabelAnd` | `string` | `"and"` | — | Translatable label for the "and" indicator. |
| `WizardMode` | `bool` | — | — | Whether the stepper item is in wizard mode. |
| `StaticMode` | `bool` | — | — | Whether the step is static and not interactive (auto-set when inside a static-mode gup-stepper). |
| `Open` | `bool` | — | — | Whether the step is open. |
| `LabelShow` | `string` | `"Show"` | — | Translatable label for the accordion "Show" indicator. |
| `LabelHide` | `string` | `"Hide"` | — | Translatable label for the accordion "Hide" indicator. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<LabelContent>` | The label content slot. Takes precedence over the Label attribute. |
| `<ChildContent>` | The collapsible content of the step. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

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

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
