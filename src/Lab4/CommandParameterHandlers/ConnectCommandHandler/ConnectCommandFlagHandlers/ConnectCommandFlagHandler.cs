using ITMO.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ConnectCommandHandler.ConnectCommandFlagHandlers;

public abstract class ConnectCommandFlagHandler
{
    protected ConnectCommandFlagHandler? Next { get; private set; }

    public ConnectCommandFlagHandler AddNext(ConnectCommandFlagHandler next)
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

    public abstract ConnectCommandBuilder Handle(Request input);
}