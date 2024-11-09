using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;
using ITMO.ObjectOrientedProgramming.Lab2.LectureModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;

public class CreditSubjectBuilder
{
    private readonly List<Labwork> _labworks = [];

    private readonly List<MaterialForLecture> _lectures = [];

    private Guid _authorId;
    private double _pointsForCredit;

    public CreditSubjectBuilder AddAuthor(Guid authorId)
    {
        _authorId = authorId;
        return this;
    }

    public CreditSubjectBuilder AddLabwork(Labwork labwork)
    {
        if (labwork is null) throw new Exception("Invalid Subject creation");
        _labworks.Add(labwork);
        return this;
    }

    public CreditSubjectBuilder AddLecture(MaterialForLecture lecture)
    {
        if (lecture is null) throw new Exception("Invalid Subject creation");
        _lectures.Add(lecture);
        return this;
    }

    public CreditSubjectBuilder AddControlPoint(double pointsForCredit)
    {
        if (pointsForCredit <= 0) throw new Exception("Invalid Subject creation");
        _pointsForCredit = pointsForCredit;
        return this;
    }

    public CreditSubject Build()
    {
        return new CreditSubject(
            null,
            _authorId,
            _labworks,
            _lectures,
            _pointsForCredit);
    }
}