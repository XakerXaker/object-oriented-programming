using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;

public class DisconnectCommand : ICommand
{
    public string Name => "Disconnect";

    public void Execute(IFileSystem? fileSystem)
    {
        fileSystem = null;
    }
}
