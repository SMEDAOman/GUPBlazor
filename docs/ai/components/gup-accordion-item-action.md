# GupAccordionItemAction

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupAccordionItemAction.razor`
> Live demo: /demo/accordion

Part of the Accordion component set — see the Accordion page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-accordion-item-action icon-name="..."> An accordion item toggle action label/icon. Used inside GupAccordionItem or on its own. Note: this is presentational — it is not a button or link. Default slot: ChildContent (the label)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `IconName` | `string?` | — | — |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-accordion-item-action.md`
