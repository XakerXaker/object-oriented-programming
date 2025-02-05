using ITMO.ObjectOrientedProgramming.Lab4.ApplicationContexts;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.DeleteFileCommands;

public class DeleteFileCommand : ICommand
{
    private readonly string _path;

    public DeleteFileCommand(string path)
    {
        _path = path;
    }

    public ExecutionResult Execute(IApplicationContext context)
    {
        string path = Path.GetFullPath(_path);
        if (File.Exists(_path) && path.StartsWith(context.ConnectionAddress))
        {
            context.Fs.DeleteFile(_path);
            return new ExecutionResult.Success();
        }

        return new ExecutionResult.Failed("Messed with path in Delete File command");
    }
}