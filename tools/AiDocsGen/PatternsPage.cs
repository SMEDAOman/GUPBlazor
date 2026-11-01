using System.Text;

namespace AiDocsGen;

/// Compositions that are not components. The demo catalogue lists these beside real
/// components (Error summary, Add row, Address form), so an agent follows the link,
/// finds an HTML demo with no markup, and either guesses a component name that does
/// not exist or gives up. This page gives them real markup instead.
public static class PatternsPage
{
    private sealed record Pattern(string Title, string Slug, string Blurb, string DemoFile, string RootTag);

    private static readonly Pattern[] Patterns =
    [
        new("Error summary", "error-summary",
            "A validation summary that lists every invalid field and links to each one. There is no "
            + "`GupErrorSummary` component — it is a `GupBanner` with `Type=Error` wrapping a list of "
            + "buttons, plus `role=\"alert\"` on the wrapper so assistive tech announces it.",
            "ErrorSummary.razor", "GupBanner"),

        new("Add row", "add-row",
            "Adding rows to a table from a flyout form, rather than editing in place.",
            "Patterns/AddRow.razor", "GupFlyout"),

        new("Address form", "address-form",
            "The standard address field set, in the order and grouping services use.",
            "Patterns/AddressForm.razor", "GupFormSection"),
    ];

    public static int Write(string outDir, string repoRoot, string baseUrl, string version)
    {
        var pagesDir = Path.Combine(repoRoot, "GUPBlazorDemo", "Components", "Pages", "Demo");
        if (!Directory.Exists(pagesDir))
        {
            return 0;
        }

        var sb = new StringBuilder();
        sb.AppendLine("# GUPBlazor — patterns");
        sb.AppendLine();
        sb.AppendLine($"> GUPBlazor {version}. Compositions built from the components, not components");
        sb.AppendLine("> themselves. Each one below has **no** dedicated `Gup…` type — do not look for one.");
        sb.AppendLine();

        var written = 0;

        foreach (var p in Patterns)
        {
            var path = Path.Combine(pagesDir, p.DemoFile.Replace('/', Path.DirectorySeparatorChar));
            if (!File.Exists(path))
            {
                continue;
            }

            var examples = ExampleExtractor.FromPage(File.ReadAllText(path), Path.GetFileName(path));
            if (examples.Count == 0)
            {
                examples = ExampleExtractor.FromWholePage(
                    File.ReadAllText(path), Path.GetFileName(path), p.RootTag);
            }

            if (examples.Count == 0)
            {
                continue;
            }

            sb.AppendLine($"## {p.Title}");
            sb.AppendLine();
            sb.AppendLine(p.Blurb);
            sb.AppendLine();
            sb.AppendLine($"Live demo: {baseUrl}/demo/{p.Slug}");
            sb.AppendLine();

            // One example is enough to show the shape; the rest are variations.
            var ex = examples[0];
            sb.AppendLine($"<!-- from GUPBlazorDemo/Components/Pages/Demo/{p.DemoFile} -->");
            sb.AppendLine("```razor");
            sb.AppendLine(ex.Code);
            sb.AppendLine("```");
            sb.AppendLine();
            written++;
        }

        if (written == 0)
        {
            return 0;
        }

        sb.AppendLine("---");
        sb.AppendLine();
        sb.AppendLine($"Full index: {baseUrl}/ai/index.md");

        Directory.CreateDirectory(outDir);
        File.WriteAllText(Path.Combine(outDir, "patterns.md"), sb.ToString(), new UTF8Encoding(false));
        return written;
    }
}
