# GupFileUpload

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupFileUpload.razor`
> Live demo: /demo/file-upload

Drag-and-drop or browse, with file list and remove actions.

## Upstream mapping

```text
Equivalent of <gup-file-upload name="..." accept="..." multiple required full-width error-message="..." allow-thumbnails max-file-size="50"> Named slots: ChildContent (label), Hint, ExtraAction Uses plain JS (window.__gupFileUpload) for interactivity. When OnChange is set, JS notifies .NET via DotNetObjectReference (requires interactive render mode).
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Name` | `string` | `"" (empty)` | — |  |
| `FileInputLabel` | `string` | `"Choose file"` | — |  |
| `ItemDeleteLabel` | `string` | `"Remove the file"` | — |  |
| `Accept` | `string` | `"" (empty)` | — |  |
| `Multiple` | `bool` | — | — |  |
| `Required` | `bool` | — | — |  |
| `IsFullWidth` | `bool` | — | — |  |
| `ErrorMessage` | `string?` | — | — |  |
| `IsInvalid` | `bool` | — | — | Force the invalid (red) border without an error message, e.g. when a parent form flags the field from its own validation summary. |
| `AllowThumbnails` | `bool` | — | — |  |
| `SizeValidationMessage` | `string` | `"Maximum file size exceeded!"` | — |  |
| `MaxFileSize` | `int` | `50` | — |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |
| `<Hint>` |  |
| `<ExtraAction>` |  |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `OnChange` | `EventCallback<IReadOnlyList<GupFileUploadFile>>` |  |

> Members of `GupFileUploadFile` are documented in [support types](/ai/types.md).

## Cascading values consumed

- CascadedReadOnly (cascading name: "GupReadOnly")

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Single file no hint

<!-- from GUPBlazorDemo/Components/Pages/.../FileUpload.razor -->
```razor
<GupFileUpload Name="default">
    <ChildContent>Upload a file</ChildContent>
</GupFileUpload>
```

### With hint

<!-- from GUPBlazorDemo/Components/Pages/.../FileUpload.razor -->
```razor
<GupFileUpload Name="with-hint">
    <ChildContent>Upload a file</ChildContent>
    <Hint>Only .pdf .jpg or .png files at <strong>5 MB</strong> or less.</Hint>
</GupFileUpload>
```

### With error

<!-- from GUPBlazorDemo/Components/Pages/.../FileUpload.razor -->
```razor
<GupFileUpload Name="error-only" ErrorMessage="File is too large">
    <ChildContent>Upload a file</ChildContent>
</GupFileUpload>
```

### With error hint

<!-- from GUPBlazorDemo/Components/Pages/.../FileUpload.razor -->
```razor
<GupFileUpload Name="error-hint" ErrorMessage="File is too large">
    <ChildContent>Upload a file</ChildContent>
    <Hint>Select files up to 5 MB</Hint>
</GupFileUpload>
```

### Size validation max 5 mb

<!-- from GUPBlazorDemo/Components/Pages/.../FileUpload.razor -->
```razor
<GupFileUpload Name="size-limited" MaxFileSize="5"
               SizeValidationMessage="File exceeds maximum size limit">
    <ChildContent>Upload a file</ChildContent>
    <Hint>Select files up to 5 MB</Hint>
</GupFileUpload>
```

### Full width

<!-- from GUPBlazorDemo/Components/Pages/.../FileUpload.razor -->
```razor
<GupFileUpload Name="full-width-upload" IsFullWidth="true">
    <ChildContent>Upload a file</ChildContent>
</GupFileUpload>
```

### With value single file seeded

<!-- from GUPBlazorDemo/Components/Pages/.../FileUpload.razor -->
```razor
<GupFileUpload Name="with-value">
    <ChildContent>Upload a file</ChildContent>
</GupFileUpload>
```

### With file thumbnail seeded

<!-- from GUPBlazorDemo/Components/Pages/.../FileUpload.razor -->
```razor
<GupFileUpload Name="with-files" AllowThumbnails="true">
    <ChildContent>Upload a file</ChildContent>
</GupFileUpload>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-file-upload.md`
