using ITMO.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ConnectCommandHandler.ConnectCommandFlagHandlers;

public class ConnectCommandModeFlagHandler : ConnectCommandFlagHandler
{
    public override ConnectCommandBuilder Handle(Request input)
    {
        var builder = new ConnectCommandBuilder();
        if (input.Current != "-m")
            throw new Exception("Unrecognizable flag in connection command");

        if (input.MoveNext() == false)
            throw new Exception("Flag is not specified in connection command");

        string mode = input.Current;

        return builder.InMode(mode);
    }
}