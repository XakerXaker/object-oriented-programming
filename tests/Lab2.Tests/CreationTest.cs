using ITMO.ObjectOrientedProgramming.Lab2;
using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;
using ITMO.ObjectOrientedProgramming.Lab2.LectureModel;
using ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;
using ITMO.ObjectOrientedProgramming.Lab2.UserModel;

using Xunit;

namespace Lab2.Tests;

public class CreationTest
{
    [Fact]
    public void CreateSubjectWithoutTotal100Points()
    {
        var user = new User();
        var labworkBuilder = new LabworkBuilder();
        Labwork lab = labworkBuilder.AddAssessmentCriteria(" fg;").AddAuthor(user.Id).AddDescription("ldf").AddTitle("9585").SetPoint(1).Build();
        var examSubjectBuilder = new ExamSubjectBuilder();

        examSubjectBuilder.AddAuthor(user.Id)
            .AddControlPoint(10)
            .AddLecture(new MaterialForLecture(null, user.Id, "ld", "ld", "ld"))
            .AddLabwork(lab);

        Assert.Throws<Exception>(() => examSubjectBuilder.Build());
    }

    [Fact]
    public void NotPermissibleChange()
    {
        bool expectedResult = false;
        var user1 = new User();
        var builder = new LabworkBuilder();
        Labwork lab = builder.AddAssessmentCriteria(" fg;")
            .AddAuthor(user1.Id)
            .AddDescription("ldf")
            .AddTitle("9585")
            .SetPoint(100)
            .Build();
        var user2 = new User();
        var update = new Updater(user2);

        bool result = update.UpdateLab(lab, "test");
        Assert.Equal(result, expectedResult);
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