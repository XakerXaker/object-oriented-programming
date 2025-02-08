using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;

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

    public string Name => "File move";

    public void Execute(IFileSystem fileSystem)
    {
        fileSystem.MoveFile(_source, _destination);
    }
}