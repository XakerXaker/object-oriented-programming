using ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.Repository;

public class SubjectRepository
{
    private readonly List<ISubject> data = [];

    public void Add(ISubject subject)
    {
        data.Add(subject);
    }

    public ISubject? SearchById(ISubject subject)
    {
        foreach (ISubject s in data)
        {
            if (s == subject) return s;
        }

        return null;
    }
}