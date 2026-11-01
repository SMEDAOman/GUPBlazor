# GupWizardFooter

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupWizardFooter.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/wizard

Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-wizard-footer nav-aria-label="..."> Slots: Start (left/back button), End (right/forward button)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `NavAriaLabel` | `string?` | — | — | Accessible label for the footer navigation region (matches `nav-aria-label`). |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<Start>` |  |
| `<End>` |  |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Wizard footer

<!-- from GUPBlazorDemo/Components/Pages/.../Wizard.razor -->
```razor
<GupWizardFooter>
  <Start>
    <GupButton Appearance="GupButtonAppearance.Secondary">
      <IconStart><GupIcon IconName="arrow-back" Width="20" Height="20" /></IconStart>
      <ChildContent>Back</ChildContent>
    </GupButton>
  </Start>
  <End>
    <GupButton Appearance="GupButtonAppearance.Primary">
      <ChildContent>Continue</ChildContent>
      <IconEnd><GupIcon IconName="arrow-forward" Width="20" Height="20" /></IconEnd>
    </GupButton>
  </End>
</GupWizardFooter>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
