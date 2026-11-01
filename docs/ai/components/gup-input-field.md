# GupInputField

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupInputField.razor`
> Live demo: /demo/inputs/text

Single-line text with label, hint, error and read-only states.

## Upstream mapping

```text
Equivalent of <gup-input-field name="..." type="text|email|date|time|password|number|numeric|tel|url">Label</gup-input-field> Two-way binding: @bind-Value Slots (RenderFragment): ChildContent (label), Prefix, Suffix, InputStart, InputEnd, Hint, ErrorMessageContent, Popup Events: OnValueChange (input), OnChange (commit/blur), OnKeyDown, OnFocus, OnInvalid Validation: self-validates against Pattern, MinLength, MaxLength, Required after the user interacts. Parent can force the error state via IsInvalid.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Name` | `string` | `"" (empty)` | — |  |
| `Type` | `string` | `"text"` | — |  |
| `Placeholder` | `string?` | — | — |  |
| `Value` | `string?` | — | `@bind-Value` |  |
| `Disabled` | `bool` | — | — |  |
| `Readonly` | `bool` | — | — |  |
| `Required` | `bool` | `true` | — |  |
| `MinLength` | `int?` | — | — |  |
| `MaxLength` | `int?` | — | — |  |
| `Min` | `string?` | — | — |  |
| `Max` | `string?` | — | — |  |
| `Pattern` | `string?` | — | — |  |
| `Step` | `int?` | — | — |  |
| `LabelHidden` | `bool` | — | — |  |
| `ErrorMessage` | `string?` | — | — |  |
| `IsInvalid` | `bool` | — | — |  |
| `StrictNumeric` | `bool` | — | — | When true and Type is "numeric" or "tel", non-digit keystrokes are stripped on input. Deviates from the design-system spec (which only validates, not filters) — opt in deliberately. |
| `InputRole` | `string?` | — | — |  |
| `AriaControlsId` | `string?` | — | — |  |
| `AriaExpandedState` | `bool?` | — | — |  |
| `AriaHasPopupType` | `string?` | — | — |  |
| `AriaActiveDescendantId` | `string?` | — | — |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |
| `<Prefix>` |  |
| `<Suffix>` |  |
| `<InputStart>` |  |
| `<InputEnd>` |  |
| `<Hint>` |  |
| `<ErrorMessageContent>` |  |
| `<Popup>` |  |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `ValueChanged` | `EventCallback<string?>` |  |
| `OnValueChange` | `EventCallback<string?>` | Fires whenever the input value changes (on every keystroke). |
| `OnChange` | `EventCallback<string?>` | Fires when the input value is committed (change event / blur). |
| `OnKeyDown` | `EventCallback<KeyboardEventArgs>` | Fires when a key is pressed inside the input. |
| `OnFocus` | `EventCallback<FocusEventArgs>` | Fires when the input is focused. |
| `OnInvalid` | `EventCallback` | Fires when the native input becomes invalid. |

## Cascading values consumed

- CascadedLangId (cascading name: "GupLangId")
- CascadedReadOnly (cascading name: "GupReadOnly")

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Hint

<!-- from GUPBlazorDemo/Components/Pages/.../HintValidation.razor -->
```razor
<GupInputField Name="hv-id" Type="text">
  <ChildContent>Civil ID</ChildContent>
  <Hint>Eight digits, printed on the front of your card.</Hint>
</GupInputField>
```

### Validation message

<!-- from GUPBlazorDemo/Components/Pages/.../HintValidation.razor -->
```razor
<GupInputField Name="hv-email" Type="email" IsInvalid="true"
               ErrorMessage="Enter an email address in the format name@example.com">
  Email address
</GupInputField>
```

### Both together

<!-- from GUPBlazorDemo/Components/Pages/.../HintValidation.razor -->
```razor
<GupInputField Name="hv-both" Type="text" IsInvalid="true"
               ErrorMessage="Enter your Civil ID">
  <ChildContent>Civil ID</ChildContent>
  <Hint>Eight digits, printed on the front of your card.</Hint>
</GupInputField>
```

### Rich error content

<!-- from GUPBlazorDemo/Components/Pages/.../HintValidation.razor -->
```razor
<GupInputField Name="hv-rich" Type="text" IsInvalid="true">
  <ChildContent>Commercial registration number</ChildContent>
  <ErrorMessageContent>
    We could not find that number. <a href="/help">Check the format</a>.
  </ErrorMessageContent>
</GupInputField>
```

### Two way binding bind text

<!-- from GUPBlazorDemo/Components/Pages/.../ScreenReaderText.razor -->
```razor
<GupInputField Name="sr-bound-text"
               @bind-Value="_boundText"
               Placeholder="Type here…">Screenreader text</GupInputField>

<p style="margin:0;">
    <strong>Visible:</strong> The button below has a hidden description —
    <GupScreenReaderText @bind-Text="_boundText" OnRendered="HandleRendered" />
</p>

<p data-testid="bind-output" style="margin:0;">
    <strong>Bound text:</strong> "<span data-testid="bind-value">@_boundText</span>"
    &nbsp;·&nbsp;
    <strong>OnRendered fired:</strong> <span data-testid="render-count">@_renderCount</span> times
</p>
```

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

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-input-field.md`
