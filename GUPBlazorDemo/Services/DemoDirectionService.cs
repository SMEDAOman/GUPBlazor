namespace GUPBlazorDemo.Services;

/// <summary>
/// Service to manage and notify about the layout direction (LTR vs RTL) for the demo application.
/// Allows previewing every page in Right-to-Left or Left-to-Right mode.
/// </summary>
public sealed class DemoDirectionService
{
    private string _direction = "ltr";

    /// <summary>The current active direction: "ltr" or "rtl".</summary>
    public string CurrentDirection => _direction;

    /// <summary>True if the active direction is Right-to-Left (Arabic).</summary>
    public bool IsRtl => string.Equals(_direction, "rtl", StringComparison.OrdinalIgnoreCase);

    /// <summary>Fired when the layout direction changes.</summary>
    public event Action? OnDirectionChanged;

    /// <summary>
    /// Sets the direction to either "ltr" or "rtl" and optionally notifies subscribers.
    /// </summary>
    public void SetDirection(string dir, bool notify = true)
    {
        var normalized = string.Equals(dir, "rtl", StringComparison.OrdinalIgnoreCase) ? "rtl" : "ltr";
        if (!string.Equals(_direction, normalized, StringComparison.OrdinalIgnoreCase))
        {
            _direction = normalized;
            if (notify)
            {
                OnDirectionChanged?.Invoke();
            }
        }
    }

    /// <summary>Toggles between LTR and RTL.</summary>
    public void Toggle()
    {
        SetDirection(IsRtl ? "ltr" : "rtl");
    }
}
