using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;
using ITMO.ObjectOrientedProgramming.Lab4.FileSystems.LocalFileSystems;

namespace ITMO.ObjectOrientedProgramming.Lab4.ApplicationContexts;

public class MyApplicationContext : IApplicationContext
{
    private readonly string _connectionAddress;

    // Вернет полный путь, поданный Юзером, под капотом само нормализует под ОС
    public string ConnectionAddress => Path.GetFullPath(_connectionAddress);

    public string CurrentDirectory { get; private set; }

    public string ConnectionMode => "local";

    public string FolderIcon { get; }

    public string FileIcon { get; }

    public IFileSystem Fs { get; } = new LocalFileSystem();

    public MyApplicationContext(string connectionAddress, string folderIcon, string fileIcon)
    {
        CurrentDirectory = string.Empty;
        _connectionAddress = connectionAddress;
        FolderIcon = folderIcon;
        FileIcon = fileIcon;
    }

    public void GoTo(string path)
    {
    }
}