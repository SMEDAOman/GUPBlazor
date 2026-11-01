# GupSearch

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupSearch.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/search

Search field with submit and clear affordances.

## Upstream mapping

```text
Equivalent of <gup-search name="..." label="..." placeholder="..." value="..."> Pill-shaped search field with a clear-button (visible only when there is a value) and a trailing search-icon submit button. Mirrors the gov.om design-system component at design-system/components/search. Two-way binding: @bind-Value, @bind-Disabled Events: - OnValueChange → fires on every keystroke (input event); receives the new value - OnSearch      → fires when the search icon is clicked or Enter is pressed; receives the current value - OnClear       → fires when the × clear button is pressed - OnClick       → fires when the input is clicked (matches gup-click in the source component)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Name` | `string` | `"search"` | — | The name of the search input — used for the input id/name. |
| `Label` | `string` | `"Search"` | — | Accessible label for the search input (rendered as aria-label). |
| `Placeholder` | `string?` | — | — | Placeholder text shown when the field is empty. |
| `Value` | `string?` | — | `@bind-Value` | Current value of the search input. |
| `Disabled` | `bool` | — | `@bind-Disabled` | When true, the field and both buttons are visually disabled and non-interactive. |
| `SearchLabel` | `string` | `"Search"` | — | aria-label / title for the search submit button. |
| `ResetLabel` | `string` | `"Clear"` | — | aria-label / title for the clear button (× icon). |

## Events

| Event | Type | Description |
|---|---|---|
| `ValueChanged` | `EventCallback<string?>` |  |
| `DisabledChanged` | `EventCallback<bool>` |  |
| `OnValueChange` | `EventCallback<string?>` | Fires on every keystroke — receives the new value. |
| `OnSearch` | `EventCallback<string?>` | Fires when the user submits — clicking the search button or pressing Enter. Receives the current value. |
| `OnClear` | `EventCallback` | Fires when the × clear button is pressed. |
| `OnClick` | `EventCallback<MouseEventArgs>` | Fires when the input field is clicked. |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default

<!-- from GUPBlazorDemo/Components/Pages/.../Search.razor -->
```razor
<GupSearch Name="default" Label="Search" />
```

### With placeholder

<!-- from GUPBlazorDemo/Components/Pages/.../Search.razor -->
```razor
<GupSearch Name="placeholder"
           Label="Search services"
           Placeholder="Search for something…" />
```

### With initial value

<!-- from GUPBlazorDemo/Components/Pages/.../Search.razor -->
```razor
<GupSearch Name="prefilled"
           Label="Search"
           Value="what is the real meaning of life?" />
```

### Disabled

<!-- from GUPBlazorDemo/Components/Pages/.../Search.razor -->
```razor
<GupSearch Name="disabled"
           Label="Search"
           Placeholder="Search for something…"
           Disabled="true" />
```

### Two way binding bind value events

<!-- from GUPBlazorDemo/Components/Pages/.../Search.razor -->
```razor
<GupSearch Name="bound"
           Label="Search"
           Placeholder="Type something then press Enter or click 🔍"
           @bind-Value="_boundValue"
           OnValueChange="HandleValueChange"
           OnSearch="HandleSearch"
           OnClear="HandleClear"
           OnClick="HandleClick" />

<div style="display:flex; gap:8px; flex-wrap:wrap;">
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundValue = "Hello world")">
        <ChildContent>Set to "Hello world"</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundValue = string.Empty)">
        <ChildContent>Clear externally</ChildContent>
    </GupButton>
</div>

<div data-testid="bind-output" style="display:flex; flex-direction:column; gap:4px; margin:0;">
    <p style="margin:0;">
        <strong>Bound value:</strong>
        "<span data-testid="bind-value">@_boundValue</span>"
    </p>
    <p style="margin:0;">
        <strong>OnValueChange:</strong>
        <span data-testid="value-change-count">@_valueChangeCount</span> times
        &nbsp;·&nbsp;
        <strong>OnSearch:</strong>
        <span data-testid="search-count">@_searchCount</span> times
        &nbsp;·&nbsp;
        <strong>OnClear:</strong>
        <span data-testid="clear-count">@_clearCount</span> times
        &nbsp;·&nbsp;
        <strong>OnClick:</strong>
        <span data-testid="click-count">@_clickCount</span> times
    </p>
    <p style="margin:0;">
        <strong>Last submitted query:</strong>
        "<span data-testid="last-search">@_lastSearch</span>"
    </p>
</div>
```

### Two way binding bind disabled

<!-- from GUPBlazorDemo/Components/Pages/.../Search.razor -->
```razor
<GupSearch Name="bind-disabled"
           Label="Search"
           Placeholder="Search…"
           @bind-Disabled="_isDisabled"
           Value="Some preset query" />

<GupCheckbox Name="toggle-disabled"
             @bind-Checked="_isDisabled">Disable the search field</GupCheckbox>

<p style="margin:0;">
    Bound disabled state: <strong>@_isDisabled</strong>
</p>
```

### Rtl arabic

<!-- from GUPBlazorDemo/Components/Pages/.../Search.razor -->
```razor
<GupSearch Name="rtl"
           Label="بحث"
           Placeholder="ابحث عن شيء…"
           SearchLabel="بحث"
           ResetLabel="مسح" />
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
