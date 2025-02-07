using Lab1.Crypto;

namespace Lab1.Utils;

public static class EncryptorSource
{
    public static (IEncryptor<object> encryptor, object key) Choose()
    {
        var alphabet = Locale.Choose();
        Console.WriteLine("Виберіть метод шифрування.");
        Console.WriteLine("1-Шифр Цезаря.");
        Console.WriteLine("2-Лінійний шифр Тритеміуса.");
        Console.WriteLine("3-Лінійний шифр Тритеміуса.");
        Console.WriteLine("4-Нелінійний шифр Тритеміуса.");
        Console.WriteLine("5-Шифр Тритеміуса за гаслом.");
        Console.Write(">> ");
        int variant = int.Parse(Console.ReadLine() ?? string.Empty);
        switch (variant)
        {
            case 1:
            {
                return ((IEncryptor<object> encryptor, object key))GetCezar(alphabet);
            }
            default:
            {
                throw new Exception("Відповідь не розпізнано.");
            }
        }
    }

    private static (CezarEncryptor encryptor, int key) GetCezar(string alphabet)
    {
        Console.Write("Введіть ключ: ");
        int key = int.Parse(Console.ReadLine() ?? string.Empty);
        return (new CezarEncryptor(alphabet), key);
    }
}