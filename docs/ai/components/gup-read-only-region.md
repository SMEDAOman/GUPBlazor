# GupReadOnlyRegion

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupReadOnlyRegion.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/read-only-cascade

Part of the Read-only cascade component set — see the Read-only cascade page for how it composes.

## Upstream mapping

```text
Marks a region as read-only. Does two things: 1. Cascades GupReadOnly, which the GUP field components honour natively (real disabled/readonly attributes, so keyboard and screen readers agree). 2. Blocks pointer interaction on the region itself, which catches bespoke markup a page hand-rolls outside the component library. The cascade is the real fix; the pointer block is the safety net.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `ReadOnly` | `bool` | — | — |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Gupreadonlyregion

<!-- from GUPBlazorDemo/Components/Pages/.../ReadOnlyCascade.razor -->
```razor
<p>
    Same cascade, plus <code>pointer-events:none</code> and
    <code>aria-disabled</code> on the wrapper — the safety net for
    hand-rolled markup. The raw input below is not a GUP component, so
    only the region blocks it.
</p>
<GupReadOnlyRegion ReadOnly="_readOnly">
    <GupFormList>
        <GupInputField Name="ro-region-field" Type="text" @bind-Value="_regionText">Inside the region</GupInputField>
    </GupFormList>
    <label style="display:block; margin-top:12px;">
        Plain HTML input (not a GUP component)
        <input type="text" @bind="_rawText" style="display:block; margin-top:4px; padding:8px;" />
    </label>
</GupReadOnlyRegion>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
