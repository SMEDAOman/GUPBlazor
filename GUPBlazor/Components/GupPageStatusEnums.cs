namespace GUPBlazor.Components
{
    /// <summary>
    /// Visual state of a <see cref="GupPageStatus"/>.
    /// Mirrors the <c>type</c> attribute on <c>&lt;gup-page-status&gt;</c>.
    /// </summary>
    public enum GupPageStatusType
    {
        /// <summary>Positive outcome — green background, "done" icon.</summary>
        Success,

        /// <summary>Negative outcome — red background, "close" icon.</summary>
        Error,

        /// <summary>Time-bounded outcome — neutral background, "priority-high" icon.</summary>
        Expired,
    }
}
