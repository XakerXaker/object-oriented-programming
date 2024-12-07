using ITMO.ObjectOrientedProgramming.Lab3.Messages;

namespace ITMO.ObjectOrientedProgramming.Lab3.Receivers.Users;

public class User
{
    public Dictionary<Message, bool> Messages { get; init; } = [];

    public string Name { get; init; }

    public User(string name)
    {
        Name = name;
    }

    public void ReceiveMessage(Message message)
    {
        Messages.Add(message, false);
    }

    public ReadMessageOperation MarkAsRead(Message message)
    {
        Messages.TryGetValue(message, out bool status);
        Messages[message] = true;

        return status == true ? new ReadMessageOperation.Failure() : new ReadMessageOperation.Success();
    }
}