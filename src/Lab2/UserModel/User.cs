using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.UserModel;

public class User
{
    public Guid Id { get; init; }

    public User()
    {
        Id = Guid.NewGuid();
    }

    public void ChangeLab(Labwork lab)
    {
        if (Id != lab.AuthorId) throw new Exception("Not accessible");
    }
}