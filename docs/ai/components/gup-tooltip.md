# GupTooltip

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupTooltip.razor`
> Live demo: /demo/tooltip

Hover and focus tooltip with placement options.

## Upstream mapping

```text
Equivalent of <gup-tooltip title="…" hint="…" placement="bottom" max-width="200" max-height="150"> A small popup attached to a trigger element. Mirrors the gov.om design-system `gup-tooltip` component (which wraps gup-generic-popup + Floating UI). Slots: Trigger        — the element that activates the tooltip (button, link, icon…). Required. Wraps the actual trigger so we can attach mouse / focus handlers without forcing the consumer to use a specific element id. ChildContent   — extra content inside the popup, rendered after the title and hint (matches the unnamed slot of <gup-tooltip>). Optional. Two-way binding: @bind-IsOpen     — visible state (Show / Hide / Toggle are equivalent). @bind-Placement  — current placement edge. Events: OnShow  — fires when the tooltip becomes visible (matches gup-tooltip-show). OnHide  — fires when the tooltip is hidden  (matches gup-tooltip-hide). CSS custom properties (set on the wrapper): --gup-tooltip--max-width    overrides MaxWidth. --gup-tooltip--max-height   overrides MaxHeight.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Title` | `string` | `"" (empty)` | — | Title of the tooltip — rendered as a heading inside the popup. |
| `Hint` | `string?` | — | — | Optional hint shown below the title. |
| `Target` | `string?` | — | — | Id of an external target element the tooltip attaches to (matches `target`). When set, the consumer wires the trigger externally; otherwise use the `Trigger` slot. |
| `Offset` | `int` | `8` | — | Distance in px between the popup and the trigger (matches `offset`). Default: 8. |
| `Placement` | `GupTooltipPlacement` | `GupTooltipPlacement.Bottom` | `@bind-Placement` | Placement of the popup relative to the trigger. Default: `Bottom`. |
| `TriggerOn` | `GupTooltipTrigger` | `GupTooltipTrigger.Click` | — | How the tooltip opens. Default: `Click`. |
| `IsOpen` | `bool` | — | `@bind-IsOpen` | Whether the tooltip is currently visible. Supports two-way binding via @@bind-IsOpen. |
| `ShowArrow` | `bool` | `true` | — | Display the small triangular arrow pointing at the trigger. Default: true. |
| `MaxWidth` | `int` | `200` | — | Maximum width of the popup, in px. Override at runtime via `--gup-tooltip--max-width`. |
| `MaxHeight` | `int` | `150` | — | Maximum height of the popup, in px (a scrollbar appears when content overflows). Override via `--gup-tooltip--max-height`. |
| `CloseOnOutsideClick` | `bool` | `true` | — | Close on click outside the trigger and popup. Default: true. |
| `CloseOnEscape` | `bool` | `true` | — | Close when ESC is pressed. Default: true. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<Trigger>` | Element used to activate the tooltip. Required. |
| `<ChildContent>` | Optional extra content inside the popup, rendered after the title/hint. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `PlacementChanged` | `EventCallback<GupTooltipPlacement>` |  |
| `IsOpenChanged` | `EventCallback<bool>` |  |
| `OnShow` | `EventCallback` | Fires when the tooltip is shown (matches `gup-tooltip-show`). |
| `OnHide` | `EventCallback` | Fires when the tooltip is hidden (matches `gup-tooltip-hide`). |

## Enums

### `GupTooltipPlacement`

Placement of a `GupTooltip` popup relative to its trigger element. Mirrors the `placement` attribute on the gov.om `<gup-tooltip>` design-system component (which itself uses Floating UI's `Placement` type): each edge plus its -start / -end alignment variants.

- `GupTooltipPlacement.Top` — Tooltip appears above the trigger.
- `GupTooltipPlacement.TopStart` — Above the trigger, aligned to its start edge.
- `GupTooltipPlacement.TopEnd` — Above the trigger, aligned to its end edge.
- `GupTooltipPlacement.Bottom` — Tooltip appears below the trigger (default).
- `GupTooltipPlacement.BottomStart` — Below the trigger, aligned to its start edge.
- `GupTooltipPlacement.BottomEnd` — Below the trigger, aligned to its end edge.
- `GupTooltipPlacement.Left` — Tooltip appears to the inline-start of the trigger (left in LTR).
- `GupTooltipPlacement.LeftStart` — Inline-start of the trigger, aligned to its start edge.
- `GupTooltipPlacement.LeftEnd` — Inline-start of the trigger, aligned to its end edge.
- `GupTooltipPlacement.Right` — Tooltip appears to the inline-end of the trigger (right in LTR).
- `GupTooltipPlacement.RightStart` — Inline-end of the trigger, aligned to its start edge.
- `GupTooltipPlacement.RightEnd` — Inline-end of the trigger, aligned to its end edge.

### `GupTooltipTrigger`

How a `GupTooltip` opens.

- `GupTooltipTrigger.Click` — Opens when the trigger is clicked. Closes on outside click or ESC.
- `GupTooltipTrigger.Hover` — Opens on hover/focus, closes when the pointer leaves or focus moves away.
- `GupTooltipTrigger.Manual` — The component never reacts to user input — drive it via `@bind-IsOpen`, `ShowAsync()`, or `HideAsync()`.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default click to open

<!-- from GUPBlazorDemo/Components/Pages/.../Tooltip.razor -->
```razor
<GupTooltip Title="Tooltip title">
    <Trigger>
        <GupButton Appearance="@GupButtonAppearance.Primary"
                   Kind="@GupButtonKind.Button">
            <ChildContent>Click to open the tooltip</ChildContent>
        </GupButton>
    </Trigger>
</GupTooltip>
```

### With hint

<!-- from GUPBlazorDemo/Components/Pages/.../Tooltip.razor -->
```razor
<GupTooltip Title="Tooltip title" Hint="Hint text">
    <Trigger>
        <GupButton Appearance="@GupButtonAppearance.Primary"
                   Kind="@GupButtonKind.Button">
            <ChildContent>Click to open</ChildContent>
        </GupButton>
    </Trigger>
</GupTooltip>
```

### Placements

<!-- from GUPBlazorDemo/Components/Pages/.../Tooltip.razor -->
```razor
<GupTooltip Title="Top" Placement="GupTooltipPlacement.Top">
    <Trigger>
        <GupButton Kind="@GupButtonKind.Button"><ChildContent>Top</ChildContent></GupButton>
    </Trigger>
</GupTooltip>

<GupTooltip Title="Bottom" Placement="GupTooltipPlacement.Bottom">
    <Trigger>
        <GupButton Kind="@GupButtonKind.Button"><ChildContent>Bottom</ChildContent></GupButton>
    </Trigger>
</GupTooltip>

<GupTooltip Title="Left" Placement="GupTooltipPlacement.Left">
    <Trigger>
        <GupButton Kind="@GupButtonKind.Button"><ChildContent>Left</ChildContent></GupButton>
    </Trigger>
</GupTooltip>

<GupTooltip Title="Right" Placement="GupTooltipPlacement.Right">
    <Trigger>
        <GupButton Kind="@GupButtonKind.Button"><ChildContent>Right</ChildContent></GupButton>
    </Trigger>
</GupTooltip>
```

### Open on hover focus

<!-- from GUPBlazorDemo/Components/Pages/.../Tooltip.razor -->
```razor
<GupTooltip Title="I appear on hover"
            Hint="…and on keyboard focus too."
            TriggerOn="GupTooltipTrigger.Hover">
    <Trigger>
        <GupButton Appearance="@GupButtonAppearance.Secondary"
                   Kind="@GupButtonKind.Button">
            <ChildContent>Hover or focus me</ChildContent>
        </GupButton>
    </Trigger>
</GupTooltip>
```

### With action slot childcontent

<!-- from GUPBlazorDemo/Components/Pages/.../Tooltip.razor -->
```razor
<GupTooltip Title="Did you know?"
            Hint="You can put any content here.">
    <Trigger>
        <GupButton Kind="@GupButtonKind.Button">
            <ChildContent>Click for details</ChildContent>
        </GupButton>
    </Trigger>
    <ChildContent>
        <GupLink Href="https://www.gov.om" Target="_blank">Learn more →</GupLink>
    </ChildContent>
</GupTooltip>
```

### Long content max size

<!-- from GUPBlazorDemo/Components/Pages/.../Tooltip.razor -->
```razor
<GupTooltip Title="A long title that wraps over multiple lines because we set a small max-width"
            Hint="Use the MaxWidth and MaxHeight parameters (or the matching CSS custom properties) to bound the popup."
            MaxWidth="240"
            MaxHeight="120">
    <Trigger>
        <GupButton Kind="@GupButtonKind.Button"><ChildContent>Long content</ChildContent></GupButton>
    </Trigger>
</GupTooltip>
```

### Without arrow

<!-- from GUPBlazorDemo/Components/Pages/.../Tooltip.razor -->
```razor
<GupTooltip Title="No arrow here" ShowArrow="false">
    <Trigger>
        <GupButton Kind="@GupButtonKind.Button"><ChildContent>Click me</ChildContent></GupButton>
    </Trigger>
</GupTooltip>
```

### Rtl arabic

<!-- from GUPBlazorDemo/Components/Pages/.../Tooltip.razor -->
```razor
<GupTooltip Title="معلومة" Hint="نص توضيحي" Placement="GupTooltipPlacement.Left">
    <Trigger>
        <GupButton Kind="@GupButtonKind.Button"><ChildContent>يسار</ChildContent></GupButton>
    </Trigger>
</GupTooltip>
<GupTooltip Title="معلومة" Hint="نص توضيحي" Placement="GupTooltipPlacement.Right">
    <Trigger>
        <GupButton Kind="@GupButtonKind.Button"><ChildContent>يمين</ChildContent></GupButton>
    </Trigger>
</GupTooltip>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-tooltip.md`
