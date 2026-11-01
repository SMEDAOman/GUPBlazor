# GupBadgeChip

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupBadgeChip.razor`
> Live demo: /demo/badge-chips

Compact status chips with optional icon.

## Upstream mapping

```text
Equivalent of <gup-badge-chip appearance="neutral|positive|warning|negative|brand" is-filled has-thumbnail with-icon-only> Compact label for status. Slots: Thumbnail, Prefix, ChildContent, Suffix. Use IconOnly=true for a square chip containing a single icon (no text).
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Appearance` | `GupBadgeChipAppearance` | `GupBadgeChipAppearance.Neutral` | — |  |
| `IsFilled` | `bool` | — | — |  |
| `HasThumbnail` | `bool` | — | — |  |
| `IconOnly` | `bool` | — | — |  |
| `Role` | `string` | `"status"` | — |  |
| `AriaLabel` | `string?` | — | — |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |
| `<Prefix>` |  |
| `<Suffix>` |  |
| `<Thumbnail>` |  |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Enums

### `GupBadgeChipAppearance`

- `GupBadgeChipAppearance.Neutral`
- `GupBadgeChipAppearance.Positive`
- `GupBadgeChipAppearance.Warning`
- `GupBadgeChipAppearance.Negative`
- `GupBadgeChipAppearance.Brand`

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

### Rich title content

<!-- from GUPBlazorDemo/Components/Pages/.../FormSection.razor -->
```razor
<GupFormSection>
    <Title>
        <span style="display:inline-flex; align-items:center; gap:8px;">
            Identity verification
            <GupBadgeChip Appearance="@GupBadgeChipAppearance.Positive" IsFilled="true">
                <ChildContent>Verified</ChildContent>
            </GupBadgeChip>
        </span>
    </Title>
    <ChildContent>
        <p style="margin: 0; color: var(--gup-color-content-primary);">
            The Title slot can contain any markup — here it's combined with a badge chip.
        </p>
    </ChildContent>
</GupFormSection>
```

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

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-badge-chip.md`
