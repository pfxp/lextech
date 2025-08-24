namespace Lextech.Core;

public interface INumberRepository
{
    void Add(uint input);
    uint Min();
    uint Max();
    int Count();
    uint this[int index] { get; }
}