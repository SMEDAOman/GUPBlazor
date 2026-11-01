# GupBanner

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupBanner.razor`
> Live demo: /demo/banner

Page-level messages in four severities, outline and filled appearances.

## Upstream mapping

```text
Equivalent of <gup-banner type="neutral|success|warning|error" appearance="outline|filled" hide-icon show-close-button> Named slots: TitleContent (upstream's Title), ChildContent (body), ActionButtons (typically two GupButtons) Events: OnClose (fires when the close button is clicked — matches gup-close)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Type` | `GupBannerType` | `GupBannerType.Neutral` | — | Status of the banner. Default: `neutral`. |
| `Appearance` | `GupBannerAppearance` | `GupBannerAppearance.Outline` | — | Visual style — outline (default) or filled. |
| `HideIcon` | `bool` | — | — | Hide the leading status icon. Default: false. |
| `ShowCloseButton` | `bool` | — | — | Display the close button. Default: false (matches the design-system default). |
| `CloseLabel` | `string` | `"Close"` | — | Accessible label for the close button. Only relevant if `ShowCloseButton` is true. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<TitleContent>` |  |
| `<ChildContent>` | Default content. |
| `<ActionButtons>` | Slot for (typically two) `GupButton` action buttons — matches the action-buttons slot. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `OnClose` | `EventCallback` | Fires when the close button is clicked (matches the `gup-close` event). |

## Enums

### `GupBannerType`

Status of a `GupBanner`. Mirrors the `type` attribute on the gov.om `<gup-banner>` design-system component.

- `GupBannerType.Neutral` — Neutral / informational banner (default).
- `GupBannerType.Success` — Success banner.
- `GupBannerType.Warning` — Warning banner.
- `GupBannerType.Error` — Error banner.

### `GupBannerAppearance`

Visual style of a `GupBanner`. Mirrors the `appearance` attribute on the gov.om `<gup-banner>` design-system component.

- `GupBannerAppearance.Outline` — Outlined banner (default).
- `GupBannerAppearance.Filled` — Filled (strong background) banner.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Severities

<!-- from GUPBlazorDemo/Components/Pages/.../Banner.razor -->
```razor
<GupBanner Type="GupBannerType.Neutral">
  <TitleContent>Neutral</TitleContent>
  <ChildContent>Your application has been saved as a draft.</ChildContent>
</GupBanner>
<GupBanner Type="GupBannerType.Success">
  <TitleContent>Success</TitleContent>
  <ChildContent>Your changes have been saved.</ChildContent>
</GupBanner>
<GupBanner Type="GupBannerType.Warning">
  <TitleContent>Warning</TitleContent>
  <ChildContent>Your session will expire in five minutes.</ChildContent>
</GupBanner>
<GupBanner Type="GupBannerType.Error">
  <TitleContent>Error</TitleContent>
  <ChildContent>We could not process your request. Please try again.</ChildContent>
</GupBanner>
```

### Filled appearance

<!-- from GUPBlazorDemo/Components/Pages/.../Banner.razor -->
```razor
<GupBanner Type="GupBannerType.Success" Appearance="GupBannerAppearance.Filled">
  <TitleContent>Submitted</TitleContent>
  <ChildContent>Reference number OM-2026-4471.</ChildContent>
</GupBanner>
<GupBanner Type="GupBannerType.Error" Appearance="GupBannerAppearance.Filled">
  <TitleContent>Payment failed</TitleContent>
  <ChildContent>The card was declined by the issuing bank.</ChildContent>
</GupBanner>
```

### Without an icon

<!-- from GUPBlazorDemo/Components/Pages/.../Banner.razor -->
```razor
<GupBanner Type="GupBannerType.Neutral" HideIcon="true">
  <ChildContent>A plain message with no leading icon.</ChildContent>
</GupBanner>
```

### With actions

<!-- from GUPBlazorDemo/Components/Pages/.../Banner.razor -->
```razor
<GupBanner Type="GupBannerType.Warning">
  <TitleContent>Unsaved changes</TitleContent>
  <ChildContent>You have changes that have not been submitted yet.</ChildContent>
  <ActionButtons>
    <GupButton Appearance="GupButtonAppearance.Primary">Save now</GupButton>
    <GupButton Appearance="GupButtonAppearance.Text">Discard</GupButton>
  </ActionButtons>
</GupBanner>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-banner.md`
