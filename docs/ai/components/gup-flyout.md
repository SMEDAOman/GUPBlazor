# GupFlyout

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupFlyout.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/flyout

Side panel from any edge — the mobile-friendly home for add-row forms.

## Upstream mapping

```text
Equivalent of <gup-flyout heading="..." position="right|left|top|bottom" backdrop hide-close-button> A side / top / bottom panel that slides into view from an edge of the viewport. Slots: ChildContent  — main body content FooterContent — optional footer (typically action buttons) Two-way binding: @bind-IsOpen   — controls visibility (Show/Hide are equivalent) @bind-Position — current edge the panel slides from Events: OnOpen   — fires when the flyout becomes visible OnClose  — fires when the flyout closes (close button, backdrop, or ESC)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Dir` | `string?` | — | — | Explicit text direction ('rtl' or 'ltr'). If omitted, auto-detects from IsRTL or active page context. |
| `IsRTL` | `bool?` | — | — | Whether the flyout is rendered in Right-To-Left direction. |
| `Heading` | `string` | `"" (empty)` | — | Heading text shown in the flyout header. |
| `Position` | `GupFlyoutPosition` | `GupFlyoutPosition.Right` | `@bind-Position` | Edge the flyout slides from. Default: Right. |
| `IsOpen` | `bool` | — | `@bind-IsOpen` | Whether the flyout is open. Supports two-way binding via @@bind-IsOpen. |
| `HideCloseButton` | `bool` | — | — | Hide the built-in close button. ESC and backdrop click still close the flyout unless disabled separately. |
| `CloseLabel` | `string` | `"Close"` | — | Accessible label for the close button. Default: "Close". |
| `Backdrop` | `bool` | `true` | — | Show the dimmed backdrop behind the flyout panel. Default: true. |
| `CloseOnBackdropClick` | `bool` | `true` | — | Whether clicking on the backdrop should close the flyout. Default: true. |
| `CloseOnEscape` | `bool` | `true` | — | Whether pressing ESC should close the flyout. Default: true. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Main body content of the flyout. |
| `<FooterContent>` | Optional footer content (typically action buttons). |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `PositionChanged` | `EventCallback<GupFlyoutPosition>` |  |
| `IsOpenChanged` | `EventCallback<bool>` |  |
| `OnOpen` | `EventCallback` | Fires when the flyout becomes visible. |
| `OnClose` | `EventCallback` | Fires when the flyout closes (close button, backdrop click, or ESC). |

## Enums

### `GupFlyoutPosition`

- `GupFlyoutPosition.Right`
- `GupFlyoutPosition.Left`
- `GupFlyoutPosition.Top`
- `GupFlyoutPosition.Bottom`

## Cascading values consumed

- WizardStack
- CascadedLangId (cascading name: "GupLangId")

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### From the Flyout page template

<!-- from GUPBlazorDemo/Components/Pages/.../Flyout.razor -->
```razor
<GupFlyout Heading="Right flyout"
           @bind-IsOpen="_rightOpen"
           Position="@GupFlyoutPosition.Right"
           OnOpen="@(() => LogEvent("right-open"))"
           OnClose="@(() => LogEvent("right-close"))">
  <ChildContent>
    <div style="display:flex; flex-direction:column; gap:24px;">
      <div style="display:flex; flex-direction:column; gap:4px;">
        <span style="font-size:16px; font-weight:700; line-height:24px;">Civil ID</span>
        <span style="font-size:20px; font-weight:400; line-height:28px;">1034580392</span>
      </div>
      <div style="display:flex; flex-direction:column; gap:4px;">
        <span style="font-size:16px; font-weight:700; line-height:24px;">Expiry Date</span>
        <span style="font-size:20px; font-weight:400; line-height:28px;">01/02/2028</span>
      </div>
      <div style="display:flex; flex-direction:column; gap:4px;">
        <span style="font-size:16px; font-weight:700; line-height:24px;">Full Name</span>
        <span style="font-size:20px; font-weight:400; line-height:28px;">First Name Last Name</span>
      </div>
      <GupTrack Direction="vertical" Gap="2">
        <GupInputField Type="text" Placeholder="Update field">Name</GupInputField>
        <GupInputField Type="email" Placeholder="Update field">Email</GupInputField>
      </GupTrack>
    </div>
  </ChildContent>
  <FooterContent>
    <div style="display:flex; justify-content:flex-end; gap:12px; width:100%;">
      <GupButton Appearance="@GupButtonAppearance.Secondary"
                 OnClick="@(() => CloseFlyout("right-cancel"))">
        <ChildContent>Cancel</ChildContent>
      </GupButton>
      <GupButton Appearance="@GupButtonAppearance.Primary"
                 OnClick="@(() => CloseFlyout("right-save"))">
        <ChildContent>Save changes</ChildContent>
      </GupButton>
    </div>
  </FooterContent>
</GupFlyout>
```

### From the Flyout page template

<!-- from GUPBlazorDemo/Components/Pages/.../Flyout.razor -->
```razor
<GupFlyout Heading="Filters"
           @bind-IsOpen="_leftOpen"
           Position="@GupFlyoutPosition.Left"
           OnOpen="@(() => LogEvent("left-open"))"
           OnClose="@(() => LogEvent("left-close"))">
  <ChildContent>
    <GupTrack Direction="vertical" Gap="2">
      <GupInputField Type="text" Placeholder="Filter A">Filter A</GupInputField>
      <GupInputField Type="text" Placeholder="Filter B">Filter B</GupInputField>
      <GupInputField Type="text" Placeholder="Filter C">Filter C</GupInputField>
    </GupTrack>
  </ChildContent>
  <FooterContent>
    <div style="display:flex; justify-content:space-between; align-items:center; width:100%;">
      <GupButton Appearance="@GupButtonAppearance.Text" Kind="@GupButtonKind.Button"
                 OnClick="@(() => LogEvent("left-clear-all"))">
        <ChildContent>Clear all</ChildContent>
      </GupButton>
      <GupButtonGroup>
        <GupButton Appearance="@GupButtonAppearance.Secondary"
                   OnClick="@(() => CloseFlyout("left-cancel"))">
          <ChildContent>Cancel</ChildContent>
        </GupButton>
        <GupButton Appearance="@GupButtonAppearance.Primary"
                   OnClick="@(() => CloseFlyout("left-apply"))">
          <ChildContent>Apply</ChildContent>
        </GupButton>
      </GupButtonGroup>
    </div>
  </FooterContent>
</GupFlyout>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
