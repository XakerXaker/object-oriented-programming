using ITMO.ObjectOrientedProgramming.Lab4.Commands.ShowFileCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ShowFileCommandHandler.ShowFileFlagHandlers;

public class ShowFileCommandModeFlagHandler : ShowFileCommandFlagHandler
{
    public override ShowFileCommandBuilder Handle(Request input)
    {
        var builder = new ShowFileCommandBuilder();
        if (input.Current != "-m")
            throw new Exception("Unrecognizable flag in connection command");

        if (input.MoveNext() == false)
            throw new Exception("Flag is not specified in connection command");

        string mode = input.Current;

        return builder.InMode(mode);
    }
}