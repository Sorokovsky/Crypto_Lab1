namespace Lab1.Crypto;

public class Statistics
{
    private readonly Dictionary<char, int> _letterCounts = new();

    public void Make(string text)
    {
        foreach (var letter in text)
        {
            if (!_letterCounts.TryAdd(letter, 1))
            {
                _letterCounts[letter]++;
            }
        }
    }

    private IReadOnlyDictionary<char, int> PopularLetters => _letterCounts
        .OrderBy(x => x.Value)
        .ToDictionary(x => x.Key, x => x.Value);

    public char Popular(int position = 0)
    {
        return PopularLetters.Skip(position).First().Key;
    }
}