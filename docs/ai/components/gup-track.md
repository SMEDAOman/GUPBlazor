# GupTrack

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupTrack.razor`
> Live demo: /demo/track

GupTrack — the spacing primitive used to lay out rows and columns on the design system scale.

## Upstream mapping

```text
Equivalent of <gup-track direction="horizontal|vertical" gap="N" horizontal-alignment="..." vertical-alignment="..." items-equal is-multiline> Gap is in multiples of --unit (4px), so gap=7 → 28px.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Gap` | `int` | `2` | — |  |
| `Direction` | `string` | `"horizontal"` | — |  |
| `HorizontalAlignment` | `string` | `"normal"` | — |  |
| `VerticalAlignment` | `string` | `"normal"` | — |  |
| `ItemsEqual` | `bool` | — | — | All items in a row have the same width (equivalent of flex: 1 on children). |
| `IsMultiline` | `bool` | — | — | Allow items to wrap onto multiple lines (equivalent of flex-wrap). |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Gap gap

<!-- from GUPBlazorDemo/Components/Pages/.../Track.razor -->
```razor
<GupTrack Gap="@gap">
  <GupBadgeChip>One</GupBadgeChip>
  <GupBadgeChip>Two</GupBadgeChip>
  <GupBadgeChip>Three</GupBadgeChip>
</GupTrack>
```

### Horizontal (default)

<!-- from GUPBlazorDemo/Components/Pages/.../Track.razor -->
```razor
<GupTrack Gap="3">
  <GupButton Appearance="GupButtonAppearance.Secondary">Back</GupButton>
  <GupButton Appearance="GupButtonAppearance.Primary">Continue</GupButton>
</GupTrack>
```

### Vertical

<!-- from GUPBlazorDemo/Components/Pages/.../Track.razor -->
```razor
<GupTrack Gap="3" Direction="vertical">
  <GupButton Appearance="GupButtonAppearance.Secondary">Back</GupButton>
  <GupButton Appearance="GupButtonAppearance.Primary">Continue</GupButton>
</GupTrack>
```

### Horizontal: end

<!-- from GUPBlazorDemo/Components/Pages/.../Track.razor -->
```razor
<GupTrack Gap="3" HorizontalAlignment="end">
  <GupButton Appearance="GupButtonAppearance.Text">Cancel</GupButton>
  <GupButton Appearance="GupButtonAppearance.Primary">Submit</GupButton>
</GupTrack>
```

### Horizontal: space-between

<!-- from GUPBlazorDemo/Components/Pages/.../Track.razor -->
```razor
<GupTrack Gap="3" HorizontalAlignment="space-between">
  <GupButton Appearance="GupButtonAppearance.Secondary">Back</GupButton>
  <GupButton Appearance="GupButtonAppearance.Primary">Continue</GupButton>
</GupTrack>
```

### Equal items

<!-- from GUPBlazorDemo/Components/Pages/.../Track.razor -->
```razor
<GupTrack Gap="3" ItemsEqual="true">
  <GupButton Appearance="GupButtonAppearance.Secondary">One</GupButton>
  <GupButton Appearance="GupButtonAppearance.Secondary">Two</GupButton>
  <GupButton Appearance="GupButtonAppearance.Secondary">Three</GupButton>
</GupTrack>
```

### Two way binding bind open

<!-- from GUPBlazorDemo/Components/Pages/.../Accordion.razor -->
```razor
<GupTrack Direction="horizontal" Gap="2">
    <GupButton Appearance="@GupButtonAppearance.Secondary"
               Kind="@GupButtonKind.Button"
               OnClick="@(() => _bindOpen = !_bindOpen)">
        <ChildContent>Toggle externally</ChildContent>
    </GupButton>
</GupTrack>

<div style="margin-top: 16px;">
    <GupAccordion>
        <GupAccordionItem @bind-Open="_bindOpen">
            <LabelContent>Bound accordion item</LabelContent>
            <ChildContent>The Open state is bound to a parent property — the button above can toggle it too.</ChildContent>
        </GupAccordionItem>
    </GupAccordion>
</div>

<p data-testid="bind-output" style="margin-top: 12px;">
    Bound value: <strong>@(_bindOpen ? "open" : "closed")</strong>
</p>
```

### Link variants

<!-- from GUPBlazorDemo/Components/Pages/.../DataDisplay.razor -->
```razor
<GupTrack Direction="vertical" Gap="4">
  <div><GupLink Href="#">Default link</GupLink></div>
  <div><GupLink Href="#">Visit the Gov.om portal for a full list of available e-services</GupLink></div>
  <div style="font-size: 14px;"><GupLink Href="#">Smaller context link</GupLink></div>
</GupTrack>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-track.md`
