using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.TreeListCommandHandler.TreeListFlagHandlers;

public class TreeListCommandModeFlagHandler : TreeListCommandFlagHandler
{
    private readonly string _flagName = "-d";

    private readonly int _flagNamePosition = 3;
    private readonly int _flagValuePosition = 4;

    public override TreeListCommandBuilder Handle(Request input)
    {
        var builder = new TreeListCommandBuilder();

        if (input.GetTokenFromIndex(_flagNamePosition - 1) != _flagName)
            throw new Exception("Unrecognizable flag in tree list command");

        return builder.WithDepth(int.Parse(input.GetTokenFromIndex(_flagValuePosition - 1)));
    }
}