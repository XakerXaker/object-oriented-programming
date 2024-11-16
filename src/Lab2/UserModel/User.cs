namespace ITMO.ObjectOrientedProgramming.Lab2.UserModel;

public class User
{
    public Guid Id { get; init; }

    public User()
    {
        Id = Guid.NewGuid();
    }
}