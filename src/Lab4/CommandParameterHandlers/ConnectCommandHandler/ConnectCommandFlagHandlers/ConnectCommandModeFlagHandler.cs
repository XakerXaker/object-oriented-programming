using ITMO.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ConnectCommandHandler.ConnectCommandFlagHandlers;

public class ConnectCommandModeFlagHandler : ConnectCommandFlagHandler
{
    private readonly string _flagName = "-m";
    private readonly string _flagValue = "local";

    private readonly int _flagNamePosition = 3;
    private readonly int _flagValuePosition = 4;

    public override ConnectCommandBuilder Handle(Request input)
    {
        if (input.GetTokenFromIndex(_flagNamePosition - 1) != _flagName)
            throw new Exception("Unrecognizable flag name in connection command");

        if (input.GetTokenFromIndex(_flagValuePosition - 1) != _flagValue)
            throw new Exception("Unrecognizable flag value in connection command");

        string mode = input.GetTokenFromIndex(_flagValuePosition);

        var builder = new ConnectCommandBuilder();
        return builder.InMode(mode);
    }
}