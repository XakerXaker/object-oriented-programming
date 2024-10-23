namespace ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

public class MagneticPath : PathSegment
{
    public MagneticPath(double lenght, PowerModule? powerModule) : base(lenght, powerModule) { }

    public override MovementResult MoveTrain(Train train, int accuracy)
    {
        if (train.Speed == 0)
        {
            return new MovementResult.Failure();
        }

        if (PowerModule is not null && PowerModule.SpeedLimit < train.Speed)
        {
            return new MovementResult.Failure();
        }

        double distanseTravelled = 0;
        while (true)
        {
            TravelTime += accuracy;
            distanseTravelled += (double)train.Speed * accuracy;
            if (Length - distanseTravelled <= 0)
            {
                break;
            }
        }

        return new MovementResult.Success();
    }
}