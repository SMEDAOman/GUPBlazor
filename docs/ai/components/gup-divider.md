# GupDivider

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupDivider.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/divider

Horizontal and vertical rules with spacing options.

## Upstream mapping

```text
Equivalent of <gup-divider appearance="default|secondary|inverse" location="bottom|top|top-and-bottom" gap="4"> A simple divider that separates content via a top, bottom, or both border. The content goes in ChildContent (default slot). Two-way binding: @bind-Appearance, @bind-Location, @bind-Gap Events: OnClick (fires when the divider wrapper is clicked / activated by Enter/Space)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Appearance` | `GupDividerAppearance` | `GupDividerAppearance.Default` | `@bind-Appearance` | Visual appearance — default, secondary (lower contrast), or inverse (for dark surfaces). |
| `Location` | `GupDividerLocation` | `GupDividerLocation.Bottom` | `@bind-Location` | Where the divider line is rendered relative to the content. |
| `Gap` | `int` | `4` | `@bind-Gap` | Spacing (in --unit multiples, default 4 = 16px) between the content and the line. |
| `AriaLabel` | `string?` | — | — | Accessible label — used when the divider is clickable. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Content to be separated by the divider. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `AppearanceChanged` | `EventCallback<GupDividerAppearance>` |  |
| `LocationChanged` | `EventCallback<GupDividerLocation>` |  |
| `GapChanged` | `EventCallback<int>` |  |
| `OnClick` | `EventCallback<MouseEventArgs>` | Fires when the divider is clicked or activated by keyboard (Enter/Space). |

## Enums

### `GupDividerAppearance`

Visual style of a `GupDivider`.

- `GupDividerAppearance.Default`
- `GupDividerAppearance.Secondary`
- `GupDividerAppearance.Inverse`

### `GupDividerLocation`

Which edges of the content a `GupDivider` draws on.

- `GupDividerLocation.Bottom`
- `GupDividerLocation.Top`
- `GupDividerLocation.TopAndBottom`

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default bottom

<!-- from GUPBlazorDemo/Components/Pages/.../Divider.razor -->
```razor
<GupDivider>
    <span>Element 1</span>
    <span>Element 2 with some words</span>
    <span>Element 3 with so many words that they wrap onto multiple lines and demonstrate how the
        divider sits beneath them.</span>
</GupDivider>
```

### Top

<!-- from GUPBlazorDemo/Components/Pages/.../Divider.razor -->
```razor
<GupDivider Location="@GupDividerLocation.Top" Gap="5">
    <span>Element 1</span>
    <span>Element 2 with some words</span>
    <span>Element 3 with so many words that they wrap.</span>
</GupDivider>
```

### Top and bottom

<!-- from GUPBlazorDemo/Components/Pages/.../Divider.razor -->
```razor
<GupDivider Location="@GupDividerLocation.TopAndBottom" Gap="6">
    <span>Element 1</span>
    <span>Element 2 with some words</span>
    <span>Element 3 with so many words that they wrap onto multiple lines.</span>
</GupDivider>
```

### Secondary appearance

<!-- from GUPBlazorDemo/Components/Pages/.../Divider.razor -->
```razor
<GupDivider Appearance="@GupDividerAppearance.Secondary"
            Location="@GupDividerLocation.TopAndBottom"
            Gap="7">
    <span>Element 1</span>
    <span>Element 2 with some words</span>
    <span>Element 3 — lower-contrast line for less visual weight.</span>
</GupDivider>
```

### Inverse appearance dark surface

<!-- from GUPBlazorDemo/Components/Pages/.../Divider.razor -->
```razor
<GupDivider Appearance="@GupDividerAppearance.Inverse"
            Location="@GupDividerLocation.TopAndBottom"
            Gap="8">
    <span>Element 1</span>
    <span>Element 2 with some words</span>
    <span>Element 3 — white-tinted line on a dark surface.</span>
</GupDivider>
```

### Gap variations

<!-- from GUPBlazorDemo/Components/Pages/.../Divider.razor -->
```razor
<GupDivider Gap="2">
    <span>Gap = 2 (8px)</span>
</GupDivider>
<GupDivider Gap="4">
    <span>Gap = 4 (16px, default)</span>
</GupDivider>
<GupDivider Gap="10">
    <span>Gap = 10 (40px)</span>
</GupDivider>
```

### Two way binding bind appearance bind location bind gap

<!-- from GUPBlazorDemo/Components/Pages/.../Divider.razor -->
```razor
<GupDivider @bind-Appearance="_boundAppearance"
            @bind-Location="_boundLocation"
            @bind-Gap="_boundGap">
    <span>Bound divider</span>
    <span>Use the controls below to change appearance, location, and gap.</span>
</GupDivider>

<div style="display:flex; gap:8px; flex-wrap:wrap; align-items:center;">
    <strong>Appearance:</strong>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundAppearance = GupDividerAppearance.Default)">
        <ChildContent>Default</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundAppearance = GupDividerAppearance.Secondary)">
        <ChildContent>Secondary</ChildContent>
    </GupButton>
</div>

<div style="display:flex; gap:8px; flex-wrap:wrap; align-items:center;">
    <strong>Location:</strong>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundLocation = GupDividerLocation.Bottom)">
        <ChildContent>Bottom</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundLocation = GupDividerLocation.Top)">
        <ChildContent>Top</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundLocation = GupDividerLocation.TopAndBottom)">
        <ChildContent>Top &amp; bottom</ChildContent>
    </GupButton>
</div>

<div style="display:flex; gap:8px; flex-wrap:wrap; align-items:center;">
    <strong>Gap:</strong>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundGap = Math.Max(0, _boundGap - 1))">
        <ChildContent>−</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundGap = _boundGap + 1)">
        <ChildContent>+</ChildContent>
    </GupButton>
</div>

<p data-testid="bind-output" style="margin:0;">
    Bound state: appearance = <strong>@_boundAppearance</strong>, location =
    <strong>@_boundLocation</strong>, gap = <strong>@_boundGap</strong>
</p>
```

### Onclick event

<!-- from GUPBlazorDemo/Components/Pages/.../Divider.razor -->
```razor
<GupDivider Location="@GupDividerLocation.TopAndBottom"
            AriaLabel="Activate the divider"
            OnClick="HandleDividerClick">
    <span>Clickable divider</span>
    <span>Click anywhere in this content (or focus and press Enter/Space) to fire the OnClick
        event.</span>
</GupDivider>

<p data-testid="click-log" style="margin:0;">
    Click count: <strong>@_clickCount</strong>
</p>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
