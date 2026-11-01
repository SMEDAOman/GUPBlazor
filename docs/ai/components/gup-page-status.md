# GupPageStatus

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupPageStatus.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/page-status

Empty, error and loading states for a whole page.

## Upstream mapping

```text
Equivalent of <gup-page-status type="success|error|expired"> A page-status block with a circular icon, title, message, and an optional action area (typically a GupButton or GupButtonGroup). Slots / RenderFragments: - TitleContent   → rich content for the heading (overrides PageTitle) - ChildContent   → message body (default slot) - ActionContent  → optional action(s) — usually a GupButton / GupButtonGroup Two-way binding: @bind-Type, @bind-PageTitle Events: OnActionClick (bubbles clicks from the action area without wiring every button individually)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Type` | `GupPageStatusType` | `GupPageStatusType.Success` | `@bind-Type` | Visual state — Success (green), Error (red), or Expired (neutral). |
| `PageTitle` | `string?` | — | `@bind-PageTitle` | Plain-text title. Use `TitleContent` for rich content. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<TitleContent>` | Rich content for the title — overrides `PageTitle`. |
| `<ChildContent>` | Message body rendered beneath the title. |
| `<ActionContent>` | Optional action area — typically a GupButton or GupButtonGroup. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `TypeChanged` | `EventCallback<GupPageStatusType>` |  |
| `PageTitleChanged` | `EventCallback<string?>` |  |
| `OnActionClick` | `EventCallback<MouseEventArgs>` | Fires when the action area is clicked (event bubbles up from buttons inside). |

## Enums

### `GupPageStatusType`

Visual state of a `GupPageStatus`. Mirrors the `type` attribute on `<gup-page-status>`.

- `GupPageStatusType.Success` — Positive outcome — green background, "done" icon.
- `GupPageStatusType.Error` — Negative outcome — red background, "close" icon.
- `GupPageStatusType.Expired` — Time-bounded outcome — neutral background, "priority-high" icon.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Success

<!-- from GUPBlazorDemo/Components/Pages/.../PageStatus.razor -->
```razor
<GupPageStatus Type="GupPageStatusType.Success"
               PageTitle="Your payment has been processed successfully.">
    <ChildContent>Payment ID: 22399</ChildContent>
    <ActionContent>
        <GupButton Appearance="@GupButtonAppearance.Primary" Kind="@GupButtonKind.Button">
            <ChildContent>Review your application</ChildContent>
        </GupButton>
    </ActionContent>
</GupPageStatus>
```

### Error

<!-- from GUPBlazorDemo/Components/Pages/.../PageStatus.razor -->
```razor
<GupPageStatus Type="GupPageStatusType.Error"
               PageTitle="Your payment has failed.">
    <ChildContent>
        We tried to charge your card, but something went wrong. Please update your
        payment method below to continue.
    </ChildContent>
    <ActionContent>
        <GupButton Appearance="@GupButtonAppearance.Primary" Kind="@GupButtonKind.Button">
            <ChildContent>Update payment method</ChildContent>
        </GupButton>
    </ActionContent>
</GupPageStatus>
```

### Expired

<!-- from GUPBlazorDemo/Components/Pages/.../PageStatus.razor -->
```razor
<GupPageStatus Type="GupPageStatusType.Expired"
               PageTitle="Your application has expired.">
    <ChildContent>
        Unfortunately, the payment period has ended. You will need to start a new
        application. Please exit and submit a new application to proceed.
    </ChildContent>
    <ActionContent>
        <GupButton Appearance="@GupButtonAppearance.Primary" Kind="@GupButtonKind.Button">
            <ChildContent>Go to dashboard</ChildContent>
        </GupButton>
    </ActionContent>
</GupPageStatus>
```

### Without an action

<!-- from GUPBlazorDemo/Components/Pages/.../PageStatus.razor -->
```razor
<GupPageStatus Type="GupPageStatusType.Success"
               PageTitle="All done.">
    <ChildContent>Your changes have been saved.</ChildContent>
</GupPageStatus>
```

### Rich title titlecontent

<!-- from GUPBlazorDemo/Components/Pages/.../PageStatus.razor -->
```razor
<GupPageStatus Type="GupPageStatusType.Success">
    <TitleContent>
        Welcome back, <em>Caesar</em>!
    </TitleContent>
    <ChildContent>You're signed in.</ChildContent>
</GupPageStatus>
```

### Two way binding bind type bind pagetitle

<!-- from GUPBlazorDemo/Components/Pages/.../PageStatus.razor -->
```razor
<GupPageStatus @bind-Type="_boundType" @bind-PageTitle="_boundTitle">
    <ChildContent>Bound state — change the controls below.</ChildContent>
</GupPageStatus>

<div style="display:flex; gap:8px; flex-wrap:wrap; align-items:center; justify-content:center;">
    <strong>Type:</strong>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => { _boundType = GupPageStatusType.Success; _boundTitle = "Looks good!"; })">
        <ChildContent>Success</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => { _boundType = GupPageStatusType.Error; _boundTitle = "Something broke."; })">
        <ChildContent>Error</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => { _boundType = GupPageStatusType.Expired; _boundTitle = "Time's up."; })">
        <ChildContent>Expired</ChildContent>
    </GupButton>
</div>

<p data-testid="bind-output" style="margin:0; text-align:center;">
    Bound state: type = <strong>@_boundType</strong>,
    title = <strong>@_boundTitle</strong>
</p>
```

### Onactionclick event

<!-- from GUPBlazorDemo/Components/Pages/.../PageStatus.razor -->
```razor
<GupPageStatus Type="GupPageStatusType.Success"
               PageTitle="All set."
               OnActionClick="HandleActionClick">
    <ChildContent>Click any of the action buttons below.</ChildContent>
    <ActionContent>
        <GupButtonGroup>
            <GupButton Appearance="@GupButtonAppearance.Primary" Kind="@GupButtonKind.Button">
                <ChildContent>Continue</ChildContent>
            </GupButton>
            <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button">
                <ChildContent>View receipt</ChildContent>
            </GupButton>
        </GupButtonGroup>
    </ActionContent>
</GupPageStatus>

<p data-testid="event-log" style="margin:0; text-align:center;">
    Action clicks: <strong>@_actionClickCount</strong>
</p>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
