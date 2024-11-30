using ITMO.ObjectOrientedProgramming.Lab3.Messages;

namespace ITMO.ObjectOrientedProgramming.Lab3.Addressees;

public class GroupAddressee : IAddressee
{
    private readonly IEnumerable<IAddressee> _addressees;

    public GroupAddressee(IEnumerable<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void GetMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.GetMessage(message);
        }
    }
}