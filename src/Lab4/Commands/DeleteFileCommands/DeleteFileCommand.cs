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
        context.Fs.DeleteFile(_path);
        return new ExecutionResult.Success();
    }
}