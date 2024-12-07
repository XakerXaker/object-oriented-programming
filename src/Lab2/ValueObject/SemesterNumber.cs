namespace ITMO.ObjectOrientedProgramming.Lab2.ValueObject;

public record SemesterNumber
{
    public SemesterNumber(double number)
    {
        if (number <= 0) throw new Exception("Semester number cannot be negative");
        Number = number;
    }

    public double Number { get; set; }
}