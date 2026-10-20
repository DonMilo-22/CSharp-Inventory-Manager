using System.Text;

public static class InventoryCsvExport
{
    public static void Export<T>(IEnumerable<T> rows, string path, Func<T, string[]> columns)
    {
        static string Escape(string value)
        {
            value ??= "";
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }
        var builder = new StringBuilder();
        foreach (var row in rows)
            builder.AppendLine(string.Join(",", columns(row).Select(Escape)));
        File.WriteAllText(path, builder.ToString(), new UTF8Encoding(true));
        Console.WriteLine($"Exported rows to {Path.GetFullPath(path)}");
    }
}
