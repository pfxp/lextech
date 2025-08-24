# Overview
Coding challenge for Lextech by Peter Pellegrini

# Usage
Compile.
Supply the numbers as space delimited command line arguments.

For example

`lextech 1 2 4` to give the rsult of 3.

# Tests
I tested both the NumberRepository (the source of input numbers) and the MissingNumberFinderService.
Run the unit tests to see some of the possible outputs listed below.

# Possible outputs
The program will output an enumeration describes the input and whether an output missing number
could be returned.

| Description            | Missing number returned? | Description    |
|------------------------|--------------------------|----------------|
| EmptyInput             | No                       | Input: []      |
| SingleItemInput        | No                       | Input: [1]     | 
| ConsecutiveNumbersOnly | No                       | Input: [1,2,3] |
| MultipleMissingNumbers | No                       | Input: [1,2,5] |
| MissingNumberReturned  | Yes                      | Input: [3,0,1] |


# Assumptions
* If duplicate input numbers are specified, the duplicates are silently discarded.
* Any item on the command line that does not parse with UIint.Parse() is silently discarded.

# Search technique
* The typical size of the list of numbers is not supplied, but I move sequentially through the list so on average it will take n/2 searches to find a missing number.
* With more time I would do a binary search so that the number of searches for any gaps would take log2(n) searches. Like on the Price is Right, but I wanted to cap
* the time I spent on the test to 90min. There's probably a recursive way to do this.
* The sorted set I insert into is slower to insert into than a list, but it automatically discards duplicates and sorts the input for me. Retrieval should be quick.

# General thoughts
I haven't implemented dependencity injection in the console app. This can be done but my time is limited.