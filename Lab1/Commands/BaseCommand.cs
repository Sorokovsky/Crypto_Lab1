namespace Lab1.Commands;

public abstract class BaseCommand
{
    public int Number { get; set; }
    
    public abstract string Title { get; set; }

    public abstract void Invoke();
}