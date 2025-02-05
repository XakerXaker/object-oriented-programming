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
        string source = Path.GetFullPath(_source);
        string destination = Path.GetFullPath(_destination);

        // определяем относительность пути, абсолютные тоже хавает
        if (destination.StartsWith(context.ConnectionAddress) && source.StartsWith(context.ConnectionAddress))
        {
            context.Fs.CopyFile(_source, _destination);
            return new ExecutionResult.Success();
        }

        return new ExecutionResult.Failed("Messed with paths in Copy File command");
    }
}