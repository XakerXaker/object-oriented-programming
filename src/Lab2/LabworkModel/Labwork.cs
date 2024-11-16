using ITMO.ObjectOrientedProgramming.Lab2.UserModel;
using ITMO.ObjectOrientedProgramming.Lab2.ValueObject;

namespace ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;

public class Labwork
{
    public Labwork(Guid? parentId, Guid? authorId, string title, string description, string assessmentCriteria, Points points)
    {
        ParentId = parentId;
        Id = Guid.NewGuid();
        AuthorId = authorId;
        _title = title;
        _description = description;
        _assessmentCriteria = assessmentCriteria;
        Points = points;
    }

    public Guid? ParentId { get; init; }

    public Guid Id { get; init; }

    public Guid? AuthorId { get; init; }

    public Points Points { get; init; }

    private readonly string _title;
    private readonly string _assessmentCriteria;

    private string _description;

    public LabworkBuilder Clone(LabworkBuilder builder)
    {
       return builder.AddParentId(Id)
        .AddTitle(_title)
        .AddDescription(_description)
        .AddAssessmentCriteria(_assessmentCriteria)
        .SetPoints(Points);
    }

    public bool CheckAccess(User user)
    {
        if (AuthorId == user.Id) return true;
        return false;
    }

    public void ChangeDescription(User user, string newDescription)
    {
        if (CheckAccess(user))
        {
            _description = newDescription;
        }
        else
        {
            throw new Exception("Access denied");
        }
    }
}