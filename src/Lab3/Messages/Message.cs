namespace ITMO.ObjectOrientedProgramming.Lab3.Messages;

public record Message : IEquatable<Message>
{
    public string Head { get; init; }

    public string Body { get; init; }

    public ImportanceLevel ImportanceLevel { get; init; }

    public Message(string head, string body, ImportanceLevel importanceLevel)
    {
        Head = head;
        Body = body;
        ImportanceLevel = importanceLevel;
    }
}