using System.Reflection;

namespace Lab1.Utils;

public static class Alphabets
{
    public static readonly Dictionary<string, string> All = GetAll();

    public static string Ukr { get; } = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";

    public static string En { get; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private static Dictionary<string, string> GetAll()
    { 
        return typeof(Alphabets)
            .GetProperties(BindingFlags.Static | BindingFlags.Public)
            .Where(x => x.PropertyType == typeof(string))
            .ToDictionary(x => x.Name, x => ((string)x.GetValue(null) ?? string.Empty));
    }
}