using CalculatorApp.Services.Commands;
using IServices_ICommand = CalculatorApp.IServices.ICommand;

namespace CalculatorApp.Services;

public interface ICommandRegistry
{
    bool IsCommand(string command);
    void RegisterCommand(string key, IServices_ICommand command);
    IServices_ICommand GetCommand(string command);
}

public class CommandRegistry : ICommandRegistry
{
    private readonly Dictionary<string, IServices_ICommand> _commands = new();

    public CommandRegistry()
    {
        _commands.Add(CloseCommand.Key, new CloseCommand());
        _commands.Add(ClearCommand.Key, new ClearCommand());
    }

    public bool IsCommand(string command)
    {
        return _commands.ContainsKey(command.ToLower());
    }

    public void RegisterCommand(string key, IServices_ICommand command)
    {
        _commands.Add(key, new ClearCommand());
    }

    public IServices_ICommand GetCommand(string command)
    {
        return _commands[command.ToLower()];
    }
}