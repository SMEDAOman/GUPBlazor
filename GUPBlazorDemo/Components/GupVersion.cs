using GUPBlazor.Components;

namespace GUPBlazorDemo.Components;

/// The shipped GUPBlazor version, read from the referenced assembly so the demo's
/// install snippets cannot fall behind the package the way a hardcoded string did.
public static class GupVersion
{
    public static string Current { get; } = Read();

    private static string Read()
    {
        var v = typeof(GupButton).Assembly.GetName().Version;
        return v is null ? "0.0.0" : $"{v.Major}.{v.Minor}.{v.Build}";
    }
}
