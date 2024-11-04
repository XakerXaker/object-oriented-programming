namespace ITMO.ObjectOrientedProgramming.Lab1.Models;

public record Time
{
    public double Value { get; set; }

    public Time(double value)
    {
        if (value < 0) throw new Exception("Time cannot be negative");
        Value = value;
    }
}