namespace ITMO.ObjectOrientedProgramming.Lab4.PathValidation;

public class PathValidator
{
    public bool IsRelativeTo(string connectionPath, string relativePath)
    {
        string fullPath = Path.GetFullPath(relativePath);
        return relativePath.StartsWith(fullPath);
    }
}