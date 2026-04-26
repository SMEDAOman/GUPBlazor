namespace GUPBlazor.Components;

public sealed class GupWizardNavArgs
{
    public GupWizardNavArgs(int currentStepIndex, int targetStepIndex)
    {
        CurrentStepIndex = currentStepIndex;
        TargetStepIndex = targetStepIndex;
    }

    public int CurrentStepIndex { get; }

    /// <summary>Index the wizard intends to move to. Handlers may overwrite this to redirect navigation.</summary>
    public int TargetStepIndex { get; set; }

    /// <summary>Set to true to abort the navigation (e.g. validation failed).</summary>
    public bool Cancel { get; set; }
}
