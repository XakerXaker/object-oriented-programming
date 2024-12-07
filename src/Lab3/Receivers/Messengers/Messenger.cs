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

    public void ReceiveMessage(string message)
    {
        string lmessage = $"{_prefix}: {message}";
        ShowMessage(lmessage);
    }

    public void ShowMessage(string message)
    {
        _output.Render(message);
    }
}