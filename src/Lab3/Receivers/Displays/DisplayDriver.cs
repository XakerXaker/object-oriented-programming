using System.Drawing;

namespace ITMO.ObjectOrientedProgramming.Lab3.Receivers.Displays;

public class DisplayDriver
{
    private string _buffer = string.Empty;

    public void Clear()
    {
        _buffer = string.Empty;
    }

    public void WriteText(string text)
    {
        _buffer = text;
    }

    public void SetColor(Color color)
    {
        _buffer = Crayon.Output.Rgb(color.R, color.G, color.B).Text(_buffer);
    }
}