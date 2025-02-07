using ITMO.ObjectOrientedProgramming.Lab4.FileSystemComposite;

namespace ITMO.ObjectOrientedProgramming.Lab4.FileSystemItemVisitor;

public class ConsoleVisitor : IFileSystemItemVisitor
{
    private readonly string _intend;
    private readonly string _folderSymbol;
    private readonly string _fileSymbol;

    private readonly int _depth;

    private int _depthCounter;

    public ConsoleVisitor(int depth, string intend, string folderSymbol, string fileSymbol)
    {
        _depthCounter = 0;

        _depth = depth;
        _intend = intend;
        _folderSymbol = folderSymbol;
        _fileSymbol = fileSymbol;
    }

    public void Visit(FileSystemFile component)
    {
        WriteIndented(component.Name, _fileSymbol);
    }

    public void Visit(FileSystemDirectory component)
    {
        WriteIndented(component.Name, _folderSymbol);

        _depthCounter += 1;

        if (_depthCounter <= _depth)
        {
            foreach (IFileSystemItem innerComponent in component.Components)
            {
                innerComponent.Accept(this);
            }
        }

        _depthCounter -= 1;
    }

    private void WriteIndented(string value, string fileSystemItemSymbol)
    {
        if (_depthCounter is not 0)
        {
            Console.Write(string.Concat(Enumerable.Repeat("   ", _depth)));
            Console.Write(string.Concat(_intend, fileSystemItemSymbol));
        }

        Console.WriteLine(value);
    }
}