using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;
using ITMO.ObjectOrientedProgramming.Lab2.LectureModel;
using ITMO.ObjectOrientedProgramming.Lab2.UserModel;
using ITMO.ObjectOrientedProgramming.Lab2.ValueObject;

namespace ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;

public class ExamSubject : ISubject
{
    public Guid? ParentId { get; init; }

    public Guid Id { get; init; }

    public Guid? AuthorId { get; init; }

    public Points PointsForExam { get; init; }

    private readonly IEnumerable<Labwork> _labworks = [];

    private IEnumerable<MaterialForLecture> _lectures;

    public ExamSubject(Guid? parentId, Guid? authorId, IEnumerable<Labwork> labworks, IEnumerable<MaterialForLecture> lectures, Points pointsForExam)
    {
        ParentId = parentId;
        Id = Guid.NewGuid();
        AuthorId = authorId;
        _labworks = labworks;
        _lectures = lectures;
        PointsForExam = pointsForExam;
    }

    public ExamSubjectBuilder Clone(ExamSubjectBuilder builder)
    {
        return builder.AddParentId(Id)
        .AddLabwork(_labworks)
        .AddLecture(_lectures)
        .AddControlPoint(PointsForExam);
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