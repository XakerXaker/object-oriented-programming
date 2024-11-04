using ITMO.ObjectOrientedProgramming.Lab1.Entities;
using ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

using ITMO.ObjectOrientedProgramming.Lab1.Models;
using ITMO.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Lab1.Tests;

public class SimulationTest
{
    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesTrainToPermissibleRouteSpeed()
    {
        var expectedResult = new MovementResult.Success(new Time(80));
        var accuracy = new Time(4);
        var train = new Train(new Mass(1), 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(new Length(2048), 1, null),
            new MagneticPath(new Length(1000), new PowerModule(1416)),
        };
        var simulator = new Simulator(train, route, accuracy);

        simulator.Simulate();

        Assert.Equal(simulator.SimulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesTrainOverRoutePermissibleRouteSpeed()
    {
        var expectedResult = new MovementResult.Failure();
        var accuracy = new Time(4);
        var train = new Train(new Mass(1), 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(new Length(2048), 1, null),
            new MagneticPath(new Length(1000),  new PowerModule(63)),
        };

        var simulator = new Simulator(train, route, accuracy);

        simulator.Simulate();

        Assert.Equal(simulator.SimulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesTrainToPermissibleRouteAndStationSpeed()
    {
        var expectedResult = new MovementResult.Success(new Time(172));
        var accuracy = new Time(4);
        var train = new Train(new Mass(1), 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(new Length(2048), 1, null),
            new MagneticPath(new Length(1000), null),
            new Station(new Length(1000), new Time(60), new PowerModule(10000)),
            new MagneticPath(new Length(1000), new PowerModule(1000)),
        };

        var simulator = new Simulator(train, route, accuracy);

        simulator.Simulate();

        Assert.Equal(simulator.SimulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesTrainOverPermissibleStationSpeed()
    {
        var expectedResult = new MovementResult.Failure();
        var accuracy = new Time(4);
        var train = new Train(new Mass(1), 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(new Length(2048), 1, null),
            new Station(new Length(1000), new Time(60), new PowerModule(63)),
            new MagneticPath(new Length(1000), new PowerModule(100000)),
        };

        var simulator = new Simulator(train, route, accuracy);

        simulator.Simulate();

        Assert.Equal(simulator.SimulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesTrainToPermissibleStationSpeedButOverPermissibleRouteSpeed()
    {
        var expectedResult = new MovementResult.Failure();
        var accuracy = new Time(4);
        var train = new Train(new Mass(1), 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(new Length(2048), 1, null),
            new MagneticPath(new Length(1000), null),
            new Station(new Length(1000), new Time(60), new PowerModule(1000000)),
            new MagneticPath(new Length(1000), new PowerModule(10)),
        };
        var simulator = new Simulator(train, route, accuracy);

        simulator.Simulate();

        Assert.Equal(simulator.SimulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesTrainOverPermissibleSpeedAndSlowsDownToPermissibleSpeed()
    {
        var expectedResult = new MovementResult.Success(new Time(388));
        var accuracy = new Time(4);
        var train = new Train(new Mass(1), 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(new Length(2048), 1, null),
            new MagneticPath(new Length(1000), null),
            new ForcePath(new Length(2048), -1, null),
            new Station(new Length(1000), new Time(60), new PowerModule(63)),
            new MagneticPath(new Length(1000), null),
            new ForcePath(new Length(2048), 1, null),
            new MagneticPath(new Length(1000), null),
            new ForcePath(new Length(100), -10, new PowerModule(63)),
        };

        var simulator = new Simulator(train, route, accuracy);

        simulator.Simulate();

        Assert.Equal(simulator.SimulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenTrainStartsFromMagneticPath()
    {
        var expectedResult = new MovementResult.Failure();
        var accuracy = new Time(4);
        var train = new Train(new Mass(1), 1);
        var route = new List<IPathSegment>()
        {
            new MagneticPath(new Length(1000), new PowerModule(100000)),
        };

        var simulator = new Simulator(train, route, accuracy);

        simulator.Simulate();

        Assert.Equal(simulator.SimulationResult, expectedResult);
    }

    [Fact]
    public void Simulate_ShouldReturnResultOfSimulation_WhenForcePathAcceleratesAndSlowsDown()
    {
        var expectedResult = new MovementResult.Failure();
        var accuracy = new Time(4);
        var train = new Train(new Mass(1), 1);
        var route = new List<IPathSegment>()
        {
            new ForcePath(new Length(2000), 1, null),
            new ForcePath(new Length(2000), -2, new PowerModule(20000)),
        };
        var simulator = new Simulator(train, route, accuracy);

        simulator.Simulate();

        Assert.Equal(simulator.SimulationResult, expectedResult);
    }
}