using ITMO.ObjectOrientedProgramming.Lab1.Entities;
using ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

using ITMO.ObjectOrientedProgramming.Lab1.Models;

using Xunit;

namespace Lab1.Tests;

public class SimulationTest
{
    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesTrainToPermissibleRouteSpeed()
    {
        var expectedResult = new MovementResult.Success();
        MovementResult simulationResult = new MovementResult.Success();
        var train = new Train(1, 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(2048, 1, null),
            new MagneticPath(1000, new PowerModule(1416)),
        };

        foreach (IPathSegment path in route)
        {
            if (simulationResult is MovementResult.Success)
            {
                simulationResult = path.MoveTrain(train, 4);
            }
        }

        Assert.Equal(simulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesTrainOverRoutePermissibleRouteSpeed()
    {
        var expectedResult = new MovementResult.Failure();
        MovementResult simulationResult = new MovementResult.Success();
        var train = new Train(1, 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(2048, 1, null),
            new MagneticPath(1000,  new PowerModule(63)),
        };

        foreach (IPathSegment path in route)
        {
            if (simulationResult is MovementResult.Success)
            {
                simulationResult = path.MoveTrain(train, 4);
            }
        }

        Assert.Equal(simulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesTrainToPermissibleRouteAndStationSpeed()
    {
        var expectedResult = new MovementResult.Success();
        MovementResult simulationResult = new MovementResult.Success();
        var train = new Train(1, 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(2048, 1, null),
            new MagneticPath(1000, null),
            new Station(1000, 60, new PowerModule(10000)),
            new MagneticPath(1000, new PowerModule(1000)),
        };

        foreach (IPathSegment path in route)
        {
            if (simulationResult is MovementResult.Success)
            {
                simulationResult = path.MoveTrain(train, 4);
            }
        }

        Assert.Equal(simulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesTrainOverPermissibleStationSpeed()
    {
        var expectedResult = new MovementResult.Failure();
        MovementResult simulationResult = new MovementResult.Success();
        var train = new Train(1, 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(2048, 1, null),
            new Station(1000, 60, new PowerModule(63)),
            new MagneticPath(1000, new PowerModule(100000)),
        };

        foreach (IPathSegment path in route)
        {
            if (simulationResult is MovementResult.Success)
            {
                simulationResult = path.MoveTrain(train, 4);
            }
        }

        Assert.Equal(simulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesTrainToPermissibleStationSpeedButOverPermissibleRouteSpeed()
    {
        var expectedResult = new MovementResult.Failure();
        MovementResult simulationResult = new MovementResult.Success();
        var train = new Train(1, 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(2048, 1, null),
            new MagneticPath(1000, null),
            new Station(1000, 60, new PowerModule(1000000)),
            new MagneticPath(1000, new PowerModule(10)),
        };

        foreach (IPathSegment path in route)
        {
            if (simulationResult is MovementResult.Success)
            {
                simulationResult = path.MoveTrain(train, 4);
            }
        }

        Assert.Equal(simulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesTrainOverPermissibleSpeedAndSlowsDownToPermissibleSpeed()
    {
        var expectedResult = new MovementResult.Success();
        MovementResult simulationResult = new MovementResult.Success();
        var train = new Train(1, 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(2048, 1, null),
            new MagneticPath(1000, null),
            new ForcePath(2048, -1, null),
            new Station(1000, 60, new PowerModule(63)),
            new MagneticPath(1000, null),
            new ForcePath(2048, 1, null),
            new MagneticPath(1000, null),
            new ForcePath(100, -10, new PowerModule(63)),
        };

        foreach (IPathSegment path in route)
        {
            if (simulationResult is MovementResult.Success)
            {
                simulationResult = path.MoveTrain(train, 4);
            }
        }

        Assert.Equal(simulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenTrainStartsFromMagneticPath()
    {
        var expectedResult = new MovementResult.Failure();
        MovementResult simulationResult = new MovementResult.Success();
        var train = new Train(1, 1);
        var route = new List<IPathSegment>()
        {
            new MagneticPath(1000, new PowerModule(100000)),
        };

        foreach (IPathSegment path in route)
        {
            if (simulationResult is MovementResult.Success)
            {
                simulationResult = path.MoveTrain(train, 4);
            }
        }

        Assert.Equal(simulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesAndSlowsDown()
    {
        var expectedResult = new MovementResult.Failure();
        MovementResult simulationResult = new MovementResult.Success();
        var train = new Train(1, 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(2000, 1, null),
            new ForcePath(2000, -2, new PowerModule(20000)),
        };

        foreach (IPathSegment path in route)
        {
            if (simulationResult is MovementResult.Success)
            {
                simulationResult = path.MoveTrain(train, 4);
            }
        }

        Assert.Equal(simulationResult, expectedResult);
    }
}