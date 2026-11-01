using System.Text;
using AiDocsGen;

var repoRoot = Arg("--repo") ?? FindRepoRoot();
var outDir = Arg("--out") ?? Path.Combine(repoRoot, "docs", "ai");
// Empty by default, which makes every link root-relative ("/ai/index.md") so the
// same files work on localhost, in a container, and on raw.githubusercontent.com.
// Pass --base-url to absolutise them for a known public host.
var baseUrl = (Arg("--base-url") ?? "").TrimEnd('/');

var libDir = Path.Combine(repoRoot, "GUPBlazor", "Components");
var demoPagesDir = Path.Combine(repoRoot, "GUPBlazorDemo", "Components", "Pages");
var navFile = Path.Combine(repoRoot, "GUPBlazorDemo", "Components", "DemoNav.cs");

if (!Directory.Exists(libDir))
{
    Console.Error.WriteLine($"error: component directory not found: {libDir}");
    return 1;
}

var version = ReadVersion(Path.Combine(repoRoot, "GUPBlazor", "GUPBlazor.csproj"));

var xmlPath = FindXmlDoc(repoRoot);
if (xmlPath is null)
{
    Console.Error.WriteLine(
        "warning: GUPBlazor.xml not found, so enum and type summaries will be missing.\n" +
        "         Build the library first: dotnet build GUPBlazor -c Release");
}

var xml = XmlDocs.Load(xmlPath);

Console.WriteLine($"GUPBlazor {version}");
Console.WriteLine($"  components : {libDir}");
Console.WriteLine($"  base url   : {baseUrl}");
Console.WriteLine($"  output     : {outDir}");

var sections = File.Exists(navFile) ? NavParser.Parse(File.ReadAllText(navFile)) : [];
var navByTitle = sections
    .SelectMany(s => s.Pages)
    .GroupBy(p => p.Title, StringComparer.OrdinalIgnoreCase)
    .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);

// Examples indexed by the component names they mention, so each component page
// can show the real markup from whichever demo page exercises it.
var allExamples = new List<ExampleDoc>();
var demoPageSources = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
if (Directory.Exists(demoPagesDir))
{
    foreach (var page in Directory.EnumerateFiles(demoPagesDir, "*.razor", SearchOption.AllDirectories))
    {
        var text = File.ReadAllText(page);
        demoPageSources[Path.GetFileName(page)] = text;
        allExamples.AddRange(ExampleExtractor.FromPage(text, Path.GetFileName(page)));
    }
}

Console.WriteLine($"  examples   : {allExamples.Count} found across demo pages");

// Enums live in separate *Enums.cs / *Types.cs files; map them to their component by prefix.
var enumsByOwner = new Dictionary<string, List<EnumDoc>>(StringComparer.OrdinalIgnoreCase);
foreach (var file in Directory.EnumerateFiles(libDir, "*.cs"))
{
    var parsed = EnumParser.Parse(File.ReadAllText(file), xml);
    if (parsed.Count == 0)
    {
        continue;
    }

    var owner = Path.GetFileNameWithoutExtension(file)
        .Replace("Enums", "", StringComparison.Ordinal)
        .Replace("Types", "", StringComparison.Ordinal);

    if (!enumsByOwner.TryGetValue(owner, out var list))
    {
        enumsByOwner[owner] = list = [];
    }

    list.AddRange(parsed);
}

/// Components whose demo page is titled differently from the component name
/// ("Table & table cell", "Toast & toast container"). Keyed by component, valued
/// by the nav title to look up.
var PageAliases = new Dictionary<string, string>(StringComparer.Ordinal)
{
    ["GupTable"] = "Table & table cell",
    ["GupTableRow"] = "Table & table cell",
    ["GupTableCell"] = "Table & table cell",
    ["GupToast"] = "Toast & toast container",
    ["GupToastContainer"] = "Toast & toast container",
    ["GupWizard"] = "Wizard main & footer",
    ["GupWizardMain"] = "Wizard main & footer",
    ["GupWizardFooter"] = "Wizard main & footer",
    ["GUPWizardStack"] = "Wizard main & footer",
    ["GUPWizardStackStep"] = "Wizard main & footer",
    ["GupTab"] = "Tabs",
    ["GupTabPanel"] = "Tabs",
    ["GupTabsNavigation"] = "Tabs",
    ["GupTextarea"] = "Textarea field",
    ["GupScreenReaderText"] = "Screenreader text",
    ["GupReadOnlyRegion"] = "Read-only cascade",
    ["GupIcon"] = "Icons",
    ["GupLink"] = "Button",
    ["GupStepperItem"] = "Stepper",
    ["GupRadioButtonGroup"] = "Radio button",
    ["GupDropdownMenu"] = "Dropdown",
    ["GupDropdownMenuItem"] = "Dropdown",
    ["GupFormList"] = "Form list",
    ["GupLabelledItem"] = "Labelled item",
};

var components = new List<ComponentDoc>();

foreach (var file in Directory.EnumerateFiles(libDir, "*.razor").OrderBy(f => f, StringComparer.Ordinal))
{
    var name = Path.GetFileNameWithoutExtension(file);
    if (name.StartsWith('_'))
    {
        continue;
    }

    var source = File.ReadAllText(file);
    var (parameters, cascading) = RazorParser.Parse(source);

    var demoPage = MatchDemoPageWithParent(name, navByTitle, PageAliases);
    // Only a component that *is* the page's subject borrows its description; an
    // aliased child links to the page but describes itself as part of the set.
    var ownDemoPage = PageAliases.ContainsKey(name) ? null : MatchDemoPage(name, navByTitle, PageAliases);

    // Rank by how much the example is *about* this component: its own demo page first,
    // then by how early the tag appears, so a page that merely contains one ranks last.
    var examples = allExamples
        .Where(e => MentionsComponent(e.Code, name))
        .Select(e => new
        {
            Example = e,
            OwnPage = OwnsPage(e.SourcePage, name),
            FirstUse = e.Code.IndexOf($"<{name}", StringComparison.Ordinal),
        })
        .OrderByDescending(x => x.OwnPage)
        .ThenBy(x => x.FirstUse)
        .Select(x => x.Example)
        .Take(8)
        .ToList();

    // Nothing wrapped in a <DemoExample> uses this component, so fall back to the raw
    // page markup. This is what rescues the wizard components, demonstrated only by
    // the page templates.
    if (examples.Count == 0)
    {
        foreach (var (pageName, pageText) in demoPageSources)
        {
            examples.AddRange(ExampleExtractor.FromWholePage(pageText, pageName, name));
            if (examples.Count >= 2)
            {
                break;
            }
        }
    }

    components.Add(new ComponentDoc(
        Name: name,
        File: Path.GetFileName(file),
        Summary: xml.Type($"GUPBlazor.Components.{name}")
                 ?? ownDemoPage?.Description
                 ?? ChildSummary(name, demoPage),
        HeaderComment: RazorParser.ExtractHeaderComment(source),
        Parameters: parameters,
        CascadingParameters: cascading,
        Enums: enumsByOwner.GetValueOrDefault(name) ?? [],
        Examples: examples,
        DemoPage: demoPage));
}

// Root-level components that ship outside Components/ but matter to consumers.
foreach (var extra in new[] { "GUPHTMLHeader", "GUPHTMLFooter" })
{
    var path = Path.Combine(repoRoot, "GUPBlazor", $"{extra}.razor");
    if (!File.Exists(path))
    {
        continue;
    }

    var source = File.ReadAllText(path);
    var (parameters, cascading) = RazorParser.Parse(source);
    components.Add(new ComponentDoc(
        Name: extra,
        File: $"../{extra}.razor",
        Summary: extra.Contains("Header")
            ? "Emits the stylesheet, font and design-token links GUPBlazor needs. Place inside <head>."
            : "Emits the scripts GUPBlazor needs. Place just before </body>.",
        HeaderComment: null,
        Parameters: parameters,
        CascadingParameters: cascading,
        Enums: [],
        Examples: [],
        DemoPage: null));
}

Console.WriteLine($"  parsed     : {components.Count} components, {components.Sum(c => c.Parameters.Count)} parameters");

var writer = new MarkdownWriter(baseUrl, version);

var componentsDir = Path.Combine(outDir, "components");
Directory.CreateDirectory(componentsDir);

foreach (var c in components)
{
    var path = Path.Combine(componentsDir, $"{MarkdownWriter.Slug(c.Name)}.md");
    File.WriteAllText(path, writer.Component(c), new UTF8Encoding(false));
}

File.WriteAllText(Path.Combine(outDir, "index.md"), writer.Index(components, sections), new UTF8Encoding(false));

// llms.txt and llms-full.txt belong at the site root, not under /ai.
var siteRoot = Directory.GetParent(outDir)!.FullName;
File.WriteAllText(Path.Combine(siteRoot, "llms.txt"), writer.LlmsTxt(components), new UTF8Encoding(false));

var full = new StringBuilder();
full.AppendLine("# GUPBlazor — complete reference");
full.AppendLine();
full.AppendLine($"Version {version}. Every component in one file, for a single fetch.");
full.AppendLine($"Generated from source. Canonical: {baseUrl}/llms.txt");
full.AppendLine();
foreach (var c in components.OrderBy(c => c.Name, StringComparer.Ordinal))
{
    full.AppendLine(writer.Component(c));
    full.AppendLine();
}

File.WriteAllText(Path.Combine(siteRoot, "llms-full.txt"), full.ToString(), new UTF8Encoding(false));

StaticPages.Write(outDir, baseUrl, version, components.Count);

var tokenCount = TokensPage.Write(outDir, repoRoot, baseUrl, version);
Console.WriteLine($"  tokens     : {tokenCount} design tokens from gup.css");

var typeCount = TypesPage.Write(outDir, repoRoot, xml, baseUrl, version);
Console.WriteLine($"  types      : {typeCount} support types (event payloads, config objects)");

var patternCount = PatternsPage.Write(outDir, repoRoot, baseUrl, version);
Console.WriteLine($"  patterns   : {patternCount} compositions that are not components");

Console.WriteLine($"  wrote      : {components.Count} component files + index, llms.txt, llms-full.txt, guides");
Console.WriteLine("done.");
return 0;

/// Last-resort description for a child component with no XML doc and no page of its
/// own, so neither the index nor llms.txt shows a blank cell.
static string? ChildSummary(string component, DemoPageRef? parentPage) =>
    parentPage is null
        ? null
        : $"Part of the {parentPage.Title} component set — see the {parentPage.Title} page for how it composes.";

/// True when the demo page's file name is the one that documents this component,
/// e.g. Buttons.razor for GupButton, so its own examples outrank incidental uses.
static bool OwnsPage(string pageFile, string component)
{
    var page = Path.GetFileNameWithoutExtension(pageFile);
    var bare = component.StartsWith("Gup", StringComparison.OrdinalIgnoreCase) ? component[3..] : component;

    return page.Equals(bare, StringComparison.OrdinalIgnoreCase)
        || page.Equals(bare + "s", StringComparison.OrdinalIgnoreCase)
        || page.Equals(bare + "Demo", StringComparison.OrdinalIgnoreCase)
        || (bare.EndsWith("y", StringComparison.Ordinal) && page.Equals(bare[..^1] + "ies", StringComparison.OrdinalIgnoreCase));
}

static bool MentionsComponent(string code, string name) =>
    code.Contains($"<{name} ", StringComparison.Ordinal) ||
    code.Contains($"<{name}>", StringComparison.Ordinal) ||
    code.Contains($"<{name}/>", StringComparison.Ordinal) ||
    code.Contains($"<{name} />", StringComparison.Ordinal);

/// A child component (GupAccordionItem, GupTableRow, …) rarely has its own nav entry.
/// Fall back to the nearest ancestor's page by trimming trailing words, so the doc
/// still links somewhere useful and can borrow a description.
static DemoPageRef? MatchDemoPageWithParent(string component, Dictionary<string, DemoPageRef> nav, Dictionary<string, string>? aliases = null)
{
    if (MatchDemoPage(component, nav, aliases) is { } own)
    {
        return own;
    }

    var bare = component.StartsWith("GUP", StringComparison.Ordinal) ? component[3..]
             : component.StartsWith("Gup", StringComparison.Ordinal) ? component[3..]
             : component;

    // Split on word boundaries, then drop the last word repeatedly: AccordionItemAction
    // -> AccordionItem -> Accordion.
    var words = System.Text.RegularExpressions.Regex
        .Matches(bare, @"[A-Z]+(?![a-z])|[A-Z][a-z]*|[0-9]+")
        .Select(m => m.Value)
        .ToList();

    for (var take = words.Count - 1; take >= 1; take--)
    {
        var candidate = "Gup" + string.Concat(words.Take(take));
        if (MatchDemoPage(candidate, nav, aliases) is { } parent)
        {
            return parent;
        }
    }

    return null;
}


static DemoPageRef? MatchDemoPage(string component, Dictionary<string, DemoPageRef> nav, Dictionary<string, string>? aliases = null)
{
    if (aliases is not null && aliases.TryGetValue(component, out var alias) && nav.TryGetValue(alias, out var aliased))
    {
        return aliased;
    }

    // "GupButton" -> "Button", "GUPWizardStack" -> "WizardStack"
    var bare = component.StartsWith("GUP", StringComparison.Ordinal) ? component[3..]
             : component.StartsWith("Gup", StringComparison.Ordinal) ? component[3..]
             : component;

    if (nav.TryGetValue(bare, out var hit))
    {
        return hit;
    }

    var spaced = string.Concat(bare.Select((ch, i) => char.IsUpper(ch) && i > 0 ? " " + char.ToLowerInvariant(ch) : ch.ToString()));
    return nav.GetValueOrDefault(spaced);
}

static string ReadVersion(string csproj)
{
    if (!File.Exists(csproj))
    {
        return "0.0.0";
    }

    var text = File.ReadAllText(csproj);
    var m = System.Text.RegularExpressions.Regex.Match(text, @"<Version>([^<]+)</Version>");
    return m.Success ? m.Groups[1].Value : "0.0.0";
}

static string? FindXmlDoc(string root)
{
    var candidates = new[]
    {
        Path.Combine(root, "GUPBlazor", "bin", "Release", "net10.0", "GUPBlazor.xml"),
        Path.Combine(root, "GUPBlazor", "bin", "Debug", "net10.0", "GUPBlazor.xml"),
    };

    return candidates.FirstOrDefault(File.Exists);
}

static string FindRepoRoot()
{
    var dir = new DirectoryInfo(AppContext.BaseDirectory);
    while (dir is not null)
    {
        if (File.Exists(Path.Combine(dir.FullName, "GUPBlazor.slnx")))
        {
            return dir.FullName;
        }

        dir = dir.Parent;
    }

    return Directory.GetCurrentDirectory();
}

static string? Arg(string name)
{
    var args = Environment.GetCommandLineArgs();
    var i = Array.IndexOf(args, name);
    return i >= 0 && i + 1 < args.Length ? args[i + 1] : null;
}
