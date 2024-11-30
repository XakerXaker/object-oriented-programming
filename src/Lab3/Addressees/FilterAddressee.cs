using ITMO.ObjectOrientedProgramming.Lab3.Messages;

namespace ITMO.ObjectOrientedProgramming.Lab3.Addressees;

public class FilterAddressee : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ImportanceLevel _acceptableImportance;

    public FilterAddressee(IAddressee addressee, ImportanceLevel acceptableImportance)
    {
        _addressee = addressee;
        _acceptableImportance = acceptableImportance;
    }

    public void GetMessage(Message message)
    {
        if (message.ImportanceLevel >= _acceptableImportance)
        {
            _addressee.GetMessage(message);
        }
    }
}