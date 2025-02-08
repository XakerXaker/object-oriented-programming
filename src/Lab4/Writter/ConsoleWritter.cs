namespace ITMO.ObjectOrientedProgramming.Lab4.Writter;

public class ConsoleWritter : IWritter
{
    public void ShowContent(string content)
    {
        Console.WriteLine(content);
    }
}