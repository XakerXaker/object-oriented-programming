namespace ITMO.ObjectOrientedProgramming.Lab3.Receivers.Displays.Output;

public class FileOutput : IOutput
{
    public void Render(string message)
    {
        using var writer = new StreamWriter("output.txt");
        writer.WriteLine(message);
    }
}