namespace Lab1.Commands;

public class CommandContext
{
    private int _currentNumber = 0;
    private readonly List<BaseCommand> _commands = [];

    public CommandContext()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;
    }
    
    public void Loop()
    {
        while (true)
        {
            try
            {
                var operation = ChooseOperation();
                var command = _commands.FirstOrDefault(x => x.Number == operation);
                if (command == null)
                {
                    Console.WriteLine("Опцію не знайдено, спробуйте ще.");
                }
                else
                {
                    command.Invoke();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    public void Add(params BaseCommand[] commands)
    {
        commands.ToList().ForEach(command => command.Number = _currentNumber++);
        _commands.AddRange(commands);
    }

    private int ChooseOperation()
    {
        Console.WriteLine("Виберіть опцію.");
        foreach (var command in _commands)
        {
            Console.WriteLine($"{command.Number}-{command.Title}.");
        }

        Console.Write(">> ");
        return int.Parse(Console.ReadLine() ?? string.Empty);
    }
}