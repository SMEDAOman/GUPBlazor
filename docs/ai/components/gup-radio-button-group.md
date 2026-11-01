# GupRadioButtonGroup

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupRadioButtonGroup.razor`
> Live demo: /demo/inputs/radio

Part of the Radio button component set — see the Radio button page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-radio-button-group label="..." name="..."> Two-way binding: @bind-Value (selected radio's value) Events: OnChange (new selected value)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Label` | `string` | `"" (empty)` | — |  |
| `Name` | `string` | `"" (empty)` | — |  |
| `Value` | `string?` | — | `@bind-Value` |  |
| `Required` | `bool` | `true` | — | Whether a selection is required. Mandatory by default; set to false to show "(optional)". |
| `ErrorMessage` | `string?` | — | — | Validation error message shown when `IsInvalid` is true. |
| `IsInvalid` | `bool` | — | — | Whether the group is in an invalid state. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<Hint>` | Optional hint slot rendered below the group label. |
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `ValueChanged` | `EventCallback<string?>` |  |
| `OnChange` | `EventCallback<string?>` |  |
| `OnInvalid` | `EventCallback` | Fires when the group fails validation (matches `gup-invalid`). |

## Cascading values consumed

- CascadedLangId (cascading name: "GupLangId")

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default group

<!-- from GUPBlazorDemo/Components/Pages/.../Forms.razor -->
```razor
<GupRadioButtonGroup Label="Preferred contact method" Name="contact-method">
    <GupRadioButton Name="contact-method" Value="email">
        <ChildContent>Email</ChildContent>
        <Hint>We'll send updates to your inbox.</Hint>
    </GupRadioButton>
    <GupRadioButton Name="contact-method" Value="sms">
        <ChildContent>SMS</ChildContent>
        <Hint>We'll send a text to your phone.</Hint>
    </GupRadioButton>
    <GupRadioButton Name="contact-method" Value="none">
        <ChildContent>Do not contact</ChildContent>
    </GupRadioButton>
</GupRadioButtonGroup>
```

### With pre selected item

<!-- from GUPBlazorDemo/Components/Pages/.../Forms.razor -->
```razor
<GupRadioButtonGroup Label="Application type" Name="app-type">
    <GupRadioButton Name="app-type" Value="new" Selected="true">
        <ChildContent>New application</ChildContent>
        <Hint>Apply for the first time.</Hint>
    </GupRadioButton>
    <GupRadioButton Name="app-type" Value="renewal">
        <ChildContent>Renewal</ChildContent>
        <Hint>Renew an existing permit.</Hint>
    </GupRadioButton>
    <GupRadioButton Name="app-type" Value="replacement" Disabled="true">
        <ChildContent>Replacement (unavailable)</ChildContent>
    </GupRadioButton>
</GupRadioButtonGroup>
```

### Checkbox and radios

<!-- from GUPBlazorDemo/Components/Pages/.../ReadOnlyCascade.razor -->
```razor
<GupCheckbox Name="ro-check" @bind-Checked="_agreed"><ChildContent>I agree to the terms</ChildContent></GupCheckbox>

<div style="margin-top:16px;">
    <GupRadioButtonGroup Label="Preferred contact" Name="ro-radio" @bind-Value="_choice">
        <GupRadioButton Name="ro-radio" Value="email">
            <ChildContent>Email</ChildContent>
        </GupRadioButton>
        <GupRadioButton Name="ro-radio" Value="sms">
            <ChildContent>SMS</ChildContent>
        </GupRadioButton>
    </GupRadioButtonGroup>
</div>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-radio-button-group.md`
