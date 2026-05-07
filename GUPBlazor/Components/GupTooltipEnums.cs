namespace GUPBlazor.Components
{
    /// <summary>
    /// Placement of a <see cref="GupTooltip"/> popup relative to its trigger element.
    /// Mirrors the <c>placement</c> attribute on the gov.om <c>&lt;gup-tooltip&gt;</c>
    /// design-system component (which itself uses Floating UI's <c>Placement</c> type).
    /// Only the four primary edges are supported in the Blazor port — they cover
    /// every documented Storybook story for the component.
    /// </summary>
    public enum GupTooltipPlacement
    {
        /// <summary>Tooltip appears above the trigger.</summary>
        Top,

        /// <summary>Tooltip appears below the trigger (default).</summary>
        Bottom,

        /// <summary>Tooltip appears to the inline-start of the trigger (left in LTR).</summary>
        Left,

        /// <summary>Tooltip appears to the inline-end of the trigger (right in LTR).</summary>
        Right,
    }

    /// <summary>
    /// How a <see cref="GupTooltip"/> opens.
    /// </summary>
    public enum GupTooltipTrigger
    {
        /// <summary>Opens when the trigger is clicked. Closes on outside click or ESC.</summary>
        Click,

        /// <summary>Opens on hover/focus, closes when the pointer leaves or focus moves away.</summary>
        Hover,

        /// <summary>The component never reacts to user input — drive it via <c>@bind-IsOpen</c>, <c>ShowAsync()</c>, or <c>HideAsync()</c>.</summary>
        Manual,
    }
}
