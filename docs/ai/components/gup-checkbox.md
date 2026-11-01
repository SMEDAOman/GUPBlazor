# GupCheckbox

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupCheckbox.razor`
> Live demo: /demo/inputs/checkbox

Single, grouped and indeterminate states.

## Upstream mapping

```text
Equivalent of <gup-checkbox name="..." checked disabled indeterminate> Two-way binding: @bind-Checked (and @bind-Indeterminate) Events: OnChange (new checked state), OnInvalid (required + unchecked)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Name` | `string` | `"" (empty)` | — |  |
| `Value` | `string` | `"on"` | — |  |
| `Checked` | `bool` | — | `@bind-Checked` |  |
| `Indeterminate` | `bool` | — | `@bind-Indeterminate` |  |
| `Disabled` | `bool` | — | — |  |
| `Required` | `bool` | — | — |  |
| `ErrorMessage` | `string?` | — | — |  |
| `Size` | `string` | `"m"` | — |  |
| `Appearance` | `string` | `"default"` | — |  |
| `Id` | `string?` | — | — |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |
| `<Hint>` |  |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `CheckedChanged` | `EventCallback<bool>` |  |
| `IndeterminateChanged` | `EventCallback<bool>` |  |
| `OnChange` | `EventCallback<bool>` |  |
| `OnInvalid` | `EventCallback` |  |

## Cascading values consumed

- CascadedReadOnly (cascading name: "GupReadOnly")

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Single, unchecked

<!-- from GUPBlazorDemo/Components/Pages/.../Checkbox.razor -->
```razor
<GupCheckbox Name="cb-terms" Value="accepted">
    <ChildContent>I accept the terms and conditions</ChildContent>
    <Hint>Please read the terms before accepting.</Hint>
</GupCheckbox>
```

### Single, checked

<!-- from GUPBlazorDemo/Components/Pages/.../Checkbox.razor -->
```razor
<GupCheckbox Name="cb-newsletter" Checked="true">
    <ChildContent>Subscribe to newsletter</ChildContent>
</GupCheckbox>
```

### Unchecked + disabled

<!-- from GUPBlazorDemo/Components/Pages/.../Checkbox.razor -->
```razor
<GupCheckbox Name="cb-unavailable" Disabled="true">
    <ChildContent>This option is disabled</ChildContent>
</GupCheckbox>
```

### Checked + disabled

<!-- from GUPBlazorDemo/Components/Pages/.../Checkbox.razor -->
```razor
<GupCheckbox Name="cb-checked-disabled" Checked="true" Disabled="true">
    <ChildContent>Checked &amp; disabled</ChildContent>
</GupCheckbox>
```

### Medium (default)

<!-- from GUPBlazorDemo/Components/Pages/.../Checkbox.razor -->
```razor
<GupCheckbox Name="cb-m-1">
    <ChildContent>Medium checkbox</ChildContent>
</GupCheckbox>
<GupCheckbox Name="cb-m-2" Checked="true">
    <ChildContent>Medium checked</ChildContent>
</GupCheckbox>
```

### Small

<!-- from GUPBlazorDemo/Components/Pages/.../Checkbox.razor -->
```razor
<GupCheckbox Name="cb-s-1" Size="s">
    <ChildContent>Small checkbox</ChildContent>
</GupCheckbox>
<GupCheckbox Name="cb-s-2" Size="s" Checked="true">
    <ChildContent>Small checked</ChildContent>
</GupCheckbox>
```

### Circle

<!-- from GUPBlazorDemo/Components/Pages/.../Checkbox.razor -->
```razor
<GupCheckbox Name="cb-circle-1" Appearance="circle">
    <ChildContent>Circle checkbox</ChildContent>
</GupCheckbox>
<GupCheckbox Name="cb-circle-2" Appearance="circle" Checked="true">
    <ChildContent>Circle checked</ChildContent>
</GupCheckbox>
```

### Small circle

<!-- from GUPBlazorDemo/Components/Pages/.../Checkbox.razor -->
```razor
<GupCheckbox Name="cb-small-circle" Size="s" Appearance="circle" Checked="true">
    <ChildContent>Small circle checked</ChildContent>
</GupCheckbox>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-checkbox.md`
