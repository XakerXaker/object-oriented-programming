namespace ITMO.ObjectOrientedProgramming.Lab2.EducationalProgrammModel;

public class EducationalProgram
{
    public EducationalProgram(Guid authorId, IEnumerable<Semester> semesters)
    {
        Id = Guid.NewGuid();
        AuthorId = authorId;
        Semesters = semesters;
    }

    public Guid AuthorId { get; init; }

    public Guid Id { get; init; }

    public IEnumerable<Semester> Semesters { get; private set; }
}