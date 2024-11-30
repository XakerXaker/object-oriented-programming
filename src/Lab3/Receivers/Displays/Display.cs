using ITMO.ObjectOrientedProgramming.Lab3.Messages;
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

    public void ShowMessage(Message message)
    {
        _displayDriver.Clear();
        _displayDriver.SetColor(_color);

        string localMessage = message.Head + '\n' + message.Body;
        _displayDriver.WriteText(localMessage);
    }
}