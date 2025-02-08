using ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers;
using ITMO.ObjectOrientedProgramming.Lab4.FileSystems;
using ITMO.ObjectOrientedProgramming.Lab4.Input;
using System.Windows.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.Runner;

public class RunnerFacade
{
    private readonly CommandParameterHandler _rootHandler;

    public RunnerFacade(CommandParameterHandler handler)
    {
        _rootHandler = handler;
    }

    public void Run()
    {
        string? query = string.Empty;
        IFileSystem? fileSystem = null;

        while (true)
        {
            query = Console.ReadLine();
            if (query is null)
            {
                break;
            }
            else
            {
                var command = (ICommand?)_rootHandler.Handle(new Request(query));
                if (command is not null)
                {
                    command.Execute(fileSystem);
                }
            }
        }
    }
}