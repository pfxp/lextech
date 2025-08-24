using Lextech.Core;

namespace Lextech.Tests;

public class NumberRepositoryFixture : IDisposable
{
    public INumberRepository _emptyRepository { get; private set; }
    public INumberRepository _singleItemRepository { get; private set; }
    public INumberRepository _consecutiveNumbersOnlyRepository { get; private set; }
    public INumberRepository _multipleMissingNumbers { get; private set; }
    public INumberRepository _missingNumberReturned { get; private set; }

    public NumberRepositoryFixture()
    {
        // empty
        _emptyRepository = new NumberRepository();

        // single item
        _singleItemRepository = new NumberRepository();
        _singleItemRepository.Add(0);

        // consecutive numbers
        _consecutiveNumbersOnlyRepository = new NumberRepository();
        _consecutiveNumbersOnlyRepository.Add(0);
        _consecutiveNumbersOnlyRepository.Add(1);
        _consecutiveNumbersOnlyRepository.Add(2);

        // multiple Missing Numbers
        _multipleMissingNumbers = new NumberRepository();
        _multipleMissingNumbers.Add(0);
        _multipleMissingNumbers.Add(1);
        _multipleMissingNumbers.Add(4);

        // missing Number Returned
        _missingNumberReturned = new NumberRepository();
        _missingNumberReturned.Add(0);
        _missingNumberReturned.Add(1);
        _missingNumberReturned.Add(2);
        _missingNumberReturned.Add(4);
    }

    public void Dispose()
    {
    }
}