namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.ShowFileCommands;

public class ShowFileCommandBuilder : ICommandBuilder
{
    private string _path = string.Empty;
    private string _mode = string.Empty;

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

        return new ShowFileCommand(_path, _mode);
    }
}
