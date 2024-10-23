namespace ITMO.ObjectOrientedProgramming.Lab1.Models;

public abstract record MovementResult
{
    private MovementResult() { }

    public sealed record Success : MovementResult;

    public sealed record Failure : MovementResult;
}