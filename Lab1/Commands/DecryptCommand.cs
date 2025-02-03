using Lab1.Crypto;
using Lab1.Utils;

namespace Lab1.Commands;

public class DecryptCommand : BaseCommand
{
    public override string Title { get; set; } = "Дешифрувати";
    public override void Invoke()
    {
        var text = TextSource.GetText();
        Console.Write("Введіть ключ шифрування: ");
        var key = int.Parse(Console.ReadLine() ?? string.Empty);
        var alphabet = Locale.Choose();
        IEncryptor encryptor = new CezarEncryptor(alphabet);
        Console.WriteLine($"Результат: {encryptor.Decrypt(text, key)}");
    }
}