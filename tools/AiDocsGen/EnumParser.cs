using System.Text.RegularExpressions;

namespace AiDocsGen;

public static partial class EnumParser
{
    [GeneratedRegex(@"public\s+enum\s+(?<name>\w+)\s*\{(?<body>[^}]*)\}", RegexOptions.Singleline)]
    private static partial Regex EnumRx();

    public static List<EnumDoc> Parse(string source, XmlDocs xml, string ns = "GUPBlazor.Components")
    {
        var result = new List<EnumDoc>();

        foreach (var m in EnumRx().Matches(source).Cast<Match>())
        {
            var name = m.Groups["name"].Value;
            var members = new List<(string, string?)>();

            foreach (var raw in m.Groups["body"].Value.Split(','))
            {
                var line = raw.Trim();
                if (line.Length == 0)
                {
                    continue;
                }

                // Drop /// lines and comments, keep the identifier.
                var ident = line.Split('\n')
                    .Select(l => l.Trim())
                    .LastOrDefault(l => l.Length > 0 && !l.StartsWith("//", StringComparison.Ordinal));

                if (ident is null)
                {
                    continue;
                }

                ident = Regex.Replace(ident, @"\s*=.*$", "").Trim();
                if (!Regex.IsMatch(ident, @"^\w+$"))
                {
                    continue;
                }

                members.Add((ident, xml.Field($"{ns}.{name}", ident)));
            }

            result.Add(new EnumDoc(name, xml.Type($"{ns}.{name}"), members));
        }

        return result;
    }
}
