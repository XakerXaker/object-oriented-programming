using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;
using ITMO.ObjectOrientedProgramming.Lab2.LectureModel;
using ITMO.ObjectOrientedProgramming.Lab2.UserModel;
using ITMO.ObjectOrientedProgramming.Lab2.ValueObject;

namespace ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;

public class CreditSubjectBuilder
{
    private readonly User _user;
    private IEnumerable<Labwork> _labworks = [];

    private IEnumerable<MaterialForLecture> _lectures = [];

    private Guid? _parentId;

    private Points? _pointsForCredit;

    public CreditSubjectBuilder AddParentId(Guid? parentId)
    {
        _parentId = parentId;
        return this;
    }

    public CreditSubjectBuilder AddLabwork(IEnumerable<Labwork> labworks)
    {
        if (labworks is null) throw new Exception("Invalid Subject creation");
        _labworks = labworks;
        return this;
    }

    public CreditSubjectBuilder AddLecture(IEnumerable<MaterialForLecture> lectures)
    {
        if (lectures is null) throw new Exception("Invalid Subject creation");
        _lectures = lectures;
        return this;
    }

    public CreditSubjectBuilder AddControlPoint(Points pointsForCredit)
    {
        _pointsForCredit = pointsForCredit;
        return this;
    }

    public CreditSubject Build()
    {
        if (_pointsForCredit is null)
        {
            throw new Exception("Ivalid Subject creation");
        }

        double totalPoints = _pointsForCredit.Value;
        foreach (Labwork lab in _labworks)
        {
            totalPoints += lab.Points.Value;
        }

        if (totalPoints != 100) throw new Exception("Invalid Subject creation");

        return new CreditSubject(
            _parentId,
            _user.Id,
            _labworks,
            _lectures,
            _pointsForCredit);
    }

    public CreditSubjectBuilder(User user)
    {
        _user = user;
    }
}