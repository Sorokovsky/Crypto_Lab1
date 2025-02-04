using Lab1.Crypto;

namespace Lab1.Utils;

public static class EncryptorSource
{
    public static (IEncryptor encryptor, object key) Choose()
    {
        var alphabet = Locale.Choose();
        Console.WriteLine("Виберіть метод шифрування.");
        Console.WriteLine("1-Шифр Цезаря.");
        Console.WriteLine("2-Шифр Тритеміуса.");
        Console.Write(">> ");
        int variant = int.Parse(Console.ReadLine() ?? string.Empty);
        switch (variant)
        {
            case 1:
            {
                return GetCezar(alphabet);
            }
            case 2:
            {
                return GetTrithemius(alphabet);
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

    public static (TrithemiusEncryptor encryptor, object key) GetTrithemius(string alphabet)
    {
        Console.WriteLine("Виберіть тип ключа.");
        Console.WriteLine("1-Лінійне рівняння.");
        Console.WriteLine("2-Нелінійне рівняння.");
        Console.WriteLine("3-Гасло.");
        Console.Write(">> ");
        var variant = int.Parse(Console.ReadLine() ?? string.Empty);
        object key;
        switch (variant)
        {
            case 1:
            {
                key = GetConstants(2);
                break;
            }
            case 2:
            {
                key = GetConstants(3);
                break;
            }
            case 3:
            {
                key = GetMottor(alphabet);
                break;
            }
            default:
            {
                throw new Exception("Відповідь не розпізнано.");
            }
        }

        return (new TrithemiusEncryptor(alphabet), key);
    }

    private static string GetMottor(string alphabet)
    {
        Console.Write("Ведіть гасло: ");
        var mottor = Console.ReadLine() ?? string.Empty;
        var canBe = mottor.Any(x => alphabet.Contains(x.ToString().ToUpper().ToString()));
        if (canBe == false)
        {
            throw new Exception("Хочаб один символ має бути у вибраній абетці.");
        }

        return mottor;
    }

    public static int[] GetConstants(int count)
    {
        var result = new int[count]; 
        for (int i = 0; i < count; i++)
        {
            if(i == 0) Console.Write("Введіть A: ");
            if(i == 1) Console.Write("Введіть B: ");
            if(i == 2) Console.Write("Введіть C: ");
            result[i] = (int.Parse(Console.ReadLine() ?? string.Empty));
        }

        return result;
    }
}