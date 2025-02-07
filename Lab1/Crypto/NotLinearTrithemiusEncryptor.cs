namespace Lab1.Crypto;

public class NotLinearTrithemiusEncryptor : IEncryptor<List<int>>
{
    public NotLinearTrithemiusEncryptor(string alphabet)
    {
        Alphabet = alphabet;
    }

    public string Alphabet { get; init; }
    
    public string Encrypt(string input, List<int> key)
    {
        var (a, b, c) = ValidateAndGetConstants(key);
        var result = string.Empty;
        for (var i = 0; i < input.Length; i++)
        {
            var letter = input[i];
            var index = Alphabet.IndexOf(char.ToUpper(letter));
            if (index == -1) result += letter;
            else
            {
                var isCap = char.IsUpper(letter);
                var step = (int)Math.Pow(a, 2) + b * i + c;
                var newIndex = (index + step + Alphabet.Length) % Alphabet.Length;
                var newLetter = Alphabet[newIndex];
                result += isCap ? newLetter : char.ToLower(newLetter);
            }
        }

        return result;
    }

    public string Decrypt(string input, List<int> key)
    {
        var (a, b, c) = ValidateAndGetConstants(key);
        var result = string.Empty;
        for (var i = 0; i < input.Length; i++)
        {
            var letter = input[i];
            var index = Alphabet.IndexOf(char.ToUpper(letter));
            if (index == -1) result += letter;
            else
            {
                var isCap = char.IsUpper(letter);
                var step = (int)Math.Pow(a, 2) + b * i + c;
                var newIndex = (index - step + Alphabet.Length) % Alphabet.Length;
                var newLetter = Alphabet[newIndex];
                result += isCap ? newLetter : char.ToLower(newLetter);
            }
        }

        return result;
    }

    private static (int a, int b, int c) ValidateAndGetConstants(List<int> key)
    {
        if (key.Count != 3) throw new ArgumentException("Ключ має містити три параметри (a, b, c)");
        return (key.First(), key[1], key[2]);
    }
}