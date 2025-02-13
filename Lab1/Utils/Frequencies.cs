namespace Lab1.Utils;

public static class Frequencies
{
    private static IReadOnlyDictionary<char, double> Ukr => new Dictionary<char, double>()
    {
        {'А', 0.072}, {'Б', 0.017}, {'В', 0.052}, {'Г', 0.016}, {'Д', 0.035},
        {'Е', 0.017}, {'Є', 0.008}, {'Ж', 0.009}, {'З', 0.023}, {'И', 0.061},
        {'І', 0.057}, {'Ї', 0.006}, {'Й', 0.008}, {'К', 0.035}, {'Л', 0.036},
        {'М', 0.031}, {'Н', 0.065}, {'О', 0.094}, {'П', 0.029}, {'Р', 0.047},
        {'С', 0.041}, {'Т', 0.055}, {'У', 0.040}, {'Ф', 0.001}, {'Х', 0.012},
        {'Ц', 0.016}, {'Ч', 0.014}, {'Ш', 0.012}, {'Щ', 0.008}, {'Ь', 0.029},
        {'Ю', 0.014}, {'Я', 0.029}
    }
        .OrderBy(x => x.Value)
        .ToDictionary(x => x.Key, x => x.Value);

    private static IReadOnlyDictionary<char, double> En => new Dictionary<char, double>
    {
        {'A', 0.082}, {'B', 0.015}, {'C', 0.028}, {'D', 0.043}, {'E', 0.127},
        {'F', 0.022}, {'G', 0.020}, {'H', 0.061}, {'I', 0.070}, {'J', 0.002},
        {'K', 0.008}, {'L', 0.040}, {'M', 0.024}, {'N', 0.067}, {'O', 0.075},
        {'P', 0.019}, {'Q', 0.001}, {'R', 0.060}, {'S', 0.063}, {'T', 0.091},
        {'U', 0.028}, {'V', 0.010}, {'W', 0.023}, {'X', 0.001}, {'Y', 0.020},
        {'Z', 0.001}
    }
    .OrderBy(x => x.Value)
    .ToDictionary(x => x.Key, x => x.Value);

    public static readonly IReadOnlyDictionary<string, IReadOnlyDictionary<char, double>> All = new Dictionary<string, IReadOnlyDictionary<char, double>>()
    {
        {"En", En},
        {"Ukr", Ukr},
    };
}