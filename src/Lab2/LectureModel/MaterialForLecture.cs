namespace ITMO.ObjectOrientedProgramming.Lab2.LectureModel;

public class MaterialForLecture
{
    public MaterialForLecture(Guid? parentId, Guid authorId, string title, string description, string content)
    {
        ParentId = parentId;
        Id = Guid.NewGuid();
        AuthorId = authorId;
        Title = title;
        Description = description;
        Content = content;
    }

    public Guid? ParentId { get; init; }

    public Guid Id { get; init; }

    public Guid AuthorId { get; init; }

    public string Title { get;  set; }

    public string Description { get; set; }

    public string Content { get; set; }

    public MaterialForLecture Clone()
    {
        return new MaterialForLecture(Id, AuthorId, Title, Description, Content);
    }
}