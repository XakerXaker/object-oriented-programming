using ITMO.ObjectOrientedProgramming.Lab4.ApplicationContexts;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    public ExecutionResult Execute(IApplicationContext context);
}