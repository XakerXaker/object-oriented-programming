using ITMO.ObjectOrientedProgramming.Lab2.LabworkModel;
using ITMO.ObjectOrientedProgramming.Lab2.LectureModel;
using ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;
using ITMO.ObjectOrientedProgramming.Lab2.UserModel;
using ITMO.ObjectOrientedProgramming.Lab2.ValueObject;

using Xunit;

namespace Lab2.Tests;

public class CreationTest
{
    [Fact]
    public void CreateSubjectWithoutTotal100Points()
    {
        var user = new User();
        var labworkBuilder = new LabworkBuilder(user);
        Labwork lab = labworkBuilder.AddAssessmentCriteria(" fg;")
        .AddDescription("ld")
        .AddTitle("9585")
        .SetPoints(new Points(1))
        .Build();
        var labworks = new List<Labwork>
        {
            lab,
        };

        var lectureBuilder = new MaterialForLectureBuilder(user);
        MaterialForLecture lecture = lectureBuilder.AddDescription("587")
        .AddContent("587")
        .AddTitle("587")
        .Build();
        var lectures = new List<MaterialForLecture>
        {
            lecture,
        };

        var examSubjectBuilder = new ExamSubjectBuilder(user);
        examSubjectBuilder.AddControlPoint(new Points(10))
            .AddLecture(lectures)
            .AddLabwork(labworks);

        Assert.Throws<Exception>(() => examSubjectBuilder.Build());
    }

    [Fact]
    public void NotPermissibleChange()
    {
        var user1 = new User();
        var builder = new LabworkBuilder(user1);
        Labwork lab = builder.AddAssessmentCriteria(" fg;")
            .AddDescription("ldf")
            .AddTitle("9585")
            .SetPoints(new Points(100))
            .Build();
        var user2 = new User();

        Assert.Throws<Exception>(() => lab.ChangeDescription(user2, "892"));
    }

    [Fact]
    public void CompareProtypeIdAndOriginalId()
    {
        var user = new User();
        var builder = new LabworkBuilder(user);
        Labwork lab1 = builder.AddAssessmentCriteria(" fg;")
            .AddDescription("ldf")
            .AddTitle("9585")
            .SetPoints(new Points(100))
            .Build();

        LabworkBuilder labworkBuilder = lab1.Clone(new LabworkBuilder(user));
        Labwork lab2 = labworkBuilder.Build();
        Assert.Equal(lab1.Id, lab2.ParentId);
    }
}