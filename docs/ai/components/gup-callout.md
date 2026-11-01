# GupCallout

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupCallout.razor`
> Live demo: /demo/callout

Block quote with optional author, in three appearances.

## Upstream mapping

```text
Equivalent of <gup-callout appearance="default|background|border"> A callout / blockquote with an optional title and footer (e.g. an author name). Slots: - TitleContent  → rendered as a heading next to a quote icon (header) - ChildContent  → main body of the callout (default slot) - FooterContent → optional footer (e.g. attribution) Two-way binding: @bind-Appearance Events: OnClick
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Appearance` | `GupCalloutAppearance` | `GupCalloutAppearance.Default` | `@bind-Appearance` | Visual appearance — default (left border), background (filled), or border (outlined). |
| `AriaLabel` | `string?` | — | — | Accessible label for the callout — used when the callout is clickable. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<TitleContent>` | Optional title — rendered next to a quote icon. |
| `<ChildContent>` | Main body of the callout. |
| `<FooterContent>` | Optional footer — typically an author or attribution. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `AppearanceChanged` | `EventCallback<GupCalloutAppearance>` |  |
| `OnClick` | `EventCallback<MouseEventArgs>` | Fires when the callout is clicked or activated by keyboard (Enter/Space). |

## Enums

### `GupCalloutAppearance`

- `GupCalloutAppearance.Default`
- `GupCalloutAppearance.Background`
- `GupCalloutAppearance.Border`

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default (left border)

<!-- from GUPBlazorDemo/Components/Pages/.../Callout.razor -->
```razor
<GupCallout Appearance="@GupCalloutAppearance.Default">
    <TitleContent>Quote title</TitleContent>
    <ChildContent>It is a long established fact that a reader will be distracted by the readable
        content of a page when looking at its layout.</ChildContent>
    <FooterContent>- Author</FooterContent>
</GupCallout>
```

### Background (filled)

<!-- from GUPBlazorDemo/Components/Pages/.../Callout.razor -->
```razor
<GupCallout Appearance="@GupCalloutAppearance.Background">
    <TitleContent>Quote title</TitleContent>
    <ChildContent>It is a long established fact that a reader will be distracted by the readable
        content of a page when looking at its layout.</ChildContent>
    <FooterContent>- Author</FooterContent>
</GupCallout>
```

### Border (outlined)

<!-- from GUPBlazorDemo/Components/Pages/.../Callout.razor -->
```razor
<GupCallout Appearance="@GupCalloutAppearance.Border">
    <TitleContent>Quote title</TitleContent>
    <ChildContent>It is a long established fact that a reader will be distracted by the readable
        content of a page when looking at its layout.</ChildContent>
    <FooterContent>- Author</FooterContent>
</GupCallout>
```

### Attribution

<!-- from GUPBlazorDemo/Components/Pages/.../Flag.razor -->
```razor
<GupCallout>
    Flag artwork comes from the
    <a href="https://github.com/lipis/flag-icons">flag-icons</a> project,
    MIT licensed. The licence ships with the package at
    <code>_content/GUPBlazor/flags/LICENSE.txt</code>.
</GupCallout>
```

### Accessibility

<!-- from GUPBlazorDemo/Components/Pages/.../SkipLink.razor -->
```razor
<GupCallout>
    The link is hidden with the <code>screenreader-text</code> clip pattern
    rather than <code>display:none</code>, so it stays in the focus order and
    in the accessibility tree. Never hide it in a way that removes it from
    the tab sequence.
</GupCallout>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-callout.md`
