# GupAccordionItem

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupAccordionItem.razor`
> Live demo: /demo/accordion

Part of the Accordion component set — see the Accordion page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-accordion-item open hide-controls label-show="..." label-hide="..."> Two-way binding: @bind-Open Events: OnToggle (new open state) Slots: LabelContent (named "label"), ChildContent (default — collapsible content)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `LabelShow` | `string` | `"Show"` | — | A translatable label for the Show indicator. |
| `LabelHide` | `string` | `"Hide"` | — | A translatable label for the Hide indicator. |
| `Open` | `bool` | — | `@bind-Open` | Whether the accordion item is open. |
| `HideControls` | `bool` | — | — | Whether to hide the show/hide controls. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<LabelContent>` |  |
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `OpenChanged` | `EventCallback<bool>` | Two-way binding callback for Open. |
| `OnToggle` | `EventCallback<bool>` | Fires whenever the item is toggled by the user. Argument is the new open state. |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Standalone item no wrapper

<!-- from GUPBlazorDemo/Components/Pages/.../Accordion.razor -->
```razor
<GupAccordionItem>
    <LabelContent>I am alone</LabelContent>
    <ChildContent>An accordion item can be used outside a GupAccordion wrapper.</ChildContent>
</GupAccordionItem>
```

### Default

<!-- from GUPBlazorDemo/Components/Pages/.../Accordion.razor -->
```razor
<GupAccordion>
    <GupAccordionItem>
        <LabelContent>Click me</LabelContent>
        <ChildContent>Some hidden content</ChildContent>
    </GupAccordionItem>
    <GupAccordionItem>
        <LabelContent>Click me too</LabelContent>
        <ChildContent>Some other hidden content</ChildContent>
    </GupAccordionItem>
    <GupAccordionItem>
        <LabelContent>Slip merely pocket large no copy</LabelContent>
        <ChildContent>Some hidden content</ChildContent>
    </GupAccordionItem>
    <GupAccordionItem>
        <LabelContent>Crop copy ate accept anything leather fifty</LabelContent>
        <ChildContent>Some hidden content</ChildContent>
    </GupAccordionItem>
</GupAccordion>
```

### Open by default

<!-- from GUPBlazorDemo/Components/Pages/.../Accordion.razor -->
```razor
<GupAccordion>
    <GupAccordionItem Open="true">
        <LabelContent>I am open by default</LabelContent>
        <ChildContent>I am an accordion item</ChildContent>
    </GupAccordionItem>
    <GupAccordionItem>
        <LabelContent>I am closed by default</LabelContent>
        <ChildContent>I am an accordion item</ChildContent>
    </GupAccordionItem>
</GupAccordion>
```

### Ontoggle event

<!-- from GUPBlazorDemo/Components/Pages/.../Accordion.razor -->
```razor
<GupAccordion>
    <GupAccordionItem OnToggle="HandleAccordionToggled">
        <LabelContent>Watch the event log</LabelContent>
        <ChildContent>Each open/close emits an OnToggle event with the new open state.</ChildContent>
    </GupAccordionItem>
</GupAccordion>
<p data-testid="event-log" style="margin-top: 12px;">
    Last event: <strong>@_lastEvent</strong> (count: @_eventCount)
</p>
```

### Hide show hide controls

<!-- from GUPBlazorDemo/Components/Pages/.../Accordion.razor -->
```razor
<GupAccordion>
    <GupAccordionItem HideControls="true">
        <LabelContent>No controls — click anywhere on the label</LabelContent>
        <ChildContent>The Show / Hide indicator is suppressed.</ChildContent>
    </GupAccordionItem>
    <GupAccordionItem HideControls="true">
        <LabelContent>Another bare item</LabelContent>
        <ChildContent>Useful for very dense layouts.</ChildContent>
    </GupAccordionItem>
</GupAccordion>
```

### Custom show hide labels i18n

<!-- from GUPBlazorDemo/Components/Pages/.../Accordion.razor -->
```razor
<GupAccordion>
    <GupAccordionItem LabelShow="عرض" LabelHide="اخفاء">
        <LabelContent>اضغط</LabelContent>
        <ChildContent>محتوى مخفي</ChildContent>
    </GupAccordionItem>
    <GupAccordionItem LabelShow="Open" LabelHide="Close">
        <LabelContent>English with custom labels</LabelContent>
        <ChildContent>The action labels can be localized.</ChildContent>
    </GupAccordionItem>
</GupAccordion>
```

### Two way binding bind open

<!-- from GUPBlazorDemo/Components/Pages/.../Accordion.razor -->
```razor
<GupTrack Direction="horizontal" Gap="2">
    <GupButton Appearance="@GupButtonAppearance.Secondary"
               Kind="@GupButtonKind.Button"
               OnClick="@(() => _bindOpen = !_bindOpen)">
        <ChildContent>Toggle externally</ChildContent>
    </GupButton>
</GupTrack>

<div style="margin-top: 16px;">
    <GupAccordion>
        <GupAccordionItem @bind-Open="_bindOpen">
            <LabelContent>Bound accordion item</LabelContent>
            <ChildContent>The Open state is bound to a parent property — the button above can toggle it too.</ChildContent>
        </GupAccordionItem>
    </GupAccordion>
</div>

<p data-testid="bind-output" style="margin-top: 12px;">
    Bound value: <strong>@(_bindOpen ? "open" : "closed")</strong>
</p>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-accordion-item.md`
