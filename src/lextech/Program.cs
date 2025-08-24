using Lextech.Core;

void PrintWelcomeBanner()
{
    Console.WriteLine($"Lextech coding challenge by Peter Pellegrini.{Environment.NewLine}");
}

void CheckArguments()
{
    if (args.Length > 1)
        return;

    Console.WriteLine("Error: Invalid number of arguments. You need to supply at least 2 unsigned integers.");
    PrintUsage();
    Console.WriteLine("Exiting.");
}

void PrintUsage()
{
    Console.WriteLine("Usage: lextech num_0 num_1 ... num_n");
}

INumberRepository ProcessArguments()
{
    var numberRepository = new NumberRepository();

    foreach (var arg in args)
    {
        if (uint.TryParse(arg, out uint number))
        {
            numberRepository.Add(number);
        }
    }

    return numberRepository;
}

void PrintResult(Result result)
{
    switch(result.Summary)
    {
        case Summary.EmptyInput:
            Console.WriteLine("No result. No numbers were provided.");
            break;
        case Summary.SingleItemInput:
            Console.WriteLine("No result. Only one number was provided, no missing number can be determined.");
            break;
        case Summary.ConsecutiveNumbersOnly:
            Console.WriteLine("No result. All numbers are consecutive, no missing number.");
            break;
        case Summary.MultipleMissingNumbers:
            Console.WriteLine("No result. There are multiple missing numbers, cannot determine a *single* missing number.");
            break;
        case Summary.MissingNumberReturned:
            Console.WriteLine($"The missing number is: {result.MissingNumber}");
            break;
        case Summary.UnhandledCaseBugDetected:
            Console.WriteLine("No result. An unhandled case was detected, please check the implementation.");
            break;
    }
}



PrintWelcomeBanner();
CheckArguments();
var numberRepo = ProcessArguments();

var missingNumberFinderService = new MissingNumberFinderService();
var result = missingNumberFinderService.Find(numberRepo);

PrintResult(result);