namespace Lab1.Crypto;

public class CezarEncryptor : IEncryptor
{
    public string Alphabet { get; init; }

    public CezarEncryptor(string alphabet)
    {
        Alphabet = alphabet;
    }

    public string Encrypt(string input, object key)
    {
        if (key.GetType() != typeof(int))
        {
            throw new ArgumentException("Ключ має бути числом.");
        }

        var step = (int)key;
        if (step <= 0 || step > Alphabet.Length)
        {
            throw new ArgumentException($"Ключ має бути в діапазоні 1-{Alphabet.Length}");
        }

        var result = string.Empty;
        foreach (var  letter in input)
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

    public string Decrypt(string input, object key)
    {
        if (key.GetType() != typeof(int))
        {
            throw new ArgumentException("Ключ має бути числом.");
        }

        var step = (int)key;
        if (step <= 0 || step > Alphabet.Length)
        {
            throw new ArgumentException($"Ключ має бути в діапазоні 1-{Alphabet.Length}");
        }
        var result = string.Empty;
        foreach (var letter in input)
        {
            var index = Alphabet.IndexOf(letter.ToString().ToUpper().First());
            if (index == -1) result += letter;
            else
            {
                var isCap = letter == Alphabet[index];
                var newLetter = Alphabet[(index - step + Alphabet.Length) % Alphabet.Length];
                if (isCap == false) newLetter = newLetter.ToString().ToLower().First();
                result += newLetter;
            }
        }

        return result;
    }
}