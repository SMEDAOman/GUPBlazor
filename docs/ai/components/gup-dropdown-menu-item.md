# GupDropdownMenuItem

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupDropdownMenuItem.razor`
> Live demo: /demo/inputs/dropdown

Part of the Dropdown component set — see the Dropdown page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-dropdown-menu-item label="..." value="..." selected disabled>
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Label` | `string` | `"" (empty)` | — |  |
| `Value` | `string` | `"" (empty)` | — |  |
| `Selected` | `bool` | — | — |  |
| `Disabled` | `bool` | — | — |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Cascading values consumed

- IsMultiple (cascading name: "IsMultiple")

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

### Loading simulated

<!-- from GUPBlazorDemo/Components/Pages/.../Dropdown.razor -->
```razor
<GupDropdownField Name="loading-dd" Placeholder="Select an option">
    <Label>Loading dropdown</Label>
    <ChildContent>
        <GupDropdownMenu>
            <GupDropdownMenuItem Label="Option A" Value="a" />
        </GupDropdownMenu>
    </ChildContent>
</GupDropdownField>
<div class="gup-button gup-button--secondary" style="margin-top: 12px;">
    <button class="button" type="button" onclick="window.__gupDropdownLoadingDemo('gup-dd-loading-dd')">
        Simulate loading
    </button>
</div>
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

### Single select search

<!-- from GUPBlazorDemo/Components/Pages/.../Dropdown.razor -->
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

### Disabled

<!-- from GUPBlazorDemo/Components/Pages/.../Dropdown.razor -->
```razor
<GupDropdownField Name="disabled-dd" Placeholder="Cannot select" Disabled="true">
    <Label>Disabled dropdown</Label>
    <ChildContent>
        <GupDropdownMenu>
            <GupDropdownMenuItem Label="Item 1" Value="1" />
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

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-dropdown-menu-item.md`
