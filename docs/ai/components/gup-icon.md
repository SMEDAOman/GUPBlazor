# GupIcon

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupIcon.razor`
> Live demo: /demo/icons

Part of the Icons component set — see the Icons page for how it composes.

## Upstream mapping

```text
Renders a Material Symbols Outlined icon via the Google variable font.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `IconName` | `string` | `"" (empty)` | — |  |
| `Width` | `int` | `16` | — |  |
| `Height` | `int` | `16` | — |  |
| `Filled` | `bool` | `false` | — |  |
| `Weight` | `int` | `400` | — |  |
| `Grade` | `int` | `0` | — |  |
| `RtlFlipEnabled` | `bool` | — | — | Flip the icon horizontally in RTL layouts (matches `rtl-flip-enabled`). |
| `FillColor` | `string?` | — | — | Fill color in any CSS format (matches `fill-color` / `--gup-icon--fill-color`). |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Icon color follows the button variant via per context css

<!-- from GUPBlazorDemo/Components/Pages/.../Icons.razor -->
```razor
<GupButton Appearance="@GupButtonAppearance.Primary">
  <IconStart><GupIcon IconName="download" Width="20" /></IconStart>
  <ChildContent>Download</ChildContent>
</GupButton>
<GupButton Appearance="@GupButtonAppearance.Secondary">
  <IconStart><GupIcon IconName="edit" Width="20" /></IconStart>
  <ChildContent>Edit</ChildContent>
</GupButton>
<GupButton Appearance="@GupButtonAppearance.Text">
  <ChildContent>Continue</ChildContent>
  <IconEnd><GupIcon IconName="arrow_forward" Width="20" /></IconEnd>
</GupButton>
<GupButton Appearance="@GupButtonAppearance.Primary" Disabled="true">
  <IconStart><GupIcon IconName="lock" Width="20" /></IconStart>
  <ChildContent>Disabled</ChildContent>
</GupButton>
```

### Glyph inherits css color from its parent

<!-- from GUPBlazorDemo/Components/Pages/.../Icons.razor -->
```razor
<div class="icon-tile" style="color: var(--gup-color-brand-xhigh);">
  <GupIcon IconName="palette" Width="32" />
  <code>brand-xhigh</code>
</div>
<div class="icon-tile" style="color: var(--gup-color-positive-high);">
  <GupIcon IconName="check_circle" Width="32" Filled="true" />
  <code>positive-high</code>
</div>
<div class="icon-tile" style="color: var(--gup-color-warning-high);">
  <GupIcon IconName="warning" Width="32" Filled="true" />
  <code>warning-high</code>
</div>
<div class="icon-tile" style="color: var(--gup-color-negative-high);">
  <GupIcon IconName="error" Width="32" Filled="true" />
  <code>negative-high</code>
</div>
```

### With an icon

<!-- from GUPBlazorDemo/Components/Pages/.../LabelledItem.razor -->
```razor
<GupLabelledItem Label="Phone number">
  <IconContent><GupIcon IconName="call" Width="20" Height="20" /></IconContent>
  <ChildContent>+968 9000 0000</ChildContent>
</GupLabelledItem>
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

### Wizard footer

<!-- from GUPBlazorDemo/Components/Pages/.../Wizard.razor -->
```razor
<GupWizardFooter>
  <Start>
    <GupButton Appearance="GupButtonAppearance.Secondary">
      <IconStart><GupIcon IconName="arrow-back" Width="20" Height="20" /></IconStart>
      <ChildContent>Back</ChildContent>
    </GupButton>
  </Start>
  <End>
    <GupButton Appearance="GupButtonAppearance.Primary">
      <ChildContent>Continue</ChildContent>
      <IconEnd><GupIcon IconName="arrow-forward" Width="20" Height="20" /></IconEnd>
    </GupButton>
  </End>
</GupWizardFooter>
```

### With start end icons

<!-- from GUPBlazorDemo/Components/Pages/.../Tabs.razor -->
```razor
<GupTabs Appearance="GupTabsAppearance.Default">
    <GupTabsNavigation>
        <GupTab Label="Inbox">
            <IconStart><GupIcon IconName="inbox" Width="20" Height="20" /></IconStart>
            <ChildContent>Inbox</ChildContent>
        </GupTab>
        <GupTab Label="Drafts">
            <IconStart><GupIcon IconName="edit_document" Width="20" Height="20" /></IconStart>
            <ChildContent>Drafts</ChildContent>
        </GupTab>
        <GupTab Label="Sent">
            <IconStart><GupIcon IconName="send" Width="20" Height="20" /></IconStart>
            <ChildContent>Sent</ChildContent>
        </GupTab>
    </GupTabsNavigation>
    <GupTabPanel><ChildContent>You have 3 unread messages.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>2 drafts saved.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>No sent messages today.</ChildContent></GupTabPanel>
</GupTabs>
```

### With an account area

<!-- from GUPBlazorDemo/Components/Pages/.../HeaderDemo.razor -->
```razor
<GupHeader>
  <End>
    <GupTrack Gap="3" VerticalAlignment="center">
      <GupButton Appearance="GupButtonAppearance.Text">
        <IconStart><GupIcon IconName="language" Width="20" Height="20" /></IconStart>
        <ChildContent>العربية</ChildContent>
      </GupButton>
      <GupAvatar Label="Ahmed Al Balushi" />
    </GupTrack>
  </End>
</GupHeader>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-icon.md`
