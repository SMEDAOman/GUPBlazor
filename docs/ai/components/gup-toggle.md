# GupToggle

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupToggle.razor`
> Live demo: /demo/inputs/toggle

On/off switch with label and hint.

## Upstream mapping

```text
Equivalent of <gup-toggle name="..." checked disabled readonly knob-location="before|after"> Two-way binding: @bind-Checked Events: OnChange (new checked state)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Name` | `string` | `"" (empty)` | — |  |
| `Checked` | `bool` | — | `@bind-Checked` |  |
| `Disabled` | `bool` | — | — |  |
| `Readonly` | `bool` | — | — |  |
| `KnobLocation` | `string` | `"before"` | — | "before" (default) renders knob before the text, "after" renders knob after the text. |
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
| `OnChange` | `EventCallback<bool>` | Fires whenever the toggle is changed by the user. |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Unchecked

<!-- from GUPBlazorDemo/Components/Pages/.../Toggle.razor -->
```razor
<GupToggle Name="t-default">
    <ChildContent>Default</ChildContent>
</GupToggle>
```

### Checked

<!-- from GUPBlazorDemo/Components/Pages/.../Toggle.razor -->
```razor
<GupToggle Name="t-checked" Checked="true">
    <ChildContent>Default</ChildContent>
</GupToggle>
```

### Knob before (default)

<!-- from GUPBlazorDemo/Components/Pages/.../Toggle.razor -->
```razor
<GupToggle Name="t-knob-before" KnobLocation="before">
    <ChildContent>Knob before label</ChildContent>
</GupToggle>
```

### Knob after

<!-- from GUPBlazorDemo/Components/Pages/.../Toggle.razor -->
```razor
<GupToggle Name="t-knob-after" KnobLocation="after">
    <ChildContent>Knob after label</ChildContent>
</GupToggle>
```

### Unchecked + disabled

<!-- from GUPBlazorDemo/Components/Pages/.../Toggle.razor -->
```razor
<GupToggle Name="t-disabled" Disabled="true">
    <ChildContent>This option is disabled</ChildContent>
</GupToggle>
```

### Checked + disabled

<!-- from GUPBlazorDemo/Components/Pages/.../Toggle.razor -->
```razor
<GupToggle Name="t-checked-disabled" Checked="true" Disabled="true">
    <ChildContent>Checked &amp; disabled</ChildContent>
</GupToggle>
```

### Readonly, unchecked

<!-- from GUPBlazorDemo/Components/Pages/.../Toggle.razor -->
```razor
<GupToggle Name="t-readonly" Readonly="true">
    <ChildContent>Readonly toggle</ChildContent>
    <Hint>You can focus me, but I can't be changed.</Hint>
</GupToggle>
```

### Readonly, checked

<!-- from GUPBlazorDemo/Components/Pages/.../Toggle.razor -->
```razor
<GupToggle Name="t-readonly-checked" Readonly="true" Checked="true">
    <ChildContent>Readonly &amp; checked</ChildContent>
</GupToggle>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-toggle.md`
