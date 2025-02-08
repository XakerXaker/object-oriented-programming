using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.Commands.RenameFileCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.RenameFileCommandHandler;

public class RenameFileCommandParameterHandler : CommandParameterHandler
{
    private readonly int _numsOfTokenRequired = 4;
    private readonly string _commandType = "File";
    private readonly string _commandName = "rename";

    public override ICommand? Handle(Request input)
    {
        var builder = new RenameFileCommandBuilder();

        if (input.Length != _numsOfTokenRequired || (input.GetTokenFromIndex(0) != _commandType && input.GetTokenFromIndex(1) != _commandName))
            return Next?.Handle(input);

        builder.From(input.GetTokenFromIndex(2));
        builder.To(input.GetTokenFromIndex(3));

        return builder.Build();
    }
}