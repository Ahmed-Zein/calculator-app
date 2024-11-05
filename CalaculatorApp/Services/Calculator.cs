using CalculatorApp.DTO;
using CalculatorApp.IServices;
using CalculatorApp.Services.Commands;

namespace CalculatorApp.Services;

public class Calculator(CommandExecutor commandExecutor, ITokenizer tokenizer, IEngin engin)
{
    private CommandExecutor CommandExecutor { get; } = commandExecutor;
    private ITokenizer Tokenizer { get; } = tokenizer;
    private IEngin Engin { get; } = engin;

    private readonly HashSet<char> _operators = ['*', '/', '+', '-'];

    public string Eval(string line)
    {
        var commandResult = CommandExecutor.Execute(line);
        if (commandResult.Success)
        {
            return "";
        }

        try
        {
            var tokens = Tokenizer.Tokenize(line);
            var calculatorResult = Engin.Compute(tokens);
            return calculatorResult.Message;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}