namespace ITMO.ObjectOrientedProgramming.Lab4.FileSystemComposite;

public class FileSystemCompositeFactory
{
    public IFileSystemItem Create(string path)
    {
        if (Directory.Exists(path))
        {
            string? name = Path.GetFileName(path);

            IEnumerable<string> names = Directory
                .EnumerateFileSystemEntries(path)
                .Select(Path.GetFileName)
                .Where(x => x is not null)
                .Cast<string>();

            IFileSystemItem[] components = names
                .Select(entry => Path.Combine(path, entry))
                .Select(Create)
                .ToArray();

            return new FileSystemDirectory(name ?? string.Empty, components);
        }

        if (File.Exists(path))
        {
            string name = Path.GetFileName(path);
            return new FileSystemFile(name);
        }

        throw new InvalidOperationException($"File system component at {path} is not found");
    }
}