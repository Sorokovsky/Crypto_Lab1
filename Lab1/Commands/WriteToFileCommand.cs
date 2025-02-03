using Lab1.Utils;

namespace Lab1.Commands;

public class WriteToFileCommand : BaseCommand
{
    public override string Title { get; set; } = "Записати у файл";
    public override void Invoke()
    {
        IFileService filesService = new FilesService();
        Console.Write("Введіть назву файла: ");
        var name = Console.ReadLine() ?? string.Empty;
        Console.Write("Введіть текст для запису: ");
        var text = Console.ReadLine() ?? string.Empty;
        filesService.WriteFile($"{name}.txt", text);
    }
}