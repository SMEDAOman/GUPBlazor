# GUPBlazor — AI reference index

GUPBlazor 0.3.4: 69 documented Blazor components implementing the gov.om
(Government Unified Platform) design system, by the SMEs Development Authority (Oman).
WCAG 2.2 AA, full RTL, Arabic localization. Targets `net10.0`.

- Start here: /docs (conventions and a worked example inline)
- Everything in one file: /llms-full.txt
- Getting started: /ai/getting-started.md
- Types, services and helpers: /ai/types.md
- Patterns: /ai/patterns.md
- NuGet: https://www.nuget.org/packages/GUPBlazor
- Repository: https://github.com/SMEDAOman/GUPBlazor

Links below are relative to wherever this file is served from — resolve them
against this document's own URL.

## Components

| Component | Docs | Live demo | Summary |
|---|---|---|---|
| `GUPHTMLFooter` | [md](/ai/components/gup-html-footer.md) | — | Emits the scripts GUPBlazor needs. Place just before </body>. |
| `GUPHTMLHeader` | [md](/ai/components/gup-html-header.md) | — | Emits the stylesheet, font and design-token links GUPBlazor needs. Place inside <head>. |
| `GUPWizardStack` | [md](/ai/components/gup-wizard-stack.md) | [demo](/demo/wizard) | Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes. |
| `GUPWizardStackStep` | [md](/ai/components/gup-wizard-stack-step.md) | [demo](/demo/wizard) | Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes. |
| `GupAccordion` | [md](/ai/components/gup-accordion.md) | [demo](/demo/accordion) | Collapsible sections, single or multiple open, including item actions. |
| `GupAccordionItem` | [md](/ai/components/gup-accordion-item.md) | [demo](/demo/accordion) | Part of the Accordion component set — see the Accordion page for how it composes. |
| `GupAccordionItemAction` | [md](/ai/components/gup-accordion-item-action.md) | [demo](/demo/accordion) | Part of the Accordion component set — see the Accordion page for how it composes. |
| `GupAvatar` | [md](/ai/components/gup-avatar.md) | [demo](/demo/avatar) | User avatar from initials or an image. |
| `GupBadge` | [md](/ai/components/gup-badge.md) | [demo](/demo/badges) | Status badges in the full colour range. |
| `GupBadgeChip` | [md](/ai/components/gup-badge-chip.md) | [demo](/demo/badge-chips) | Compact status chips with optional icon. |
| `GupBanner` | [md](/ai/components/gup-banner.md) | [demo](/demo/banner) | Page-level messages in four severities, outline and filled appearances. |
| `GupBreadcrumbs` | [md](/ai/components/gup-breadcrumbs.md) | [demo](/demo/breadcrumbs) | Trail with current-item state; collapses to first and last below 599px. |
| `GupBreadcrumbsItem` | [md](/ai/components/gup-breadcrumbs-item.md) | [demo](/demo/breadcrumbs) | Part of the Breadcrumbs component set — see the Breadcrumbs page for how it composes. |
| `GupButton` | [md](/ai/components/gup-button.md) | [demo](/demo/buttons) | Button appearances, icons, disabled states, and button groups. |
| `GupButtonGroup` | [md](/ai/components/gup-button-group.md) | [demo](/demo/button-group) | Groups of related buttons, with the stacking behaviour used on mobile. |
| `GupCallout` | [md](/ai/components/gup-callout.md) | [demo](/demo/callout) | Block quote with optional author, in three appearances. |
| `GupCheckbox` | [md](/ai/components/gup-checkbox.md) | [demo](/demo/inputs/checkbox) | Single, grouped and indeterminate states. |
| `GupContentHeader` | [md](/ai/components/gup-content-header.md) | [demo](/demo/content-header) | Page title, summary and optional actions at the top of a page. |
| `GupDataSheet` | [md](/ai/components/gup-data-sheet.md) | [demo](/demo/data-sheet) | Bordered card grouping labelled items — order summaries and similar. |
| `GupDataTable` | [md](/ai/components/gup-data-table.md) | [demo](/demo/data-table) | Table chrome around GupTable — search, filter panel with removable chips, empty state, pagination footer. |
| `GupDetails` | [md](/ai/components/gup-details.md) | [demo](/demo/details) | Single disclosure with quote, sink and none appearances. |
| `GupDialog` | [md](/ai/components/gup-dialog.md) | [demo](/demo/dialogs) | Modal in five sizes including fullscreen, with action buttons. |
| `GupDivider` | [md](/ai/components/gup-divider.md) | [demo](/demo/divider) | Horizontal and vertical rules with spacing options. |
| `GupDropdownField` | [md](/ai/components/gup-dropdown-field.md) | [demo](/demo/inputs/dropdown) | Part of the Dropdown component set — see the Dropdown page for how it composes. |
| `GupDropdownMenu` | [md](/ai/components/gup-dropdown-menu.md) | [demo](/demo/inputs/dropdown) | Part of the Dropdown component set — see the Dropdown page for how it composes. |
| `GupDropdownMenuItem` | [md](/ai/components/gup-dropdown-menu-item.md) | [demo](/demo/inputs/dropdown) | Part of the Dropdown component set — see the Dropdown page for how it composes. |
| `GupFileItem` | [md](/ai/components/gup-file-item.md) | [demo](/demo/file-item) | A single uploaded file row with size, link and remove action. |
| `GupFileUpload` | [md](/ai/components/gup-file-upload.md) | [demo](/demo/file-upload) | Drag-and-drop or browse, with file list and remove actions. |
| `GupFilterChip` | [md](/ai/components/gup-filter-chip.md) | [demo](/demo/filter-chip) | Removable chips for active filters. |
| `GupFilterChipWrapper` | [md](/ai/components/gup-filter-chip-wrapper.md) | [demo](/demo/filter-chip) | Part of the Filter chip component set — see the Filter chip page for how it composes. |
| `GupFlag` | [md](/ai/components/gup-flag.md) | [demo](/demo/flag) | Country flags in rectangle and circle shapes. |
| `GupFlyout` | [md](/ai/components/gup-flyout.md) | [demo](/demo/flyout) | Side panel from any edge — the mobile-friendly home for add-row forms. |
| `GupFormList` | [md](/ai/components/gup-form-list.md) | [demo](/demo/form-list) | Part of the Form list component set — see the Form list page for how it composes. |
| `GupFormSection` | [md](/ai/components/gup-form-section.md) | [demo](/demo/form-section) | Titled section with optional footer for action buttons. |
| `GupHeader` | [md](/ai/components/gup-header.md) | [demo](/demo/header) | The service header — brand, service name, language toggle and account area. |
| `GupIcon` | [md](/ai/components/gup-icon.md) | [demo](/demo/icons) | Part of the Icons component set — see the Icons page for how it composes. |
| `GupImage` | [md](/ai/components/gup-image.md) | [demo](/demo/image) | Responsive image with aspect-ratio and object-fit control. |
| `GupInputField` | [md](/ai/components/gup-input-field.md) | [demo](/demo/inputs/text) | Single-line text with label, hint, error and read-only states. |
| `GupLabelledItem` | [md](/ai/components/gup-labelled-item.md) | [demo](/demo/labelled-item) | Part of the Labelled item component set — see the Labelled item page for how it composes. |
| `GupLink` | [md](/ai/components/gup-link.md) | [demo](/demo/buttons) | Part of the Button component set — see the Button page for how it composes. |
| `GupLogo` | [md](/ai/components/gup-logo.md) | [demo](/demo/logo) | GupLogo in icon and horizontal lockups, with inversion for dark surfaces. |
| `GupPageStatus` | [md](/ai/components/gup-page-status.md) | [demo](/demo/page-status) | Empty, error and loading states for a whole page. |
| `GupPagination` | [md](/ai/components/gup-pagination.md) | [demo](/demo/pagination) | Page controls with previous/next and page-number buttons. |
| `GupRadioButton` | [md](/ai/components/gup-radio-button.md) | [demo](/demo/inputs/radio) | Radio groups, horizontal and vertical. |
| `GupRadioButtonGroup` | [md](/ai/components/gup-radio-button-group.md) | [demo](/demo/inputs/radio) | Part of the Radio button component set — see the Radio button page for how it composes. |
| `GupReadOnlyRegion` | [md](/ai/components/gup-read-only-region.md) | [demo](/demo/read-only-cascade) | Part of the Read-only cascade component set — see the Read-only cascade page for how it composes. |
| `GupRichText` | [md](/ai/components/gup-rich-text.md) | [demo](/demo/rich-text) | Prose block that styles headings, lists and links coming from a CMS or editor. |
| `GupScreenReaderText` | [md](/ai/components/gup-screen-reader-text.md) | [demo](/demo/screenreader-text) | Part of the Screenreader text component set — see the Screenreader text page for how it composes. |
| `GupSearch` | [md](/ai/components/gup-search.md) | [demo](/demo/search) | Search field with submit and clear affordances. |
| `GupSkipLink` | [md](/ai/components/gup-skip-link.md) | [demo](/demo/skip-link) | Keyboard-only link that jumps past the header to main content. |
| `GupSpinner` | [md](/ai/components/gup-spinner.md) | [demo](/demo/spinner) | Indeterminate loading indicator in several sizes. |
| `GupStepper` | [md](/ai/components/gup-stepper.md) | [demo](/demo/stepper) | The wizard progress indicator, with stepper items in complete, current and upcoming states. |
| `GupStepperItem` | [md](/ai/components/gup-stepper-item.md) | [demo](/demo/stepper) | Part of the Stepper component set — see the Stepper page for how it composes. |
| `GupTab` | [md](/ai/components/gup-tab.md) | [demo](/demo/tabs) | Part of the Tabs component set — see the Tabs page for how it composes. |
| `GupTabPanel` | [md](/ai/components/gup-tab-panel.md) | [demo](/demo/tabs) | Part of the Tabs component set — see the Tabs page for how it composes. |
| `GupTable` | [md](/ai/components/gup-table.md) | [demo](/demo/table-cell) | Part of the Table & table cell component set — see the Table & table cell page for how it composes. |
| `GupTableCell` | [md](/ai/components/gup-table-cell.md) | [demo](/demo/table-cell) | Part of the Table & table cell component set — see the Table & table cell page for how it composes. |
| `GupTableRow` | [md](/ai/components/gup-table-row.md) | [demo](/demo/table-cell) | Part of the Table & table cell component set — see the Table & table cell page for how it composes. |
| `GupTabs` | [md](/ai/components/gup-tabs.md) | [demo](/demo/tabs) | Default, toggle and vertical appearances, with tab panels and tabs navigation. |
| `GupTabsNavigation` | [md](/ai/components/gup-tabs-navigation.md) | [demo](/demo/tabs) | Part of the Tabs component set — see the Tabs page for how it composes. |
| `GupTextarea` | [md](/ai/components/gup-textarea.md) | [demo](/demo/inputs/textarea) | Part of the Textarea field component set — see the Textarea field page for how it composes. |
| `GupToast` | [md](/ai/components/gup-toast.md) | [demo](/demo/toasts) | Part of the Toast & toast container component set — see the Toast & toast container page for how it composes. |
| `GupToastContainer` | [md](/ai/components/gup-toast-container.md) | [demo](/demo/toasts) | Part of the Toast & toast container component set — see the Toast & toast container page for how it composes. |
| `GupToggle` | [md](/ai/components/gup-toggle.md) | [demo](/demo/inputs/toggle) | On/off switch with label and hint. |
| `GupTooltip` | [md](/ai/components/gup-tooltip.md) | [demo](/demo/tooltip) | Hover and focus tooltip with placement options. |
| `GupTrack` | [md](/ai/components/gup-track.md) | [demo](/demo/track) | GupTrack — the spacing primitive used to lay out rows and columns on the design system scale. |
| `GupWizard` | [md](/ai/components/gup-wizard.md) | [demo](/demo/wizard) | Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes. |
| `GupWizardFooter` | [md](/ai/components/gup-wizard-footer.md) | [demo](/demo/wizard) | Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes. |
| `GupWizardMain` | [md](/ai/components/gup-wizard-main.md) | [demo](/demo/wizard) | Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes. |

## Demo catalogue

### Documentation

How to install the library and the conventions worth knowing before you build a page.

- [Welcome](/demo/welcome) — What the library is, what ships with it, and how it relates to the upstream gov.om design system.
- [Installation](/demo/installation) — Add the NuGet package, register the services, and wire up the styles and scripts.
- [Usage](/demo/usage) — Utility components, spacing, icons, tokens and RTL — the conventions behind the component pages.
- [Design tokens](/demo/design-tokens) — Every CSS custom property the library exports, read live from gup.css.
- [Versions](/demo/versions) — What ships, the target framework, and how it maps to the upstream design system.
- [Feedback](/demo/feedback-contact) — Where to report a bug in this port, and where to ask about the design system itself.

### Tools

For checking a page before it ships.

- [Device Preview](/demo/device-preview) — View any page in this demo at a real phone or tablet viewport, with a live readout of which gup.css breakpoints are active.

### Foundations

Tokens and layout primitives everything else is built from.

- [Branding](/demo/branding) — Logo, icons, color tokens, and typography scale.
- [Logo](/demo/logo) — GupLogo in icon and horizontal lockups, with inversion for dark surfaces.
- [Icons](/demo/icons) — Material Symbols Outlined — sizes, fill, weight, grade, and color.
- [Track](/demo/track) — GupTrack — the spacing primitive used to lay out rows and columns on the design system scale.
- [Layout](/demo/layout) — Track, grid, container and the page-shell components.
- [Divider](/demo/divider) — Horizontal and vertical rules with spacing options.
- [Image](/demo/image) — Responsive image with aspect-ratio and object-fit control.
- [Flag](/demo/flag) — Country flags in rectangle and circle shapes.
- [Rich text](/demo/rich-text) — Prose block that styles headings, lists and links coming from a CMS or editor.

### Components

The component set, grouped the way the upstream Storybook groups it.

- [Button](/demo/buttons) — Button appearances, icons, disabled states, and button groups.
- [Button group](/demo/button-group) — Groups of related buttons, with the stacking behaviour used on mobile.
- [Banner](/demo/banner) — Page-level messages in four severities, outline and filled appearances.
- [Callout](/demo/callout) — Block quote with optional author, in three appearances.
- [Badge](/demo/badges) — Status badges in the full colour range.
- [Badge chip](/demo/badge-chips) — Compact status chips with optional icon.
- [Filter chip](/demo/filter-chip) — Removable chips for active filters.
- [Avatar](/demo/avatar) — User avatar from initials or an image.
- [Tooltip](/demo/tooltip) — Hover and focus tooltip with placement options.
- [Details](/demo/details) — Single disclosure with quote, sink and none appearances.
- [Spinner](/demo/spinner) — Indeterminate loading indicator in several sizes.
- [Page status](/demo/page-status) — Empty, error and loading states for a whole page.
- [Labelled item](/demo/labelled-item) — Label and value pair for read-only data.
- [File item](/demo/file-item) — A single uploaded file row with size, link and remove action.
- [Screenreader text](/demo/screenreader-text) — Visually hidden text that assistive technology still announces.
- [Skip link](/demo/skip-link) — Keyboard-only link that jumps past the header to main content.
- [Search](/demo/search) — Search field with submit and clear affordances.
- [Pagination](/demo/pagination) — Page controls with previous/next and page-number buttons.
- [Feedback](/demo/feedback) — Inline feedback prompt and rating control.
- [Header](/demo/header) — The service header — brand, service name, language toggle and account area.
- [Content header](/demo/content-header) — Page title, summary and optional actions at the top of a page.
- [Wizard main & footer](/demo/wizard) — The wizard shell: main content region and the pinned Back/Continue footer.
- [Form components (all-in-one)](/demo/forms) — Input fields, form sections, checkboxes, radio buttons, and dropdowns on one page.
- [Input field](/demo/inputs/text) — Single-line text with label, hint, error and read-only states.
- [Email input](/demo/inputs/email) — type=email with the WHATWG pattern and a leading icon.
- [Phone input](/demo/inputs/tel) — type=tel — raises the telephone keypad on mobile.
- [Number input](/demo/inputs/number) — type=number for incremental values; spinners included.
- [Date input](/demo/inputs/date) — Native date control with RTL-aware mirroring.
- [Password input](/demo/inputs/password) — Masked entry with a reveal toggle.
- [Textarea field](/demo/inputs/textarea) — Multi-line entry with character counter.
- [Checkbox](/demo/inputs/checkbox) — Single, grouped and indeterminate states.
- [Radio button](/demo/inputs/radio) — Radio groups, horizontal and vertical.
- [Toggle](/demo/inputs/toggle) — On/off switch with label and hint.
- [Dropdown](/demo/inputs/dropdown) — Single and multi-select with search, clear and grouped options.
- [File upload](/demo/file-upload) — Drag-and-drop or browse, with file list and remove actions.
- [Form section](/demo/form-section) — Titled section with optional footer for action buttons.
- [Form list](/demo/form-list) — Repeating rows of fields with add and remove controls.
- [Hint & validation message](/demo/hint-validation) — The hint and error slots shared by every field component.
- [Error summary](/demo/error-summary) — Validation summary banner that links each error to its field.
- [Read-only cascade](/demo/read-only-cascade) — Lock every field on a page with one cascaded flag, plus GupReadOnlyRegion.
- [Breadcrumbs](/demo/breadcrumbs) — Trail with current-item state; collapses to first and last below 599px.
- [Tabs](/demo/tabs) — Default, toggle and vertical appearances, with tab panels and tabs navigation.
- [Stepper](/demo/stepper) — The wizard progress indicator, with stepper items in complete, current and upcoming states.
- [Accordion](/demo/accordion) — Collapsible sections, single or multiple open, including item actions.
- [Data table](/demo/data-table) — Table chrome around GupTable — search, filter panel with removable chips, empty state, pagination footer.
- [Table & table cell](/demo/table-cell) — The table primitives — header, row and cell, including alignment and wrapping.
- [Data display](/demo/data-display) — Labelled items and key/value layouts for read-only data.
- [Data sheet](/demo/data-sheet) — Bordered card grouping labelled items — order summaries and similar.
- [Dialog](/demo/dialogs) — Modal in five sizes including fullscreen, with action buttons.
- [Flyout](/demo/flyout) — Side panel from any edge — the mobile-friendly home for add-row forms.
- [Toast & toast container](/demo/toasts) — Transient messages in four severities, stacked bottom-end by the global container.

### Patterns

Compositions that solve a recurring task — built from the components above.

- [Add row](/demo/patterns/add-row) — Adding rows to a list, with the flyout form and the table that receives them.
- [Address form](/demo/patterns/address-form) — The standard address field set, in the order and grouping services use.
- [Credit card payment](/demo/patterns/credit-card-payment) — Card entry with formatting, validation and the review step.

### Page templates

Whole-page compositions — the shapes a service actually ships. Each is a faithful port of the matching upstream Storybook template.

- [Service Start](/service-start) — The wizard shell: header, content header, stepper, step content and a pinned footer with Back/Continue.
- [Service Provider Confirmation](/application-completed) — Confirmation page after submission — summary tables, primary and secondary actions, feedback link.
- [Service Provider Sign In](/sign-in) — Sign-in screen for a service provider, with the standard page chrome.
- [Help Service](/help) — Help and FAQ layout — long-form prose constrained to a readable measure.
- [Templates index](/templates) — Plain list of the template pages with their routes.

