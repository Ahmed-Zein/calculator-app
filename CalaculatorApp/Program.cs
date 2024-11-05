using CalculatorApp.Services;
using CalculatorApp.Services.Commands;

namespace CalculatorApp;

public static class CalculatorApp
{
    public static void Main(string[] args)
    {
        var commandRegistry = new CommandRegistry();
        var commandExecutor = new CommandExecutor(commandRegistry);
        
        var enginRules = new ArithmeticEnginRules();
        var arithmeticCompute = new Engin(enginRules);
        var tokenizer = new Tokenizer(enginRules);
        
        var calculator = new Calculator(commandExecutor, tokenizer, arithmeticCompute);
        var repl = new Repl(calculator);

        repl.Run();
    }
}