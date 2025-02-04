namespace ITMO.ObjectOrientedProgramming.Lab4.Commands.DeleteFileCommands;

public class DeleteFileCommandBuilder : ICommandBuilder
{
    private string _path = string.Empty;

    public DeleteFileCommandBuilder From(string path)
    {
        _path = path;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(_path))
        {
            throw new Exception();
        }

        return new DeleteFileCommand(_path);
    }
}