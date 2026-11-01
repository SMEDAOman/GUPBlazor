# GupToastContainer

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupToastContainer.razor`
> Live demo: /demo/toasts

Part of the Toast & toast container component set — see the Toast & toast container page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-toast-container>. Mount once (typically in MainLayout) and call ToastService.Show(...) from any page to push a toast. Also accepts ChildContent for static <GupToast> entries and supports @ref-based AddToast() for backward compatibility.
```

## Import

```razor
@using GUPBlazor.Components
```

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-toast-container.md`
