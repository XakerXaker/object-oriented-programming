namespace ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

public class ForcePath : IPathSegment
{
    private readonly double _forceValue;

    public double Length { get; init; }

    public PowerModule? PowerModule { get; init; }

    public ForcePath(double length, double forceValue, PowerModule? powerModule)
    {
        if (length < 0) throw new Exception("length cannot be negative");
        _forceValue = forceValue;
        PowerModule = powerModule;
        Length = length;
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