global using ITMO.ObjectOrientedProgramming.Lab1.Models;

namespace ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

public class Station : IPathSegment
{
    private readonly Time _trainStopTime;

    public Length Length { get; init; }

    public PowerModule? PowerModule { get; init; }

    public Station(Length length, Time trainStopTime, PowerModule powerModule)
    {
        _trainStopTime = trainStopTime;
        Length = length;
        PowerModule = powerModule;
    }

    public MovementResult MoveTrain(Train train, Time accuracy)
    {
        if (PowerModule is not null && train.Speed > PowerModule.SpeedLimit)
        {
            return new MovementResult.Failure();
        }

        train.PassDistance(Length, accuracy);
        train.TravelTime.Value += _trainStopTime.Value;

        return new MovementResult.Success(train.TravelTime);
    }
}