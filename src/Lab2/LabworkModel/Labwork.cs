namespace ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;

public class Labwork
{
    public Labwork(Guid? parentId, Guid authorId, string title, string description, string assessmentCriteria, double point)
    {
        Id = Guid.NewGuid();
        ParentId = parentId;
        AuthorId = authorId;
        Title = title;
        Description = description;
        AssessmentCriteria = assessmentCriteria;
        Point = point;
    }

    public Guid? ParentId { get; init; }

    public Guid Id { get; init; }

    public Guid AuthorId { get; init; }

    public string Title { get; set; }

    public string Description { get;  set; }

    public string AssessmentCriteria { get; set; }

    public double Point { get; set; }

    public Labwork Clone()
    {
        return new Labwork(Id, AuthorId, Title, Description, AssessmentCriteria, Point);
    }
}