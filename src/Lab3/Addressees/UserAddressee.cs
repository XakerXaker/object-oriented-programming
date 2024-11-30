using ITMO.ObjectOrientedProgramming.Lab3.Messages;
using ITMO.ObjectOrientedProgramming.Lab3.Receivers.Users;

namespace ITMO.ObjectOrientedProgramming.Lab3.Addressees;

public class UserAddressee : IAddressee
{
    private readonly User _user;

    public UserAddressee(User user)
    {
        _user = user;
    }

    public void GetMessage(Message message)
    {
        _user.GetMessage(message);
    }
}