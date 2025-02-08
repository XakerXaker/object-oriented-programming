using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ChangeDirectoryCommands;

public class ChangeDirectoryCommand : ICommand
{
    private readonly string _path;

    public ChangeDirectoryCommand(string path)
    {
        _path = path;
    }

    public string Name => "Tree goto";

    public void Execute(IFileSystem? fileSystem)
    {
        fileSystem?.ChangeDirectory(_path);
    }
}
