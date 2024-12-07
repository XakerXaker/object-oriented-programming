using ITMO.ObjectOrientedProgramming.Lab2.UserModel;
using ITMO.ObjectOrientedProgramming.Lab2.ValueObject;

namespace ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;

public class LabworkBuilder
{
    private readonly User _user;
    private Guid? _parentId;
    private string? _title;

    private string? _description;

    private string? _assessmentCriteria;

    private Points? _points;

    public LabworkBuilder AddParentId(Guid? parentId)
    {
        _parentId = parentId;
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

    public LabworkBuilder SetPoints(Points points)
    {
        _points = points;
        return this;
    }

    public Labwork Build()
    {
        return new Labwork(
            _parentId,
            _user.Id,
            _title ?? throw new Exception("Invalid labwork"),
            _assessmentCriteria ?? throw new Exception("Invalid labwork"),
            _description ?? throw new Exception("Invalid Labwork"),
            _points ?? throw new Exception("Invalid labwork"));
    }

    public LabworkBuilder(User user)
    {
        _user = user;
    }
}