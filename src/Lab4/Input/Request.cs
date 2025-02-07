namespace ITMO.ObjectOrientedProgramming.Lab4.Input;

public class Request
{
    private readonly string _input;

    public string[] Tokens { get; }

    private int _position;

    public string Current => Tokens[_position];

    public int Length => _input.Length;

    public Request(string input)
    {
        _position = 0;
        _input = input;

        Tokens = _input.Split(' ');
    }

    public bool MoveNext()
    {
        _position++;
        return _position < Tokens.Length;
    }

    public void Reset()
    {
        _position = 0;
    }
}