namespace ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

public class MagneticPath : IPathSegment
{
    public double Length { get; init; }

    public PowerModule? PowerModule { get; init; }

    public MagneticPath(double length, PowerModule? powerModule)
    {
        if (length < 0) throw new Exception("length cannot be negative");
        Length = length;
        PowerModule = powerModule;
    }

    public MovementResult MoveTrain(Train train, int accuracy)
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

        return new MovementResult.Success();
    }
}