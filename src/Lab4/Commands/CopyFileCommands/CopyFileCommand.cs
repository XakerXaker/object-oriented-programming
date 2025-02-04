using ITMO.ObjectOrientedProgramming.Lab4.ApplicationContexts;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.CopyFileCommands;

public class CopyFileCommand : ICommand
{
    private readonly string _source;
    private readonly string _destination;

    public CopyFileCommand(string source, string destination)
    {
        _source = source;
        _destination = destination;
    }

    public ExecutionResult Execute(IApplicationContext context)
    {
        context.Fs.CopyFile(_source, _destination);
        return new ExecutionResult.Success();
    }
}