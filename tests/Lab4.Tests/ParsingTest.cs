using ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.ConnectCommandHandler;
using ITMO.ObjectOrientedProgramming.Lab4.CommandParameterHandlers.CopyFileCommandHandler;
using ITMO.ObjectOrientedProgramming.Lab4.Input;
using Xunit;

namespace Lab4.Tests;

public class ParsingTest
{
    [Fact]
    public void Parse()
    {
        var input = new Request("file copy bluh");
        var connect = new ConnectCommandParameterHandler();
        var copyFile = new CopyFileCommandParameterHandler();
        connect.AddNext(copyFile);
        Assert.Throws<Exception>(() => connect.Handle(input));
    }
}