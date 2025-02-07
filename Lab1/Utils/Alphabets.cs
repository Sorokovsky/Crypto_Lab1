using System.Reflection;

namespace Lab1.Utils;

public static class Alphabets
{

    public static string Ukr { get; private set; } = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";

    public static string En { get; private set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    public static Dictionary<string, string> All { get; } = GetAll();

    private static Dictionary<string, string> GetAll()
    {
        var properties = typeof(Alphabets)
            .GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
        var result = properties 
            .Where(x => x.PropertyType == typeof(string))
            .ToDictionary(x => x.Name, x => (string)x.GetValue(null)!);
        return result;
    }
}