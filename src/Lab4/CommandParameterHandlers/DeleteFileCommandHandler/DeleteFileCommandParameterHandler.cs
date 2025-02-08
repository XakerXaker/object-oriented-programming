using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.Commands.DeleteFileCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.DeleteFileCommandHandler;

public class DeleteFileCommandParameterHandler : CommandParameterHandler
{
    private readonly int _numsOfTokenRequired = 3;
    private readonly string _commandType = "File";
    private readonly string _commandName = "delete";

    public override ICommand? Handle(Request input)
    {
        var builder = new DeleteFileCommandBuilder();

        if (input.Length != _numsOfTokenRequired || (input.GetTokenFromIndex(0) != _commandType && input.GetTokenFromIndex(1) != _commandName))
            return Next?.Handle(input);

        builder.From(input.GetTokenFromIndex(2));

        return builder.Build();
    }
}