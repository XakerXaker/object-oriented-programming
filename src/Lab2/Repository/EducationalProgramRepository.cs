using ITMO.ObjectOrientedProgramming.Lab2.EducationalProgrammModel;

namespace ITMO.ObjectOrientedProgramming.Lab2.Repository;

public class EducationalProgramRepository
{
    private readonly List<EducationalProgram> data = [];

    public void Add(EducationalProgram program)
    {
        data.Add(program);
    }

    public EducationalProgram? SearchById(EducationalProgram program)
    {
        foreach (EducationalProgram p in data)
        {
            if (p == program) return p;
        }

        return null;
    }
}