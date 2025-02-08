using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.TreeListCommandHandler.TreeListFlagHandlers;

public abstract class TreeListCommandFlagHandler
{
    protected TreeListCommandFlagHandler? Next { get; private set; }

    public TreeListCommandFlagHandler AddNext(TreeListCommandFlagHandler next)
    {
        if (Next is null)
        {
            Next = next;
        }
        else
        {
            Next.AddNext(next);
        }

        return this;
    }

    public abstract TreeListCommandBuilder Handle(Request input);
}