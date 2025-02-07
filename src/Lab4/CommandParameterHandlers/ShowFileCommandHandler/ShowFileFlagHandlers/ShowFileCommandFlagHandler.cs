using ITMO.ObjectOrientedProgramming.Lab4.Commands.ShowFileCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ShowFileCommandHandler.ShowFileFlagHandlers;

public abstract class ShowFileCommandFlagHandler
{
    protected ShowFileCommandFlagHandler? Next { get; private set; }

    public ShowFileCommandFlagHandler AddNext(ShowFileCommandFlagHandler next)
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

    public abstract ShowFileCommandBuilder Handle(Request input);
}