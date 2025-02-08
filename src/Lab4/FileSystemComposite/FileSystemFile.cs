using ITMO.ObjectOrientedProgramming.Lab4.FileSystemItemVisitor;

namespace ITMO.ObjectOrientedProgramming.Lab4.FileSystemComposite;

public class FileSystemFile : IFileSystemItem
{
    public FileSystemFile(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IFileSystemItemVisitor visitor)
    {
        visitor.Visit(this);
    }
}