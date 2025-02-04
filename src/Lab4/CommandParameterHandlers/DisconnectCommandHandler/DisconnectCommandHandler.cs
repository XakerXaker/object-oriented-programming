using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.DisconnectCommandHandler;

public class DisconnectCommandHandler : CommandParameterHandler
{
    public override ICommand? Handle(Request input)
    {
        var builder = new ConnectCommandBuilder();

        return input.Current != "Disconnect" ? Next?.Handle(input) : new DisconnectCommand();
    }
}