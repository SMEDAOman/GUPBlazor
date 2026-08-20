namespace GUPBlazor.Components;

/// <summary>
/// Passed to wizard navigation handlers, which may redirect the move via
/// <see cref="TargetStepIndex"/> or block it via <see cref="Cancel"/>.
/// </summary>
public sealed class GupWizardNavArgs
{
    /// <summary>Creates navigation arguments for a move between two steps.</summary>
    public GupWizardNavArgs(int currentStepIndex, int targetStepIndex)
    {
        CurrentStepIndex = currentStepIndex;
        TargetStepIndex = targetStepIndex;
    }

    /// <summary>Index of the step being navigated away from.</summary>
    public int CurrentStepIndex { get; }

    /// <summary>Index the wizard intends to move to. Handlers may overwrite this to redirect navigation.</summary>
    public int TargetStepIndex { get; set; }

    /// <summary>Set to true to abort the navigation (e.g. validation failed).</summary>
    public bool Cancel { get; set; }
}
