namespace GUPBlazor.Components;

/// <summary>Column definition used to lay out a <c>GupDataTable</c>.</summary>
public sealed class GupDataTableColumn
{
    /// <summary>Unique key identifying the column.</summary>
    public string Key { get; set; } = "";

    /// <summary>Header text shown for the column.</summary>
    public string Label { get; set; } = "";

    /// <summary>Explicit column width, e.g. "180px" or "20%". Null lets the column size itself.</summary>
    public string? Width { get; set; }

    /// <summary>When true the column absorbs remaining horizontal space.</summary>
    public bool Grow { get; set; }
}

/// <summary>Kind of editor rendered for a filter in the filter panel.</summary>
public enum GupDataTableFilterType
{
    /// <summary>Free-text input.</summary>
    Text,

    /// <summary>Date picker input.</summary>
    Date,

    /// <summary>Dropdown populated from <see cref="GupDataTableFilter.Options"/>.</summary>
    Select,
}

/// <summary>A filter offered in the <c>GupDataTable</c> filter panel.</summary>
public sealed class GupDataTableFilter
{
    /// <summary>Unique key identifying the filter.</summary>
    public string Key { get; set; } = "";

    /// <summary>Label shown above the filter editor.</summary>
    public string Label { get; set; } = "";

    /// <summary>Editor kind. Default: <see cref="GupDataTableFilterType.Text"/>.</summary>
    public GupDataTableFilterType Type { get; set; } = GupDataTableFilterType.Text;

    /// <summary>Choices offered when <see cref="Type"/> is <see cref="GupDataTableFilterType.Select"/>.</summary>
    public IReadOnlyList<GupDataTableFilterOption> Options { get; set; } = [];
}

/// <summary>A selectable choice for a Select-typed filter.</summary>
public sealed class GupDataTableFilterOption
{
    /// <summary>Underlying value submitted when the option is chosen.</summary>
    public string Value { get; set; } = "";

    /// <summary>Text shown to the user.</summary>
    public string Label { get; set; } = "";
}

/// <summary>A filter the user has applied, surfaced as a removable chip.</summary>
public sealed class GupAppliedFilter
{
    /// <summary>Key of the <see cref="GupDataTableFilter"/> this value belongs to.</summary>
    public string Key { get; set; } = "";

    /// <summary>The applied value.</summary>
    public string Value { get; set; } = "";

    /// <summary>Text shown on the filter chip.</summary>
    public string Label { get; set; } = "";
}
