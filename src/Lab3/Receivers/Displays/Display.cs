using System.Drawing;

namespace ITMO.ObjectOrientedProgramming.Lab3.Receivers.Displays;

public class Display
{
    private readonly DisplayDriver _displayDriver = new DisplayDriver();
    private readonly Color _color = Color.Black;

    public Display(Color color)
    {
        _color = color;
    }

    public void ShowMessage(string message)
    {
        _displayDriver.Clear();
        _displayDriver.SetColor(_color);

        _displayDriver.WriteText(message);
    }
}