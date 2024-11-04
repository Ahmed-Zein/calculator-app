namespace CalculatorApp.Services;

public interface ICommandExecutor
{
    void Execute(string command);
}

public class CommandExecutor(CommandRegistry commandRegistry) : ICommandExecutor
{
    public void Execute(string command)
    {
        if (commandRegistry.IsCommand(command))
        {
            var action = commandRegistry.GetCommand(command);
            action.Invoke();
        }
        else
        {
            throw new ArgumentException($"Command '{command}' not found.");
        }
    }
}