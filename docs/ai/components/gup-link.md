# GupLink

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupLink.razor`
> Live demo: /demo/buttons

Part of the Button component set — see the Button page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-link kind="link|button" size="s|m|l" severity="primary|secondary|danger" href="..." disabled open-in-new-tab> Default slot: ChildContent (the link label) Events: OnClick (fires when a kind="button" link is clicked — matches gup-click)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Kind` | `string` | `"link"` | — | Whether the link renders as an anchor (default) or an HTML button. |
| `Size` | `string` | `"m"` | — | Size of the link: `s`, `m` (default), or `l`. |
| `Severity` | `string` | `"primary"` | — | Visual severity: `primary` (default), `secondary`, or `danger`. |
| `Href` | `string` | `"#"` | — | Target URL. Only relevant when `Kind` is `link`. |
| `Target` | `string` | `"" (empty)` | — | Explicit anchor target. Overrides `OpenInNewTab` if set. |
| `OpenInNewTab` | `bool` | — | — | Open the URL in a new tab. Only applicable when `Kind` is `link`. |
| `Disabled` | `bool` | — | — | Disable the link. Only relevant when `Kind` is `button`. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `OnClick` | `EventCallback<MouseEventArgs>` | Fires when a `kind="button"` link is clicked (matches the `gup-click` event). |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Link variants

<!-- from GUPBlazorDemo/Components/Pages/.../DataDisplay.razor -->
```razor
<GupTrack Direction="vertical" Gap="4">
  <div><GupLink Href="#">Default link</GupLink></div>
  <div><GupLink Href="#">Visit the Gov.om portal for a full list of available e-services</GupLink></div>
  <div style="font-size: 14px;"><GupLink Href="#">Smaller context link</GupLink></div>
</GupTrack>
```

### Rich text with lists

<!-- from GUPBlazorDemo/Components/Pages/.../DataDisplay.razor -->
```razor
<GupRichText>
  <p>These services are available to Omani nationals and residents:</p>
  <ol>
    <li>Visa and residency permits</li>
    <li>Business licensing</li>
    <li>Civil registration</li>
  </ol>
  <p>For more information visit <GupLink Href="https://gov.om/">gov.om</GupLink>.</p>
</GupRichText>
```

### With action slot childcontent

<!-- from GUPBlazorDemo/Components/Pages/.../Tooltip.razor -->
```razor
<GupTooltip Title="Did you know?"
            Hint="You can put any content here.">
    <Trigger>
        <GupButton Kind="@GupButtonKind.Button">
            <ChildContent>Click for details</ChildContent>
        </GupButton>
    </Trigger>
    <ChildContent>
        <GupLink Href="https://www.gov.om" Target="_blank">Learn more →</GupLink>
    </ChildContent>
</GupTooltip>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-link.md`
