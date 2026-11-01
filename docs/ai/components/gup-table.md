# GupTable

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupTable.razor`
> Live demo: /demo/table-cell

Part of the Table & table cell component set — see the Table & table cell page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-table>
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Responsive` | `bool` | — | — | When true, the table collapses into stacked cards below the mobile breakpoint (each row becomes a bordered card, each cell stacks with its `Label` shown inline). Use for data tables that would otherwise overflow narrow screens. Default: false (classic table). |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Row headers key value summary

<!-- from GUPBlazorDemo/Components/Pages/.../DataDisplay.razor -->
```razor
<GupTable>
  <GupTableRow>
    <GupTableCell Type="rowheader">Applicant name</GupTableCell>
    <GupTableCell>Mohammed Al Rashdi</GupTableCell>
  </GupTableRow>
  <GupTableRow>
    <GupTableCell Type="rowheader">Civil ID</GupTableCell>
    <GupTableCell>78345612</GupTableCell>
  </GupTableRow>
  <GupTableRow>
    <GupTableCell Type="rowheader">Application date</GupTableCell>
    <GupTableCell>09 April 2026</GupTableCell>
  </GupTableRow>
  <GupTableRow>
    <GupTableCell Type="rowheader">Status</GupTableCell>
    <GupTableCell>Under review</GupTableCell>
  </GupTableRow>
  <GupTableRow>
    <GupTableCell Type="rowheader">Reference number</GupTableCell>
    <GupTableCell>GOV-2026-004412</GupTableCell>
  </GupTableRow>
</GupTable>
```

### Column headers

<!-- from GUPBlazorDemo/Components/Pages/.../DataDisplay.razor -->
```razor
<GupTable>
  <GupTableRow>
    <GupTableCell Type="header">Service</GupTableCell>
    <GupTableCell Type="header">Reference</GupTableCell>
    <GupTableCell Type="header">Date</GupTableCell>
    <GupTableCell Type="header">Status</GupTableCell>
  </GupTableRow>
  <GupTableRow>
    <GupTableCell>Business registration</GupTableCell>
    <GupTableCell>BIZ-20240101</GupTableCell>
    <GupTableCell>01 Jan 2024</GupTableCell>
    <GupTableCell>Approved</GupTableCell>
  </GupTableRow>
  <GupTableRow>
    <GupTableCell>Driving license renewal</GupTableCell>
    <GupTableCell>DRV-20240215</GupTableCell>
    <GupTableCell>15 Feb 2024</GupTableCell>
    <GupTableCell>Pending</GupTableCell>
  </GupTableRow>
  <GupTableRow>
    <GupTableCell>Passport application</GupTableCell>
    <GupTableCell>PAS-20240310</GupTableCell>
    <GupTableCell>10 Mar 2024</GupTableCell>
    <GupTableCell>Under review</GupTableCell>
  </GupTableRow>
</GupTable>
```

### Basic table

<!-- from GUPBlazorDemo/Components/Pages/.../TableCellDemo.razor -->
```razor
<GupTable>
  <GupTableRow>
    <GupTableCell Type="header">Reference</GupTableCell>
    <GupTableCell Type="header">Service</GupTableCell>
    <GupTableCell Type="header">Status</GupTableCell>
  </GupTableRow>
  <GupTableRow>
    <GupTableCell>OM-2026-4471</GupTableCell>
    <GupTableCell>Licence renewal</GupTableCell>
    <GupTableCell>Approved</GupTableCell>
  </GupTableRow>
  <GupTableRow>
    <GupTableCell>OM-2026-4472</GupTableCell>
    <GupTableCell>New registration</GupTableCell>
    <GupTableCell>Under review</GupTableCell>
  </GupTableRow>
</GupTable>
```

### Responsive

<!-- from GUPBlazorDemo/Components/Pages/.../TableCellDemo.razor -->
```razor
<GupTable Responsive="true">
  <GupTableRow>
    <GupTableCell Type="header">Reference</GupTableCell>
    <GupTableCell Type="header">Service</GupTableCell>
    <GupTableCell Type="header">Status</GupTableCell>
  </GupTableRow>
  <GupTableRow>
    <GupTableCell Label="Reference">OM-2026-4471</GupTableCell>
    <GupTableCell Label="Service">Licence renewal</GupTableCell>
    <GupTableCell Label="Status">Approved</GupTableCell>
  </GupTableRow>
  <GupTableRow>
    <GupTableCell Label="Reference">OM-2026-4472</GupTableCell>
    <GupTableCell Label="Service">New registration</GupTableCell>
    <GupTableCell Label="Status">Under review</GupTableCell>
  </GupTableRow>
</GupTable>
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

### Bound values

<!-- from GUPBlazorDemo/Components/Pages/.../ReadOnlyCascade.razor -->
```razor
<p>
    Every value below is bound to a field above. While the form is
    locked they must all stay exactly as they are — if one changes,
    the lock leaked.
</p>
<GupTable>
    <GupTableRow><GupTableCell Type="rowheader">Full name</GupTableCell><GupTableCell>@Show(_text)</GupTableCell></GupTableRow>
    <GupTableRow><GupTableCell Type="rowheader">Email</GupTableCell><GupTableCell>@Show(_email)</GupTableCell></GupTableRow>
    <GupTableRow><GupTableCell Type="rowheader">Notes</GupTableCell><GupTableCell>@Show(_notes)</GupTableCell></GupTableRow>
    <GupTableRow><GupTableCell Type="rowheader">Sector</GupTableCell><GupTableCell>@Show(_sector)</GupTableCell></GupTableRow>
    <GupTableRow><GupTableCell Type="rowheader">Agreed</GupTableCell><GupTableCell>@_agreed</GupTableCell></GupTableRow>
    <GupTableRow><GupTableCell Type="rowheader">Contact</GupTableCell><GupTableCell>@Show(_choice)</GupTableCell></GupTableRow>
    <GupTableRow><GupTableCell Type="rowheader">Inside region</GupTableCell><GupTableCell>@Show(_regionText)</GupTableCell></GupTableRow>
    <GupTableRow><GupTableCell Type="rowheader">Plain input</GupTableCell><GupTableCell>@Show(_rawText)</GupTableCell></GupTableRow>
</GupTable>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-table.md`
