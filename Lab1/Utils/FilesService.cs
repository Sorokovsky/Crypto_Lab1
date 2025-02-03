namespace Lab1.Utils;

public class FilesService : IFileService
{
    public string ReadFile(string path)
    {
        if (File.Exists(path) == false)
        {
            throw new ArgumentException($"Файл {path} не знайдено.");
        }

        using var stream = File.OpenRead(path);
        using var reader = new StreamReader(stream);
        var data = reader.ReadToEnd();
        reader.Close();
        stream.Close();
        return data;
    }

    public void WriteFile(string path, string data)
    {
        var stream = File.OpenWrite(path);
        var writer = new StreamWriter(stream);
        writer.WriteLine(data);
        writer.Close();
        stream.Close();
    }
}