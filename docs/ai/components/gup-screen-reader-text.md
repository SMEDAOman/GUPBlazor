# GupScreenReaderText

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupScreenReaderText.razor`
> Live demo: /demo/screenreader-text

Part of the Screenreader text component set — see the Screenreader text page for how it composes.

## Upstream mapping

```text
Equivalent of <gup-screenreader-text> Text that is visible only to assistive technologies (screen readers). Visually hidden via the "screenreader-text" pattern (clip + 1×1 absolute box) while remaining in the accessibility tree. Slots / RenderFragments: - ChildContent → the text/content to expose to screen readers (default slot) Parameters: - Text → plain-text alternative to ChildContent (use one or the other). - As   → tag name to render — "span" (default) or "div". - Role → optional ARIA role (e.g. "status", "alert") — useful when announcing dynamic updates via aria-live regions. - AriaLive → optional aria-live politeness ("polite" | "assertive" | "off"). Two-way binding: @bind-Text, @bind-As, @bind-Role, @bind-AriaLive Events: OnRendered (fires on every render — handy when the SR text is updated dynamically)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Text` | `string?` | — | `@bind-Text` | Plain-text content shown only to screen readers. Ignored when `ChildContent` is supplied. |
| `As` | `string` | `"span"` | `@bind-As` | Tag name to render — "span" (default) or "div". |
| `Role` | `string?` | — | `@bind-Role` | Optional ARIA role — e.g. "status" or "alert" for announce-on-update regions. |
| `AriaLive` | `string?` | — | `@bind-AriaLive` | Optional aria-live politeness ("polite", "assertive", or "off"). |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Rich content for the screenreader-only region — overrides `Text`. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `TextChanged` | `EventCallback<string?>` |  |
| `AsChanged` | `EventCallback<string>` |  |
| `RoleChanged` | `EventCallback<string?>` |  |
| `AriaLiveChanged` | `EventCallback<string?>` |  |
| `OnRendered` | `EventCallback` | Fires after the component renders — useful when SR text is updated dynamically. |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Text parameter no slot

<!-- from GUPBlazorDemo/Components/Pages/.../ScreenReaderText.razor -->
```razor
<p data-testid="text-param-example" style="margin:0;">
    Save
    <GupScreenReaderText Text="your application before continuing" />
</p>
```

### As div block level wrapper

<!-- from GUPBlazorDemo/Components/Pages/.../ScreenReaderText.razor -->
```razor
<ul style="margin:0; padding-left:20px;">
    <li>Form section 1
        <GupScreenReaderText As="div" Text="Personal details — three fields, all required" />
    </li>
    <li>Form section 2
        <GupScreenReaderText As="div" Text="Address — two fields, both required" />
    </li>
</ul>
```

### Default text only slot

<!-- from GUPBlazorDemo/Components/Pages/.../ScreenReaderText.razor -->
```razor
<p data-testid="default-example" style="margin:0;">
    The text below is only visible to screenreaders:
    <GupScreenReaderText>Screenreader text</GupScreenReaderText>
    Did you see it?
</p>
```

### Live region role arialive

<!-- from GUPBlazorDemo/Components/Pages/.../ScreenReaderText.razor -->
```razor
<div>
    <GupButton Appearance="@GupButtonAppearance.Primary" Kind="@GupButtonKind.Button"
               OnClick="@AnnounceUpdate">
        <ChildContent>Announce update</ChildContent>
    </GupButton>
</div>

<GupScreenReaderText Role="status"
                     AriaLive="polite"
                     Text="@_announcement" />

<p data-testid="announcement-output" style="margin:0;">
    <strong>Visible mirror (for the demo):</strong>
    "<span data-testid="announcement-value">@_announcement</span>"
    &nbsp;·&nbsp; announced
    <strong><span data-testid="announce-count">@_announceCount</span></strong> times
</p>
```

### Inspection helper temporarily reveal sr text

<!-- from GUPBlazorDemo/Components/Pages/.../ScreenReaderText.razor -->
```razor
<GupCheckbox Name="sr-reveal"
             @bind-Checked="_reveal">Reveal screenreader text (demo only)</GupCheckbox>

<div class="@(_reveal ? "sr-reveal" : "")">
    <p style="margin:0;">
        Submit
        <GupScreenReaderText Text="(this will permanently delete your draft)" />
    </p>
</div>
```

### Two way binding bind text

<!-- from GUPBlazorDemo/Components/Pages/.../ScreenReaderText.razor -->
```razor
<GupInputField Name="sr-bound-text"
               @bind-Value="_boundText"
               Placeholder="Type here…">Screenreader text</GupInputField>

<p style="margin:0;">
    <strong>Visible:</strong> The button below has a hidden description —
    <GupScreenReaderText @bind-Text="_boundText" OnRendered="HandleRendered" />
</p>

<p data-testid="bind-output" style="margin:0;">
    <strong>Bound text:</strong> "<span data-testid="bind-value">@_boundText</span>"
    &nbsp;·&nbsp;
    <strong>OnRendered fired:</strong> <span data-testid="render-count">@_renderCount</span> times
</p>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-screen-reader-text.md`
