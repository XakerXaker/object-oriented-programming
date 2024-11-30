using ITMO.ObjectOrientedProgramming.Lab3.Addressees;
using ITMO.ObjectOrientedProgramming.Lab3.Messages;

namespace ITMO.ObjectOrientedProgramming.Lab3.Topics;

public class Topic
{
    public static Builder Build => new Builder();

    private readonly IEnumerable<IAddressee> _addressees;

    public string Name { get; init; }

    private Topic(string name, IEnumerable<IAddressee> addressees)
    {
        Name = name;
        _addressees = addressees;
    }

    public void SendMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.GetMessage(message);
        }
    }

    public class Builder
    {
        private readonly List<IAddressee> _addressee = [];
        private string _name = string.Empty;

        public Builder AddAddressee(IAddressee addressee)
        {
            _addressee.Add(addressee);
            return this;
        }

        public Builder AddName(string name)
        {
            _name = name;
            return this;
        }

        public Topic Build()
        {
            return new Topic(_name, _addressee);
        }
    }
}