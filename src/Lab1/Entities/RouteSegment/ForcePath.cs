namespace ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

public class ForcePath : IPathSegment
{
    private readonly double _forceValue;

    public Length Length { get; init; }

    public PowerModule? PowerModule { get; init; }

    public ForcePath(Length length, double forceValue, PowerModule? powerModule)
    {
        _forceValue = forceValue;
        PowerModule = powerModule;
        Length = length;
    }

    public MovementResult MoveTrain(Train train, Time accuracy)
    {
        if (!train.IsForceAcceptable(_forceValue))
        {
            return new MovementResult.Failure();
        }
        else
        {
            train.ApplyForce(_forceValue);
            train.PassDistance(Length, accuracy);
            train.ResetAcceleration();

            if (PowerModule is not null && train.Speed > PowerModule.SpeedLimit)
            {
                return new MovementResult.Failure();
            }

            if (train.Speed < 0)
            {
                return new MovementResult.Failure();
            }

            return new MovementResult.Success(train.TravelTime);
        }
    }
}