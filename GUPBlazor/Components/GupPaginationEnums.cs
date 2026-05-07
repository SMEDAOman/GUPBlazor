namespace GUPBlazor.Components
{
    /// <summary>
    /// Pagination layout variant.
    /// Mirrors the <c>kind</c> attribute on <c>&lt;gup-pagination&gt;</c>.
    /// </summary>
    public enum GupPaginationKind
    {
        /// <summary>Numbered pages with previous/next text buttons (default).</summary>
        Numbered,

        /// <summary>Two large prev/next links (no page numbers) — used for guided flows.</summary>
        Directional,
    }
}
