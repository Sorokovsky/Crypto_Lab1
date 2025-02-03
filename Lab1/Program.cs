using Lab1.Commands;

namespace Lab1;

public static class Program
{
    public static void Main()
    {
        var context = new CommandContext();
        context.Add(
            new ExitCommands(),
            new WriteToFileCommand(),
            new ReadFromFileCommand(),
            new EncryptCommand()
            );
        context.Loop();
    }
}
