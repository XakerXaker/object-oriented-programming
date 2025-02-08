namespace ITMO.ObjectOrientedProgramming.Lab4.Input;

public class Request
{
    private readonly string _input;

    public string[] Tokens { get; }

    public int Length => Tokens.Length;

    public Request(string input)
    {
        _input = input;

        Tokens = _input.Split(' ');
    }

    public string GetTokenFromIndex(int i)
    {
        if (i >= Length)
            throw new Exception("Out of range in tokens array");

        return Tokens[i];
    }
}