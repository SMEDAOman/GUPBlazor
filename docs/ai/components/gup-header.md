# GupHeader

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupHeader.razor`
> Live demo: /demo/header

The service header — brand, service name, language toggle and account area.

## Upstream mapping

```text
Equivalent of <gup-header nav-aria-label="..."> Slots: Start (left side), End (right side)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `NavAriaLabel` | `string` | `"Navigation"` | — |  |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<Start>` |  |
| `<End>` |  |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### With an account area

<!-- from GUPBlazorDemo/Components/Pages/.../HeaderDemo.razor -->
```razor
<GupHeader>
  <End>
    <GupTrack Gap="3" VerticalAlignment="center">
      <GupButton Appearance="GupButtonAppearance.Text">
        <IconStart><GupIcon IconName="language" Width="20" Height="20" /></IconStart>
        <ChildContent>العربية</ChildContent>
      </GupButton>
      <GupAvatar Label="Ahmed Al Balushi" />
    </GupTrack>
  </End>
</GupHeader>
```

### Standard

<!-- from GUPBlazorDemo/Components/Pages/.../HeaderDemo.razor -->
```razor
@* The header renders its own logo in the blue box; Start is for buttons. *@
<GupHeader>
  <End>
    <GupButton Appearance="GupButtonAppearance.Text">
      <IconStart><GupIcon IconName="language" Width="20" Height="20" /></IconStart>
      <ChildContent>العربية</ChildContent>
    </GupButton>
  </End>
</GupHeader>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-header.md`
