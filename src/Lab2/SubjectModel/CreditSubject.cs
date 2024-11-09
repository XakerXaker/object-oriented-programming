using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;
using ITMO.ObjectOrientedProgramming.Lab2.LectureModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;

public class CreditSubject : ISubject
{
    public Guid? ParentId { get; init; }

    public Guid Id { get; init; }

    public Guid AuthorId { get; init; }

    private readonly List<Labwork> _labworks = [];

    private readonly List<MaterialForLecture> _lectures;

    public double PointsForCredit { get; private set; }

    public CreditSubject(Guid? parentId, Guid authorId, IEnumerable<Labwork> labworks, IEnumerable<MaterialForLecture> lectures, double pointsForCredit)
    {
        ParentId = parentId;
        Id = Guid.NewGuid();
        AuthorId = authorId;
        _labworks = labworks.ToList();
        _lectures = lectures.ToList();
        PointsForCredit = pointsForCredit;
    }

    public CreditSubject Clone()
    {
        return new(Id, AuthorId, _labworks, _lectures, PointsForCredit);
    }
}