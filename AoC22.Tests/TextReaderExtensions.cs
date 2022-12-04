namespace AoC22.Tests;

public static class TextReaderExtensions
{
    public static string[] GetLinesFromReader(this TextReader tr)
    {
        var lines = new List<string>();
        string? line = string.Empty;
        while (line != null)
        {
            lines.Add(line);
            line = tr.ReadLine();
        }

        return lines.ToArray()[1..];
    }
}