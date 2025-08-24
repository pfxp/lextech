using Lextech.Core;

namespace Lextech.Tests;

public class MissingNumberFinderServiceTest : IClassFixture<NumberRepositoryFixture>
{
    private readonly NumberRepositoryFixture _fixture;

    public MissingNumberFinderServiceTest(NumberRepositoryFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void EmptyInput()
    {
        var missingNumberFinderService = new MissingNumberFinderService();
        var result = missingNumberFinderService.Find(_fixture._emptyRepository);
        Assert.Equal(Summary.EmptyInput, result.Summary);
        Assert.Null(result.MissingNumber);
    }

    [Fact]
    public void SingleItem()
    {
        var missingNumberFinderService = new MissingNumberFinderService();
        var result = missingNumberFinderService.Find(_fixture._singleItemRepository);
        Assert.Equal(Summary.SingleItemInput, result.Summary);
        Assert.Null(result.MissingNumber);
    }

    [Fact]
    public void ConsecutiveNumbers()
    {
        var missingNumberFinderService = new MissingNumberFinderService();
        var result = missingNumberFinderService.Find(_fixture._consecutiveNumbersOnlyRepository);
        Assert.Equal(Summary.ConsecutiveNumbersOnly, result.Summary);
        Assert.Null(result.MissingNumber);
    }

    [Fact]
    public void MultipleMissingNumbers()
    {
        var missingNumberFinderService = new MissingNumberFinderService();
        var result = missingNumberFinderService.Find(_fixture._multipleMissingNumbers);
        Assert.Equal(Summary.MultipleMissingNumbers, result.Summary);
        Assert.Null(result.MissingNumber);
    }

    [Fact]
    public void MissingNumberReturned()
    {
        var missingNumberFinderService = new MissingNumberFinderService();
        var result = missingNumberFinderService.Find(_fixture._missingNumberReturned);
        Assert.Equal(Summary.MissingNumberReturned, result.Summary);
        Assert.Equal((uint)3, result.MissingNumber);
    }
}