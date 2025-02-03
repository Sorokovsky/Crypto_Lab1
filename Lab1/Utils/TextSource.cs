namespace Lab1.Utils;

public static class TextSource
{
    public static string GetText()
    {
        Console.Write("Текст з файлу (Y-Так, або N-Ні): ");
        var choose = (Console.ReadLine() ?? string.Empty).ToLower();
        string text;
        if (choose == "y")
        {
            Console.Write("Введіть назву файлу: ");
            var fileName = Console.ReadLine() ?? string.Empty;
            IFileService fileService = new FilesService();
            text = fileService.ReadFile($"{fileName}.txt");
        }
        else if (choose == "n")
        {
            Console.Write("Введіть текст: ");
            text = Console.ReadLine() ?? string.Empty;
        }
        else
        {
            throw new InvalidOperationException("Відповідь не розпізнано.");
        }

        return text;
    }
}