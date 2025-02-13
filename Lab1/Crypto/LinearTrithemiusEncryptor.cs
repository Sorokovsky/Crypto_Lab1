namespace Lab1.Crypto;

public class LinearTrithemiusEncryptor : IEncryptor<List<int>>
{
    public string Alphabet { get; init; }

    public LinearTrithemiusEncryptor(string alphabet)
    {
        Alphabet = alphabet;
    }

    public string Encrypt(string input, List<int> key) => GetNewString(input, key, false);


    public string Decrypt(string input, List<int> key) => GetNewString(input, key, true);

    private static (int a, int b) GetAndValidateKey(List<int> key)
    {
        if (key.Count != 2) throw new ArgumentException("Ключ має містити два параметри (a, b).");
        return (key.First(), key[1]);
    }
    
    private string GetNewString(string input, List<int> key, bool reversed) 
    {
        var (a, b) = GetAndValidateKey(key);
        var result = string.Empty;

        for (var i = 0; i < input.Length; i++)
        {
            var letter = input[i];
            var index = Alphabet.IndexOf(char.ToUpper(letter));
            if (index == -1) result += letter;
            else
            {
                var isCap = char.IsUpper(letter);
                var step = a * i + b;
                if (reversed) step = -step;
                var newIndex = (index + step + Alphabet.Length) % Alphabet.Length;
                var newLetter = Alphabet[(newIndex) % Alphabet.Length];
                result += isCap ? newLetter : char.ToLower(newLetter);
            }
        }

        return result;
    }
}
