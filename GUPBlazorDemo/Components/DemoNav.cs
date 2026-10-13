namespace GUPBlazorDemo.Components;

/// <summary>One page in the demo catalogue.</summary>
public record DemoEntry(string Href, string Title, string Description);

/// <summary>A collapsible folder of pages inside a section, mirroring the upstream sidebar.</summary>
public record DemoGroup(string Title, DemoEntry[] Entries, string? Icon = null);

/// <summary>
/// A titled section. Entries sit directly under the heading; Groups render below them
/// as collapsible folders.
/// </summary>
public record DemoSection(string Title, string Intro, DemoEntry[] Entries, DemoGroup[]? Groups = null, string? Icon = null);

/// <summary>
/// The demo catalogue. Single source for both the sidebar (MainLayout) and the
/// reference index (ComponentDemo), so the two can never drift apart. Grouped to
/// mirror the upstream gov.om Storybook navigation.
/// </summary>
public static class DemoNav
{
    public static int TotalCount => Sections.Sum(s => s.Entries.Length + (s.Groups?.Sum(g => g.Entries.Length) ?? 0));

    public static IEnumerable<DemoEntry> AllEntries =>
        Sections.SelectMany(s => s.Entries.Concat(s.Groups?.SelectMany(g => g.Entries) ?? []));

    public static readonly DemoSection[] Sections =
    [
        new("Documentation",
            "How to install the library and the conventions worth knowing before you build a page.",
        [
            new("/demo/welcome", "Welcome", "What the library is, what ships with it, and how it relates to the upstream gov.om design system."),
            new("/demo/installation", "Installation", "Add the NuGet package, register the services, and wire up the styles and scripts."),
            new("/demo/usage", "Usage", "Utility components, spacing, icons, tokens and RTL — the conventions behind the component pages."),
            new("/demo/design-tokens", "Design tokens", "Every CSS custom property the library exports, read live from gup.css."),
            new("/demo/versions", "Versions", "What ships, the target framework, and how it maps to the upstream design system."),
            new("/demo/feedback-contact", "Feedback", "Where to report a bug in this port, and where to ask about the design system itself."),
        ], Icon: "menu_book"),

        new("Tools",
            "For checking a page before it ships.",
        [
            new("/demo/device-preview", "Device Preview", "View any page in this demo at a real phone or tablet viewport, with a live readout of which gup.css breakpoints are active."),
        ], Icon: "handyman"),

        new("Foundations",
            "Tokens and layout primitives everything else is built from.",
        [
            new("/demo/branding", "Branding", "Logo, icons, color tokens, and typography scale."),
            new("/demo/logo", "Logo", "GupLogo in icon and horizontal lockups, with inversion for dark surfaces."),
            new("/demo/icons", "Icons", "Material Symbols Outlined — sizes, fill, weight, grade, and color."),
            new("/demo/track", "Track", "GupTrack — the spacing primitive used to lay out rows and columns on the design system scale."),
            new("/demo/layout", "Layout", "Track, grid, container and the page-shell components."),
            new("/demo/divider", "Divider", "Horizontal and vertical rules with spacing options."),
            new("/demo/image", "Image", "Responsive image with aspect-ratio and object-fit control."),
            new("/demo/flag", "Flag", "Country flags in rectangle and circle shapes."),
            new("/demo/rich-text", "Rich text", "Prose block that styles headings, lists and links coming from a CMS or editor."),
        ], Icon: "foundation"),

        new("Components",
            "The component set, grouped the way the upstream Storybook groups it.",
        [
            new("/demo/buttons", "Button", "Button appearances, icons, disabled states, and button groups."),
            new("/demo/button-group", "Button group", "Groups of related buttons, with the stacking behaviour used on mobile."),
            new("/demo/banner", "Banner", "Page-level messages in four severities, outline and filled appearances."),
            new("/demo/callout", "Callout", "Block quote with optional author, in three appearances."),
            new("/demo/badges", "Badge", "Status badges in the full colour range."),
            new("/demo/badge-chips", "Badge chip", "Compact status chips with optional icon."),
            new("/demo/filter-chip", "Filter chip", "Removable chips for active filters."),
            new("/demo/avatar", "Avatar", "User avatar from initials or an image."),
            new("/demo/tooltip", "Tooltip", "Hover and focus tooltip with placement options."),
            new("/demo/details", "Details", "Single disclosure with quote, sink and none appearances."),
            new("/demo/spinner", "Spinner", "Indeterminate loading indicator in several sizes."),
            new("/demo/page-status", "Page status", "Empty, error and loading states for a whole page."),
            new("/demo/labelled-item", "Labelled item", "Label and value pair for read-only data."),
            new("/demo/file-item", "File item", "A single uploaded file row with size, link and remove action."),
            new("/demo/screenreader-text", "Screenreader text", "Visually hidden text that assistive technology still announces."),
            new("/demo/skip-link", "Skip link", "Keyboard-only link that jumps past the header to main content."),
            new("/demo/search", "Search", "Search field with submit and clear affordances."),
            new("/demo/pagination", "Pagination", "Page controls with previous/next and page-number buttons."),
            new("/demo/feedback", "Feedback", "Inline feedback prompt and rating control."),
        ],
        [
            new DemoGroup("Layout",
            [
                new("/demo/header", "Header", "The service header — brand, service name, language toggle and account area."),
                new("/demo/content-header", "Content header", "Page title, summary and optional actions at the top of a page."),
                new("/demo/wizard", "Wizard main & footer", "The wizard shell: main content region and the pinned Back/Continue footer."),
            ], Icon: "view_quilt"),

            new DemoGroup("Forms",
            [
                new("/demo/forms", "Form components (all-in-one)", "Input fields, form sections, checkboxes, radio buttons, and dropdowns on one page."),
                new("/demo/inputs/text", "Input field", "Single-line text with label, hint, error and read-only states."),
                new("/demo/inputs/email", "Email input", "type=email with the WHATWG pattern and a leading icon."),
                new("/demo/inputs/tel", "Phone input", "type=tel — raises the telephone keypad on mobile."),
                new("/demo/inputs/number", "Number input", "type=number for incremental values; spinners included."),
                new("/demo/inputs/date", "Date input", "Native date control with RTL-aware mirroring."),
                new("/demo/inputs/password", "Password input", "Masked entry with a reveal toggle."),
                new("/demo/inputs/textarea", "Textarea field", "Multi-line entry with character counter."),
                new("/demo/inputs/checkbox", "Checkbox", "Single, grouped and indeterminate states."),
                new("/demo/inputs/radio", "Radio button", "Radio groups, horizontal and vertical."),
                new("/demo/inputs/toggle", "Toggle", "On/off switch with label and hint."),
                new("/demo/inputs/dropdown", "Dropdown", "Single and multi-select with search, clear and grouped options."),
                new("/demo/file-upload", "File upload", "Drag-and-drop or browse, with file list and remove actions."),
                new("/demo/form-section", "Form section", "Titled section with optional footer for action buttons."),
                new("/demo/form-list", "Form list", "Repeating rows of fields with add and remove controls."),
                new("/demo/hint-validation", "Hint & validation message", "The hint and error slots shared by every field component."),
                new("/demo/error-summary", "Error summary", "Validation summary banner that links each error to its field."),
                new("/demo/read-only-cascade", "Read-only cascade", "Lock every field on a page with one cascaded flag, plus GupReadOnlyRegion."),
            ], Icon: "edit_note"),

            new DemoGroup("Navigation",
            [
                new("/demo/breadcrumbs", "Breadcrumbs", "Trail with current-item state; collapses to first and last below 599px."),
                new("/demo/tabs", "Tabs", "Default, toggle and vertical appearances, with tab panels and tabs navigation."),
                new("/demo/stepper", "Stepper", "The wizard progress indicator, with stepper items in complete, current and upcoming states."),
            ], Icon: "explore"),

            new DemoGroup("Accordion",
            [
                new("/demo/accordion", "Accordion", "Collapsible sections, single or multiple open, including item actions."),
            ], Icon: "expand"),

            new DemoGroup("Table",
            [
                new("/demo/data-table", "Data table", "Table chrome around GupTable — search, filter panel with removable chips, empty state, pagination footer."),
                new("/demo/table-cell", "Table & table cell", "The table primitives — header, row and cell, including alignment and wrapping."),
                new("/demo/data-display", "Data display", "Labelled items and key/value layouts for read-only data."),
                new("/demo/data-sheet", "Data sheet", "Bordered card grouping labelled items — order summaries and similar."),
            ], Icon: "table_rows"),

            new DemoGroup("Dialogs & overlays",
            [
                new("/demo/dialogs", "Dialog", "Modal in five sizes including fullscreen, with action buttons."),
                new("/demo/flyout", "Flyout", "Side panel from any edge — the mobile-friendly home for add-row forms."),
            ], Icon: "layers"),

            new DemoGroup("Toasts",
            [
                new("/demo/toasts", "Toast & toast container", "Transient messages in four severities, stacked bottom-end by the global container."),
            ], Icon: "notifications"),
        ], Icon: "widgets"),

        new("Patterns",
            "Compositions that solve a recurring task — built from the components above.",
        [
            new("/demo/patterns/add-row", "Add row", "Adding rows to a list, with the flyout form and the table that receives them."),
            new("/demo/patterns/address-form", "Address form", "The standard address field set, in the order and grouping services use."),
            new("/demo/patterns/credit-card-payment", "Credit card payment", "Card entry with formatting, validation and the review step."),
        ], Icon: "dashboard_customize"),

        new("Page templates",
            "Whole-page compositions — the shapes a service actually ships. Each is a faithful port of the matching upstream Storybook template.",
        [
            new("/service-start", "Service Start", "The wizard shell: header, content header, stepper, step content and a pinned footer with Back/Continue."),
            new("/application-completed", "Service Provider Confirmation", "Confirmation page after submission — summary tables, primary and secondary actions, feedback link."),
            new("/sign-in", "Service Provider Sign In", "Sign-in screen for a service provider, with the standard page chrome."),
            new("/help", "Help Service", "Help and FAQ layout — long-form prose constrained to a readable measure."),
            new("/templates", "Templates index", "Plain list of the template pages with their routes."),
        ], Icon: "web"),
    ];
}
