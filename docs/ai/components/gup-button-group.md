# GupButtonGroup

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupButtonGroup.razor`
> Live demo: https://gupdesign.sme.gov.om/demo/button-group

Groups of related buttons, with the stacking behaviour used on mobile.

## Upstream mapping

```text
Equivalent of <gup-button-group direction="horizontal|vertical|vertical-on-mobile|vertical-reverse-on-mobile"> Wraps gup-button elements with a gap.
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Direction` | `string` | `"horizontal"` | — | Direction of the button group. One of horizontal (default), vertical, vertical-on-mobile, vertical-reverse-on-mobile. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<ChildContent>` | Default content. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Horizontal default

<!-- from GUPBlazorDemo/Components/Pages/.../ButtonGroup.razor -->
```razor
<GupButtonGroup>
  <GupButton Appearance="GupButtonAppearance.Primary">Continue</GupButton>
  <GupButton Appearance="GupButtonAppearance.Secondary">Save as draft</GupButton>
  <GupButton Appearance="GupButtonAppearance.Text">Cancel</GupButton>
</GupButtonGroup>
```

### Vertical

<!-- from GUPBlazorDemo/Components/Pages/.../ButtonGroup.razor -->
```razor
<GupButtonGroup Direction="vertical">
  <GupButton Appearance="GupButtonAppearance.Primary">Continue</GupButton>
  <GupButton Appearance="GupButtonAppearance.Secondary">Save as draft</GupButton>
  <GupButton Appearance="GupButtonAppearance.Text">Cancel</GupButton>
</GupButtonGroup>
```

### With icons

<!-- from GUPBlazorDemo/Components/Pages/.../ButtonGroup.razor -->
```razor
<GupButtonGroup>
  <GupButton Appearance="GupButtonAppearance.Secondary">
    <IconStart><GupIcon IconName="arrow-back" Width="20" Height="20" /></IconStart>
    <ChildContent>Back</ChildContent>
  </GupButton>
  <GupButton Appearance="GupButtonAppearance.Primary">
    <ChildContent>Continue</ChildContent>
    <IconEnd><GupIcon IconName="arrow-forward" Width="20" Height="20" /></IconEnd>
  </GupButton>
</GupButtonGroup>
```

### Button Group

<!-- from GUPBlazorDemo/Components/Pages/.../Buttons.razor -->
```razor
<GupButtonGroup>
  <GupButton Appearance="@GupButtonAppearance.Primary" OnClick="ButtonClicked">Submit Application</GupButton>
  <GupButton Appearance="@GupButtonAppearance.Secondary" OnClick="ButtonClicked">Save Draft</GupButton>
  <GupButton Appearance="@GupButtonAppearance.Text" OnClick="ButtonClicked">Cancel</GupButton>
</GupButtonGroup>
```

### Onactionclick event

<!-- from GUPBlazorDemo/Components/Pages/.../PageStatus.razor -->
```razor
<GupPageStatus Type="GupPageStatusType.Success"
               PageTitle="All set."
               OnActionClick="HandleActionClick">
    <ChildContent>Click any of the action buttons below.</ChildContent>
    <ActionContent>
        <GupButtonGroup>
            <GupButton Appearance="@GupButtonAppearance.Primary" Kind="@GupButtonKind.Button">
                <ChildContent>Continue</ChildContent>
            </GupButton>
            <GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Button">
                <ChildContent>View receipt</ChildContent>
            </GupButton>
        </GupButtonGroup>
    </ActionContent>
</GupPageStatus>

<p data-testid="event-log" style="margin:0; text-align:center;">
    Action clicks: <strong>@_actionClickCount</strong>
</p>
```

### With footer action buttons

<!-- from GUPBlazorDemo/Components/Pages/.../FormSection.razor -->
```razor
<GupFormSection>
    <Title>Contact details</Title>
    <ChildContent>
        <GupFormList>
            <GupInputField Name="footer-email" Type="email">Email</GupInputField>
            <GupInputField Name="footer-phone" Type="tel">Mobile number</GupInputField>
        </GupFormList>
    </ChildContent>
    <FooterContent>
        <GupButtonGroup>
            <GupButton Appearance="@GupButtonAppearance.Primary"
                       Kind="@GupButtonKind.Button"
                       OnClick="HandleSave">
                <ChildContent>Save</ChildContent>
            </GupButton>
            <GupButton Appearance="@GupButtonAppearance.Secondary"
                       Kind="@GupButtonKind.Button"
                       OnClick="HandleCancel">
                <ChildContent>Cancel</ChildContent>
            </GupButton>
        </GupButtonGroup>
    </FooterContent>
</GupFormSection>

<p data-testid="footer-log" style="margin: 8px 0 0;">
    Last footer action: <strong>@_lastFooterAction</strong>
</p>
```

### Rtl arabic

<!-- from GUPBlazorDemo/Components/Pages/.../FormSection.razor -->
```razor
<GupFormSection>
    <Title>المعلومات الشخصية</Title>
    <ChildContent>
        <GupFormList>
            <GupInputField Name="rtl-first-name" Type="text">الاسم الأول</GupInputField>
            <GupInputField Name="rtl-last-name" Type="text">اسم العائلة</GupInputField>
        </GupFormList>
    </ChildContent>
    <FooterContent>
        <GupButtonGroup>
            <GupButton Appearance="@GupButtonAppearance.Primary"
                       Kind="@GupButtonKind.Button">
                <ChildContent>حفظ</ChildContent>
            </GupButton>
            <GupButton Appearance="@GupButtonAppearance.Secondary"
                       Kind="@GupButtonKind.Button">
                <ChildContent>إلغاء</ChildContent>
            </GupButton>
        </GupButtonGroup>
    </FooterContent>
</GupFormSection>
```

### Onfooterclick event

<!-- from GUPBlazorDemo/Components/Pages/.../FormSection.razor -->
```razor
<div data-testid="footer-click-section">
<GupFormSection OnFooterClick="HandleFooterAreaClick">
    <Title>Footer click delegation</Title>
    <ChildContent>
        <p style="margin: 0; color: var(--gup-color-content-primary);">
            Click any of the buttons below — the parent component logs the click.
        </p>
    </ChildContent>
    <FooterContent>
        <GupButtonGroup>
            <GupButton Appearance="@GupButtonAppearance.Primary"
                       Kind="@GupButtonKind.Button">
                <ChildContent>Action 1</ChildContent>
            </GupButton>
            <GupButton Appearance="@GupButtonAppearance.Secondary"
                       Kind="@GupButtonKind.Button">
                <ChildContent>Action 2</ChildContent>
            </GupButton>
            <GupButton Appearance="@GupButtonAppearance.Text"
                       Kind="@GupButtonKind.Button">
                <ChildContent>Action 3</ChildContent>
            </GupButton>
        </GupButtonGroup>
    </FooterContent>
</GupFormSection>
</div>

<p data-testid="footer-click-log" style="margin:0;">
    Footer area clicks: <strong>@_footerClickCount</strong>
</p>
```

---

Full component index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md · Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs
