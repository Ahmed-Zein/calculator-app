namespace CalculatorApp.Services;

public class Calculator(CommandExecutor commandExecutor)
{
    private  CommandExecutor CommandExecutor { get; } = commandExecutor;

    public string Eval(string line)
    {
        try
        {
            CommandExecutor.Execute(line);
            return "";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

}