using CalculatorApp.DTO;

namespace CalculatorApp.Services.Commands;

public interface ICommandExecutor
{
    IResult Execute(string command);
}

public class CommandExecutor(CommandRegistry commandRegistry) : ICommandExecutor
{
    public IResult Execute(string command)
    {
        if (!commandRegistry.IsCommand(command))
        {
            return Result.Err("Invalid command");
        }

        var action = commandRegistry.GetCommand(command);
        action.Invoke();
        return Result.Ok("executed successfully");
    }
}