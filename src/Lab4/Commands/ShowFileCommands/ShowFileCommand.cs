using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;
using ITMO.ObjectOrientedProgramming.Lab4.Writter;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.ShowFileCommands;

public class ShowFileCommand : ICommand
{
    private readonly string _path;
    private readonly string _mode;

    public ShowFileCommand(string path, string mode)
    {
        _path = path;
        _mode = mode;
    }

    public string Name => "File show";

    public void Execute(IFileSystem? fileSystem)
    {
        if (_mode != "console")
            return;

        string? content = fileSystem?.GetFileContent(_path);

        if (content is not null)
        {
            var writter = new ConsoleWritter();
            writter.ShowContent(content);
        }
    }
}
