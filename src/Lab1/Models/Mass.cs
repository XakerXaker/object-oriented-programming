namespace ITMO.ObjectOrientedProgramming.Lab1.Models;

public record Mass
{
    public double Value { get; init; }

    public Mass(double value)
    {
        if (value < 0) throw new Exception("Mass cannot be negative");
        Value = value;
    }
}