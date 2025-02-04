namespace ITMO.ObjectOrientedProgramming.Lab4.Commands;

public abstract record ExecutionResult
{
    private ExecutionResult() { }

    public sealed record Failed(string Descriptiton) : ExecutionResult { }

    public sealed record Success : ExecutionResult { }
}