# GupBadge

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupBadge.razor`
> Live demo: /demo/badges

Status badges in the full colour range.

## Upstream mapping

```text
Equivalent of <gup-badge type="neutral|positive|negative|offline"> A small status dot used to convey state.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Type` | `GupBadgeType` | `GupBadgeType.Neutral` | — |  |
| `AriaLabel` | `string?` | — | — |  |

## Enums

### `GupBadgeType`

- `GupBadgeType.Neutral`
- `GupBadgeType.Positive`
- `GupBadgeType.Negative`
- `GupBadgeType.Offline`

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### In a summary layout

<!-- from GUPBlazorDemo/Components/Pages/.../LabelledItem.razor -->
```razor
<GupLabelledItem Label="Service">Commercial licence renewal</GupLabelledItem>
<GupLabelledItem Label="Reference">OM-2026-4471</GupLabelledItem>
<GupLabelledItem Label="Status">
  <GupBadge Type="GupBadgeType.Positive" />
  Approved
</GupLabelledItem>
```

### With status badges

<!-- from GUPBlazorDemo/Components/Pages/.../TableCellDemo.razor -->
```razor
<GupTable>
  <GupTableRow>
    <GupTableCell Type="header">Reference</GupTableCell>
    <GupTableCell Type="header">Status</GupTableCell>
  </GupTableRow>
  <GupTableRow>
    <GupTableCell>OM-2026-4471</GupTableCell>
    <GupTableCell><GupBadge Type="GupBadgeType.Positive" /> Approved</GupTableCell>
  </GupTableRow>
  <GupTableRow>
    <GupTableCell>OM-2026-4473</GupTableCell>
    <GupTableCell><GupBadge Type="GupBadgeType.Negative" /> Rejected</GupTableCell>
  </GupTableRow>
</GupTable>
```

### Toggle

<!-- from GUPBlazorDemo/Components/Pages/.../ReadOnlyCascade.razor -->
```razor
<GupTrack Direction="horizontal" Gap="3">
    <GupButton Appearance="@GupButtonAppearance.Primary" OnClick="ToggleReadOnly">
        <ChildContent>@(_readOnly ? "Unlock the form" : "Lock the form")</ChildContent>
    </GupButton>
    @* GupBadge is a status dot; the label sits beside it. *@
    <GupTrack Direction="horizontal" Gap="2" VerticalAlignment="center">
        <GupBadge Type="@(_readOnly ? GupBadgeType.Negative : GupBadgeType.Positive)"
                  AriaLabel="@(_readOnly ? "Locked" : "Editable")" />
        <span>@(_readOnly ? "Locked" : "Editable")</span>
    </GupTrack>
</GupTrack>

<p style="margin-top:16px;">
    Producers: wrap a region in <code>&lt;CascadingValue Value="flag" Name="GupReadOnly"&gt;</code>,
    or use <code>&lt;GupReadOnlyRegion ReadOnly="flag"&gt;</code>, which cascades the same
    value and additionally blocks pointer events for markup that is not built
    from these components.
</p>

<h3 style="margin-top:16px;">What to check when locked</h3>
<ul>
    <li>Typing into any text field, textarea or number field does nothing.</li>
    <li>The dropdown does not open; the checkbox and radios do not change.</li>
    <li>The file picker is gone entirely, not merely greyed out.</li>
    <li>Tabbing through the form skips the inputs instead of landing on them.</li>
    <li>No "This field is required" appears on an empty locked field.</li>
    <li>The date and password affix buttons are disabled, not just inert.</li>
</ul>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-badge.md`
