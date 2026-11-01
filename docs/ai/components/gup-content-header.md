# GupContentHeader

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupContentHeader.razor`
> Live demo: /demo/content-header

Page title, summary and optional actions at the top of a page.

## Upstream mapping

```text
Equivalent of <gup-content-header page-title="..." page-subtitle="..."> Slots: Breadcrumbs, PageSubtitleContent, PageTitleContent, PageSummary, ChildContent (content below title) The *Content slots take precedence over the corresponding string props.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `PageTitle` | `string` | `"" (empty)` | — | Page title. Used when the PageTitleContent slot is not provided. |
| `PageSubtitle` | `string?` | — | — | Page subtitle (above the title). Used when the PageSubtitleContent slot is not provided. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<Breadcrumbs>` | Slot for gup-breadcrumbs. Do not insert anything else here. |
| `<PageTitleContent>` | Slot for the page title. Takes precedence over the PageTitle prop. |
| `<PageSubtitleContent>` | Slot for the page subtitle. Takes precedence over the PageSubtitle prop. |
| `<PageSummary>` | Slot for textual content appearing below the title. |
| `<ChildContent>` | Default slot — content below the title. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Title only

<!-- from GUPBlazorDemo/Components/Pages/.../ContentHeaderDemo.razor -->
```razor
<GupContentHeader PageTitle="Apply for a licence" />
```

### With a summary

<!-- from GUPBlazorDemo/Components/Pages/.../ContentHeaderDemo.razor -->
```razor
<GupContentHeader PageTitle="Apply for a licence">
  <PageSummary>
    Complete all sections before submitting. You can save a draft and return later.
  </PageSummary>
</GupContentHeader>
```

### With a subtitle

<!-- from GUPBlazorDemo/Components/Pages/.../ContentHeaderDemo.razor -->
```razor
<GupContentHeader PageTitle="Apply for a licence" PageSubtitle="Step 2 of 4" />
```

### With breadcrumbs

<!-- from GUPBlazorDemo/Components/Pages/.../ContentHeaderDemo.razor -->
```razor
<GupContentHeader PageTitle="Apply for a licence">
  <Breadcrumbs>
    <GupBreadcrumbs>
      <GupBreadcrumbsItem Href="/">Home</GupBreadcrumbsItem>
      <GupBreadcrumbsItem Href="/demo/forms">Services</GupBreadcrumbsItem>
      <GupBreadcrumbsItem Current="true">Apply</GupBreadcrumbsItem>
    </GupBreadcrumbs>
  </Breadcrumbs>
  <PageSummary>Breadcrumbs sit above the title.</PageSummary>
</GupContentHeader>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-content-header.md`
