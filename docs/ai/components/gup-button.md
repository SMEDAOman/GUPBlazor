# GupButton

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupButton.razor`
> Live demo: /demo/buttons

Button appearances, icons, disabled states, and button groups.

## Upstream mapping

```text
Equivalent of <gup-button appearance="primary|secondary|text|danger" kind="button|link" ...> Named slots: IconStart, IconEnd Default slot: ChildContent (button label)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Appearance` | `GupButtonAppearance` | `GupButtonAppearance.Primary` | — |  |
| `Kind` | `GupButtonKind` | `GupButtonKind.Button` | — |  |
| `Type` | `GupButtonType` | `GupButtonType.Button` | — |  |
| `Href` | `string?` | — | — |  |
| `Disabled` | `bool` | — | — |  |
| `SoftDisabled` | `bool` | — | — | Renders the button with the disabled *appearance* (greyed) while keeping it fully interactive — the click still fires. Use for "looks disabled until the form is valid, but pressing it reveals what's missing" affordances. Ignored when `Disabled` is true (a real disable wins). |
| `WithIconOnly` | `bool` | — | — | Display only the icon with no text label (matches `with-icon-only`). Provide `Label` for the accessible name. |
| `Inverted` | `bool` | — | — | Whether the button is inverted (for dark backgrounds). |
| `Label` | `string` | `"" (empty)` | — | Accessible label used when `WithIconOnly` is true. |
| `OpenInNewTab` | `bool` | — | — | Open the URL in a new tab. Only applicable when `Kind` is Link. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |
| `<IconStart>` |  |
| `<IconEnd>` |  |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `OnClick` | `EventCallback<MouseEventArgs>` |  |

## Enums

### `GupButtonAppearance`

Visual style of a `GupButton`.

- `GupButtonAppearance.Primary`
- `GupButtonAppearance.Secondary`
- `GupButtonAppearance.Text`
- `GupButtonAppearance.Danger`

### `GupButtonKind`

Whether a `GupButton` renders as a button or an anchor.

- `GupButtonKind.Button`
- `GupButtonKind.Link`

### `GupButtonType`

The HTML `type` attribute of a `GupButton`.

- `GupButtonType.Button`
- `GupButtonType.Submit`
- `GupButtonType.Reset`

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Appearances

<!-- from GUPBlazorDemo/Components/Pages/.../Buttons.razor -->
```razor
<GupButton Appearance="@GupButtonAppearance.Primary" OnClick="ButtonClicked">Primary</GupButton>
<GupButton Appearance="@GupButtonAppearance.Secondary" OnClick="ButtonClicked">Secondary</GupButton>
<GupButton Appearance="@GupButtonAppearance.Text" OnClick="ButtonClicked">Text</GupButton>
<GupButton Appearance="@GupButtonAppearance.Danger" OnClick="ButtonClicked">Danger</GupButton>
```

### With icons

<!-- from GUPBlazorDemo/Components/Pages/.../Buttons.razor -->
```razor
<GupButton Appearance="@GupButtonAppearance.Primary" OnClick="ButtonClicked">
  <IconStart><GupIcon IconName="arrow-back" Width="20" Height="20" /></IconStart>
  <ChildContent>Icon Start</ChildContent>
</GupButton>
<GupButton Appearance="@GupButtonAppearance.Primary" OnClick="ButtonClicked">
  <ChildContent>Icon End</ChildContent>
  <IconEnd><GupIcon IconName="arrow-forward" Width="20" Height="20" /></IconEnd>
</GupButton>
<GupButton Appearance="@GupButtonAppearance.Secondary" OnClick="ButtonClicked">
  <IconStart><GupIcon IconName="close" Width="20" Height="20" /></IconStart>
  <ChildContent>Cancel</ChildContent>
</GupButton>
<GupButton Appearance="@GupButtonAppearance.Text" OnClick="ButtonClicked">
  <IconStart><GupIcon IconName="live-help" Width="20" Height="20" /></IconStart>
  <ChildContent>Need help?</ChildContent>
</GupButton>
```

### Disabled state

<!-- from GUPBlazorDemo/Components/Pages/.../Buttons.razor -->
```razor
<GupButton Appearance="@GupButtonAppearance.Primary" Disabled="true" OnClick="ButtonClicked">Primary disabled</GupButton>
<GupButton Appearance="@GupButtonAppearance.Secondary" Disabled="true" OnClick="ButtonClicked">Secondary disabled</GupButton>
<GupButton Appearance="@GupButtonAppearance.Text" Disabled="true" OnClick="ButtonClicked">Text disabled</GupButton>
<GupButton Appearance="@GupButtonAppearance.Primary" Disabled="true" OnClick="ButtonClicked">
  <ChildContent>Disabled with icon</ChildContent>
  <IconEnd><GupIcon IconName="arrow-forward" Width="20" Height="20" /></IconEnd>
</GupButton>
```

### Kind=link (renders as <a>)

<!-- from GUPBlazorDemo/Components/Pages/.../Buttons.razor -->
```razor
<GupButton Appearance="@GupButtonAppearance.Primary" Kind="@GupButtonKind.Link" Href="#" OnClick="ButtonClicked">Link Primary</GupButton>
<GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Link" Href="#" OnClick="ButtonClicked">Link Secondary</GupButton>
<GupButton Appearance="@GupButtonAppearance.Text" Kind="@GupButtonKind.Link"  OnClick="ButtonClicked">Link Text</GupButton>
```

### Button Group

<!-- from GUPBlazorDemo/Components/Pages/.../Buttons.razor -->
```razor
<GupButtonGroup>
  <GupButton Appearance="@GupButtonAppearance.Primary" OnClick="ButtonClicked">Submit Application</GupButton>
  <GupButton Appearance="@GupButtonAppearance.Secondary" OnClick="ButtonClicked">Save Draft</GupButton>
  <GupButton Appearance="@GupButtonAppearance.Text" OnClick="ButtonClicked">Cancel</GupButton>
</GupButtonGroup>
```

### Horizontal default

<!-- from GUPBlazorDemo/Components/Pages/.../ButtonGroup.razor -->
```razor
<GupButtonGroup>
  <GupButton Appearance="GupButtonAppearance.Primary">Continue</GupButton>
  <GupButton Appearance="GupButtonAppearance.Secondary">Save as draft</GupButton>
  <GupButton Appearance="GupButtonAppearance.Text">Cancel</GupButton>
</GupButtonGroup>
```

### Vertical

<!-- from GUPBlazorDemo/Components/Pages/.../ButtonGroup.razor -->
```razor
<GupButtonGroup Direction="vertical">
  <GupButton Appearance="GupButtonAppearance.Primary">Continue</GupButton>
  <GupButton Appearance="GupButtonAppearance.Secondary">Save as draft</GupButton>
  <GupButton Appearance="GupButtonAppearance.Text">Cancel</GupButton>
</GupButtonGroup>
```

### With icons

<!-- from GUPBlazorDemo/Components/Pages/.../ButtonGroup.razor -->
```razor
<GupButtonGroup>
  <GupButton Appearance="GupButtonAppearance.Secondary">
    <IconStart><GupIcon IconName="arrow-back" Width="20" Height="20" /></IconStart>
    <ChildContent>Back</ChildContent>
  </GupButton>
  <GupButton Appearance="GupButtonAppearance.Primary">
    <ChildContent>Continue</ChildContent>
    <IconEnd><GupIcon IconName="arrow-forward" Width="20" Height="20" /></IconEnd>
  </GupButton>
</GupButtonGroup>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-button.md`
