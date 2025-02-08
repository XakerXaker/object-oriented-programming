using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ChangeDirectoryCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ChangeDirectoryCommandHandler;

public class ChangeDirectoryCommandParameterHandler : CommandParameterHandler
{
    private readonly int _numOfTokensRequired = 3;
    private readonly string _commandType = "Tree";
    private readonly string _commandName = "goto";

    public override ICommand? Handle(Request input)
    {
        if (input.Length != _numOfTokensRequired || (input.GetTokenFromIndex(0) != _commandType && input.GetTokenFromIndex(1) != _commandName))
            return Next?.Handle(input);

        return new ChangeDirectoryCommand(input.GetTokenFromIndex(2));
    }
}