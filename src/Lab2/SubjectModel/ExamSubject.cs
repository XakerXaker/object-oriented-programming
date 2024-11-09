using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;
using ITMO.ObjectOrientedProgramming.Lab2.LectureModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;

public class ExamSubject : ISubject
{
    public Guid? ParentId { get; init; }

    public Guid Id { get; init; }

    public Guid AuthorId { get; init; }

    private readonly List<Labwork> _labworks = [];

    private readonly List<MaterialForLecture> _lectures = [];

    public double PointsForExam { get; private set; }

    public ExamSubject(Guid? parentId, Guid authorId, IEnumerable<Labwork> labworks, IEnumerable<MaterialForLecture> lectures, double pointsForExam)
    {
        ParentId = parentId;
        AuthorId = authorId;
        Id = Guid.NewGuid();
        _labworks = labworks.ToList();
        _lectures = lectures.ToList();
        PointsForExam = pointsForExam;
    }

    public ExamSubject Clone()
    {
        return new(Id, AuthorId, _labworks, _lectures, PointsForExam);
    }
}