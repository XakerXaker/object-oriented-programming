namespace ITMO.ObjectOrientedProgramming.Lab4.FileSystems.LocalFileSystems;

public class LocalFileSystem : IFileSystem
{
    // Destination is directory
    public void MoveFile(string source, string destination)
    {
        try
        {
            File.Move(source, Path.Combine(destination, Path.GetFileName(source)));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Moving file threws an exception: {0}", ex.ToString());
        }
    }

    // Destination is directory
    public void CopyFile(string source, string destination)
    {
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
}
