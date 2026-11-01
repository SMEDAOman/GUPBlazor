using System.Xml.Linq;

namespace AiDocsGen;

/// Summaries from the compiler-generated GUPBlazor.xml, keyed by member id.
public sealed class XmlDocs
{
    private readonly Dictionary<string, string> _summaries = new(StringComparer.Ordinal);

    public static XmlDocs Load(string? path)
    {
        var docs = new XmlDocs();
        if (path is null || !File.Exists(path))
        {
            return docs;
        }

        var doc = XDocument.Load(path);
        foreach (var member in doc.Descendants("member"))
        {
            var name = member.Attribute("name")?.Value;
            var summary = member.Element("summary");
            if (name is null || summary is null)
            {
                continue;
            }

            var text = RazorParser.CleanXmlDoc(summary.ToString());
            if (text.Length > 0)
            {
                docs._summaries[name] = text;
            }
        }

        return docs;
    }

    public string? Type(string fullName) =>
        _summaries.GetValueOrDefault($"T:{fullName}");

    public string? Field(string fullName, string member) =>
        _summaries.GetValueOrDefault($"F:{fullName}.{member}");

    public string? Property(string fullName, string member) =>
        _summaries.GetValueOrDefault($"P:{fullName}.{member}");

    public string? Event(string fullName, string member) =>
        _summaries.GetValueOrDefault($"E:{fullName}.{member}");

    /// Methods are keyed with their parameter list (M:Type.Name(System.String)),
    /// so match on the name and take the first overload.
    public string? Method(string fullName, string member)
    {
        var prefix = $"M:{fullName}.{member}";
        return _summaries.FirstOrDefault(kv =>
            kv.Key.StartsWith(prefix + "(", StringComparison.Ordinal) ||
            kv.Key == prefix).Value;
    }
}
