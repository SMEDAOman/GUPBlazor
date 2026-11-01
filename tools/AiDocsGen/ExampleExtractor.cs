using System.Text.RegularExpressions;

namespace AiDocsGen;

/// Pulls every <DemoExample> block out of a demo page. Mirrors the runtime
/// ExampleSourceProvider so the generated docs and "Show code" agree.
public static partial class ExampleExtractor
{
    [GeneratedRegex(@"<DemoExample\b(?<attrs>[^>]*?)(?<selfclose>/)?>", RegexOptions.Singleline)]
    private static partial Regex OpenTagRx();

    [GeneratedRegex(@"(?<key>\w+)\s*=\s*""(?<val>[^""]*)""")]
    private static partial Regex AttrRx();

    public static List<ExampleDoc> FromPage(string source, string pageFileName)
    {
        var results = new List<ExampleDoc>();

        foreach (var m in OpenTagRx().Matches(source).Cast<Match>())
        {
            if (m.Groups["selfclose"].Success)
            {
                continue;
            }

            var attrs = AttrRx().Matches(m.Groups["attrs"].Value)
                .Cast<Match>()
                .ToDictionary(a => a.Groups["key"].Value, a => a.Groups["val"].Value, StringComparer.Ordinal);

            var bodyStart = m.Index + m.Length;
            var close = FindClose(source, bodyStart);
            if (close < 0)
            {
                continue;
            }

            var code = Dedent(source[bodyStart..close]);
            if (string.IsNullOrWhiteSpace(code))
            {
                continue;
            }

            var label = attrs.GetValueOrDefault("Label") is { Length: > 0 } l
                ? Decode(l)
                : Humanize(attrs.GetValueOrDefault("Id") ?? "Example");

            results.Add(new ExampleDoc(label, code, pageFileName));
        }

        return results;
    }

    // DemoExample nests, so track depth rather than taking the first closing tag.
    private static int FindClose(string source, int from)
    {
        var depth = 1;
        var i = from;

        while (depth > 0)
        {
            var next = source.IndexOf("<DemoExample", i + 1, StringComparison.Ordinal);
            var end = source.IndexOf("</DemoExample>", i + 1, StringComparison.Ordinal);

            if (end < 0)
            {
                return -1;
            }

            if (next >= 0 && next < end)
            {
                depth++;
                i = next;
                continue;
            }

            depth--;
            if (depth == 0)
            {
                return end;
            }

            i = end;
        }

        return -1;
    }

    /// Usage of one component pulled straight from a page, for components that no
    /// &lt;DemoExample&gt; wraps — the page templates (ServiceStart and friends) are the
    /// only demonstration of the wizard components, and production leans on them.
    public static List<ExampleDoc> FromWholePage(string source, string pageFileName, string component)
    {
        var results = new List<ExampleDoc>();
        var open = $"<{component}";
        var close = $"</{component}>";

        var i = source.IndexOf(open, StringComparison.Ordinal);
        while (i >= 0 && results.Count < 2)
        {
            // Must be the tag itself, not a longer component with the same prefix.
            var after = i + open.Length;
            if (after < source.Length && (char.IsLetterOrDigit(source[after]) || source[after] == '-'))
            {
                i = source.IndexOf(open, i + 1, StringComparison.Ordinal);
                continue;
            }

            var end = source.IndexOf(close, after, StringComparison.Ordinal);
            if (end < 0)
            {
                break;
            }

            var block = Dedent(source[i..(end + close.Length)]);

            // A whole template can be enormous; keep it readable.
            if (block.Length is > 60 and < 6000)
            {
                results.Add(new ExampleDoc(
                    $"From the {Path.GetFileNameWithoutExtension(pageFileName)} page template",
                    block,
                    pageFileName));
            }

            i = source.IndexOf(open, end, StringComparison.Ordinal);
        }

        return results;
    }

    private static string Dedent(string block)
    {
        var lines = block.Replace("\r\n", "\n").Split('\n').ToList();

        while (lines.Count > 0 && lines[0].Trim().Length == 0)
        {
            lines.RemoveAt(0);
        }

        while (lines.Count > 0 && lines[^1].Trim().Length == 0)
        {
            lines.RemoveAt(lines.Count - 1);
        }

        if (lines.Count == 0)
        {
            return "";
        }

        var indent = lines
            .Where(l => l.Trim().Length > 0)
            .Select(l => l.Length - l.TrimStart().Length)
            .DefaultIfEmpty(0)
            .Min();

        return string.Join("\n", lines.Select(l => l.Length >= indent ? l[indent..] : l.TrimStart()));
    }

    /// "two-way-binding-bind-open" -> "Two way binding bind open"
    private static string Humanize(string id)
    {
        var words = id.Replace('-', ' ').Replace('_', ' ').Trim();
        words = Regex.Replace(words, @"\s+", " ");
        return words.Length == 0 ? "Example" : char.ToUpperInvariant(words[0]) + words[1..];
    }

    private static string Decode(string s) =>
        s.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&").Replace("&quot;", "\"");
}
