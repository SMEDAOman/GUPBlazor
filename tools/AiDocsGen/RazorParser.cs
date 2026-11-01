using System.Text;
using System.Text.RegularExpressions;

namespace AiDocsGen;

public static partial class RazorParser
{
    [GeneratedRegex(@"\[Parameter(?:\([^)]*\))?\]\s*public\s+(?<type>[^\s]+(?:<[^>]*>)?[?]?)\s+(?<name>\w+)\s*\{[^}]*\}(?:\s*=\s*(?<default>[^;]+);)?",
        RegexOptions.Singleline)]
    private static partial Regex ParameterRx();

    [GeneratedRegex(@"\[CascadingParameter(?:\(Name\s*=\s*""(?<cname>[^""]+)""\))?\]\s*(?:public|private|protected)\s+(?<type>[^\s]+[?]?)\s+(?<name>\w+)")]
    private static partial Regex CascadingRx();

    // The /// block immediately preceding a [Parameter] attribute.
    [GeneratedRegex(@"(?<doc>(?:[ \t]*///.*\r?\n)+)[ \t]*\[Parameter")]
    private static partial Regex ParamDocRx();

    public static (List<ParamDoc> Parameters, List<string> Cascading) Parse(string source)
    {
        var codeBlock = ExtractCodeBlock(source);
        var inlineDocs = CollectInlineDocs(codeBlock);

        var parameters = new List<ParamDoc>();
        foreach (var m in ParameterRx().Matches(codeBlock).Cast<Match>())
        {
            var name = m.Groups["name"].Value;
            var type = m.Groups["type"].Value.Trim();
            var def = m.Groups["default"].Success ? m.Groups["default"].Value.Trim() : null;

            inlineDocs.TryGetValue(name, out var summary);

            parameters.Add(new ParamDoc(
                Name: name,
                Type: type,
                Default: NormalizeDefault(def),
                Summary: summary,
                IsSlot: type.StartsWith("RenderFragment", StringComparison.Ordinal),
                IsEventCallback: type.StartsWith("EventCallback", StringComparison.Ordinal),
                IsBindable: false));
        }

        // A parameter pair Foo / FooChanged supports @bind-Foo.
        var names = parameters.Select(p => p.Name).ToHashSet(StringComparer.Ordinal);
        for (var i = 0; i < parameters.Count; i++)
        {
            if (names.Contains(parameters[i].Name + "Changed"))
            {
                parameters[i] = parameters[i] with { IsBindable = true };
            }
        }

        var cascading = CascadingRx().Matches(codeBlock)
            .Cast<Match>()
            .Select(m => m.Groups["cname"].Success
                ? $"{m.Groups["name"].Value} (cascading name: \"{m.Groups["cname"].Value}\")"
                : m.Groups["name"].Value)
            .Distinct(StringComparer.Ordinal)
            .ToList();

        return (parameters, cascading);
    }

    /// Maps a parameter name to the summary text of the /// block directly above it.
    private static Dictionary<string, string> CollectInlineDocs(string codeBlock)
    {
        var result = new Dictionary<string, string>(StringComparer.Ordinal);

        foreach (var m in ParamDocRx().Matches(codeBlock).Cast<Match>())
        {
            var after = codeBlock[(m.Index + m.Length)..];
            var nameMatch = Regex.Match(after, @"[^\]]*\]?\s*public\s+[^\s]+(?:<[^>]*>)?[?]?\s+(?<name>\w+)");
            if (!nameMatch.Success)
            {
                continue;
            }

            var text = CleanXmlDoc(m.Groups["doc"].Value);
            if (!string.IsNullOrWhiteSpace(text))
            {
                result[nameMatch.Groups["name"].Value] = text;
            }
        }

        return result;
    }

    /// The leading @* ... *@ comment, which several components use as an upstream mapping note.
    public static string? ExtractHeaderComment(string source)
    {
        var trimmed = source.TrimStart('﻿', ' ', '\r', '\n', '\t');
        if (!trimmed.StartsWith("@*", StringComparison.Ordinal))
        {
            return null;
        }

        var end = trimmed.IndexOf("*@", StringComparison.Ordinal);
        if (end < 0)
        {
            return null;
        }

        var body = trimmed[2..end];
        var lines = body.Split('\n')
            .Select(l => l.Trim())
            .Where(l => l.Length > 0);

        return string.Join(" ", lines).Trim();
    }

    private static string ExtractCodeBlock(string source)
    {
        var at = source.IndexOf("@code", StringComparison.Ordinal);
        return at < 0 ? source : source[at..];
    }

    private static string? NormalizeDefault(string? def)
    {
        if (string.IsNullOrWhiteSpace(def))
        {
            return null;
        }

        def = def.Trim();
        return def is "\"\"" ? "\"\" (empty)" : def;
    }

    public static string CleanXmlDoc(string raw)
    {
        var sb = new StringBuilder();
        foreach (var line in raw.Split('\n'))
        {
            var l = line.Trim();
            if (l.StartsWith("///", StringComparison.Ordinal))
            {
                l = l[3..].Trim();
            }

            if (l.Length > 0)
            {
                sb.Append(l).Append(' ');
            }
        }

        var text = sb.ToString();
        text = Regex.Replace(text, @"</?summary>", "");
        text = Regex.Replace(text, @"<see\s+cref=""(?:[A-Za-z]:)?([^""]+)""\s*/>", m => Simplify(m.Groups[1].Value));
        text = Regex.Replace(text, @"<see\s+cref=""[^""]+""\s*>([^<]*)</see>", "$1");
        text = Regex.Replace(text, @"<see\s+langword=""([^""]+)""\s*/>", "`$1`");
        text = Regex.Replace(text, @"<paramref\s+name=""([^""]+)""\s*/>", "`$1`");
        text = Regex.Replace(text, @"<c>([^<]*)</c>", "`$1`");
        text = Regex.Replace(text, @"<para>|</para>", " ");
        text = Regex.Replace(text, @"<[^>]+>", "");
        text = text.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");
        return Regex.Replace(text, @"\s+", " ").Trim();
    }

    private static string Simplify(string cref)
    {
        // A method cref carries its parameter list (Remove(System.Guid)); drop it so the
        // last dotted segment is the member name and not "Guid)".
        var paren = cref.IndexOf('(');
        if (paren >= 0)
        {
            cref = cref[..paren];
        }

        var name = cref.Split('.').Last();
        return $"`{name}`";
    }
}
