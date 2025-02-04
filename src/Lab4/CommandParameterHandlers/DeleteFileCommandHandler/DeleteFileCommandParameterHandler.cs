using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.Commands.DeleteFileCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.DeleteFileCommandHandler;

public class DeleteFileCommandParameterHandler : CommandParameterHandler
{
    public override ICommand? Handle(Request input)
    {
        var builder = new DeleteFileCommandBuilder();

        if (input.Length != 2 || input.Current != "File")
            return Next?.Handle(input);

        if (!input.MoveNext() || input.Current != "Delete")
            return Next?.Handle(input);

        input.MoveNext();
        builder.From(input.Current);

        return builder.Build();
    }
}