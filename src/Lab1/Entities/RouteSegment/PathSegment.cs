namespace ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

public abstract class PathSegment
{
    public double Length { get; protected set; }

    public int TravelTime { get; protected set; }

    protected PowerModule? PowerModule { get; set; }

    protected PathSegment(double length, PowerModule? powerModule)
    {
        if (length < 0) throw new Exception("Length cannot be negative");

        Length = length;
        PowerModule = powerModule;
    }

    public abstract MovementResult MoveTrain(Train train, int accuracy);
}