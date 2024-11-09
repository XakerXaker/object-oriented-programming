using ITMO.ObjectOrientedProgramming.Lab2.EducationalProgrammModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.LectureModel;

public class MaterialForLecture : IEducationalProgrammUnit
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

    public string Title { get;  private set; }

    public string Description { get; private set; }

    public string Content { get;  private set; }

    public MaterialForLecture Clone()
    {
        return new MaterialForLecture(Id, AuthorId, Title, Description, Content);
    }
}