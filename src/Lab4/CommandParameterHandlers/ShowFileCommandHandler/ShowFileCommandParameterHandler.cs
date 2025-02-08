using ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ShowFileCommandHandler.ShowFileFlagHandlers;
using ITMO.ObjectOrientedProgramming.Lab4.Commands;
using ITMO.ObjectOrientedProgramming.Lab4.Commands.ShowFileCommands;
using ITMO.ObjectOrientedProgramming.Lab4.Input;

namespace ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ShowFileCommandHandler;

public class ShowFileCommandParameterHandler : CommandParameterHandler
{
    private readonly int _numsOfTokenRequired = 3;
    private readonly string _commandType = "File";
    private readonly string _commandName = "show";
    private readonly ShowFileCommandFlagHandler _flagHandler = new ShowFileCommandModeFlagHandler();

    public override ICommand? Handle(Request input)
    {
        var builder = new ShowFileCommandBuilder();

        if (input.Length < _numsOfTokenRequired || (input.GetTokenFromIndex(0) != _commandType && input.GetTokenFromIndex(1) != _commandName))
            return Next?.Handle(input);

        string source = input.GetTokenFromIndex(2);

        if (input.Length > _numsOfTokenRequired)
        {
            builder = _flagHandler.Handle(input);
        }

        return builder.From(source).Build();
    }
}