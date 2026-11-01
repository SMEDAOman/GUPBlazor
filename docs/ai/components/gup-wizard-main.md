# GupWizardMain

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupWizardMain.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/wizard

Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-wizard-main> — main content area between header and footer
```

## Import

```razor
@using GUPBlazor.Components
```

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Wizard main

<!-- from GUPBlazorDemo/Components/Pages/.../Wizard.razor -->
```razor
<GupWizardMain>
  <h3>Business details</h3>
  <p>Tell us about the business you are applying for.</p>
</GupWizardMain>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
