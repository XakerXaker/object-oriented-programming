using ITMO.ObjectOrientedProgramming.Lab4.ApplicationContexts;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

public class ConnectCommand : ICommand
{
    private readonly string _absolutePath;
    private readonly string _mode;

    public ConnectCommand(string absolutePath, string mode)
    {
        _absolutePath = absolutePath;
        _mode = mode;
    }

    public ExecutionResult Execute(IApplicationContext context)
    {
        // При попытке подключиться к новой ФС без Disconnect'a от предыдущей ФС
        if (context is not null)
        {
            return new ExecutionResult.Failed("Connect commmand failed");
        }

        if (_mode != "l")
        {
            return new ExecutionResult.Failed("Connect command doesn't support this mode");
        }

        if (!Path.IsPathRooted(_absolutePath))
        {
            return new ExecutionResult.Failed("Connect command require absolute path");
        }

        context = new MyApplicationContext(_absolutePath, " ", " ");

        return new ExecutionResult.Success();
    }
}