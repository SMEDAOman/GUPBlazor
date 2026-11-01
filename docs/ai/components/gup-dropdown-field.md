# GupDropdownField

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupDropdownField.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/inputs/dropdown

Part of the Dropdown component set — see the Dropdown page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-dropdown-field name="..." placeholder="..." required disabled clearable loading> Named slots: Label, Hint Default slot: ChildContent (gup-dropdown-menu) Uses plain JS for interactivity; event handling round-trips to Blazor via DotNetObjectReference. Events: - OnChange (single mode): fires with selected value when user picks an item - OnMultiChange (multi mode): fires on every toggle with current selected values - OnMultiApplied (multi mode): fires when user clicks Apply or closes the menu - OnOpen / OnClose: menu visibility changes - OnClear: clear button clicked
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Name` | `string` | `"" (empty)` | — |  |
| `Placeholder` | `string` | `"" (empty)` | — |  |
| `Disabled` | `bool` | — | — |  |
| `Required` | `bool` | `true` | — |  |
| `IsInvalid` | `bool` | — | — |  |
| `Loading` | `bool` | — | — |  |
| `Clearable` | `bool` | — | — |  |
| `ErrorMessage` | `string?` | — | — |  |
| `DisplayValue` | `string?` | — | — |  |
| `ClearLabel` | `string` | `"Clear"` | — |  |
| `LoadingLabel` | `string` | `"Loading..."` | — |  |
| `MultipleValuesLabel` | `string` | `" selected"` | — |  |
| `LabelHidden` | `bool` | — | — | Hide the label visually while keeping it available to screen-readers (matches `label-hidden`). |
| `Attachment` | `string` | `"bottom-start"` | — | Positioning of the menu relative to the field (matches `attachment`), e.g. bottom-start, top-end. |
| `Value` | `string?` | — | `@bind-Value` |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<Label>` |  |
| `<Hint>` |  |
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `ValueChanged` | `EventCallback<string?>` |  |
| `OnChange` | `EventCallback<string?>` | Single-select: fires with the selected value (or null) when the user picks an item. |
| `OnMultiChange` | `EventCallback<IReadOnlyList<string>>` | Multi-select: fires on every toggle with the current list of selected values. |
| `OnMultiApplied` | `EventCallback<IReadOnlyList<string>>` | Multi-select: fires when the user clicks Apply or closes the dropdown. |
| `OnOpen` | `EventCallback` |  |
| `OnClose` | `EventCallback` |  |
| `OnClear` | `EventCallback` |  |
| `OnInvalid` | `EventCallback` | Fires when the field fails validation (matches `gup-invalid`). |

## Cascading values consumed

- CascadedReadOnly (cascading name: "GupReadOnly")
- CascadedLangId (cascading name: "GupLangId")

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Single select

<!-- from GUPBlazorDemo/Components/Pages/.../Forms.razor -->
```razor
<GupDropdownField Name="governorate" Placeholder="Select a governorate">
    <Label>Governorate</Label>
    <ChildContent>
        <GupDropdownMenu>
            <GupDropdownMenuItem Label="Muscat" Value="muscat" />
            <GupDropdownMenuItem Label="Dhofar" Value="dhofar" />
            <GupDropdownMenuItem Label="Musandam" Value="musandam" />
            <GupDropdownMenuItem Label="Al Buraimi" Value="buraimi" />
            <GupDropdownMenuItem Label="Ad Dakhiliyah" Value="dakhiliyah" />
        </GupDropdownMenu>
    </ChildContent>
</GupDropdownField>
```

### With hint pre selected

<!-- from GUPBlazorDemo/Components/Pages/.../Forms.razor -->
```razor
<GupDropdownField Name="doc-type" Placeholder="Select document type" DisplayValue="Passport">
    <Label>Document type</Label>
    <ChildContent>
        <GupDropdownMenu>
            <GupDropdownMenuItem Label="National ID" Value="national-id" />
            <GupDropdownMenuItem Label="Passport" Value="passport" Selected="true" />
            <GupDropdownMenuItem Label="Driving License" Value="driving-license" />
        </GupDropdownMenu>
    </ChildContent>
    <Hint>Choose the type of document to upload.</Hint>
</GupDropdownField>
```

### With search

<!-- from GUPBlazorDemo/Components/Pages/.../Forms.razor -->
```razor
<GupDropdownField Name="country" Placeholder="Search and select">
    <Label>Country</Label>
    <ChildContent>
        <GupDropdownMenu SearchEnabled="true">
            <GupDropdownMenuItem Label="Oman" Value="oman" />
            <GupDropdownMenuItem Label="United Arab Emirates" Value="uae" />
            <GupDropdownMenuItem Label="Saudi Arabia" Value="saudi-arabia" />
            <GupDropdownMenuItem Label="Bahrain" Value="bahrain" />
            <GupDropdownMenuItem Label="Kuwait" Value="kuwait" />
            <GupDropdownMenuItem Label="Qatar" Value="qatar" />
            <GupDropdownMenuItem Label="Jordan" Value="jordan" />
            <GupDropdownMenuItem Label="Egypt" Value="egypt" />
            <GupDropdownMenuItem Label="India" Value="india" />
            <GupDropdownMenuItem Label="Pakistan" Value="pakistan" />
            <GupDropdownMenuItem Label="United Kingdom" Value="uk" />
            <GupDropdownMenuItem Label="United States" Value="us" />
        </GupDropdownMenu>
    </ChildContent>
</GupDropdownField>
```

### Multiple with search

<!-- from GUPBlazorDemo/Components/Pages/.../Forms.razor -->
```razor
<GupDropdownField Name="multi-search" Placeholder="Search and select multiple">
    <Label>Services</Label>
    <Hint>Select all applicable services.</Hint>
    <ChildContent>
        <GupDropdownMenu Multiple="true" SearchEnabled="true">
            <GupDropdownMenuItem Label="Civil status" Value="civil-status" />
            <GupDropdownMenuItem Label="Business registration" Value="business-reg" />
            <GupDropdownMenuItem Label="Vehicle licensing" Value="vehicle-lic" />
            <GupDropdownMenuItem Label="Property registration" Value="property-reg" />
            <GupDropdownMenuItem Label="Education services" Value="education" />
            <GupDropdownMenuItem Label="Health services" Value="health" />
        </GupDropdownMenu>
    </ChildContent>
</GupDropdownField>
```

### Dropdown gupdropdownfield

<!-- from GUPBlazorDemo/Components/Pages/.../ReadOnlyCascade.razor -->
```razor
<GupDropdownField Name="ro-dropdown" Placeholder="Select a sector" @bind-Value="_sector">
    <Label>Business sector</Label>
    <ChildContent>
        <GupDropdownMenu>
            <GupDropdownMenuItem Label="Manufacturing" Value="manufacturing" />
            <GupDropdownMenuItem Label="Services" Value="services" />
            <GupDropdownMenuItem Label="Agriculture" Value="agriculture" />
        </GupDropdownMenu>
    </ChildContent>
</GupDropdownField>
```

### Default

<!-- from GUPBlazorDemo/Components/Pages/.../Dropdown.razor -->
```razor
<GupDropdownField Name="governorate" Placeholder="Select a governorate">
    <Label>Governorate</Label>
    <ChildContent>
        <GupDropdownMenu>
            @* Value 0 is the placeholder convention; it renders muted. *@
            <GupDropdownMenuItem Label="Please Select" Value="0" Selected="true" />
            <GupDropdownMenuItem Label="Muscat" Value="muscat" />
            <GupDropdownMenuItem Label="Dhofar" Value="dhofar" />
            <GupDropdownMenuItem Label="Musandam" Value="musandam" />
            <GupDropdownMenuItem Label="Al Buraimi" Value="buraimi" />
            <GupDropdownMenuItem Label="Ad Dakhiliyah" Value="dakhiliyah" />
        </GupDropdownMenu>
    </ChildContent>
</GupDropdownField>
```

### With hint pre selected

<!-- from GUPBlazorDemo/Components/Pages/.../Dropdown.razor -->
```razor
<GupDropdownField Name="doc-type" Placeholder="Select document type" DisplayValue="Passport">
    <Label>Document type</Label>
    <Hint>Choose the type of document to upload (top hint).</Hint>
    <ChildContent>
        <GupDropdownMenu>
            <GupDropdownMenuItem Label="National ID" Value="national-id" />
            <GupDropdownMenuItem Label="Passport" Value="passport" Selected="true" />
            <GupDropdownMenuItem Label="Driving License" Value="driving-license" />
        </GupDropdownMenu>
    </ChildContent>
    <Hint>Choose the type of document to upload (bottom hint).</Hint>
</GupDropdownField>
```

### Two way binding bind value

<!-- from GUPBlazorDemo/Components/Pages/.../Dropdown.razor -->
```razor
<GupDropdownField Name="bind-color" Placeholder="Pick a color" @bind-Value="_selectedColor">
    <Label>Favourite colour</Label>
    <ChildContent>
        <GupDropdownMenu>
            <GupDropdownMenuItem Label="Red" Value="red" />
            <GupDropdownMenuItem Label="Green" Value="green" />
            <GupDropdownMenuItem Label="Blue" Value="blue" />
            <GupDropdownMenuItem Label="Yellow" Value="yellow" />
        </GupDropdownMenu>
    </ChildContent>
</GupDropdownField>
<p data-testid="bind-color-output" style="margin-top: 12px;">
    Bound value: <strong>@(_selectedColor ?? "(none)")</strong>
</p>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
