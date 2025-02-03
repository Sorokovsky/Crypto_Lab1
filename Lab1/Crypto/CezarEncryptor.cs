namespace Lab1.Crypto;

public class CezarEncryptor : IEncryptor
{
    public string Alphabet { get; set; }

    public CezarEncryptor(string alphabet)
    {
        Alphabet = alphabet;
    }

    public string Encrypt(string input, int key)
    {
        if (key <= 0 || key > Alphabet.Length)
        {
            throw new ArgumentException($"Ключ має бути в діапазоні 0-{Alphabet.Length}");
        }

        var result = string.Empty;
        foreach (var  letter in input)
        {
            var index = Alphabet.IndexOf(letter.ToString().ToUpper().First());
            if (index == -1) result += letter;
            else
            {
                var newLetter = Alphabet[(index + key + Alphabet.Length) % Alphabet.Length];
                result += newLetter;
            }
        }

        return result;
    }
}