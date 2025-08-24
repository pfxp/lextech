using Lextech.Core;

namespace Lextech.Tests;

public class NumberRepositoryTest
{
    [Fact]
    public void RepoTest()
    {
        var numberRepository = new NumberRepository();
        Assert.Equal(0, numberRepository.Count());

        numberRepository.Add(0);
        Assert.Equal(1, numberRepository.Count());

        // Discard the duplicate
        numberRepository.Add(0);
        Assert.Equal(1, numberRepository.Count());

        numberRepository.Add(1);
        Assert.Equal(2, numberRepository.Count());

        numberRepository.Add(2);
        Assert.Equal(3, numberRepository.Count());

        Assert.Equal((uint) 0, numberRepository.Min());

        Assert.Equal((uint) 2, numberRepository.Max());
    }
}