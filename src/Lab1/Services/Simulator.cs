using ITMO.ObjectOrientedProgramming.Lab1.Entities;
using ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

namespace ITMO.ObjectOrientedProgramming.Lab1.Services;

public class Simulator
{
    public MovementResult SimulationResult { get; private set; }

    private readonly Time _accuracy;
    private readonly List<IPathSegment> _route;

    private readonly Train _train;

    public Simulator(Train train, IEnumerable<IPathSegment> route, Time accuracy)
    {
        _train = train;
        _route = new List<IPathSegment>(route);
        _accuracy = accuracy;
        SimulationResult = new MovementResult.Success(new Time(0));
    }

    public void Simulate()
    {
        foreach (IPathSegment path in _route)
        {
            if (path.MoveTrain(_train, _accuracy) is MovementResult.Failure)
            {
                SimulationResult = new MovementResult.Failure();
                return;
            }
        }

        SimulationResult = new MovementResult.Success(_train.TravelTime);
    }
}