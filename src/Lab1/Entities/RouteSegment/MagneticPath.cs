namespace ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

public class MagneticPath : IPathSegment
{
    public Length Length { get; init; }

    public PowerModule? PowerModule { get; init; }

    public MagneticPath(Length length, PowerModule? powerModule)
    {
        Length = length;
        PowerModule = powerModule;
    }

    public MovementResult MoveTrain(Train train, Time accuracy)
    {
        if (train.Speed == 0)
        {
            return new MovementResult.Failure();
        }

        if (PowerModule is not null && PowerModule.SpeedLimit < train.Speed)
        {
            return new MovementResult.Failure();
        }

        train.PassDistance(Length, accuracy);

        return new MovementResult.Success(train.TravelTime);
    }
}