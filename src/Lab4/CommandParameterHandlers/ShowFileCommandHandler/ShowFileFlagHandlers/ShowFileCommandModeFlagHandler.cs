using ITMO.ObjectOrientedProgramming.Lab4.Commands.ShowFileCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ShowFileCommandHandler.ShowFileFlagHandlers;

public class ShowFileCommandModeFlagHandler : ShowFileCommandFlagHandler
{
    private readonly string _flagName = "-m";

    private readonly int _flagNamePosition = 4;
    private readonly int _flagValuePosition = 5;

    public override ShowFileCommandBuilder Handle(Request input)
    {
        var builder = new ShowFileCommandBuilder();
        string mode = string.Empty;
        if (input.GetTokenFromIndex(_flagNamePosition - 1) != _flagName)
            throw new Exception("Unrecognizable flag in show file command");

        if (input.Length == _flagValuePosition)
            mode = input.GetTokenFromIndex(_flagValuePosition - 1);

        return builder.InMode(mode);
    }
}