using Lab1.Utils;

namespace Lab1.Commands;

public class DecryptCommand : BaseCommand
{
    public override string Title { get; set; } = "Дешифрувати";
    public override void Invoke()
    {
        var text = TextSource.GetText();
        var (encryptor, key) = EncryptorSource.Choose();
        TextSource.OutputText(encryptor.Decrypt(text, key));
    }
}