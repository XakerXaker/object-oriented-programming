using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;
using ITMO.ObjectOrientedProgramming.Lab2.LectureModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;

public class ExamSubjectBuilder
{
    public Guid? ParentId { get; init; }

    public Guid AuthorId { get; private set; }

    private readonly List<Labwork> _labworks = [];

    private readonly List<MaterialForLecture> _lectures = [];
    private double _pointsForExam;

    public ExamSubjectBuilder AddAuthor(Guid authorId)
    {
        AuthorId = authorId;
        return this;
    }

    public ExamSubjectBuilder AddLabwork(Labwork labwork)
    {
        if (labwork is null) throw new Exception("Invalid Subject creation");
        _labworks.Add(labwork);
        return this;
    }

    public ExamSubjectBuilder AddLecture(MaterialForLecture lecture)
    {
        if (lecture is null) throw new Exception("Invalid Subject creation");
        _lectures.Add(lecture);
        return this;
    }

    public ExamSubjectBuilder AddControlPoint(double pointsForExam)
    {
        if (pointsForExam <= 0) throw new Exception("Invalid Subject creation");
        _pointsForExam = pointsForExam;
        return this;
    }

    public ExamSubject Build()
    {
        double totalPoints = _pointsForExam;
        foreach (Labwork lab in _labworks)
        {
            totalPoints += lab.Point;
        }

        if (totalPoints != 100) throw new Exception("Invalid Subject creation");

        return new ExamSubject(
            null,
            AuthorId,
            _labworks,
            _lectures,
            _pointsForExam);
    }
}