namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.MoveFileCommands;

public class MoveFileCommandBuilder : ICommandBuilder
{
    private string _source = string.Empty;
    private string _destination = string.Empty;

    public MoveFileCommandBuilder From(string source)
    {
        _source = source;
        return this;
    }

    public MoveFileCommandBuilder To(string destination)
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

        return new MoveFileCommand(_source, _destination);
    }
}