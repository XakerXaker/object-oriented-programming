using ITMO.ObjectOrientedProgramming.Lab3.Messages;
using ITMO.ObjectOrientedProgramming.Lab3.Receivers.Messengers.Output;

namespace ITMO.ObjectOrientedProgramming.Lab3.Receivers.Messengers;

public class Messenger
{
    private readonly IOutputStream _output;
    private readonly string _prefix = "Messenger";

    public Messenger(IOutputStream output)
    {
        _output = output;
    }

    public void GetMessage(Message message)
    {
        string lmessage = $"{_prefix}: {message.Head} and {message.Body}";
        ShowMessage(lmessage);
    }

    public void ShowMessage(string message)
    {
        _output.Render(message);
    }
}