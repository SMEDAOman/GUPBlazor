using System.Text.RegularExpressions;

namespace GUPBlazorDemo.Components;

public record DesignToken(string Name, string Value, string? Comment);

public record TokenGroup(string Title, string Intro, DesignToken[] Tokens);

/// <summary>
/// Reads the design tokens straight out of the shipped gup.css so the reference
/// page documents what the library actually exports rather than a hand-kept copy.
/// </summary>
public sealed partial class DesignTokenCatalogue(IWebHostEnvironment env)
{
    private TokenGroup[]? _groups;

    public TokenGroup[] Groups => _groups ??= Load();

    public int TotalCount => Groups.Sum(g => g.Tokens.Length);

    [GeneratedRegex(@"^\s*(--gup-[a-z0-9-]+)\s*:\s*([^;]+);(?:\s*/\*(.*?)\*/)?", RegexOptions.Multiline)]
    private static partial Regex TokenPattern();

    private TokenGroup[] Load()
    {
        var css = ReadCss();
        if (css is null)
        {
            return [];
        }

        var tokens = TokenPattern().Matches(css)
            .Select(m => new DesignToken(
                m.Groups[1].Value,
                m.Groups[2].Value.Trim(),
                Note(m.Groups[3])))
            .GroupBy(t => t.Name)
            .Select(g => g.First())
            .ToArray();

        return BuildGroups(tokens);
    }

    // Section banners ("--- Semantic Colors ---") trail whichever declaration ends
    // the line above them; they describe the next block, not that token.
    private static string? Note(Group capture)
    {
        if (!capture.Success)
        {
            return null;
        }

        var text = capture.Value.Trim();
        return text.StartsWith("---", StringComparison.Ordinal) ? null : text;
    }

    private string? ReadCss()
    {
        // Published builds expose the library's wwwroot under _content; the source
        // copy is only there when running from the repo.
        var candidates = new[]
        {
            Path.Combine(env.WebRootPath, "_content", "GUPBlazor", "gup.css"),
            Path.Combine(env.ContentRootPath, "..", "GUPBlazor", "wwwroot", "gup.css"),
        };

        foreach (var path in candidates)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
        }

        return null;
    }

    private static TokenGroup[] BuildGroups(DesignToken[] all)
    {
        var taken = new HashSet<string>();

        TokenGroup Group(string title, string intro, params string[] prefixes)
        {
            var matched = all
                .Where(t => !taken.Contains(t.Name) && prefixes.Any(p => t.Name.StartsWith(p, StringComparison.Ordinal)))
                .OrderBy(t => t.Name, StringComparer.Ordinal)
                .ToArray();

            foreach (var t in matched)
            {
                taken.Add(t.Name);
            }

            return new TokenGroup(title, intro, matched);
        }

        var groups = new List<TokenGroup>
        {
            Group("Colors — brand",
                "The primary palette. Components consume the semantic slots (xhigh → xlow), not raw hex.",
                "--gup-color-brand"),

            Group("Colors — content & icon",
                "Text and icon colors, including the inverted set for dark surfaces.",
                "--gup-color-content", "--gup-color-icon"),

            Group("Colors — background & border",
                "Surfaces and strokes. Values with a slash are alpha compositions.",
                "--gup-color-background", "--gup-color-border"),

            Group("Colors — status",
                "Success, warning, danger and info, used by badges, banners, toasts and validation.",
                "--gup-color-success", "--gup-color-danger", "--gup-color-warning",
                "--gup-color-error", "--gup-color-info"),

            Group("Colors — neutral",
                "The greyscale ramp behind borders, surfaces and secondary text.",
                "--gup-color-neutral"),

            Group("Colors — remaining",
                "Everything else in the color space, including Figma-mapping values.",
                "--gup-color"),

            Group("Typography",
                "The type ramp. Each slot carries its own size, weight and line height.",
                "--gup-display", "--gup-headline", "--gup-body", "--gup-label",
                "--gup-strong", "--gup-font"),

            Group("Spacing",
                "Gaps between content. Prefer these over raw pixel values so rhythm stays consistent.",
                "--gup-spacing", "--gup-space", "--gup-universal", "--gup-gutter"),

            Group("Padding & component sizing",
                "Internal padding and the component size ramp.",
                "--gup-padding", "--gup-component"),

            Group("Radius, stroke & elevation",
                "Corner radii, border widths and shadows.",
                "--gup-radius", "--gup-stroke", "--gup-shadow"),

            Group("Icons",
                "The icon size ramp, xs through xl.",
                "--gup-icon"),

            Group("Layout & breakpoints",
                "Container widths, the grid, and the breakpoints the responsive rules key off.",
                "--gup-breakpoint", "--gup-container", "--gup-grid"),

            Group("Per-component tokens",
                "Overrides scoped to a single component — set these to restyle one component without touching the global palette.",
                "--gup-accordion", "--gup-callout", "--gup-divider", "--gup-filter",
                "--gup-flag", "--gup-page", "--gup-pagination", "--gup-search",
                "--gup-stepper", "--gup-tab", "--gup-toast", "--gup-toggle",
                "--gup-tooltip", "--gup-wizard"),
        };

        var leftovers = all.Where(t => !taken.Contains(t.Name))
            .OrderBy(t => t.Name, StringComparer.Ordinal)
            .ToArray();

        if (leftovers.Length > 0)
        {
            groups.Add(new TokenGroup("Other", "Tokens that do not fall into the groups above.", leftovers));
        }

        return groups.Where(g => g.Tokens.Length > 0).ToArray();
    }
}
