namespace ITMO.ObjectOrientedProgramming.Lab2.ValueObject;

public record Points
{
    public Points(double value)
    {
        if (value <= 0) throw new Exception("Points value cannot be negative");
        Value = value;
    }

    public double Value { get; init; }
}