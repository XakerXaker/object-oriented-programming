using ITMO.ObjectOrientedProgramming.Lab4.FileSystemItemVisitor;

namespace ITMO.ObjectOrientedProgramming.Lab4.FileSystemComposite;

public interface IFileSystemItem
{
    public string Name { get; }

    public void Accept(IFileSystemItemVisitor visitor);
}