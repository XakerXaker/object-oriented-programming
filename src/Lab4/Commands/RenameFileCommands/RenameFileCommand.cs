using ITMO.ObjectOrientedProgramming.Lab4.ApplicationContexts;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.RenameFileCommands;

public class RenameFileCommand : ICommand
{
    private readonly string _path;
    private readonly string _name;

    public RenameFileCommand(string path, string name)
    {
       _path = path;
       _name = name;
    }

    public ExecutionResult Execute(IApplicationContext context)
    {
        string destination = Path.GetFullPath(_path);

        if (destination.StartsWith(context.ConnectionAddress))
        {
            context.Fs.RenameFile(destination, _name);
            return new ExecutionResult.Success();
        }

        return new ExecutionResult.Failed("Messed with paths in Rename File command");
    }
}