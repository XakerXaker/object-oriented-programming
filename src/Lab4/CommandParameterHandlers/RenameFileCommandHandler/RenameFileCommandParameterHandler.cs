using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.Commands.RenameFileCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.RenameFileCommandHandler;

public class RenameFileCommandParameterHandler : CommandParameterHandler
{
    public override ICommand? Handle(Request input)
    {
        var builder = new RenameFileCommandBuilder();

        if (input.Length != 4 || input.Current != "File")
            return Next?.Handle(input);

        if (!input.MoveNext() || input.Current != "rename")
            return Next?.Handle(input);

        input.MoveNext();
        builder.From(input.Current);

        input.MoveNext();
        builder.To(input.Current);

        return builder.Build();
    }
}