namespace ITMO.ObjectOrientedProgramming.Lab1.Models;

public record Length
{
    public double Value { get; init; }

    public Length(double value)
    {
        if (value < 0) throw new Exception("Time cannot be negative");
        Value = value;
    }
}