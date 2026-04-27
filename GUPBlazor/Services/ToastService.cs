namespace GUPBlazor.Services;

public sealed class ToastService
{
    public event Action<ToastNotification>? OnShow;
    public event Action<Guid>? OnRemove;
    public event Action? OnClear;

    public Guid Show(string message, string severity = "neutral",
                     int delayMs = 5000, string closeLabel = "Close")
    {
        var n = new ToastNotification(Guid.NewGuid(), message, severity, delayMs, closeLabel);
        OnShow?.Invoke(n);
        return n.Id;
    }

    public void Remove(Guid id) => OnRemove?.Invoke(id);

    public void Clear() => OnClear?.Invoke();
}

public sealed record ToastNotification(
    Guid Id, string Message, string Severity, int DelayMs, string CloseLabel);
