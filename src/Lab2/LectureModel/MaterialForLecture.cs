using ITMO.ObjectOrientedProgramming.Lab2.UserModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.LectureModel;

public class MaterialForLecture
{
    public MaterialForLecture(Guid? parentId, Guid? authorId, string title, string description, string content)
    {
        ParentId = parentId;
        Id = Guid.NewGuid();
        AuthorId = authorId;
        _title = title;
        _description = description;
        _content = content;
    }

    public Guid? ParentId { get; init; }

    public Guid Id { get; init; }

    public Guid? AuthorId { get; init; }

    private readonly string _title;
    private readonly string _content;
    private string _description;

    public MaterialForLectureBuilder Clone(MaterialForLectureBuilder builder)
    {
        return builder.AddParentId(Id)
        .AddTitle(_title)
        .AddDescription(_description)
        .AddContent(_content);
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