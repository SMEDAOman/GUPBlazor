# GupDetails

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupDetails.razor`
> Live demo: /demo/details

Single disclosure with quote, sink and none appearances.

## Upstream mapping

```text
Equivalent of <gup-details open content-appearance="quote|sink|none" closed-icon="..." open-icon="..." icon-hidden toggle-button-title="..." close-button-label="..."> A disclosure element. Click on the button, and hidden content will be revealed. Do not stack. Two-way binding: @bind-Open Events: OnToggle (new open state) Slots: LabelContent (named "label"), ChildContent (default — collapsible content)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Open` | `bool` | — | `@bind-Open` | Whether the content is expanded. |
| `ContentAppearance` | `GupDetailsContentAppearance` | `GupDetailsContentAppearance.Quote` | — | Whether the content is styled as a quote, a sink, or none. |
| `ClosedIcon` | `string` | `"keyboard-arrow-down"` | — | The icon to use when the content is closed. |
| `OpenIcon` | `string` | `"keyboard-arrow-up"` | — | The icon to use when the content is open. |
| `ToggleButtonTitle` | `string?` | — | — | A tooltip appearing when hovering on the toggle button. |
| `IconHidden` | `bool` | — | — | Hide the disclosure icon next to the label. |
| `CloseButtonLabel` | `string` | `"Close"` | — | Label/tooltip for the close button (sink appearance only). |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<LabelContent>` |  |
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `OpenChanged` | `EventCallback<bool>` | Two-way binding callback for Open. |
| `OnToggle` | `EventCallback<bool>` | Fires whenever the disclosure is toggled by the user. Argument is the new open state. |

## Enums

### `GupDetailsContentAppearance`

- `GupDetailsContentAppearance.Quote`
- `GupDetailsContentAppearance.Sink`
- `GupDetailsContentAppearance.None`

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Quote (default)

<!-- from GUPBlazorDemo/Components/Pages/.../Details.razor -->
```razor
<GupDetails Open="true" ContentAppearance="@GupDetailsContentAppearance.Quote">
    <LabelContent>Quote appearance</LabelContent>
    <ChildContent>It is a long established fact that a reader will be distracted by the readable
        content of a page when looking at its layout.</ChildContent>
</GupDetails>
```

### Sink

<!-- from GUPBlazorDemo/Components/Pages/.../Details.razor -->
```razor
<GupDetails Open="true" ContentAppearance="@GupDetailsContentAppearance.Sink">
    <LabelContent>Sink appearance</LabelContent>
    <ChildContent>It is a long established fact that a reader will be distracted by the readable
        content of a page when looking at its layout.</ChildContent>
</GupDetails>
```

### None

<!-- from GUPBlazorDemo/Components/Pages/.../Details.razor -->
```razor
<GupDetails Open="true" ContentAppearance="@GupDetailsContentAppearance.None">
    <LabelContent>No decoration</LabelContent>
    <ChildContent>It is a long established fact that a reader will be distracted by the readable
        content of a page when looking at its layout.</ChildContent>
</GupDetails>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-details.md`
