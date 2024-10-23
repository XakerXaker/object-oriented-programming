global using ITMO.ObjectOrientedProgramming.Lab1.Models;

namespace ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

public class Station : PathSegment
{
    private readonly int timeToIn;

    public Station(double lenght, int timeToIn, PowerModule powerModule) : base(lenght, powerModule)
    {
        this.timeToIn = timeToIn;
    }

    public override MovementResult MoveTrain(Train train, int accuracy)
    {
        if (PowerModule is not null && train.Speed > PowerModule.SpeedLimit)
        {
            return new MovementResult.Failure();
        }

        double distanseTravelled = 0;
        while (true)
        {
            distanseTravelled += train.Speed * accuracy;
            TravelTime += accuracy;
            if (Length - distanseTravelled <= 0)
            {
                TravelTime += timeToIn;
                break;
            }
        }

        return new MovementResult.Success();
    }
}