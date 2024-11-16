using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;
using ITMO.ObjectOrientedProgramming.Lab2.LectureModel;
using ITMO.ObjectOrientedProgramming.Lab2.UserModel;
using ITMO.ObjectOrientedProgramming.Lab2.ValueObject;

namespace ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;

public class ExamSubjectBuilder
{
    private readonly User _user;
    private IEnumerable<Labwork> _labworks = [];

    private IEnumerable<MaterialForLecture> _lectures = [];

    private Guid? _parentId;

    private Points? _pointsForExam;

    public ExamSubjectBuilder AddParentId(Guid? parentId)
    {
        _parentId = parentId;
        return this;
    }

    public ExamSubjectBuilder AddLabwork(IEnumerable<Labwork> labworks)
    {
        if (labworks is null) throw new Exception("Invalid Subject creation");
        _labworks = labworks;
        return this;
    }

    public ExamSubjectBuilder AddLecture(IEnumerable<MaterialForLecture> lectures)
    {
        if (lectures is null) throw new Exception("Invalid Subject creation");
        _lectures = lectures;
        return this;
    }

    public ExamSubjectBuilder AddControlPoint(Points pointsForExam)
    {
        _pointsForExam = pointsForExam;
        return this;
    }

    public ExamSubject Build()
    {
        if (_pointsForExam is null) throw new Exception("Invalid Subject creation");

        double totalPoints = _pointsForExam.Value;
        foreach (Labwork lab in _labworks)
        {
            totalPoints += lab.Points.Value;
        }

        if (totalPoints != 100) throw new Exception("Invalid Subject creation");

        return new ExamSubject(
            _parentId,
            _user.Id,
            _labworks,
            _lectures,
            _pointsForExam);
    }

    public ExamSubjectBuilder(User user)
    {
        _user = user;
    }
}