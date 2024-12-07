using System.Drawing;

namespace ITMO.ObjectOrientedProgramming.Lab3.Receivers.Displays.DisplayDrivers;

public class ConsoleDisplayDriver : IDisplayDriver
{
    public void Clear()
    {
        Console.Clear();
    }

    public void WriteText(string text)
    {
        Console.WriteLine(text);
    }

    public void SetColor(Color color, string text)
    {
        text = Crayon.Output.Rgb(color.R, color.G, color.B).Text(text);
    }
}