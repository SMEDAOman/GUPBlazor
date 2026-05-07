namespace GUPBlazor.Components
{
    /// <summary>
    /// Visual appearance for <see cref="GupTabs"/>.
    /// Mirrors the <c>appearance</c> attribute on <c>&lt;gup-tabs&gt;</c>.
    /// </summary>
    public enum GupTabsAppearance
    {
        /// <summary>Underlined active tab on a horizontal strip (default).</summary>
        Default,

        /// <summary>Pill-shaped toggle group with a rounded background.</summary>
        Toggle,

        /// <summary>Stacked vertical list of tabs with a leading active indicator.</summary>
        Vertical,
    }
}
