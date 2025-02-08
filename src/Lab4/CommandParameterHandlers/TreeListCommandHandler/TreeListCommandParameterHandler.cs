using ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.TreeListCommandHandler.TreeListFlagHandlers;
using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.TreeListCommandHandler;

public class TreeListCommandParameterHandler : CommandParameterHandler
{
    private readonly int _numOfTokensRequired = 2;
    private readonly string _commandType = "Tree";
    private readonly string _commandName = "list";

    private readonly TreeListCommandFlagHandler _flagHandler = new TreeListCommandModeFlagHandler();

    public override ICommand? Handle(Request input)
    {
        var builder = new TreeListCommandBuilder();
        if (input.Length < _numOfTokensRequired || (input.GetTokenFromIndex(0) != _commandType && input.GetTokenFromIndex(1) != _commandName))
            return Next?.Handle(input);

        if (input.Length > _numOfTokensRequired)
            builder = _flagHandler.Handle(input);

        return builder.Build();
    }
}