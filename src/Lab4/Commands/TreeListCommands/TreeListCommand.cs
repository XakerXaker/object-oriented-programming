using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.FileSystemComposite;
using ITMO.ObjectOrientedProgramming.Lab4.FileSystemItemVisitor;
using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;

    private readonly string _intend;
    private readonly string _folderSymbol;
    private readonly string _fileSymbol;

    public TreeListCommand(int depth, string indent, string folderSymbol, string fileSymbol)
    {
        _depth = depth;

        _intend = indent;

        _folderSymbol = folderSymbol;
        _fileSymbol = fileSymbol;
    }

    public void Execute(IFileSystem fileSystem)
    {
        var fileSystemComposite = new FileSystemCompositeFactory();
        IFileSystemItem fileSystemItem = fileSystemComposite.Create(fileSystem.ConnectionPath);
        IFileSystemItemVisitor visitor = new ConsoleVisitor(_depth, _intend, _folderSymbol, _fileSymbol);
    }
}
