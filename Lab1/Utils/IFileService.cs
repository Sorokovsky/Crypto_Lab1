namespace Lab1.Utils;

public interface IFileService
{
    public string ReadFile(string path);
    
    public void WriteFile(string path, string data);
}