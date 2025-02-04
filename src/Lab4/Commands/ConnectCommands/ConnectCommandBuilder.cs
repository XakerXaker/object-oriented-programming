namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

public class ConnectCommandBuilder : ICommandBuilder
{
    private string _absolutePath = string.Empty;
    private string _mode = string.Empty;

    public ConnectCommandBuilder WithArgument(string absolutePath)
    {
        _absolutePath = absolutePath;
        return this;
    }

    public ConnectCommandBuilder InMode(string mode)
    {
        _mode = mode;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(_absolutePath))
        {
            throw new Exception();
        }

        if (string.IsNullOrEmpty(_mode))
        {
            throw new Exception();
        }

        return new ConnectCommand(_absolutePath, _mode);
    }
}