# GupTab

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupTab.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/tabs

Part of the Tabs component set — see the Tabs page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-tab disabled selected> A single tab button. When nested inside a GupTabs, the parent's SelectedIndex drives the selected state — clicking the tab asks the parent to switch. Slots: - ChildContent  → button label - IconStart     → icon shown before the label - IconEnd       → icon shown after the label Events: - OnClick → fires when this tab is clicked (disabled tabs do not fire it)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Disabled` | `bool` | — | — | Whether the tab is disabled. Disabled tabs cannot be selected via click. |
| `Selected` | `bool` | — | — | Initial selected state. When nested inside a `GupTabs` this only acts as a pre-selection hint — the parent owns the runtime selected state. |
| `Label` | `string?` | — | — | Plain-text label, used as the bold sizing twin for the default/toggle appearances. |

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
| `OnClick` | `EventCallback` | Fires when the tab is clicked (disabled tabs do not fire). |

## Cascading values consumed

- Tabs

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default appearance

<!-- from GUPBlazorDemo/Components/Pages/.../Tabs.razor -->
```razor
<GupTabs Appearance="GupTabsAppearance.Default">
    <GupTabsNavigation>
        <GupTab Label="First tab"><ChildContent>First tab</ChildContent></GupTab>
        <GupTab Label="Second tab"><ChildContent>Second tab</ChildContent></GupTab>
        <GupTab Label="Third tab"><ChildContent>Third tab</ChildContent></GupTab>
    </GupTabsNavigation>
    <GupTabPanel><ChildContent>Panel for first tab</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>Panel for second tab</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>Panel for third tab</ChildContent></GupTabPanel>
</GupTabs>
```

### Default full width

<!-- from GUPBlazorDemo/Components/Pages/.../Tabs.razor -->
```razor
<GupTabs Appearance="GupTabsAppearance.Default" IsFullWidth="true">
    <GupTabsNavigation>
        <GupTab Label="Overview"><ChildContent>Overview</ChildContent></GupTab>
        <GupTab Label="Details"><ChildContent>Details</ChildContent></GupTab>
        <GupTab Label="History"><ChildContent>History</ChildContent></GupTab>
    </GupTabsNavigation>
    <GupTabPanel><ChildContent>Service overview content.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>Detailed service description.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>Service request history.</ChildContent></GupTabPanel>
</GupTabs>
```

### Toggle appearance

<!-- from GUPBlazorDemo/Components/Pages/.../Tabs.razor -->
```razor
<GupTabs Appearance="GupTabsAppearance.Toggle">
    <GupTabsNavigation>
        <GupTab Label="Day"><ChildContent>Day</ChildContent></GupTab>
        <GupTab Label="Week"><ChildContent>Week</ChildContent></GupTab>
        <GupTab Label="Month"><ChildContent>Month</ChildContent></GupTab>
    </GupTabsNavigation>
    <GupTabPanel><ChildContent>Showing today's activity.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>Showing this week's activity.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>Showing this month's activity.</ChildContent></GupTabPanel>
</GupTabs>
```

### Toggle full width

<!-- from GUPBlazorDemo/Components/Pages/.../Tabs.razor -->
```razor
<GupTabs Appearance="GupTabsAppearance.Toggle" IsFullWidth="true">
    <GupTabsNavigation>
        <GupTab Label="Cards"><ChildContent>Cards</ChildContent></GupTab>
        <GupTab Label="List"><ChildContent>List</ChildContent></GupTab>
    </GupTabsNavigation>
    <GupTabPanel><ChildContent>Card layout selected.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>List layout selected.</ChildContent></GupTabPanel>
</GupTabs>
```

### Vertical appearance

<!-- from GUPBlazorDemo/Components/Pages/.../Tabs.razor -->
```razor
<GupTabs Appearance="GupTabsAppearance.Vertical">
    <GupTabsNavigation>
        <GupTab Label="Profile"><ChildContent>Profile</ChildContent></GupTab>
        <GupTab Label="Notifications"><ChildContent>Notifications</ChildContent></GupTab>
        <GupTab Label="Security"><ChildContent>Security</ChildContent></GupTab>
        <GupTab Label="Privacy"><ChildContent>Privacy</ChildContent></GupTab>
    </GupTabsNavigation>
    <GupTabPanel><ChildContent>Profile settings panel.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>Notification settings panel.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>Security settings panel.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>Privacy settings panel.</ChildContent></GupTabPanel>
</GupTabs>
```

### Disabled tab pre selection

<!-- from GUPBlazorDemo/Components/Pages/.../Tabs.razor -->
```razor
<GupTabs Appearance="GupTabsAppearance.Default">
    <GupTabsNavigation>
        <GupTab Label="Step 1"><ChildContent>Step 1</ChildContent></GupTab>
        <GupTab Label="Step 2" Selected="true"><ChildContent>Step 2 (preselected)</ChildContent></GupTab>
        <GupTab Label="Step 3" Disabled="true"><ChildContent>Step 3 (disabled)</ChildContent></GupTab>
    </GupTabsNavigation>
    <GupTabPanel><ChildContent>Panel one.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>Panel two — this opens by default.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>Panel three.</ChildContent></GupTabPanel>
</GupTabs>
```

### Two way binding bind selectedindex events

<!-- from GUPBlazorDemo/Components/Pages/.../Tabs.razor -->
```razor
<GupTabs Appearance="GupTabsAppearance.Default"
         @bind-SelectedIndex="_boundIndex"
         OnSelectedIndexChange="HandleIndexChange">
    <GupTabsNavigation>
        <GupTab Label="Tab A"><ChildContent>Tab A</ChildContent></GupTab>
        <GupTab Label="Tab B"><ChildContent>Tab B</ChildContent></GupTab>
        <GupTab Label="Tab C"><ChildContent>Tab C</ChildContent></GupTab>
    </GupTabsNavigation>
    <GupTabPanel><ChildContent>Content for tab A.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>Content for tab B.</ChildContent></GupTabPanel>
    <GupTabPanel><ChildContent>Content for tab C.</ChildContent></GupTabPanel>
</GupTabs>

<div style="display:flex; gap:8px; flex-wrap:wrap;">
    <GupButton Appearance="GupButtonAppearance.Secondary" Kind="GupButtonKind.Button"
               OnClick="@(() => _boundIndex = 0)">
        <ChildContent>Select A</ChildContent>
    </GupButton>
    <GupButton Appearance="GupButtonAppearance.Secondary" Kind="GupButtonKind.Button"
               OnClick="@(() => _boundIndex = 1)">
        <ChildContent>Select B</ChildContent>
    </GupButton>
    <GupButton Appearance="GupButtonAppearance.Secondary" Kind="GupButtonKind.Button"
               OnClick="@(() => _boundIndex = 2)">
        <ChildContent>Select C</ChildContent>
    </GupButton>
</div>

<div data-testid="bind-output" style="display:flex; flex-direction:column; gap:4px; margin:0;">
    <p style="margin:0;">
        <strong>Bound index:</strong>
        <span data-testid="bind-index">@_boundIndex</span>
    </p>
    <p style="margin:0;">
        <strong>OnSelectedIndexChange:</strong>
        fired <span data-testid="change-count">@_indexChangeCount</span> times
        &nbsp;·&nbsp;
        <strong>Last index:</strong>
        <span data-testid="last-index">@_lastIndex</span>
    </p>
</div>
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

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
