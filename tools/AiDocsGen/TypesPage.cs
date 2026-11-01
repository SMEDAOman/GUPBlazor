using System.Text;
using System.Text.RegularExpressions;

namespace AiDocsGen;

/// The public support types a caller has to construct or read: event payloads
/// (GupFileUploadFile, GupWizardNavArgs) and config objects (GupDataTableColumn).
/// Without these a caller knows the parameter's type name but not its members.
public static partial class TypesPage
{
    [GeneratedRegex(@"public\s+(?:sealed\s+|abstract\s+)?(?<kind>record|class)\s+(?<name>\w+)(?<positional>\s*\((?<ctor>[^)]*)\))?",
        RegexOptions.Singleline)]
    private static partial Regex TypeRx();

    [GeneratedRegex(@"public\s+(?<type>[^\s]+(?:<[^>]*>)?[?]?)\s+(?<name>\w+)\s*\{\s*get;(?:\s*(?:init|set);)?\s*\}(?:\s*=\s*(?<default>[^;]+);)?")]
    private static partial Regex PropRx();

    [GeneratedRegex(@"public\s+static\s+(?:partial\s+)?class\s+(?<name>\w+)")]
    private static partial Regex StaticClassRx();

    [GeneratedRegex(@"public\s+sealed\s+class\s+(?<name>\w+Service)")]
    private static partial Regex ServiceClassRx();

    // Instance members of an injectable service: methods and events.
    [GeneratedRegex(@"public\s+(?:event\s+)?(?<type>[A-Za-z_][\w<>,.\[\]? ]*?)\s+(?<name>\w+)\s*(?:\((?<args>[^)]*)\)|;|\{)")]
    private static partial Regex InstanceMemberRx();

    // Static members: a method with a parameter list, or an expression-bodied property.
    [GeneratedRegex(@"public\s+static\s+(?<type>[A-Za-z_][\w<>,.\[\] ]*?[?]?)\s+(?<name>\w+)\s*(?:\((?<args>[^)]*)\)|=>)")]
    private static partial Regex StaticMemberRx();

    public static int Write(string outDir, string repoRoot, XmlDocs xml, string baseUrl, string version)
    {
        var dir = Path.Combine(repoRoot, "GUPBlazor", "Components");
        if (!Directory.Exists(dir))
        {
            return 0;
        }

        var types = new List<(string Name, string Kind, string? Summary, List<(string Type, string Name, string? Summary, string? Default)> Members)>();

        foreach (var file in Directory.EnumerateFiles(dir, "*.cs").OrderBy(f => f, StringComparer.Ordinal))
        {
            var source = File.ReadAllText(file);

            foreach (var m in TypeRx().Matches(source).Cast<Match>())
            {
                var name = m.Groups["name"].Value;
                var members = new List<(string, string, string?, string?)>();

                // Positional record: GupFileUploadFile(string Name, long Size, …)
                if (m.Groups["positional"].Success)
                {
                    foreach (var p in SplitParams(m.Groups["ctor"].Value))
                    {
                        var parts = p.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length >= 2)
                        {
                            members.Add((parts[0], parts[^1],
                                xml.Property($"GUPBlazor.Components.{name}", parts[^1]), null));
                        }
                    }
                }

                // Property-bodied class: read to the end of its braces.
                var body = ExtractBody(source, m.Index + m.Length);
                foreach (var p in PropRx().Matches(body).Cast<Match>())
                {
                    var pn = p.Groups["name"].Value;
                    if (members.Any(x => x.Item2 == pn))
                    {
                        continue;
                    }

                    members.Add((
                        p.Groups["type"].Value,
                        pn,
                        xml.Property($"GUPBlazor.Components.{name}", pn),
                        p.Groups["default"].Success ? p.Groups["default"].Value.Trim() : null));
                }

                if (members.Count > 0)
                {
                    types.Add((name, m.Groups["kind"].Value,
                        xml.Type($"GUPBlazor.Components.{name}"), members));
                }
            }
        }

        // Static helper classes (GupFlagCountries) are not components and have no
        // parameters, so nothing else in the generator would surface them.
        var helpers = new List<(string Name, string? Summary, List<(string Sig, string? Summary)> Members)>();

        foreach (var file in Directory.EnumerateFiles(dir, "*.cs").OrderBy(f => f, StringComparer.Ordinal))
        {
            var source = File.ReadAllText(file);

            foreach (var m in StaticClassRx().Matches(source).Cast<Match>())
            {
                var name = m.Groups["name"].Value;
                var body = ExtractBody(source, m.Index + m.Length);
                var members = new List<(string, string?)>();

                foreach (var mem in StaticMemberRx().Matches(body).Cast<Match>())
                {
                    var mn = mem.Groups["name"].Value;
                    var sig = mem.Groups["args"].Success
                        ? $"{mem.Groups["type"].Value} {mn}({mem.Groups["args"].Value.Trim()})"
                        : $"{mem.Groups["type"].Value} {mn}";

                    members.Add((Regex.Replace(sig, @"\s+", " ").Trim(),
                        xml.Property($"GUPBlazor.Components.{name}", mn)
                        ?? xml.Method($"GUPBlazor.Components.{name}", mn)));
                }

                if (members.Count > 0)
                {
                    helpers.Add((name, xml.Type($"GUPBlazor.Components.{name}"), members));
                }
            }
        }

        // Injectable services live in GUPBlazor/Services, outside the components folder.
        // ToastService is the library's only API called from C# rather than markup, so
        // without this it has no signature anywhere.
        var services = new List<(string Name, string? Summary, List<(string Sig, string? Summary)> Members)>();
        var servicesDir = Path.Combine(repoRoot, "GUPBlazor", "Services");

        if (Directory.Exists(servicesDir))
        {
            foreach (var file in Directory.EnumerateFiles(servicesDir, "*.cs").OrderBy(f => f, StringComparer.Ordinal))
            {
                var source = File.ReadAllText(file);

                foreach (var m in ServiceClassRx().Matches(source).Cast<Match>())
                {
                    var name = m.Groups["name"].Value;
                    var body = ExtractBody(source, m.Index + m.Length);
                    var members = new List<(string, string?)>();

                    foreach (var mem in InstanceMemberRx().Matches(body).Cast<Match>())
                    {
                        var mn = mem.Groups["name"].Value;
                        if (mn == name || members.Any(x => x.Item1.Contains($" {mn}(", StringComparison.Ordinal)))
                        {
                            continue;
                        }

                        var sig = mem.Groups["args"].Success
                            ? $"{mem.Groups["type"].Value} {mn}({mem.Groups["args"].Value.Trim()})"
                            : $"{mem.Groups["type"].Value} {mn}";

                        members.Add((Regex.Replace(sig, @"\s+", " ").Trim(),
                            xml.Method($"GUPBlazor.Services.{name}", mn)
                            ?? xml.Property($"GUPBlazor.Services.{name}", mn)
                            ?? xml.Event($"GUPBlazor.Services.{name}", mn)));
                    }

                    if (members.Count > 0)
                    {
                        services.Add((name, xml.Type($"GUPBlazor.Services.{name}"), members));
                    }
                }

                // Payload records declared alongside the service (ToastNotification).
                foreach (var m in TypeRx().Matches(source).Cast<Match>())
                {
                    var name = m.Groups["name"].Value;
                    if (!m.Groups["positional"].Success || types.Any(t => t.Name == name))
                    {
                        continue;
                    }

                    var members = SplitParams(m.Groups["ctor"].Value)
                        .Select(p => p.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries))
                        .Where(parts => parts.Length >= 2)
                        .Select(parts => (parts[0], parts[^1],
                            xml.Property($"GUPBlazor.Services.{name}", parts[^1]), (string?)null))
                        .ToList();

                    if (members.Count > 0)
                    {
                        types.Add((name, "record", xml.Type($"GUPBlazor.Services.{name}"), members));
                    }
                }
            }
        }

        if (types.Count == 0 && helpers.Count == 0 && services.Count == 0)
        {
            return 0;
        }

        var sb = new StringBuilder();
        sb.AppendLine("# GUPBlazor — support types");
        sb.AppendLine();
        sb.AppendLine($"> GUPBlazor {version}. The public types you construct or receive when using the");
        sb.AppendLine("> components: event payloads and configuration objects.");
        sb.AppendLine();
        sb.AppendLine("A component's parameter table gives the type name; this page gives its members.");
        sb.AppendLine();

        foreach (var t in types.OrderBy(t => t.Name, StringComparer.Ordinal))
        {
            sb.AppendLine($"## `{t.Name}`");
            sb.AppendLine();
            if (!string.IsNullOrWhiteSpace(t.Summary))
            {
                sb.AppendLine(t.Summary);
                sb.AppendLine();
            }

            sb.AppendLine("| Member | Type | Default | Description |");
            sb.AppendLine("|---|---|---|---|");
            foreach (var mem in t.Members)
            {
                var def = mem.Default is null ? "—" : $"`{Escape(mem.Default)}`";
                sb.AppendLine($"| `{mem.Name}` | `{Escape(mem.Type)}` | {def} | {Escape(mem.Summary ?? "")} |");
            }

            sb.AppendLine();

            if (t.Kind == "record")
            {
                var ctor = string.Join(", ", t.Members.Select(x => x.Name.ToLowerInvariant()));
                sb.AppendLine("Positional record — construct it with the members in order:");
                sb.AppendLine();
                sb.AppendLine("```csharp");
                sb.AppendLine($"new {t.Name}({ctor})");
                sb.AppendLine("```");
                sb.AppendLine();
            }
        }

        if (services.Count > 0)
        {
            sb.AppendLine("# Injectable services");
            sb.AppendLine();
            sb.AppendLine("Registered by `AddGUPBlazor()`. Inject with `@inject`, in namespace");
            sb.AppendLine("`GUPBlazor.Services`.");
            sb.AppendLine();

            foreach (var s in services.OrderBy(s => s.Name, StringComparer.Ordinal))
            {
                sb.AppendLine($"## `{s.Name}`");
                sb.AppendLine();
                if (!string.IsNullOrWhiteSpace(s.Summary))
                {
                    sb.AppendLine(s.Summary);
                    sb.AppendLine();
                }

                sb.AppendLine("```razor");
                sb.AppendLine("@using GUPBlazor.Services");
                sb.AppendLine($"@inject {s.Name} {s.Name.Replace("Service", "s", StringComparison.Ordinal)}");
                sb.AppendLine("```");
                sb.AppendLine();
                sb.AppendLine("| Member | Description |");
                sb.AppendLine("|---|---|");
                foreach (var (sig, summary) in s.Members)
                {
                    sb.AppendLine($"| `{Escape(sig)}` | {Escape(summary ?? "")} |");
                }

                sb.AppendLine();
            }
        }

        if (helpers.Count > 0)
        {
            sb.AppendLine("# Static helpers");
            sb.AppendLine();
            sb.AppendLine("Lookup tables and utilities the library ships, so you do not have to");
            sb.AppendLine("hardcode your own.");
            sb.AppendLine();

            foreach (var h in helpers.OrderBy(h => h.Name, StringComparer.Ordinal))
            {
                sb.AppendLine($"## `{h.Name}`");
                sb.AppendLine();
                if (!string.IsNullOrWhiteSpace(h.Summary))
                {
                    sb.AppendLine(h.Summary);
                    sb.AppendLine();
                }

                sb.AppendLine("| Member | Description |");
                sb.AppendLine("|---|---|");
                foreach (var (sig, summary) in h.Members)
                {
                    sb.AppendLine($"| `{Escape(sig)}` | {Escape(summary ?? "")} |");
                }

                sb.AppendLine();
            }
        }

        sb.AppendLine("---");
        sb.AppendLine();
        sb.AppendLine($"Full index: {baseUrl}/ai/index.md");

        Directory.CreateDirectory(outDir);
        File.WriteAllText(Path.Combine(outDir, "types.md"), sb.ToString(), new UTF8Encoding(false));
        return types.Count + helpers.Count + services.Count;
    }

    private static IEnumerable<string> SplitParams(string ctor)
    {
        var depth = 0;
        var current = new StringBuilder();

        foreach (var ch in ctor)
        {
            if (ch is '<' or '(') depth++;
            if (ch is '>' or ')') depth--;

            if (ch == ',' && depth == 0)
            {
                yield return current.ToString();
                current.Clear();
                continue;
            }

            current.Append(ch);
        }

        if (current.Length > 0)
        {
            yield return current.ToString();
        }
    }

    /// Text from the type's opening brace to its matching close.
    private static string ExtractBody(string source, int from)
    {
        var open = source.IndexOf('{', from);
        if (open < 0)
        {
            return "";
        }

        var depth = 0;
        for (var i = open; i < source.Length; i++)
        {
            if (source[i] == '{') depth++;
            else if (source[i] == '}' && --depth == 0)
            {
                return source[open..i];
            }
        }

        return source[open..];
    }

    private static string Escape(string s) =>
        s.Replace("|", "\\|").Replace("\r", " ").Replace("\n", " ");
}
