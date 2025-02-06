using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.DeleteFileCommands;

public class DeleteFileCommand : ICommand
{
    private readonly string _path;

    public DeleteFileCommand(string path)
    {
        _path = path;
    }

    public void Execute(IFileSystem fileSystem)
    {
        fileSystem.DeleteFile(_path);
    }
}