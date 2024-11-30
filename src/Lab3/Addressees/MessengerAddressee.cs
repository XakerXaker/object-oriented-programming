using ITMO.ObjectOrientedProgramming.Lab3.Messages;
using ITMO.ObjectOrientedProgramming.Lab3.Receivers.Messengers;

namespace ITMO.ObjectOrientedProgramming.Lab3.Addressees;

public class MessengerAddressee : IAddressee
{
    private readonly Messenger _messenger;

    public MessengerAddressee(Messenger messenger)
    {
        _messenger = messenger;
    }

    public void GetMessage(Message message)
    {
        SendMessage(message);
    }

    public void SendMessage(Message message)
    {
        _messenger.GetMessage(message);
    }
}