using ITMO.ObjectOrientedProgramming.Lab4.ApplicationContexts;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.MoveFileCommands;

public class MoveFileCommand : ICommand
{
    private readonly string _source;
    private readonly string _destination;

    public MoveFileCommand(string source, string destination)
    {
       _source = source;
       _destination = destination;
    }

    public ExecutionResult Execute(IApplicationContext context)
    {
        context.Fs.MoveFile(_source, _destination);
        return new ExecutionResult.Success();
    }
}