using ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ShowFileCommandHandler.ShowFileFlagHandlers;
using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.Commands.ShowFileCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ShowFileCommandHandler;

public class ShowFileCommandParameterHandler : CommandParameterHandler
{
    private readonly ShowFileCommandFlagHandler _flagHandler = new ShowFileCommandModeFlagHandler();

    public override ICommand? Handle(Request input)
    {
        var builder = new ShowFileCommandBuilder();

        if (input.Length < 3 || input.Current != "File")
            return Next?.Handle(input);

        if (input.MoveNext() || input.Current != "show")
            return Next?.Handle(input);

        input.MoveNext();
        string source = input.Current;

        if (input.MoveNext())
        {
            builder = _flagHandler.Handle(input);
        }

        return builder.From(source).Build();
    }
}