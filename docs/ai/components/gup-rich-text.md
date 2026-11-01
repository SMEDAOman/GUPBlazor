# GupRichText

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupRichText.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/rich-text

Prose block that styles headings, lists and links coming from a CMS or editor.

## Upstream mapping

```text
Equivalent of <gup-rich-text> — wraps HTML content with typography styles
```

## Import

```razor
@using GUPBlazor.Components
```

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Prose block

<!-- from GUPBlazorDemo/Components/Pages/.../RichText.razor -->
```razor
<GupRichText>
  <h2>Applying for a licence</h2>
  <p>
    Before you start, make sure you have your commercial registration number and a
    copy of the lease agreement for the premises. The application takes about
    fifteen minutes to complete.
  </p>
  <h3>What you will need</h3>
  <ul>
    <li>Commercial registration number</li>
    <li>A copy of the lease agreement</li>
    <li>Proof of payment for the application fee</li>
  </ul>
  <h3>After you apply</h3>
  <p>
    You will receive a decision within <strong>five working days</strong>. If more
    information is needed, we will contact you using the details on your
    <a href="/demo/forms">application form</a>.
  </p>
  <ol>
    <li>We check your documents</li>
    <li>An inspector visits the premises</li>
    <li>The licence is issued</li>
  </ol>
</GupRichText>
```

### Rich text with lists

<!-- from GUPBlazorDemo/Components/Pages/.../DataDisplay.razor -->
```razor
<GupRichText>
  <p>These services are available to Omani nationals and residents:</p>
  <ol>
    <li>Visa and residency permits</li>
    <li>Business licensing</li>
    <li>Civil registration</li>
  </ol>
  <p>For more information visit <GupLink Href="https://gov.om/">gov.om</GupLink>.</p>
</GupRichText>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
