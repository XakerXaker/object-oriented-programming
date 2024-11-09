using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;
using ITMO.ObjectOrientedProgramming.Lab2.UserModel;
using Xunit;

namespace Lab2.Tests;

public class CreationTest
{
    [Fact]
    public void CreateSubjectWithoutTotal100Points()
    {
        var user = new User();
        List<Labwork> labs = [];
        var builder = new LabworkBuilder();
        try
        {
            labs.Add(builder.AddAssessmentCriteria(" fg;").AddAuthor(user.Id).AddDescription("ldf").AddTitle("9585").SetPoint(100).Build());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    [Fact]
    public void NotPermissibleChange()
    {
        var user1 = new User();
        var builder = new LabworkBuilder();
        Labwork lab = builder.AddAssessmentCriteria(" fg;")
            .AddAuthor(user1.Id)
            .AddDescription("ldf")
            .AddTitle("9585")
            .SetPoint(100).Build();

        try
        {
            var user2 = new User();
            user2.ChangeLab(lab);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    [Fact]
    public void CompareProtypeIdAndOriginalId()
    {
        var builder = new LabworkBuilder();
        Labwork lab1 = builder.AddAssessmentCriteria(" fg;")
            .AddAuthor(Guid.NewGuid())
            .AddDescription("ldf")
            .AddTitle("9585")
            .SetPoint(100).Build();

        Labwork lab2 = lab1.Clone();

        Assert.Equal(lab1.Id, lab2.ParentId);
    }
}