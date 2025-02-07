namespace Lab1.Crypto;

public class MottorTrithemiusEncryptor : IEncryptor<string>
{
    public MottorTrithemiusEncryptor(string alphabet)
    {
        Alphabet = alphabet;
    }

    public string Alphabet { get; init; }
    
    public string Encrypt(string input, string key)
    {
        var mottor = ValidateAndGetKey(key, input.Length);
        var result = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            var letter = input[i];
            var index = Alphabet.IndexOf(char.ToUpper(letter));
            if (index == -1) result += letter;
            else
            {
                var isCap = char.IsUpper(letter);
                var mottoLetter = mottor[i];
                var mottoIndex = Alphabet.IndexOf(char.ToUpper(mottoLetter));
                if (mottoIndex == -1) result += letter;
                else
                {
                    var newIndex = (index + mottoIndex) % Alphabet.Length;
                    var newLetter = Alphabet[newIndex];
                    newLetter = isCap ? newLetter : char.ToLower(newLetter);
                    result += newLetter;
                }
            }
        }

        return result;
    }

    public string Decrypt(string input, string key)
    {
        var mottor = ValidateAndGetKey(key, input.Length);
        var result = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            var letter = input[i];
            var index = Alphabet.IndexOf(char.ToUpper(letter));
            if (index == -1) result += letter;
            else
            {
                var isCap = char.IsUpper(letter);
                var mottoLetter = mottor[i];
                var mottoIndex = Alphabet.IndexOf(mottoLetter);
                if (mottoIndex == -1) result += letter;
                else
                {
                    var newIndex = (index - mottoIndex + Alphabet.Length) % Alphabet.Length;
                    var newLetter = Alphabet[newIndex];
                    newLetter = isCap ? newLetter : char.ToLower(newLetter);
                    result += newLetter;
                }
            }
        }

        return result;
    }

    private string ValidateAndGetKey(string key, int needCount)
    {
        var alphabetKey = key
            .Where(letter => Alphabet.Contains(char.ToUpper(letter)))
            .Aggregate(string.Empty, (current, letter) => current + letter);
        if (string.IsNullOrEmpty(alphabetKey))
        {
            throw new ArgumentException("Гасло не має бути порожнім.");
        }

        if (needCount < 0)
        {
            throw new ArgumentException("Довжина ряжка не має бути меньше 0.");
        }

        var length = alphabetKey.Length;
        var i = 0;
        while (alphabetKey.Length < needCount)
        {
            var letter = alphabetKey[i];
            alphabetKey += letter;
            i++;
            if (i >= length) i = 0;
        }

        if (alphabetKey.Length > needCount)
        {
            alphabetKey =  alphabetKey[..needCount];
        }

        return alphabetKey;
    }
}