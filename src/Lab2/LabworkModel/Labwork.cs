using ITMO.ObjectOrientedProgramming.Lab2.EducationalProgrammModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;

public class Labwork : IEducationalProgrammUnit
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

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string AssessmentCriteria { get; private set; }

    public double Point { get; private set; }

    public Labwork Clone()
    {
        return new Labwork(Id, AuthorId, Title, Description, AssessmentCriteria, Point);
    }
}