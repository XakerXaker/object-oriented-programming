using System.Drawing;

namespace ITMO.ObjectOrientedProgramming.Lab3.Receivers.Displays.DisplayDrivers;

public interface IDisplayDriver
{
    public void Clear();

    public void SetColor(Color color, string text);

    public void WriteText(string text);
}