using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;

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

    public void Execute(IFileSystem fileSystem)
    {
        fileSystem.CopyFile(_source, _destination);
    }
}