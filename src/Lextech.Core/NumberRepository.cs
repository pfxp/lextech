namespace Lextech.Core;

/// <summary>
///
/// </summary>
public class NumberRepository : INumberRepository
{
    private readonly SortedSet<uint> numbers;

    public uint this[int index] 
    {
        get
        {
            if (index < 0 || index >= numbers.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
            
            return numbers.ElementAt(index);
        }
    }

    public NumberRepository()
    {
        numbers = new SortedSet<uint>();
    }

    public void Add(uint input)
    {
        numbers.Add(input);
    }

    public uint Min()
    {
        return numbers.Min();
    }

    public uint Max()
    {
        return numbers.Max();
    }

    public int Count()
    {
        return numbers.Count;
    }
}