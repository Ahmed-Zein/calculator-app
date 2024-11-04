using CalculatorApp.IServices;

namespace CalculatorApp.Services.Commands;

public class CloseCommand : ICommand
{
    public const string Key = "bye";

    public void Invoke()
    {
        Environment.Exit(0);
    }
}

public class ClearCommand : ICommand
{
    public const string Key = "clear";

    public void Invoke()
    {
        Console.Clear();
    }
}