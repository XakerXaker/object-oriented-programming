using ITMO.ObjectOrientedProgramming.Lab4.Commands;

using ITMO.ObjectOrientedProgramming.Lab4.Commands.MoveFileCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.MoveFileCommandHandler;

public class MoveFileCommandParameterHandler : CommandParameterHandler
{
    private readonly int _numsOfTokenRequired = 4;
    private readonly string _commandType = "File";
    private readonly string _commandName = "move";

    public override ICommand? Handle(Request input)
    {
        var builder = new MoveFileCommandBuilder();

        if (input.Length != _numsOfTokenRequired || (input.GetTokenFromIndex(0) != _commandType && input.GetTokenFromIndex(1) != _commandName))
            return Next?.Handle(input);

        builder.From(input.GetTokenFromIndex(2));
        builder.To(input.GetTokenFromIndex(3));

        return builder.Build();
    }
}