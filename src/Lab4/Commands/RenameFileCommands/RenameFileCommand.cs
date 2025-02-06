using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;

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

    public void Execute(IFileSystem fileSystem)
    {
        fileSystem.RenameFile(_path, _name);
    }
}