using ITMO.ObjectOrientedProgramming.Lab3.Addressees;
using ITMO.ObjectOrientedProgramming.Lab3.Addressees.Logger;
using ITMO.ObjectOrientedProgramming.Lab3.Messages;
using ITMO.ObjectOrientedProgramming.Lab3.Receivers.Messengers;
using ITMO.ObjectOrientedProgramming.Lab3.Receivers.Messengers.Output;
using ITMO.ObjectOrientedProgramming.Lab3.Receivers.Users;

using Moq;

using Xunit;

namespace Lab3.Tests;

public class MessageSendingTest
{
    [Fact]
    public void GetUnseenMessageStatus()
    {
        var user = new User("Test");
        var message = new Message("head", "body", ImportanceLevel.MEDIUM);
        bool messageIsRead = false;

        user.ReceiveMessage(message);
        Assert.Equal(messageIsRead, user.Messages[message]);
    }

    [Fact]
    public void MarkUnseenMessageAsRead()
    {
        var user = new User("Test");
        var message = new Message("head", "body", ImportanceLevel.MEDIUM);
        var readMessageOperation = new ReadMessageOperation.Success();

        user.ReceiveMessage(message);
        ReadMessageOperation markAsRead = user.MarkAsRead(message);

        Assert.Equal(readMessageOperation, markAsRead);
    }

    [Fact]
    public void SentMessageWithLowerImportanceToAddressee()
    {
        var mockAddressee = new Mock<IAddressee>();
        var filterAddressee = new FilterAddressee(mockAddressee.Object, ImportanceLevel.MEDIUM);
        var message = new Message("head", "body", ImportanceLevel.LOW);

        filterAddressee.SendMessage(message);

        mockAddressee.Verify(x => x.SendMessage(message), Times.Never());
    }

    [Fact]
    public void LogMessageSending()
    {
        var user = new User("Test");
        var addressee = new UserAddressee(user);
        var mockLogger = new Mock<ILogger>();
        var loggerAddressee = new LoggerAddressee(addressee, mockLogger.Object);
        var message = new Message("head", "body", ImportanceLevel.LOW);

        loggerAddressee.SendMessage(message);

        mockLogger.Verify(x => x.Log($"The message with header: {message.Head} has been sent to User addressee"));
    }

    [Fact]
    public void MessengerProccessingMessage()
    {
        var mockOutput = new Mock<IOutputStream>();
        var messenger = new Messenger(mockOutput.Object);
        var message = new Message("head", "body", ImportanceLevel.LOW);
        var messengerAddressee = new MessengerAddressee(messenger);

        messengerAddressee.SendMessage(message);

        mockOutput.Verify(x => x.Render($"Messenger: {message.Head}: {message.Body}"));
    }

    [Fact]
    public void SendindMessageToUserFromTwoUserAddressees()
    {
        var user = new User("Test");
        var message = new Message("head", "body", ImportanceLevel.LOW);
        var firstAddressee = new UserAddressee(user);
        var secondAddressee = new UserAddressee(user);
        var filterAddressee = new FilterAddressee(secondAddressee, ImportanceLevel.MEDIUM);

        filterAddressee.SendMessage(message);
        bool firstSearchResult = user.Messages.ContainsKey(message);
        firstAddressee.SendMessage(message);
        bool secondSearchResult = user.Messages.ContainsKey(message);

        Assert.False(firstSearchResult);
        Assert.True(secondSearchResult);
    }
}