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
        context.Fs.RenameFile(_path, _name);
        return new ExecutionResult.Success();
    }
}