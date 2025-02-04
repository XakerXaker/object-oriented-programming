using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;

namespace ITMO.ObjectOrientedProgramming.Lab4.ApplicationContexts;

public interface IApplicationContext
{
    public string ConnectionAddress { get; }

    public string ConnectionMode { get; }

    public string FolderIcon { get; }

    public string FileIcon { get; }

    public IFileSystem Fs { get; }
}