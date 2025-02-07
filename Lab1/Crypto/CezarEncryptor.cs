namespace Lab1.Crypto;

public class CezarEncryptor : IEncryptor<int>
{
    public string Alphabet { get; init; }

    public CezarEncryptor(string alphabet)
    {
        Alphabet = alphabet;
    }

    public string Encrypt(string input, int key) => GetNewText(input, GetAndValidateKey(key));

    public string Decrypt(string input, int key) => GetNewText(input, -GetAndValidateKey(key));

    private int GetAndValidateKey(int key)
    {
            if (key <= 0 || key > Alphabet.Length)
            {
                throw new ArgumentException($"Ключ має бути в діапазоні 1-{Alphabet.Length}");
            }
            return key;
    }

    private string GetNewText(string input, int step)
    {
        var result = string.Empty;
        foreach (var letter in input)
        {
            var index = Alphabet.IndexOf(letter.ToString().ToUpper().First());
            if (index == -1) result += letter;
            else
            {
                var isCap = letter == Alphabet[index];
                var newLetter = Alphabet[(index + step + Alphabet.Length) % Alphabet.Length];
                if (isCap == false) newLetter = newLetter.ToString().ToLower().First();
                result += newLetter;
            }
        }

        return result;
    }
}