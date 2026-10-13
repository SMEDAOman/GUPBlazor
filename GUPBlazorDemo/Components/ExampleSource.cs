using System.Collections.Concurrent;
using System.Reflection;
using System.Text;

namespace GUPBlazorDemo.Components;

/// <summary>
/// Pulls the markup for a demo example out of the page's own embedded source, so
/// "Show code" quotes what actually rendered rather than a hand-copied snippet.
/// </summary>
public sealed class ExampleSourceProvider
{
    private readonly ConcurrentDictionary<string, string?> _files = new(StringComparer.OrdinalIgnoreCase);
    private readonly ConcurrentDictionary<string, string?> _snippets = new(StringComparer.Ordinal);

    /// <summary>
    /// Markup of the <c>&lt;DemoExample&gt;</c> whose Id matches, with its wrapper and the
    /// surrounding indentation removed. Null when the source is unavailable.
    /// </summary>
    public string? Get(string file, string id) =>
        _snippets.GetOrAdd($"{file}|{id}", _ => Extract(file, id));

    private string? Extract(string file, string id)
    {
        var source = Load(file);
        if (source is null)
        {
            return null;
        }

        var marker = $"Id=\"{id}\"";
        var at = source.IndexOf(marker, StringComparison.Ordinal);
        if (at < 0)
        {
            return null;
        }

        var open = source.LastIndexOf("<DemoExample", at, StringComparison.Ordinal);
        if (open < 0)
        {
            return null;
        }

        var bodyStart = source.IndexOf('>', at);
        if (bodyStart < 0)
        {
            return null;
        }

        // Self-closing example: nothing to show.
        if (source[bodyStart - 1] == '/')
        {
            return null;
        }

        var close = FindClose(source, bodyStart);
        return close < 0 ? null : Dedent(source[(bodyStart + 1)..close]);
    }

    // DemoExample can nest, so track depth rather than taking the first closing tag.
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

    private static string Dedent(string block)
    {
        var lines = block.Replace("\r\n", "\n").Split('\n')
            .SkipWhile(string.IsNullOrWhiteSpace)
            .ToList();

        while (lines.Count > 0 && string.IsNullOrWhiteSpace(lines[^1]))
        {
            lines.RemoveAt(lines.Count - 1);
        }

        if (lines.Count == 0)
        {
            return "";
        }

        var indent = lines
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Min(l => l.Length - l.TrimStart().Length);

        var sb = new StringBuilder();
        foreach (var line in lines)
        {
            sb.AppendLine(line.Length >= indent ? line[indent..] : line.TrimStart());
        }

        return sb.ToString().TrimEnd();
    }

    private string? Load(string file) => _files.GetOrAdd(file, f =>
    {
        var assembly = Assembly.GetExecutingAssembly();
        // MSBuild writes RecursiveDir with the platform separator, so names look like
        // "src/Demo\Logo.razor"; match on the leaf regardless of which one is used.
        var name = assembly.GetManifestResourceNames()
            .FirstOrDefault(n => n.Replace('\\', '/')
                .EndsWith("/" + f.Replace('\\', '/'), StringComparison.OrdinalIgnoreCase));

        if (name is null)
        {
            return null;
        }

        using var stream = assembly.GetManifestResourceStream(name);
        if (stream is null)
        {
            return null;
        }

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    });
}
