global using ITMO.ObjectOrientedProgramming.Lab1.Models;

namespace ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

public class Station : IPathSegment
{
    private readonly int _trainStopTime;

    public double Length { get; init; }

    public PowerModule? PowerModule { get; init; }

    public Station(double length, int trainStopTime, PowerModule powerModule)
    {
        _trainStopTime = trainStopTime;
        Length = length;
        PowerModule = powerModule;
    }

    public MovementResult MoveTrain(Train train, int accuracy)
    {
        if (PowerModule is not null && train.Speed > PowerModule.SpeedLimit)
        {
            return new MovementResult.Failure();
        }

        train.PassDistance(Length, accuracy);
        train.TravelTime += _trainStopTime;

        return new MovementResult.Success();
    }
}