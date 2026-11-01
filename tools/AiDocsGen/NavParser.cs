using System.Text.RegularExpressions;

namespace AiDocsGen;

/// Reads DemoNav.cs so the generated index mirrors the sidebar exactly and the
/// two cannot drift. Parsed as text rather than referenced, to keep this tool
/// out of the shipped projects' dependency graph.
public static partial class NavParser
{
    [GeneratedRegex(@"new\s*\(\s*""(?<href>/[^""]*)""\s*,\s*""(?<title>(?:[^""\\]|\\.)*)""\s*,\s*""(?<desc>(?:[^""\\]|\\.)*)""\s*\)")]
    private static partial Regex EntryRx();

    [GeneratedRegex(@"new\s*\(\s*""(?<title>[^""]+)""\s*,\s*$\s*""(?<intro>(?:[^""\\]|\\.)*)""\s*,",
        RegexOptions.Multiline)]
    private static partial Regex SectionRx();

    public static List<SectionDoc> Parse(string source)
    {
        var sections = new List<SectionDoc>();

        var sectionMatches = SectionRx().Matches(source).Cast<Match>().ToList();

        for (var i = 0; i < sectionMatches.Count; i++)
        {
            var start = sectionMatches[i].Index;
            var end = i + 1 < sectionMatches.Count ? sectionMatches[i + 1].Index : source.Length;
            var slice = source[start..end];

            var pages = EntryRx().Matches(slice)
                .Cast<Match>()
                .Select(e => new DemoPageRef(
                    Route: e.Groups["href"].Value,
                    Title: Unescape(e.Groups["title"].Value),
                    Description: Unescape(e.Groups["desc"].Value),
                    Section: Unescape(sectionMatches[i].Groups["title"].Value)))
                .ToList();

            sections.Add(new SectionDoc(
                Title: Unescape(sectionMatches[i].Groups["title"].Value),
                Intro: Unescape(sectionMatches[i].Groups["intro"].Value),
                Pages: pages));
        }

        return sections;
    }

    private static string Unescape(string s) =>
        s.Replace("\\\"", "\"").Replace("\\\\", "\\");
}
