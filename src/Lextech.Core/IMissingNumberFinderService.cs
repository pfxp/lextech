namespace Lextech.Core;

public interface IMissingNumberFinderService
{
    Result Find(INumberRepository repository);
}