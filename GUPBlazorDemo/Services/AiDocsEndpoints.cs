using System.Text;

namespace GUPBlazorDemo.Services;

/// Serves the generated AI reference as plain text, so a web-fetching agent gets
/// markdown instead of the Blazor prerender (which carries none of the code
/// snippets — those only appear once the interactive circuit connects).
public static class AiDocsEndpoints
{
    // Everything is served as text/plain: some AI web readers refuse text/markdown
    // outright, and markdown is readable as plain text either way.
    // Everything is served as text/plain: some AI web readers refuse text/markdown
    // outright, and markdown reads fine as plain text either way.
    private const string Plain = "text/plain; charset=utf-8";

    // HEAD as well as GET: many fetchers preflight with HEAD, and a 405 there makes
    // them abandon the URL.
    private static readonly string[] Verbs = ["GET", "HEAD"];

    /// Same files, served without this site's network constraints. Advertised only
    /// in a Link header so it never appears in the documentation text.
    private const string GitHubMirror =
        "https://raw.githubusercontent.com/SMEDAOman/GUPBlazor/main/docs";

    /// Advertises the markdown reference on every HTML response via Link headers, so a
    /// fetcher sees it without parsing <head>. Demo pages additionally point at their own
    /// component doc: landing on /demo/inputs/text otherwise gives no hint that
    /// gup-input-field.md exists.
    public static void UseAiDocLinks(this WebApplication app)
    {
        // Only routes whose doc actually exists: a Link header pointing at a 404 is
        // worse than none, and many demo pages (Installation, Usage) are not components.
        var docsRoot = ResolveDocsRoot(app.Environment);
        var routeToSlug = BuildRouteMap();

        if (docsRoot is not null)
        {
            var componentsDir = Path.Combine(docsRoot, "ai", "components");
            foreach (var route in routeToSlug.Keys.ToList())
            {
                if (!File.Exists(Path.Combine(componentsDir, routeToSlug[route] + ".md")))
                {
                    routeToSlug.Remove(route);
                }
            }
        }
        else
        {
            routeToSlug.Clear();
        }

        app.Use(async (ctx, next) =>
        {
            ctx.Response.OnStarting(() =>
            {
                var type = ctx.Response.ContentType;

                // On the doc responses themselves, advertise the GitHub mirror as a
                // canonical alternate. A fetcher that cannot follow this site's relative
                // links can pick it up from the header; readers never see it.
                if (type is not null && type.Contains("text/plain", StringComparison.OrdinalIgnoreCase))
                {
                    var p = ctx.Request.Path.Value ?? "";
                    if (p.StartsWith("/ai/", StringComparison.OrdinalIgnoreCase)
                        || p is "/docs" or "/reference" or "/llms.txt" or "/llms-full.txt")
                    {
                        var mirrored = p is "/docs" or "/reference" ? "/llms.txt" : p;
                        ctx.Response.Headers["Link"] =
                            $"<{GitHubMirror}{mirrored}>; rel=\"alternate\"; type=\"text/plain\"";
                    }

                    return Task.CompletedTask;
                }

                if (type is not null && type.Contains("text/html", StringComparison.OrdinalIgnoreCase))
                {
                    var links = new List<string>
                    {
                        "</llms.txt>; rel=\"alternate\"; type=\"text/markdown\"",
                        "</ai/index.md>; rel=\"help\"; type=\"text/markdown\"",
                    };

                    var path = ctx.Request.Path.Value?.TrimEnd('/') ?? "";
                    if (routeToSlug.TryGetValue(path, out var slug))
                    {
                        links.Insert(0,
                            $"</ai/components/{slug}.md>; rel=\"alternate\"; type=\"text/markdown\"");
                    }

                    ctx.Response.Headers["Link"] = string.Join(", ", links);
                }

                return Task.CompletedTask;
            });

            await next();
        });
    }

    /// Demo route to component-doc slug, derived from the catalogue so the two cannot drift.
    private static Dictionary<string, string> BuildRouteMap()
    {
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        foreach (var entry in Components.DemoNav.AllEntries)
        {
            // "Input field" -> "gup-input-field"; the generator slugs component names the
            // same way, so a title that names a component resolves to its doc.
            var slug = "gup-" + entry.Title.ToLowerInvariant()
                .Replace("&", " ")
                .Replace("(all-in-one)", "")
                .Trim()
                .Replace(' ', '-');

            while (slug.Contains("--", StringComparison.Ordinal))
            {
                slug = slug.Replace("--", "-", StringComparison.Ordinal);
            }

            map.TryAdd(entry.Href.TrimEnd('/'), slug.TrimEnd('-'));
        }

        return map;
    }

    public static void MapAiDocs(this WebApplication app)
    {
        var root = ResolveDocsRoot(app.Environment);

        app.MapMethods("/llms.txt", Verbs, () => Serve(root, "llms.txt", Plain));

        // Friendlier aliases for the same file, so a prompt can name /docs rather than
        // a convention filename. /llms.txt stays for crawlers that look for it.
        foreach (var alias in new[] { "/docs", "/reference" })
        {
            app.MapMethods(alias, Verbs, () => Serve(root, "llms.txt", Plain));
        }
        app.MapMethods("/llms-full.txt", Verbs, () => Serve(root, "llms-full.txt", Plain));

        app.MapMethods("/sitemap.xml", Verbs, (HttpRequest req) => Sitemap(root, req));

        // A bare /ai serves the index, so the shortest guess still lands.
        app.MapMethods("/ai", Verbs, () => Serve(root, Path.Combine("ai", "index.md"), Plain));

        // Any generated page under /ai, including /ai/components/gup-button.md.
        app.MapMethods("/ai/{**path}", Verbs, (string? path) =>
        {
            path = string.IsNullOrWhiteSpace(path) ? "index.md" : path;

            if (!path.EndsWith(".md", StringComparison.OrdinalIgnoreCase))
            {
                path += ".md";
            }

            return Serve(root, Path.Combine("ai", path), Plain);
        });
    }

    /// Lists the demo routes and every generated markdown page, so a crawler finds
    /// the markdown as well as the pages.
    private static IResult Sitemap(string? root, HttpRequest req)
    {
        var origin = $"{req.Scheme}://{req.Host}";

        var urls = new List<string> { "/", "/llms.txt", "/llms-full.txt", "/ai/index.md" };
        urls.AddRange(Components.DemoNav.AllEntries.Select(e => e.Href));

        if (root is not null)
        {
            var aiDir = Path.Combine(root, "ai");
            if (Directory.Exists(aiDir))
            {
                urls.AddRange(Directory
                    .EnumerateFiles(aiDir, "*.md", SearchOption.AllDirectories)
                    .Select(f => "/ai/" + Path.GetRelativePath(aiDir, f).Replace('\\', '/')));
            }
        }

        var sb = new StringBuilder();
        sb.AppendLine("""<?xml version="1.0" encoding="UTF-8"?>""");
        sb.AppendLine("""<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">""");
        foreach (var url in urls.Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(u => u, StringComparer.Ordinal))
        {
            sb.AppendLine($"  <url><loc>{origin}{url}</loc></url>");
        }

        sb.AppendLine("</urlset>");

        return Results.Text(sb.ToString(), "application/xml; charset=utf-8");
    }

    private static IResult Serve(string? root, string relative, string contentType)
    {
        if (root is null)
        {
            return Results.Text(
                "The AI reference has not been generated.\nRun: dotnet run --project tools/AiDocsGen\n",
                Plain, statusCode: StatusCodes.Status404NotFound);
        }

        var full = Path.GetFullPath(Path.Combine(root, relative));

        // Keep traversal inside the docs root.
        if (!full.StartsWith(Path.GetFullPath(root), StringComparison.OrdinalIgnoreCase) || !File.Exists(full))
        {
            return Results.Text(
                $"Not found: /{relative.Replace('\\', '/')}\n\nStart at /llms.txt or /ai/index.md.\n",
                Plain, statusCode: StatusCodes.Status404NotFound);
        }

        return Results.Text(File.ReadAllText(full, Encoding.UTF8), contentType);
    }

    /// The docs ship beside the app when published; when running from the repo they
    /// sit at the solution root.
    private static string? ResolveDocsRoot(IWebHostEnvironment env)
    {
        var candidates = new[]
        {
            Path.Combine(env.ContentRootPath, "docs"),
            Path.Combine(env.ContentRootPath, "..", "docs"),
        };

        return candidates
            .Select(Path.GetFullPath)
            .FirstOrDefault(p => File.Exists(Path.Combine(p, "llms.txt")));
    }
}
