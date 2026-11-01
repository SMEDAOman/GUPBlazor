# GUPBlazor — conventions

The rules that are not visible from a parameter list. Read this before writing markup.

## Named slots are elements, not attributes

Most components take their content through `RenderFragment` slots. A slot is a child
**element**, never an attribute:

```razor
@* correct *@
<GupInputField Name="email" Type="email" @bind-Value="_email">
    <ChildContent>Email address</ChildContent>
    <Hint>We will only use this to contact you about your application.</Hint>
</GupInputField>

@* wrong — Hint is a slot, not a string attribute *@
<GupInputField Name="email" Hint="We will only use this..." />
```

**The rule that catches everyone:** as soon as you use *any* named slot, the default content
must also be wrapped in `<ChildContent>` explicitly. Bare text alongside a named slot will
not compile.

```razor
@* fine — only default content, no wrapper needed *@
<GupButton Appearance="@GupButtonAppearance.Primary">Submit</GupButton>

@* needs the wrapper, because IconStart is present *@
<GupButton Appearance="@GupButtonAppearance.Primary">
    <IconStart><GupIcon IconName="arrow-back" Width="20" Height="20" /></IconStart>
    <ChildContent>Back</ChildContent>
</GupButton>
```

## Enums, not strings

Variants are enums. Pass them with `@`:

```razor
<GupButton Appearance="@GupButtonAppearance.Primary" />
<GupButton Appearance="@GupButtonAppearance.Secondary" Kind="@GupButtonKind.Link" Href="/next" />
```

Each component's page lists its enums and every member.

## Two-way binding

Where a component exposes `Value` plus `ValueChanged`, use `@bind-Value`. The component docs
mark every bindable parameter.

```razor
<GupInputField Name="company" @bind-Value="_company" />
<GupToggle @bind-Checked="_optedIn" />
```

## Text fields are required by default

`GupInputField`, `GupTextarea` and `GupDropdownField` default `Required` to **true** — the
opposite of plain HTML. Opt a field out explicitly:

```razor
<GupInputField Name="middle-name" Required="false" @bind-Value="_middleName" />
```

`GupCheckbox` and `GupFileUpload` default `Required` to **false**. Check the component's
parameter table rather than assuming.

## Icons

`GupIcon` renders Material Symbols Outlined by ligature name. Always give an explicit size;
the font ligature will otherwise inherit surrounding type and look wrong.

```razor
<GupIcon IconName="arrow-forward" Width="20" Height="20" />
```

`Width` and `Height` default to 16, which is small for body text — 20 or 24 is the usual
choice inside a button. Icon names accept either `snake_case` or `kebab-case` (`live_help`
and `live-help` both resolve).

## RTL and Arabic

Styling uses CSS logical properties throughout (`margin-inline`, `inset-inline-start`), so
setting direction is all that is required — no mirrored stylesheet, no per-component flag:

```razor
<html dir="rtl" lang="ar">
```

`dir="rtl"` works on any container, not just `<html>`, which is how the demo previews a
single component in RTL.

## Read-only cascade

To lock a whole form, cascade one flag rather than setting `Readonly` on each field. Field
components read the cascading value named `GupReadOnly`:

```razor
<CascadingValue Name="GupReadOnly" Value="true">
    <GupFormSection>
        @* every field inside renders read-only *@
    </GupFormSection>
</CascadingValue>
```

`GupReadOnlyRegion` wraps this for a subtree.

## Render modes

The components are plain Blazor and do not set a render mode themselves. Anything
interactive — clicks, binding, dialogs, toasts — needs one from the host:

```razor
@rendermode InteractiveServer
```

Static server rendering is fine for display-only pages (tables, labelled items, prose).

## Toasts

Place a single `GupToastContainer` in the layout, then raise toasts through the injected
`ToastService`. Severity is a **string**, not an enum — one of `neutral` (default),
`positive`, `warning` or `negative`:

```razor
@inject ToastService Toasts
<GupButton OnClick="ShowSaved">Save</GupButton>

@code {
    private void ShowSaved() => Toasts.Show("Application saved", "positive");
}
```

`Show` returns a `Guid` you can pass to `Remove(id)`; `Clear()` dismisses all of them.
It also takes `delayMs` (default 5000) and `closeLabel`.

## Naming

Components are prefixed `Gup`. Four legacy ones use an uppercase `GUP` — `GUPHTMLHeader`,
`GUPHTMLFooter`, `GUPWizardStack`, `GUPWizardStackStep`. The casing is significant in Razor.

---

Full index: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/index.md