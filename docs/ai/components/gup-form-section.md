# GupFormSection

> GUPBlazor 0.3.4 — Blazor implementation of the gov.om (Government Unified Platform) design system.
> Source: `GUPBlazor/Components/GupFormSection.razor`
> Live demo: /demo/form-section

Titled section with optional footer for action buttons.

## Upstream mapping

```text
Equivalent of <gup-form-section> A section in a long form with a heading and an optional footer (typically a GupButtonGroup with action buttons). Slots: - Title          → rich content for the section heading (overrides Heading) - ChildContent   → main content of the section (default slot) - FooterContent  → optional footer with action buttons (use GupButtonGroup) Two-way binding: @bind-Heading Events: OnFooterClick (fires when the footer area is clicked, useful for bubbling up button clicks without wiring each one individually)
```

## Import

```razor
@using GUPBlazor.Components
```

## Parameters

| Parameter | Type | Default | Bindable | Description |
|---|---|---|---|---|
| `Heading` | `string?` | — | `@bind-Heading` | Plain-text section heading. Use `Title` for rich content. |

## Slots (RenderFragment)

| Slot | Description |
|---|---|
| `<Title>` | Rich content for the section heading. Overrides `Heading`. |
| `<ChildContent>` | Main content of the section. |
| `<FooterContent>` | Optional footer — typically a GupButtonGroup with action buttons. |

> Named slots are child elements, not attributes. When you use any named slot, wrap the default content in `<ChildContent>` explicitly.

## Events

| Event | Type | Description |
|---|---|---|
| `HeadingChanged` | `EventCallback<string?>` |  |
| `OnFooterClick` | `EventCallback<MouseEventArgs>` | Fires when the footer area is clicked. |

## Examples

Verbatim from the demo pages — this is the markup that renders in the live demo.

### Default title content

<!-- from GUPBlazorDemo/Components/Pages/.../FormSection.razor -->
```razor
<GupFormSection>
    <Title>Personal information</Title>
    <ChildContent>
        <GupFormList>
            <GupInputField Name="default-first-name" Type="text">First name</GupInputField>
            <GupInputField Name="default-last-name" Type="text">Last name</GupInputField>
            <GupInputField Name="default-national-id" Type="text">National ID</GupInputField>
        </GupFormList>
    </ChildContent>
</GupFormSection>
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

### Multiple form sections

<!-- from GUPBlazorDemo/Components/Pages/.../FormSection.razor -->
```razor
<GupFormSection>
    <Title>Section 1 — Applicant</Title>
    <ChildContent>
        <GupFormList>
            <GupInputField Name="multi-name" Type="text">Full name</GupInputField>
            <GupInputField Name="multi-civil-id" Type="text">Civil ID</GupInputField>
        </GupFormList>
    </ChildContent>
</GupFormSection>

<GupFormSection>
    <Title>Section 2 — Address</Title>
    <ChildContent>
        <GupFormList>
            <GupInputField Name="multi-street" Type="text">Street</GupInputField>
            <GupInputField Name="multi-city" Type="text">City</GupInputField>
            <GupInputField Name="multi-postcode" Type="text">Postcode</GupInputField>
        </GupFormList>
    </ChildContent>
    <FooterContent>
        <GupButtonGroup>
            <GupButton Appearance="@GupButtonAppearance.Primary"
                       Kind="@GupButtonKind.Button">
                <ChildContent>Continue</ChildContent>
            </GupButton>
        </GupButtonGroup>
    </FooterContent>
</GupFormSection>
```

### Heading string string parameter

<!-- from GUPBlazorDemo/Components/Pages/.../FormSection.razor -->
```razor
<GupFormSection Heading="Quick heading via parameter">
    <ChildContent>
        <p style="margin: 0; color: var(--gup-color-content-primary);">
            The heading above was set with <code>Heading="..."</code>.
        </p>
    </ChildContent>
</GupFormSection>
```

### Rich title content

<!-- from GUPBlazorDemo/Components/Pages/.../FormSection.razor -->
```razor
<GupFormSection>
    <Title>
        <span style="display:inline-flex; align-items:center; gap:8px;">
            Identity verification
            <GupBadgeChip Appearance="@GupBadgeChipAppearance.Positive" IsFilled="true">
                <ChildContent>Verified</ChildContent>
            </GupBadgeChip>
        </span>
    </Title>
    <ChildContent>
        <p style="margin: 0; color: var(--gup-color-content-primary);">
            The Title slot can contain any markup — here it's combined with a badge chip.
        </p>
    </ChildContent>
</GupFormSection>
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

### Two way binding bind heading

<!-- from GUPBlazorDemo/Components/Pages/.../FormSection.razor -->
```razor
<div data-testid="bound-section">
    <GupFormSection @bind-Heading="_boundHeading">
        <ChildContent>
            <p style="margin: 0; color: var(--gup-color-content-primary);">
                The heading is bound to a parent variable. Edit it below and the title updates live.
            </p>
        </ChildContent>
    </GupFormSection>
</div>

<label style="display:flex; flex-direction:column; gap:8px; max-width:480px;">
    <span style="font-weight: var(--font-weight-base-beta);">Heading</span>
    <input data-testid="heading-input"
           type="text"
           value="@_boundHeading"
           @oninput="OnHeadingInput"
           style="padding:8px 12px; border:1px solid var(--gup-color-border-medium); border-radius:4px; font-size:16px;" />
</label>

<p data-testid="bind-output" style="margin:0;">
    Bound heading: <strong>@_boundHeading</strong>
</p>
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

Full component index: /ai/index.md · Start here: /docs

Absolute mirror, if relative links do not resolve for you: `https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-form-section.md`
