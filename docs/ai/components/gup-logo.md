# GupLogo

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupLogo.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/logo

GupLogo in icon and horizontal lockups, with inversion for dark surfaces.

## Upstream mapping

```text
Gov.om logo — inline SVG from design-system source. Equivalent of <gup-logo appearance="icon|horizontal|vertical" inverted="disabled|enabled|custom" title="..." href="..." size="24">
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Appearance` | `string` | `"icon"` | — | Logo lockup: `icon` (default), `horizontal`, or `vertical`. |
| `Title` | `string` | `"Logo"` | — | Accessible description of the logo, also shown as a tooltip on hover. |
| `Inverted` | `string` | `"disabled"` | — | Invert the logo colors for dark backgrounds: `disabled` (default), `enabled`, or `custom`. |
| `Href` | `string?` | — | — | Optional link for the logo. When set, the logo is wrapped in an anchor. |
| `Size` | `int` | `24` | — | Height of the logo in px; width scales proportionally. Default: 24. |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Icon (default)

<!-- from GUPBlazorDemo/Components/Pages/.../Logo.razor -->
```razor
<GupLogo Size="60" />
```

### Horizontal lockup

<!-- from GUPBlazorDemo/Components/Pages/.../Logo.razor -->
```razor
<GupLogo Appearance="horizontal" Size="44" />
```

### Light (default)

<!-- from GUPBlazorDemo/Components/Pages/.../Branding.razor -->
```razor
<GupLogo Size="60" />
```

### On brand background

<!-- from GUPBlazorDemo/Components/Pages/.../Branding.razor -->
```razor
<GupLogo Size="60" />
```

### On dark background

<!-- from GUPBlazorDemo/Components/Pages/.../Branding.razor -->
```razor
<GupLogo Size="60" />
```

### Small (32px)

<!-- from GUPBlazorDemo/Components/Pages/.../Branding.razor -->
```razor
<GupLogo Size="32" />
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
