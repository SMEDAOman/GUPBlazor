using System.Text;
using System.Text.RegularExpressions;

namespace AiDocsGen;

/// Reads the tokens straight out of the shipped gup.css, mirroring the demo's
/// DesignTokenCatalogue, so the AI page documents what the library really exports.
public static partial class TokensPage
{
    [GeneratedRegex(@"^\s*(--gup-[a-z0-9-]+)\s*:\s*([^;]+);(?:\s*/\*(.*?)\*/)?", RegexOptions.Multiline)]
    private static partial Regex TokenRx();

    public static int Write(string outDir, string repoRoot, string baseUrl, string version)
    {
        var css = Path.Combine(repoRoot, "GUPBlazor", "wwwroot", "gup.css");
        if (!File.Exists(css))
        {
            return 0;
        }

        var tokens = TokenRx().Matches(File.ReadAllText(css))
            .Select(m => (
                Name: m.Groups[1].Value,
                Value: m.Groups[2].Value.Trim(),
                Note: Note(m.Groups[3])))
            .GroupBy(t => t.Name)
            .Select(g => g.First())
            .OrderBy(t => NaturalKey(t.Name), StringComparer.Ordinal)
            .ToList();

        var sb = new StringBuilder();
        sb.AppendLine("# GUPBlazor — design tokens");
        sb.AppendLine();
        sb.AppendLine($"> GUPBlazor {version}. {tokens.Count} CSS custom properties, read from the shipped `gup.css`.");
        sb.AppendLine();
        sb.AppendLine("Use the token, not the literal value — the palette is re-themed per entity and raw hex");
        sb.AppendLine("will not follow. Tokens are available anywhere once `<GUPHTMLHeader />` is on the page.");
        sb.AppendLine();
        sb.AppendLine("```css");
        sb.AppendLine(".my-panel {");
        sb.AppendLine("    color: var(--gup-color-content-high);");
        sb.AppendLine("    background: var(--gup-color-background-low);");
        sb.AppendLine("}");
        sb.AppendLine("```");
        sb.AppendLine();

        var taken = new HashSet<string>(StringComparer.Ordinal);

        void Group(string title, string intro, params string[] prefixes)
        {
            var matched = tokens
                .Where(t => !taken.Contains(t.Name) && prefixes.Any(p => t.Name.StartsWith(p, StringComparison.Ordinal)))
                .ToList();

            if (matched.Count == 0)
            {
                return;
            }

            foreach (var t in matched)
            {
                taken.Add(t.Name);
            }

            sb.AppendLine($"## {title}");
            sb.AppendLine();
            sb.AppendLine(intro);
            sb.AppendLine();
            sb.AppendLine("| Token | Value | Note |");
            sb.AppendLine("|---|---|---|");
            foreach (var t in matched)
            {
                sb.AppendLine($"| `{t.Name}` | `{Escape(t.Value)}` | {Escape(t.Note ?? "")} |");
            }

            sb.AppendLine();
        }

        Group("Colors — brand", "The primary palette. Components consume the semantic slots, not raw hex.", "--gup-color-brand");
        Group("Colors — content & icon", "Text and icon colors, including the inverted set for dark surfaces.", "--gup-color-content", "--gup-color-icon");
        Group("Colors — background & border", "Surfaces and strokes. Values with a slash are alpha compositions.", "--gup-color-background", "--gup-color-border");
        Group("Colors — status", "Success, warning, error and info slots.", "--gup-color-positive", "--gup-color-negative", "--gup-color-warning", "--gup-color-neutral", "--gup-color-info");
        Group("Colors — other", "Remaining color tokens.", "--gup-color");
        Group("Spacing", "The spacing scale. `GupTrack` gap values map onto these.", "--gup-spacing", "--gup-space", "--gup-gap");
        Group("Typography", "Font families, sizes, weights and line heights.", "--gup-font", "--gup-text", "--gup-line", "--gup-letter");
        Group("Radius & elevation", "Corner radii and shadows.", "--gup-radius", "--gup-border-radius", "--gup-shadow", "--gup-elevation");
        Group("Sizing & layout", "Widths, heights, breakpoints and z-index.", "--gup-size", "--gup-width", "--gup-height", "--gup-breakpoint", "--gup-z", "--gup-container");
        Group("Motion", "Durations and easing curves.", "--gup-duration", "--gup-ease", "--gup-transition", "--gup-motion");
        Group("Everything else", "Tokens that do not fall into the groups above.", "--gup-");

        sb.AppendLine("---");
        sb.AppendLine();
        sb.AppendLine($"Full index: {baseUrl}/ai/index.md · Live token browser: {baseUrl}/demo/design-tokens");

        Directory.CreateDirectory(outDir);
        File.WriteAllText(Path.Combine(outDir, "design-tokens.md"), sb.ToString(), new UTF8Encoding(false));
        return tokens.Count;
    }

    // Zero-pads digit runs so --gup-space-2 sorts before --gup-space-10.
    private static string NaturalKey(string name) =>
        Regex.Replace(name, @"\d+", m => m.Value.PadLeft(6, '0'));

    // Section banners ("--- Semantic Colors ---") trail the declaration above them.
    private static string? Note(Group capture)
    {
        if (!capture.Success)
        {
            return null;
        }

        var text = capture.Value.Trim();
        return text.StartsWith("---", StringComparison.Ordinal) ? null : text;
    }

    private static string Escape(string s) =>
        s.Replace("|", "\\|").Replace("\r", " ").Replace("\n", " ");
}
