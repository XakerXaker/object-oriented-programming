using ITMO.ObjectOrientedProgramming.Lab3.Messages;

namespace ITMO.ObjectOrientedProgramming.Lab3.Addressees;

public interface IAddressee
{
    public void GetMessage(Message message);
}