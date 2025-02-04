namespace ITMO.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    public void RenameFile(string path, string name);

    public void MoveFile(string source, string destination);

    public void CopyFile(string source, string destination);

    public void DeleteFile(string path);
}