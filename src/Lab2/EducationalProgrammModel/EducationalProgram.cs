namespace ITMO.ObjectOrientedProgramming.Lab2.EducationalProgrammModel;

public class EducationalProgram
{
    public Guid AuthorId { get; init; }

    public IEnumerable<Semester> Semesters { get; private set; }

    public EducationalProgram(Guid authorId, IEnumerable<Semester> semesters)
    {
        Semesters = semesters.ToList();
        AuthorId = authorId;
    }
}