namespace GUPBlazor.Components;

/// <summary>Metadata for a file selected in a <c>GupFileUpload</c>.</summary>
public record GupFileUploadFile(string Name, long Size, string Type, long LastModified);
