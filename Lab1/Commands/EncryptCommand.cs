using Lab1.Utils;

namespace Lab1.Commands;

public class EncryptCommand : BaseCommand
{
    public override string Title { get; set; } = "Зашифрувати";
    public override void Invoke()
    {
        var text = TextSource.GetText();
        var (encryptor, key) = EncryptorSource.Choose();
        Console.WriteLine($"Результат: {encryptor.Encrypt(text, key)}");
    }
}