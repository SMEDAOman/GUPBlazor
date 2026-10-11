namespace GUPBlazorDemo.Components;

/// <summary>One page in the demo catalogue.</summary>
public record DemoEntry(string Href, string Title, string Description);

/// <summary>A titled group of demo pages.</summary>
public record DemoSection(string Title, string Intro, DemoEntry[] Entries);

/// <summary>
/// The demo catalogue. Single source for both the sidebar (MainLayout) and the
/// reference index (ComponentDemo), so the two can never drift apart.
/// </summary>
public static class DemoNav
{
    public static int TotalCount => Sections.Sum(s => s.Entries.Length);

    public static readonly DemoSection[] Sections =
    [
        new("Tools",
            "For checking a page before it ships.",
        [
            new("/demo/device-preview", "Device Preview", "View any page in this demo at a real phone or tablet viewport, with a live readout of which gup.css breakpoints are active."),
        ]),

        new("Page templates",
            "Whole-page compositions — the shapes a service actually ships. Each is a faithful port of the matching upstream Storybook template.",
        [
            new("/service-start", "Service Start", "The wizard shell: header, content header, stepper, step content and a pinned footer with Back/Continue."),
            new("/application-completed", "Application Completed", "Confirmation page after submission — summary tables, primary and secondary actions, feedback link."),
            new("/sign-in", "Service Provider Sign In", "Sign-in screen for a service provider, with the standard page chrome."),
            new("/help", "Help Service", "Help and FAQ layout — long-form prose constrained to a readable measure."),
            new("/templates", "Templates index", "Plain list of the four template pages with their routes."),
        ]),

        new("Foundations",
            "Tokens and layout primitives everything else is built from.",
        [
            new("/demo/branding", "Branding", "Logo, icons, color tokens, and typography scale."),
            new("/demo/icons", "Icons", "Material Symbols Outlined — sizes, fill, weight, grade, and color."),
            new("/demo/layout", "Layout", "Track, grid, container and the page-shell components."),
            new("/demo/divider", "Divider", "Horizontal and vertical rules with spacing options."),
            new("/demo/image", "Image", "Responsive image with aspect-ratio and object-fit control."),
            new("/demo/flag", "Flag", "Country flags in rectangle and circle shapes."),
        ]),

        new("Forms — controls",
            "One page per input type. Each shows states, validation and the attributes that matter on mobile.",
        [
            new("/demo/inputs/text", "Text Input", "Single-line text with label, hint, error and read-only states."),
            new("/demo/inputs/email", "Email Input", "type=email with the WHATWG pattern and a leading icon."),
            new("/demo/inputs/tel", "Phone Input", "type=tel — raises the telephone keypad on mobile."),
            new("/demo/inputs/number", "Number Input", "type=number for incremental values; spinners included."),
            new("/demo/inputs/date", "Date Input", "Native date control with RTL-aware mirroring."),
            new("/demo/inputs/password", "Password Input", "Masked entry with a reveal toggle."),
            new("/demo/inputs/dropdown", "Dropdown", "Single and multi-select with search, clear and grouped options."),
            new("/demo/inputs/checkbox", "Checkbox", "Single, grouped and indeterminate states."),
            new("/demo/inputs/radio", "Radio Button", "Radio groups, horizontal and vertical."),
            new("/demo/inputs/textarea", "Textarea", "Multi-line entry with character counter."),
            new("/demo/inputs/toggle", "Toggle", "On/off switch with label and hint."),
        ]),

        new("Forms — composition",
            "Putting controls together: grouping, validation summaries and whole-form behaviour.",
        [
            new("/demo/forms", "Form Components (all-in-one)", "Input fields, form sections, checkboxes, radio buttons, and dropdowns on one page."),
            new("/demo/form-section", "Form Section", "Titled section with optional footer for action buttons."),
            new("/demo/error-summary", "Error Summary", "Validation summary banner that links each error to its field."),
            new("/demo/file-upload", "File Upload", "Drag-and-drop or browse, with file list and remove actions."),
            new("/demo/read-only-cascade", "Read-only cascade", "Lock every field on a page with one cascaded flag, plus GupReadOnlyRegion."),
        ]),

        new("Data display",
            "Tables and structured content. The responsive behaviour here is the thing to check at 360px.",
        [
            new("/demo/data-table", "Data Table", "Table chrome around GupTable — search, filter panel with removable chips, empty state, pagination footer."),
            new("/demo/data-display", "Data Display", "Labelled items and key/value layouts for read-only data."),
            new("/demo/data-sheet", "Data Sheet", "Bordered card grouping labelled items — order summaries and similar."),
            new("/demo/pagination", "Pagination", "Page controls with previous/next and page-number buttons."),
        ]),

        new("Navigation",
            "Moving between pages and between sections of a page.",
        [
            new("/demo/breadcrumbs", "Breadcrumbs", "Trail with current-item state; collapses to first and last below 599px."),
            new("/demo/tabs", "Tabs", "Default, toggle and vertical appearances, with full-width option."),
            new("/demo/search", "Search", "Search field with submit and clear affordances."),
            new("/demo/skip-link", "Skip Link", "Keyboard-only link that jumps past the header to main content."),
        ]),

        new("Feedback & status",
            "Telling the user what happened, or what is happening.",
        [
            new("/demo/toasts", "Toasts", "Transient messages in four severities, stacked bottom-end."),
            new("/demo/dialogs", "Dialog", "Modal in five sizes including fullscreen, with action buttons."),
            new("/demo/flyout", "Flyout", "Side panel from any edge — the mobile-friendly home for add-row forms."),
            new("/demo/page-status", "Page Status", "Empty, error and loading states for a whole page."),
            new("/demo/spinner", "Spinner", "Indeterminate loading indicator in several sizes."),
            new("/demo/feedback", "Feedback", "Inline feedback prompt and rating control."),
            new("/demo/callout", "Callout", "Block quote with optional author, in three appearances."),
        ]),

        new("Content & indicators",
            "Smaller pieces used inside the layouts above.",
        [
            new("/demo/buttons", "Buttons", "Button appearances, icons, disabled states, and button groups."),
            new("/demo/accordion", "Accordion", "Collapsible sections, single or multiple open."),
            new("/demo/details", "Details", "Single disclosure with quote, sink and none appearances."),
            new("/demo/badges", "Badge", "Status badges in the full colour range."),
            new("/demo/badge-chips", "Badge Chip", "Compact status chips with optional icon."),
            new("/demo/filter-chip", "Filter Chip", "Removable chips for active filters."),
            new("/demo/avatar", "Avatar", "User avatar from initials or an image."),
            new("/demo/tooltip", "Tooltip", "Hover and focus tooltip with placement options."),
            new("/demo/screenreader-text", "Screenreader Text", "Visually hidden text that assistive technology still announces."),
        ]),
    ];
}
