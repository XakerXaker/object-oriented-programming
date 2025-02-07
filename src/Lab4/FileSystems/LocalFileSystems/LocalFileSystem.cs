namespace ITMO.ObjectOrientedProgramming.Lab4.FileSystems.LocalFileSystems;

public class LocalFileSystem : IFileSystem
{
    // Теперь это корень
    public string ConnectionPath { get; }

    // Контекст для выполнения команд
    private string _currentDirectory;

    public LocalFileSystem(string connectionPath)
    {
        ConnectionPath = Path.GetFullPath(connectionPath);

        _currentDirectory = ConnectionPath;
    }

    public bool IsAbsolutePath(string path)
    {
        string fullPath = Path.GetFullPath(path);

        return fullPath.StartsWith(ConnectionPath);
    }

    public bool IsValidPathArgument(string path)
    {
        string fullPath = Path.GetFullPath(path);

        return fullPath.StartsWith(_currentDirectory) || IsAbsolutePath(path);
    }

    // Destination is directory
    public void MoveFile(string source, string destination)
    {
        string sourceFilePath = source;
        string destinationDirectoryPath = destination;

        try
        {
            if (File.Exists(sourceFilePath))
            {
                File.Move(source, Path.Combine(destination, Path.GetFileName(source)));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Moving file threws an exception: {0}", ex.ToString());
        }
    }

    // Destination is directory
    public void CopyFile(string source, string destination)
    {
        if (!File.Exists(source) || !IsValidPathArgument(source))
            return;

        if (!Directory.Exists(destination) || !IsValidPathArgument(destination))
            return;

        try
        {
            File.Copy(source, Path.Combine(destination, Path.GetFileName(source)));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Copying file threws an exception: {0}", ex.ToString());
        }
    }

    public void DeleteFile(string path)
    {
        if (!File.Exists(path) || !IsValidPathArgument(path))
            return;

        try
        {
            File.Delete(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Deleting file threws an exception: {0}", ex.ToString());
        }
    }

    public void RenameFile(string path, string name)
    {
        if (!File.Exists(path) || !IsValidPathArgument(path))
            return;

        try
        {
            string? directoryName = Path.GetDirectoryName(path);
            if (directoryName is not null)
            {
                File.Move(path, Path.Combine(directoryName, name));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Renaming file threws an exception: {0}", ex.ToString());
        }
    }

    public string? GetFileContent(string path)
    {
        if (!IsValidPathArgument(path) || !File.Exists(path))
            return null;

        try
        {
            string content = File.ReadAllText(path);
            return content;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Reading file threws an exception: {0}", ex.ToString());
        }

        return null;
    }

    public void ChangeDirectory(string path)
    {
        if (!IsValidPathArgument(path))
            return;

        _currentDirectory = Path.GetFullPath(path);
    }
}
