using ITMO.ObjectOrientedProgramming.Lab3.Receivers.Displays.DisplayDrivers;
using System.Drawing;

namespace ITMO.ObjectOrientedProgramming.Lab3.Receivers.Displays;

public class Display
{
    private readonly IDisplayDriver _displayDriver;
    private readonly Color _color = Color.Black;

    public Display(Color color, IDisplayDriver displayDriver)
    {
        _color = color;
        _displayDriver = displayDriver;
    }

    public void ShowMessage(string message)
    {
        _displayDriver.Clear();
        _displayDriver.SetColor(_color, message);

        _displayDriver.WriteText(message);
    }
}