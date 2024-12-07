using System.Drawing;

namespace ITMO.ObjectOrientedProgramming.Lab3.Receivers.Displays.DisplayDrivers;

public class FileDisplayDriver : IDisplayDriver
{
    private readonly string _path = "output.txt";

    public void Clear()
    {
        File.WriteAllText(_path, string.Empty);
    }

    public void WriteText(string text)
    {
        File.WriteAllText(_path, text);
    }

    public void SetColor(Color color, string text)
    {
        string lcolor = $"Color: {color.ToString()}";
        string temp = text;
        text = lcolor + temp;
    }
}