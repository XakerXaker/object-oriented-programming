using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;
using ITMO.ObjectOrientedProgramming.Lab2.LectureModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;

public class ExamSubject : ISubject
{
    public Guid? ParentId { get; init; }

    public Guid Id { get; init; }

    public Guid AuthorId { get; init; }

    private readonly IEnumerable<Labwork> _labworks = [];

    public IEnumerable<MaterialForLecture> Lectures { get; set; }

    public double PointsForExam { get; init; }

    public ExamSubject(Guid? parentId, Guid authorId, IEnumerable<Labwork> labworks, IEnumerable<MaterialForLecture> lectures, double pointsForExam)
    {
        ParentId = parentId;
        AuthorId = authorId;
        Id = Guid.NewGuid();
        _labworks = labworks;
        Lectures = lectures;
        PointsForExam = pointsForExam;
    }

    public ExamSubject Clone()
    {
        return new(Id, AuthorId, _labworks, Lectures, PointsForExam);
    }
}