using ITMO.ObjectOrientedProgramming.Lab4.FileSystemComposite;

namespace ITMO.ObjectOrientedProgramming.Lab4.FileSystemItemVisitor;

public interface IFileSystemItemVisitor
{
    public void Visit(FileSystemFile component);

    public void Visit(FileSystemDirectory component);
}