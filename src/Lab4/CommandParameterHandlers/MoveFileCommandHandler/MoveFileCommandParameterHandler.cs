using ITMO.ObjectOrientedProgramming.Lab4.Commands;

using ITMO.ObjectOrientedProgramming.Lab4.Commands.MoveFileCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.MoveFileCommandHandler;

public class MoveFileCommandParameterHandler : CommandParameterHandler
{
    public override ICommand? Handle(Request input)
    {
        var builder = new MoveFileCommandBuilder();

        if (input.Length != 4 || input.Current != "File")
            return Next?.Handle(input);

        if (!input.MoveNext() || input.Current != "move")
        {
            input.Reset();
            return Next?.Handle(input);
        }

        input.MoveNext();
        builder.From(input.Current);

        input.MoveNext();
        builder.To(input.Current);

        return builder.Build();
    }
}