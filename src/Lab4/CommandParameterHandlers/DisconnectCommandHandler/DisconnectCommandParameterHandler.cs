using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.DisconnectCommandHandler;

public class DisconnectCommandParameterHandler : CommandParameterHandler
{
    private readonly string _commandName = "Disconnect";
    private readonly int _numsOfTokenRequired = 1;

    public override ICommand? Handle(Request input)
    {
        if (input.GetTokenFromIndex(0) != _commandName || input.Length != _numsOfTokenRequired)
            return Next?.Handle(input);

        return new DisconnectCommand();
    }
}