using ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ConnectCommandHandler.ConnectCommandFlagHandlers;
using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ConnectCommandHandler;

public class ConnectCommandParameterHandler : CommandParameterHandler
{
    private readonly int _numOfTokensRequired = 3;
    private readonly string _commandName = "Connect";
    private readonly ConnectCommandModeFlagHandler _flagHandler = new ConnectCommandModeFlagHandler();

    public override ICommand? Handle(Request input)
    {
        if (input.Length != _numOfTokensRequired || input.GetTokenFromIndex(0) != _commandName)
            return Next?.Handle(input);

        string connectionAddress = input.GetTokenFromIndex(1);

        ConnectCommandBuilder builder = _flagHandler.Handle(input);
        return builder.WithArgument(connectionAddress).Build();
    }
}