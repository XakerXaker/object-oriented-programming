namespace ITMO.ObjectOrientedProgramming.Lab4.Commands;

// Кажется, этот интерфейс нужен для того, чтобы юзеры цепочки, которая возвращает билдер также не привязывалась к конкретной команде.
public interface ICommandBuilder
{
    public ICommand Build();
}