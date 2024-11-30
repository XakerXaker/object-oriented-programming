namespace ITMO.ObjectOrientedProgramming.Lab3.Addressees.Logger;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
