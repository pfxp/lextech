namespace Lextech.Core;

public class MissingNumberFinderService : IMissingNumberFinderService
{
    /// <summary>
    /// Find the trivial cases before moving onto a solution involving the BSP.
    /// </summary>
    /// <param name="repository"></param>
    /// <returns></returns>
    public Result Find(INumberRepository repository)
    {
        if (repository.Count() == 0)
        {
            return new Result { Summary = Summary.EmptyInput, MissingNumber = null };
        }

        if (repository.Count() == 1)
        {
            return new Result { Summary = Summary.SingleItemInput, MissingNumber = null };
        }

        int minMaxDistance = (int)(repository.Max() - repository.Min());

        if (minMaxDistance + 1 == repository.Count())
        {
            return new Result { Summary = Summary.ConsecutiveNumbersOnly, MissingNumber = null };
        }

        if (minMaxDistance > repository.Count())
        {
            return new Result { Summary = Summary.MultipleMissingNumbers, MissingNumber = null };
        }

        int count = repository.Count();

        for (int i = 0; i < count - 1; i++)
        {
            if (repository[i + 1] - repository[i] > 1)
            {
                return new Result { Summary = Summary.MissingNumberReturned, MissingNumber = repository[i] + 1 };
            }
        }

        return new Result { Summary = Summary.UnhandledCaseBugDetected, MissingNumber = null };
    }
}