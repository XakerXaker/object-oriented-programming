using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;
using ITMO.ObjectOrientedProgramming.Lab4.FileSystems.LocalFileSystems;

namespace ITMO.ObjectOrientedProgramming.Lab4.ApplicationContexts;

public class MyApplicationContext : IApplicationContext
{
    public string ConnectionAddress { get; }

    public string CurrentDirectory { get; private set; }

    public string ConnectionMode => "local";

    public string FolderIcon { get; }

    public string FileIcon { get; }

    public IFileSystem Fs { get; } = new LocalFileSystem();

    public MyApplicationContext(string connectionAddress, string folderIcon, string fileIcon)
    {
        CurrentDirectory = string.Empty;
        ConnectionAddress = connectionAddress;
        FolderIcon = folderIcon;
        FileIcon = fileIcon;
    }

    public void GoTo(string path)
    {
    }
}