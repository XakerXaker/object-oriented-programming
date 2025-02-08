using ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ConnectCommandHandler;
using ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.CopyFileCommandHandler;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.TreeListCommandHandler;
using ITMO.ObjectOrientedProgramming.Lab4.Input;
using Xunit;

namespace Lab4.Tests;

public class ParsingTest
{
    [Fact]
    public void TestParsingWhenNotEnoughArgument()
    {
        var input = new Request("file copy da bla h");
        var connect = new ConnectCommandParameterHandler();
        var copyFile = new CopyFileCommandParameterHandler();
        connect.AddNext(copyFile);

        ITMO.ObjectOrientedProgramming.Lab4.Commands.ICommand? command = connect.Handle(input);

        Assert.Null(command);
    }

    [Fact]
    public void TestParsingWithFlag()
    {
        var input = new Request("Tree list -d 5");
        var connect = new ConnectCommandParameterHandler();
        var treeList = new TreeListCommandParameterHandler();
        string expectedCommandName = "Tree list";
        connect.AddNext(treeList);

        ITMO.ObjectOrientedProgramming.Lab4.Commands.ICommand? command = connect.Handle(input);

        if (command is not null)
        {
            Assert.Equal(expectedCommandName, command.Name);
        }
    }

    [Fact]
    public void TestParsingWithoutOptionalFlag()
    {
        var input = new Request("Tree list");
        var connect = new ConnectCommandParameterHandler();
        var copyFile = new TreeListCommandParameterHandler();
        string expectedCommandName = "Tree list";
        connect.AddNext(copyFile);

        ITMO.ObjectOrientedProgramming.Lab4.Commands.ICommand? command = connect.Handle(input);

        if (command is not null)
        {
            Assert.Equal(expectedCommandName, command.Name);
        }
    }
}