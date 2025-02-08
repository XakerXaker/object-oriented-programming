using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers;

public abstract class CommandParameterHandler
{
    protected CommandParameterHandler? Next { get; private set; }

    public CommandParameterHandler AddNext(CommandParameterHandler handler)
    {
        if (Next is null)
        {
            Next = handler;
        }
        else
        {
            Next.AddNext(handler);
        }

        return this;
    }

    public abstract ICommand? Handle(Request input);
}