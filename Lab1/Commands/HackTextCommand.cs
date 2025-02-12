using Lab1.Crypto;
using Lab1.Utils;

namespace Lab1.Commands;

public class HackTextCommand : BaseCommand
{
    public override string Title { get; set; } = "Взломати шифр.";
    public override void Invoke()
    {
        var text = TextSource.GetText();
        var locale = Locale.Choose();
        IEncryptor<int> encryptor = new CezarEncryptor(locale);
        for (var i = 1; i <= locale.Length; i++)
        {
            var result = encryptor.Decrypt(text, i);
            Console.WriteLine($"З ключем: {i}");
            Console.WriteLine($"Результат: {result}");
        }
    }
}