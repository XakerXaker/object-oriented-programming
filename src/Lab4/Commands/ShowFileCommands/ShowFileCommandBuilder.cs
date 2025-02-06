using ITMO.ObjectOrientedProgramming.Lab4.Writter;

namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.ShowFileCommands;

public class ShowFileCommandBuilder : ICommandBuilder
{
    private string _path = string.Empty;
    private string _mode = string.Empty;

    private IWritter? _writter;

    public ShowFileCommandBuilder From(string path)
    {
        _path = path;
        return this;
    }

    public ShowFileCommandBuilder InMode(string mode)
    {
        _mode = mode;
        return this;
    }

    public ShowFileCommandBuilder AddWritter(IWritter writter)
    {
        _writter = writter;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(_path))
        {
            throw new Exception();
        }

        if (string.IsNullOrEmpty(_mode))
        {
            throw new Exception();
        }

        if (_writter is null)
        {
            throw new Exception();
        }

        return new ShowFileCommand(_path, _mode, _writter);
    }
}
