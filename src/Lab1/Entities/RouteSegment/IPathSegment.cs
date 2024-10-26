namespace ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

public interface IPathSegment
{
    public Length Length { get; init; }

    public PowerModule? PowerModule { get; init; }

    public MovementResult MoveTrain(Train train, Time accuracy);
}