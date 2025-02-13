using Lab1.Crypto;
using Lab1.Utils;

namespace Lab1.Commands;

public class HackTextCommand : BaseCommand
{
    public override string Title { get; set; } = "Взломати шифр";
    public override void Invoke()
    {
        var text = TextSource.GetText();
        var locale = Locale.Choose();
        IEncryptor<int> encryptor = new CezarEncryptor(locale);
        var statistics = new Statistics();
        statistics.Make(text);
        var a = Alphabets.All.First(x => x.Value.Equals(locale)).Key;
        var popular = statistics.Popular();
        var pop = Frequencies.All[a].Last().Key;
        var freqIndex = locale.IndexOf(pop);
        var popIndex = locale.IndexOf(popular);
        var key = Math.Abs(freqIndex - popIndex);
        var result = encryptor.Decrypt(text, key);
        Console.WriteLine(result);
    }
}