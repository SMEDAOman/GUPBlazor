# GupFilterChip

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupFilterChip.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/filter-chip

Removable chips for active filters.

## Upstream mapping

```text
Equivalent of <gup-filter-chip kind="button|link" disabled href="..." hide-close-icon> A pill-shaped chip used to display a user-selected filter. As a "button" it renders a close (×) icon and emits OnClick when activated; as a "link" it navigates to Href. Two-way binding: @bind-Kind, @bind-Disabled, @bind-Href, @bind-HideCloseIcon Events:          OnClick (fires when the button-kind chip is clicked)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Kind` | `GupFilterChipKind` | `GupFilterChipKind.Button` | `@bind-Kind` | Whether the chip behaves as a button (default — closeable) or a link. |
| `Disabled` | `bool` | — | `@bind-Disabled` | Whether the button-kind chip is disabled. Ignored when Kind=Link. |
| `Href` | `string` | `"" (empty)` | `@bind-Href` | Target URL when Kind=Link. |
| `HideCloseIcon` | `bool` | — | `@bind-HideCloseIcon` | Hides the trailing close (×) icon. Only relevant when Kind=Button. |
| `AriaLabel` | `string?` | — | — | Optional accessible label — useful when the chip's only visible content is the close icon. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Chip label content. Avoid placing interactive elements inside. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `KindChanged` | `EventCallback<GupFilterChipKind>` |  |
| `DisabledChanged` | `EventCallback<bool>` |  |
| `HrefChanged` | `EventCallback<string>` |  |
| `HideCloseIconChanged` | `EventCallback<bool>` |  |
| `OnClick` | `EventCallback<MouseEventArgs>` | Fires when the button-kind chip is activated (click / Enter / Space). |

## Enums

### `GupFilterChipKind`

Whether the filter chip renders as a button (default — closeable) or a link. Mirrors gup-filter-chip's `kind` attribute.

- `GupFilterChipKind.Button`
- `GupFilterChipKind.Link`

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default button

<!-- from GUPBlazorDemo/Components/Pages/.../FilterChip.razor -->
```razor
<GupFilterChip>I am a button</GupFilterChip>
```

### Disabled

<!-- from GUPBlazorDemo/Components/Pages/.../FilterChip.razor -->
```razor
<GupFilterChip Disabled="true">I am disabled</GupFilterChip>
```

### Link

<!-- from GUPBlazorDemo/Components/Pages/.../FilterChip.razor -->
```razor
<GupFilterChip Kind="@GupFilterChipKind.Link" Href="#">I am a link</GupFilterChip>
```

### Without close icon

<!-- from GUPBlazorDemo/Components/Pages/.../FilterChip.razor -->
```razor
<GupFilterChip HideCloseIcon="true">No close icon</GupFilterChip>
```

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
