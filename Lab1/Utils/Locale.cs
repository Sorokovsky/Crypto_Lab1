namespace Lab1.Utils;

public static class Locale
{
    public static string Choose()
    {
        Console.WriteLine("Виберіть мову: ");
        foreach (var language in Alphabets.All.Keys)
        {
            Console.WriteLine(language);
        }

        Console.Write(">> ");
        var choose = Console.ReadLine() ?? string.Empty;
        var locale = Alphabets.All.GetValueOrDefault(choose);
        if (locale == null) throw new InvalidOperationException("Відповіть не розпізнано.");
        return locale;
    }
}