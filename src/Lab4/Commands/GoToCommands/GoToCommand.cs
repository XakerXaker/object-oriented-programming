using ITMO.ObjectOrientedProgramming.Lab4.ApplicationContexts;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.GoToCommands;

public class GoToCommand : ICommand
{
    public ExecutionResult Execute(IApplicationContext? context)
    {
        if (context is null)
            return new ExecutionResult.Failed("FileSystem is already disconnected");

        context = null;
        return new ExecutionResult.Success();
    }
}
