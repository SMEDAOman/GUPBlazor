# GupFlag

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupFlag.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/flag

Country flags in rectangle and circle shapes.

## Upstream mapping

```text
Equivalent of <gup-flag country-name="om" shape="rectangle|circle" size="20"> Renders a country flag from the SVG set bundled under wwwroot/flags. CountryName accepts either an English country name ("Oman") or an ISO 3166-1 alpha-2 code ("om"), matched case-insensitively. An unknown value renders an empty placeholder of the same size. The browser fetches each SVG on demand and caches it, so a page only downloads the flags it actually shows.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `CountryName` | `string?` | — | — | English country name (e.g. `Oman`) or ISO 3166-1 alpha-2 code (e.g. `om`). Matching ignores case. An unrecognised value renders an empty placeholder of the same size rather than throwing. |
| `Shape` | `GupFlagShape` | `GupFlagShape.Rectangle` | — | Shape of the flag: 4:3 rectangle (default) or 1:1 circle. |
| `Size` | `int` | `20` | — | Height of the flag in pixels; the width follows from `Shape`. Default: 20. |
| `Alt` | `string?` | — | — | Alternative text for the image. Defaults to the resolved country name. Set to an empty string when the flag is decorative and the country is already named in adjacent text. |
| `BasePath` | `string` | `"_content/GUPBlazor/flags"` | — | Base path the bundled flag SVGs are served from. A shape subfolder (`4x3` or `1x1`) and `<code>.svg` are appended, so an override must point at a directory containing those subfolders. |

## Enums

### `GupFlagShape`

Aspect ratio and corner treatment of a `GupFlag`.

- `GupFlagShape.Rectangle` — 4:3 rectangle flag (default).
- `GupFlagShape.Circle` — 1:1 circle flag.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default rectangle

<!-- from GUPBlazorDemo/Components/Pages/.../Flag.razor -->
```razor
<GupTrack Direction="horizontal" Gap="3">
    <GupFlag CountryName="om" />
    <GupFlag CountryName="ae" />
    <GupFlag CountryName="sa" />
    <GupFlag CountryName="kw" />
    <GupFlag CountryName="qa" />
    <GupFlag CountryName="bh" />
</GupTrack>
```

### Circle shape

<!-- from GUPBlazorDemo/Components/Pages/.../Flag.razor -->
```razor
<GupTrack Direction="horizontal" Gap="3">
    <GupFlag CountryName="om" Shape="@GupFlagShape.Circle" Size="32" />
    <GupFlag CountryName="ch" Shape="@GupFlagShape.Circle" Size="32" />
    <GupFlag CountryName="jp" Shape="@GupFlagShape.Circle" Size="32" />
    <GupFlag CountryName="br" Shape="@GupFlagShape.Circle" Size="32" />
    <GupFlag CountryName="in" Shape="@GupFlagShape.Circle" Size="32" />
</GupTrack>
```

### Unknown country

<!-- from GUPBlazorDemo/Components/Pages/.../Flag.razor -->
```razor
<GupTrack Direction="horizontal" Gap="3">
    <GupFlag CountryName="om" Size="32" />
    <GupFlag CountryName="zz" Size="32" />
    <GupFlag CountryName="Atlantis" Size="32" />
</GupTrack>
```

### Code or country name

<!-- from GUPBlazorDemo/Components/Pages/.../Flag.razor -->
```razor
<GupTrack Direction="horizontal" Gap="4">
    <span><GupFlag CountryName="om" /> <code>"om"</code></span>
    <span><GupFlag CountryName="Oman" /> <code>"Oman"</code></span>
    <span><GupFlag CountryName="CH" /> <code>"CH"</code></span>
    <span><GupFlag CountryName="Switzerland" /> <code>"Switzerland"</code></span>
</GupTrack>
```

### Size

<!-- from GUPBlazorDemo/Components/Pages/.../Flag.razor -->
```razor
<GupTrack Direction="horizontal" Gap="3" VerticalAlignment="center">
    <GupFlag CountryName="om" Size="16" />
    <GupFlag CountryName="om" Size="24" />
    <GupFlag CountryName="om" Size="40" />
    <GupFlag CountryName="om" Size="64" />
    <GupFlag CountryName="om" Size="96" />
</GupTrack>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
