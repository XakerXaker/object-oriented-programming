using ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ConnectCommandHandler.ConnectCommandFlagHandlers;
using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ConnectCommandHandler;

public class ConnectCommandParameterHandler : CommandParameterHandler
{
    private readonly ConnectCommandModeFlagHandler _flagHandler = new ConnectCommandModeFlagHandler();

    public override ICommand? Handle(Request input)
    {
        var builder = new ConnectCommandBuilder();

        if (input.Current != "Connect")
            return Next?.Handle(input);

        string connectionAddress = input.MoveNext() ? input.Current : throw new Exception("Not enough arguments are specified in connect command");

        builder = input.MoveNext() ? _flagHandler.Handle(input) : throw new Exception("The connection mode is not specified");

        return builder.WithArgument(connectionAddress).Build();
    }
}