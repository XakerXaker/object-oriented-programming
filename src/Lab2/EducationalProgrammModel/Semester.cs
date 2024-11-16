using ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;
using ITMO.ObjectOrientedProgramming.Lab2.ValueObject;

namespace ITMO.ObjectOrientedProgramming.Lab2.EducationalProgrammModel;

public record Semester
{
    public Semester(SemesterNumber semesterNumber, IEnumerable<ISubject> subjects)
    {
        SemesterNumber = semesterNumber;
        Subjects = subjects;
    }

    public SemesterNumber SemesterNumber { get; init; }

    public IEnumerable<ISubject> Subjects { get; private set; }
}