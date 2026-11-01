# GupFormList

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupFormList.razor`
> Live demo: /demo/form-list

Part of the Form list component set — see the Form list page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-form-list> — vertical flex container for form fields
```

## Import

```razor
@using GUPBlazor.Components
```

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Stacked fields

<!-- from GUPBlazorDemo/Components/Pages/.../FormListDemo.razor -->
```razor
<GupFormList>
  <GupInputField Name="fl-first" Type="text">First name</GupInputField>
  <GupInputField Name="fl-last" Type="text">Last name</GupInputField>
  <GupInputField Name="fl-email" Type="email">Email address</GupInputField>
</GupFormList>
```

### Mixed controls

<!-- from GUPBlazorDemo/Components/Pages/.../FormListDemo.razor -->
```razor
<GupFormList>
  <GupInputField Name="fl-company" Type="text">Company name</GupInputField>
  <GupTextarea Name="fl-notes" Rows="3">Additional notes</GupTextarea>
  <GupToggle Name="fl-updates">Send me updates about this application</GupToggle>
</GupFormList>
```

### Input field gupinputfield

<!-- from GUPBlazorDemo/Components/Pages/.../Forms.razor -->
```razor
<GupFormList>
    <GupInputField Name="demo-text" Type="text">Full name</GupInputField>
    <GupInputField Name="demo-email" Type="email">Email address</GupInputField>
    <GupInputField Name="demo-tel" Type="tel">Phone number</GupInputField>
    <GupInputField Name="demo-date" Type="date">Date of birth</GupInputField>
    <GupInputField Name="demo-password" Type="password">Password</GupInputField>
    <GupInputField Name="demo-readonly" Type="text" Value="Read-only value" Readonly="true">Read-only field</GupInputField>
    <GupInputField Name="demo-disabled" Type="text" Disabled="true">Disabled field</GupInputField>
</GupFormList>
```

### Input fields gupinputfield

<!-- from GUPBlazorDemo/Components/Pages/.../ReadOnlyCascade.razor -->
```razor
<GupFormList>
    <GupInputField Name="ro-text" Type="text" @bind-Value="_text">Full name</GupInputField>
    <GupInputField Name="ro-email" Type="email" @bind-Value="_email">Email address</GupInputField>
    @* Affix buttons: the picker and the show/hide toggle must disable too. *@
    <GupInputField Name="ro-date" Type="date" @bind-Value="_date">Date of birth</GupInputField>
    <GupInputField Name="ro-password" Type="password" @bind-Value="_password">Password</GupInputField>
    @* Required + empty: must not show a validation error while locked. *@
    <GupInputField Name="ro-required" Type="text" @bind-Value="_required" Required="true">Required, left empty</GupInputField>
    @* Already opted out locally; the cascade must not un-disable it. *@
    <GupInputField Name="ro-own-disabled" Type="text" Disabled="true">Disabled on its own</GupInputField>
</GupFormList>
```

### Default

<!-- from GUPBlazorDemo/Components/Pages/.../DateInput.razor -->
```razor
<GupFormList>
    <GupInputField Name="date-default" Type="date">Date of birth</GupInputField>
</GupFormList>
```

### Pre-filled

<!-- from GUPBlazorDemo/Components/Pages/.../DateInput.razor -->
```razor
<GupFormList>
    <GupInputField Name="date-value" Type="date" Value="1990-06-15">Date of birth</GupInputField>
</GupFormList>
```

### Time

<!-- from GUPBlazorDemo/Components/Pages/.../DateInput.razor -->
```razor
<GupFormList>
    <GupInputField Name="time-input" Type="time">Appointment time</GupInputField>
</GupFormList>
```

### Date-time

<!-- from GUPBlazorDemo/Components/Pages/.../DateInput.razor -->
```razor
<GupFormList>
    <GupInputField Name="datetime-input" Type="datetime-local">Appointment slot</GupInputField>
</GupFormList>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-form-list.md`
