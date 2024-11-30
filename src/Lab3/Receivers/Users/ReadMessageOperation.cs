namespace ITMO.ObjectOrientedProgramming.Lab3.Receivers.Users;

public abstract record ReadMessageOperation
{
    private ReadMessageOperation() { }

    public sealed record Failure : ReadMessageOperation
    { }

    public sealed record Success : ReadMessageOperation
    { }
}
