namespace Lab1.Crypto;

public class TrithemiusEncryptor : IEncryptor
{
    public string Alphabet { get; init; }

    public TrithemiusEncryptor(string alphabet)
    {
        Alphabet = alphabet;
    }

    public string Encrypt(string input, object key) => GetNewString(input, key);

    public string Decrypt(string input, object key) => GetNewString(input, key, true);

    private int CalculateStep(int[] numbers, int currentIndex)
    {
        if (numbers.Length == 2)
        {
            var a = numbers.First();
            var b = numbers.ElementAt(1);
            return a * currentIndex + b;
        }

        if (numbers.Length == 3)
        {
            return ((int)Math.Pow(numbers.First(), 2)) + numbers.ElementAt(1) * currentIndex + numbers.ElementAt(2);
        }

        throw new ArgumentException("Кількість констант має бути 2 чи 3.");
    }

    private string GetNewString(string input, object key, bool reverse = false)
    {
        var result = string.Empty;
        if (key is int[] numbers)
        {
            foreach (var letter in input)
            {
                var index = Alphabet.IndexOf(letter.ToString().ToUpper().First());
                if (index == -1)
                {
                    result += letter;
                }
                else
                {
                    var capLetter = Alphabet.ElementAt(index);
                    var isCap = capLetter == letter;
                    var step = CalculateStep(numbers, index);
                    if (reverse) step = -step;
                    var newIndex = (index + step + Alphabet.Length) % Alphabet.Length;
                    var newLetter = Alphabet[newIndex];
                    if (isCap == false) newLetter = newLetter.ToString().ToLower().First();
                    result += newLetter;
                }
            }
        }

        if (key is string motto)
        {
            var mottoLength = motto.Length;
            var i = 0;
            foreach (var letter in input)
            {
                var index = Alphabet.IndexOf(letter.ToString().ToUpper().First());
                if (index == -1)
                {
                    result += letter;
                }
                else
                {
                    var capLetter = Alphabet[index];
                    var isCap = capLetter == letter;
                    if (i >= mottoLength) i = 0;
                    var mottoLetter = motto[i];
                    while (Alphabet.Contains(mottoLetter.ToString().ToLower().First()) == false)
                    {
                        i++;
                        if (i >= mottoLength) i = 0;
                    }

                    var mottoIndex = Alphabet.IndexOf(motto[i]);
                    var step = mottoIndex * (reverse ? -1 : 1);
                    var newIndex = (index + step + Alphabet.Length) % Alphabet.Length;
                    var newLetter = Alphabet[newIndex];
                    if (isCap == false) newLetter = newLetter.ToString().ToLower().First();
                    result += newLetter;
                    i++;
                }
            }
        }

        return result;
    }
}