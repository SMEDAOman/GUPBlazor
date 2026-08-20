namespace GUPBlazor.Services;

/// <summary>
/// Raises toast notifications. Register with <c>AddGUPBlazor()</c>, inject where a toast is
/// needed, and place a single <c>GupToastContainer</c> in the layout to render them.
/// </summary>
public sealed class ToastService
{
    /// <summary>Raised when a toast should be displayed.</summary>
    public event Action<ToastNotification>? OnShow;

    /// <summary>Raised when the toast with the given id should be dismissed.</summary>
    public event Action<Guid>? OnRemove;

    /// <summary>Raised when all toasts should be dismissed.</summary>
    public event Action? OnClear;

    /// <summary>
    /// Displays a toast and returns its id, which can be passed to <see cref="Remove"/>.
    /// </summary>
    /// <param name="message">Text shown in the toast.</param>
    /// <param name="severity">Visual style: <c>neutral</c>, <c>positive</c>, <c>warning</c> or <c>negative</c>.</param>
    /// <param name="delayMs">How long the toast stays visible, in milliseconds.</param>
    /// <param name="closeLabel">Accessible label for the dismiss button.</param>
    public Guid Show(string message, string severity = "neutral",
                     int delayMs = 5000, string closeLabel = "Close")
    {
        var n = new ToastNotification(Guid.NewGuid(), message, severity, delayMs, closeLabel);
        OnShow?.Invoke(n);
        return n.Id;
    }

    /// <summary>Dismisses the toast with the given id.</summary>
    public void Remove(Guid id) => OnRemove?.Invoke(id);

    /// <summary>Dismisses every visible toast.</summary>
    public void Clear() => OnClear?.Invoke();
}

/// <summary>A single toast notification raised by <see cref="ToastService"/>.</summary>
public sealed record ToastNotification(
    Guid Id, string Message, string Severity, int DelayMs, string CloseLabel);
