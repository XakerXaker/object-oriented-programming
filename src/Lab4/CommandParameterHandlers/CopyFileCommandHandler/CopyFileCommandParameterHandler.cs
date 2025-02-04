using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.Commands.CopyFileCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.CopyFileCommandHandler;

public class CopyFileCommandParameterHandler : CommandParameterHandler
{
    public override ICommand? Handle(Request input)
    {
        var builder = new CopyFileCommandBuilder();

        if (input.Length != 4 || input.Current != "File")
            return Next?.Handle(input);

        if (!input.MoveNext() || input.Current != "copy")
            return Next?.Handle(input);

        input.MoveNext();
        builder.From(input.Current);

        input.MoveNext();
        builder.To(input.Current);

        return builder.Build();
    }
}