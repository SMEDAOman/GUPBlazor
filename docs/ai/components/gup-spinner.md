# GupSpinner

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupSpinner.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/spinner

Indeterminate loading indicator in several sizes.

## Upstream mapping

```text
Equivalent of <gup-spinner size="s|m|l|xl"> — accessible loading indicator. Renders the gov.om brand spinner SVG with a continuous rotation animation. Sizes: s=16px, m=24px (default), l=40px, xl=64px. Pass Pixels to override. Legacy small/medium/large values are still accepted for backward compatibility. Set LabelHidden to keep the label for screen-readers only.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Size` | `string` | `"m"` | — | Spinner size: `s`, `m` (default), `l`, or `xl`. Legacy `small`/`medium`/`large` values are also accepted. |
| `Pixels` | `int?` | — | — | Override the size with an explicit pixel value. |
| `Label` | `string` | `"Loading..."` | — | Optional label displayed below the spinner (and read by screen-readers). Default: "Loading...". |
| `Text` | `string?` | — | — | Optional visible text alongside the spinner. Suppressed when `LabelHidden` is true. |
| `LabelHidden` | `bool` | — | — | If true, the label/text is hidden visually and available only to screen-readers (matches `label-hidden`). |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Small (16px)

<!-- from GUPBlazorDemo/Components/Pages/.../Spinner.razor -->
```razor
<GupSpinner Size="small" />
```

### Medium · default (24px)

<!-- from GUPBlazorDemo/Components/Pages/.../Spinner.razor -->
```razor
<GupSpinner />
```

### Large (40px)

<!-- from GUPBlazorDemo/Components/Pages/.../Spinner.razor -->
```razor
<GupSpinner Size="large" />
```

### Inline text label

<!-- from GUPBlazorDemo/Components/Pages/.../Spinner.razor -->
```razor
<GupSpinner Text="Loading..." />
```

### Large with text · custom ARIA label

<!-- from GUPBlazorDemo/Components/Pages/.../Spinner.razor -->
```razor
<GupSpinner Size="large"
            Text="Submitting your application..."
            Label="Submitting your application, please wait" />
```

### Centered loading panel

<!-- from GUPBlazorDemo/Components/Pages/.../Spinner.razor -->
```razor
<GupSpinner Size="large" Text="Fetching data..." />
```

### On dark canvas

<!-- from GUPBlazorDemo/Components/Pages/.../Spinner.razor -->
```razor
<GupSpinner Size="large" Text="Loading..." />
```

### Inside a button

<!-- from GUPBlazorDemo/Components/Pages/.../Spinner.razor -->
```razor
<GupButton Appearance="@GupButtonAppearance.Primary" Kind="@GupButtonKind.Button">
  <ChildContent>
    <GupTrack Direction="horizontal" Gap="2" VerticalAlignment="center">
      <GupSpinner Size="small" Label="Saving" />
      <span>Saving…</span>
    </GupTrack>
  </ChildContent>
</GupButton>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
