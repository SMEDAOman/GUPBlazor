# GupFileItem

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupFileItem.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/file-item

A single uploaded file row with size, link and remove action.

## Upstream mapping

```text
Equivalent of <gup-file-item file-name="..." subtitle="..." url="..." thumbnail-src="..." thumbnail-alt="..."> Default slot: ChildContent (action button)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `FileName` | `string` | `"" (empty)` | — |  |
| `Subtitle` | `string?` | — | — |  |
| `Url` | `string?` | — | — |  |
| `ThumbnailSrc` | `string?` | — | — |  |
| `ThumbnailAlt` | `string?` | — | — |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Basic

<!-- from GUPBlazorDemo/Components/Pages/.../FileItem.razor -->
```razor
<GupFileItem FileName="lease-agreement.pdf" Subtitle="12.10.2026, 2 MB" />
<GupFileItem FileName="commercial-registration.pdf" Subtitle="12.10.2026, 840 KB" />
```

### As a link

<!-- from GUPBlazorDemo/Components/Pages/.../FileItem.razor -->
```razor
<GupFileItem FileName="receipt.pdf" Subtitle="12.10.2026, 310 KB" Url="/demo/file-item" />
```

### Default

<!-- from GUPBlazorDemo/Components/Pages/.../FileUpload.razor -->
```razor
<GupFileItem FileName="file.png" Subtitle="09.02.2021, 2 MB"
             ThumbnailSrc="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAYAAACNMs+9AAAAFUlEQVR42mP8z8BQz0AEYBxVSF+FABJADveWkH6oAAAAAElFTkSuQmCC"
             ThumbnailAlt="Thumbnail" />
```

### With download link

<!-- from GUPBlazorDemo/Components/Pages/.../FileUpload.razor -->
```razor
<GupFileItem FileName="designers-card.png" Subtitle="09.02.2021, 2 MB"
             Url="https://example.com/documents/designers-card.png"
             ThumbnailSrc="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAYAAACNMs+9AAAAFUlEQVR42mP8z8BQz0AEYBxVSF+FABJADveWkH6oAAAAAElFTkSuQmCC"
             ThumbnailAlt="Thumbnail" />
```

### With delete icon button

<!-- from GUPBlazorDemo/Components/Pages/.../FileUpload.razor -->
```razor
<GupFileItem FileName="file.png" Subtitle="09.02.2021, 2 MB"
             ThumbnailSrc="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAYAAACNMs+9AAAAFUlEQVR42mP8z8BQz0AEYBxVSF+FABJADveWkH6oAAAAAElFTkSuQmCC"
             ThumbnailAlt="Thumbnail">
    <div class="gup-button gup-button--text">
        <button type="button" class="button" aria-label="Remove the file"
                title="Remove the file" @onclick="@(() => Alert("Delete clicked"))">
            <GupIcon IconName="delete-forever" Width="24" Height="24" />
        </button>
    </div>
</GupFileItem>
```

### Multiple items grouped

<!-- from GUPBlazorDemo/Components/Pages/.../FileUpload.razor -->
```razor
<GupFileItem FileName="report-2024-q1.pdf" Subtitle="01.03.2024, 1.2 MB" />
<GupFileItem FileName="report-2024-q2.pdf" Subtitle="01.06.2024, 1.4 MB" />
<GupFileItem FileName="report-2024-q3.pdf" Subtitle="01.09.2024, 1.3 MB" />
```

### File library saved files list

<!-- from GUPBlazorDemo/Components/Pages/.../FileUpload.razor -->
```razor
<GupFileUpload Name="library" Multiple="true">
    <ChildContent>Upload files</ChildContent>
    <ExtraAction>
        <GupButton Appearance="@GupButtonAppearance.Text"
                   OnClick="@(() => Alert("Saved files clicked (File library)"))">
            <ChildContent>Saved files</ChildContent>
        </GupButton>
    </ExtraAction>
</GupFileUpload>
<div style="margin-top: var(--gup-spacing-text-to-component);">
    <GupFileItem FileName="file.png" Subtitle="09.02.2021, 2 MB" Url="/file.png">
        <GupButton Appearance="@GupButtonAppearance.Text"
                   OnClick="@(() => Alert("You clicked on Select button"))">
            <ChildContent>Select</ChildContent>
        </GupButton>
    </GupFileItem>
    <GupFileItem FileName="file2.png" Subtitle="09.02.2021, 2 MB" Url="/file2.png">
        <GupButton Appearance="@GupButtonAppearance.Text"
                   OnClick="@(() => Alert("You clicked on Select button"))">
            <ChildContent>Select</ChildContent>
        </GupButton>
    </GupFileItem>
</div>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
