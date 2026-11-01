# GupAvatar

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupAvatar.razor`
> Live demo: /demo/avatar

User avatar from initials or an image.

## Upstream mapping

```text
Equivalent of <gup-avatar size="s|m|l" src="..." alt="..." label="..." status="..."> Renders a user avatar — image when Src+Alt are provided, name abbreviation when Label is provided, otherwise a generic "person" icon. Supports an optional status badge in the bottom-end corner. Two-way binding: @bind-Status, @bind-Label, @bind-Src Events: OnClick
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Size` | `GupAvatarSize` | `GupAvatarSize.S` | — | Avatar size — small, medium, or large. |
| `Src` | `string?` | — | `@bind-Src` | Image source — when set together with `Alt`, the avatar shows the image. |
| `Alt` | `string?` | — | — | Image alt text. Required for the image to render. |
| `Label` | `string?` | — | `@bind-Label` | Text label — uppercase letters are extracted as the abbreviation when no image is provided. |
| `Status` | `GupBadgeType?` | — | `@bind-Status` | Optional status badge rendered in the bottom-end corner. |
| `StatusAriaLabel` | `string?` | — | — | Accessible label for the status badge. |
| `AriaLabel` | `string?` | — | — | Accessible label for the avatar itself. |

## Events

| Event | Type | Description |
|---|---|---|
| `SrcChanged` | `EventCallback<string?>` |  |
| `LabelChanged` | `EventCallback<string?>` |  |
| `StatusChanged` | `EventCallback<GupBadgeType?>` |  |
| `OnClick` | `EventCallback<MouseEventArgs>` | Fires when the avatar is clicked or activated by keyboard (Enter/Space). |

> Members of `GupBadgeType` are documented in [support types](/ai/types.md).

## Enums

### `GupAvatarSize`

- `GupAvatarSize.S`
- `GupAvatarSize.M`
- `GupAvatarSize.L`

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Small (default)

<!-- from GUPBlazorDemo/Components/Pages/.../Avatar.razor -->
```razor
<GupAvatar Size="@GupAvatarSize.S" Label="Caesar Moussalli" AriaLabel="Caesar Moussalli" />
```

### Medium

<!-- from GUPBlazorDemo/Components/Pages/.../Avatar.razor -->
```razor
<GupAvatar Size="@GupAvatarSize.M" Label="Caesar Moussalli" AriaLabel="Caesar Moussalli" />
```

### Large

<!-- from GUPBlazorDemo/Components/Pages/.../Avatar.razor -->
```razor
<GupAvatar Size="@GupAvatarSize.L" Label="Caesar Moussalli" AriaLabel="Caesar Moussalli" />
```

### Small

<!-- from GUPBlazorDemo/Components/Pages/.../Avatar.razor -->
```razor
<GupAvatar Size="@GupAvatarSize.S" AriaLabel="Anonymous user" />
```

### Medium

<!-- from GUPBlazorDemo/Components/Pages/.../Avatar.razor -->
```razor
<GupAvatar Size="@GupAvatarSize.M" AriaLabel="Anonymous user" />
```

### Large

<!-- from GUPBlazorDemo/Components/Pages/.../Avatar.razor -->
```razor
<GupAvatar Size="@GupAvatarSize.L" AriaLabel="Anonymous user" />
```

### Small

<!-- from GUPBlazorDemo/Components/Pages/.../Avatar.razor -->
```razor
<GupAvatar Size="@GupAvatarSize.S"
           Src="https://images.unsplash.com/photo-1494790108377-be9c29b29330?auto=format&fit=crop&q=80&w=200"
           Alt="Some Profile" />
```

### Medium

<!-- from GUPBlazorDemo/Components/Pages/.../Avatar.razor -->
```razor
<GupAvatar Size="@GupAvatarSize.M"
           Src="https://images.unsplash.com/photo-1494790108377-be9c29b29330?auto=format&fit=crop&q=80&w=200"
           Alt="Some Profile" />
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-avatar.md`
