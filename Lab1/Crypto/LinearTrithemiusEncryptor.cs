namespace Lab1.Crypto;

public class LinearTrithemiusEncryptor : IEncryptor<List<int>>
{
    public string Alphabet { get; init; }

    public LinearTrithemiusEncryptor(string alphabet)
    {
        Alphabet = alphabet;
    }
    
    public string Encrypt(string input, List<int> key)
    {
        var (a, b) = GetAndValidateKey(key);
        var result = string.Empty;
        foreach (var letter in input)
        {
            var index = Alphabet.IndexOf(letter.ToString().ToUpper().First());
            if (index == -1) result += letter;
            else
            {
                var capLetter = Alphabet[index];
                var isCap = capLetter == letter;
                var step = a * index + b;
                var newIndex = (index + step + Alphabet.Length) % Alphabet.Length;
                var newLetter = Alphabet[newIndex];
                if (isCap == false) newLetter = newLetter.ToString().ToLower().First();
                result += newLetter;
            }
        }

        return result;
    }

    public string Decrypt(string input, List<int> key)
    {
        var (a, b) = GetAndValidateKey(key);
        var result = string.Empty;
        var reversedA = Reverse(a, Alphabet.Length);
        foreach (var letter in input)
        {
            var index = Alphabet.IndexOf(letter.ToString().ToUpper().First());
            if (index == -1) result += letter;
            else
            {
                var capLetter = Alphabet[index];
                var isCap = capLetter == letter;
                var newIndex = (reversedA * (index - b)) % Alphabet.Length; 
                var newLetter = Alphabet[newIndex];
                if (isCap == false) newLetter = newLetter.ToString().ToLower().First();
                result += newLetter;
            }
        }

        return result;
    }

    private static (int a, int b) GetAndValidateKey(List<int> key)
    {
        if (key.Count != 2) throw new ArgumentException("Ключ має мати дві константи.");
        return (key.First(), key[1]);
    }

    private static int Reverse(int number, int mod)
    {
        var i = 0;
        var result = 0;
        while (result != 1)
        {
            i++;
            result = (number * i) % mod;
        }
        return i;
    }
}