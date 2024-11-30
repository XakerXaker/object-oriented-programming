namespace ITMO.ObjectOrientedProgramming.Lab3.Receivers.Messengers.Output;

public class ConsoleOutput : IOutputStream
{
    public void Render(string message)
    {
        Console.WriteLine(message);
    }
}