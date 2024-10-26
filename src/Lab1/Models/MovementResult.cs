namespace ITMO.ObjectOrientedProgramming.Lab1.Models;

public abstract record MovementResult
{
    private MovementResult() { }

    public sealed record Success(Time TravelTime) : MovementResult;

    public sealed record Failure : MovementResult;
}