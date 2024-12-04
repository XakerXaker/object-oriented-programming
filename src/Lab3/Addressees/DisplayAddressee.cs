using ITMO.ObjectOrientedProgramming.Lab3.Messages;
using ITMO.ObjectOrientedProgramming.Lab3.Receivers.Displays;

namespace ITMO.ObjectOrientedProgramming.Lab3.Addressees;

public class DisplayAddressee : IAddressee
{
    private readonly Display _display;

    public DisplayAddressee(Display display)
    {
        _display = display;
    }

    public void SendMessage(Message message)
    {
        string lmessage = $"{message.Head}: {message.Body}";
        _display.ShowMessage(lmessage);
    }
}