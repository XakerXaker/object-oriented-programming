namespace ITMO.ObjectOrientedProgramming.Lab3.Receivers.Displays.Output;

public class ConsoleOutput : IOutput
{
    public void Render(string message)
    {
        Console.WriteLine(message);
    }
}