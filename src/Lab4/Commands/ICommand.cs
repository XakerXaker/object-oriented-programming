using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    public void Execute(IFileSystem fileSystem);
}