namespace Lab1.Utils;

public class FilesService : IFileService
{
    public string GetPath(string path)
    {
        return Path.Combine(Environment.CurrentDirectory, path);
    }
    
    public string ReadFile(string path)
    {
        var filePath = GetPath(path);
        if (File.Exists(filePath) == false)
        {
            throw new ArgumentException($"Файл {path} не знайдено.");
        }

        using var stream = File.OpenRead(filePath);
        using var reader = new StreamReader(stream);
        var data = reader.ReadToEnd();
        return data;
    }

    public void WriteFile(string path, string data)
    {
        var filePath = GetPath(path);
        if (File.Exists(filePath))
        {
            Console.Write("Файл існує, продовжити(y-так, n-ні): ");
            var result = Console.ReadLine() ?? string.Empty;
            if(result == "n") return;
            if (result != "y")
            {
                throw new Exception("Відповідь не розпізнано.");
            }
        }

        var mode = File.Exists(filePath) ? FileMode.Truncate : FileMode.Create;
        using var stream = File.Open(filePath, mode);
        using var writer = new StreamWriter(stream);
        writer.Write(data);
    }
}