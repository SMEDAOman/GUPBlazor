# GupTextarea

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupTextarea.razor`
> Live demo: /demo/inputs/textarea

Part of the Textarea field component set — see the Textarea field page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-textarea-field name="..." rows="...">Label</gup-textarea-field> Two-way binding: @bind-Value Events: OnValueChange (fires on every input), OnChange (fires on change/blur)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Name` | `string` | `"" (empty)` | — |  |
| `Placeholder` | `string?` | — | — |  |
| `Value` | `string?` | — | `@bind-Value` |  |
| `Disabled` | `bool` | — | — |  |
| `Readonly` | `bool` | — | — |  |
| `Required` | `bool` | `true` | — |  |
| `Rows` | `int` | `4` | — |  |
| `Minlength` | `int?` | — | — |  |
| `Maxlength` | `int?` | — | — |  |
| `ErrorMessage` | `string?` | — | — |  |
| `IsInvalid` | `bool` | — | — |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |
| `<HintContent>` |  |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `ValueChanged` | `EventCallback<string?>` |  |
| `OnValueChange` | `EventCallback<string?>` | Fires whenever the textarea value changes (on every input event). |
| `OnChange` | `EventCallback<string?>` | Fires when the textarea value changes and loses focus. |
| `OnKeyPress` | `EventCallback<KeyboardEventArgs>` | Fires when a key is pressed inside the textarea. |
| `OnInvalid` | `EventCallback` | Fires when the textarea enters the invalid state (matches `gup-invalid`). |

## Cascading values consumed

- CascadedReadOnly (cascading name: "GupReadOnly")
- CascadedLangId (cascading name: "GupLangId")

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default

<!-- from GUPBlazorDemo/Components/Pages/.../Textarea.razor -->
```razor
<GupFormList>
    <GupTextarea Name="msg-default">Your message</GupTextarea>
</GupFormList>
```

### With placeholder

<!-- from GUPBlazorDemo/Components/Pages/.../Textarea.razor -->
```razor
<GupFormList>
    <GupTextarea Name="msg-placeholder" Placeholder="Type your message here...">Your message</GupTextarea>
</GupFormList>
```

### Pre-filled

<!-- from GUPBlazorDemo/Components/Pages/.../Textarea.razor -->
```razor
<GupFormList>
    <GupTextarea Name="msg-value" Value="This is some pre-filled message text.">Your message</GupTextarea>
</GupFormList>
```

### Read-only

<!-- from GUPBlazorDemo/Components/Pages/.../Textarea.razor -->
```razor
<GupFormList>
    <GupTextarea Name="msg-readonly" Value="This message cannot be edited." Readonly="true">Read-only message</GupTextarea>
</GupFormList>
```

### Disabled

<!-- from GUPBlazorDemo/Components/Pages/.../Textarea.razor -->
```razor
<GupFormList>
    <GupTextarea Name="msg-disabled" Disabled="true">Disabled message</GupTextarea>
</GupFormList>
```

### 2 rows

<!-- from GUPBlazorDemo/Components/Pages/.../Textarea.razor -->
```razor
<GupFormList>
    <GupTextarea Name="msg-rows-2" Rows="2">Short message</GupTextarea>
</GupFormList>
```

### 4 rows (default)

<!-- from GUPBlazorDemo/Components/Pages/.../Textarea.razor -->
```razor
<GupFormList>
    <GupTextarea Name="msg-rows-4" Rows="4">Standard message</GupTextarea>
</GupFormList>
```

### 10 rows

<!-- from GUPBlazorDemo/Components/Pages/.../Textarea.razor -->
```razor
<GupFormList>
    <GupTextarea Name="msg-rows-10" Rows="10">Long message</GupTextarea>
</GupFormList>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-textarea.md`
