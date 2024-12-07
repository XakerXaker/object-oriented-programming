using ITMO.ObjectOrientedProgramming.Lab3.Messages;

namespace ITMO.ObjectOrientedProgramming.Lab3.Addressees;

public class GroupAddressee : IAddressee
{
    private readonly IEnumerable<IAddressee> _addressees;

    public GroupAddressee(IEnumerable<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void SendMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.SendMessage(message);
        }
    }
}