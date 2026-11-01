# GupToast

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupToast.razor`
> Live demo: /demo/toasts

Part of the Toast & toast container component set — see the Toast & toast container page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-toast severity="neutral|positive|negative|warning" close-label="..."> ChildContent is the message body. OnRemove fires when the close button is clicked.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Severity` | `string` | `"neutral"` | — |  |
| `CloseLabel` | `string` | `"Close"` | — |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `OnRemove` | `EventCallback` |  |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### From the Toasts page template

<!-- from GUPBlazorDemo/Components/Pages/.../Toasts.razor -->
```razor
<GupToast Severity="neutral">
            This is a toast message slave desk north official prevent finish tightly mean suppose attack gravity breathing production was her test finally everybody
          </GupToast>
```

### From the Toasts page template

<!-- from GUPBlazorDemo/Components/Pages/.../Toasts.razor -->
```razor
<GupToast Severity="positive">
            Your changes have been saved successfully.
          </GupToast>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-toast.md`
