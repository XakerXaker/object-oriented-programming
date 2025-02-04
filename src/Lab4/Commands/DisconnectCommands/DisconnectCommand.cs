using ITMO.ObjectOrientedProgramming.Lab4.ApplicationContexts;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;

public class DisconnectCommand : ICommand
{
    public ExecutionResult Execute(IApplicationContext? context)
    {
        if (context is null)
            return new ExecutionResult.Failed("FileSystem is already disconnected");

        context = null;
        return new ExecutionResult.Success();
    }
}
