using Lab1.Crypto;
using Lab1.Utils;

namespace Lab1.Commands;

public class EncryptCommand : BaseCommand
{
    public override string Title { get; set; } = "Зашифрувати";
    public override void Invoke()
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

        Console.Write("Введіть ключ шифрування: ");
        var key = int.Parse(Console.ReadLine() ?? string.Empty);
        var alphabet = Locale.Choose();
        IEncryptor encryptor = new CezarEncryptor(alphabet);
        Console.WriteLine(encryptor.Encrypt(text, key));
    }
}