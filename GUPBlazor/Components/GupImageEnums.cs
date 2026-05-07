namespace GUPBlazor.Components
{
    /// <summary>
    /// Image loading strategy passed to the underlying &lt;img&gt; element.
    /// Browsers that don't support the attribute will silently ignore it.
    /// </summary>
    public enum GupImageLoading
    {
        /// <summary>Defer loading until the image enters the viewport.</summary>
        Lazy,

        /// <summary>Load the image immediately (default browser behaviour).</summary>
        Eager,
    }
}
