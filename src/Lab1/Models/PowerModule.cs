namespace ITMO.ObjectOrientedProgramming.Lab1.Models;

public class PowerModule
{
    public int SpeedLimit { get; private set; }

    public PowerModule(int speedLimit)
    {
        SpeedLimit = speedLimit;
    }
}