namespace ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;

public class LabworkBuilder
{
    private Guid? _authorId;

    private string? _title;

    private string? _description;

    private string? _assessmentCriteria;

    private double? _point;

    public LabworkBuilder AddAuthor(Guid authorId)
    {
        _authorId = authorId;
        return this;
    }

    public LabworkBuilder AddTitle(string title)
    {
        _title = title;
        return this;
    }

    public LabworkBuilder AddDescription(string description)
    {
        _description = description;
        return this;
    }

    public LabworkBuilder AddAssessmentCriteria(string assesmentCriteria)
    {
        _assessmentCriteria = assesmentCriteria;
        return this;
    }

    public LabworkBuilder SetPoint(double point)
    {
        _point = point;
        return this;
    }

    public Labwork Build()
    {
        return new Labwork(
            null,
            _authorId ?? throw new Exception("Invalid labwork"),
            _title ?? throw new Exception("Invalid labwork"),
            _assessmentCriteria ?? throw new Exception("Invalid labwork"),
            _description ?? throw new Exception("Invalid Labwork"),
            _point ?? throw new Exception("Invalid labwork"));
    }
}