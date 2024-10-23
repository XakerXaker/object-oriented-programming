using ITMO.ObjectOrientedProgramming.Lab1.Entities;

using ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

namespace ITMO.ObjectOrientedProgramming.Lab1.Services;

public class Simulator
{
    private readonly int accuracy;
    private readonly List<PathSegment> route;

    private readonly Train train;
    private int travelTime;

    public MovementResult SimulationResult { get; private set; }

    public Simulator(Train train, IEnumerable<PathSegment> route, int accuracy)
    {
        this.train = train;
        this.route = new List<PathSegment>(route);
        this.accuracy = accuracy;
        travelTime = 0;
        SimulationResult = new MovementResult.Success();
    }

    public void Simulate()
    {
        foreach (PathSegment path in route)
        {
            if (SimulationResult is MovementResult.Success)
            {
                Console.WriteLine("{0}", SimulationResult);
                SimulationResult = path.MoveTrain(train, accuracy);
                travelTime += path.TravelTime;
            }
        }
    }

    public void PrintSimulationResult()
    {
        if (SimulationResult is MovementResult.Success)
        {
            Console.WriteLine("The route has been successfully completed in {0} second", travelTime);
        }
        else
        {
            Console.WriteLine("Failed to complete the route");
        }
    }
}