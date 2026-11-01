# GupDialog

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupDialog.razor`
> Live demo: /demo/dialogs

Modal in five sizes including fullscreen, with action buttons.

## Upstream mapping

```text
Equivalent of <gup-dialog heading="..." hide-close-button close-label="..."> A modal dialog. Slots: ChildContent  — main body content ActionButtons — typically a <GupButtonGroup> with Submit/Cancel buttons Visibility is controlled by IsOpen. When IsOpen is true the host renders a full-viewport backdrop + the centered modal panel. ESC closes the dialog (unless HideCloseButton is true). OnClose fires when the close button is clicked, the backdrop is clicked, or ESC is pressed.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `IsOpen` | `bool` | — | — |  |
| `Heading` | `string` | `"" (empty)` | — |  |
| `HideCloseButton` | `bool` | — | — |  |
| `CloseLabel` | `string` | `"Close"` | — |  |
| `CloseOnBackdropClick` | `bool` | `true` | — |  |
| `Size` | `string` | `"medium"` | — | Dialog width: `small`, `medium` (default), `large`, `xl` or `fullscreen`. An unrecognised value falls back to medium. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |
| `<ActionButtons>` |  |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `OnClose` | `EventCallback` |  |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### From the Dialogs page template

<!-- from GUPBlazorDemo/Components/Pages/.../Dialogs.razor -->
```razor
<GupDialog Heading="Do you want to save your progress?"
           IsOpen="_defaultOpen"
           OnClose="@(() => CloseDialog("default"))">
  <ChildContent>Save now to keep any changes you've made so far.</ChildContent>
  <ActionButtons>
    <GupButtonGroup>
      <GupButton Appearance="@GupButtonAppearance.Secondary" OnClick="@(() => CloseDialog("default-submit"))">
        <ChildContent>Submit</ChildContent>
      </GupButton>
      <GupButton Appearance="@GupButtonAppearance.Text" OnClick="@(() => CloseDialog("default-cancel"))">
        <ChildContent>Cancel</ChildContent>
      </GupButton>
    </GupButtonGroup>
  </ActionButtons>
</GupDialog>
```

### From the Dialogs page template

<!-- from GUPBlazorDemo/Components/Pages/.../Dialogs.razor -->
```razor
<GupDialog Heading="Dialog with Long Content"
           IsOpen="_longOpen"
           OnClose="@(() => CloseDialog("long"))">
  <ChildContent>
    <p>This is a paragraph with a lot of content to demonstrate scrolling.</p>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec euismod, nisl eget ultricies ultricies, nunc nisl ultricies nunc, quis ultricies nunc nisl quis nisl.</p>
    <p>Donec euismod, nisl eget ultricies ultricies, nunc nisl ultricies nunc, quis ultricies nunc nisl quis nisl.</p>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec euismod, nisl eget ultricies ultricies, nunc nisl ultricies nunc, quis ultricies nunc nisl quis nisl.</p>
    <p>Donec euismod, nisl eget ultricies ultricies, nunc nisl ultricies nunc, quis ultricies nunc nisl quis nisl.</p>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec euismod, nisl eget ultricies ultricies, nunc nisl ultricies nunc, quis ultricies nunc nisl quis nisl.</p>
    <p>Donec euismod, nisl eget ultricies ultricies, nunc nisl ultricies nunc, quis ultricies nunc nisl quis nisl.</p>
  </ChildContent>
  <ActionButtons>
    <GupButtonGroup>
      <GupButton Appearance="@GupButtonAppearance.Secondary" OnClick="@(() => CloseDialog("long-ok"))">
        <ChildContent>Got it</ChildContent>
      </GupButton>
      <GupButton Appearance="@GupButtonAppearance.Text" OnClick="@(() => CloseDialog("long-cancel"))">
        <ChildContent>Cancel</ChildContent>
      </GupButton>
    </GupButtonGroup>
  </ActionButtons>
</GupDialog>
```

---

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-dialog.md`
