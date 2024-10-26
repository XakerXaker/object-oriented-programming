namespace ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

public class ForcePath : IPathSegment
{
    private readonly double _forceValue;

    public Length Length { get; init; }

    public PowerModule? PowerModule { get; init; }

    public ForcePath(double length, double forceValue, PowerModule? powerModule)
    {
        _forceValue = forceValue;
        PowerModule = powerModule;
        Length = new Length(length);
    }

    public MovementResult MoveTrain(Train train, int accuracy)
    {
        if (_forceValue > train.MaximumPermissibleForce)
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

            return new MovementResult.Success();
        }
    }
}