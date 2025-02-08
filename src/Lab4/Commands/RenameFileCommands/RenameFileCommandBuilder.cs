namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.RenameFileCommands;

public class RenameFileCommandBuilder : ICommandBuilder
{
    private string _path = string.Empty;
    private string _name = string.Empty;

    public RenameFileCommandBuilder From(string path)
    {
        _path = path;
        return this;
    }

    public RenameFileCommandBuilder To(string name)
    {
        _name = name;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(_path))
        {
            throw new Exception();
        }

        if (string.IsNullOrEmpty(_name))
        {
            throw new Exception();
        }

        return new RenameFileCommand(_path, _name);
    }
}