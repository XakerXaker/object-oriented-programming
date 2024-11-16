using ITMO.ObjectOrientedProgramming.Lab2.UserModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.LectureModel;

public class MaterialForLectureBuilder
{
    private readonly User _user;
    private Guid? _parentId;

    private string? _title;

    private string? _description;

    private string? _content;

    public MaterialForLectureBuilder AddParentId(Guid? parentId)
    {
        _parentId = parentId;
        return this;
    }

    public MaterialForLectureBuilder AddTitle(string title)
    {
        _title = title;
        return this;
    }

    public MaterialForLectureBuilder AddDescription(string description)
    {
        _description = description;
        return this;
    }

    public MaterialForLectureBuilder AddContent(string content)
    {
        _content = content;
        return this;
    }

    public MaterialForLecture Build()
    {
        return new MaterialForLecture(
            _parentId,
            _user.Id,
            _title ?? throw new Exception("Invalid material for lecture"),
            _description ?? throw new Exception("Invalid material for lecture"),
            _content ?? throw new Exception("Invalid material for lecture"));
    }

    public MaterialForLectureBuilder(User user)
    {
        _user = user;
    }
}