using Lab1.Crypto;

namespace Lab1.Utils;

public static class EncryptorSource
{
    public static (dynamic encryptor, dynamic key) Choose()
    {
        var alphabet = Locale.Choose();
        Console.WriteLine("Виберіть метод шифрування.");
        Console.WriteLine("1-Шифр Цезаря.");
        Console.WriteLine("2-Лінійний шифр Тритеміуса.");
        Console.WriteLine("3-Нелінійний шифр Тритеміуса.");
        Console.WriteLine("4-Шифр Тритеміуса за гаслом.");
        Console.Write(">> ");
        var variant = int.Parse(Console.ReadLine() ?? string.Empty);
        return variant switch
        {
            1 => GetCezar(alphabet),
            2 => GetLinearEncryptor(alphabet),
            3 => GetNotLinearEncryptor(alphabet),
            4 => GetMottoEncryptor(alphabet),
            _ => throw new Exception("Відповідь не розпізнано.")
        };
    }

    private static (IEncryptor<int> encryptor, int key) GetCezar(string alphabet)
    {
        Console.Write("Введіть ключ: ");
        int key = int.Parse(Console.ReadLine() ?? string.Empty);
        IEncryptor<int> encryptor = new CezarEncryptor(alphabet);
        return (encryptor, key);
    }

    private static (IEncryptor<List<int>> encryptor, List<int> key) GetLinearEncryptor(string alphabet)
    {
        IEncryptor<List<int>> encryptor = new LinearTrithemiusEncryptor(alphabet);
        return (encryptor, GetConstants(2));
    }
    
    private static (IEncryptor<List<int>> encryptor, List<int> key) GetNotLinearEncryptor(string alphabet)
    {
        return (new NotLinearTrithemiusEncryptor(alphabet), GetConstants(3));
    }
    
    private static (IEncryptor<string> encryptor, string key) GetMottoEncryptor(string alphabet)
    {
        Console.Write("Введіть гасло: ");
        var motto = Console.ReadLine() ?? string.Empty;
        return (new MottorTrithemiusEncryptor(alphabet), motto);
    }

    private static List<int> GetConstants(int count)
    {
        if (count < 0) throw new ArgumentException("Кількісь констант не може бути від'ємна.");
        var result = new List<int>();
        for (var i = 0; i < count; i++)
        {
            var letter = (char)('A' + i);
            Console.Write($"Введіть константу {letter}: ");
            result.Add(int.Parse(Console.ReadLine() ?? string.Empty));
        }

        return result;
    }
}