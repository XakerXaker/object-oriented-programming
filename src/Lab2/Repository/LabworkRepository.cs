using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.Repository;

public class LabworkRepository
{
    private readonly List<Labwork> data = [];

    public void Add(Labwork lab)
    {
        data.Add(lab);
    }

    public Labwork? SearchById(Labwork lab)
    {
        foreach (Labwork l in data)
        {
            if (l.Id == lab.Id) return l;
        }

        return null;
    }
}