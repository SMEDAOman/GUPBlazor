# GupRadioButton

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupRadioButton.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/inputs/radio

Radio groups, horizontal and vertical.

## Upstream mapping

```text
Equivalent of <gup-radio-button name="..." value="..." selected> Named slots: ChildContent (label text), Hint Events: OnChange (fires with this radio's value when it becomes selected) When nested inside a GupRadioButtonGroup, the group's @bind-Value drives selection.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Name` | `string` | `"" (empty)` | — |  |
| `Value` | `string` | `"" (empty)` | — |  |
| `Selected` | `bool` | — | — |  |
| `Disabled` | `bool` | — | — |  |
| `Size` | `string` | `"m"` | — | Size of the radio button: `s`, `m` (default), or `l`. |
| `Required` | `bool` | — | — | Whether the radio button is required. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |
| `<Hint>` |  |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `OnChange` | `EventCallback<string>` |  |
| `OnFocus` | `EventCallback` | Fires when the radio button gains focus (matches `gup-focus`). |
| `OnBlur` | `EventCallback` | Fires when the radio button loses focus (matches `gup-blur`). |

## Cascading values consumed

- CascadedReadOnly (cascading name: "GupReadOnly")
- Group

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

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
