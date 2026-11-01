# GupFilterChipWrapper

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupFilterChipWrapper.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/filter-chip

Part of the Filter chip component set — see the Filter chip page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-filter-chip-wrapper clear-label="Clear all"> Groups GupFilterChip elements with an optional leading label and a trailing "clear all" button. Renders the chips in a multi-line GupTrack. Default slot:  ChildContent — should contain only GupFilterChip elements Named slot:    Label         — group label rendered before the chips Two-way bind:  @bind-ClearLabel Events:        OnClearAll    — fires when the "clear all" button is clicked
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `ClearLabel` | `string` | `"" (empty)` | `@bind-ClearLabel` | Label for the trailing "clear all" button. When empty, the button is hidden. |
| `AriaLabel` | `string?` | — | — | Optional accessible label for the wrapper region. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<Label>` | Group label rendered before the chips. |
| `<ChildContent>` | Default slot — should contain only GupFilterChip elements. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `ClearLabelChanged` | `EventCallback<string>` |  |
| `OnClearAll` | `EventCallback<MouseEventArgs>` | Fires when the "clear all" button is clicked. |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Wrapper basic

<!-- from GUPBlazorDemo/Components/Pages/.../FilterChip.razor -->
```razor
<GupFilterChipWrapper ClearLabel="Clear all">
    <Label>Search in:</Label>
    <ChildContent>
        <GupFilterChip>Filter 1</GupFilterChip>
        <GupFilterChip>Filter 2</GupFilterChip>
        <GupFilterChip>Filter 3</GupFilterChip>
        <GupFilterChip>Filter 4</GupFilterChip>
    </ChildContent>
</GupFilterChipWrapper>
```

### Mixed kinds inside a wrapper

<!-- from GUPBlazorDemo/Components/Pages/.../FilterChip.razor -->
```razor
<GupFilterChipWrapper ClearLabel="Clear all">
    <Label>Mixed:</Label>
    <ChildContent>
        <GupFilterChip>Button chip</GupFilterChip>
        <GupFilterChip Kind="@GupFilterChipKind.Link" Href="#">Link chip</GupFilterChip>
        <GupFilterChip HideCloseIcon="true">No icon</GupFilterChip>
        <GupFilterChip Disabled="true">Disabled</GupFilterChip>
    </ChildContent>
</GupFilterChipWrapper>
```

### Rtl arabic

<!-- from GUPBlazorDemo/Components/Pages/.../FilterChip.razor -->
```razor
<GupFilterChipWrapper ClearLabel="مسح الكل">
    <Label>البحث في:</Label>
    <ChildContent>
        <GupFilterChip>الفرز الأول</GupFilterChip>
        <GupFilterChip>الفرز الثاني</GupFilterChip>
        <GupFilterChip>الفرز الثالث</GupFilterChip>
        <GupFilterChip>الفرز الرابع</GupFilterChip>
    </ChildContent>
</GupFilterChipWrapper>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
