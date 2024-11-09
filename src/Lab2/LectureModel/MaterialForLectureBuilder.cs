namespace ITMO.ObjectOrientedProgramming.Lab2.LectureModel;

public class MaterialForLectureBuilder
{
    private Guid? _authorId;

    private string? _title;

    private string? _description;

    private string? _content;

    public MaterialForLectureBuilder AddAuthor(Guid? authorId)
    {
        _authorId = authorId;
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
            null,
            _authorId ?? throw new Exception("Invalid material for lecture"),
            _title ?? throw new Exception("Invalid material for lecture"),
            _description ?? throw new Exception("Invalid material for lecture"),
            _content ?? throw new Exception("Invalid material for lecture"));
    }
}