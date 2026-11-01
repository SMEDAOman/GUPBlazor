# GupImage

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupImage.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/image

Responsive image with aspect-ratio and object-fit control.

## Upstream mapping

```text
Equivalent of <gup-image src="..." alt="..." width="..." height="..." loading="lazy|eager" error-message="..."> A component for displaying images with branded captions and graceful error fallback. Slots / RenderFragments: - CaptionContent â†’ optional caption rendered in a <figcaption> beneath the image - ErrorContent   â†’ optional custom error UI (replaces the default error message when the image fails to load) Two-way binding: @bind-Src, @bind-Alt, @bind-ErrorMessage, @bind-Loading, @bind-Width, @bind-Height Events: OnError, OnLoad
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Src` | `string` | `string.Empty` | `@bind-Src` | The source URL of the image. |
| `Alt` | `string` | `string.Empty` | `@bind-Alt` | The alt text for the image. |
| `ErrorMessage` | `string` | `"Error loading image"` | `@bind-ErrorMessage` | The error message shown when the image fails to load. Overridden by `ErrorContent`. |
| `Loading` | `GupImageLoading?` | — | `@bind-Loading` | Image loading strategy â€” lazy or eager. When null, the attribute is omitted. |
| `Width` | `int?` | — | `@bind-Width` | The intrinsic width of the image (in pixels). |
| `Height` | `int?` | — | `@bind-Height` | The intrinsic height of the image (in pixels). |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<CaptionContent>` | Optional caption rendered in a `<figcaption>` below the image. |
| `<ErrorContent>` | Optional custom error UI â€” when provided, replaces the default error message. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `SrcChanged` | `EventCallback<string>` |  |
| `AltChanged` | `EventCallback<string>` |  |
| `ErrorMessageChanged` | `EventCallback<string>` |  |
| `LoadingChanged` | `EventCallback<GupImageLoading?>` |  |
| `WidthChanged` | `EventCallback<int?>` |  |
| `HeightChanged` | `EventCallback<int?>` |  |
| `OnError` | `EventCallback` | Fires when the underlying `<img>` emits an error event (image failed to load). |
| `OnLoad` | `EventCallback` | Fires when the underlying `<img>` finishes loading successfully. |

## Enums

### `GupImageLoading`

Image loading strategy passed to the underlying <img> element. Browsers that don't support the attribute will silently ignore it.

- `GupImageLoading.Lazy` — Defer loading until the image enters the viewport.
- `GupImageLoading.Eager` — Load the image immediately (default browser behaviour).

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default

<!-- from GUPBlazorDemo/Components/Pages/.../Image.razor -->
```razor
<GupImage Src="@_unsplashSrc"
          Alt="A scenic landscape"
          Width="300"
          Height="300" />
```

### With caption

<!-- from GUPBlazorDemo/Components/Pages/.../Image.razor -->
```razor
<GupImage Src="@_unsplashSrc"
          Alt="A scenic landscape"
          Width="300"
          Height="300">
    <CaptionContent>Caption</CaptionContent>
</GupImage>
```

### Caption with custom html

<!-- from GUPBlazorDemo/Components/Pages/.../Image.razor -->
```razor
<GupImage Src="@_unsplashSrc"
          Alt="A scenic landscape"
          Width="300"
          Height="300">
    <CaptionContent>
        Caption with some HTML, eg. an <strong>accent</strong>
    </CaptionContent>
</GupImage>
```

### Error message default fallback

<!-- from GUPBlazorDemo/Components/Pages/.../Image.razor -->
```razor
<GupImage Src="invalid-url"
          Alt="Won't load"
          Width="300"
          Height="300"
          ErrorMessage="Error loading image" />
```

### Custom error content

<!-- from GUPBlazorDemo/Components/Pages/.../Image.razor -->
```razor
<GupImage Src="another-invalid-url"
          Alt="Won't load either"
          Width="300"
          Height="300">
    <ErrorContent>
        <div style="width:300px; height:300px; border:1px solid #e2e2e2;
                    border-radius:12px; display:flex; justify-content:center;
                    align-items:center; background:#f8f8f8;">
            Image failed to load 🤕
        </div>
    </ErrorContent>
</GupImage>
```

### Lazy loading

<!-- from GUPBlazorDemo/Components/Pages/.../Image.razor -->
```razor
<GupImage Src="@_unsplashSrc"
          Alt="Lazy-loaded landscape"
          Width="300"
          Height="300"
          Loading="GupImageLoading.Lazy">
    <CaptionContent>This image uses <code>loading="lazy"</code>.</CaptionContent>
</GupImage>
```

### Two way binding bind src bind alt bind width bind height bind loading

<!-- from GUPBlazorDemo/Components/Pages/.../Image.razor -->
```razor
<GupImage @bind-Src="_boundSrc"
          @bind-Alt="_boundAlt"
          @bind-Width="_boundWidth"
          @bind-Height="_boundHeight"
          @bind-Loading="_boundLoading">
    <CaptionContent>Bound image — change the controls below.</CaptionContent>
</GupImage>

<div style="display:flex; gap:8px; flex-wrap:wrap; align-items:center;">
    <strong>Source:</strong>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => { _boundSrc = _unsplashSrc; _boundAlt = "A scenic landscape"; })">
        <ChildContent>Landscape</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => { _boundSrc = _picsumSrc; _boundAlt = "Random Picsum photo"; })">
        <ChildContent>Picsum</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => { _boundSrc = "invalid"; _boundAlt = "Broken"; })">
        <ChildContent>Broken</ChildContent>
    </GupButton>
</div>

<div style="display:flex; gap:8px; flex-wrap:wrap; align-items:center;">
    <strong>Size:</strong>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => { _boundWidth = 200; _boundHeight = 200; })">
        <ChildContent>200 × 200</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => { _boundWidth = 300; _boundHeight = 300; })">
        <ChildContent>300 × 300</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => { _boundWidth = 400; _boundHeight = 250; })">
        <ChildContent>400 × 250</ChildContent>
    </GupButton>
</div>

<div style="display:flex; gap:8px; flex-wrap:wrap; align-items:center;">
    <strong>Loading:</strong>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundLoading = null)">
        <ChildContent>(none)</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundLoading = GupImageLoading.Lazy)">
        <ChildContent>Lazy</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _boundLoading = GupImageLoading.Eager)">
        <ChildContent>Eager</ChildContent>
    </GupButton>
</div>

<p data-testid="bind-output" style="margin:0;">
    Bound state: src = <strong>@(_boundSrc.Length > 40 ? _boundSrc.Substring(0, 40) + "…" : _boundSrc)</strong>,
    alt = <strong>@_boundAlt</strong>,
    size = <strong>@_boundWidth × @_boundHeight</strong>,
    loading = <strong>@(_boundLoading?.ToString() ?? "(none)")</strong>
</p>
```

### Onload and onerror events

<!-- from GUPBlazorDemo/Components/Pages/.../Image.razor -->
```razor
<GupImage Src="@_eventSrc"
          Alt="Event demo image"
          Width="200"
          Height="200"
          OnLoad="HandleImageLoad"
          OnError="HandleImageError" />

<div style="display:flex; gap:8px; flex-wrap:wrap; align-items:center;">
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _eventSrc = _picsumSrc + "?v=" + DateTime.UtcNow.Ticks)">
        <ChildContent>Load valid image</ChildContent>
    </GupButton>
    <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button"
               OnClick="@(() => _eventSrc = "broken-" + DateTime.UtcNow.Ticks)">
        <ChildContent>Load broken image</ChildContent>
    </GupButton>
</div>

<p data-testid="event-log" style="margin:0;">
    Loads: <strong>@_loadCount</strong> · Errors: <strong>@_errorCount</strong>
</p>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
