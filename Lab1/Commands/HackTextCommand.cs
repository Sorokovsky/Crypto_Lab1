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
        var statistics = new Statistics();
        statistics.Make(text);
    }
}