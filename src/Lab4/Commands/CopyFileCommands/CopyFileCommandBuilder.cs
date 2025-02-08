namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.CopyFileCommands;

public class CopyFileCommandBuilder : ICommandBuilder
{
    private string _source = string.Empty;
    private string _destination = string.Empty;

    public CopyFileCommandBuilder From(string source)
    {
        _source = source;
        return this;
    }

    public CopyFileCommandBuilder To(string destination)
    {
        _destination = destination;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(_source))
        {
            throw new Exception();
        }

        if (string.IsNullOrEmpty(_destination))
        {
            throw new Exception();
        }

        return new CopyFileCommand(_source, _destination);
    }
}