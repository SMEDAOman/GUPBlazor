# GupBreadcrumbsItem

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupBreadcrumbsItem.razor`
> Live demo: /demo/breadcrumbs

Part of the Breadcrumbs component set — see the Breadcrumbs page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-breadcrumbs-item href="..." current> A single breadcrumb item — to be used as a child of GupBreadcrumbs. Two-way binding: @bind-Current, @bind-Href Events: OnClick
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Href` | `string` | `"#"` | `@bind-Href` | Breadcrumb URL. |
| `Current` | `bool` | — | `@bind-Current` | Whether this breadcrumb represents the current page. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `HrefChanged` | `EventCallback<string>` |  |
| `CurrentChanged` | `EventCallback<bool>` |  |
| `OnClick` | `EventCallback<MouseEventArgs>` | Fires when the breadcrumb link is clicked. |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default

<!-- from GUPBlazorDemo/Components/Pages/.../Breadcrumbs.razor -->
```razor
<GupBreadcrumbs>
    <GupBreadcrumbsItem Href="#">Home</GupBreadcrumbsItem>
    <GupBreadcrumbsItem Href="#">Store</GupBreadcrumbsItem>
    <GupBreadcrumbsItem Href="#">Category</GupBreadcrumbsItem>
    <GupBreadcrumbsItem Href="#">Phone</GupBreadcrumbsItem>
    <GupBreadcrumbsItem Href="#" Current="true">Phone specs</GupBreadcrumbsItem>
</GupBreadcrumbs>
```

### Two items

<!-- from GUPBlazorDemo/Components/Pages/.../Breadcrumbs.razor -->
```razor
<GupBreadcrumbs>
    <GupBreadcrumbsItem Href="#">Representative of an Overseas Business visa</GupBreadcrumbsItem>
    <GupBreadcrumbsItem Href="#" Current="true">Settling in Oman</GupBreadcrumbsItem>
</GupBreadcrumbs>
```

### Onclick event

<!-- from GUPBlazorDemo/Components/Pages/.../Breadcrumbs.razor -->
```razor
<GupBreadcrumbs>
    <GupBreadcrumbsItem Href="javascript:void(0)" OnClick="@(e => Log("Home"))">Home</GupBreadcrumbsItem>
    <GupBreadcrumbsItem Href="javascript:void(0)" OnClick="@(e => Log("Store"))">Store</GupBreadcrumbsItem>
    <GupBreadcrumbsItem Href="javascript:void(0)" OnClick="@(e => Log("Category"))">Category</GupBreadcrumbsItem>
    <GupBreadcrumbsItem Href="javascript:void(0)" Current="true" OnClick="@(e => Log("Phone specs"))">Phone specs</GupBreadcrumbsItem>
</GupBreadcrumbs>

<p data-testid="event-log" style="margin-top:12px;">
    Last clicked: <strong>@_lastClicked</strong> (count: @_clickCount)
</p>
```

### Rtl arabic

<!-- from GUPBlazorDemo/Components/Pages/.../Breadcrumbs.razor -->
```razor
<GupBreadcrumbs AriaLabel="مسار التنقل">
    <GupBreadcrumbsItem Href="#">الصفحة الرئيسية</GupBreadcrumbsItem>
    <GupBreadcrumbsItem Href="#" Current="true">هذه الصفحة</GupBreadcrumbsItem>
</GupBreadcrumbs>
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

### Two way binding bind current

<!-- from GUPBlazorDemo/Components/Pages/.../Breadcrumbs.razor -->
```razor
@* IsMultiline: three fixed-width buttons overflow a 360px viewport otherwise. *@
<GupTrack Direction="horizontal" Gap="2" IsMultiline="true">
    <GupButton Appearance="@GupButtonAppearance.Secondary"
               Kind="@GupButtonKind.Button"
               OnClick="@(() => _currentIndex = 0)">
        <ChildContent>Mark Home as current</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary"
               Kind="@GupButtonKind.Button"
               OnClick="@(() => _currentIndex = 1)">
        <ChildContent>Mark Store as current</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary"
               Kind="@GupButtonKind.Button"
               OnClick="@(() => _currentIndex = 2)">
        <ChildContent>Mark Category as current</ChildContent>
    </GupButton>
</GupTrack>

<div style="margin-top:16px;">
    <GupBreadcrumbs>
        <GupBreadcrumbsItem Href="#" @bind-Current="_isHomeCurrent">Home</GupBreadcrumbsItem>
        <GupBreadcrumbsItem Href="#" @bind-Current="_isStoreCurrent">Store</GupBreadcrumbsItem>
        <GupBreadcrumbsItem Href="#" @bind-Current="_isCategoryCurrent">Category</GupBreadcrumbsItem>
    </GupBreadcrumbs>
</div>

<p data-testid="bind-output" style="margin-top:12px;">
    Current item: <strong>@CurrentLabel</strong>
</p>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-breadcrumbs-item.md`
