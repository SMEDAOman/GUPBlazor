namespace AiDocsGen;

public sealed record ParamDoc(
    string Name,
    string Type,
    string? Default,
    string? Summary,
    bool IsSlot,
    bool IsEventCallback,
    bool IsBindable);

public sealed record EnumDoc(string Name, string? Summary, List<(string Member, string? Summary)> Members);

public sealed record ComponentDoc(
    string Name,
    string File,
    string? Summary,
    string? HeaderComment,
    List<ParamDoc> Parameters,
    List<string> CascadingParameters,
    List<EnumDoc> Enums,
    List<ExampleDoc> Examples,
    DemoPageRef? DemoPage);

public sealed record ExampleDoc(string Label, string Code, string SourcePage);

public sealed record DemoPageRef(string Route, string Title, string Description, string Section);

public sealed record SectionDoc(string Title, string Intro, List<DemoPageRef> Pages);
