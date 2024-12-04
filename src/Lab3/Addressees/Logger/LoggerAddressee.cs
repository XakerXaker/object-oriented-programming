using ITMO.ObjectOrientedProgramming.Lab3.Messages;

namespace ITMO.ObjectOrientedProgramming.Lab3.Addressees.Logger;

public class LoggerAddressee : IAddressee
{
    private readonly IAddressee _addressee;

    private readonly ILogger _logger;

    public LoggerAddressee(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void SendMessage(Message message)
    {
        _addressee.SendMessage(message);
        _logger.Log(CreateLogMessage(message));
    }

    public string CreateLogMessage(Message message)
    {
        string localMessage = string.Empty;
        string header = message.Head;
        if (_addressee is DisplayAddressee)
        {
           localMessage = $"The message with header: {header} has been sent to Display addressee";
        }
        else if (_addressee is MessengerAddressee)
        {
           localMessage = $"The message with header: {header} has been sent to Messenger addressee";
        }

        if (_addressee is UserAddressee)
        {
           localMessage = $"The message with header: {header} has been sent to User addressee";
        }

        return localMessage;
    }
}