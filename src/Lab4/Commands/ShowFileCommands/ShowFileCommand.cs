using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;
using ITMO.ObjectOrientedProgramming.Lab4.Writter;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.ShowFileCommands;

public class ShowFileCommand : ICommand
{
    private readonly string _path;
    private readonly string _mode;

    private readonly IWritter _writter;

    public ShowFileCommand(string path, string mode, IWritter writter)
    {
        _path = path;
        _mode = mode;

        _writter = writter;
    }

    public void Execute(IFileSystem fileSystem)
    {
        if (_mode != "console")
            return;
        string? content = fileSystem.GetFileContent(_path);

        if (content is not null)
            _writter.ShowContent(content);
    }
}
