using Lab1.Utils;

namespace Lab1.Commands;

public class ReadFromFileCommand : BaseCommand
{
    public override string Title { get; set; } = "Читати з файлу";
    public override void Invoke()
    {
        Console.WriteLine("Введіть назву файлу.");
        var name = Console.ReadLine() ?? string.Empty;
        IFileService filesService = new FilesService();
        var text = filesService.ReadFile($"{name}.txt");
        Console.WriteLine($"Зміст файлу {name}: ");
        Console.WriteLine(text);
    }
}