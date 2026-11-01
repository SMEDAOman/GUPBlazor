# GupDataSheet

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupDataSheet.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/data-sheet

Bordered card grouping labelled items — order summaries and similar.

## Upstream mapping

```text
Equivalent of <gup-data-sheet> A bordered, padded container — typically used to highlight a group of GupLabelledItem entries (e.g. an order summary), but it can wrap any other content too. Slots: - ChildContent → the content of the data-sheet (default slot) Events: OnClick (also makes the sheet keyboard-focusable / activatable)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `AriaLabel` | `string?` | — | — | Accessible label for the sheet — used when the sheet is clickable. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Content of the data-sheet (typically GupLabelledItem children). |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `OnClick` | `EventCallback<MouseEventArgs>` | Fires when the sheet is clicked or activated by keyboard (Enter/Space). |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default any content

<!-- from GUPBlazorDemo/Components/Pages/.../DataSheet.razor -->
```razor
<GupDataSheet>
    <ChildContent>
        Usually this component is used with labelled items, but it can be also used to highlight
        any other content.
    </ChildContent>
</GupDataSheet>
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
