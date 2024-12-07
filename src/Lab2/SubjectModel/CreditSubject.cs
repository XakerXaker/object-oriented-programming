using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;
using ITMO.ObjectOrientedProgramming.Lab2.LectureModel;
using ITMO.ObjectOrientedProgramming.Lab2.UserModel;
using ITMO.ObjectOrientedProgramming.Lab2.ValueObject;

namespace ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;

public class CreditSubject : ISubject
{
    public Guid? ParentId { get; init; }

    public Guid Id { get; init; }

    public Guid? AuthorId { get; init; }

    private readonly IEnumerable<Labwork> _labworks = [];

    private IEnumerable<MaterialForLecture> _lectures;

    public Points PointsForCredit { get; init; }

    public CreditSubject(Guid? parentId, Guid? authorId, IEnumerable<Labwork> labworks, IEnumerable<MaterialForLecture> lectures, Points pointsForCredit)
    {
        ParentId = parentId;
        Id = Guid.NewGuid();
        AuthorId = authorId;
        _labworks = labworks;
        _lectures = lectures;
        PointsForCredit = pointsForCredit;
    }

    public CreditSubjectBuilder Clone(CreditSubjectBuilder builder)
    {
        return builder.AddParentId(Id)
        .AddLabwork(_labworks)
        .AddLecture(_lectures)
        .AddControlPoint(PointsForCredit);
    }

    public bool CheckAccess(User user)
    {
        if (AuthorId == user.Id) return true;
        return false;
    }

    public void ChangeLectures(User user, IEnumerable<MaterialForLecture> newLectures)
    {
        if (CheckAccess(user))
        {
            _lectures = newLectures;
        }
        else
        {
            throw new Exception("Access denied");
        }
    }
}