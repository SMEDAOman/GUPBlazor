namespace GUPBlazor.Components
{
    /// <summary>
    /// Status of a <see cref="GupBanner"/>. Mirrors the <c>type</c> attribute on the
    /// gov.om <c>&lt;gup-banner&gt;</c> design-system component.
    /// </summary>
    public enum GupBannerType
    {
        /// <summary>Neutral / informational banner (default).</summary>
        Neutral,

        /// <summary>Success banner.</summary>
        Success,

        /// <summary>Warning banner.</summary>
        Warning,

        /// <summary>Error banner.</summary>
        Error,
    }

    /// <summary>
    /// Visual style of a <see cref="GupBanner"/>. Mirrors the <c>appearance</c> attribute
    /// on the gov.om <c>&lt;gup-banner&gt;</c> design-system component.
    /// </summary>
    public enum GupBannerAppearance
    {
        /// <summary>Outlined banner (default).</summary>
        Outline,

        /// <summary>Filled (strong background) banner.</summary>
        Filled,
    }
}
