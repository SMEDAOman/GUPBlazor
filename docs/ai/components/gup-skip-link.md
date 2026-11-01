# GupSkipLink

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupSkipLink.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/skip-link

Keyboard-only link that jumps past the header to main content.

## Upstream mapping

```text
Equivalent of <gup-skip-link href="#main-content"> Anchor that lets keyboard users bypass the header navigation and jump straight to the main content. Visually hidden until it receives focus (first Tab press). The target element must exist on the page — e.g. <main id="main-content" tabindex="-1">.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Href` | `string` | `"#main-content"` | — | Fragment link (including `#`) to the main content block, e.g. `#main-content`. An element with that id must exist on the page, otherwise the link does nothing. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Link text. Use phrasing content only — avoid nesting links or buttons. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### From the SkipLink page template

<!-- from GUPBlazorDemo/Components/Pages/.../SkipLink.razor -->
```razor
<GupSkipLink Href="#main-content">Skip to content</GupSkipLink>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
