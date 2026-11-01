# GupDataTable

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupDataTable.razor`
> Live demo: /demo/data-table

Table chrome around GupTable — search, filter panel with removable chips, empty state, pagination footer.

## Upstream mapping

```text
Equivalent of <gup-data-table title="..." description="..." show-search show-filters ...> Composite table chrome: header, search box, filter panel, applied-filter chips, empty state and a pagination footer wrapped around <GupTable>. Two modes, selected by whether Items is set: - Data-driven (Items != null): the component searches, slices and renders rows itself via RowTemplate. This is the only mode where the search box filters. - Manual (Items == null): the consumer supplies ChildContent rows already paged; the component renders chrome only and reports page/search changes via events. Two-way binding: @bind-SearchValue, @bind-CurrentPage, @bind-ResultsCount, @bind-FilterPanelOpen, @bind-AppliedFilters Events: OnSearch, OnPageChange, OnClearFilters, OnViewClick, OnFilterApply
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `TableTitle` | `string?` | — | — | Heading shown above the table. Named `TableTitle` rather than `Title` to avoid colliding with the HTML `title` attribute. |
| `Description` | `string?` | — | — | Supporting text shown beneath `TableTitle`. |
| `SearchPlaceholder` | `string` | `"Find data"` | — | Placeholder for the search box. Also used as its accessible label. |
| `SearchValue` | `string?` | — | `@bind-SearchValue` | Current search term. |
| `ResultsCount` | `int?` | — | `@bind-ResultsCount` | Match count rendered as "N results" beside the search box. Null hides the label. |
| `TotalItems` | `int` | — | — | Unfiltered row count across all pages. Drives the item counter, the page count and the empty state, so a data-driven consumer must set it (typically `Items.Count()`) — it is not inferred from `Items`. Zero renders the empty state. The component never writes to it: while a search is active the chrome narrows to the match count internally, so this stays the consumer's own total. |
| `CurrentPage` | `int` | `1` | `@bind-CurrentPage` | Active page, 1-based. |
| `ItemsPerPage` | `int` | `10` | — | Rows per page. Values of zero or less fall back to 10. |
| `ShowSearch` | `bool` | `true` | — | Whether the search box is rendered. |
| `ShowFilters` | `bool` | — | — | Whether the filter button, filter panel and view button are rendered. |
| `Filters` | `IReadOnlyList<GupDataTableFilter>` | `[]` | — | Filters offered in the filter panel. |
| `AppliedFilters` | `IReadOnlyList<GupAppliedFilter>` | `[]` | `@bind-AppliedFilters` | Filters the user has applied, rendered as removable chips. |
| `Columns` | `IReadOnlyList<GupDataTableColumn>` | `[]` | — | Column definitions. When non-empty a header row is rendered from them, and each column's `Width` or `Grow` sizes it. |
| `FiltersButtonText` | `string` | `"Filters"` | — | Label for the filter toggle, in both the desktop and mobile control stacks. |
| `ClearAllText` | `string` | `"Clear all"` | — | Label for the button that clears every applied-filter chip. |
| `ViewButtonText` | `string` | `"View application"` | — | Label for the secondary action button beside the filter toggle. |
| `ViewButtonIcon` | `string?` | — | — | Icon name shown before `ViewButtonText`. Null renders no icon. |
| `ShowViewButton` | `bool` | `true` | — | Whether the view button is rendered. |
| `MobileActionButtons` | `IReadOnlyList<string>` | `[]` | — | Labels for extra full-width action buttons shown above the mobile filter toggle. |
| `EmptyTitle` | `string` | `"No applications found"` | — | Heading of the empty state. |
| `EmptyDescription` | `string` | `"There are no applications to display. Create your first application to get started."` | — | Body text of the empty state. |
| `FilterPanelOpen` | `bool` | — | `@bind-FilterPanelOpen` | Whether the filter panel is open. |
| `Responsive` | `bool` | `true` | — | Passed to the inner `GupTable`: collapses rows into stacked cards below the mobile breakpoint. Replaces the `layout` property of the Lit component. |
| `Items` | `IEnumerable<TItem>?` | — | — | Rows to display. When set, the component performs its own search, filtering and paging. |
| `SearchTextSelector` | `Func<TItem, string>?` | — | — |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<RowTemplate>` | Renders one row. Receives the item for that row. |
| `<ChildContent>` | Rows supplied directly by the consumer, used when `Items` is null. In that mode the consumer owns searching and paging — the search box only raises `OnSearch`, and the pagination footer only raises `OnPageChange`. |
| `<FiltersContent>` | Replaces the auto-generated filter editors in both filter panels. |
| `<PaginationContent>` | Replaces the built-in `GupPagination` in the footer. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `SearchValueChanged` | `EventCallback<string?>` | Fires when `SearchValue` changes — enables `@@bind-SearchValue`. |
| `ResultsCountChanged` | `EventCallback<int?>` | Fires when `ResultsCount` changes — enables `@@bind-ResultsCount`. |
| `CurrentPageChanged` | `EventCallback<int>` | Fires when `CurrentPage` changes — enables `@@bind-CurrentPage`. |
| `AppliedFiltersChanged` | `EventCallback<IReadOnlyList<GupAppliedFilter>>` | Fires when `AppliedFilters` changes — enables `@@bind-AppliedFilters`. |
| `FilterPanelOpenChanged` | `EventCallback<bool>` | Fires when `FilterPanelOpen` changes — enables `@@bind-FilterPanelOpen`. |
| `OnSearch` | `EventCallback<string?>` | Fires on every keystroke in the search box, with the new term. |
| `OnPageChange` | `EventCallback<int>` | Fires when the page changes, with the new page number. |
| `OnClearFilters` | `EventCallback` | Fires when Clear is pressed in the filter panel or the chip row. |
| `OnViewClick` | `EventCallback` | Fires when the view button is pressed. |
| `OnFilterApply` | `EventCallback<IReadOnlyList<GupAppliedFilter>>` | Fires when Apply is pressed in the filter panel, with the applied filters. |
| `OnMobileActionClick` | `EventCallback<string>` | Fires when one of the `MobileActionButtons` is pressed, with its label. |

> Members of `GupAppliedFilter` are documented in [support types](/ai/types.md).

## Enums

### `GupDataTableFilterType`

Kind of editor rendered for a filter in the filter panel.

- `GupDataTableFilterType.Text` — Free-text input.
- `GupDataTableFilterType.Date` — Date picker input.
- `GupDataTableFilterType.Select` — Dropdown populated from `Options`.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default search and pagination

<!-- from GUPBlazorDemo/Components/Pages/.../DataTable.razor -->
```razor
<GupDataTable Items="Applications"
              SearchTextSelector="SearchText"
              TableTitle="Applications"
              Description="This is a short description"
              Columns="ApplicationColumns"
              ItemsPerPage="6"
              TotalItems="Applications.Count"
              @bind-SearchValue="_defaultSearch"
              @bind-CurrentPage="_defaultPage"
              @bind-ResultsCount="_defaultResults"
              ShowFilters="false">
    <RowTemplate Context="app">
        <GupTableRow>
            <GupTableCell Label="Number">@app.Number</GupTableCell>
            <GupTableCell Label="Type">@app.Type</GupTableCell>
            <GupTableCell Label="Start date">@app.StartDate</GupTableCell>
            <GupTableCell Label="End date">@app.EndDate</GupTableCell>
            <GupTableCell Label="Status">
                <GupBadgeChip Appearance="@app.StatusAppearance">@app.Status</GupBadgeChip>
            </GupTableCell>
        </GupTableRow>
    </RowTemplate>
</GupDataTable>
```

### With filters text date and select

<!-- from GUPBlazorDemo/Components/Pages/.../DataTable.razor -->
```razor
<GupDataTable Items="Applications"
              SearchTextSelector="SearchText"
              TableTitle="Applications"
              Description="Filter by status, reference or date"
              Columns="ApplicationColumns"
              ItemsPerPage="6"
              TotalItems="Applications.Count"
              ShowFilters="true"
              ViewButtonText="Action"
              ViewButtonIcon="download"
              Filters="ApplicationFilters"
              MobileActionButtons="@(new[] { "New application" })"
              @bind-SearchValue="_filterSearch"
              @bind-CurrentPage="_filterPage"
              @bind-ResultsCount="_filterResults"
              @bind-FilterPanelOpen="_filterPanelOpen"
              @bind-AppliedFilters="_appliedFilters"
              OnFilterApply="HandleFilterApply"
              OnClearFilters="@(() => Log("Clear filters"))"
              OnViewClick="@(() => Log("View click"))"
              OnMobileActionClick="@(label => Log($"Mobile action: {label}"))">
    <RowTemplate Context="app">
        <GupTableRow>
            <GupTableCell Label="Number">@app.Number</GupTableCell>
            <GupTableCell Label="Type">@app.Type</GupTableCell>
            <GupTableCell Label="Start date">@app.StartDate</GupTableCell>
            <GupTableCell Label="End date">@app.EndDate</GupTableCell>
            <GupTableCell Label="Status">
                <GupBadgeChip Appearance="@app.StatusAppearance">@app.Status</GupBadgeChip>
            </GupTableCell>
        </GupTableRow>
    </RowTemplate>
</GupDataTable>

<p data-testid="filter-log" style="margin:16px 0 0; padding:0 24px 16px;">
    Last event: <strong>@_lastEvent</strong>
    &nbsp;·&nbsp; applied: <strong>@_appliedFilters.Count</strong>
</p>
```

### Empty state

<!-- from GUPBlazorDemo/Components/Pages/.../DataTable.razor -->
```razor
<GupDataTable TItem="Application"
              Items="NoApplications"
              TableTitle="Applications"
              Description="This is a short description"
              Columns="ApplicationColumns"
              ItemsPerPage="6"
              TotalItems="0"
              ShowFilters="true"
              ViewButtonText="Action"
              Filters="ApplicationFilters"
              @bind-FilterPanelOpen="_emptyPanelOpen" />
```

### Search only

<!-- from GUPBlazorDemo/Components/Pages/.../DataTable.razor -->
```razor
<GupDataTable Items="Applications"
              SearchTextSelector="SearchText"
              SearchPlaceholder="Search applications"
              Columns="ApplicationColumns"
              ItemsPerPage="10"
              TotalItems="Applications.Count"
              ShowFilters="false"
              @bind-SearchValue="_searchOnlySearch"
              @bind-CurrentPage="_searchOnlyPage"
              @bind-ResultsCount="_searchOnlyResults"
              OnSearch="@(term => Log($"Search: {term}"))">
    <RowTemplate Context="app">
        <GupTableRow>
            <GupTableCell Label="Number">@app.Number</GupTableCell>
            <GupTableCell Label="Type">@app.Type</GupTableCell>
            <GupTableCell Label="Start date">@app.StartDate</GupTableCell>
            <GupTableCell Label="End date">@app.EndDate</GupTableCell>
            <GupTableCell Label="Status">
                <GupBadgeChip Appearance="@app.StatusAppearance">@app.Status</GupBadgeChip>
            </GupTableCell>
        </GupTableRow>
    </RowTemplate>
</GupDataTable>
```

### Responsive stacked cards below 639px

<!-- from GUPBlazorDemo/Components/Pages/.../DataTable.razor -->
```razor
<GupDataTable Items="Applications"
              SearchTextSelector="SearchText"
              TableTitle="Applications"
              Columns="ApplicationColumns"
              ItemsPerPage="4"
              TotalItems="Applications.Count"
              ShowFilters="true"
              ViewButtonText="Action"
              Filters="ApplicationFilters"
              MobileActionButtons="@(new[] { "New application" })"
              Responsive="true"
              @bind-SearchValue="_responsiveSearch"
              @bind-CurrentPage="_responsivePage"
              @bind-ResultsCount="_responsiveResults"
              @bind-FilterPanelOpen="_responsivePanelOpen">
    <RowTemplate Context="app">
        <GupTableRow>
            <GupTableCell Label="Number">@app.Number</GupTableCell>
            <GupTableCell Label="Type">@app.Type</GupTableCell>
            <GupTableCell Label="Start date">@app.StartDate</GupTableCell>
            <GupTableCell Label="End date">@app.EndDate</GupTableCell>
            <GupTableCell Label="Status">
                <GupBadgeChip Appearance="@app.StatusAppearance">@app.Status</GupBadgeChip>
            </GupTableCell>
        </GupTableRow>
    </RowTemplate>
</GupDataTable>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-data-table.md`
