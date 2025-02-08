using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;
using ITMO.ObjectOrientedProgramming.Lab4.FileSystems.LocalFileSystems;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

public class ConnectCommand : ICommand
{
    private readonly string _absolutePath;
    private readonly string _mode;

    public ConnectCommand(string absolutePath, string mode)
    {
        _absolutePath = absolutePath;
        _mode = mode;
    }

    public string Name => "Connect";

    public void Execute(IFileSystem fileSystem)
    {
        if (_mode == "l")
            fileSystem = new LocalFileSystem(_absolutePath);
    }
}