using CalculatorApp.Services;

namespace CalculatorApp;

public static class CalculatorApp
{
    public static void Main(string[] args)
    {
        var commandRegistry = new CommandRegistry();
        var commandExecutor = new CommandExecutor(commandRegistry);
        var calculator = new Calculator(commandExecutor);
        var repl = new Repl(calculator);

        repl.Run();
    }
}