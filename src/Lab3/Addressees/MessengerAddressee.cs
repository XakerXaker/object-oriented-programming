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

    public void SendMessage(Message message)
    {
        string lmessage = $"{message.Head}: {message.Body}";
        _messenger.ReceiveMessage(lmessage);
    }
}