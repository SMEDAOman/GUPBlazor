# GUPBlazor — AI reference index

GUPBlazor 0.3.4: 69 documented Blazor components implementing the gov.om
(Government Unified Platform) design system, by the SMEs Development Authority (Oman).
WCAG 2.2 AA, full RTL, Arabic localization. Targets `net10.0`.

- Start here: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/docs (conventions and a worked example inline)
- Everything in one file: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/llms-full.txt
- Getting started: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/getting-started.md
- Types, services and helpers: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/types.md
- Patterns: https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/patterns.md
- NuGet: https://www.nuget.org/packages/GUPBlazor
- Repository: https://github.com/SMEDAOman/GUPBlazor

## Components

| Component | Docs | Live demo | Summary |
|---|---|---|---|
| `GUPHTMLFooter` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-html-footer.md) | — | Emits the scripts GUPBlazor needs. Place just before </body>. |
| `GUPHTMLHeader` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-html-header.md) | — | Emits the stylesheet, font and design-token links GUPBlazor needs. Place inside <head>. |
| `GUPWizardStack` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-wizard-stack.md) | [demo](https://gupdesign.sme.gov.om/demo/wizard) | Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes. |
| `GUPWizardStackStep` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-wizard-stack-step.md) | [demo](https://gupdesign.sme.gov.om/demo/wizard) | Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes. |
| `GupAccordion` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-accordion.md) | [demo](https://gupdesign.sme.gov.om/demo/accordion) | Collapsible sections, single or multiple open, including item actions. |
| `GupAccordionItem` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-accordion-item.md) | [demo](https://gupdesign.sme.gov.om/demo/accordion) | Part of the Accordion component set — see the Accordion page for how it composes. |
| `GupAccordionItemAction` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-accordion-item-action.md) | [demo](https://gupdesign.sme.gov.om/demo/accordion) | Part of the Accordion component set — see the Accordion page for how it composes. |
| `GupAvatar` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-avatar.md) | [demo](https://gupdesign.sme.gov.om/demo/avatar) | User avatar from initials or an image. |
| `GupBadge` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-badge.md) | [demo](https://gupdesign.sme.gov.om/demo/badges) | Status badges in the full colour range. |
| `GupBadgeChip` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-badge-chip.md) | [demo](https://gupdesign.sme.gov.om/demo/badge-chips) | Compact status chips with optional icon. |
| `GupBanner` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-banner.md) | [demo](https://gupdesign.sme.gov.om/demo/banner) | Page-level messages in four severities, outline and filled appearances. |
| `GupBreadcrumbs` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-breadcrumbs.md) | [demo](https://gupdesign.sme.gov.om/demo/breadcrumbs) | Trail with current-item state; collapses to first and last below 599px. |
| `GupBreadcrumbsItem` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-breadcrumbs-item.md) | [demo](https://gupdesign.sme.gov.om/demo/breadcrumbs) | Part of the Breadcrumbs component set — see the Breadcrumbs page for how it composes. |
| `GupButton` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-button.md) | [demo](https://gupdesign.sme.gov.om/demo/buttons) | Button appearances, icons, disabled states, and button groups. |
| `GupButtonGroup` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-button-group.md) | [demo](https://gupdesign.sme.gov.om/demo/button-group) | Groups of related buttons, with the stacking behaviour used on mobile. |
| `GupCallout` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-callout.md) | [demo](https://gupdesign.sme.gov.om/demo/callout) | Block quote with optional author, in three appearances. |
| `GupCheckbox` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-checkbox.md) | [demo](https://gupdesign.sme.gov.om/demo/inputs/checkbox) | Single, grouped and indeterminate states. |
| `GupContentHeader` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-content-header.md) | [demo](https://gupdesign.sme.gov.om/demo/content-header) | Page title, summary and optional actions at the top of a page. |
| `GupDataSheet` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-data-sheet.md) | [demo](https://gupdesign.sme.gov.om/demo/data-sheet) | Bordered card grouping labelled items — order summaries and similar. |
| `GupDataTable` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-data-table.md) | [demo](https://gupdesign.sme.gov.om/demo/data-table) | Table chrome around GupTable — search, filter panel with removable chips, empty state, pagination footer. |
| `GupDetails` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-details.md) | [demo](https://gupdesign.sme.gov.om/demo/details) | Single disclosure with quote, sink and none appearances. |
| `GupDialog` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-dialog.md) | [demo](https://gupdesign.sme.gov.om/demo/dialogs) | Modal in five sizes including fullscreen, with action buttons. |
| `GupDivider` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-divider.md) | [demo](https://gupdesign.sme.gov.om/demo/divider) | Horizontal and vertical rules with spacing options. |
| `GupDropdownField` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-dropdown-field.md) | [demo](https://gupdesign.sme.gov.om/demo/inputs/dropdown) | Part of the Dropdown component set — see the Dropdown page for how it composes. |
| `GupDropdownMenu` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-dropdown-menu.md) | [demo](https://gupdesign.sme.gov.om/demo/inputs/dropdown) | Part of the Dropdown component set — see the Dropdown page for how it composes. |
| `GupDropdownMenuItem` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-dropdown-menu-item.md) | [demo](https://gupdesign.sme.gov.om/demo/inputs/dropdown) | Part of the Dropdown component set — see the Dropdown page for how it composes. |
| `GupFileItem` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-file-item.md) | [demo](https://gupdesign.sme.gov.om/demo/file-item) | A single uploaded file row with size, link and remove action. |
| `GupFileUpload` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-file-upload.md) | [demo](https://gupdesign.sme.gov.om/demo/file-upload) | Drag-and-drop or browse, with file list and remove actions. |
| `GupFilterChip` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-filter-chip.md) | [demo](https://gupdesign.sme.gov.om/demo/filter-chip) | Removable chips for active filters. |
| `GupFilterChipWrapper` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-filter-chip-wrapper.md) | [demo](https://gupdesign.sme.gov.om/demo/filter-chip) | Part of the Filter chip component set — see the Filter chip page for how it composes. |
| `GupFlag` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-flag.md) | [demo](https://gupdesign.sme.gov.om/demo/flag) | Country flags in rectangle and circle shapes. |
| `GupFlyout` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-flyout.md) | [demo](https://gupdesign.sme.gov.om/demo/flyout) | Side panel from any edge — the mobile-friendly home for add-row forms. |
| `GupFormList` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-form-list.md) | [demo](https://gupdesign.sme.gov.om/demo/form-list) | Part of the Form list component set — see the Form list page for how it composes. |
| `GupFormSection` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-form-section.md) | [demo](https://gupdesign.sme.gov.om/demo/form-section) | Titled section with optional footer for action buttons. |
| `GupHeader` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-header.md) | [demo](https://gupdesign.sme.gov.om/demo/header) | The service header — brand, service name, language toggle and account area. |
| `GupIcon` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-icon.md) | [demo](https://gupdesign.sme.gov.om/demo/icons) | Part of the Icons component set — see the Icons page for how it composes. |
| `GupImage` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-image.md) | [demo](https://gupdesign.sme.gov.om/demo/image) | Responsive image with aspect-ratio and object-fit control. |
| `GupInputField` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-input-field.md) | [demo](https://gupdesign.sme.gov.om/demo/inputs/text) | Single-line text with label, hint, error and read-only states. |
| `GupLabelledItem` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-labelled-item.md) | [demo](https://gupdesign.sme.gov.om/demo/labelled-item) | Part of the Labelled item component set — see the Labelled item page for how it composes. |
| `GupLink` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-link.md) | [demo](https://gupdesign.sme.gov.om/demo/buttons) | Part of the Button component set — see the Button page for how it composes. |
| `GupLogo` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-logo.md) | [demo](https://gupdesign.sme.gov.om/demo/logo) | GupLogo in icon and horizontal lockups, with inversion for dark surfaces. |
| `GupPageStatus` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-page-status.md) | [demo](https://gupdesign.sme.gov.om/demo/page-status) | Empty, error and loading states for a whole page. |
| `GupPagination` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-pagination.md) | [demo](https://gupdesign.sme.gov.om/demo/pagination) | Page controls with previous/next and page-number buttons. |
| `GupRadioButton` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-radio-button.md) | [demo](https://gupdesign.sme.gov.om/demo/inputs/radio) | Radio groups, horizontal and vertical. |
| `GupRadioButtonGroup` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-radio-button-group.md) | [demo](https://gupdesign.sme.gov.om/demo/inputs/radio) | Part of the Radio button component set — see the Radio button page for how it composes. |
| `GupReadOnlyRegion` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-read-only-region.md) | [demo](https://gupdesign.sme.gov.om/demo/read-only-cascade) | Part of the Read-only cascade component set — see the Read-only cascade page for how it composes. |
| `GupRichText` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-rich-text.md) | [demo](https://gupdesign.sme.gov.om/demo/rich-text) | Prose block that styles headings, lists and links coming from a CMS or editor. |
| `GupScreenReaderText` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-screen-reader-text.md) | [demo](https://gupdesign.sme.gov.om/demo/screenreader-text) | Part of the Screenreader text component set — see the Screenreader text page for how it composes. |
| `GupSearch` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-search.md) | [demo](https://gupdesign.sme.gov.om/demo/search) | Search field with submit and clear affordances. |
| `GupSkipLink` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-skip-link.md) | [demo](https://gupdesign.sme.gov.om/demo/skip-link) | Keyboard-only link that jumps past the header to main content. |
| `GupSpinner` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-spinner.md) | [demo](https://gupdesign.sme.gov.om/demo/spinner) | Indeterminate loading indicator in several sizes. |
| `GupStepper` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-stepper.md) | [demo](https://gupdesign.sme.gov.om/demo/stepper) | The wizard progress indicator, with stepper items in complete, current and upcoming states. |
| `GupStepperItem` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-stepper-item.md) | [demo](https://gupdesign.sme.gov.om/demo/stepper) | Part of the Stepper component set — see the Stepper page for how it composes. |
| `GupTab` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-tab.md) | [demo](https://gupdesign.sme.gov.om/demo/tabs) | Part of the Tabs component set — see the Tabs page for how it composes. |
| `GupTabPanel` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-tab-panel.md) | [demo](https://gupdesign.sme.gov.om/demo/tabs) | Part of the Tabs component set — see the Tabs page for how it composes. |
| `GupTable` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-table.md) | [demo](https://gupdesign.sme.gov.om/demo/table-cell) | Part of the Table & table cell component set — see the Table & table cell page for how it composes. |
| `GupTableCell` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-table-cell.md) | [demo](https://gupdesign.sme.gov.om/demo/table-cell) | Part of the Table & table cell component set — see the Table & table cell page for how it composes. |
| `GupTableRow` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-table-row.md) | [demo](https://gupdesign.sme.gov.om/demo/table-cell) | Part of the Table & table cell component set — see the Table & table cell page for how it composes. |
| `GupTabs` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-tabs.md) | [demo](https://gupdesign.sme.gov.om/demo/tabs) | Default, toggle and vertical appearances, with tab panels and tabs navigation. |
| `GupTabsNavigation` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-tabs-navigation.md) | [demo](https://gupdesign.sme.gov.om/demo/tabs) | Part of the Tabs component set — see the Tabs page for how it composes. |
| `GupTextarea` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-textarea.md) | [demo](https://gupdesign.sme.gov.om/demo/inputs/textarea) | Part of the Textarea field component set — see the Textarea field page for how it composes. |
| `GupToast` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-toast.md) | [demo](https://gupdesign.sme.gov.om/demo/toasts) | Part of the Toast & toast container component set — see the Toast & toast container page for how it composes. |
| `GupToastContainer` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-toast-container.md) | [demo](https://gupdesign.sme.gov.om/demo/toasts) | Part of the Toast & toast container component set — see the Toast & toast container page for how it composes. |
| `GupToggle` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-toggle.md) | [demo](https://gupdesign.sme.gov.om/demo/inputs/toggle) | On/off switch with label and hint. |
| `GupTooltip` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-tooltip.md) | [demo](https://gupdesign.sme.gov.om/demo/tooltip) | Hover and focus tooltip with placement options. |
| `GupTrack` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-track.md) | [demo](https://gupdesign.sme.gov.om/demo/track) | GupTrack — the spacing primitive used to lay out rows and columns on the design system scale. |
| `GupWizard` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-wizard.md) | [demo](https://gupdesign.sme.gov.om/demo/wizard) | Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes. |
| `GupWizardFooter` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-wizard-footer.md) | [demo](https://gupdesign.sme.gov.om/demo/wizard) | Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes. |
| `GupWizardMain` | [md](https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs/ai/components/gup-wizard-main.md) | [demo](https://gupdesign.sme.gov.om/demo/wizard) | Part of the Wizard main & footer component set — see the Wizard main & footer page for how it composes. |

## Demo catalogue

### Documentation

How to install the library and the conventions worth knowing before you build a page.

- [Welcome](https://gupdesign.sme.gov.om/demo/welcome) — What the library is, what ships with it, and how it relates to the upstream gov.om design system.
- [Installation](https://gupdesign.sme.gov.om/demo/installation) — Add the NuGet package, register the services, and wire up the styles and scripts.
- [Usage](https://gupdesign.sme.gov.om/demo/usage) — Utility components, spacing, icons, tokens and RTL — the conventions behind the component pages.
- [Design tokens](https://gupdesign.sme.gov.om/demo/design-tokens) — Every CSS custom property the library exports, read live from gup.css.
- [Versions](https://gupdesign.sme.gov.om/demo/versions) — What ships, the target framework, and how it maps to the upstream design system.
- [Feedback](https://gupdesign.sme.gov.om/demo/feedback-contact) — Where to report a bug in this port, and where to ask about the design system itself.

### Tools

For checking a page before it ships.

- [Device Preview](https://gupdesign.sme.gov.om/demo/device-preview) — View any page in this demo at a real phone or tablet viewport, with a live readout of which gup.css breakpoints are active.

### Foundations

Tokens and layout primitives everything else is built from.

- [Branding](https://gupdesign.sme.gov.om/demo/branding) — Logo, icons, color tokens, and typography scale.
- [Logo](https://gupdesign.sme.gov.om/demo/logo) — GupLogo in icon and horizontal lockups, with inversion for dark surfaces.
- [Icons](https://gupdesign.sme.gov.om/demo/icons) — Material Symbols Outlined — sizes, fill, weight, grade, and color.
- [Track](https://gupdesign.sme.gov.om/demo/track) — GupTrack — the spacing primitive used to lay out rows and columns on the design system scale.
- [Layout](https://gupdesign.sme.gov.om/demo/layout) — Track, grid, container and the page-shell components.
- [Divider](https://gupdesign.sme.gov.om/demo/divider) — Horizontal and vertical rules with spacing options.
- [Image](https://gupdesign.sme.gov.om/demo/image) — Responsive image with aspect-ratio and object-fit control.
- [Flag](https://gupdesign.sme.gov.om/demo/flag) — Country flags in rectangle and circle shapes.
- [Rich text](https://gupdesign.sme.gov.om/demo/rich-text) — Prose block that styles headings, lists and links coming from a CMS or editor.

### Components

The component set, grouped the way the upstream Storybook groups it.

- [Button](https://gupdesign.sme.gov.om/demo/buttons) — Button appearances, icons, disabled states, and button groups.
- [Button group](https://gupdesign.sme.gov.om/demo/button-group) — Groups of related buttons, with the stacking behaviour used on mobile.
- [Banner](https://gupdesign.sme.gov.om/demo/banner) — Page-level messages in four severities, outline and filled appearances.
- [Callout](https://gupdesign.sme.gov.om/demo/callout) — Block quote with optional author, in three appearances.
- [Badge](https://gupdesign.sme.gov.om/demo/badges) — Status badges in the full colour range.
- [Badge chip](https://gupdesign.sme.gov.om/demo/badge-chips) — Compact status chips with optional icon.
- [Filter chip](https://gupdesign.sme.gov.om/demo/filter-chip) — Removable chips for active filters.
- [Avatar](https://gupdesign.sme.gov.om/demo/avatar) — User avatar from initials or an image.
- [Tooltip](https://gupdesign.sme.gov.om/demo/tooltip) — Hover and focus tooltip with placement options.
- [Details](https://gupdesign.sme.gov.om/demo/details) — Single disclosure with quote, sink and none appearances.
- [Spinner](https://gupdesign.sme.gov.om/demo/spinner) — Indeterminate loading indicator in several sizes.
- [Page status](https://gupdesign.sme.gov.om/demo/page-status) — Empty, error and loading states for a whole page.
- [Labelled item](https://gupdesign.sme.gov.om/demo/labelled-item) — Label and value pair for read-only data.
- [File item](https://gupdesign.sme.gov.om/demo/file-item) — A single uploaded file row with size, link and remove action.
- [Screenreader text](https://gupdesign.sme.gov.om/demo/screenreader-text) — Visually hidden text that assistive technology still announces.
- [Skip link](https://gupdesign.sme.gov.om/demo/skip-link) — Keyboard-only link that jumps past the header to main content.
- [Search](https://gupdesign.sme.gov.om/demo/search) — Search field with submit and clear affordances.
- [Pagination](https://gupdesign.sme.gov.om/demo/pagination) — Page controls with previous/next and page-number buttons.
- [Feedback](https://gupdesign.sme.gov.om/demo/feedback) — Inline feedback prompt and rating control.
- [Header](https://gupdesign.sme.gov.om/demo/header) — The service header — brand, service name, language toggle and account area.
- [Content header](https://gupdesign.sme.gov.om/demo/content-header) — Page title, summary and optional actions at the top of a page.
- [Wizard main & footer](https://gupdesign.sme.gov.om/demo/wizard) — The wizard shell: main content region and the pinned Back/Continue footer.
- [Form components (all-in-one)](https://gupdesign.sme.gov.om/demo/forms) — Input fields, form sections, checkboxes, radio buttons, and dropdowns on one page.
- [Input field](https://gupdesign.sme.gov.om/demo/inputs/text) — Single-line text with label, hint, error and read-only states.
- [Email input](https://gupdesign.sme.gov.om/demo/inputs/email) — type=email with the WHATWG pattern and a leading icon.
- [Phone input](https://gupdesign.sme.gov.om/demo/inputs/tel) — type=tel — raises the telephone keypad on mobile.
- [Number input](https://gupdesign.sme.gov.om/demo/inputs/number) — type=number for incremental values; spinners included.
- [Date input](https://gupdesign.sme.gov.om/demo/inputs/date) — Native date control with RTL-aware mirroring.
- [Password input](https://gupdesign.sme.gov.om/demo/inputs/password) — Masked entry with a reveal toggle.
- [Textarea field](https://gupdesign.sme.gov.om/demo/inputs/textarea) — Multi-line entry with character counter.
- [Checkbox](https://gupdesign.sme.gov.om/demo/inputs/checkbox) — Single, grouped and indeterminate states.
- [Radio button](https://gupdesign.sme.gov.om/demo/inputs/radio) — Radio groups, horizontal and vertical.
- [Toggle](https://gupdesign.sme.gov.om/demo/inputs/toggle) — On/off switch with label and hint.
- [Dropdown](https://gupdesign.sme.gov.om/demo/inputs/dropdown) — Single and multi-select with search, clear and grouped options.
- [File upload](https://gupdesign.sme.gov.om/demo/file-upload) — Drag-and-drop or browse, with file list and remove actions.
- [Form section](https://gupdesign.sme.gov.om/demo/form-section) — Titled section with optional footer for action buttons.
- [Form list](https://gupdesign.sme.gov.om/demo/form-list) — Repeating rows of fields with add and remove controls.
- [Hint & validation message](https://gupdesign.sme.gov.om/demo/hint-validation) — The hint and error slots shared by every field component.
- [Error summary](https://gupdesign.sme.gov.om/demo/error-summary) — Validation summary banner that links each error to its field.
- [Read-only cascade](https://gupdesign.sme.gov.om/demo/read-only-cascade) — Lock every field on a page with one cascaded flag, plus GupReadOnlyRegion.
- [Breadcrumbs](https://gupdesign.sme.gov.om/demo/breadcrumbs) — Trail with current-item state; collapses to first and last below 599px.
- [Tabs](https://gupdesign.sme.gov.om/demo/tabs) — Default, toggle and vertical appearances, with tab panels and tabs navigation.
- [Stepper](https://gupdesign.sme.gov.om/demo/stepper) — The wizard progress indicator, with stepper items in complete, current and upcoming states.
- [Accordion](https://gupdesign.sme.gov.om/demo/accordion) — Collapsible sections, single or multiple open, including item actions.
- [Data table](https://gupdesign.sme.gov.om/demo/data-table) — Table chrome around GupTable — search, filter panel with removable chips, empty state, pagination footer.
- [Table & table cell](https://gupdesign.sme.gov.om/demo/table-cell) — The table primitives — header, row and cell, including alignment and wrapping.
- [Data display](https://gupdesign.sme.gov.om/demo/data-display) — Labelled items and key/value layouts for read-only data.
- [Data sheet](https://gupdesign.sme.gov.om/demo/data-sheet) — Bordered card grouping labelled items — order summaries and similar.
- [Dialog](https://gupdesign.sme.gov.om/demo/dialogs) — Modal in five sizes including fullscreen, with action buttons.
- [Flyout](https://gupdesign.sme.gov.om/demo/flyout) — Side panel from any edge — the mobile-friendly home for add-row forms.
- [Toast & toast container](https://gupdesign.sme.gov.om/demo/toasts) — Transient messages in four severities, stacked bottom-end by the global container.

### Patterns

Compositions that solve a recurring task — built from the components above.

- [Add row](https://gupdesign.sme.gov.om/demo/patterns/add-row) — Adding rows to a list, with the flyout form and the table that receives them.
- [Address form](https://gupdesign.sme.gov.om/demo/patterns/address-form) — The standard address field set, in the order and grouping services use.
- [Credit card payment](https://gupdesign.sme.gov.om/demo/patterns/credit-card-payment) — Card entry with formatting, validation and the review step.

### Page templates

Whole-page compositions — the shapes a service actually ships. Each is a faithful port of the matching upstream Storybook template.

- [Service Start](https://gupdesign.sme.gov.om/service-start) — The wizard shell: header, content header, stepper, step content and a pinned footer with Back/Continue.
- [Service Provider Confirmation](https://gupdesign.sme.gov.om/application-completed) — Confirmation page after submission — summary tables, primary and secondary actions, feedback link.
- [Service Provider Sign In](https://gupdesign.sme.gov.om/sign-in) — Sign-in screen for a service provider, with the standard page chrome.
- [Help Service](https://gupdesign.sme.gov.om/help) — Help and FAQ layout — long-form prose constrained to a readable measure.
- [Templates index](https://gupdesign.sme.gov.om/templates) — Plain list of the template pages with their routes.

