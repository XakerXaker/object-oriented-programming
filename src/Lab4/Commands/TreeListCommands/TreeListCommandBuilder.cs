using ITMO.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public class TreeListCommandBuilder : ICommandBuilder
{
    private int _depth;

    private string _intend = "->";
    private string _folderSymbol = "Folder";
    private string _fileSymbol = "File";

    public TreeListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public TreeListCommandBuilder WithIntend(string intend)
    {
        _intend = intend;
        return this;
    }

    public TreeListCommandBuilder WithFolderSymbol(string folderSymbol)
    {
        _folderSymbol = folderSymbol;
        return this;
    }

    public TreeListCommandBuilder WithFileSymbol(string fileSymbol)
    {
        _fileSymbol = fileSymbol;
        return this;
    }

    public ICommand Build()
    {
        return new TreeListCommand(_depth, _intend, _folderSymbol, _fileSymbol);
    }
}
