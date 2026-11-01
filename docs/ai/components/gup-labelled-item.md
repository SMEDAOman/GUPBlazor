# GupLabelledItem

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupLabelledItem.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/labelled-item

Part of the Labelled item component set — see the Labelled item page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-labelled-item> A generic component to label any static content. Produces a form-item-like layout with a label above the content. Used inside GupDataSheet but also on its own to display read-only data. Parameters / slots: - Label         (string, two-way bindable) → simple text label - LabelContent  (RenderFragment)           → richer label content (overrides Label) - IconContent   (RenderFragment)           → optional icon next to the content (use a GupIcon) - ChildContent  (RenderFragment)           → the content being labelled (default slot) Events: OnClick — fires when the labelled item is activated.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Label` | `string?` | — | `@bind-Label` | Plain-text label. Use `LabelContent` for richer content. |
| `AriaLabel` | `string?` | — | — | Accessible label for the item — used when the item is clickable. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<LabelContent>` | Rich label content — takes precedence over `Label` when set. |
| `<IconContent>` | Optional icon rendered next to the value (insert a GupIcon). |
| `<ChildContent>` | The labelled value / content (default slot). |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `LabelChanged` | `EventCallback<string?>` |  |
| `OnClick` | `EventCallback<MouseEventArgs>` | Fires when the item is clicked or activated by keyboard (Enter/Space). |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Basic

<!-- from GUPBlazorDemo/Components/Pages/.../LabelledItem.razor -->
```razor
<GupLabelledItem Label="Full name">Ahmed Al Balushi</GupLabelledItem>
<GupLabelledItem Label="Civil ID">1234567</GupLabelledItem>
<GupLabelledItem Label="Application date">12 October 2026</GupLabelledItem>
```

### With an icon

<!-- from GUPBlazorDemo/Components/Pages/.../LabelledItem.razor -->
```razor
<GupLabelledItem Label="Phone number">
  <IconContent><GupIcon IconName="call" Width="20" Height="20" /></IconContent>
  <ChildContent>+968 9000 0000</ChildContent>
</GupLabelledItem>
```

### In a summary layout

<!-- from GUPBlazorDemo/Components/Pages/.../LabelledItem.razor -->
```razor
<GupLabelledItem Label="Service">Commercial licence renewal</GupLabelledItem>
<GupLabelledItem Label="Reference">OM-2026-4471</GupLabelledItem>
<GupLabelledItem Label="Status">
  <GupBadge Type="GupBadgeType.Positive" />
  Approved
</GupLabelledItem>
```

### With labelled items

<!-- from GUPBlazorDemo/Components/Pages/.../DataSheet.razor -->
```razor
<GupDataSheet>
    <ChildContent>
        <GupLabelledItem Label="Selected service">
            <ChildContent>Service name</ChildContent>
        </GupLabelledItem>
        <GupLabelledItem Label="Amount to pay">
            <IconContent>
                <GupIcon IconName="receipt" Width="30" Height="30" />
            </IconContent>
            <ChildContent>15 OMR</ChildContent>
        </GupLabelledItem>
    </ChildContent>
</GupDataSheet>
```

### Rich label content

<!-- from GUPBlazorDemo/Components/Pages/.../DataSheet.razor -->
```razor
<GupDataSheet>
    <ChildContent>
        <GupLabelledItem>
            <LabelContent>
                <span style="display:inline-flex; align-items:center; gap:6px;">
                    <GupIcon IconName="badge" Width="16" Height="16" /> Applicant ID
                </span>
            </LabelContent>
            <ChildContent>OM-2026-001234</ChildContent>
        </GupLabelledItem>
        <GupLabelledItem>
            <LabelContent>
                <span style="display:inline-flex; align-items:center; gap:6px;">
                    <GupIcon IconName="event" Width="16" Height="16" /> Submitted on
                </span>
            </LabelContent>
            <ChildContent>5 May 2026</ChildContent>
        </GupLabelledItem>
    </ChildContent>
</GupDataSheet>
```

### Rtl arabic

<!-- from GUPBlazorDemo/Components/Pages/.../DataSheet.razor -->
```razor
<GupDataSheet>
    <ChildContent>
        <GupLabelledItem Label="الخدمة المختارة">
            <ChildContent>اسم الخدمة</ChildContent>
        </GupLabelledItem>
        <GupLabelledItem Label="المبلغ المستحق">
            <IconContent>
                <GupIcon IconName="receipt" Width="30" Height="30" />
            </IconContent>
            <ChildContent>١٥ ر.ع</ChildContent>
        </GupLabelledItem>
    </ChildContent>
</GupDataSheet>
```

### Click events

<!-- from GUPBlazorDemo/Components/Pages/.../DataSheet.razor -->
```razor
<GupDataSheet AriaLabel="Order summary"
              OnClick="HandleSheetClick">
    <ChildContent>
        <GupLabelledItem Label="Service"
                         AriaLabel="Edit service"
                         OnClick="HandleItemClick">
            <ChildContent>Click me — labelled item</ChildContent>
        </GupLabelledItem>
        <GupLabelledItem Label="Total">
            <ChildContent>Click outside any item — bubbles to the sheet</ChildContent>
        </GupLabelledItem>
    </ChildContent>
</GupDataSheet>

<p data-testid="click-log" style="margin:0;">
    Sheet clicks: <strong data-testid="sheet-clicks">@_sheetClicks</strong> ·
    Item clicks: <strong data-testid="item-clicks">@_itemClicks</strong>
</p>
```

### Two way binding bind label

<!-- from GUPBlazorDemo/Components/Pages/.../DataSheet.razor -->
```razor
<input data-testid="bind-input"
       type="text"
       value="@_boundLabel"
       @oninput="OnBoundLabelInput"
       style="padding:8px 12px; border:1px solid var(--gup-color-border-low); border-radius:8px;" />

<GupDataSheet>
    <ChildContent>
        <GupLabelledItem @bind-Label="_boundLabel">
            <ChildContent>Bound value renders here.</ChildContent>
        </GupLabelledItem>
    </ChildContent>
</GupDataSheet>

<p data-testid="bind-output" style="margin:0;">
    Bound label: <strong>@_boundLabel</strong>
</p>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
