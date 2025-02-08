using ITMO.ObjectOrientedProgramming.Lab4.FileSystemItemVisitor;

namespace ITMO.ObjectOrientedProgramming.Lab4.FileSystemComposite;

public class FileSystemDirectory : IFileSystemItem
{
    public string Name { get; }

    public IReadOnlyCollection<IFileSystemItem> Components { get; }

    public FileSystemDirectory(
        string name,
        IReadOnlyCollection<IFileSystemItem> components)
    {
        Name = name;
        Components = components;
    }

    public void Accept(IFileSystemItemVisitor visitor)
    {
        visitor.Visit(this);
    }
}