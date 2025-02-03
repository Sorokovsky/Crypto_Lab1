namespace Lab1.Commands;

public class ExitCommands : BaseCommand
{
    public override string Title { get; set; } = "Вийти";
    public override void Invoke()
    {
        Environment.Exit(0);
    }
}