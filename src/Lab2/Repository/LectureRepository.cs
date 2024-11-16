using ITMO.ObjectOrientedProgramming.Lab2.LectureModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.Repository;

public class LectureRepository
{
    private readonly List<MaterialForLecture> data = [];

    public void Add(MaterialForLecture lecture)
    {
        data.Add(lecture);
    }

    public MaterialForLecture? SearchById(MaterialForLecture lecture)
    {
        foreach (MaterialForLecture l in data)
        {
            if (l.Id == lecture.Id) return l;
        }

        return null;
    }
}