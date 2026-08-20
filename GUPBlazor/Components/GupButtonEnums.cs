namespace GUPBlazor.Components;

/// <summary>Visual style of a <c>GupButton</c>.</summary>
public enum GupButtonAppearance
{
    Primary,
    Secondary,
    Text,
    Danger
}

/// <summary>Whether a <c>GupButton</c> renders as a button or an anchor.</summary>
public enum GupButtonKind
{
    Button,
    Link
}

/// <summary>The HTML <c>type</c> attribute of a <c>GupButton</c>.</summary>
public enum GupButtonType
{
    Button,
    Submit,
    Reset
}
