using Lab1.Crypto;
using Lab1.Utils;

namespace Lab1;

public static class Program
{
    public static void Main()
    {
        while (true)
        {
            try
            {
                var operation = ChooseOperation();
                switch (operation)
                {
                    case 0:
                    {
                        Environment.Exit(0);
                        break;
                    }
                    case 1:
                    {
                        Console.WriteLine("Ввведіть назву файлу.");
                        var path = Console.ReadLine() ?? string.Empty;
                        var files = new FilesService();
                        files.WriteFile($"${path}.txt", "");
                        Console.WriteLine("Файл створено.");
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Ввведіть назву файлу.");
                        var path = Console.ReadLine() ?? string.Empty;
                        var files = new FilesService();
                        Console.WriteLine("Введіть текст для запису: ");
                        var data = Console.ReadLine() ?? string.Empty;
                        files.WriteFile($"{path}.txt", data);
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Введіть назву файлу.");
                        var path = Console.ReadLine() ?? string.Empty;
                        var files = new FilesService();
                        var text = files.ReadFile($"{path}.txt");
                        Console.WriteLine($"Вміст файлу {path}");
                        Console.WriteLine(text);
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Введіть текст: ");
                        var text = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine("Введіть ключ: ");
                        var key = int.Parse(Console.ReadLine() ?? string.Empty);
                        var encryptor = new CezarEncryptor(Alphabets.EN);
                        var encrypted = encryptor.Encrypt(text, key);
                        Console.WriteLine($"Зашифровано: {encrypted}");
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                continue;
            }
        }
    }

    private static int ChooseOperation()
    {
        Console.WriteLine("Будь ласка, оберіть операцію.");
        Console.WriteLine("0-Вийти.");
        Console.WriteLine("1-Створити файл.");
        Console.WriteLine("2-Записати у файл.");
        Console.WriteLine("3-Читати з файлу.");
        Console.WriteLine("4-Зашифрувати.");
        Console.WriteLine("5-Дешифрувати.");
        return int.Parse(Console.ReadLine() ?? string.Empty);
    }
}
