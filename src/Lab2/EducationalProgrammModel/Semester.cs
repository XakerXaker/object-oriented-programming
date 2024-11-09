using ITMO.ObjectOrientedProgramming.Lab2.SubjectModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.EducationalProgrammModel;

public record Semester
{
    public uint SemesterNumber { get; init; }

    public IEnumerable<ISubject> Subjects { get; private set; }

    public Semester(uint semesterNumber, IEnumerable<ISubject> subjects)
    {
        SemesterNumber = semesterNumber;
        Subjects = subjects;
    }
}