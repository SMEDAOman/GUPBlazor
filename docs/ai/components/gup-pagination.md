# GupPagination

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupPagination.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/pagination

Page controls with previous/next and page-number buttons.

## Upstream mapping

```text
Equivalent of <gup-pagination kind="numbered|directional" total-pages="..." current-page="..."> Page navigation control with two layouts: - Numbered    → page-number buttons with prev/next text buttons - Directional → two large prev/next links (used as a chrome-less prev/next pair) Two-way binding: @bind-CurrentPage, @bind-Kind, @bind-TotalPages Events: OnPageChange (fires with the new page number — both before and after binding update)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `TotalPages` | `int` | `10` | `@bind-TotalPages` | Total number of pages. |
| `CurrentPage` | `int` | `1` | `@bind-CurrentPage` | Currently active page (1-based). |
| `Kind` | `GupPaginationKind` | `GupPaginationKind.Numbered` | `@bind-Kind` | Layout variant — Numbered (default) or Directional. |
| `PrevLabel` | `string` | `"Previous"` | — | Label for the "Previous" button/link. |
| `PrevTitle` | `string` | `"" (empty)` | — | Title shown beneath the "Previous" label (Directional kind). |
| `PrevLink` | `string` | `"" (empty)` | — | Href for the "Previous" link (Directional kind). |
| `NextLabel` | `string` | `"Next"` | — | Label for the "Next" button/link. |
| `NextTitle` | `string` | `"" (empty)` | — | Title shown beneath the "Next" label (Directional kind). |
| `NextLink` | `string` | `"" (empty)` | — | Href for the "Next" link (Directional kind). |
| `AriaLabel` | `string` | `"Pagination"` | — | Accessible label for the surrounding <nav> element. |

## Events

| Event | Type | Description |
|---|---|---|
| `TotalPagesChanged` | `EventCallback<int>` |  |
| `CurrentPageChanged` | `EventCallback<int>` |  |
| `KindChanged` | `EventCallback<GupPaginationKind>` |  |
| `OnPageChange` | `EventCallback<int>` | Fires when the active page changes — receives the new page number. |
| `OnPrevClick` | `EventCallback<MouseEventArgs>` | Fires when the directional "Previous" link is clicked. |
| `OnNextClick` | `EventCallback<MouseEventArgs>` | Fires when the directional "Next" link is clicked. |

## Enums

### `GupPaginationKind`

Pagination layout variant. Mirrors the `kind` attribute on `<gup-pagination>`.

- `GupPaginationKind.Numbered` — Numbered pages with previous/next text buttons (default).
- `GupPaginationKind.Directional` — Two large prev/next links (no page numbers) — used for guided flows.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Numbered default

<!-- from GUPBlazorDemo/Components/Pages/.../Pagination.razor -->
```razor
<GupPagination TotalPages="10" CurrentPage="3" />
```

### Two way binding bind currentpage

<!-- from GUPBlazorDemo/Components/Pages/.../Pagination.razor -->
```razor
<GupPagination TotalPages="25"
               @bind-CurrentPage="_boundPage"
               OnPageChange="HandlePageChange" />

<div style="display:flex; gap:8px; flex-wrap:wrap; align-items:center; justify-content:center;">
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundPage = 1)">
        <ChildContent>Jump to first</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundPage = 13)">
        <ChildContent>Jump to middle</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundPage = 25)">
        <ChildContent>Jump to last</ChildContent>
    </GupButton>
</div>

<p data-testid="bind-output" style="margin:0; text-align:center;">
    Bound page: <strong>@_boundPage</strong> &nbsp;·&nbsp;
    OnPageChange fired: <strong>@_pageChangeCount</strong> times
</p>
```

### Directional previous next

<!-- from GUPBlazorDemo/Components/Pages/.../Pagination.razor -->
```razor
<GupPagination Kind="GupPaginationKind.Directional"
               PrevLabel="Previous"
               PrevTitle="Rub your eyes and purify your heart – and prize above all else in the world those who love you and who wish you well"
               PrevLink="#prev"
               NextLabel="Next"
               NextTitle="But Art is a punitive sentence, not a birthright"
               NextLink="#next" />
```

### Directional previous only

<!-- from GUPBlazorDemo/Components/Pages/.../Pagination.razor -->
```razor
<GupPagination Kind="GupPaginationKind.Directional"
               PrevLabel="Previous"
               PrevTitle="Rub your eyes and purify your heart – and prize above all else in the world those who love you and who wish you well"
               PrevLink="#prev" />
```

### Directional next only

<!-- from GUPBlazorDemo/Components/Pages/.../Pagination.razor -->
```razor
<GupPagination Kind="GupPaginationKind.Directional"
               NextLabel="Next"
               NextTitle="But Art is a punitive sentence, not a birthright"
               NextLink="#next" />
```

### Directional onprevclick onnextclick events

<!-- from GUPBlazorDemo/Components/Pages/.../Pagination.razor -->
```razor
<GupPagination Kind="GupPaginationKind.Directional"
               PrevLabel="Previous"
               PrevTitle="Section 3 — accommodation"
               PrevLink="javascript:void(0)"
               NextLabel="Next"
               NextTitle="Section 5 — review & submit"
               NextLink="javascript:void(0)"
               OnPrevClick="@(_ => Log("Prev"))"
               OnNextClick="@(_ => Log("Next"))" />

<p data-testid="event-log" style="margin:0; text-align:center;">
    Last clicked: <strong>@_lastDirectionalClick</strong>
    &nbsp;·&nbsp; total: <strong>@_directionalClickCount</strong>
</p>
```

### Rtl arabic

<!-- from GUPBlazorDemo/Components/Pages/.../Pagination.razor -->
```razor
<GupPagination TotalPages="25" CurrentPage="6"
               PrevLabel="السابق" NextLabel="التالي" />

<GupPagination Kind="GupPaginationKind.Directional"
               PrevLabel="السابق"
               PrevTitle="القسم الثالث — الإقامة"
               PrevLink="#prev"
               NextLabel="التالي"
               NextTitle="القسم الخامس — المراجعة"
               NextLink="#next" />
```

### Numbered ellipsis truncation

<!-- from GUPBlazorDemo/Components/Pages/.../Pagination.razor -->
```razor
<div>
    <p style="margin:0 0 8px; color:#52525b;">Near start (page 2 of 25)</p>
    <GupPagination TotalPages="25" CurrentPage="2" />
</div>
<div>
    <p style="margin:0 0 8px; color:#52525b;">Mid-range (page 12 of 25)</p>
    <GupPagination TotalPages="25" CurrentPage="12" />
</div>
<div>
    <p style="margin:0 0 8px; color:#52525b;">Near end (page 23 of 25)</p>
    <GupPagination TotalPages="25" CurrentPage="23" />
</div>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
